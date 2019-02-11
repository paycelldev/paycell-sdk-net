using System.Collections.Generic;


namespace paycell_web_sdk_client.Models.model
{
    public class Payment
    {
        /**
         * Represents total payment amount in advance. If different amounts will be given for different payment methods,
         * They should be added in instalmentPlans. Count attribute for instalment plans that will be paid in advance should
         * be given as 1. Last 2 decimal represents coins.
         * 1.55 is represented as "155"
         * 3.00 is represented as "300"
         */
        public string Amount { get; set; }

        /**
         * Currency
         * TL is represented as "99"
         */
        public string Currency { get; set; }

        /**
         * Unique id for payment request, Merchant provides this information
         */
        public string PaymentReferenceNumber { get; set; }

        /**
         * Defines how security will be provided for credit card payments
         */
        public string PaymentSecurity { get; set; }

        /**
         * List of instalment plans
         */
        public List<InstalmentPlan> InstalmentPlan { get; set; }
    }
}