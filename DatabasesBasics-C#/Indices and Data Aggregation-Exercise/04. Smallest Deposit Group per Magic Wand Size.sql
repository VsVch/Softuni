/*SELECT TOP(2) d.DepositGroup
FROM (SELECT AVG(MagicWandSize) AS m,
			DepositGroup
		FROM WizzardDeposits 
		GROUP BY DepositGroup) AS d
ORDER BY m ASC*/
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
