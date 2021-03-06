USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaUpdateSaldo]    Script Date: 02/12/2021 13:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaUpdateSaldo]
@idConta numeric(18,0),
@saldo numeric(18,2)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atulizar o saldo da conta do cliente
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 22/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaUpdateSaldo]2,50.00
	
	*/

	BEGIN;

	UPDATE [dbo].[conta]
	SET	[saldoCliente] = @saldo
	WHERE  [idConta] = @idConta;
		

	END;
