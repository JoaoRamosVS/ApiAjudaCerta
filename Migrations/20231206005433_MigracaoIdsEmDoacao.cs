using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoIdsEmDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Pessoa_PessoaId",
                table: "Doacao");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Doacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 156, 125, 204, 229, 163, 136, 185, 194, 202, 123, 171, 153, 39, 135, 193, 61, 124, 185, 100, 32, 108, 209, 208, 49, 136, 130, 11, 21, 247, 94, 177, 208, 80, 90, 76, 181, 167, 101, 34, 215, 139, 178, 186, 190, 255, 25, 159, 170, 241, 64, 115, 52, 239, 118, 101, 160, 231, 37, 75, 3, 23, 250, 39, 113 }, new byte[] { 236, 187, 107, 31, 201, 17, 172, 15, 137, 66, 3, 9, 232, 51, 180, 250, 88, 35, 180, 202, 120, 14, 183, 246, 50, 151, 164, 182, 183, 19, 146, 66, 215, 114, 110, 54, 154, 133, 253, 53, 169, 129, 34, 131, 162, 96, 133, 16, 130, 255, 63, 206, 63, 183, 235, 55, 188, 41, 222, 181, 151, 132, 20, 31, 89, 110, 233, 218, 9, 138, 53, 182, 243, 155, 138, 202, 98, 172, 34, 137, 228, 160, 11, 240, 196, 89, 247, 170, 62, 215, 203, 15, 184, 217, 196, 158, 247, 215, 100, 49, 34, 82, 202, 12, 67, 190, 167, 171, 242, 234, 96, 164, 134, 33, 211, 17, 95, 240, 99, 83, 58, 93, 27, 90, 38, 138, 150, 93 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Pessoa_PessoaId",
                table: "Doacao",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Pessoa_PessoaId",
                table: "Doacao");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Doacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 121, 151, 187, 224, 15, 120, 1, 9, 138, 254, 220, 196, 179, 66, 3, 113, 204, 125, 135, 145, 193, 233, 143, 146, 57, 34, 217, 242, 201, 149, 138, 51, 94, 107, 69, 148, 36, 235, 52, 159, 120, 177, 58, 223, 58, 133, 109, 213, 130, 53, 190, 21, 122, 54, 125, 185, 229, 159, 190, 73, 34, 216, 98, 68 }, new byte[] { 236, 89, 87, 158, 109, 199, 12, 182, 180, 127, 209, 226, 203, 215, 84, 31, 166, 49, 170, 191, 177, 105, 175, 5, 221, 165, 78, 162, 121, 170, 58, 243, 104, 112, 209, 156, 199, 146, 199, 34, 214, 66, 107, 147, 71, 27, 176, 71, 112, 124, 255, 131, 43, 118, 91, 27, 94, 106, 162, 144, 189, 191, 219, 16, 113, 247, 100, 67, 132, 129, 182, 235, 245, 178, 188, 231, 110, 251, 160, 100, 53, 140, 127, 225, 207, 107, 28, 99, 221, 80, 181, 189, 83, 123, 157, 190, 107, 207, 9, 86, 192, 113, 103, 58, 100, 177, 196, 37, 163, 255, 242, 177, 78, 118, 40, 100, 155, 88, 93, 212, 82, 188, 71, 172, 113, 199, 62, 67 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Pessoa_PessoaId",
                table: "Doacao",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }
    }
}
