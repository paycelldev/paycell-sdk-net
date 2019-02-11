using System;

namespace paycell_web_sdk_client.Models.model
{
    public class RequestHeader
    {
        public string TransactionId { get; set; }

        /**
         * Format used: YYYYMMddHHmmssSSS
         */
        public string TransactionDateTime { get; set; }

        /**
         * IP address of the requester
         */
        public string ClientIPAddress { get; set; }

        /**
         * Application name: defined by Paycell Web SDK for each merchant
         */
        public string ApplicationName { get; set; }

        /**
         * Application password: defined by Paycell Web SDK for each merchant
         */
        public string ApplicationPwd { get; set; }
    }
}