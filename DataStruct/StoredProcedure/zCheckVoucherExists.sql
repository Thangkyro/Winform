create procedure zCheckVoucherExists
	@VoucherId int
AS
Begin
	select  top 1 VoucherID from zBillVoucher Where VoucherID = @VoucherID
end
