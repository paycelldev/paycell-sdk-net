using paycell_web_sdk_client.Models.dto;
using paycell_web_sdk_client.Models.init;
using paycell_web_sdk_client.Models.model;
using paycell_web_sdk_client.Models.queryStatu;
using paycell_web_sdk_client.Util;
using System;

namespace paycell_web_sdk_client.Services
{
    public abstract class PaymentServiceTool
    {

        public InitRequest CreateInitRequest(IndexPageViewDto indexPageView)
        {
            InitRequestFactory InitRequestFactory = new InitRequestFactory();

            InitRequest InitRequest = new InitRequest()
            {
                Language = indexPageView.MetaData.Language,
                HostAccount = indexPageView.MetaData.HostAccount,
                Payment = InitRequestFactory.CreatePayment(indexPageView.PaymentView.Amount, indexPageView.PaymentView.Currency, indexPageView.PaymentView.PaymentSecurity)
            };

            foreach (InstalmentPlanViewDto dto in indexPageView.PaymentView.InstalmentPlans)
            {
                InstalmentPlan InstalmentPlan = InitRequestFactory.AddNewInstalmentPlan(dto, indexPageView.PaymentView.InstalmentPlans.Count - 1);
                InitRequest.Payment.InstalmentPlan.Add(InstalmentPlan);
            }

            InitRequest.Payment.PaymentReferenceNumber = indexPageView.PaymentView.PaymentReferenceNumber;
            InitRequest.ReturnUrl = Constants.RETURN_URL + "?paymentReferenceNumber=" + indexPageView.PaymentView.PaymentReferenceNumber;

            InitRequest = InitRequestFactory.Build(InitRequest);

            return InitRequest;
        }

        public IndexPageViewDto LoadTestData()
        {
            IndexPageViewDto dto = new IndexPageViewDto();
            MetaDataViewDto metaDataViewDto = new MetaDataViewDto
            {
                HostAccount = "xxxxx@xxxx.com",
                Msisdn = "905465553333",
                Language = "tr",
                ApplicationName = Constants.APPLICATION_NAME,
                MerchantCode = Constants.MERCHANT_CODE,
                TerminalCode = Constants.TERMINAL_CODE,
                ClientIPAddress = GetIPAddress()
            };

            PaymentViewDto paymentViewDto = CreateTestPaymentViewDto();
            InstalmentPlanViewDto instalmentPlan = CreateTestInstalmentPlan();

            dto.MetaData = metaDataViewDto;
            dto.PaymentView = paymentViewDto;
            dto.PaymentView.InstalmentPlans.Add(instalmentPlan);

            return dto;
        }

        public PaymentViewDto CreateTestPaymentViewDto()
        {
            return new PaymentViewDto
            {
                Amount = "100",
                Currency = "99",
                PaymentSecurity = "NON_THREED_SECURE",
                InstalmentPlans = new System.Collections.Generic.List<InstalmentPlanViewDto>()
            };
        }

        public InstalmentPlanViewDto CreateTestInstalmentPlan()
        {
            return new InstalmentPlanViewDto
            {
                Amount = "100",
                CardBrand = "BONUS",
                Count = "1",
                PaymentMethodType = "CREDIT_CARD"
            };
        }

        public string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];

            if (ipAddress == "::1")
            {
                ipAddress = "0:0:0:1";
            }
            return ipAddress;
        }

        public QueryStatuViewDto CreateQueryStatuViewDto(QueryStatuResponse queryStatuResponse)
        {
            QueryStatuViewDto queryStatuViewDto = new QueryStatuViewDto()
            {
                ExtraParameters = (queryStatuResponse.ExtraParameters),
                Amount = (queryStatuResponse.Amount),
                Currency = (queryStatuResponse.Currency),
                InstallmentCount = (queryStatuResponse.InstallmentCount),
                AcquirerbankCode = (queryStatuResponse.AcquirerbankCode),
                IssuerBankCode = (queryStatuResponse.IssuerBankCode),
                ApprovalCode = (queryStatuResponse.ApprovalCode),
                Msisdn = (queryStatuResponse.Msisdn),
                OrderId = (queryStatuResponse.OrderId),
                PaymentReferenceNumber = (queryStatuResponse.PaymentReferenceNumber),
                PaymentDate = (queryStatuResponse.PaymentDate),
                PaymentSecurity = (queryStatuResponse.PaymentSecurity),
                ReconcilationDate = (queryStatuResponse.ReconcilationDate),
                Status = (queryStatuResponse.Status),
                StatusExplanation = (queryStatuResponse.StatusExplanation),
                PaymentMethodId = (queryStatuResponse.PaymentMethod.PaymentMethodId),
                PaymentMethodNumber = (queryStatuResponse.PaymentMethod.PaymentMethodNumber),
                PaymentMethodType = (queryStatuResponse.PaymentMethod.PaymentMethodType)
            };

            return queryStatuViewDto;
        }

        public string GetPaymentScreenUrl(string trackingId)
        {
            return Constants.VALIDATION_TRACKING_URL + "/" + trackingId;

        }

        public string KeyGenerator()
        {
            return Guid.NewGuid().ToString().Replace("{", "");
        }
    }
}