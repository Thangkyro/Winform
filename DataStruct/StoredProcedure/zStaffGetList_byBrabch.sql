USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zStaffGetList]    Script Date: 23/05/2021 10:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zStaffGetList_byBrabch]
(
@branchId as int
)
AS

-- Author: Kyro
-- Created: 16 May 2021
-- Function: select a zStaff table record

-- Modifications:

	Select 
	branchId,
	StaffCode,
	Name,
	Gender,
	CONCAT(Name + ' - ', Gender) as Display,
	PhoneNumber1,
	PhoneSimple1,
	PhoneNumber2,
	PhoneSimple2,
	DateOfBirth,
	TFN,
	AcountNumber,
	BSB,
	Decriptions,
	is_inactive,
	created_by,
	created_at,
	modified_by,
	modified_at
 FROM  [dbo].[zStaff] with(nolock)
	where (branchId = @branchId And is_inactive = 0 )


