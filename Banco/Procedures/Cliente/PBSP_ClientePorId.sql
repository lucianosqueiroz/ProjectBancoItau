USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ClientePorId]    Script Date: 01/12/2021 17:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ClientePorId]
	@idCliente numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Localiza cliente pelo id
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 19/10/2021
	Ex................: EXEC [dbo].[PBSP_ClientePorId]2

	*/

	BEGIN;

	SELECT 
		[idCliente],
		[cpf],
		[nome],
		[email]
  FROM [bdItau].[dbo].[cliente] with(nolock)
  WHERE [idCliente]= @idCliente;
		

	END;
