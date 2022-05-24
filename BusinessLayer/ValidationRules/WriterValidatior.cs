using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidatior:AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adini Boş Geçemesiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soy adini boş geçemesiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkimda Adini Boş Geçemesiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Hakkimda Adini Boş Geçemesiniz");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lutfen 20  karakter Fazla Giris Yapmayin..");
            RuleFor(x => x.WriterTitle).MaximumLength(20).WithMessage("Ünvan Adini Boş Geçemesiniz");

        }
    }
}
