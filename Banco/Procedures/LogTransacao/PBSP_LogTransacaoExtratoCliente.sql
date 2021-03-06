USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoExtratoCliente]    Script Date: 02/12/2021 13:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoExtratoCliente]
@idCliente numeric(18,0),
@idConta numeric (18,0),
@dataInicial date,
@dataFinal date

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoExtratoCliente]2,1,'2021-10-01', '2021-11-26'

	*/

	BEGIN;


		SELECT 
			[dbo].[logTransacao].[idLogTrans],
			[dbo].[cliente].cpf,
			[dbo].[logTransacao].idCliente,
			[dbo].[cliente].nome,
			[dbo].[conta].idConta,
			[dbo].conta.nConta,
			[dbo].[transacao].idTransacao,
			[dbo].[transacao].[nome] AS transacao,
			[dbo].[logTransacao].[valorTrans],
			[dbo].[logTransacao].[dataTrans]
			FROM [dbo].[logTransacao]
		INNER JOIN [dbo].[cliente]
		ON  [dbo].[cliente]. idCliente = [dbo].[logTransacao].idCliente
		INNER JOIN [dbo].[transacao]
		ON [dbo].[logTransacao].[idTrans] = [dbo].[transacao].[idTransacao]
		INNER JOIN [dbo].[Conta]
		ON [dbo].[logTransacao].[idConta] = [dbo].[conta].[idConta]
		WHERE [dbo].[logTransacao].[idCliente]  = @idCliente
		AND conta.idConta = @idConta
		AND [dbo].[logTransacao].[dataTrans] BETWEEN  CONVERT(VARCHAR , @dataInicial,112) AND CONVERT(VARCHAR , @dataFinal,112)
		 

	END;
