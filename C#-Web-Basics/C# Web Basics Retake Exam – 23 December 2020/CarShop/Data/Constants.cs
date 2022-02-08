namespace CarShop.Data
{
    public static class Constants
    {
        public const int UserMaxLenght = 20;
        public const int UsernameMinLenght = 4;
        public const int UserPasswordMinLenght = 5;
        public const string UserEmailVaidation = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserTypeMechanic = "Mechanic";
        public const string UserTypeClient = "Client";
          
        public const int CarModelMaxLenght = 20;
        public const int CarModelMinLenght = 5;
        public const int YearMinValue = 1900;
        public const string plateNumberRegex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";

        public const int IssueMinDescription = 5;
    }
}
