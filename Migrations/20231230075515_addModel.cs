using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("8bd7d069-d991-4529-b232-d56f557d85d0"));

            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("f60f1a60-990c-4131-ae92-b95c31331bdb"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("6c9842d1-0f7b-4c9f-af79-b47b278836fc"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("00e41f63-019e-4965-bd9f-169d8d9f2515"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("570cd95e-4bc8-404e-a3f0-c1f84a0f3a44"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("39d880f7-076c-4ccd-bbd1-7d795278594f"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("6c4ace98-b04e-4ec3-b25b-28c39c7364d1"));

            migrationBuilder.CreateTable(
                name: "tb_project_tenders",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    title = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                values: new object[] { new Guid("065d6138-bed5-458c-939a-63ac58e84b51"), null, null, "Manager" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("c29fa0aa-57aa-4e4c-9c35-9b4440d345e1"), null, null, "Admin" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("d3386b72-9975-470a-8a65-d00276ec7490"), null, null, "VendorCompany" });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("56290299-48c7-4647-8902-d0c22eb34742"), null, null, "$2a$12$cOntMHnVkwLKQNIDePfK1OqGZ4KuoAcuUQ/8129VXNUcPFhOtgc4W", new Guid("065d6138-bed5-458c-939a-63ac58e84b51") });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("a3048ba3-e83d-42bd-8db0-f25d30631536"), null, null, "$2a$12$2gEciosg0I4acedhc1s0Eup5Qy6b.9VocD65YUzj7ZoWDWlVPufLW", new Guid("c29fa0aa-57aa-4e4c-9c35-9b4440d345e1") });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("3890c5dc-9c32-475c-9f6f-e6df56209b13"), new Guid("56290299-48c7-4647-8902-d0c22eb34742"), null, "chris@gmail.com", "Chris", 0, "Martin", null, "119120" });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("81a6683f-79c5-4438-b3bb-1021ff913f5b"), new Guid("a3048ba3-e83d-42bd-8db0-f25d30631536"), null, "jennie@gmail.com", "Jennie", 1, "Jane", null, "119119" });

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
                name: "tb_vendor_offers");

            migrationBuilder.DropTable(
                name: "tb_project_tenders");

            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("3890c5dc-9c32-475c-9f6f-e6df56209b13"));

            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("81a6683f-79c5-4438-b3bb-1021ff913f5b"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("d3386b72-9975-470a-8a65-d00276ec7490"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("56290299-48c7-4647-8902-d0c22eb34742"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("a3048ba3-e83d-42bd-8db0-f25d30631536"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("065d6138-bed5-458c-939a-63ac58e84b51"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c29fa0aa-57aa-4e4c-9c35-9b4440d345e1"));

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("39d880f7-076c-4ccd-bbd1-7d795278594f"), null, null, "Manager" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("6c4ace98-b04e-4ec3-b25b-28c39c7364d1"), null, null, "Admin" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("6c9842d1-0f7b-4c9f-af79-b47b278836fc"), null, null, "VendorCompany" });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("00e41f63-019e-4965-bd9f-169d8d9f2515"), null, null, "$2a$12$DrEfZrw4CsGvsTu.fuHgq.zS9EVMf6WHSglszkVBILHu61VmbyXym", new Guid("39d880f7-076c-4ccd-bbd1-7d795278594f") });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("570cd95e-4bc8-404e-a3f0-c1f84a0f3a44"), null, null, "$2a$12$2SDVGI76H1dUd1.daZwi9OkOkkdsQLR1zvlOVX7nR6AY7mw06bc5C", new Guid("6c4ace98-b04e-4ec3-b25b-28c39c7364d1") });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("8bd7d069-d991-4529-b232-d56f557d85d0"), new Guid("00e41f63-019e-4965-bd9f-169d8d9f2515"), null, "chris@gmail.com", "Chris", 0, "Martin", null, "119120" });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("f60f1a60-990c-4131-ae92-b95c31331bdb"), new Guid("570cd95e-4bc8-404e-a3f0-c1f84a0f3a44"), null, "jennie@gmail.com", "Jennie", 1, "Jane", null, "119119" });
        }
    }
}
