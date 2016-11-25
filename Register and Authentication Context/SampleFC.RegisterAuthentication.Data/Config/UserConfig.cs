using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using System.Data.Entity.ModelConfiguration;

namespace SampleFC.RegisterAuthentication.Data.Config
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {

            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired();

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.Password)
                .IsRequired();

            Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Ignore(u => u.EmailConfirmed);



        }
    }
}
