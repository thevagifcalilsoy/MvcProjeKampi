using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityLayer.Concrete
{
  public  class Content
    {
        [Key]
        public int ContentId { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentState { get; set; }

        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }
        //ContentYazar
        //ContentBaslik
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
