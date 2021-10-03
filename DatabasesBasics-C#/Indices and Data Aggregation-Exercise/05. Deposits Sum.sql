/*SELECT DepositGroup,
	  SUM(Total)		
FROM (SELECT DepositGroup,
		SUM(DepositAmount) AS Total
	  FROM WizzardDeposits
	  GROUP BY DepositGroup ,DepositAmount) AS d
GROUP BY DepositGroup*/

SELECT DepositGroup, SUM(DepositAmount)
FROM WizzardDeposits
GROUP BY DepositGroup