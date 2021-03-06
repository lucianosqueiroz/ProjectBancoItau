USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ListaClientePeloNumeroConta]    Script Date: 02/12/2021 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ListaClientePeloNumeroConta]
@nConta  numeric(9, 0),
@nAgencia  numeric(4, 0)

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Localiza o cliente pelo número da conta e dítito
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 14/10/2021
	Ex................: EXEC [dbo].[PBSP_ListaClientePeloNumeroConta]

	*/

	BEGIN;


		SELECT 
			[dbo].[cliente].idCliente,
			[dbo].[conta].idConta,
			[dbo].[conta].nConta,
			[dbo].[conta].cDigito,
			[dbo].[conta].nAgencia,
			[dbo].[conta].aDigito,
			[dbo].[conta].saldoCliente,
			[dbo].[conta].senha
		FROM [dbo].[cliente]
		INNER JOIN [dbo].[conta]
		ON  [dbo].[cliente]. idCliente = [dbo].[conta].[idCliente]
		WHERE [dbo].[conta].nConta = @nConta
			and [dbo].[conta].nAgencia = @nAgencia
			
		

	END;
