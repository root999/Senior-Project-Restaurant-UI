using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auth_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auth_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    password = table.Column<string>(type: "varchar(128)", nullable: false),
                    last_login = table.Column<byte[]>(type: "datetime", nullable: true),
                    is_superuser = table.Column<byte[]>(type: "bool", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(30)", nullable: false),
                    email = table.Column<string>(type: "varchar(254)", nullable: false),
                    is_staff = table.Column<byte[]>(type: "bool", nullable: false),
                    is_active = table.Column<byte[]>(type: "bool", nullable: false),
                    date_joined = table.Column<byte[]>(type: "datetime", nullable: false),
                    last_name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "django_content_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    app_label = table.Column<string>(type: "varchar(100)", nullable: false),
                    model = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_django_content_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "django_migrations",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    app = table.Column<string>(type: "varchar(255)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    applied = table.Column<byte[]>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_django_migrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "django_session",
                columns: table => new
                {
                    session_key = table.Column<string>(type: "varchar(40)", nullable: false),
                    session_data = table.Column<string>(type: "text", nullable: false),
                    expire_date = table.Column<byte[]>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_django_session", x => x.session_key);
                });

            migrationBuilder.CreateTable(
                name: "django_site",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    domain = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_django_site", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "myapi_customer",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    date_joined = table.Column<byte[]>(type: "datetime", nullable: false),
                    email = table.Column<string>(type: "varchar(254)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(30)", nullable: false),
                    is_active = table.Column<byte[]>(type: "bool", nullable: false),
                    is_staff = table.Column<byte[]>(type: "bool", nullable: false),
                    is_superuser = table.Column<byte[]>(type: "bool", nullable: false),
                    last_login = table.Column<byte[]>(type: "datetime", nullable: true),
                    last_name = table.Column<string>(type: "varchar(150)", nullable: false),
                    password = table.Column<string>(type: "varchar(128)", nullable: false),
                    surname = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "myapi_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    price = table.Column<double>(type: "decimal", nullable: false),
                    photoUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    category = table.Column<string>(type: "varchar(50)", nullable: false),
                    details = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "myapi_restaurant",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    address = table.Column<string>(type: "varchar(250)", nullable: false),
                    logoUrl = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_restaurant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auth_user_groups",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<long>(type: "integer", nullable: false),
                    group_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_user_groups_auth_group_group_id",
                        column: x => x.group_id,
                        principalTable: "auth_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_auth_user_groups_auth_user_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auth_permission",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content_type_id = table.Column<long>(type: "integer", nullable: false),
                    codename = table.Column<string>(type: "varchar(100)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_permission_django_content_type_content_type_id",
                        column: x => x.content_type_id,
                        principalTable: "django_content_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "django_admin_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    action_time = table.Column<byte[]>(type: "datetime", nullable: false),
                    object_id = table.Column<string>(type: "text", nullable: true),
                    object_repr = table.Column<string>(type: "varchar(200)", nullable: false),
                    change_message = table.Column<string>(type: "text", nullable: false),
                    content_type_id = table.Column<long>(type: "integer", nullable: true),
                    user_id = table.Column<long>(type: "integer", nullable: false),
                    action_flag = table.Column<long>(type: "smallint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_django_admin_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_django_admin_log_auth_user_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_django_admin_log_django_content_type_content_type_id",
                        column: x => x.content_type_id,
                        principalTable: "django_content_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account_emailaddress",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    verified = table.Column<byte[]>(type: "bool", nullable: false),
                    primary = table.Column<byte[]>(type: "bool", nullable: false),
                    user_id = table.Column<long>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "varchar(254)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_emailaddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_emailaddress_myapi_customer_user_id",
                        column: x => x.user_id,
                        principalTable: "myapi_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "authtoken_token",
                columns: table => new
                {
                    key = table.Column<string>(type: "varchar(40)", nullable: false),
                    created = table.Column<byte[]>(type: "datetime", nullable: false),
                    user_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authtoken_token", x => x.key);
                    table.ForeignKey(
                        name: "FK_authtoken_token_myapi_customer_user_id",
                        column: x => x.user_id,
                        principalTable: "myapi_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "myapi_customer_groups",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    customer_id = table.Column<long>(type: "integer", nullable: false),
                    group_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_customer_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_myapi_customer_groups_auth_group_group_id",
                        column: x => x.group_id,
                        principalTable: "auth_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_myapi_customer_groups_myapi_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "myapi_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "myapi_menu",
                columns: table => new
                {
                    restaurant_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_menu", x => x.restaurant_id);
                    table.ForeignKey(
                        name: "FK_myapi_menu_myapi_restaurant_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "myapi_restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "myapi_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    issueTime = table.Column<DateTime>(type: "time", nullable: false),
                    customer_id = table.Column<long>(type: "integer", nullable: false),
                    restaurant_id = table.Column<long>(type: "integer", nullable: false),
                    issueDate = table.Column<DateTime>(type: "date", nullable: false),
                    plannedTime = table.Column<DateTime>(type: "time", nullable: false),
                    plannedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_myapi_order_myapi_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "myapi_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_myapi_order_myapi_restaurant_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "myapi_restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auth_group_permissions",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    group_id = table.Column<long>(type: "integer", nullable: false),
                    permission_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_group_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_group_permissions_auth_group_group_id",
                        column: x => x.group_id,
                        principalTable: "auth_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_auth_group_permissions_auth_permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "auth_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auth_user_user_permissions",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<long>(type: "integer", nullable: false),
                    permission_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user_user_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_user_user_permissions_auth_permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "auth_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_auth_user_user_permissions_auth_user_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "myapi_customer_user_permissions",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    customer_id = table.Column<long>(type: "integer", nullable: false),
                    permission_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_customer_user_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_myapi_customer_user_permissions_auth_permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "auth_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_myapi_customer_user_permissions_myapi_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "myapi_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account_emailconfirmation",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    created = table.Column<byte[]>(type: "datetime", nullable: false),
                    sent = table.Column<byte[]>(type: "datetime", nullable: true),
                    key = table.Column<string>(type: "varchar(64)", nullable: false),
                    email_address_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_emailconfirmation", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_emailconfirmation_account_emailaddress_email_address_id",
                        column: x => x.email_address_id,
                        principalTable: "account_emailaddress",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "myapi_menu_products",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    menu_id = table.Column<long>(type: "integer", nullable: false),
                    product_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_menu_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_myapi_menu_products_myapi_menu_menu_id",
                        column: x => x.menu_id,
                        principalTable: "myapi_menu",
                        principalColumn: "restaurant_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_myapi_menu_products_myapi_product_product_id",
                        column: x => x.product_id,
                        principalTable: "myapi_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: " myapi_order_orderedProducts",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productCount = table.Column<long>(type: "integer", nullable: false),
                    order_id = table.Column<long>(type: "integer", nullable: false),
                    product_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ myapi_order_orderedProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_ myapi_order_orderedProducts_myapi_order_order_id",
                        column: x => x.order_id,
                        principalTable: "myapi_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ myapi_order_orderedProducts_myapi_product_product_id",
                        column: x => x.product_id,
                        principalTable: "myapi_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "myapi_productsinorder",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productCount = table.Column<long>(type: "integer", nullable: false),
                    order_id = table.Column<long>(type: "integer", nullable: false),
                    product_id = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapi_productsinorder", x => x.id);
                    table.ForeignKey(
                        name: "FK_myapi_productsinorder_myapi_order_order_id",
                        column: x => x.order_id,
                        principalTable: "myapi_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_myapi_productsinorder_myapi_product_product_id",
                        column: x => x.product_id,
                        principalTable: "myapi_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: " myapi_order_orderedProducts_order_id_d9ef4a5a",
                table: " myapi_order_orderedProducts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: " myapi_order_orderedProducts_product_id_51217bdf",
                table: " myapi_order_orderedProducts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "account_emailaddress_user_id_2c513194",
                table: "account_emailaddress",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_account_emailaddress_email",
                table: "account_emailaddress",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "account_emailconfirmation_email_address_id_5b7f8c58",
                table: "account_emailconfirmation",
                column: "email_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_account_emailconfirmation_key",
                table: "account_emailconfirmation",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_auth_group_name",
                table: "auth_group",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "auth_group_permissions_group_id_b120cbf9",
                table: "auth_group_permissions",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "auth_group_permissions_group_id_permission_id_0cd325b0_uniq",
                table: "auth_group_permissions",
                columns: new[] { "group_id", "permission_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "auth_group_permissions_permission_id_84c5c92e",
                table: "auth_group_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "auth_permission_content_type_id_2f476e4b",
                table: "auth_permission",
                column: "content_type_id");

            migrationBuilder.CreateIndex(
                name: "auth_permission_content_type_id_codename_01ab375a_uniq",
                table: "auth_permission",
                columns: new[] { "content_type_id", "codename" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_auth_user_username",
                table: "auth_user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "auth_user_groups_group_id_97559544",
                table: "auth_user_groups",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "auth_user_groups_user_id_6a12ed8b",
                table: "auth_user_groups",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "auth_user_groups_user_id_group_id_94350c0c_uniq",
                table: "auth_user_groups",
                columns: new[] { "user_id", "group_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "auth_user_user_permissions_permission_id_1fbb5f2c",
                table: "auth_user_user_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "auth_user_user_permissions_user_id_a95ead1b",
                table: "auth_user_user_permissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq",
                table: "auth_user_user_permissions",
                columns: new[] { "user_id", "permission_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_authtoken_token_user_id",
                table: "authtoken_token",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "django_admin_log_content_type_id_c4bce8eb",
                table: "django_admin_log",
                column: "content_type_id");

            migrationBuilder.CreateIndex(
                name: "django_admin_log_user_id_c564eba6",
                table: "django_admin_log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "django_content_type_app_label_model_76bd3d3b_uniq",
                table: "django_content_type",
                columns: new[] { "app_label", "model" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "django_session_expire_date_a5c62663",
                table: "django_session",
                column: "expire_date");

            migrationBuilder.CreateIndex(
                name: "IX_django_site_domain",
                table: "django_site",
                column: "domain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_myapi_customer_email",
                table: "myapi_customer",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "myapi_customer_groups_customer_id_3dc5a130",
                table: "myapi_customer_groups",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "myapi_customer_groups_customer_id_group_id_e86fdd48_uniq",
                table: "myapi_customer_groups",
                columns: new[] { "customer_id", "group_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "myapi_customer_groups_group_id_32060ea0",
                table: "myapi_customer_groups",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "myapi_customer_user_permissions_customer_id_a432a236",
                table: "myapi_customer_user_permissions",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "myapi_customer_user_permissions_customer_id_permission_id_84f4ef75_uniq",
                table: "myapi_customer_user_permissions",
                columns: new[] { "customer_id", "permission_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "myapi_customer_user_permissions_permission_id_c232764c",
                table: "myapi_customer_user_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "myapi_menu_products_menu_id_c3137229",
                table: "myapi_menu_products",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "myapi_menu_products_menu_id_product_id_ed15ea1e_uniq",
                table: "myapi_menu_products",
                columns: new[] { "menu_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "myapi_menu_products_product_id_20e5825a",
                table: "myapi_menu_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "myapi_order_customer_id_60b6f946",
                table: "myapi_order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "myapi_order_restaurant_id_a36a0c36",
                table: "myapi_order",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "myapi_productsinorder_order_id_210cc500",
                table: "myapi_productsinorder",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "myapi_productsinorder_product_id_a32e6c07",
                table: "myapi_productsinorder",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " myapi_order_orderedProducts");

            migrationBuilder.DropTable(
                name: "account_emailconfirmation");

            migrationBuilder.DropTable(
                name: "auth_group_permissions");

            migrationBuilder.DropTable(
                name: "auth_user_groups");

            migrationBuilder.DropTable(
                name: "auth_user_user_permissions");

            migrationBuilder.DropTable(
                name: "authtoken_token");

            migrationBuilder.DropTable(
                name: "django_admin_log");

            migrationBuilder.DropTable(
                name: "django_migrations");

            migrationBuilder.DropTable(
                name: "django_session");

            migrationBuilder.DropTable(
                name: "django_site");

            migrationBuilder.DropTable(
                name: "myapi_customer_groups");

            migrationBuilder.DropTable(
                name: "myapi_customer_user_permissions");

            migrationBuilder.DropTable(
                name: "myapi_menu_products");

            migrationBuilder.DropTable(
                name: "myapi_productsinorder");

            migrationBuilder.DropTable(
                name: "account_emailaddress");

            migrationBuilder.DropTable(
                name: "auth_user");

            migrationBuilder.DropTable(
                name: "auth_group");

            migrationBuilder.DropTable(
                name: "auth_permission");

            migrationBuilder.DropTable(
                name: "myapi_menu");

            migrationBuilder.DropTable(
                name: "myapi_order");

            migrationBuilder.DropTable(
                name: "myapi_product");

            migrationBuilder.DropTable(
                name: "django_content_type");

            migrationBuilder.DropTable(
                name: "myapi_customer");

            migrationBuilder.DropTable(
                name: "myapi_restaurant");
        }
    }
}
