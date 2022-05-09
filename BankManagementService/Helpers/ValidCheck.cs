using System;
using System.Text.RegularExpressions;

namespace BankManagementMicroservice.Helpers
{
    public class ValidCheck 
    {
        public static bool IsValidEmail(string emailId)
        {
            bool isValid = Regex.IsMatch(emailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isValid;
        }     

        public static bool IsValidMobileNumber(string mobNumber)
        {
            bool isValid = Regex.IsMatch(mobNumber, @"^[6-9]\d{9}$", RegexOptions.IgnoreCase);
            return isValid;
        }
    }
}
