
/****** Object:  StoredProcedure [dbo].[zBranchGetList]    Script Date: 7/6/2022 9:39:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBranchGetList]  
(  
@branchId as int  
)  
AS  
  
-- Author: Auto winfred  
-- Created: 16 May 2021  
-- Function: select a zBranch table record  
  
-- Modifications:  
  
 Select   
 branchId,  
 BranchCode,  
 BranchName,  
 Located,  
 PhoneNumber,  
 Facebook,  
 Email,  
 website,  
 SMSText,  
 NumberBill,  
 Noontime,  
 Decriptions,  
 is_inactive,  
 created_by,  
 created_at,  
 modified_by,  
 modified_at ,
 Titlebranch,
Imagebranch ,
zIsSendMassage
 FROM  [dbo].[zBranch] with(nolock)  
 where (branchId = @branchId OR @branchId = 0 )  
  
  
