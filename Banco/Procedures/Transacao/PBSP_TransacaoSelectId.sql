USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_TransacaoSelectId]    Script Date: 02/12/2021 14:01:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_TransacaoSelectId]
@idTransacao numeric (18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Seleciona a transação pelo seu idTransacao
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 21/10/2021
	Ex................: EXEC [dbo].[PBSP_TransacaoSelectId]

	*/

	BEGIN;


	SELECT	[idTransacao],
			[nome]
    FROM [dbo].[transacao] with(nolock)
	WHERE [dbo].[transacao].[idTransacao] = @idTransacao

	END;
