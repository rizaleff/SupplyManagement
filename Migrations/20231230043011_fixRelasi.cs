using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fixRelasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_companies_tb_m_vendors_guid",
                table: "tb_m_companies");

            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("1c11e24f-ce2d-4175-a5d9-005097f08d0f"));

            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("2da7058c-8e3f-478e-b619-c8ee5f49de5f"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("70b6c06d-d671-43c3-a412-d672b55e6e36"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("5eec4a8f-4d50-4636-a62e-d89a0616313f"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("bd6faa26-42a4-4a5b-a331-780115599296"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("7aa6a63d-11b3-44d8-ba58-76934773958a"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("bbae1463-395e-41fb-bcb6-720ff4192a72"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_vendors_tb_m_companies_guid",
                table: "tb_m_vendors",
                column: "guid",
                principalTable: "tb_m_companies",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_vendors_tb_m_companies_guid",
                table: "tb_m_vendors");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_companies_tb_m_vendors_guid",
                table: "tb_m_companies",
                column: "guid",
                principalTable: "tb_m_vendors",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
