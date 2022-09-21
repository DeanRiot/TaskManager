namespace TaskManager.Model.Repository.EntityFramework.Behaviors.Task
{
    public interface ITaskBahavior
    {
        public uint CreateTask(Data.Column column, Context.User user);
        public uint UpdateTask(Data.Column column, Context.User user);
    }
}
