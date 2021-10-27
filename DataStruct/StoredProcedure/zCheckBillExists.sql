USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zCheckBillExists]    Script Date: 10/27/2021 11:23:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[zCheckBillExists]  
 @BranchID int ,
 @PhoneNumber varchar(50),
 @Date date
AS  
Begin  
 select  1 
 from zBillMaster 
 Where branchId = @BranchID
	and CustomerPhone = @PhoneNumber
	and CAST(BillDate as date) = CAST(@Date as date)
	and Status = 'New'
end  
