using Philcosa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class PostcardTheme 
    {        
        public int PostcardId { get; set; }
        public Postcard Postcard { get; set; }

        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

    }
}
