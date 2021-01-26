using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication5.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountEmailaddress> AccountEmailaddresses { get; set; }
        public virtual DbSet<AccountEmailconfirmation> AccountEmailconfirmations { get; set; }
        public virtual DbSet<AuthGroup> AuthGroups { get; set; }
        public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }
        public virtual DbSet<AuthPermission> AuthPermissions { get; set; }
        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }
        public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }
        public virtual DbSet<AuthtokenToken> AuthtokenTokens { get; set; }
        public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }
        public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }
        public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }
        public virtual DbSet<DjangoSession> DjangoSessions { get; set; }
        public virtual DbSet<DjangoSite> DjangoSites { get; set; }
        public virtual DbSet<MyapiCustomer> MyapiCustomers { get; set; }
        public virtual DbSet<MyapiCustomerGroup> MyapiCustomerGroups { get; set; }
        public virtual DbSet<MyapiCustomerUserPermission> MyapiCustomerUserPermissions { get; set; }
        public virtual DbSet<MyapiMenu> MyapiMenus { get; set; }
        public virtual DbSet<MyapiMenuProduct> MyapiMenuProducts { get; set; }
        public virtual DbSet<MyapiOrder> MyapiOrders { get; set; }
        public virtual DbSet<MyapiOrderOrderedProduct> MyapiOrderOrderedProducts { get; set; }
        public virtual DbSet<MyapiProduct> MyapiProducts { get; set; }
        public virtual DbSet<MyapiProductsinorder> MyapiProductsinorders { get; set; }
        public virtual DbSet<MyapiRestaurant> MyapiRestaurants { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlite("");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEmailaddress>(entity =>
            {
                entity.ToTable("account_emailaddress");

                entity.HasIndex(e => e.Email, "IX_account_emailaddress_email")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "account_emailaddress_user_id_2c513194");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(254)")
                    .HasColumnName("email");

                entity.Property(e => e.Primary)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("primary");

                entity.Property(e => e.UserId)
                    .HasColumnType("integer")
                    .HasColumnName("user_id");

                entity.Property(e => e.Verified)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("verified");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccountEmailaddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AccountEmailconfirmation>(entity =>
            {
                entity.ToTable("account_emailconfirmation");

                entity.HasIndex(e => e.Key, "IX_account_emailconfirmation_key")
                    .IsUnique();

                entity.HasIndex(e => e.EmailAddressId, "account_emailconfirmation_email_address_id_5b7f8c58");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.EmailAddressId)
                    .HasColumnType("integer")
                    .HasColumnName("email_address_id");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasColumnName("key");

                entity.Property(e => e.Sent)
                    .HasColumnType("datetime")
                    .HasColumnName("sent");

                entity.HasOne(d => d.EmailAddress)
                    .WithMany(p => p.AccountEmailconfirmations)
                    .HasForeignKey(d => d.EmailAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AuthGroup>(entity =>
            {
                entity.ToTable("auth_group");

                entity.HasIndex(e => e.Name, "IX_auth_group_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthGroupPermission>(entity =>
            {
                entity.ToTable("auth_group_permissions");

                entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

                entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("integer")
                    .HasColumnName("group_id");

                entity.Property(e => e.PermissionId)
                    .HasColumnType("integer")
                    .HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AuthPermission>(entity =>
            {
                entity.ToTable("auth_permission");

                entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

                entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Codename)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("codename");

                entity.Property(e => e.ContentTypeId)
                    .HasColumnType("integer")
                    .HasColumnName("content_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.AuthPermissions)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_user");

                entity.HasIndex(e => e.Username, "IX_auth_user_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.DateJoined)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("date_joined");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(254)")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("is_active");

                entity.Property(e => e.IsStaff)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("username");
            });

            modelBuilder.Entity<AuthUserGroup>(entity =>
            {
                entity.ToTable("auth_user_groups");

                entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544");

                entity.HasIndex(e => e.UserId, "auth_user_groups_user_id_6a12ed8b");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("integer")
                    .HasColumnName("group_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("integer")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AuthUserUserPermission>(entity =>
            {
                entity.ToTable("auth_user_user_permissions");

                entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_permission_id_1fbb5f2c");

                entity.HasIndex(e => e.UserId, "auth_user_user_permissions_user_id_a95ead1b");

                entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.PermissionId)
                    .HasColumnType("integer")
                    .HasColumnName("permission_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("integer")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AuthtokenToken>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("authtoken_token");

                entity.HasIndex(e => e.UserId, "IX_authtoken_token_user_id")
                    .IsUnique();

                entity.Property(e => e.Key)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("key");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.UserId)
                    .HasColumnType("integer")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AuthtokenToken)
                    .HasForeignKey<AuthtokenToken>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DjangoAdminLog>(entity =>
            {
                entity.ToTable("django_admin_log");

                entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

                entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.ActionFlag)
                    .HasColumnType("smallint unsigned")
                    .HasColumnName("action_flag");

                entity.Property(e => e.ActionTime)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("action_time");

                entity.Property(e => e.ChangeMessage)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("change_message");

                entity.Property(e => e.ContentTypeId)
                    .HasColumnType("integer")
                    .HasColumnName("content_type_id");

                entity.Property(e => e.ObjectId)
                    .HasColumnType("text")
                    .HasColumnName("object_id");

                entity.Property(e => e.ObjectRepr)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("object_repr");

                entity.Property(e => e.UserId)
                    .HasColumnType("integer")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.ContentTypeId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DjangoContentType>(entity =>
            {
                entity.ToTable("django_content_type");

                entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.AppLabel)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("app_label");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("model");
            });

            modelBuilder.Entity<DjangoMigration>(entity =>
            {
                entity.ToTable("django_migrations");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.App)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("app");

                entity.Property(e => e.Applied)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("applied");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DjangoSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey);

                entity.ToTable("django_session");

                entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

                entity.Property(e => e.SessionKey)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("session_key");

                entity.Property(e => e.ExpireDate)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("expire_date");

                entity.Property(e => e.SessionData)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("session_data");
            });

            modelBuilder.Entity<DjangoSite>(entity =>
            {
                entity.ToTable("django_site");

                entity.HasIndex(e => e.Domain, "IX_django_site_domain")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("domain");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MyapiCustomer>(entity =>
            {
                entity.ToTable("myapi_customer");

                entity.HasIndex(e => e.Email, "IX_myapi_customer_email")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.DateJoined)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("date_joined");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(254)")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("is_active");

                entity.Property(e => e.IsStaff)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser)
                    .IsRequired()
                    .HasColumnType("bool")
                    .HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasColumnName("password");

                entity.Property(e => e.Surname)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<MyapiCustomerGroup>(entity =>
            {
                entity.ToTable("myapi_customer_groups");

                entity.HasIndex(e => e.CustomerId, "myapi_customer_groups_customer_id_3dc5a130");

                entity.HasIndex(e => new { e.CustomerId, e.GroupId }, "myapi_customer_groups_customer_id_group_id_e86fdd48_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.GroupId, "myapi_customer_groups_group_id_32060ea0");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("integer")
                    .HasColumnName("customer_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("integer")
                    .HasColumnName("group_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MyapiCustomerGroups)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MyapiCustomerGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiCustomerUserPermission>(entity =>
            {
                entity.ToTable("myapi_customer_user_permissions");

                entity.HasIndex(e => e.CustomerId, "myapi_customer_user_permissions_customer_id_a432a236");

                entity.HasIndex(e => new { e.CustomerId, e.PermissionId }, "myapi_customer_user_permissions_customer_id_permission_id_84f4ef75_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionId, "myapi_customer_user_permissions_permission_id_c232764c");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("integer")
                    .HasColumnName("customer_id");

                entity.Property(e => e.PermissionId)
                    .HasColumnType("integer")
                    .HasColumnName("permission_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MyapiCustomerUserPermissions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.MyapiCustomerUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiMenu>(entity =>
            {
                entity.HasKey(e => e.RestaurantId);

                entity.ToTable("myapi_menu");

                entity.Property(e => e.RestaurantId)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("restaurant_id");

                entity.HasOne(d => d.Restaurant)
                    .WithOne(p => p.MyapiMenu)
                    .HasForeignKey<MyapiMenu>(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiMenuProduct>(entity =>
            {
                entity.ToTable("myapi_menu_products");

                entity.HasIndex(e => e.MenuId, "myapi_menu_products_menu_id_c3137229");

                entity.HasIndex(e => new { e.MenuId, e.ProductId }, "myapi_menu_products_menu_id_product_id_ed15ea1e_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId, "myapi_menu_products_product_id_20e5825a");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.MenuId)
                    .HasColumnType("integer")
                    .HasColumnName("menu_id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("integer")
                    .HasColumnName("product_id");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MyapiMenuProducts)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MyapiMenuProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiOrder>(entity =>
            {
                entity.ToTable("myapi_order");

                entity.HasIndex(e => e.CustomerId, "myapi_order_customer_id_60b6f946");

                entity.HasIndex(e => e.RestaurantId, "myapi_order_restaurant_id_a36a0c36");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("integer")
                    .HasColumnName("customer_id");

                entity.Property(e => e.IssueDate)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("issueDate");

                entity.Property(e => e.IssueTime)
                    .IsRequired()
                    .HasColumnType("time")
                    .HasColumnName("issueTime");

                entity.Property(e => e.PlannedDate)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("plannedDate");

                entity.Property(e => e.PlannedTime)
                    .IsRequired()
                    .HasColumnType("time")
                    .HasColumnName("plannedTime");

                entity.Property(e => e.RestaurantId)
                    .HasColumnType("integer")
                    .HasColumnName("restaurant_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MyapiOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.MyapiOrders)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiOrderOrderedProduct>(entity =>
            {
                entity.ToTable(" myapi_order_orderedProducts");

                entity.HasIndex(e => e.OrderId, " myapi_order_orderedProducts_order_id_d9ef4a5a");

                entity.HasIndex(e => e.ProductId, " myapi_order_orderedProducts_product_id_51217bdf");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.OrderId)
                    .HasColumnType("integer")
                    .HasColumnName("order_id");

                entity.Property(e => e.ProductCount)
                    .HasColumnType("integer")
                    .HasColumnName("productCount");

                entity.Property(e => e.ProductId)
                    .HasColumnType("integer")
                    .HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.MyapiOrderOrderedProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MyapiOrderOrderedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiProduct>(entity =>
            {
                entity.ToTable("myapi_product");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("category");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnType("varchar(250)")
                    .HasColumnName("details");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("name");

                entity.Property(e => e.PhotoUrl)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("photoUrl");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<MyapiProductsinorder>(entity =>
            {
                entity.ToTable("myapi_productsinorder");

                entity.HasIndex(e => e.OrderId, "myapi_productsinorder_order_id_210cc500");

                entity.HasIndex(e => e.ProductId, "myapi_productsinorder_product_id_a32e6c07");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.OrderId)
                    .HasColumnType("integer")
                    .HasColumnName("order_id");

                entity.Property(e => e.ProductCount)
                    .HasColumnType("integer")
                    .HasColumnName("productCount");

                entity.Property(e => e.ProductId)
                    .HasColumnType("integer")
                    .HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.MyapiProductsinorders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MyapiProductsinorders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MyapiRestaurant>(entity =>
            {
                entity.ToTable("myapi_restaurant");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(250)")
                    .HasColumnName("address");

                entity.Property(e => e.LogoUrl)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("logoUrl");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
