USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_SelectUsuarioID]    Script Date: 02/12/2021 13:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_SelectUsuarioID]
	@idUser int
	
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Selecionar um usuário pelo ID
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 13/10/2021
	Ex................: EXEC [dbo].[PBSP_SelectUsuarioID]

	*/
	
	BEGIN;

	
			SELECT idUsuario,
				login,
				gerente, 
				senha
			FROM [dbo].[usuario] with(nolock)
			WHERE [idUsuario] = @idUser
			

	END;
