using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoIdsAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Endereco_EnderecoId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pessoa_PessoaId",
                table: "Agenda");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Agenda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Agenda",
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
                values: new object[] { new byte[] { 162, 5, 136, 235, 239, 69, 16, 108, 179, 64, 152, 99, 174, 96, 179, 189, 197, 14, 254, 29, 227, 21, 206, 13, 46, 84, 33, 204, 7, 204, 38, 188, 68, 5, 115, 157, 153, 146, 145, 80, 70, 9, 78, 158, 202, 115, 185, 95, 155, 203, 16, 171, 154, 112, 112, 119, 7, 164, 63, 86, 129, 163, 147, 1 }, new byte[] { 140, 125, 217, 70, 231, 177, 5, 170, 65, 140, 242, 43, 91, 97, 158, 234, 104, 242, 196, 147, 139, 220, 16, 55, 244, 218, 212, 229, 178, 223, 92, 79, 110, 175, 246, 53, 57, 25, 58, 13, 251, 153, 143, 10, 123, 188, 196, 84, 245, 182, 219, 222, 85, 158, 56, 106, 99, 31, 6, 129, 136, 108, 113, 213, 244, 121, 95, 74, 214, 88, 242, 15, 234, 55, 190, 220, 211, 94, 73, 57, 76, 72, 236, 25, 41, 39, 73, 182, 7, 177, 121, 49, 9, 104, 128, 139, 165, 127, 47, 240, 73, 250, 135, 16, 23, 194, 231, 8, 152, 178, 56, 20, 23, 1, 53, 163, 116, 255, 251, 240, 75, 176, 136, 147, 129, 234, 80, 36 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Endereco_EnderecoId",
                table: "Agenda",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pessoa_PessoaId",
                table: "Agenda",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Endereco_EnderecoId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pessoa_PessoaId",
                table: "Agenda");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Agenda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Agenda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 251, 117, 16, 172, 16, 147, 173, 93, 176, 28, 57, 213, 228, 186, 99, 150, 56, 171, 153, 185, 15, 199, 236, 2, 146, 151, 251, 142, 185, 45, 17, 23, 254, 214, 7, 195, 26, 48, 204, 151, 34, 26, 56, 80, 234, 165, 180, 38, 209, 242, 22, 250, 116, 126, 181, 24, 113, 200, 114, 150, 251, 156, 52, 123 }, new byte[] { 223, 145, 196, 244, 159, 170, 187, 196, 166, 221, 171, 197, 137, 65, 207, 107, 40, 247, 44, 11, 210, 196, 147, 253, 172, 121, 13, 3, 174, 74, 125, 171, 226, 95, 75, 113, 8, 12, 11, 60, 169, 255, 126, 19, 94, 96, 34, 33, 161, 209, 131, 205, 21, 17, 105, 139, 176, 137, 216, 180, 146, 157, 19, 129, 134, 9, 128, 112, 243, 74, 235, 48, 63, 100, 69, 137, 241, 80, 217, 147, 133, 181, 47, 84, 142, 175, 103, 215, 4, 220, 180, 247, 154, 120, 74, 50, 122, 236, 82, 44, 20, 27, 12, 38, 230, 90, 220, 17, 78, 43, 3, 2, 221, 143, 3, 13, 109, 71, 251, 196, 218, 179, 141, 219, 46, 230, 20, 250 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Endereco_EnderecoId",
                table: "Agenda",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pessoa_PessoaId",
                table: "Agenda",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }
    }
}
