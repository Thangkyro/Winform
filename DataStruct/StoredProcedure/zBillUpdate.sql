USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillUpdate]    Script Date: 10/26/2021 9:21:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[zBillUpdate]
(
@BillID as int,
@branchId as int,
@PaymentCash as decimal,
@PaymentCard as decimal,
@PaymentVoucher as decimal,
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Kyro
-- Created: 13 June 2021
-- Function: Update bill master

-- Modifications:

begin try

-- update
update [dbo].[zBillMaster] WITH(ROWLOCK) 
	set
		--BillDate = coalesce(Getdate(), BillDate),
		Status = 'Complete',
		Timefinish = Getdate(),
		PaymentCash = coalesce(@PaymentCash, PaymentCash),
		PaymentCard = coalesce(@PaymentCard, PaymentCard),
		PaymentVoucher = coalesce(@PaymentVoucher, PaymentVoucher),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(Getdate(), modified_at)
where BillID  = @BillID  AND  branchId  = @branchId

INSERT INTO zbookingmaster_log(BookingDate,branchId,CustId,Service,Note,CreateDate,zTableName,zAction,CustomerPhone)  
	  SELECT  t.BillDate AS BookingDate,t.branchId,t.CustId,
			CAST((   SELECT  CAST(x.BillID AS VARCHAR(40)) AS  BillID,
						CAST(x.branchId AS VARCHAR(40)) AS  branchId,
						CAST(x.BillDate AS VARCHAR(40)) AS  BillDate,
						CAST(x.BillCode AS VARCHAR(40)) AS  BillCode,
						CAST(x.CustId AS VARCHAR(40)) AS  CustId,
						CAST(x.CustomerPhone AS VARCHAR(40)) AS  CustomerPhone,
						CAST(x.TotalEstimatePrice AS VARCHAR(40)) AS  TotalEstimatePrice,
						CAST(x.TotalEstimateTime AS VARCHAR(40)) AS  TotalEstimateTime,
						CAST(x.Status AS VARCHAR(40)) AS  Status,
						CAST(x.Timefinish AS VARCHAR(40)) AS  Timefinish,
						CAST(x.TotalDiscount AS VARCHAR(40)) AS  TotalDiscount,
						CAST(x.PaymentCash AS VARCHAR(40)) AS  PaymentCash,
						CAST(x.PaymentCard AS VARCHAR(40)) AS  PaymentCard,
						CAST(x.PaymentVoucher AS VARCHAR(40)) AS  PaymentVoucher,
						CAST(x.BookID AS VARCHAR(40)) AS  BookDTID,
						CAST(x.VoucherID AS VARCHAR(40)) AS  VoucherID,
						CAST(x.Decriptions AS VARCHAR(40)) AS  Decriptions,
						CAST(x.NumberBill AS VARCHAR(40)) AS  NumberBill,
						CAST(x.created_by AS VARCHAR(40)) AS  created_by,
						CAST(x.created_at AS VARCHAR(40)) AS  created_at,
						CAST(x.modified_by AS VARCHAR(40)) AS  modified_by,
						CAST(x.modified_at AS VARCHAR(40)) AS  modified_at
				FROM    [zBillMaster] AS x
				WHERE   x.BillID = t.BillID
				FOR XML PATH('row'), TYPE, ROOT('root')
			)AS NVARCHAR(MAX)) AS Service
			,t.BillID AS note
			,getdate() as CreateDate ,'zBillMaster' as zTableName,'UPDATE' as zAction, t.CustomerPhone
	FROM    [zBillMaster] AS t
	where BillID  = @BillID  AND  branchId  = @branchId
	GROUP BY t.CustId,t.BillDate,t.branchId,t.BillID, t.CustomerPhone;	

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


