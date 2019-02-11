
namespace paycell_web_sdk_client.Models.dto
{
    public class IndexPageViewDto
    {
        public PaymentViewDto PaymentView { get; set; }

        public MetaDataViewDto MetaData { get; set; }

        public QueryStatuViewDto QueryStatu { get; set; }

        public InstalmentPlanViewDto NewInstalmentPlanView { get; set; }

        public string PaymentUrl { get; set; }

    }
}