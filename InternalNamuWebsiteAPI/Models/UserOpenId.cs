using System;
using System.Collections.Generic;

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
        public string Extention { get; set; }
        public int Status { get; set; }
        public string Country { get; set; }
        public string LoginFlr { get; set; }
        public string PasswordFlr { get; set; }
        public string LoginMantis { get; set; }
        public string PasswordMantis { get; set; }
        public string LoginMail { get; set; }
        public string PasswordMail { get; set; }
        public string LoginCrp { get; set; }
        public string PasswordCrp { get; set; }
        public string LoginCrvwiki { get; set; }
        public string PasswordCrvwiki { get; set; }
        public string LoginBaseCamp { get; set; }
        public string PasswordBaseCamp { get; set; }
        public string LoginFrogLog { get; set; }
        public string PasswordFrogLog { get; set; }
        public string LoginBlog { get; set; }
        public string PasswordBlog { get; set; }
        public string LoginJabber { get; set; }
        public string PasswordJabber { get; set; }
        public bool IsAdmin { get; set; }
        public int Fdcredits { get; set; }
        public bool CanRedeem { get; set; }
        public bool CanGrantFdcredits { get; set; }
        public bool CanSetGoals { get; set; }
        public string Manager { get; set; }
        public bool CanUseFrogQuery { get; set; }
        public string ManagerImpersonates { get; set; }

        public virtual ICollection<MenuItemsXuserOpenId> MenuItemsXuserOpenIds { get; set; }
        public virtual ICollection<UsersLog> UsersLogs { get; set; }
        public virtual ICollection<VirtualFd> VirtualFdGranterNavigations { get; set; }
        public virtual ICollection<VirtualFd> VirtualFdUserNameNavigations { get; set; }
    }
}
