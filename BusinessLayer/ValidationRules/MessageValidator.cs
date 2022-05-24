using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alici Adresini Boş Geçemesiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adini Bos Gecemesiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaji boş Gecemesiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lutfen En Azi 3 karakter Girniniz..");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lutfen 100  karakter Fazla Giris Yapmayin..");
        }
    }
}
