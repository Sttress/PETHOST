using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PETHOST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETHOST.IRelationalData.Mapping
{
    internal class UserAdminMapping : IEntityTypeConfiguration<UserAdmin>
    {
        public void Configure(EntityTypeBuilder<UserAdmin> builder)
        {
            builder.ToTable("UsersAdmin");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(70);
            builder.Property(u => u.Active).IsRequired().HasDefaultValue(true);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Phone).HasMaxLength(20);
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.UpdatedAt).IsRequired(false);
        }
    }
}
