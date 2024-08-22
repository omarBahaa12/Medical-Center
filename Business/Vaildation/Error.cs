using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Vaildation
{
    public static class Error
    {
        public static string Required => "Please This Field is Required";

        public static string EmailNotMatch => "The Email not match";
        public static string PhoneNumberNotMatch => "The PhoneNumber not match";

        public static string LessthanLimit(int min) => $"Out of Limit or Less than limit {min}";

        public static string OutofLimit(int Max) => $"Out of Limit or Less than limit {Max}";
    }
}
