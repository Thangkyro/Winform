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
Imagebranch 
 FROM  [dbo].[zBranch] with(nolock)  
 where (branchId = @branchId OR @branchId = 0 )  
  
  