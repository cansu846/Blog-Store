using BlogStore.EnitityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.ValidationRules
{
    public class ArticleValidator:AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bos gecilemez").MaximumLength(10).WithMessage("en az 10 karakter giriniz")
                .MaximumLength(100).WithMessage("Lutfen en fazla 100 karakter veri girişi yapınız");
        }
    }
}
