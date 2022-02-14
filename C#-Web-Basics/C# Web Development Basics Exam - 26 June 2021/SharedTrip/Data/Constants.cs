namespace SharedTrip.Data
{
    public static class Constants
    {
        
        public const int DefautMaxValue = 20;
        public const int UsernameMinLenght = 5;
        public const int UserPasswordMinLenght = 6;
        public const string UserEmailVaidation = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";


        public const int TripSeatsMaxValue = 6;
        public const int TripSeatsMinValue = 2;
        public const int TripDescriptionMaxValue = 80;
    }
}
