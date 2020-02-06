using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace featuretoggledemo.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Features",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Features",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("42164028-e54d-4f1c-9558-5a38bd1a5e00"), "FeatureA" },
                    { new Guid("b563353c-638c-4c25-a7e0-0ac85f1d8e6f"), "FeatureB" },
                    { new Guid("dc9e3353-9f60-4d32-a3fc-9a77203fb66c"), "FeatureC" },
                    { new Guid("9fa9658b-f8ab-4a54-9b22-f93b7f75a807"), "FeatureD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("42164028-e54d-4f1c-9558-5a38bd1a5e00"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("9fa9658b-f8ab-4a54-9b22-f93b7f75a807"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("b563353c-638c-4c25-a7e0-0ac85f1d8e6f"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("dc9e3353-9f60-4d32-a3fc-9a77203fb66c"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Features",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
