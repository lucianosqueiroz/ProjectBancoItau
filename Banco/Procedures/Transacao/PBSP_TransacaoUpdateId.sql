USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_TransacaoUpdateId]    Script Date: 02/12/2021 14:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_TransacaoUpdateId]
@nome nvarchar(20),
@idTransacao numeric (18,0)

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atualiza registr
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_TransacaoUpdateId]

	*/

	BEGIN;

	UPDATE [dbo].[transacao]
	SET 
		[dbo].[transacao].[nome] = @nome
	WHERE [dbo].[transacao].[idTransacao] = @idTransacao
END;