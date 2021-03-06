USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ClienteInserir]    Script Date: 01/12/2021 17:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ClienteInserir]
@cpf varchar(11),
@nome varchar(90)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Inserção de clientes no banco de dados
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 18/10/2021
	Ex................: EXEC [dbo].[PBSP_ClienteInserir]

	*/

	BEGIN;

	INSERT INTO [dbo].[cliente]
			([dbo].[cliente].cpf, 
			[dbo].[cliente].nome) 
			
	VALUES (@cpf, @nome);
		

	END;
