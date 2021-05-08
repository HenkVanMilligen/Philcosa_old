using Philcosa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class PostcardTheme : AuditableBaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Postcard> Postcards { get; set; }
    }
}
