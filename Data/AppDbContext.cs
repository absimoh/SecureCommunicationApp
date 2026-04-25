using Microsoft.EntityFrameworkCore;
using SecureCommunicationApp.Models;

namespace SecureCommunicationApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<GroupMember>()
                .HasOne(g => g.User)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GroupMember>()
                .HasOne(g => g.ChatGroup)
                .WithMany(c => c.Members)
                .HasForeignKey(g => g.ChatGroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}