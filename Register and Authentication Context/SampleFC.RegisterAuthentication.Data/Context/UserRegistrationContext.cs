using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Data.Config;
using System.Data.Entity;

namespace SampleFC.RegisterAuthentication.Data.Context
{
    public class UserRegistrationContext : DbContext
    {
        public UserRegistrationContext() : base("UserRegistrationConnection")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
