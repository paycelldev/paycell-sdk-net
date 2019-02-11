using System;

namespace paycell_web_sdk_client.Models.model
{
    public class PaymentNotification
    {

        /**
         * Tracking information
         */
        public String TrackingId { get; set; }

        /**
         * Payment method type is returned
         * - CREDIT_CARD: for credit cards
         * - PCARD: for paycell cards
         * - DCB: for mobile payments
         * - EPARA: for Dijital Para payments.
         */
        public String PaymentMethodType { get; set; }

        /**
         * Unique id for payment, Information is provided by merchant
         */
        public String PaymentReferenceNumber { get; set; }

        /**
         * Represents if the payment is paid. Payment may be in timeout. isReverse should be checked also.
         * An action should be taken by merchant if isReverse flag active.
         */
        public Boolean IsPaid { get; set; }

        /**
         * Represents if the payment is taken beside the payment had a timeout.
         * An action should be taken by merchant.
         */
        public Boolean IsReverse { get; set; }

        /**
         * Represents transaction date
         */
        public String TransactionDate { get; set; }

        /**
         * Total amount of payment in advance. last two digist represents coins.
         * 1.66 is represented as 166
         * 1.00 is represented as 100
         */
        public String Amount { get; set; }

        /**
         * Represents if the merchant card time limit is exceeded
         */
        public Boolean IsTimeoutOperation { get; set; }

        /**
         * Represents if the customer cancelled the operation
         */
        public Boolean IsCancelled { get; set; }

        /**
         * Unique id of the transaction
         */
        public String TransactionId { get; set; }

        /**
         * datetime of the transaction
         */
        public String TransactionDateTime { get; set; }

        /**
         * IP Address of the requester
         */
        public String ClientIPAddress { get; set; }

        /**
         * Application name, defined by Turkcell Web SDK for each merchant
         */
        public String ApplicationName { get; set; }

        /**
         * Application password, defined by Turkcell Web SDK for each merchant
         */
        public String ApplicationPwd { get; set; }

        /**
         * Merchant Code, defined by Turkcell Web SDK for each merchant
         */
        public String MerchantCode { get; set; }
    }
}