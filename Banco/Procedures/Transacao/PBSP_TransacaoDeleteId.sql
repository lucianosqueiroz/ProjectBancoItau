USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_TransacaoDeleteId]    Script Date: 02/12/2021 13:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_TransacaoDeleteId]
@idTransacao numeric (18,0)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_TransacaoDeleteId]

	*/

	BEGIN;


		DELETE FROM [dbo].[transacao]
		WHERE  [dbo].[transacao].[idTransacao]= @idTransacao

	END;
