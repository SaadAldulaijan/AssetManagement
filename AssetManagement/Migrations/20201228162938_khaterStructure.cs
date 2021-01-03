using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class khaterStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Employee_EmployeeId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherAsset_Employee_EmployeeId",
                table: "OtherAsset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_EmployeeId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_TelephoneId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Telephone");

            migrationBuilder.DropColumn(
                name: "IsDefective",
                table: "Telephone");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Pager");

            migrationBuilder.DropColumn(
                name: "IsDefective",
                table: "Pager");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Telephone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Pager",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "OtherAsset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OtherAsset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Usage",
                table: "Extension",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Extension",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                columns: new[] { "TelephoneId", "ExtensionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Extension_EmployeeId",
                table: "Extension",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Extension_Employee_EmployeeId",
                table: "Extension",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherAsset_Employee_EmployeeId",
                table: "OtherAsset",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extension_Employee_EmployeeId",
                table: "Extension");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherAsset_Employee_EmployeeId",
                table: "OtherAsset");

            migrationBuilder.DropIndex(
                name: "IX_Extension_EmployeeId",
                table: "Extension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Telephone");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OtherAsset");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Extension");

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Telephone",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefective",
                table: "Telephone",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Pager",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Pager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefective",
                table: "Pager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "OtherAsset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Usage",
                table: "Extension",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_EmployeeId",
                table: "Asset",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_TelephoneId",
                table: "Asset",
                column: "TelephoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Employee_EmployeeId",
                table: "Asset",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherAsset_Employee_EmployeeId",
                table: "OtherAsset",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
