
--[zBillDetailList_GetAll] '20210925','20210929','Staff',2
ALTER PROC [dbo].[zBillDetailList_GetAll]
(
@FromDate as datetime,
@ToDate as datetime,
@Group1 as varchar(100),
@BranchID as int
)
AS

IF(@Group1 = 'Staff')
BEGIN
	Select 
		 ROW_NUMBER() OVER(ORDER BY t.TotalAmount ASC) AS No,
		 IDHead,
		 StaffName,
		 TotalAmount
	From (
		Select 
		
		t3.StaffId AS IDHead,
		t2.Name as StaffName,
		CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) AS TotalAmount
		From  [dbo].[zBillMaster] t1 with(nolock)
			join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
			join [dbo].[zStaff] t2 with(nolock) on t3.StaffId = t2.StaffId
		Where (t1.branchId  = @branchId)
				AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
				AND Status = 'Complete'  
		GROUP BY t3.StaffId, t2.Name 
		--ORDER BY TotalAmount
	) t

END
ELSE
BEGIN
	Select 
		 ROW_NUMBER() OVER(ORDER BY t.TotalAmount ASC) AS No,
		 IDHead,
		 ServiceName,
		 TotalAmount
	From (
		Select 
		 ROW_NUMBER() OVER(ORDER BY t2.Title ASC) AS No,
		t3.ServiceID AS IDHead,
		t2.Title as ServiceName,
		CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) AS TotalAmount
		From  [dbo].[zBillMaster] t1 with(nolock)
			join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
			join [dbo].[zService] t2 with(nolock) on t3.ServiceID = t2.ServiceID
		Where (t1.branchId  = @branchId)
				AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
				AND Status = 'Complete'  
		GROUP BY t3.ServiceID, t2.Title 
		--ORDER BY TotalAmount
		) t
END



