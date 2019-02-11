using paycell_web_sdk_client.Models.model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace paycell_web_sdk_client.Controllers
{
    public class HandlePostResultController : ApiController
    {

        /**
         * Handles returned data after payment
         * Url is binded to postResultUrl in {@link InitRestClient}
         * @param paymentNotification data to be handled
         * @return Success if handled successfully
         */ // url --> api/handlePostResult
        [HttpPost]
        public String Post([FromBody]PaymentNotification paymentNotification)
        {
            if (paymentNotification.IsTimeoutOperation)
            {
                HandleTimeout(paymentNotification);
            }
            else if (paymentNotification.IsCancelled)
            {
                HandleCancel(paymentNotification);
            }
            else if (paymentNotification.IsPaid)
            {
                HandlePaid(paymentNotification);
            }
            return "Success";
        }

        /**
         * Handles if the payment is paid
         * @param paymentNotification
         */
        void HandlePaid(PaymentNotification paymentNotification)
        {
        }

        /**
         * Handles if the payment is cancelled
         * @param paymentNotification
         */
        void HandleCancel(PaymentNotification paymentNotification)
        {
        }

        /**
         * Handles if the payment had timeout
         * @param paymentNotification
         */
        void HandleTimeout(PaymentNotification paymentNotification)
        {
            if (paymentNotification.IsReverse)
            {
                ReversePayment(paymentNotification);
            }
        }

        /**
         * Handles if payment has to be reversed
         * @param paymentNotification
         */
        void ReversePayment(PaymentNotification paymentNotification)
        {
        }
    }
}