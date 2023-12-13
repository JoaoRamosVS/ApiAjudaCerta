using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoIdsEmItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                table: "Eletrodomestico");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                table: "Mobilia");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                table: "Roupa");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Roupa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Mobilia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Eletrodomestico",
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
                values: new object[] { new byte[] { 121, 151, 187, 224, 15, 120, 1, 9, 138, 254, 220, 196, 179, 66, 3, 113, 204, 125, 135, 145, 193, 233, 143, 146, 57, 34, 217, 242, 201, 149, 138, 51, 94, 107, 69, 148, 36, 235, 52, 159, 120, 177, 58, 223, 58, 133, 109, 213, 130, 53, 190, 21, 122, 54, 125, 185, 229, 159, 190, 73, 34, 216, 98, 68 }, new byte[] { 236, 89, 87, 158, 109, 199, 12, 182, 180, 127, 209, 226, 203, 215, 84, 31, 166, 49, 170, 191, 177, 105, 175, 5, 221, 165, 78, 162, 121, 170, 58, 243, 104, 112, 209, 156, 199, 146, 199, 34, 214, 66, 107, 147, 71, 27, 176, 71, 112, 124, 255, 131, 43, 118, 91, 27, 94, 106, 162, 144, 189, 191, 219, 16, 113, 247, 100, 67, 132, 129, 182, 235, 245, 178, 188, 231, 110, 251, 160, 100, 53, 140, 127, 225, 207, 107, 28, 99, 221, 80, 181, 189, 83, 123, 157, 190, 107, 207, 9, 86, 192, 113, 103, 58, 100, 177, 196, 37, 163, 255, 242, 177, 78, 118, 40, 100, 155, 88, 93, 212, 82, 188, 71, 172, 113, 199, 62, 67 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                table: "Eletrodomestico",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                table: "Mobilia",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                table: "Produto",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                table: "Roupa",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                table: "Eletrodomestico");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                table: "Mobilia");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                table: "Roupa");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Roupa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Mobilia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoacaoId",
                table: "Eletrodomestico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 162, 5, 136, 235, 239, 69, 16, 108, 179, 64, 152, 99, 174, 96, 179, 189, 197, 14, 254, 29, 227, 21, 206, 13, 46, 84, 33, 204, 7, 204, 38, 188, 68, 5, 115, 157, 153, 146, 145, 80, 70, 9, 78, 158, 202, 115, 185, 95, 155, 203, 16, 171, 154, 112, 112, 119, 7, 164, 63, 86, 129, 163, 147, 1 }, new byte[] { 140, 125, 217, 70, 231, 177, 5, 170, 65, 140, 242, 43, 91, 97, 158, 234, 104, 242, 196, 147, 139, 220, 16, 55, 244, 218, 212, 229, 178, 223, 92, 79, 110, 175, 246, 53, 57, 25, 58, 13, 251, 153, 143, 10, 123, 188, 196, 84, 245, 182, 219, 222, 85, 158, 56, 106, 99, 31, 6, 129, 136, 108, 113, 213, 244, 121, 95, 74, 214, 88, 242, 15, 234, 55, 190, 220, 211, 94, 73, 57, 76, 72, 236, 25, 41, 39, 73, 182, 7, 177, 121, 49, 9, 104, 128, 139, 165, 127, 47, 240, 73, 250, 135, 16, 23, 194, 231, 8, 152, 178, 56, 20, 23, 1, 53, 163, 116, 255, 251, 240, 75, 176, 136, 147, 129, 234, 80, 36 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                table: "Eletrodomestico",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                table: "Mobilia",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                table: "Produto",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                table: "Roupa",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");
        }
    }
}
