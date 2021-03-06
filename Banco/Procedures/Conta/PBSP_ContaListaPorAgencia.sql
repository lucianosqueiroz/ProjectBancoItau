USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaListaPorAgencia]    Script Date: 02/12/2021 13:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaListaPorAgencia]
@nAgencia numeric (4,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: listar todas as contas de determinada agencia.
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 28/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaListaPorAgencia]149

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
		WHERE [dbo].[conta]. nAgencia = @nAgencia

	END;
