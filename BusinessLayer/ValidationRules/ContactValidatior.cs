using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidatior : AbstractValidator<Contact>
    {
        public ContactValidatior()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemesiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adini Bos Gecemesiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanici Adini Bos Gecemesiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lutfen En Azi 3 karakter Girniniz..");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lutfen En Azi 3 karakter Girniniz..");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Lutfen 50  karakter Fazla Giris Yapmayin..");
        }
    }
}
