using paycell_web_sdk_client.Models.model;
using paycell_web_sdk_client.Util;
using System;

namespace paycell_web_sdk_client.Models.refund
{
    public class RefundRequestFactory
    {
        private RefundRequest refundRequest;

        public RefundRequestFactory()
        {
            refundRequest = new RefundRequest()
            {
                MerchantCode = Constants.MERCHANT_CODE,
                ReferenceNumber = Constants.PRE_REFERENCE_NUMBER + UniqueIdGenerator.KeyGenerator()
            };

            RequestHeader requestHeader = new RequestHeader()
            {
                ApplicationName = Constants.APPLICATION_NAME,
                ApplicationPwd = Constants.APPLICATION_PASSWORD
            };
            refundRequest.RequestHeader =requestHeader;
        }

        /**
         * Sets the ip address information of the customer
         * @param clientIPAddress
         * @return this
         */
        public RefundRequestFactory AddClientIPAddress(string clientIPAddress)
        {
            refundRequest.RequestHeader.ClientIPAddress = clientIPAddress;
            return this;
        }

        /**
         * Sets the phone number information of the customer
         * @param msisdn 10 digits phone number: 5XXXXXXXXX
         * @return this
         */
        public RefundRequestFactory AddMsisdn(string msisdn)
        {
            refundRequest.Msisdn = msisdn;
            return this;
        }

        /**
         * Sets original reference number of the payment
         * @param originalReferenceNumber
         * @return this
         */
        public RefundRequestFactory AddOriginalReferenceNumber(string originalReferenceNumber)
        {
            refundRequest.OriginalReferenceNumber = originalReferenceNumber;
            return this;
        }

        /**
         * Sets the refund amount for the payment
         * @param amount last 2 digits represents cois
         *               1.00 is represented as "100"
         * @return
         */
        public RefundRequestFactory AddAmount(string amount)
        {
            refundRequest.Amount = amount;
            return this;
        }

        private void PreBuild()
        {
            if (refundRequest.RequestHeader.TransactionId == null)
            {
                refundRequest.RequestHeader.TransactionId = UniqueIdGenerator.GenerateTransactionId();
                refundRequest.RequestHeader.TransactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss") + "000";
            }
        }

        /**
         * Builds the request
         * @return RefundRequest builded
         * @throws Exception thrown if the Original Reference Number is not set
         */
        public RefundRequest Build()
        {
            if(refundRequest.OriginalReferenceNumber == null){
                throw new Exception("OriginalReferenceNumber should be created first.");
            }
            PreBuild();
            return refundRequest;
        }
    }
}