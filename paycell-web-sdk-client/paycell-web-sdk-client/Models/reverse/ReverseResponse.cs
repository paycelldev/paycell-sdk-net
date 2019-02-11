using paycell_web_sdk_client.Models.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.reverse
{
    public class ReverseResponse
    {
        /**
         * Header information of the response
         */
        public ResponseHeader ResponseHeader { get; set; }

        /**
         * Approval code information
         */
        public string ApprovalCode { get; set; }

        /**
         * Status code of the retry
         */
        public string RetryStatusCode { get; set; }

        /**
         * Description of the retry status
         */
        public string RetryStatusDescription { get; set; }

        /**
         * reconciliation date information
         * Format used: YYYYMMDD
         */
        public string ReconciliationDate { get; set; }
    }
}