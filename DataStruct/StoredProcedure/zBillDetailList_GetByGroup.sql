

--[zBillDetailList_GetByGroup] '20210925','20210929','','Date','','20210925', 2, 'List'
ALTER PROC [dbo].[zBillDetailList_GetByGroup]
(
@FromDate as datetime,
@ToDate as datetime,
@Group1 as nvarchar(100),
@Group2 as nvarchar(100),
@ParamQuery1 as nvarchar(50),
@ParamQuery as nvarchar(50),
@BranchID as int,
@LoadFor as nvarchar(20)
)
AS
IF (@LoadFor = 'List')
BEGIN

	Select 
	 ROW_NUMBER() OVER(ORDER BY CAST(t1.BillDate AS DATE), t2.Title ASC) AS No,
	FORMAT(CAST(t1.BillDate AS DATE),'dd/MM/yyyy') as BillDate,
	t2.Title as ServiceName,
	SUM(t3.Quantity) AS Quantity,
	t3.Price,
	CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) AS TotalAmount
	--SUM(t3.Quantity * t3.Price) as TotalAmount
	From  [dbo].[zBillMaster] t1 with(nolock)
		join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
		join [dbo].[zService] t2 with(nolock) on t3.ServiceID = t2.ServiceID
	Where  (t1.branchId  = @branchId)
			AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
			AND (
					(ISNULL(@Group2,'') = 'Staff' AND t3.StaffID = CAST(@ParamQuery AS INT) )
				OR (ISNULL(@Group2,'') = 'Service' AND t3.ServiceID = CAST(@ParamQuery AS INT) )
				OR (ISNULL(@Group2,'') = 'Date' AND CAST(t1.BillDate AS DATE) = (CASE WHEN TRY_CAST(@ParamQuery AS DATE) IS NULL THEN CAST(t1.BillDate AS DATE) ELSE CAST(@ParamQuery AS DATE) END ) )
				OR (ISNULL(@Group2,'') = '' AND 1 = 1)
			)
			AND (
					(ISNULL(@Group1,'') = 'Staff' AND ( ISNULL(@ParamQuery1,'') = '' OR t3.StaffID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = 'Service' AND (ISNULL(@ParamQuery1,'') = '' OR t3.ServiceID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = '' AND 1 = 1 )
			)
			AND t1.Status = 'Complete'  
	GROUP BY CAST(t1.BillDate AS DATE), t2.Title, t3.Price,t2.ServiceID
	Order by CAST(t1.BillDate AS DATE), t2.Title ASC
END
ELSE
BEGIN
	IF(@Group2 = 'Service') --Load list service
	BEGIN
		Select 
		 ROW_NUMBER() OVER(ORDER BY t2.Title ASC) AS No,
		t3.ServiceID,
		t2.Title as ServiceName,
		--SUM(t3.Quantity * t3.Price) as TotalAmount
		CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) AS TotalAmount
		From  [dbo].[zBillMaster] t1 with(nolock)
			join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
			join [dbo].[zService] t2 with(nolock) on t3.ServiceID = t2.ServiceID
		Where (t1.branchId  = @branchId)
				AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
				AND Status = 'Complete'  
				AND (
					(ISNULL(@Group1,'') = 'Staff' AND ( ISNULL(@ParamQuery1,'') = '' OR t3.StaffID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = 'Service' AND (ISNULL(@ParamQuery1,'') = '' OR t3.ServiceID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = '' AND 1 = 1 )
			)
		GROUP BY t3.ServiceID, t2.Title 
	END
	ELSE IF(@Group2 = 'Staff') -- Load list Staff
	BEGIN
		Select 
		 ROW_NUMBER() OVER(ORDER BY t2.Name ASC) AS No,
		t3.StaffId,
		t2.Name as StaffName,
		CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) AS TotalAmount
		--SUM(t3.Quantity * t3.Price) as TotalAmount
		From  [dbo].[zBillMaster] t1 with(nolock)
			join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
			left join [dbo].[zStaff] t2 with(nolock) on t3.StaffId = t2.StaffId
		Where (t1.branchId  = @branchId)
				AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
				AND Status = 'Complete' 
				AND (
					(ISNULL(@Group1,'') = 'Staff' AND ( ISNULL(@ParamQuery1,'') = '' OR t3.StaffID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = 'Service' AND (ISNULL(@ParamQuery1,'') = '' OR t3.ServiceID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = '' AND 1 = 1 )
			)
		GROUP BY t3.StaffId, t2.Name 
	END
	ELSE IF(@Group2 = 'Date')-- Load list Date
	BEGIN
		Select 
		 ROW_NUMBER() OVER(ORDER BY CAST(t1.BillDate AS DATE) ASC) AS No,
		FORMAT(CAST(t1.BillDate AS DATE),'dd/MM/yyyy') as BillDate,
		CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) AS TotalAmount
		--SUM(t3.Quantity * t3.Price) as TotalAmount
		From  [dbo].[zBillMaster] t1 with(nolock)
			join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
		Where (t1.branchId  = @branchId)
				AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
				AND Status = 'Complete'  
				AND (
					(ISNULL(@Group1,'') = 'Staff' AND ( ISNULL(@ParamQuery1,'') = '' OR t3.StaffID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = 'Service' AND (ISNULL(@ParamQuery1,'') = '' OR t3.ServiceID = CAST(@ParamQuery1 AS INT)) )
				OR (ISNULL(@Group1,'') = '' AND 1 = 1 )
			)
		GROUP BY CAST(t1.BillDate AS DATE)
	END

END


