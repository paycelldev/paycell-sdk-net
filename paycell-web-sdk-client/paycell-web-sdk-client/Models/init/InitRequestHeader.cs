using paycell_web_sdk_client.Models.model;
using System;

namespace paycell_web_sdk_client.Models.init
{
    public class InitRequestHeader
    {

        /**
         * Merchant information
         */
        public Merchant Merchant { get; set; }

        /**
         * Transaction information
         */
        public TransactionInfo TransactionInfo { get; set; }

        /**
         * Merchant Application name, defined by Paycell Web SDK for each Merchant
         */
        public string ApplicationName { get; set; }

        /**
         * Merchant Application password, defined by Paycell Web SDK for each Merchant
         */
        public string ApplicationPassword { get; set; }
    }
}