namespace BusinessLayer.Common
{
    public static class StaticValidation
    {
        public static string Alpha = "^[a-zA-Z]*$";
        public static string AlphaNumberic = "";
        public static string Numeric = "^[0-9]*$";

        public static string Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        
    }
}
