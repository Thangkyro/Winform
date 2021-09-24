alter PROC [dbo].[zBranchUpdate]  
(  
@branchId as int,  
@BranchCode as varchar(30),  
@BranchName as varchar(30),  
@Located as varchar(300) = Null,  
@PhoneNumber as varchar(100) = Null,  
@Facebook as varchar(100) = Null,  
@Email as varchar(100) = Null,  
@website as varchar(100) = Null,  
@SMSText as varchar(1000) = Null,  
@NumberBill as decimal = 0,  
@Noontime as decimal = 0,  
@Decriptions as varchar(2000) = '',  
@is_inactive as bit,  
@created_by as int = 0,  
@created_at as datetime = getdate,  
@modified_by as int = 0,  
@modified_at as datetime = getdate,  
 @Titlebranch NVARCHAR(MAX)= Null,
 @Imagebranch varbinary(MAX) = Null
, @ErrCode INT = 0  OUTPUT  
, @ErrMsg NVARCHAR(200) = ''  OUTPUT  
)  
AS  
  
-- Author: Auto winfred  
-- Created: 16 May 2021  
-- Function: Create or update a dbo.zBranch table record  
  
-- Modifications:  
  
begin try  
  
-- update  
update [dbo].[zBranch] WITH(ROWLOCK) set  
  BranchCode = coalesce(@BranchCode, BranchCode),  
  BranchName = coalesce(@BranchName, BranchName),  
  Located = coalesce(@Located, Located),  
  PhoneNumber = coalesce(@PhoneNumber, PhoneNumber),  
  Facebook = coalesce(@Facebook, Facebook),  
  Email = coalesce(@Email, Email),  
  website = coalesce(@website, website),  
  SMSText = coalesce(@SMSText, SMSText),  
  NumberBill = coalesce(@NumberBill, NumberBill),  
  Noontime = coalesce(@Noontime, Noontime),  
  Decriptions = coalesce(@Decriptions, Decriptions),  
  is_inactive = coalesce(@is_inactive, is_inactive),  
  created_by = coalesce(@created_by, created_by),  
  created_at = coalesce(@created_at, created_at),  
  modified_by = coalesce(@modified_by, modified_by),  
  modified_at = coalesce(@modified_at, modified_at)  ,  
  Titlebranch = coalesce(@Titlebranch, Titlebranch)  ,  
  Imagebranch = coalesce(@Imagebranch, Imagebranch)  
where branchId = @branchId  
  
end try  
  
begin catch  
  
 declare @ErrorSeverity INT;  
 declare @ErrorState INT;  
  
 select @ErrCode = ERROR_NUMBER();  
  
 select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();  
  
 raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);  
  
end catch;  
  
  