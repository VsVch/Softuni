namespace ValidationAttributes
{
    public interface IMyValidationAttribute
    {
        bool IsValid(object obj);
    }
}