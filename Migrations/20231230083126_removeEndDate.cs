using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class removeEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "end_date",
                table: "tb_project_tenders");

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("018a38ea-2797-4a58-833d-e2fc9f7c39ac"), null, null, "Admin" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("b2c86b5e-965d-4715-bd72-48a39fa41cc8"), null, null, "VendorCompany" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("bd373ba1-d60b-461b-992f-4b5e2b3366a9"), null, null, "Manager" });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("2304121e-7664-4d08-9dc2-728f627d60a4"), null, null, "$2a$12$UkZaBzj9DQWfhLZXxcMXjurlNhUgd1coZ8gRZzfeBpW0jQZCQN8xS", new Guid("018a38ea-2797-4a58-833d-e2fc9f7c39ac") });

            migrationBuilder.InsertData(
                table: "tb_m_accounts",
                columns: new[] { "guid", "created_date", "modified_date", "password", "role_guid" },
                values: new object[] { new Guid("c203b5ac-fc4c-4472-bf37-d1d68a71390b"), null, null, "$2a$12$7q3naxSlzBUBJ5iFWL45HeXehhZdBEE0tp.b5DY.4HdS2gUtFsQy2", new Guid("bd373ba1-d60b-461b-992f-4b5e2b3366a9") });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("506cbf10-7388-4c4c-abc6-012a11417d8c"), new Guid("c203b5ac-fc4c-4472-bf37-d1d68a71390b"), null, "chris@gmail.com", "Chris", 0, "Martin", null, "119120" });

            migrationBuilder.InsertData(
                table: "tb_m_employees",
                columns: new[] { "guid", "account_guid", "created_date", "email", "first_name", "gender", "last_name", "modified_date", "nik" },
                values: new object[] { new Guid("f0ec7bcb-eeea-46dc-b9e3-31d6fe508f9b"), new Guid("2304121e-7664-4d08-9dc2-728f627d60a4"), null, "jennie@gmail.com", "Jennie", 1, "Jane", null, "119119" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("506cbf10-7388-4c4c-abc6-012a11417d8c"));

            migrationBuilder.DeleteData(
                table: "tb_m_employees",
                keyColumn: "guid",
                keyValue: new Guid("f0ec7bcb-eeea-46dc-b9e3-31d6fe508f9b"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("b2c86b5e-965d-4715-bd72-48a39fa41cc8"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("2304121e-7664-4d08-9dc2-728f627d60a4"));

            migrationBuilder.DeleteData(
                table: "tb_m_accounts",
                keyColumn: "guid",
                keyValue: new Guid("c203b5ac-fc4c-4472-bf37-d1d68a71390b"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("018a38ea-2797-4a58-833d-e2fc9f7c39ac"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("bd373ba1-d60b-461b-992f-4b5e2b3366a9"));

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "tb_project_tenders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
