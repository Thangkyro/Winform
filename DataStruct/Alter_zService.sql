alter table zService
add is_discount bit null

GO

update zService set is_discount = 0