using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DataAccess.Concrete.DatabaseMap
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(50).IsRequired();

            builder.Property(I => I.ParentCategoryId).IsRequired(false);

             
            builder.HasMany(I => I.BlogCategories).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);

            builder.HasOne(I => I.ParentCategory).WithMany(I => I.SubCategories).HasForeignKey(I => I.ParentCategoryId);

        }
    }
}
