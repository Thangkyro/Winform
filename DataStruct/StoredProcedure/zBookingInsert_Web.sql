CREATE PROC [dbo].[zBookingInsert_Web]  
(  
 @BookingDate as datetime,  
 @branchId as int,  
 @CustId as int,  
 @CustomerPhone as varchar(100),  
 @Service VARCHAR(MAX),  
 @UserId as int,  
 @Note as varchar(1000),  
 @ErrCode INT = 0 OUTPUT,  
 @ErrMsg NVARCHAR(200) = '' OUTPUT  
)  
AS  
  
-- Author: Auto Kyro  
-- Created: 27 May 2021  
-- Function: Inserts a dbo.zBookingMaster, zBookingDetail table record  
  
-- Modifications:  
/*Param's Explanation:  
 • @Service:  
  - @Service = '<ROOT>  
     <r ServiceID="1" EstimateTime="2.5000" EstimatePrice="50000.0000" />  
     <r ServiceID="2" EstimateTime="1.5000" EstimatePrice="40000.0000" />  
     <r ServiceID="3" EstimateTime="1.0000" EstimatePrice="30000.0000" />  
     <r ServiceID="4" EstimateTime="1.0000" EstimatePrice="20000.0000" />  
    </ROOT>'  
  
 */  
  
begin try  
   declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())


  IF @Service IS NULL OR @Service = '' 
 begin 
	 select @ErrCode = -4165;  
  select @ErrMsg = N'Services not exists.';
	 RETURN
 end       
   
 IF @CustId is null  
 BEGIN  
  SELECT @CustId = CustId FROM [dbo].[zCustomer] WITH(NOLOCK) WHERE (ISNULL(PhoneNumber1, '') = @CustomerPhone Or ISNULL(PhoneNumber2, '') = @CustomerPhone ) ORDER BY CustId DESC  
 END   
 IF @CustId is null  
 begin  
  select @ErrCode = -260597;  
  select @ErrMsg = N'Customer not exists.';  
  return
 end  
 DECLARE @zService TABLE (  
    ServiceID   INT  
  , EstimateTime  DECIMAL(19,4)  
  , EstimatePrice  DECIMAL(19,4)  
  )  
 --Parse XML   
 DECLARE @iDoc INT  
  
 EXEC sp_xml_preparedocument @iDoc OUTPUT  
  , @Service  
  
 INSERT @zService (ServiceID,EstimateTime,EstimatePrice)  
 SELECT ServiceID,EstimateTime,EstimatePrice  
 FROM OPENXML(@iDoc, '/ROOT/r', 1) WITH (  
   ServiceID   INT  
   , EstimateTime  DECIMAL(19,4)  
   , EstimatePrice  DECIMAL(19,4)  
   )  
 EXEC sp_xml_removedocument @iDoc  
 -- Get the ID Booking  
 Declare @IdBooking as int  
-- Check exists Booking.  
 if NOT EXISTS (  
  SELECT TOP 1  1  
  FROM [dbo].[zBookingMaster]  WITH(NOLOCK)  
  WHERE [branchId] =  @branchId and CAST([BookingDate] AS DATE) = CAST(@BookingDate AS DATE)  
   and [CustId] = @CustId and [Status] = 'Temporary' )  
 BEGIN  
  -- insert master  
  INSERT INTO [dbo].[zBookingMaster]  
           ([branchId]  
           ,[BookingDate]  
           ,[CustId]  
           ,[CustomerPhone]  
           ,[TotalEstimatePrice]  
           ,[TotalEstimateTime]  
           ,[StaffRequire]  
           ,[Status]  
           ,[Decriptions]  
           ,[created_by]  
           ,[created_at]  
           ,[modified_by]  
           ,[modified_at])  
   SELECT  
           @branchId AS [branchId]  
           ,@BookingDate AS [BookingDate]  
           ,@CustId AS [CustId]  
           ,@CustomerPhone AS [CustomerPhone]  
           ,SUM(EstimatePrice) AS EstimatePrice -- TotalEstimatePrice  
           ,SUM(EstimateTime) AS EstimateTime -- TotalEstimateTime  
           ,0 -- StaffRequire  
           ,'Temporary' AS [Status]  
           ,@Note AS [Decriptions]  
           ,@UserId AS [created_by]  
           ,@DateZone AS [created_at]  
           ,@UserId AS [modified_by]  
           ,@DateZone AS [modified_at]  
          FROM  @zService  
       SET @IdBooking = SCOPE_IDENTITY()  
 END  
 ELSE  
 BEGIN  
  SELECT @IdBooking = BookID   
  FROM [dbo].[zBookingMaster] with(nolock)  
  WHERE [branchId] =  @branchId   
   and CAST([BookingDate] as date) = CAST(@BookingDate as date)  
   and [CustId] = @CustId and [Status] = 'Temporary'  
 END  
   
 Delete [dbo].[zBookingDetail] Where branchId = @branchId AND BookID = @IdBooking  
 -- insert detail  
 INSERT INTO [dbo].[zBookingDetail]  
    ([BookID]  
    ,[OrderNumber]  
    ,[branchId]  
    ,[ServiceID]  
    ,[Quantity]  
    ,[EstimatePrice]  
    ,[EstimateTime]  
    ,[Note]  
    ,[StaffId]  
    ,[created_by]  
    ,[created_at])  
  SELECT  
    @IdBooking  
    ,ROW_NUMBER() OVER ( ORDER BY ServiceID) [OrderNumber]  
    ,@branchId  
    ,ServiceID  
    ,1 AS Quantity  
    ,EstimatePrice  
    ,EstimateTime  
    ,@Note  
    ,0 AS StaffId  
    ,@UserId  
    ,@DateZone  
  FROM  @zService  
   
end try  
  
begin catch  
 Delete [dbo].[zBookingDetail] Where branchId = @branchId AND [BookID] = @IdBooking  
 Delete [dbo].[zBookingMaster] Where branchId = @branchId AND [BookID] = @IdBooking  
 declare @ErrorSeverity INT;  
 declare @ErrorState INT;  
  
 select @ErrCode = ERROR_NUMBER();  
  
 select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();  
  
 raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);  
  
end catch;  
  
  
