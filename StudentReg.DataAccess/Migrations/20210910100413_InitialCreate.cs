using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentReg.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "FullName", "Grade" },
                values: new object[] { 1, 21, "D.G.Lakshan", "Year 01" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "FullName", "Grade" },
                values: new object[] { 2, 20, "D.G.Madhubashika", "Year 01" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "FullName", "Grade" },
                values: new object[] { 3, 22, "Shan menaka", "Year 02" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "AddressNo", "City", "Street", "StudentId" },
                values: new object[,]
                {
                    { 1, "No.68", "Wellawaya", "Newcity", 1 },
                    { 2, "No.214", "Beliatte", "Sitinamaluwa", 1 },
                    { 3, "No.261", "Wellawaya", "Buduruwagala Road", 2 },
                    { 4, "No.06", "Weliyaya", "rathmalweheragama", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
