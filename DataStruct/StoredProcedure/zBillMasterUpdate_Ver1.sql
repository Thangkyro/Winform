USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterUpdate_Ver1]    Script Date: 10/29/2021 10:58:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[zBillMasterUpdate_Ver1]
(
@BillID as int,
@branchId as int,
@Decriptions as varchar(2000),
@Date as datetime
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS
-- Modifications:

begin try

declare @billDate datetime
select @billDate = BillDate from [dbo].[zBillMaster] where BillID  = @BillID  AND  branchId  = @branchId

-- update
update [dbo].[zBillMaster] set
		Decriptions = coalesce(@Decriptions, Decriptions),
		BillDate = @Date
where BillID  = @BillID  AND  branchId  = @branchId

-- update bill number
if cast(@Date as date) <> cast(@billDate as date)
begin
	update [dbo].[zBillMaster] 
	set
		NumberBill = (select ISNULL(Max(NumberBill),0) + 1 from [dbo].[zBillMaster] Where cast(BillDate as date)  = cast(@Date as date)  AND  branchId  = @branchId)
	where BillID  = @BillID  AND  branchId  = @branchId

end
--else
--begin
--	declare @BranchNum int
--	declare @BillNum int
--	select @BranchNum = NumberBill from [dbo].[zBranch] Where branchId  = @branchId
--	select @BillNum = NumberBill from [dbo].[zBillMaster] Where BillID  = @BillID  AND  branchId  = @branchId

--	if @BranchNum <> @BillNum + 1
--	begin
--		update [dbo].[zBillMaster] 
--		set
--			NumberBill = @BranchNum
--		where BillID  = @BillID  AND  branchId  = @branchId

--		update [dbo].[zBranch] 
--		set NumberBill = NumberBill + 1
--		Where branchId  = @branchId
--	end
--end

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


