USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterGetList_AllTemporaty]    Script Date: 10/23/2021 11:12:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[zBillMasterGetList_AllTemporaty]  
(  
@branchId as int  
)  
AS  
  
-- Author: Auto winfred  
-- Created: 16 May 2021  
-- Function: select a zBillMaster table record  
  
-- Modifications:  
  
 Select   
 BillID,  
 branchId,  
 BillDate,  
 BillCode,  
 CustId,  
 CustomerPhone,  
 TotalEstimatePrice,  
 TotalEstimateTime,  
 StaffRequire,  
 Status,  
 Timefinish,  
 TotalDiscount,  
 PaymentCash,  
 PaymentCard,  
 PaymentVoucher,  
 BookID,  
 VoucherID,  
 Decriptions,  
 created_by,  
 created_at,  
 modified_by,  
 modified_at,  
 Cast(NumberBill as INT ) as NumberBill,
 CONVERT(DATE, BillDate, 103) as FilterDate
 FROM  [dbo].[zBillMaster] with(nolock)  
 where branchId  = @branchId  
  AND Status = 'New'  

