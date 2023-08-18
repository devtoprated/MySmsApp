using Microsoft.Extensions.Primitives;
using Twilio.Rest.Lookups.V2;

namespace MySmsApp.Twilio.HelperMethods
{
    public static class PhoneNumberHelper
    {
        public async static Task<string> GetNumberWithoutCode(string from)
        {
            var phone = await PhoneNumberResource.FetchAsync(pathPhoneNumber: from);
            return phone.NationalFormat.ToString();
        }
    }
}
