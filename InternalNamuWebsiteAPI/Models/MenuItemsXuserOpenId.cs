using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class MenuItemsXuserOpenId
    {
        public int IdMenuItems { get; set; }
        public string UserName { get; set; }

        public virtual MenuItem IdMenuItemsNavigation { get; set; }
        public virtual UserOpenId UserNameNavigation { get; set; }
    }
}
