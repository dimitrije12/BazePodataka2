USE [BP2P]
GO
/** Object:  UserDefinedFunction [dbo].[fnVratiNullBr]    Script Date: 6/2/2021 8:39:16 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[BROJCistacica]
    (

    )
RETURNS INT
AS
BEGIN 
    DECLARE @Cursor INT
    SET @Cursor = 0

    WHILE @Cursor < (SELECT COUNT(*) FROM dbo.Cistis WHERE SpremacicaJMBG_R  IS NOT NULL)
    BEGIN
        SET @Cursor = @Cursor + 1
    END
    RETURN @Cursor
END

declare @n int
exec @n = [dbo].[BROJCistacica];
select @n
