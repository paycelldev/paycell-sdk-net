using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.model
{
    public class ResponseHeader
    {

        /**
         * Unique id of the transaction
         * Must consist of 20 digits
         */
        public string TransactionId { get; set; }

        /**
         * Date time of the response
         * Format used: YYYYMMddHHmmssSSS
         */
        public string ResponseDateTime { get; set; }

        /**
         * Result code of the response
         * "0" if it is success
         */
        public string ResponseCode { get; set; }

        /**
         * Description of the response code
         */
        public string ResponseDescription { get; set; }
    }
}