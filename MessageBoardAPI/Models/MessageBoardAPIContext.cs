using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoardAPI.Models
{
    public class MessageBoardAPIContext : DbContext
    {
        public MessageBoardAPIContext(DbContextOptions<MessageBoardAPIContext> options)
            : base(options)
        {
        }

      public DbSet<Message> Messages { get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
      {

        builder.Entity<Message>()
            .HasData(
                new Message { MessageId = 1, Body = "This is a test message", Group = "TEST", Date = DateTime.Parse("2022-01-01,"), Author = "Mark" },
                new Message { MessageId = 2, Body = "This is a test message", Group = "TEST 1", Date = DateTime.Parse("2022-01-01T10:10:10"), Author = "Mark" },
                new Message { MessageId = 3, Body = "This is a test message", Group = "TEST", Date = DateTime.Parse("2022-01-01T10:10:10"), Author = "Mark" },
                new Message { MessageId = 4, Body = "This is a test message", Group = "TEST 1", Date = DateTime.Parse("2022-01-01T10:10:10"), Author = "Jack" },
                new Message { MessageId = 5, Body = "This is a test message", Group = "TEST", Date = DateTime.Parse("2022-01-01T10:10:10"), Author = "Jack" }
            );
        } 
    }
}