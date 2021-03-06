
-- =============================================  
-- Author:  Kyro   
-- Create date: 03/06/2021  
-- Description: <Description,,>  
-- =============================================  
ALTER PROCEDURE [dbo].[zBillPrint]  
 @BillId int,  
 @BranchID int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 Declare @timeAdd int
 Set @timeAdd  = (Select ISNULL(Value,0) from zConfig)

 SELECT   
  --FORMAT(t0.BillDate , 'dd/MM/yyyy HH:mm:ss') as BillDate,  
  FORMAT(dateadd(hour,@timeAdd,t0.Timefinish) , 'dd/MM/yyyy HH:mm:ss') as BillDate,  
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
	t0.Decriptions
 FROM dbo.[zBillMaster] t0 with(nolock)  
  join dbo.[zBillDetail] t1 with(nolock) on t0.branchId = t1.branchId and t0.BillID = t1.BillID  
  join dbo.[zCustomer] t2 with(nolock) on t0.CustId = t2.CustId  
  join dbo.[zService] t3 with(nolock) on t1.branchId = t3.branchId and t1.ServiceID = t3.ServiceID  
  Left join dbo.[zStaff] t4 with(nolock) on t1.StaffId = t4.StaffId  
 WHERE t0.branchId = @BranchID  
  And t0.BillID = @BillId  
END  
  
