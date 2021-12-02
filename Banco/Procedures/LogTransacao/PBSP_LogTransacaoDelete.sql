USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoDelete]    Script Date: 02/12/2021 13:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoDelete]
@idLogTrans numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Delteta registro pelo id da Tabela LogTransacao
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 21/10/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoDelete]

	*/

	BEGIN;


	DELETE FROM [dbo].[logTransacao]
    WHERE [idLogTrans] = @idLogTrans

	END;