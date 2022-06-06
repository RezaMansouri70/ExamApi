using DomainClass.UserExam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlServer.EfConfiguration
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.Property(cb => cb.Mobile)
              .IsRequired()
               .HasMaxLength(11);

            builder.Property(cb => cb.Name)
              .IsRequired()
               .HasMaxLength(100);

            builder.Property(cb => cb.Password)
            .IsRequired()
             .HasMaxLength(100);

        }
    }
}
