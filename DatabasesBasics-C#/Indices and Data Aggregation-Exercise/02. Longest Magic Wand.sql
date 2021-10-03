/*SELECT TOP(1) MagicWandSize AS LongestMagicWand
FROM WizzardDeposits
ORDER BY MagicWandSize DESC*/
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits 


