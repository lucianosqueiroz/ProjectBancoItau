USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ClienteListaNome]    Script Date: 01/12/2021 17:44:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ClienteListaNome]
@nome varchar(90)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: localiza Cliente e conta pelo nome
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 27/10/2021
	Ex................: EXEC [dbo].[PBSP_ClienteListaNome]

	*/

	BEGIN;

	SELECT [dbo].[cliente].idCliente,
			[dbo].[cliente].cpf,
			[dbo].[cliente].nome
		FROM [dbo].[cliente] with(nolock)
		WHERE cliente.nome LIKE '%' + @nome + '%'

	END;
		

	
