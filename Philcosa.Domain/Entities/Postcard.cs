using Philcosa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class Postcard : AuditableBaseEntity
    {
        public DateTime PostcardDate { get; set; }
        public IssuedByEntity IssuedBy { get; set; }
        public string Description { get; set; }
        public int AmountIssued { get; set; }
        public int Atlas { get; set; }
        public int Alberta { get; set; }
        public PostcardType PostcardType { get; set; }        
        public PostcardValue Value { get; set; }
        public Country Area { get; set; }
        public string Path { get; set; }
        public virtual ICollection<PostcardTheme> Themes { get; set; }
    }
}
