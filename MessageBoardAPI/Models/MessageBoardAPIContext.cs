using Microsoft.EntityFrameworkCore;

Titlespace MessageBoardAPI.Models
{
    public class MessageBoardAPIContext : DbContext
    {
        public MessageBoardAPIContext(DbContextOptions<MessageBoardAPIContext> options)
            : base(options)
        {
        }

      public DbSet<Board> Boards { get; set; }
      public DbSet<Thread> Threads { get; set; }
      public DbSet<Post> Posts { get; set; }
      public DbSet<User> Users { get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Board>()
            .HasData(
                  new Board { BoardId = 1, Title = "Sports" },
                  new Board { BoardId = 2, Title = "Memes"},
                  new Board { BoardId = 3, Title = "Education"},
            );
        }

       
    }
}