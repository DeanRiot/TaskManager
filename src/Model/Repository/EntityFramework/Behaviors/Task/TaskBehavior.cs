using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskManager.Model.Repository.EntityFramework.Context;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.Task
{
    public class TaskBehavior:ITaskBahavior
    {
        DbContextOptions _options;
        public TaskBehavior(DbContextOptions options) => _options = options;

        public uint CreateTask(Data.Column column, Context.User user)
        {
            using (TaskmanContext context = new(_options))
            {
                var task = new Context.Task()
                {
                    Text = column.tasks[0].text,
                    Status = Status.OPENED,
                    SectionID = column.id,
                    Deadline = DateTime.Parse(column.tasks[0].deadline),
                };

                context.Task.Add(task);
                context.SaveChanges();

                SaveTrack(user, context, task, "Создана");
                context.SaveChanges();
                return task.TaskId;
            }
        }

        public uint UpdateTask(Data.Column column, Context.User user)
        {
            var input_task = column.tasks[0];

            using (TaskmanContext context = new(_options))
            {
                Context.Task task = (Context.Task)context.Task.Where(t => t.SectionID.Equals(input_task.id));
                if (input_task.comments is not null)
                {
                    var id = AddComment(context, input_task, user);
                    SaveTrack(user, context, task, "Добавил коментарий");
                    return id;
                }
                if (input_task.responisbility is not null)
                {
                    ChangeResponsibility(context,input_task,user);
                    SaveTrack(user, context, task, "Изменнеы ответственные");
                    return uint.MaxValue;
                }
                if (input_task.deadline is not null) {
                    task.Deadline = DateTime.Parse(input_task.deadline);
                    SaveTrack(user, context, task, "Изменена дата окончания");
                }
                if (input_task.text is not null) {
                    task.Text = input_task.text;
                    SaveTrack(user, context, task, "Изменен текст");
                }
                context.Task.Update(task);
                context.SaveChanges();
                return uint.MaxValue;
            }
        }

        private uint AddComment(TaskmanContext context, Data.Task task, Context.User user)
        {
            Context.Task finded = (Context.Task) context.Task.Where(t => t.TaskId.Equals(task.id));
            var comm = new Comment()
            {
                date = DateTime.Now,
                TaskId = finded.TaskId,
                User = user,
                Text = task.comments[0].text
            };
            context.Comment.Add(comm);
            context.SaveChanges();
            return (uint)context.Comment.Where(c=>c.Equals(comm)).Select(c=>c.CommentId).First();
        }
        private void ChangeResponsibility(TaskmanContext context, Data.Task task, Context.User user)
        {
            var t = (Context.Task) context.Task.Where(t => t.TaskId == task.id);

            t.responsibility.Clear();
            task.responisbility.ForEach(r =>
            {
                var user = (Context.User) context.User.Where(u => u.UserId == r.id);
                t.responsibility.Add(user);
            });
            context.SaveChanges();
        }

        private static void SaveTrack(Context.User user, TaskmanContext context, Context.Task task, string action)
        {
            context.Track.Add(new Track()
            {
                Task = task,
                Date = DateTime.Now,
                User = user,
                Opertion = action
            });
        }
    }
}
