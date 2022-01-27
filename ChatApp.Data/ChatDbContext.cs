using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Chat;
using ChatApp.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions options) : base(options)
        {

        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }

        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<ConversationParticipant> ConversationParticipants { get; set;}
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Media> MessageMedia { get; set; }
    }
}
