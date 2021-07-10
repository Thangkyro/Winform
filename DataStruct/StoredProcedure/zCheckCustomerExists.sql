create procedure zCheckCustomerExists
	@CustomerId int
AS
Begin
	select  top 1 CustId from  zBillMaster Where CustId = @CustomerId
end
