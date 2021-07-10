create procedure zCheckServiceExists
	@ServiceId int
AS
Begin
	select  top 1 ServiceId from  zBillDetail Where ServiceId = @ServiceId
end
