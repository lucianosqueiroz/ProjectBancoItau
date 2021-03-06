USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ContaDeletar]    Script Date: 02/12/2021 13:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ContaDeletar]
@idConta numeric(18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Deleta determinada conta pelo Id
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 18/10/2021
	Ex................: EXEC [dbo].[PBSP_ContaDeletar]

	*/

	BEGIN;


	DELETE 
	FROM  [dbo].[conta]
	WHERE [idConta] = @idConta;

	END;
