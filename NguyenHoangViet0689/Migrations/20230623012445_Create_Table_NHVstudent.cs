using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenHoangViet0689.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_NHVstudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NHVstudent",
                columns: table => new
                {
                    NHVMaSV = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NHVTenSV = table.Column<string>(type: "TEXT", nullable: false),
                    NHVsdt = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHVstudent", x => x.NHVMaSV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NHVstudent");
        }
    }
}
