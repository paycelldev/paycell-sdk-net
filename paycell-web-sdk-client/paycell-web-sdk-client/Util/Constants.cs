
namespace paycell_web_sdk_client.Util
{
    public static class Constants
    {
        public const string MERCHANT_CODE = "1186";
        public const string SECURE_CODE = "r92txmtCw8M0";
        public const string TERMINAL_CODE = "12345";

        public const string APPLICATION_NAME = "PORTALTEST";
        public const string APPLICATION_PASSWORD = "ZDyXmMLWE2z7OzJU";

        public const string INIT_URL = "https://sdk-services-test.turkcell.com.tr/api/Session/Init";
        public const string VALIDATION_TRACKING_URL = "https://sdk-services-test.turkcell.com.tr/Validation/Tracking";
        public const string REVERSE_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/cancelrestful/cancelService/reversePayment";
        public const string REFUND_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/cancelrestful/cancelService/refundPayment";
        public const string QUERY_STATU_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/cancelrestful/cancelService/queryPaymentStatus";

        public const string POST_RESULT_URL = "http://10.250.171.16:62341/api/handlePostResult";
        public const string RETURN_URL = "http://10.250.171.16:62341/Home/CheckStatus";
        public const string PRE_REFERENCE_NUMBER = "001";

        public static int SUCCESS_CODE = 0;
    }
}