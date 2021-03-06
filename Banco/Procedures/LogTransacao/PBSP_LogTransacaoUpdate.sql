USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoUpdate]    Script Date: 02/12/2021 13:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoUpdate]
@idLogTrans numeric (18,0),
@idConta numeric (18,0),
@idCliente  numeric (18,0),
@valorTrans  numeric (18,2),
@dataTrans date,
@idTrans numeric (18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoUpdate]

	*/

	BEGIN;

	UPDATE [dbo].[logTransacao]
	SET[idConta] = @idConta
      ,[idCliente] = @idCliente
      ,[valorTrans] = @valorTrans
      ,[dataTrans] = @dataTrans
	WHERE [idLogTrans] = @idLogTrans

	END;