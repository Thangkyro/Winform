/****** Object:  StoredProcedure [qidjefjs_Dev].[zBillPrint]    Script Date: 1/11/2022 3:41:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Kyro   
-- Create date: 03/06/2021  
-- Description: <Description,,>  
-- =============================================  
ALTER PROCEDURE [qidjefjs_Dev].[zBillPrint]  
 @BillId int,  
 @BranchID int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 SELECT   
  FORMAT(t0.BillDate , 'dd/MM/yyyy HH:mm:ss') as BillDate,  
  t0.BillCode,  
  t2.[Name] as CustomerName,  
  t0.CustomerPhone,  
  t1.OrderNumber,  
  t3.Title as ServiceName,  
  CAST(t1.Quantity AS INT) as Quantity,  
  CAST(t1.Price AS DECIMAL(17,2)) as Price,  
  CAST((t1.Quantity * t1.Price) AS DECIMAL(17,2)) as Amount,  
  ISNULL(t4.[Name],'') as StaffName ,  
  t1.Note,  
  t3.EstimateTime,  
  CASE WHEN t0.[Status] <> 'Complete' THEN 'Temporary bill' ELSE t0.[Status] END As [Status],  
  CAST(t1.Discount AS DECIMAL(17,2)) as TotalDiscount,  
  CAST(t0.PaymentCash AS DECIMAL(17,2)) as PaymentCash,  
  CAST(t0.PaymentCard AS DECIMAL(17,2)) as PaymentCard,  
  CAST(t0.PaymentVoucher AS DECIMAL(17,2)) as PaymentVoucher  ,
	t0.NumberBill,
	t0.Decriptions,
	t5.BranchName,
	t5.PhoneNumber as BranchPhoneNumber,
	t5.Located
 FROM dbo.[zBillMaster] t0 with(nolock)  
  join dbo.[zBillDetail] t1 with(nolock) on t0.branchId = t1.branchId and t0.BillID = t1.BillID  
  join dbo.[zCustomer] t2 with(nolock) on t0.CustId = t2.CustId  
  join dbo.[zService] t3 with(nolock) on t1.branchId = t3.branchId and t1.ServiceID = t3.ServiceID  
  Left join dbo.[zStaff] t4 with(nolock) on t1.StaffId = t4.StaffId  
  Left join dbo.[zBranch] t5 with(nolock) on t1.branchId = t5.branchId
 WHERE t0.branchId = @BranchID  
  And t0.BillID = @BillId  
END  
  