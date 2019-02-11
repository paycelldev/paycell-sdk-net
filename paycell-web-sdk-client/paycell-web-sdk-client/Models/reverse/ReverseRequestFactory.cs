using paycell_web_sdk_client.Models.model;
using paycell_web_sdk_client.Util;
using System;

namespace paycell_web_sdk_client.Models.reverse
{
    public class ReverseRequestFactory
    {

        private ReverseRequest reverseRequest;

        public ReverseRequestFactory()
        {
            RequestHeader requestHeader = new RequestHeader()
            {
                ApplicationName = Constants.APPLICATION_NAME,
                ApplicationPwd = Constants.APPLICATION_PASSWORD
            };

            reverseRequest = new ReverseRequest()
            {
                ReferenceNumber = Constants.PRE_REFERENCE_NUMBER + UniqueIdGenerator.KeyGenerator(),
                MerchantCode = Constants.MERCHANT_CODE,
                RequestHeader = requestHeader

            };
        }

        /**
         * Sets the original payment reference number of the payment to be reversed
         * @param originalPaymentReferenceNumber
         * @return this
         */
        public ReverseRequestFactory AddOriginalPaymentReferenceNumber(string originalPaymentReferenceNumber)
        {
            reverseRequest.OriginalReferenceNumber = originalPaymentReferenceNumber;
            return this;
        }

        /**
         * Sets the IP address information of the customer
         * @param clientIPAddress
         * @return
         */
        public ReverseRequestFactory AddClientIPAddress(string clientIPAddress)
        {
            reverseRequest.RequestHeader.ClientIPAddress = clientIPAddress;
            return this;
        }

        /**
         * Sets phone number of the customer
         * @param msisdn phone number of the customer, 10 Digits: 5XXXXXXXXX
         */
        public ReverseRequestFactory AddMsisdn(string msisdn)
        {
            reverseRequest.Msisdn = msisdn;
            return this;
        }

        /**
         * Builds ReverseRequest
         * @return builded ReverseRequest
         * @throws Exception thrown if OriginalReferenceNumber is not set
         */
        public ReverseRequest Build()
        {
            if(reverseRequest.OriginalReferenceNumber == null){
                throw new Exception("OriginalReferenceNumber must be set first");
            }
            PreBuild();
            return reverseRequest;
        }

        private void PreBuild()
        {
            if (reverseRequest.RequestHeader.TransactionId == null)
            {
                reverseRequest.RequestHeader.TransactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss") + "000";
                reverseRequest.RequestHeader.TransactionId = UniqueIdGenerator.GenerateTransactionId();
            }
        }
    }
}