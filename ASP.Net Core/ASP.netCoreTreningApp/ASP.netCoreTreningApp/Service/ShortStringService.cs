namespace ASP.netCoreTreningApp.Service
{
    public class ShortStringService : IShortStringService
    {
        public string GetShort(string str, int maxLenght)
        {
            if (str == null)
            {
                return str;
            }

            if (str.Length <= maxLenght)
            {
                return str;
            }

            return str.Substring(0, maxLenght) + "...";
        }
    }
}
