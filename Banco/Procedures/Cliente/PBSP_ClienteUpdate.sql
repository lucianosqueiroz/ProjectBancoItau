USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ClienteUpdate]    Script Date: 01/12/2021 17:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ClienteUpdate]
@cpf varchar(11),
@nome varchar(90),
@idCliente numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_ClienteUpdate]

	*/

	BEGIN;


	UPDATE [dbo].[cliente]
	SET [cpf] = @cpf, 
		[nome]= @nome
	WHERE [idCliente] = @idCliente;

	END;
