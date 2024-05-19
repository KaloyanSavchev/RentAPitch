using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RentAPitch.Data.Models.Constants
{

    public class EntityConstants
    {
        public const string DeffPass = "123456";

        public static class PitchConstants
        {
            public const int PitchNameMaxLength = 70;
            public const int LocationMaxLength = 70;
            public const int DescriptionMaxLength = 500;
            public const int PriceForDayMaxValue = 1000;
        } 

        public static class UserConstants
        {
            public const int UserNameMaxLength = 50;
            public const int PhoneNumberMaxLenght = 10;
        }
    }
}
