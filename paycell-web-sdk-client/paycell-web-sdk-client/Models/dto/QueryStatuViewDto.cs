
namespace paycell_web_sdk_client.Models.dto
{
    public class QueryStatuViewDto
    {

        public string Msisdn { get; set; }

        public string Amount { get; set; }

        public string Currency { get; set; }

        public string InstallmentCount { get; set; }

        public string PaymentSecurity { get; set; }

        public string PaymentDate { get; set; }

        public string ReconcilationDate { get; set; }

        public string AcquirerbankCode { get; set; }

        public string IssuerBankCode { get; set; }

        public string ApprovalCode { get; set; }

        public string OrderId { get; set; }

        public string PaymentReferenceNumber { get; set; }

        public string ExtraParameters { get; set; }

        public string Status { get; set; }

        public string StatusExplanation { get; set; }

        public string PaymentMethodId { get; set; }

        public string PaymentMethodNumber { get; set; }

        public string PaymentMethodType { get; set; }

    }
}