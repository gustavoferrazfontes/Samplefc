namespace SampleFC.RegisterAuthentication.Data.Migrations
{
    using Core.Domain.Model.Model.UserAggregate;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleFC.RegisterAuthentication.Data.Context.UserRegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleFC.RegisterAuthentication.Data.Context.UserRegistrationContext context)
        {
     
            context.User.Add(new User("admin@admin.com", "admin@admin.com", "admin", "btWDPPNShuv4Zit7WUnw10K77D8="));
            context.SaveChanges();
        }
    }
}
