using Philcosa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class IssuedByEntity : AuditableBaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Postcard Postcard { get; set; }
    }
}
