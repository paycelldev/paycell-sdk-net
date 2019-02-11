using System;

namespace paycell_web_sdk_client.Models.init
{
    public class McParameters
    {

        /**
         * Represents if the customer used Turkcell Hızlı Giriş
         * other properties are waited if the value represents true
         * "Y" for true
         * "N" for false
         */
        public string IsMcSession { get; set; }

        /**
         * Phone number of the customer without county code
         */
        public string McPhoneNumber { get; set; }

        /**
         * Country code of the customer phone number
         */
        public string McPhoneCountry { get; set; }

        /**
         * Turkcell Hızlı Giriş authorization token
         */
        public string McAuthToken { get; set; }
    }
}