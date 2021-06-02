CREATE TRIGGER [dbo].[UceniciPunoletni]
ON [dbo].[Ucenici]
FOR INSERT
AS 
BEGIN
    DECLARE @varchar AS varchar(50);
    DECLARE @Var INT
    SET @Var =  (SELECT COUNT(*) FROM Ucenici WHERE Godine < 10)
    IF(@Var > 0)
    BEGIN
        SET @varchar = 'Ne sme ucenik mladji od 10 godina '
        RAISERROR(@varchar,16,1)
    END
END