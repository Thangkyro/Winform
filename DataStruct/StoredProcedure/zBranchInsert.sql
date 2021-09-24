Alter PROC [dbo].[zBranchInsert]  
(  
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
@modified_at as datetime = getdate , 
 @Titlebranch NVARCHAR(MAX)= Null,
 @Imagebranch varbinary(MAX) = Null
, @ErrCode INT = 0  OUTPUT  
, @ErrMsg NVARCHAR(200) = ''  OUTPUT  
)  
AS  
  
-- Author: Auto winfred  
-- Created: 16 May 2021  
-- Function: Inserts a dbo.zBranch table record  
  
-- Modifications:  
  
begin try  
  
-- insert  
insert  [dbo].[zBranch] (BranchCode,BranchName,Located,PhoneNumber,Facebook,Email,website,SMSText,NumberBill,Noontime,Decriptions,is_inactive,created_by,created_at,modified_by,modified_at,Titlebranch,Imagebranch)  
values (@BranchCode,@BranchName,@Located,@PhoneNumber,@Facebook,@Email,@website,@SMSText,@NumberBill,@Noontime,@Decriptions,@is_inactive,@created_by,@created_at,@modified_by,@modified_at,@Titlebranch,@Imagebranch)  
  
  
-- Return the new ID  
end try  
  
begin catch  
  
 declare @ErrorSeverity INT;  
 declare @ErrorState INT;  
  
 select @ErrCode = ERROR_NUMBER();  
  
 select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();  
  
 raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);  
  
end catch;  
  
  