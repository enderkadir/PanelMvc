using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class MakaleTakip
    {
        public int MakaleID { get; set; }
        public string MailAdresi { get; set; }
        public virtual Makale Makale { get; set; }
    }
}
