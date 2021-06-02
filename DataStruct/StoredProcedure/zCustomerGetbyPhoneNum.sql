USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zCustomerGetList]    Script Date: 30/05/2021 5:25:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zCustomerGetbyPhoneNum]
(
	@PhoneNumber as nvarchar(50)
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zCustomer table record

-- Modifications:

	Select 
		CustId,
		branchId,
		CustomerCode,
		Name,
		Gender,
		PhoneNumber1,
		PhoneSimple1,
		PhoneNumber2,
		PhoneSimple2,
		DateOfBirth,
		PostCode,
		IsMerge,
		CustIdMerge,
		Decriptions,
		is_inactive,
		created_by,
		created_at,
		modified_by,
		modified_at
 FROM  [dbo].[zCustomer] with(nolock)
	where (PhoneNumber1 = @PhoneNumber OR PhoneNumber2 = @PhoneNumber )


