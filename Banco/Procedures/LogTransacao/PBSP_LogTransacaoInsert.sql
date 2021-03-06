USE [bdItau]
GO
/****** Object:  StoredProcedure [dbo].[PBSP_LogTransacaoInsert]    Script Date: 02/12/2021 13:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PBSP_LogTransacaoInsert]
@idTrans numeric (18,0),
@idConta numeric(18,0),
@idCliente numeric(18,0),
@valorTrans numeric(18,2),
@dataTrans date
	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Luciano Queiroz
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PBSP_LogTransacaoInsert]

	*/

	BEGIN;

	INSERT INTO [dbo].[logTransacao]
           ([idTrans]
		   ,[idConta]
           ,[idCliente]
           ,[valorTrans]
           ,[dataTrans])
     VALUES
           (@idTrans,
		   @idConta,
		   @idCliente,
		   @valorTrans,
		   @dataTrans);

		

	END;