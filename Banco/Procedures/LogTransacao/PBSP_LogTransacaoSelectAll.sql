USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoSelectAll]    Script Date: 02/12/2021 13:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoSelectAll]

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Seleciona todos os registros da Tabela Transacao
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 21/10/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoSelectAll]

	*/

	BEGIN;
	SELECT [idLogTrans]
	  ,[idTrans]
      ,[idConta]
      ,[idCliente]
      ,[valorTrans]
      ,[dataTrans]
	FROM [dbo].[logTransacao]

		

	END;


