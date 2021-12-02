USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_TransacaoInsert]    Script Date: 02/12/2021 14:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_TransacaoInsert]
@nome nvarchar(20)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Inserir registro na tabela Transacao
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 21/10/2021
	Ex................: EXEC [dbo].[PBSP_TransacaoInsert]

	*/

	BEGIN;

	INSERT INTO [dbo].[transacao]
           ([nome])
     VALUES
           (@nome)
		

	END;
