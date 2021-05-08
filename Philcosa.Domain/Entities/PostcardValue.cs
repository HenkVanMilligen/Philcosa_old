using Philcosa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class PostcardValue : AuditableBaseEntity
    {
        //public int CollectableId { get; set; }

        //public Collectable Collectable { get; set; }
        public string Code { get; set; }
        public decimal MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}
