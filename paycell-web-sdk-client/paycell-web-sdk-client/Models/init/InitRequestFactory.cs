using paycell_web_sdk_client.Models.dto;
using paycell_web_sdk_client.Models.model;
using paycell_web_sdk_client.Util;
using System;

namespace paycell_web_sdk_client.Models.init
{
    public class InitRequestFactory
    {
        private static string IS_MC_SESSION_TRUE_VALUE = "Y";
	    private static string IS_MC_SESSION_FALSE_VALUE = "N";

        public InitRequest Build(InitRequest initRequest)
        {
            initRequest.McParameters = SetNullMcParameters();
            initRequest.PostResultUrl = Constants.POST_RESULT_URL;
            initRequest.TimeoutDuration = "300";
            initRequest.RequestHeader = CreateRequestHeader();
            initRequest.HashData = HashFactory.CreateHash(initRequest.RequestHeader.Merchant, initRequest.Payment, initRequest.HostAccount);
            
            return initRequest;
        }

        public InstalmentPlan AddNewInstalmentPlan(InstalmentPlanViewDto instalmentPlanDto, int instalmentPlanCount)
        {
            InstalmentPlan InstalmentPlan = new InstalmentPlan()
            {
                Amount = instalmentPlanDto.Amount,
                Count = instalmentPlanDto.Count,
                PaymentMethodType = instalmentPlanDto.PaymentMethodType,
                CardBrand = instalmentPlanDto.CardBrand,
                LineId = (instalmentPlanCount + 1).ToString()
            };

            return InstalmentPlan;

        }

        public TransactionInfo CreateTransactionInfo()
        {
            TransactionInfo TransactionInfo = new TransactionInfo()
            {
                TransactionDateTime = DateTime.Now.Ticks.ToString(),
                TransactionId = UniqueIdGenerator.GenerateTransactionId()

            };
            return TransactionInfo;
        }

        /**
         * Creates payment
         *
         * @param amount          total amount of the payment in advance
         * @param currency        99 for TL
         * @param paymentSecurity Security method for credit cards: THREED_SECURE, NON_THREED_SECURE
         * @return InitRequestFactory
         */
        public Payment CreatePayment(String amount, String currency, String paymentSecurity)
        {
            Payment Payment = new Payment()
            {
                Amount = amount,
                Currency = currency,
                PaymentSecurity = paymentSecurity,
                InstalmentPlan = new System.Collections.Generic.List<InstalmentPlan>()
            };

            return Payment;
        }

        public McParameters SetNullMcParameters()
        {
            return new McParameters()
            {
                IsMcSession = IS_MC_SESSION_FALSE_VALUE
            };
        }

        /**
         * Sets Turkcell Hızlı Giriş parameters
         * if the customer is logged in. Easy payment will be provided.
         * @param mcPhoneNumber phone number of the customer without country code, 5XXXXXXXXX
         * @param mcPhoneCountry country code of the customer phone number
         * @param mcAuthToken Turkcell Hızlı Giriş authorization token
         * @return this
         */
        public McParameters SetMcParameters(McParameters mcParameters, string mcPhoneNumber, string mcPhoneCountry, string mcAuthToken)
        {
            mcParameters.IsMcSession = IS_MC_SESSION_TRUE_VALUE;
            mcParameters.McPhoneNumber = mcPhoneNumber;
            mcParameters.McPhoneCountry = mcPhoneCountry;
            mcParameters.McAuthToken = mcAuthToken;
            return mcParameters;
        }

        /**
         * Create Request Header : InitRequest
         * @return this
         */
        public InitRequestHeader CreateRequestHeader()
        {
            InitRequestHeader RequestHeader = new InitRequestHeader()
            {
                Merchant = new Merchant()
                {
                    MerchantCode = Constants.MERCHANT_CODE,
                    TerminalCode = Constants.TERMINAL_CODE
                },

                ApplicationName = Constants.APPLICATION_NAME,
                ApplicationPassword = Constants.APPLICATION_PASSWORD,
                TransactionInfo = CreateTransactionInfo()
            };
            
            return RequestHeader;
        }

    }
}