using paycell_web_sdk_client.Models.dto;
using paycell_web_sdk_client.Models.model;
using paycell_web_sdk_client.Models.init;
using paycell_web_sdk_client.Util;
using paycell_web_sdk_client.Models.refund;
using paycell_web_sdk_client.Models.reverse;
using paycell_web_sdk_client.Models.queryStatu;

using System;

namespace paycell_web_sdk_client.Services
{
    public class PaymentService : PaymentServiceTool
    {

        public String InitPayment(IndexPageViewDto indexPageView)
        {
            InitRequest initRequest = CreateInitRequest(indexPageView);
            InitResponse initResponse = new RestClientTool<InitRequest, InitResponse>().RestClientRequest(Constants.INIT_URL, initRequest);

            if (initResponse.StatusCode != null && Int32.Parse(initResponse.StatusCode) == Constants.SUCCESS_CODE)
            {
                return GetPaymentScreenUrl(initResponse.TrackingId);

            } else if (initResponse.StatusCode != null && initResponse.StatusCode != "11")
            {
                string errorMessage = "Init payment was not successful: " + initResponse.StatusCode + " " + initResponse.Message;
                throw new Exception(errorMessage);

            } else
            {
                string errorMessage = "Init payment was not successful, status info is empty";
                throw new Exception(errorMessage);

            }
            
        }

        public string ReversePayment(MetaDataViewDto metaData, PaymentViewDto payment)
        {
            ReverseRequestFactory reverseRequestFactory = new ReverseRequestFactory();
            RestClientTool<ReverseRequest, ReverseResponse> restClient = new RestClientTool<ReverseRequest, ReverseResponse>();

            ReverseRequest reverseRequest = reverseRequestFactory
                .AddOriginalPaymentReferenceNumber(payment.PaymentReferenceNumber).AddMsisdn(metaData.Msisdn)
                .AddClientIPAddress(metaData.ClientIPAddress).Build();

            ReverseResponse reverseResponse = restClient.RestClientRequest(Constants.REVERSE_URL, reverseRequest);

		    if (reverseResponse.ResponseHeader.ResponseCode != null && reverseResponse.ResponseHeader.ResponseCode == "0") {

                return reverseResponse.ApprovalCode;

		    } else if (reverseResponse.ResponseHeader != null) {

                string errorMessage = "Reverse payment was not successful: [%s], %s" +reverseResponse.ResponseHeader.ResponseCode + reverseResponse.ResponseHeader.ResponseDescription;
			    throw new Exception(errorMessage);

            } else {

                string errorMessage = "Reverse payment was not successful, response status info is empty.";
			    throw new Exception(errorMessage);

		    }
	    }


        public string RefundPayment(MetaDataViewDto metaData, PaymentViewDto payment, String refundAmount)
        {
            RefundRequestFactory refundRequestFactory = new RefundRequestFactory();
            RefundRequest refundRequest = refundRequestFactory
                .AddOriginalReferenceNumber(payment.PaymentReferenceNumber).AddAmount(refundAmount)
                .AddClientIPAddress(metaData.ClientIPAddress).AddMsisdn(metaData.Msisdn).Build();

            RestClientTool<RefundRequest, RefundResponse> restClient = new RestClientTool<RefundRequest, RefundResponse>();
            RefundResponse refundResponse = restClient.RestClientRequest(Constants.REFUND_URL, refundRequest);

            ResponseHeader responseHeader = refundResponse.ResponseHeader;

		    if (responseHeader.ResponseCode != null && responseHeader.ResponseCode == "0") {
			    return refundResponse.ApprovalCode;

		    } else if (responseHeader.ResponseCode != null) {
			    string errorMessage = "Refund payment was not successful: " + refundResponse.ResponseHeader.ResponseCode +
                        " " + refundResponse.ResponseHeader.ResponseDescription;
                throw new Exception(errorMessage);

            } else {
                string errorMessage = "Refund payment was not successful, response status info is empty.";
			    throw new Exception(errorMessage);
            }
	    }

        public QueryStatuViewDto QueryPayment(MetaDataViewDto metaData, PaymentViewDto paymentViewDto)
        {
            RestClientTool<QueryStatuRequest, QueryStatuResponse> restClient = new RestClientTool<QueryStatuRequest, QueryStatuResponse>();

            QueryStatuRequest request = new QueryStatuRequestFactory()
				.AddOriginalPaymentReferenceNumber(paymentViewDto.PaymentReferenceNumber)
				.AddClientIPAddress(metaData.ClientIPAddress).Build();

            QueryStatuResponse response = restClient.RestClientRequest(Constants.QUERY_STATU_URL, request);

            if (response.ResponseHeader.ResponseCode != null && response.ResponseHeader.ResponseCode == "0")
            {
                return CreateQueryStatuViewDto(response);

            }
            else if (response.ResponseHeader != null)
            {
                String errorMessage = "Query Status of Payment was not successful: " + response.ResponseHeader.ResponseCode + response.ResponseHeader.ResponseDescription;
                throw new Exception(errorMessage);

            }
            else
            {
                String errorMessage = "Query Status of Payment was not successful, response status info is empty.";
                throw new Exception(errorMessage);
            }
	    }

    }
}