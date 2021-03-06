USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_UsuarioListaPorLogin]    Script Date: 02/12/2021 14:03:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_UsuarioListaPorLogin]
@login nvarchar(9)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Localizar usuário pelo login
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 25/10/2021
	Ex................: EXEC [dbo].[PBSP_UsuarioListaPorLogin]

	*/

	BEGIN;

	SELECT
		[idUsuario],
		[login],
		[gerente],
		[senha]
		
			
	FROM [dbo].[usuario]
	WHERE [dbo].[usuario].login = @login
		

	END;
