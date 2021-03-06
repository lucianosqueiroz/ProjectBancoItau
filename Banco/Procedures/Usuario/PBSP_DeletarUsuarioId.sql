USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_DeletarUsuarioId]    Script Date: 02/12/2021 13:43:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_DeletarUsuarioId]
	@idUser int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: LOCALIZAR USUARIO PELO ID
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 13/10/2021
	Ex................: EXEC [dbo].[PBSP_DeletarUsuarioId]2

	*/

	BEGIN;

	DELETE 
	FROM [dbo].[usuario] 
	WHERE [idUsuario] = @idUser ;
		

	END;
