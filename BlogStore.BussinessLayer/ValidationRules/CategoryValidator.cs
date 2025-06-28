using BlogStore.EnitityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Lutfen kategori adını giriniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen en az 3 karakter giriniz");
            RuleFor(x=>x.CategoryName).MaximumLength(20).WithMessage("Lutfen en fazla 30 karakter giriniz");
        }
    }
}
