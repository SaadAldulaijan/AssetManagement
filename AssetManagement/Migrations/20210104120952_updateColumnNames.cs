using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class updateColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Extension_ExtensionNumber",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Telephone_TelephoneSerialNo",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_TelephoneSerialNo",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "BadgeNo",
                table: "Pager");

            migrationBuilder.DropColumn(
                name: "BadgeNo",
                table: "Extension");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Asset");

            migrationBuilder.AlterColumn<string>(
                name: "TelephoneSerialNo",
                table: "Asset",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtensionNumber",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                columns: new[] { "TelephoneSerialNo", "ExtensionNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Extension_ExtensionNumber",
                table: "Asset",
                column: "ExtensionNumber",
                principalTable: "Extension",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Telephone_TelephoneSerialNo",
                table: "Asset",
                column: "TelephoneSerialNo",
                principalTable: "Telephone",
                principalColumn: "SerialNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Extension_ExtensionNumber",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Telephone_TelephoneSerialNo",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "BadgeNo",
                table: "Pager",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BadgeNo",
                table: "Extension",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExtensionNumber",
                table: "Asset",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TelephoneSerialNo",
                table: "Asset",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SerialNo",
                table: "Asset",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                columns: new[] { "SerialNo", "Number" });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_TelephoneSerialNo",
                table: "Asset",
                column: "TelephoneSerialNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Extension_ExtensionNumber",
                table: "Asset",
                column: "ExtensionNumber",
                principalTable: "Extension",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Telephone_TelephoneSerialNo",
                table: "Asset",
                column: "TelephoneSerialNo",
                principalTable: "Telephone",
                principalColumn: "SerialNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
