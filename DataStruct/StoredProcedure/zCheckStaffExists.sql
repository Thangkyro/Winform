create procedure zCheckStaffExists
	@StaffId int
AS
Begin
	select  top 1 StaffId from  zBillDetail Where StaffId = @StaffId
end
