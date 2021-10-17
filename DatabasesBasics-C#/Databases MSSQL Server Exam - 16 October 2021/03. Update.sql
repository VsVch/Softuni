SELECT *
FROM Cigars
WHERE TastId = 1

SELECT * FROM Tastes
WHERE TasteType = 'Spicy' -- 1

SELECT * 
FROM Brands
WHERE BrandDescription IS NULL

UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.2  WHERE TastId = 1

UPDATE Brands
SET BrandDescription ='New description'  WHERE BrandDescription IS NULL
