using System;

namespace paycell_web_sdk_client.Models.init
{
    public class InitResponse
    {

        /**
         * Tracking information, is used for accessing to the payment screen of Paycell Web SDK
         */
        public string TrackingId { get; set; }

        /**
         * Status code of the request, is "0" if the operation was successful.
         */
        public string StatusCode { get; set; }

        /**
         * Status message of the request, is "Success" if the operation was successful.
         */
        public string Message { get; set; }
    }
}