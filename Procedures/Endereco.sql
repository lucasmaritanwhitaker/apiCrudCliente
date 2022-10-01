USE CrudClietnes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_BuscaEndereco]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_BuscaEndereco]
GO 

CREATE PROCEDURE [dbo].[Proc_BuscaEndereco]
	@Id int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Endereco.sql
	Objetivo..........: Trazer todos enderecos do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_BuscaEndereco] 1
	*/

	BEGIN

		SELECT	e.Id, e.Cep, e.NomeRua, e.NumeroCasa, e.Bairro, e.Cidade, e.Estado, e.Pais
			FROM [dbo].[EnderecoCliente] e
				JOIN [dbo].[Cliente] c
					ON c.Id= e.IdCliente
			WHERE e.IdCliente = @Id
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_InsereEndereco]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_InsereEndereco]
GO 

CREATE PROCEDURE [dbo].[Proc_InsereEndereco]
	@Cep varchar(200),
	@NomeRua varchar(200),
	@Bairro varchar(200),
	@Cidade varchar(200),
	@Estado varchar(200),
	@Pais varchar(200),
	@IdCliente int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Endereco.sql
	Objetivo..........: Trazer todos enderecos do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_InsereEndereco] 
	*/

	BEGIN

		INSERT INTO [dbo].[EnderecoCliente] (Cep, NomeRua, Bairro, Cidade, Estado, Pais, IdCliente)
			VALUES (@Cep, @NomeRua, @Bairro, @Cidade, @Estado, @Pais, @IdCliente)

	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_DeletaEndereco]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_DeletaEndereco]
GO 

CREATE PROCEDURE [dbo].[Proc_DeletaEndereco]
	@IdCliente int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Endereco.sql
	Objetivo..........: Deletar enderecos do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_DeletaEndereco] 2
	*/

	BEGIN

		DELETE 
			FROM [dbo].[EnderecoCliente]
			WHERE IdCliente = @IdCliente

	END
GO

				