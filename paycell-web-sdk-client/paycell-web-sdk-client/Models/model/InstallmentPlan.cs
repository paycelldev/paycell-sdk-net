using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_sdk_client.Models.model
{
    public class InstalmentPlan
    {

        public string LineId { get; set; }

        public string PaymentMethodType { get; set; }

        public string CardBrand { get; set; }

        public string Count { get; set; }

        public string Amount { get; set; }

    }
}