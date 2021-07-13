using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuItemsXuserOpenIds = new HashSet<MenuItemsXuserOpenId>();
        }

        public int IdMenuItems { get; set; }
        public string NameMenu { get; set; }
        public string ValueItem { get; set; }
        public string ToolTip { get; set; }
        public int? TipoItem { get; set; }

        public virtual ICollection<MenuItemsXuserOpenId> MenuItemsXuserOpenIds { get; set; }
    }
}
