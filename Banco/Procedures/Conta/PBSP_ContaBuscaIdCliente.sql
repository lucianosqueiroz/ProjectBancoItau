USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaBuscaIdCliente]    Script Date: 02/12/2021 13:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaBuscaIdCliente]
 @idCliente numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Localiza a conta pelo id do cliente
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 28/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaBuscaIdCliente]

	*/

	BEGIN;

		SELECT 
			[dbo].[conta].idCliente,
			[dbo].[conta].idConta,
			[dbo].[conta].nConta,
			[dbo].[conta].cDigito,
			[dbo].[conta].nAgencia,
			[dbo].[conta].aDigito,
			[dbo].[conta].senha,
			[dbo].[conta].saldoCliente
		FROM [dbo].[conta]
		WHERE [dbo].[conta]. idCliente = @idCliente
		

	END;
