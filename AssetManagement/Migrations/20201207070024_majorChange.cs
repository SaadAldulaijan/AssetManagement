using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class majorChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelephoneEmployee");

            migrationBuilder.DropTable(
                name: "TelephoneExtension");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelephoneEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TelephoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneEmployee", x => new { x.EmployeeId, x.TelephoneId });
                    table.ForeignKey(
                        name: "FK_TelephoneEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelephoneEmployee_Telephone_TelephoneId",
                        column: x => x.TelephoneId,
                        principalTable: "Telephone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneExtension",
                columns: table => new
                {
                    TelephoneId = table.Column<int>(type: "int", nullable: false),
                    ExtensionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneExtension", x => new { x.TelephoneId, x.ExtensionId });
                    table.ForeignKey(
                        name: "FK_TelephoneExtension_Extension_ExtensionId",
                        column: x => x.ExtensionId,
                        principalTable: "Extension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelephoneExtension_Telephone_TelephoneId",
                        column: x => x.TelephoneId,
                        principalTable: "Telephone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneEmployee_TelephoneId",
                table: "TelephoneEmployee",
                column: "TelephoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneExtension_ExtensionId",
                table: "TelephoneExtension",
                column: "ExtensionId");
        }
    }
}
