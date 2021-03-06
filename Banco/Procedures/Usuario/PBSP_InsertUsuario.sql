USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_InsertUsuario]    Script Date: 02/12/2021 13:44:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_InsertUsuario]
@login  nvarchar(9),
@gerente bit,
@senha nvarchar(100)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_InsertUsuario]

	*/

	BEGIN;

	INSERT INTO [dbo].[usuario]
			([dbo].[usuario].login, 
			[dbo].[usuario].gerente, 
			[dbo].[usuario].senha)
	VALUES (@login, @gerente, @senha);
		

	END;
