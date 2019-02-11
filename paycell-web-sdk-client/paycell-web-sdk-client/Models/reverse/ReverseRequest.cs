using paycell_web_sdk_client.Models.model;
using System;

namespace paycell_web_sdk_client.Models.reverse
{
    public class ReverseRequest
    {
        /**
         * Header information of the request
         */
        public RequestHeader RequestHeader { get; set; }

        /**
         * paymentReferenceNumber of the Payment
         */
        public string OriginalReferenceNumber { get; set; }

        /**
         * Unique reference number of the operation, first 3 digit is application specific and defined by Paycell Web SDK
         */
        public string ReferenceNumber { get; set; }

        /**
         * Merchant code, defined by Paycell Web SDK for each merchant
         */
        public string MerchantCode { get; set; }

        /**
         * Phone number of the customer
         * country code must be added
         */
        public string Msisdn { get; set; }
    }
}