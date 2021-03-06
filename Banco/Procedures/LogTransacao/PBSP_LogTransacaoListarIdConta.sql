USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoListarIdConta]    Script Date: 02/12/2021 13:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoListarIdConta]
@idConta numeric (18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Lista os logs de transaçcao pelo id da conta
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 24/10/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoListarIdConta]

	*/

	BEGIN;


		
	SELECT [idLogTrans]
	  ,[idTrans]
      ,[idConta]
      ,[idCliente]
      ,[valorTrans]
      ,[dataTrans]
	FROM [dbo].[logTransacao]
	WHERE idConta = @idConta

	END;
