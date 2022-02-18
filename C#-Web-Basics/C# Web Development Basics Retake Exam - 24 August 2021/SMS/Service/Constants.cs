namespace SMS.Service
{
    public static class Constants
    {
        public const int DefautMaxValue = 20;
        public const int UsernameMinLenght = 5;
        public const int UserPasswordMinLenght = 6;
        public const string UserEmailVaidation = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int ProductMinValue = 4;
        public const decimal PriceMinValue = 0.05M;
        public const decimal PriceMaxValue = 1000M;
    }
}
