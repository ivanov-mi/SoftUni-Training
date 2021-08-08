namespace VaporStore
{
    public class GlobalConstants
    {
        //Game
        public const string GameMinPrice = "0";
        public const string GameMaxPrice = "79228162514264337593543950335";

        //User
        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 20;
        public const int UserMinAge = 3;
        public const int UserMaxAge = 103;
        public const string FullNameRegEx = @"[A-Z][a-z]* [A-Z][a-z]*";

        //Card
        public const int CardNumberMaxLength = 19;
        public const string CardNumberRegEx = @"([0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4})";
        public const int CVCNumberMaxLength = 3;
        public const string CardCVCRegEx = @"[0-9]{3}";

        //Purchase
        public const int ProductKeyMaxLength = 15;
        public const string ProductKeyRegEx = @"([A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4})";
    }
}
