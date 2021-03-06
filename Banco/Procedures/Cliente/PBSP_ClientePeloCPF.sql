USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_ClientePeloCPF]    Script Date: 01/12/2021 17:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_ClientePeloCPF]
	@cpfCliente varchar(11)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Localiza o cliente pelo CPF
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 13/10/2021
	Ex................: EXEC [dbo].[PBSP_ClientePeloCPF]

	*/

	BEGIN;

  SELECT [idCliente] 
		,[cpf]
        ,[nome]
  FROM [bdItau].[dbo].[cliente] with(nolock)
  WHERE [cpf]= @cpfCliente
		

	END;
