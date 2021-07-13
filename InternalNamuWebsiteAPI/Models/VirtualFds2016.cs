using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class VirtualFds2016
    {
        public int Fdid { get; set; }
        public string UserName { get; set; }
        public string Granter { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
