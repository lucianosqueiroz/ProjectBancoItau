USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaListaPorNumConta]    Script Date: 02/12/2021 13:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaListaPorNumConta]
@nConta numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Busca pelo numero da conta
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 28/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaListaPorNumConta]

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
		WHERE [dbo].[conta]. nConta = @nConta

		

	END;
