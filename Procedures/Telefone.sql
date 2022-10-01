USE CrudClietnes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_BuscaTelefone]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_BuscaTelefone]
GO 

CREATE PROCEDURE [dbo].[Proc_BuscaTelefone]
	@Id int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Telefone.sql
	Objetivo..........: Trazer todos telefones do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_BuscaTelefone] 1
	*/

	BEGIN
	
		SELECT	t.Id, t.Ddd, t.Ddi, t.Numero
			FROM [dbo].[TelefoneCliente] t
				JOIN [dbo].[Cliente] c
					ON c.Id= t.IdCliente
			WHERE t.IdCliente = @Id
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_InsereTelefone]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_InsereTelefone]
GO 

CREATE PROCEDURE [dbo].[Proc_InsereTelefone]
	@IdCliente int,
	@Ddi  int,
	@Ddd  int,
	@Numero varchar(18)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Telefone.sql
	Objetivo..........: Inserir telefones do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_InsereTelefone] 2, 55,16,'993557170'
	*/

	BEGIN
	
		INSERT INTO [dbo].[TelefoneCliente] (IdCliente, Ddi, Ddd, Numero)
			VALUES (@IdCliente, @Ddi, @Ddd, @Numero)

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_DeletaTelefone]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_DeletaTelefone]
GO 

CREATE PROCEDURE [dbo].[Proc_DeletaTelefone]
	@IdCliente int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Telefone.sql
	Objetivo..........: Deletar telefones do Cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_DeletaTelefone] 2
	*/

	BEGIN
	
		DELETE 
			FROM [dbo].[TelefoneCliente]
			WHERE IdCliente = @IdCliente

	END
GO

				