USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_SelectUsuarioGerente]    Script Date: 02/12/2021 13:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_SelectUsuarioGerente]
	
	
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Selecionar usuários gerentes
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 13/10/2021
	Ex................: EXEC [dbo].[PBSP_SelectUsuarioID]

	*/
	
	BEGIN;

	
			SELECT idUsuario,
				login,
				gerente
			FROM [dbo].[usuario] with(nolock)
			WHERE [gerente] = 1
			

	END;
