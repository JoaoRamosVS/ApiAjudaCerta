using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class AjudaCertaApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "@ong_estreladalva");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 85, 219, 140, 53, 102, 244, 89, 149, 134, 59, 119, 55, 100, 218, 29, 0, 38, 15, 89, 231, 18, 86, 69, 59, 38, 124, 61, 222, 253, 134, 44, 210, 46, 137, 183, 134, 108, 5, 44, 211, 94, 144, 62, 254, 116, 239, 63, 59, 1, 129, 76, 37, 107, 201, 139, 118, 128, 139, 251, 111, 242, 123, 53, 1 }, new byte[] { 176, 110, 23, 179, 89, 112, 129, 83, 93, 105, 220, 102, 1, 131, 146, 38, 36, 196, 47, 14, 233, 167, 114, 13, 159, 101, 147, 247, 195, 152, 54, 251, 211, 228, 3, 188, 174, 156, 55, 198, 1, 142, 56, 218, 81, 187, 174, 46, 116, 79, 252, 18, 130, 193, 42, 122, 153, 198, 203, 221, 10, 137, 125, 83, 254, 235, 184, 108, 248, 62, 148, 90, 105, 239, 126, 102, 82, 61, 241, 217, 238, 92, 106, 140, 124, 255, 104, 220, 76, 79, 203, 241, 222, 249, 184, 49, 8, 245, 175, 191, 213, 195, 62, 235, 216, 29, 110, 184, 44, 104, 126, 151, 64, 67, 120, 131, 191, 250, 195, 57, 243, 201, 127, 232, 43, 24, 197, 18 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 40, 90, 46, 152, 31, 78, 87, 248, 187, 54, 196, 5, 40, 48, 211, 82, 217, 34, 47, 153, 16, 48, 102, 77, 54, 185, 213, 191, 46, 162, 112, 214, 162, 238, 77, 44, 95, 3, 250, 9, 74, 229, 152, 18, 226, 218, 188, 152, 0, 91, 203, 69, 73, 27, 55, 137, 243, 76, 46, 89, 253, 166, 104, 247 }, new byte[] { 210, 77, 96, 170, 203, 188, 33, 85, 197, 151, 67, 2, 200, 125, 150, 56, 81, 11, 171, 98, 220, 106, 95, 82, 33, 25, 252, 60, 7, 27, 230, 89, 182, 219, 247, 221, 40, 233, 15, 28, 172, 233, 177, 172, 253, 62, 183, 80, 82, 160, 82, 10, 137, 56, 65, 205, 26, 120, 77, 160, 115, 53, 108, 84, 17, 120, 187, 220, 37, 54, 39, 14, 27, 23, 0, 110, 237, 92, 173, 251, 124, 200, 129, 79, 130, 2, 236, 162, 228, 38, 50, 52, 226, 226, 253, 151, 77, 238, 53, 10, 232, 240, 23, 187, 159, 92, 208, 12, 36, 228, 52, 177, 53, 82, 89, 136, 114, 211, 21, 230, 36, 66, 54, 35, 236, 171, 53, 255 } });
        }
    }
}
