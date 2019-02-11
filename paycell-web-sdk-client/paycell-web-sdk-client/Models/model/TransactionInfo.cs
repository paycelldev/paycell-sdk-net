using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.model
{
    public class TransactionInfo
    {
        /**
         * Service request date time
         * yyyyMMddHHmmssSSS format is used
         */
        public string TransactionDateTime { get; set; }

        /**
         * Unique id for service request
         * must consist of 20 digits
         */
        public string TransactionId { get; set; }
    }
}
