using System.Collections.Generic;

namespace paycell_web_sdk_client.Models.dto
{
    public class PaymentViewDto
    {
 
        public string PaymentReferenceNumber { get; set; }

        public string Amount { get; set; }

        public string Currency { get; set; }

        public string PaymentSecurity { get; set; }

        public List<InstalmentPlanViewDto> InstalmentPlans { get; set; }

    }
}