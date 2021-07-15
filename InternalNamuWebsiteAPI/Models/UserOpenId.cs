using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class UserOpenId
    {
        public UserOpenId()
        {
            MenuItemsXuserOpenIds = new HashSet<MenuItemsXuserOpenId>();
            UsersLogs = new HashSet<UsersLog>();
            VirtualFdGranterNavigations = new HashSet<VirtualFd>();
            VirtualFdUserNameNavigations = new HashSet<VirtualFd>();
        }

        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Nam { get; set; }
        public string Mail { get; set; }

        [JsonIgnore]
        public string Extention { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
        [JsonIgnore]
        public string Country { get; set; }
        [JsonIgnore]
        public string LoginFlr { get; set; }
        [JsonIgnore]
        public string PasswordFlr { get; set; }
        public string LoginMantis { get; set; }
        [JsonIgnore]
        public string PasswordMantis { get; set; }
        [JsonIgnore]
        public string LoginMail { get; set; }
        [JsonIgnore]
        public string PasswordMail { get; set; }
        [JsonIgnore]
        public string LoginCrp { get; set; }
        [JsonIgnore]
        public string PasswordCrp { get; set; }
        [JsonIgnore]
        public string LoginCrvwiki { get; set; }
        [JsonIgnore]
        public string PasswordCrvwiki { get; set; }
        [JsonIgnore]
        public string LoginBaseCamp { get; set; }
        [JsonIgnore]
        public string PasswordBaseCamp { get; set; }
        [JsonIgnore]
        public string LoginFrogLog { get; set; }
        [JsonIgnore]
        public string PasswordFrogLog { get; set; }
        [JsonIgnore]
        public string LoginBlog { get; set; }
        [JsonIgnore]
        public string PasswordBlog { get; set; }
        public string LoginJabber { get; set; }
        [JsonIgnore]
        public string PasswordJabber { get; set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; }
        [JsonIgnore]
        public int Fdcredits { get; set; }
        [JsonIgnore]
        public bool CanRedeem { get; set; }
        [JsonIgnore]
        public bool CanGrantFdcredits { get; set; }
        [JsonIgnore]
        public bool CanSetGoals { get; set; }
        [JsonIgnore]
        public string Manager { get; set; }
        [JsonIgnore]
        public bool CanUseFrogQuery { get; set; }
        [JsonIgnore]
        public string ManagerImpersonates { get; set; }
        [JsonIgnore]

        public virtual ICollection<MenuItemsXuserOpenId> MenuItemsXuserOpenIds { get; set; }
        public virtual ICollection<UsersLog> UsersLogs { get; set; }
        public virtual ICollection<VirtualFd> VirtualFdGranterNavigations { get; set; }
        public virtual ICollection<VirtualFd> VirtualFdUserNameNavigations { get; set; }
    }
}
