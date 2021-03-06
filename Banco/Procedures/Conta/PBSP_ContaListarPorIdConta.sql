USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaListarPorIdConta]    Script Date: 02/12/2021 13:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaListarPorIdConta]
@idConta numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_ContaListarPorIdConta]1

	*/

	BEGIN;


			SELECT 
			[dbo].[cliente].cpf,
			[dbo].[cliente].nome,
			[dbo].[conta].idCliente,
			[dbo].[conta].idConta,
			[dbo].[conta].nConta,
			[dbo].[conta].cDigito,
			[dbo].[conta].nAgencia,
			[dbo].[conta].aDigito,
			[dbo].[conta].senha,
			[dbo].[conta].saldoCliente
		FROM [dbo].[cliente]
		INNER JOIN [dbo].[conta]
		ON  [dbo].[cliente]. idCliente = [dbo].[conta].idCliente
		WHERE [dbo].[conta]. idConta = @idConta

	END;
