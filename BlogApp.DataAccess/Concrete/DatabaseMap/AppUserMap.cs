using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DataAccess.Concrete.DatabaseMap
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(I => I.Username).IsUnique();

            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Username).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(20).IsRequired();
            builder.Property(I => I.Name).HasMaxLength(50);
            builder.Property(I => I.Surname).HasMaxLength(50);
            builder.Property(I => I.Email).HasMaxLength(70);

            builder.HasMany(I => I.Blogs).WithOne(I => I.AppUser).HasForeignKey(I=>I.AuthorId);



        }
    }
}
