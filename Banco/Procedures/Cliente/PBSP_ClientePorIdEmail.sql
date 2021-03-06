USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ClientePorIdEmail]    Script Date: 01/12/2021 17:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ClientePorIdEmail]
@idCliente numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_ClientePorIdEmail]

	*/

	BEGIN;

	SELECT 
		[idCliente],
		[email]
  FROM [bdItau].[dbo].[cliente] with(nolock)
  WHERE [idCliente]= @idCliente;
		

	END;
