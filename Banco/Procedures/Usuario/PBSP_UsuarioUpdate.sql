USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_UsuarioUpdate]    Script Date: 02/12/2021 14:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_UsuarioUpdate]
@login  nvarchar(9),
@gerente bit,
@senha nvarchar(20),
@idUsuario numeric(18, 0)

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atualizar usuario
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 15/10/2021
	Ex................: EXEC [dbo].[PBSP_UsuarioUpdate

	*/

	BEGIN;

	UPDATE [dbo].[usuario]
	SET [login]= @login, 
		[gerente]= @gerente, 
		[senha]= @senha
	WHERE [idUsuario] = @idUsuario;
		

	END;
