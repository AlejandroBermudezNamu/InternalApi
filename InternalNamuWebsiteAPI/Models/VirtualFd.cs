using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class VirtualFd
    {
        public int Fdid { get; set; }
        public string UserName { get; set; }
        public string Granter { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual UserOpenId GranterNavigation { get; set; }
        public virtual UserOpenId UserNameNavigation { get; set; }
    }
}
