CREATE PROCEDURE UceniciUSkoli
(@REGBr INT,
@UkupnoUcenika INT OUT) as

BEGIN TRY
	SELECT @UkupnoUcenika = COUNT(*)
	FROM Pohadjas
	INNER JOIN Ucenici ON Ucenici.JMBG_U = Pohadjas.UcenikJMBG_U
	INNER JOIN PrivatneSkole ON PrivatneSkole.RegBroj = Pohadjas.PrivatnaSkolaRegBroj
	WHERE Pohadjas.PrivatnaSkolaRegBroj = @REGBr
END TRY

BEGIN CATCH
	 SELECT
        ERROR_MESSAGE() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

DECLARE @Ret INT
EXEC UceniciUSkoli 1, @UkupnoUcenika = @Ret out
SELECT @Ret
