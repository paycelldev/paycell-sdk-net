using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.queryStatu
{
    public class PaymentMethod
    {
        /**
         * Unique id of the payment method used
         */
        public String PaymentMethodId { get; set; }

        /**
         * Masked credit card number
         * Retrieved from CCPO Service
         */
        public String PaymentMethodNumber { get; set; }

        /**
         * Type of payment method:
         * - CREDITCARD: for credit card
         * - PCARD: for paycell card
         */
        public String PaymentMethodType { get; set; }
    }
}