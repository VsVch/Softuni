using System.ComponentModel.DataAnnotations;

namespace ASP.netCoreTreningApp.ValidationAttributes
{
    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            MinYear = minYear;
            this.ErrorMessage = $"Value should be between" +
                $" {minYear} and {DateTime.UtcNow.Year}";
        }

        public int MinYear { get; }

        public override bool IsValid(object? value)
        {
            if (value is int intValue
                && intValue >= MinYear)
            {
                if (intValue < DateTime.UtcNow.Year)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
