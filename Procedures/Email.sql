USE CrudClietnes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_BuscaEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_BuscaEmail]
GO 

CREATE PROCEDURE [dbo].[Proc_BuscaEmail]
	@Id int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Email.sql
	Objetivo..........: Trazer todos emails do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_BuscaEmail] 1
	*/

	BEGIN

		SELECT	e.Id, e.NomeEmail
			FROM [dbo].[EmailCliente] e
				JOIN [dbo].[Cliente] c
					ON c.Id= e.IdCliente
			WHERE e.IdCliente = @Id
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_InsereEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_InsereEmail]
GO 

CREATE PROCEDURE [dbo].[Proc_InsereEmail]
	@NomeEmail varchar(100),
	@IdCliente int
	

	AS

	/*
	Documentação
	Arquivo Fonte.....: Email.sql
	Objetivo..........: Inserir emails do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_InsereEmail] 'teste@teste.com', 2
	*/

	BEGIN

		INSERT INTO [dbo].[EmailCliente] (NomeEmail, IdCliente)
			VALUES (@NomeEmail, @IdCliente)

	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_DeletaEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_DeletaEmail]
GO 

CREATE PROCEDURE [dbo].[Proc_DeletaEmail]
	@IdCliente int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Email.sql
	Objetivo..........: Deletar emails do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_DeletaEmail] 1
	*/

	BEGIN

		DELETE FROM [dbo].[EmailCliente]
			WHERE IdCliente = @IdCliente

	END
GO



				