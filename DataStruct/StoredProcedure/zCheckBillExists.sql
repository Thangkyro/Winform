USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zCheckStaffExists]    Script Date: 10/17/2021 9:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[zCheckBillExists]  
 @BranchID int ,
 @PhoneNumber varchar(50)
AS  
Begin  
 select  1 
 from zBillMaster 
 Where branchId = @BranchID
	and CustomerPhone = @PhoneNumber
	and CAST(BillDate as date) = CAST(GETDATE() as date)
end  


select * from zBillMaster