
CREATE PROC [dbo].[zGetPercenPay]
(
@BranchId as int
)
AS

-- Modifications:

	Select 
		PercenPay
	FROM  [dbo].[zBranch] with(nolock)
	where  branchId = @BranchId  