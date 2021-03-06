USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaUpdate]    Script Date: 02/12/2021 13:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaUpdate]
@nConta numeric(11,0),
@cDigito numeric(1,0),
@nAgencia numeric (4,0),
@aDigito numeric(1,0),
@senha varchar(20),
@idCliente numeric(18,0),
@saldo numeric(18,2)


	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atualiza os dados da conta do cliente pelo numero da conta
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 18/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaUpdate]

	*/

	BEGIN;


	UPDATE [dbo].[conta]
	SET	[nConta] = @nConta
		,[cDigito]= @cDigito
		,[nAgencia] = @nAgencia
		,[aDigito] = @aDigito
		,[senha] = @senha
		,[idCliente] = @idCliente
		,[saldoCliente] = @saldo
	WHERE  [nConta] = @nConta;
		


	END;
