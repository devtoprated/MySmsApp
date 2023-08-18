namespace CommonService
{
    public class StringHelper
    {
        public static string GetDigitsFromPhoneNumber(string number)
        {
            try
            {
                string newstring = new string(number.Where(char.IsDigit).ToArray());
                var t =  newstring.Substring(newstring.Length - 10, 10);
                return t;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }
    }
}