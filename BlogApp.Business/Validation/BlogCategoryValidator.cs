using BlogApp.Entities.DTO.BlogDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Validation
{
   public class BlogCategoryValidator: AbstractValidator<BlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(I => I.CategoryId).NotEmpty().WithMessage("Blog should have a category");

            RuleFor(I => I.BlogId).NotEmpty().WithMessage("Blog should have an id");



        }
    }
}
