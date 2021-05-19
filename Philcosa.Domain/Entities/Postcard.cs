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
        public string IdOnDate { get; set; }
        public int? IssuedById { get; set; }
        public IssuedByEntity IssuedBy { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string AmountIssued { get; set; }
        public string Atlas { get; set; }
        public string Alberta { get; set; }
        public int? PostcardTypeId { get; set; }
        public PostcardType PostcardType { get; set; }
        public int? PostcardValueId { get; set; }
        public PostcardValue Value { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public string Path { get; set; }

        public IList<PostcardTheme> PostcardThemes { get; set; }
    }
}
