USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_DeletarClienteCPF]    Script Date: 02/12/2021 13:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_DeletarClienteCPF]
	@cpfCliente varchar(11)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Deleta o cliente pelo seu cpf
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 13/10/2021
	Ex................: EXEC [dbo].[PBSP_DeletarClienteCPF]

[dbo].[cliente]	*/

	BEGIN;


		DELETE 	
		FROM  [dbo].[cliente]
		WHERE [cpf] = @cpfCliente;

	END;
