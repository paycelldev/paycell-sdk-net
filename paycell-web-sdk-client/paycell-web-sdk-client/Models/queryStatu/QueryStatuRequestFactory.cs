using paycell_web_sdk_client.Models.model;
using paycell_web_sdk_client.Util;
using System;

namespace paycell_web_sdk_client.Models.queryStatu
{
    public class QueryStatuRequestFactory
    {
        private QueryStatuRequest queryStatuRequest;

        public QueryStatuRequestFactory()
        {
            RequestHeader requestHeader = new RequestHeader()
            {
                ApplicationName = Constants.APPLICATION_NAME,
                ApplicationPwd = Constants.APPLICATION_PASSWORD
            };

            queryStatuRequest = new QueryStatuRequest()
            {
                MerchantCode = Constants.MERCHANT_CODE,
                RequestHeader = requestHeader
            };

        }

        /**
         * Sets original payment reference number
         * @param originalPaymentReferenceNumber
         * @return
         */
        public QueryStatuRequestFactory AddOriginalPaymentReferenceNumber(String originalPaymentReferenceNumber)
        {
            queryStatuRequest.OriginalPaymentReferenceNumber = (originalPaymentReferenceNumber);
            return this;
        }

        /**
         * Sets ip address information of the client
         * @param clientIPAddress
         * @return
         */
        public QueryStatuRequestFactory AddClientIPAddress(String clientIPAddress)
        {
            queryStatuRequest.RequestHeader.ClientIPAddress = (clientIPAddress);
            return this;
        }

        private void PreBuild()
        {
            if (queryStatuRequest.RequestHeader.TransactionId == null)
            {
                queryStatuRequest.RequestHeader.TransactionId = (UniqueIdGenerator.GenerateTransactionId());
                queryStatuRequest.RequestHeader.TransactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss") + "000";
            }
        }

        /**
         * @return builded QueryStatuRequest
         * @throws Exception thrown if OriginalPaymentReferenceNumber is not set
         */
        public QueryStatuRequest Build()
        {
            if (queryStatuRequest.OriginalPaymentReferenceNumber == null) {
                throw new Exception("OriginalPaymentReferenceNumber should be set first");
        }
            PreBuild();
            return queryStatuRequest;
        }
    }
}