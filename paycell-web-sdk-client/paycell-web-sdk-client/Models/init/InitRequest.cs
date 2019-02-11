using paycell_web_sdk_client.Models.model;

namespace paycell_web_sdk_client.Models.init
{
    public class InitRequest
    {
        /**
         * Header information of the request
         */
        public InitRequestHeader RequestHeader { get; set; }

        /**
         * Turkcell Hızlı Giriş parameters
         */
        public McParameters McParameters { get; set; }

        /**
         * Hash information of the data, encoded in base64
         * Calculated as combination of methods:
         * - securityData = Sha256(SecureCode + TerminalCode)
         * - hashData = Sha256(paymentReferenceNumber + terminalCode + amount + currency
         * + paymentSecurity + hostAccount + securityData)
         */
        public string HashData { get; set; }

        /**
         * Represents account of the customer that pays the merchant.
         * If email address of the customer address is used for authentication in merchant system,
         * email address information may be sent in this attribute
         */
        public string HostAccount { get; set; }

        /**
         * Language information tr/en
         */
        public string Language { get; set; }

        /**
         * Payment information
         */
        public Payment Payment { get; set; }

        /**
         * Represents the url that the customer will be redirected after the payment operation
         */
        public string ReturnUrl { get; set; }

        /**
         * Represents the url that the result information and status will be sent after payment operation.
         * The data will be sent in json format.
         */
        public string PostResultUrl { get; set; }

        /**
         * Represents the time limit of payment that is given by the merchant to the customer.
         */
        public string TimeoutDuration { get; set; }
    }
}