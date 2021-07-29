using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class OpenIdContext : DbContext
    {
        public OpenIdContext()
        {
        }

        public OpenIdContext(DbContextOptions<OpenIdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttackerTable> AttackerTables { get; set; }
        public virtual DbSet<FrogDollar> FrogDollars { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemsXuserOpenId> MenuItemsXuserOpenIds { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<UserOpenId> UserOpenIds { get; set; }
        public virtual DbSet<UsersLog> UsersLogs { get; set; }
        public virtual DbSet<ValuesForWidget> ValuesForWidgets { get; set; }
        public virtual DbSet<ValuesForWidgetsHistory> ValuesForWidgetsHistories { get; set; }
        public virtual DbSet<ValuesForWidgetsHistoryFinance> ValuesForWidgetsHistoryFinances { get; set; }
        public virtual DbSet<VariableMaintenance> VariableMaintenances { get; set; }
        public virtual DbSet<VirtualFd> VirtualFds { get; set; }
        public virtual DbSet<VirtualFds2016> VirtualFds2016s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=10.0.61.55;Database=OpenId;User Id=sa;Password=5f7d*PnN*s");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AttackerTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AttackerTable");

                entity.Property(e => e.Data)
                    .HasColumnType("text")
                    .HasColumnName("data");
            });

            modelBuilder.Entity<FrogDollar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FrogDollar");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.IdMenuItems)
                    .HasName("PK_menuItems");

                entity.Property(e => e.IdMenuItems).HasColumnName("idMenuItems");

                entity.Property(e => e.NameMenu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameMenu");

                entity.Property(e => e.TipoItem).HasColumnName("tipoItem");

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("toolTip");

                entity.Property(e => e.ValueItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("valueItem");
            });

            modelBuilder.Entity<MenuItemsXuserOpenId>(entity =>
            {
                entity.HasKey(e => new { e.IdMenuItems, e.UserName });

                entity.ToTable("MenuItemsXUserOpenId");

                entity.Property(e => e.IdMenuItems).HasColumnName("idMenuItems");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.HasOne(d => d.IdMenuItemsNavigation)
                    .WithMany(p => p.MenuItemsXuserOpenIds)
                    .HasForeignKey(d => d.IdMenuItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItemsXUserOpenId_MenuItems1");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.MenuItemsXuserOpenIds)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItemsXUserOpenId_UserOpenId");
            });

            modelBuilder.Entity<Sysdiagram>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<UserOpenId>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("UserOpenId");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.Property(e => e.CanGrantFdcredits).HasColumnName("canGrantFDCredits");

                entity.Property(e => e.CanRedeem).HasColumnName("canRedeem");

                entity.Property(e => e.CanSetGoals).HasColumnName("canSetGoals");

                entity.Property(e => e.CanUseFrogQuery).HasColumnName("canUseFrogQuery");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country")
                    .HasDefaultValueSql("(N'CR')");

                entity.Property(e => e.Extention)
                    .HasMaxLength(50)
                    .HasColumnName("extention");

                entity.Property(e => e.Fdcredits).HasColumnName("FDCredits");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.LoginBaseCamp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginBaseCamp");

                entity.Property(e => e.LoginBlog)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginBlog");

                entity.Property(e => e.LoginCrp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginCRP");

                entity.Property(e => e.LoginCrvwiki)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginCRVWiki");

                entity.Property(e => e.LoginFlr)
                    .HasMaxLength(50)
                    .HasColumnName("loginFLR");

                entity.Property(e => e.LoginFrogLog)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginFrogLog");

                entity.Property(e => e.LoginJabber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginJabber");

                entity.Property(e => e.LoginMail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginMail");

                entity.Property(e => e.LoginMantis)
                    .HasMaxLength(50)
                    .HasColumnName("loginMantis");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mail");

                entity.Property(e => e.Manager)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.ManagerImpersonates)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("managerImpersonates");

                entity.Property(e => e.Nam)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nam");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pass");

                entity.Property(e => e.PasswordBaseCamp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordBaseCamp");

                entity.Property(e => e.PasswordBlog)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordBlog");

                entity.Property(e => e.PasswordCrp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordCRP");

                entity.Property(e => e.PasswordCrvwiki)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordCRVWiki");

                entity.Property(e => e.PasswordFlr)
                    .HasMaxLength(50)
                    .HasColumnName("passwordFLR");

                entity.Property(e => e.PasswordFrogLog)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordFrogLog");

                entity.Property(e => e.PasswordJabber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordJabber");

                entity.Property(e => e.PasswordMail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordMail");

                entity.Property(e => e.PasswordMantis)
                    .HasMaxLength(50)
                    .HasColumnName("passwordMantis");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<UsersLog>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.SessionId, e.UserLogId })
                    .HasName("PK_UsersLog_1");

                entity.ToTable("UsersLog");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userLogId");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("beginDate");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.UsersLogs)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersLog_UserOpenId");
            });

            modelBuilder.Entity<ValuesForWidget>(entity =>
            {
                entity.HasKey(e => e.IdValuesWidgets);

                entity.Property(e => e.IdValuesWidgets).HasColumnName("idValuesWidgets");

                entity.Property(e => e.AccountPayable).HasColumnType("money");

                entity.Property(e => e.AccountReceivable).HasColumnType("money");

                entity.Property(e => e.AverageTicker).HasColumnType("money");

                entity.Property(e => e.ClosingRatio).HasColumnType("money");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalesToLeadPowerRatio).HasColumnType("money");

                entity.Property(e => e.TotalLeads).HasColumnType("money");

                entity.Property(e => e.TotalMargin).HasColumnType("money");

                entity.Property(e => e.ValuePerLead).HasColumnType("money");
            });

            modelBuilder.Entity<ValuesForWidgetsHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ValuesForWidgetsHistory");

                entity.Property(e => e.AverageTicker).HasColumnType("money");

                entity.Property(e => e.ClosingRatio).HasColumnType("money");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdValuesWidgets)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idValuesWidgets");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.SalesToLeadPowerRatio).HasColumnType("money");

                entity.Property(e => e.TotalLeads).HasColumnType("money");

                entity.Property(e => e.TotalMargin).HasColumnType("money");

                entity.Property(e => e.ValuePerLead).HasColumnType("money");
            });

            modelBuilder.Entity<ValuesForWidgetsHistoryFinance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ValuesForWidgetsHistoryFinance");

                entity.Property(e => e.AccountPayable).HasColumnType("money");

                entity.Property(e => e.AccountReceivable).HasColumnType("money");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdValuesWidgets)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idValuesWidgets");

                entity.Property(e => e.Numero).HasColumnName("numero");
            });

            modelBuilder.Entity<VariableMaintenance>(entity =>
            {
                entity.HasKey(e => e.Idvariablemaintenance);

                entity.ToTable("variableMaintenance");

                entity.Property(e => e.Idvariablemaintenance).HasColumnName("idvariablemaintenance");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdMenuItems).HasColumnName("idMenuItems");

                entity.Property(e => e.Idtype).HasColumnName("idtype");

                entity.Property(e => e.Valor)
                    .HasColumnType("money")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<VirtualFd>(entity =>
            {
                entity.HasKey(e => e.Fdid);

                entity.ToTable("VirtualFDs");

                entity.Property(e => e.Fdid).HasColumnName("FDID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Granter)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("granter");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.HasOne(d => d.GranterNavigation)
                    .WithMany(p => p.VirtualFdGranterNavigations)
                    .HasForeignKey(d => d.Granter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VirtualFDs_Granter");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.VirtualFdUserNameNavigations)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VirtualFDs_UserOpenId");
            });

            modelBuilder.Entity<VirtualFds2016>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VirtualFDs2016");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Fdid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FDID");

                entity.Property(e => e.Granter)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("granter");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
