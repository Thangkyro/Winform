CREATE FUNCTION [dbo].[ufn_SeperateStringByDelimiter] 
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) 
) 
RETURNS @output TABLE(position int, splitdata NVARCHAR(500) 
) 
BEGIN 
    DECLARE @start INT, @end INT, @idx INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string), @idx = 1 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (position,splitdata)  
        VALUES(@idx,SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        SET @idx = @idx + 1
    END 
    RETURN 
END

