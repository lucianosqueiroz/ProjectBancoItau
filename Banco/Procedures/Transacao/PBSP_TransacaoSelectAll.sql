USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_TransacaoSelectAll]    Script Date: 02/12/2021 14:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_TransacaoSelectAll]

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Seleciona todas as transações
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 21/10/2021
	Ex................: EXEC [dbo].[PBSP_TransacaoSelectAll]

	*/

	BEGIN;

	SELECT	[idTransacao],
			[nome]
    FROM [dbo].[transacao] with(nolock)

	END;