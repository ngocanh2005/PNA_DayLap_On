using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNA_DayLap_On.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pna_LoaiSanPham",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiSanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLoaiSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pna_LoaiSanPham", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dongia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    LoaiSanPhamID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SanPham_pna_LoaiSanPham_LoaiSanPhamID",
                        column: x => x.LoaiSanPhamID,
                        principalTable: "pna_LoaiSanPham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamID",
                table: "SanPham",
                column: "LoaiSanPhamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "pna_LoaiSanPham");
        }
    }
}
