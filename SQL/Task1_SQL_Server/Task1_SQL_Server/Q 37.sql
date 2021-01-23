USE HealthMinister
GO

BEGIN TRY
	BEGIN TRANSACTION
		
		DECLARE @count AS INT = 0

		INSERT INTO dbo.FacilityType(Type) 
		VALUES('Facility8')
		SET @count += 1

		INSERT INTO dbo.FacilityType(Type) 
		VALUES('Facility9')
		SET @count += 1

		IF @count > 1
			THROW 50005, N'An error occurred', 1;
		ELSE
			PRINT 'transaction committed'

	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
