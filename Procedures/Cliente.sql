USE CrudClietnes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_BuscaClientes]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_BuscaClientes]
GO 

CREATE PROCEDURE [dbo].[Proc_BuscaClientes]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Cliente.sql
	Objetivo..........: Trazer todos os clientes cadastrados
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_BuscaClientes]
	*/

	BEGIN

		SELECT	c.Nome, 
				c.Id,
				s.NomeSexo AS Sexo,
				ec.NomeEstadoCivil AS EstadoCivil,
				n.NomeNacionalidade AS Nacionalidade
			FROM [dbo].[Cliente] c
				JOIN [dbo].[Sexo] s
					ON c.Sexo = s.Id
				JOIN [dbo].[EstadoCivil] ec
					ON c.EstadoCivil = ec.Id
				JOIN [dbo].[Nacionalidade] n
					ON c.Nacionalidade = n.Id

	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_BuscaCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_BuscaCliente]
GO 

CREATE PROCEDURE [dbo].[Proc_BuscaCliente]
	@Id int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Cliente.sql
	Objetivo..........: Trazer o cliente selecionado
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_BuscaCliente]
	*/

	BEGIN

		SELECT	c.*
			FROM [dbo].[Cliente] c
				JOIN [dbo].[Sexo] s
					ON c.Sexo = s.Id
				JOIN [dbo].[EstadoCivil] ec
					ON c.EstadoCivil = ec.Id
				JOIN [dbo].[Nacionalidade] n
					ON c.Nacionalidade = n.Id
			WHERE c.Id = @Id

	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_InsereCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_InsereCliente]
GO 

CREATE PROCEDURE [dbo].[Proc_InsereCliente]
	@Nome varchar(50),
	@Sexo tinyint,
	@EstadoCivil tinyint,
	@Nacionalidade smallint

	AS

	/*
	Documentação
	Arquivo Fonte.....: Cliente.sql
	Objetivo..........: Inserir um cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_InsereCliente] 'NomeTeste', 2, 3, 4
	*/

	BEGIN 

		INSERT INTO [dbo].[Cliente] (Nome, Sexo, EstadoCivil, Nacionalidade)
			VALUES (@Nome, @Sexo, @EstadoCivil, @Nacionalidade)
			
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_AtualizaCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_AtualizaCliente]
GO 

CREATE PROCEDURE [dbo].[Proc_AtualizaCliente]
	@Id int,
	@Nome varchar(50),
	@Sexo tinyint,
	@EstadoCivil tinyint,
	@Nacionalidade smallint

	AS

	/*
	Documentação
	Arquivo Fonte.....: Cliente.sql
	Objetivo..........: Atualizar um cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_AtualizaCliente] 'NomeTeste', 2, 3, 4
	*/

	BEGIN 

		UPDATE [dbo].[Cliente] 
			SET Nome = @Nome, 
				Sexo = @Sexo,
				EstadoCivil = @EstadoCivil , 
				Nacionalidade = @Nacionalidade
			WHERE Id = @Id

	END
GO
	
	
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Proc_DeletaCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[Proc_DeletaCliente]
GO 

CREATE PROCEDURE [dbo].[Proc_DeletaCliente]
	@Id int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Cliente.sql
	Objetivo..........: Deletar um cliente
	Autor.............: Lucas Maritan
 	Data..............: 30/09/2022
	Ex................: EXEC [dbo].[Proc_DeletaCliente] 'NomeTeste', 2, 3, 4
	*/

	BEGIN 

		DELETE FROM [dbo].[Cliente] WHERE Id = @Id
			
	END
GO