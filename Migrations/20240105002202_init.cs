using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.guid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_project_tenders",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    title = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_status = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_project_tenders", x => x.guid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    password = table.Column<string>(type: "LONGTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role_guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "tb_m_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_companies",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    company_logo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    approval_status = table.Column<int>(type: "int", nullable: false),
                    account_Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_companies", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_companies_tb_m_accounts_account_Guid",
                        column: x => x.account_Guid,
                        principalTable: "tb_m_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    first_name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nik = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    account_guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_employees_tb_m_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "tb_m_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_vendors",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    company_type = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    company_field = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    approval_status = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_vendors", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_vendors_tb_m_companies_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_companies",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_vendor_offers",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    project_tender_guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    vendor_guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    offer_price = table.Column<float>(type: "float", nullable: false),
                    offer_status = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendor_offers", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_vendor_offers_tb_m_vendors_vendor_guid",
                        column: x => x.vendor_guid,
                        principalTable: "tb_m_vendors",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_vendor_offers_tb_project_tenders_project_tender_guid",
                        column: x => x.project_tender_guid,
                        principalTable: "tb_project_tenders",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("1cab2e89-0939-4589-9ed6-73eff2af8f04"), null, null, "Manager" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("2637d8a8-b9bc-4970-b4ff-f3d1e6a7c84b"), null, null, "Admin" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("d5c2fb88-e6a2-43cf-bbc7-1e3bdef84a01"), null, null, "VendorCompany" });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "email", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("1bde2d53-bb57-40d2-bea3-69a8e5ccd4f2"), null, "chris@gmail.com", null, "$2a$12$xTyeXRObDTFWoo.I1ac4G.3On6aUY2pTe58fiEnuJWSQUNzWwUNke", new Guid("1cab2e89-0939-4589-9ed6-73eff2af8f04") });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "email", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("d85c5a55-6246-4197-9955-178e4bca3cca"), null, "jennie@gmail.com", null, "$2a$12$ok9ammrDiJPpUYRUoFGGjOgfhWfA35JAPar/6xDAgylm4wAnjNRiG", new Guid("2637d8a8-b9bc-4970-b4ff-f3d1e6a7c84b") });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("213bfd24-e51b-43c9-828a-67bc6eda17f3"), new Guid("1bde2d53-bb57-40d2-bea3-69a8e5ccd4f2"), null, "Chris", 0, "Martin", null, "119120" });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("ca86c66f-7e51-4e12-8979-2ad1b11d3e41"), new Guid("d85c5a55-6246-4197-9955-178e4bca3cca"), null, "Jennie", 1, "Jane", null, "119119" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_accounts_email",
                table: "tb_m_accounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_accounts_role_guid",
                table: "tb_m_accounts",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_companies_account_Guid",
                table: "tb_m_companies",
                column: "account_Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_companies_phone_number",
                table: "tb_m_companies",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_account_guid",
                table: "tb_m_employees",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendor_offers_project_tender_guid",
                table: "tb_vendor_offers",
                column: "project_tender_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendor_offers_vendor_guid",
                table: "tb_vendor_offers",
                column: "vendor_guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_vendor_offers");

            migrationBuilder.DropTable(
                name: "tb_m_vendors");

            migrationBuilder.DropTable(
                name: "tb_project_tenders");

            migrationBuilder.DropTable(
                name: "tb_m_companies");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");
        }
    }
}
