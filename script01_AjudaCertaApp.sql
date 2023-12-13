IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Endereco] (
    [Id] int NOT NULL IDENTITY,
    [Rua] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [Bairro] nvarchar(max) NULL,
    [Complemento] nvarchar(max) NULL,
    [Bloco] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    [Estado] nvarchar(max) NULL,
    [Cep] nvarchar(max) NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ItemDoacao] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [TipoItem] int NOT NULL,
    [Foto] varbinary(max) NULL,
    CONSTRAINT [PK_ItemDoacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Conteudo] nvarchar(max) NULL,
    [Foto] varbinary(max) NULL,
    [DataPostagem] datetime2 NOT NULL,
    [Likes] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NULL,
    [Senha_Hash] varbinary(max) NULL,
    [Senha_Salt] varbinary(max) NULL,
    [UltimoAcesso] datetime2 NOT NULL,
    [Foto] varbinary(max) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Eletrodomestico] (
    [Id] int NOT NULL IDENTITY,
    [Medida] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Eletrodomestico] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Eletrodomestico_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Mobilia] (
    [Id] int NOT NULL IDENTITY,
    [Tipo] nvarchar(max) NULL,
    [Medida] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Mobilia] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilia_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Produto] (
    [Id] int NOT NULL IDENTITY,
    [Validade] datetime2 NOT NULL,
    [TipoProduto] int NOT NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produto_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Roupa] (
    [Id] int NOT NULL IDENTITY,
    [Tamanho] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [Genero] int NOT NULL,
    [FaixaEtaria] int NOT NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Roupa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Roupa_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Pessoa] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Username] nvarchar(max) NULL,
    [Documento] nvarchar(max) NULL,
    [fisicaJuridica] int NOT NULL,
    [Telefone] nvarchar(max) NULL,
    [Genero] nvarchar(max) NULL,
    [DataNasc] datetime2 NOT NULL,
    [Tipo] int NOT NULL,
    [UsuarioId] int NOT NULL,
    [EnderecoId] int NOT NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoa_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Pessoa_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Agenda] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [PessoaId] int NULL,
    [EnderecoId] int NULL,
    CONSTRAINT [PK_Agenda] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Agenda_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]),
    CONSTRAINT [FK_Agenda_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id])
);
GO

CREATE TABLE [Mensagem] (
    [Id] int NOT NULL IDENTITY,
    [Conteudo] nvarchar(max) NULL,
    [DataEnvio] datetime2 NOT NULL,
    [DestinatarioId] int NOT NULL,
    [RemetenteId] int NOT NULL,
    CONSTRAINT [PK_Mensagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mensagem_Pessoa_DestinatarioId] FOREIGN KEY ([DestinatarioId]) REFERENCES [Pessoa] ([Id]),
    CONSTRAINT [FK_Mensagem_Pessoa_RemetenteId] FOREIGN KEY ([RemetenteId]) REFERENCES [Pessoa] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Doacao] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [StatusDoacao] int NOT NULL,
    [TipoDoacao] int NOT NULL,
    [IdDoacaoOrigem] int NOT NULL,
    [PessoaId] int NULL,
    [AgendaId] int NOT NULL,
    [Dinheiro] float NOT NULL,
    CONSTRAINT [PK_Doacao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Doacao_Agenda_AgendaId] FOREIGN KEY ([AgendaId]) REFERENCES [Agenda] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Doacao_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id])
);
GO

CREATE TABLE [ItemDoacaoDoado] (
    [DoacaoId] int NOT NULL,
    [ItemDoacaoId] int NOT NULL,
    CONSTRAINT [PK_ItemDoacaoDoado] PRIMARY KEY ([DoacaoId], [ItemDoacaoId]),
    CONSTRAINT [FK_ItemDoacaoDoado_Doacao_DoacaoId] FOREIGN KEY ([DoacaoId]) REFERENCES [Doacao] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemDoacaoDoado_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Bloco', N'Cep', N'Cidade', N'Complemento', N'Estado', N'Numero', N'Rua') AND [object_id] = OBJECT_ID(N'[Endereco]'))
    SET IDENTITY_INSERT [Endereco] ON;
INSERT INTO [Endereco] ([Id], [Bairro], [Bloco], [Cep], [Cidade], [Complemento], [Estado], [Numero], [Rua])
VALUES (1, N'Jardim Tremembé', NULL, N'02319000', N'São Paulo', NULL, N'São Paulo', N'1091', N'Avenida Josino Vieira de Goes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Bloco', N'Cep', N'Cidade', N'Complemento', N'Estado', N'Numero', N'Rua') AND [object_id] = OBJECT_ID(N'[Endereco]'))
    SET IDENTITY_INSERT [Endereco] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Foto', N'Senha_Hash', N'Senha_Salt', N'UltimoAcesso') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([Id], [Email], [Foto], [Senha_Hash], [Senha_Salt], [UltimoAcesso])
VALUES (1, N'ongestreladalva@gmail.com', NULL, 0x285A2E981F4E57F8BB36C4052830D352D9222F991030664D36B9D5BF2EA270D6A2EE4D2C5F03FA094AE59812E2DABC98005BCB45491B3789F34C2E59FDA668F7, 0xD24D60AACBBC2155C5974302C87D9638510BAB62DC6A5F522119FC3C071BE659B6DBF7DD28E90F1CACE9B1ACFD3EB75052A0520A893841CD1A784DA073356C541178BBDC2536270E1B17006EED5CADFB7CC8814F8202ECA2E4263234E2E2FD974DEE350AE8F017BB9F5CD00C24E434B13552598872D315E624423623ECAB35FF, '0001-01-01T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Foto', N'Senha_Hash', N'Senha_Salt', N'UltimoAcesso') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataNasc', N'Documento', N'EnderecoId', N'Genero', N'Nome', N'Telefone', N'Tipo', N'Username', N'UsuarioId', N'fisicaJuridica') AND [object_id] = OBJECT_ID(N'[Pessoa]'))
    SET IDENTITY_INSERT [Pessoa] ON;
INSERT INTO [Pessoa] ([Id], [DataNasc], [Documento], [EnderecoId], [Genero], [Nome], [Telefone], [Tipo], [Username], [UsuarioId], [fisicaJuridica])
VALUES (1, '0001-01-01T00:00:00.0000000', NULL, 1, NULL, N'ONG Estrela Dalva', NULL, 2, NULL, 1, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataNasc', N'Documento', N'EnderecoId', N'Genero', N'Nome', N'Telefone', N'Tipo', N'Username', N'UsuarioId', N'fisicaJuridica') AND [object_id] = OBJECT_ID(N'[Pessoa]'))
    SET IDENTITY_INSERT [Pessoa] OFF;
GO

CREATE INDEX [IX_Agenda_EnderecoId] ON [Agenda] ([EnderecoId]);
GO

CREATE INDEX [IX_Agenda_PessoaId] ON [Agenda] ([PessoaId]);
GO

CREATE UNIQUE INDEX [IX_Doacao_AgendaId] ON [Doacao] ([AgendaId]);
GO

CREATE INDEX [IX_Doacao_PessoaId] ON [Doacao] ([PessoaId]);
GO

CREATE INDEX [IX_Eletrodomestico_ItemDoacaoId] ON [Eletrodomestico] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_ItemDoacaoDoado_ItemDoacaoId] ON [ItemDoacaoDoado] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Mensagem_DestinatarioId] ON [Mensagem] ([DestinatarioId]);
GO

CREATE INDEX [IX_Mensagem_RemetenteId] ON [Mensagem] ([RemetenteId]);
GO

CREATE INDEX [IX_Mobilia_ItemDoacaoId] ON [Mobilia] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Pessoa_EnderecoId] ON [Pessoa] ([EnderecoId]);
GO

CREATE INDEX [IX_Pessoa_UsuarioId] ON [Pessoa] ([UsuarioId]);
GO

CREATE INDEX [IX_Produto_ItemDoacaoId] ON [Produto] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Roupa_ItemDoacaoId] ON [Roupa] ([ItemDoacaoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231128130407_InitialCreate', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Pessoa] SET [Username] = N'@ong_estreladalva'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuario] SET [Senha_Hash] = 0x55DB8C3566F45995863B773764DA1D00260F59E71256453B267C3DDEFD862CD22E89B7866C052CD35E903EFE74EF3F3B01814C256BC98B76808BFB6FF27B3501, [Senha_Salt] = 0xB06E17B3597081535D69DC660183922624C42F0EE9A7720D9F6593F7C39836FBD3E403BCAE9C37C6018E38DA51BBAE2E744FFC1282C12A7A99C6CBDD0A897D53FEEBB86CF83E945A69EF7E66523DF1D9EE5C6A8C7CFF68DC4C4FCBF1DEF9B83108F5AFBFD5C33EEBD81D6EB82C687E9740437883BFFAC339F3C97FE82B18C512
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231128132005_AjudaCertaApp', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ItemDoacao] ADD [Quantidade] int NOT NULL DEFAULT 0;
GO

UPDATE [Usuario] SET [Senha_Hash] = 0xFB7510AC1093AD5DB01C39D5E4BA639638AB99B90FC7EC029297FB8EB92D1117FED607C31A30CC97221A3850EAA5B426D1F216FA747EB51871C87296FB9C347B, [Senha_Salt] = 0xDF91C4F49FAABBC4A6DDABC58941CF6B28F72C0BD2C493FDAC790D03AE4A7DABE25F4B71080C0B3CA9FF7E135E602221A1D183CD1511698BB089D8B4929D138186098070F34AEB303F644589F150D99385B52F548EAF67D704DCB4F79A784A327AEC522C141B0C26E65ADC114E2B0302DD8F030D6D47FBC4DAB38DDB2EE614FA
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231130021526_MigracaoCestaBasica', N'7.0.11');
GO

COMMIT;
GO

