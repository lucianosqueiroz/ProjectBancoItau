USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoExtratoResumido]    Script Date: 02/12/2021 13:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoExtratoResumido]
@idCliente numeric(18,0),
@idConta numeric (18,0),
@idTrans numeric (18,0),
@dataInicial varchar(10),
@dataFinal varchar (10)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Extrato resumido filtrado por opeeração
	Autor.............: SMN - Luciano Queiroz EXEC [dbo].[PBSP_LogTransacaoExtratoResumido]1,2,1,'2021-10-01', '2021-10-25'
 	Data..............: 24/10/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoExtratoResumido]1,2,1,'08/10/2021 00:00:00', '24/10/2021 00:00:00'

	*/

	BEGIN;
	SELECT 
			[dbo].[logTransacao].[idLogTrans],
			[dbo].[logTransacao].idCliente,
			[dbo].[logTransacao].idConta,
			[dbo].[logTransacao].idTrans,
			[dbo].[logTransacao].valorTrans,
			[dbo].[logTransacao].dataTrans
		FROM [dbo].logTransacao
		WHERE [dbo].[logTransacao].idCliente  = @idCliente
			AND [dbo].[logTransacao].idConta = @idConta
			AND [dbo].[logTransacao].[idTrans] = @idTrans
			AND [dbo].[logTransacao].[dataTrans] BETWEEN  CONVERT(VARCHAR , @dataInicial,112) AND CONVERT(VARCHAR , @dataFinal,112) 


		

	END;
