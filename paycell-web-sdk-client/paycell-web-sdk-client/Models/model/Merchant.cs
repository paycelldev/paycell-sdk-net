using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.model
{
    public class Merchant
    {
        public string MerchantCode { get; set; }

        /**
         * Terminal code, defined by Paycell Web SDK for each Merchant
         */
        public string TerminalCode { get; set; }

        /**
         * List of logo urls
         */
        public List<string> Logos { get; set; }
    }
}