SELECT * 
FROM Reports
WHERE CloseDate IS NULL

UPDATE Reports SET CloseDate = '2022-10-13' WHERE CloseDate IS NULL