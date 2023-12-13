using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoItem = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDoacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataPostagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha_Hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eletrodomestico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eletrodomestico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mobilia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobilia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoProduto = table.Column<int>(type: "int", nullable: false),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roupa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    FaixaEtaria = table.Column<int>(type: "int", nullable: false),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roupa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fisicaJuridica = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agenda_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinatarioId = table.Column<int>(type: "int", nullable: false),
                    RemetenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Pessoa_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mensagem_Pessoa_RemetenteId",
                        column: x => x.RemetenteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDoacao = table.Column<int>(type: "int", nullable: false),
                    TipoDoacao = table.Column<int>(type: "int", nullable: false),
                    IdDoacaoOrigem = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    AgendaId = table.Column<int>(type: "int", nullable: false),
                    Dinheiro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacao_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacao_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemDoacaoDoado",
                columns: table => new
                {
                    DoacaoId = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDoacaoDoado", x => new { x.DoacaoId, x.ItemDoacaoId });
                    table.ForeignKey(
                        name: "FK_ItemDoacaoDoado_Doacao_DoacaoId",
                        column: x => x.DoacaoId,
                        principalTable: "Doacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDoacaoDoado_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Bairro", "Bloco", "Cep", "Cidade", "Complemento", "Estado", "Numero", "Rua" },
                values: new object[] { 1, "Jardim Tremembé", null, "02319000", "São Paulo", null, "São Paulo", "1091", "Avenida Josino Vieira de Goes" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Foto", "Senha_Hash", "Senha_Salt", "UltimoAcesso" },
                values: new object[] { 1, "ongestreladalva@gmail.com", null, new byte[] { 40, 90, 46, 152, 31, 78, 87, 248, 187, 54, 196, 5, 40, 48, 211, 82, 217, 34, 47, 153, 16, 48, 102, 77, 54, 185, 213, 191, 46, 162, 112, 214, 162, 238, 77, 44, 95, 3, 250, 9, 74, 229, 152, 18, 226, 218, 188, 152, 0, 91, 203, 69, 73, 27, 55, 137, 243, 76, 46, 89, 253, 166, 104, 247 }, new byte[] { 210, 77, 96, 170, 203, 188, 33, 85, 197, 151, 67, 2, 200, 125, 150, 56, 81, 11, 171, 98, 220, 106, 95, 82, 33, 25, 252, 60, 7, 27, 230, 89, 182, 219, 247, 221, 40, 233, 15, 28, 172, 233, 177, 172, 253, 62, 183, 80, 82, 160, 82, 10, 137, 56, 65, 205, 26, 120, 77, 160, 115, 53, 108, 84, 17, 120, 187, 220, 37, 54, 39, 14, 27, 23, 0, 110, 237, 92, 173, 251, 124, 200, 129, 79, 130, 2, 236, 162, 228, 38, 50, 52, 226, 226, 253, 151, 77, 238, 53, 10, 232, 240, 23, 187, 159, 92, 208, 12, 36, 228, 52, 177, 53, 82, 89, 136, 114, 211, 21, 230, 36, 66, 54, 35, 236, 171, 53, 255 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "DataNasc", "Documento", "EnderecoId", "Genero", "Nome", "Telefone", "Tipo", "Username", "UsuarioId", "fisicaJuridica" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, "ONG Estrela Dalva", null, 2, null, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_EnderecoId",
                table: "Agenda",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PessoaId",
                table: "Agenda",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_AgendaId",
                table: "Doacao",
                column: "AgendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_PessoaId",
                table: "Doacao",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eletrodomestico_ItemDoacaoId",
                table: "Eletrodomestico",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDoacaoDoado_ItemDoacaoId",
                table: "ItemDoacaoDoado",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_DestinatarioId",
                table: "Mensagem",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_RemetenteId",
                table: "Mensagem",
                column: "RemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobilia_ItemDoacaoId",
                table: "Mobilia",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioId",
                table: "Pessoa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ItemDoacaoId",
                table: "Produto",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Roupa_ItemDoacaoId",
                table: "Roupa",
                column: "ItemDoacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eletrodomestico");

            migrationBuilder.DropTable(
                name: "ItemDoacaoDoado");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Mobilia");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Roupa");

            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "ItemDoacao");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
