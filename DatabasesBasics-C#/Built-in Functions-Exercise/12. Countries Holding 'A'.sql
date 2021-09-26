SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE LOWER('%a%a%a%')
ORDER BY IsoCode