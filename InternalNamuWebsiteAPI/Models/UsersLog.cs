using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class UsersLog
    {
        public int UserLogId { get; set; }
        public string UserName { get; set; }
        public string SessionId { get; set; }
        public string Ip { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public virtual UserOpenId UserNameNavigation { get; set; }
    }
}
