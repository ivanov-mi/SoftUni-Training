--7.	Define Function
CREATE FUNCTION ufn_IsWordComprised (@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
	RETURNS BIT
	AS
	BEGIN
		DECLARE @IsComprised BIT = 0;
		DECLARE @Index INT = 1;

		WHILE (@Index <= LEN(@word))
		BEGIN
			SET @IsComprised = CHARINDEX(SUBSTRING(@word, @Index, 1), @setOfLetters)
			IF (@IsComprised = 0)
				RETURN @IsComprised
			
			SET @Index += 1
		END

	RETURN @IsComprised
	END