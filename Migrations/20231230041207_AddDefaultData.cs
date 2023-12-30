using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddDefaultData : Migration
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    password = table.Column<string>(type: "LONGTEXT", nullable: false)
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
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_tb_m_companies_tb_m_vendors_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_vendors",
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
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("70b6c06d-d671-43c3-a412-d672b55e6e36"), null, null, "VendorCompany" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("7aa6a63d-11b3-44d8-ba58-76934773958a"), null, null, "Manager" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("bbae1463-395e-41fb-bcb6-720ff4192a72"), null, null, "Admin" });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("5eec4a8f-4d50-4636-a62e-d89a0616313f"), null, null, "$2a$12$lIunYR/bj0nP/VNwELpWveQNQqFIHCLN3Aan4fn47J19UlKu721ky", new Guid("7aa6a63d-11b3-44d8-ba58-76934773958a") });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("bd6faa26-42a4-4a5b-a331-780115599296"), null, null, "$2a$12$OBhEFaX69Dneu5BbmEuOhuoxb.nnaAaiX5Yl3QFdFM67gTkliDUQC", new Guid("bbae1463-395e-41fb-bcb6-720ff4192a72") });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("1c11e24f-ce2d-4175-a5d9-005097f08d0f"), new Guid("bd6faa26-42a4-4a5b-a331-780115599296"), null, "jennie@gmail.com", "Jennie", 1, "Jane", null, "119119" });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("2da7058c-8e3f-478e-b619-c8ee5f49de5f"), new Guid("5eec4a8f-4d50-4636-a62e-d89a0616313f"), null, "chris@gmail.com", "Chris", 0, "Martin", null, "119120" });

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
                name: "IX_tb_m_companies_email",
                table: "tb_m_companies",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_account_guid",
                table: "tb_m_employees",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_email",
                table: "tb_m_employees",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_companies");

            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_m_vendors");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");
        }
    }
}
