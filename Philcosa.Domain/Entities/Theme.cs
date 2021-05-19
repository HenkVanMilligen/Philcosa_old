using Philcosa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class Theme : AuditableBaseEntity
    {
        public string Name { get; set; }

        public IList<PostcardTheme> PostcardThemes { get; set; }
    }
}
