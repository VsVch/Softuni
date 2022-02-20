namespace FootballManager.Data
{
    public static class Constants
    {
        public const int DefautMaxLength = 20;
        public const int DefautMinLength = 5;     
        public const string UserEmailVaidation = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";        
        public const int EmailMaxLength = 60;

        public const int FullNameMaxLength = 80;
        public const int DescriptionMaxLength = 200;
        public const int SpeedAndEnduranceMaxValue = 10;
        public const int SpeedAndEnduranceMinValue = 0;
    }
}
