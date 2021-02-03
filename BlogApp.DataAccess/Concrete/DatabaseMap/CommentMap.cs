using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DataAccess.Concrete.DatabaseMap
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasMaxLength(200);
            builder.Property(I => I.AuthorName).HasMaxLength(50);
            builder.Property(I => I.AuthorSurname).HasMaxLength(50);
            builder.Property(I => I.AuthorEmail).HasMaxLength(50);

            builder.HasOne(I => I.ParentComment).WithMany(I => I.Replies).HasForeignKey(I=>I.ParentCommentId);





        }
    }
}
