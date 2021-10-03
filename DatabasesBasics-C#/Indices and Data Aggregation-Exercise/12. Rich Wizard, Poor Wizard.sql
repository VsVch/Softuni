SELECT SUM(Guest.DepositAmount - Host.DepositAmount) AS [Difference]
FROM WizzardDeposits AS Host 
JOIN WizzardDeposits AS Guest ON Host.id = Guest.Id +1
