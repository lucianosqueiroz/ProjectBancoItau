USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaInserir]    Script Date: 02/12/2021 13:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaInserir]
@nConta numeric(11,0),
@cDigito numeric(1,0),
@nAgencia numeric (4,0),
@aDigito numeric(1,0),
@senha varchar(20),
@idCliente varchar(11),
@saldo numeric(18,2)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Cadastrar conta de cliente no banco
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 19/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaInserir]

	*/

	BEGIN;

	INSERT INTO [dbo].[conta]
			([nConta]
			,[cDigito]
			,[nAgencia]
			,[aDigito]
			,[senha]
			,[idCliente]
			,[saldoCliente]) 
	VALUES (@nconta, 
			@cDigito,
			@nAgencia,
			@aDigito,
			@senha,
			@idCliente,
			@saldo);
		

	END;
