using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public System.Guid RoleId { get; set; }
        public System.Guid ApplicationId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual Application Application { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
