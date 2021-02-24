using BlogApp.Entities.DTO.CategoryDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Validation
{
  public  class CategoryUpdateValidator: AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Category should have a name");

            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Category id can't be left empty");




        }
    }
}
