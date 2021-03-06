CREATE PROC [dbo].[zBillInsert_FromBooking]  
(  
@bookID as int,  
@branchId as int,  
@userId as int,  
@billDate as datetime,  
@billCode as nvarchar(100),  
@BillNumber as int,  
@ErrCode INT = 0 OUTPUT,  
@ErrMsg NVARCHAR(200) = '' OUTPUT  
)  
AS  
  
begin try  
  declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

 Declare @CustId as int  
 Declare @idBillMaster as int  
 SELECT @CustId = t1.CustId   
 FROM [dbo].[zCustomer]  t1 with(nolock)  
  join [dbo].[zBookingMaster] t2 with(nolock) on t1.[CustId] = t2.[CustId]  
 WHERE t2.[BookID] = @bookID  
  
 if @CustId is null  
 begin  
  select @ErrCode = -260597;  
  select @ErrMsg = N'Customer not exists.';  
  return;  
 end  
-- Check exists bill.  
 if not exists (  
  Select 1   
  from [dbo].[zBillMaster]  with(nolock)  
  where [branchId] =  @branchId and CAST([BillDate] as date) = CAST(@billDate as date)  
   and [CustId] = @CustId and [Status] = 'New' )  
  begin  
   -- insert master  
   INSERT INTO [dbo].[zBillMaster]  
      ([branchId]  
      ,[BillDate]  
      ,[BillCode]  
      ,[CustId]  
      ,[CustomerPhone]  
      ,[TotalEstimatePrice]  
      ,[TotalEstimateTime]  
      ,[StaffRequire]  
      ,[Status]  
      ,[BookID]  
      ,[VoucherID]  
      ,[Decriptions]  
      ,[created_by]  
      ,[created_at]  
      ,[modified_by]  
      ,[modified_at]  
      ,[NumberBill])  
    select   
    @branchId  
      ,@billDate  
      ,@billCode  
      ,@CustId  
      ,[CustomerPhone]  
      ,[TotalEstimatePrice]  
      ,[TotalEstimateTime]  
      ,[StaffRequire]  
      ,'New'  
      ,@BookID  
      , null  
      ,[Decriptions]  
    ,@UserId  
      ,@DateZone  
      ,@UserId  
      ,@DateZone  
      ,@BillNumber  
    from [dbo].[zBookingMaster]  
    where BookID  = @BookID    
    AND branchId = @branchId;  
  
   --Check success insert detail  
   if(@@ROWCOUNT>0) -- success  
    begin  
     -- update bill number for zBranch  
     update zbranch set NumberBill = @BillNumber + 1 where branchId = @branchId  
     set @idBillMaster = SCOPE_IDENTITY();  
  
     -- create table temp  
      select  *  
      into #ListDetail  
      from [dbo].[zBookingDetail] with(nolock)  
      where BookID  = @BookID   
  
     DECLARE @ServiceIDDetail int  
     DECLARE @QtyDetail int  
     DECLARE @OrderNumber int = 0  
     DECLARE the_cursor CURSOR FAST_FORWARD  
     FOR  
                    SELECT  ServiceID, Quantity   
                    FROM    #ListDetail;  
  
     OPEN the_cursor;  
     FETCH NEXT FROM the_cursor INTO @ServiceIDDetail, @QtyDetail ;  
      
     WHILE @@FETCH_STATUS = 0  
                    BEGIN  
      if (@QtyDetail > 1)  
       begin  
        declare @cnt INT = 0  
        while @cnt < @QtyDetail  
        begin  
           set @cnt = @cnt + 1;  
           set @OrderNumber = @OrderNumber + 1;  
           -- insert detail  
         insert into [dbo].[zBillDetail]  
            ([BillID]  
            ,[OrderNumber]  
            ,[branchId]  
            ,[ServiceID]  
            ,[Quantity]  
            ,[Price]  
            ,[Discount]  
            ,[Payment]  
            ,[BookID]  
            ,[BookDTID]  
            ,[Note]  
            ,[StaffId]  
            ,[created_by]  
            ,[created_at])  
         select  
          @idBillMaster  
          ,@OrderNumber  
          ,[branchId]  
          ,[ServiceID]  
          ,1  
          ,[EstimatePrice]  
          , 0  
          , [EstimatePrice]  
          ,@BookID  
          ,[BookDTID]  
          ,[Note]  
          ,[StaffId]  
          ,@UserId  
          ,@DateZone 
         from [dbo].[zBookingDetail]  
         where BookID  = @BookID   
          and serviceid = @ServiceIDDetail  
        end  
       end  
      else  
       begin  
        set @OrderNumber = @OrderNumber + 1;  
        -- insert detail  
        insert into [dbo].[zBillDetail]  
           ([BillID]  
           ,[OrderNumber]  
           ,[branchId]  
           ,[ServiceID]  
           ,[Quantity]  
           ,[Price]  
           ,[Discount]  
           ,[Payment]  
           ,[BookID]  
           ,[BookDTID]  
           ,[Note]  
         ,[StaffId]  
           ,[created_by]  
           ,[created_at])  
        select  
         @idBillMaster  
         ,@OrderNumber  
         ,[branchId]  
         ,[ServiceID]  
         ,[Quantity]  
         ,[EstimatePrice]  
         , 0  
         , [EstimatePrice]  
         ,@BookID  
         ,[BookDTID]  
         ,[Note]  
         ,[StaffId]  
         ,@UserId  
         ,@DateZone 
        from [dbo].[zBookingDetail]  
        where BookID  = @BookID   
         and serviceid = @ServiceIDDetail  
       end  
  
      FETCH NEXT FROM the_cursor INTO @ServiceIDDetail, @QtyDetail ;  
     END  
     CLOSE the_cursor;  
     DEALLOCATE the_cursor;  
  
    end  
  end  
 else  
  begin  
   select @ErrCode = -260000;  
   select @ErrMsg = N'Exists bill of customer unpaid.';  
   return;  
  end  
end try  
  
begin catch  
  
 declare @ErrorSeverity INT;  
 declare @ErrorState INT;  
  
 select @ErrCode = ERROR_NUMBER();  
  
 select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();  
  
 raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);  
  
end catch;  
  
  
