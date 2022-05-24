using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Lutfen Kategori Adini Boş Geçemesiniz");
            RuleFor(x => x.CategoryDescreption).NotEmpty().WithMessage("Aciklamani Bos Gecemesiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen En Azi 3 karakter Girniniz..");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lutfen 20  karakter Fazla Giris Yapmayin..");
              
        }
    }
}
