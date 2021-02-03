using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DataAccess.Concrete.DatabaseMap
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            
            builder.Property(I => I.Title).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Definition).HasMaxLength(80);
            builder.Property(I => I.Description).HasMaxLength(1000).IsRequired();
            builder.Property(I => I.PublishedTime).IsRequired();
            builder.Property(I => I.BlogImage).HasMaxLength(100).IsRequired(false);
            // Comment Relation
            builder.HasMany(I => I.Comments).WithOne(I => I.RelatedBlog).HasForeignKey(I => I.RelatedBlogId);

            // BlogCategory Relation

            builder.HasMany(I => I.BlogCategories).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);

        }
    }
}
