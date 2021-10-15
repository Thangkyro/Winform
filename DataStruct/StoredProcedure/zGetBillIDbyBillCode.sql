USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillDetailDelete_Ver1]    Script Date: 10/15/2021 10:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zGetBillIDbyBillCode]
(
 @BillCode   as varchar(100) = ''
, @branchId as int  = 0 
)
AS


-- Modifications:


	-- delete
	SELECT BillID
	FROM zBillMaster
	where branchId = @branchId   and BillCode= @BillCode
	



