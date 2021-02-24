using BlogApp.Entities.DTO.CategoryDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Validation
{
    public class CategoryCreateValidator: AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateValidator()
        {
            RuleFor(I => I.Id).NotEmpty().WithMessage("A category should have an Id");            RuleFor(I => I.Id).NotEmpty().WithMessage("A category should have an Id");
            RuleFor(I => I.Name).NotEmpty().WithMessage("A category should have a name");
    
        }
    }
}
