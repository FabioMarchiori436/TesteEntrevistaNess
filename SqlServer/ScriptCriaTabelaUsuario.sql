CREATE TABLE [dbo].[Usuarios] (
    [Id]       INT          NOT NULL IDENTITY(1, 1),
    [Nome]     VARCHAR (50) NULL,
    [Cpf]      VARCHAR (11) NULL,
    [Telefone] VARCHAR (13) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
