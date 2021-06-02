CREATE FUNCTION StarijiPunoletniciZaposleni()
RETURNS DECIMAL
AS
	BEGIN
		DECLARE @Cursor INT
		SET @Cursor = 0

		WHILE @Cursor<(SELECT COUNT(*) FROM Zaposlenis WHERE Zaposlenis.Godine > 20)
		BEGIN
			SET @Cursor = @Cursor + 1
		END
		RETURN @Cursor
	END

declare @n int
exec @n = [dbo].[StarijiPunoletniciZaposleni];
select @n

