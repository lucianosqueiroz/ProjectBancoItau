USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ListaClientes]    Script Date: 02/12/2021 13:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ListaClientes]

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Listar todos clientes
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 13/10/2021
	Ex................: EXEC [dbo].[PBSP_ListaClientes]

	*/

	BEGIN;

	SELECT [idCliente],
		[cpf],
		[nome]
  FROM [bdItau].[dbo].[cliente] with(nolock)
		

	END;
