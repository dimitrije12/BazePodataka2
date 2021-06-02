ALTER PROCEDURE UceniciUGradu
(@PB INT,
@UkupnoUcenika INT OUT) as

BEGIN TRY
	SELECT @UkupnoUcenika = COUNT(*)
	FROM Zivis
	INNER JOIN Gradovi ON Gradovi.PostanskiBroj = Zivis.GradPostanskiBroj
	INNER JOIN Ucenici on Ucenici.JMBG_U = Zivis.UcenikJMBG_U
	WHERE Zivis.GradPostanskiBroj = @PB
	
END TRY

BEGIN CATCH
	 SELECT
        ERROR_MESSAGE() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

DECLARE @Ret INT
EXEC UceniciUGradu 21000, @UkupnoUcenika = @Ret out
SELECT @Ret



