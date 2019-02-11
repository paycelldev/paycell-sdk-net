using paycell_web_sdk_client.Models.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.refund
{
    public class RefundResponse
    {

        /**
         * Header information
         */
        public ResponseHeader ResponseHeader { get; set; }

        /**
         * Reconciliation date information,
         * format used: yyyyMMdd
         */
        public string ReconciliationDate { get; set; }

        /**
         * Approval code information
         */
        public string ApprovalCode { get; set; }

        /**
         * Status code of retry
         */
        public string RetryStatusCode { get; set; }

        /**
         * Description of retry status
         */
        public string RetryStatusDescription { get; set; }
    }
}