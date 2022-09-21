using Microsoft.EntityFrameworkCore;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class TaskmanContext : DbContext
    {
        private TaskmanContext() : base() { }
        public TaskmanContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Auth> Auth { get; set; }
        public virtual DbSet<Board> Board { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
