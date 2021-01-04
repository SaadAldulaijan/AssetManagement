using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class updatePrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    BadgeNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.BadgeNo);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                columns: table => new
                {
                    SerialNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.SerialNo);
                    table.ForeignKey(
                        name: "FK_Telephone_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extension",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usage = table.Column<int>(type: "int", nullable: false),
                    BadgeNo = table.Column<int>(type: "int", nullable: true),
                    EmployeeBadgeNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extension", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Extension_Employee_EmployeeBadgeNo",
                        column: x => x.EmployeeBadgeNo,
                        principalTable: "Employee",
                        principalColumn: "BadgeNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherAsset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BadgeNo = table.Column<int>(type: "int", nullable: true),
                    EmployeeBadgeNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherAsset_Employee_EmployeeBadgeNo",
                        column: x => x.EmployeeBadgeNo,
                        principalTable: "Employee",
                        principalColumn: "BadgeNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pager",
                columns: table => new
                {
                    SerialNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Capcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BadgeNo = table.Column<int>(type: "int", nullable: true),
                    EmployeeBadgeNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pager", x => x.SerialNo);
                    table.ForeignKey(
                        name: "FK_Pager_Employee_EmployeeBadgeNo",
                        column: x => x.EmployeeBadgeNo,
                        principalTable: "Employee",
                        principalColumn: "BadgeNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    SerialNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelephoneSerialNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExtensionNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => new { x.SerialNo, x.Number });
                    table.ForeignKey(
                        name: "FK_Asset_Extension_ExtensionNumber",
                        column: x => x.ExtensionNumber,
                        principalTable: "Extension",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Telephone_TelephoneSerialNo",
                        column: x => x.TelephoneSerialNo,
                        principalTable: "Telephone",
                        principalColumn: "SerialNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ExtensionNumber",
                table: "Asset",
                column: "ExtensionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_TelephoneSerialNo",
                table: "Asset",
                column: "TelephoneSerialNo");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Extension_EmployeeBadgeNo",
                table: "Extension",
                column: "EmployeeBadgeNo");

            migrationBuilder.CreateIndex(
                name: "IX_OtherAsset_EmployeeBadgeNo",
                table: "OtherAsset",
                column: "EmployeeBadgeNo");

            migrationBuilder.CreateIndex(
                name: "IX_Pager_EmployeeBadgeNo",
                table: "Pager",
                column: "EmployeeBadgeNo");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Telephone_SubCategoryId",
                table: "Telephone",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "OtherAsset");

            migrationBuilder.DropTable(
                name: "Pager");

            migrationBuilder.DropTable(
                name: "Extension");

            migrationBuilder.DropTable(
                name: "Telephone");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
