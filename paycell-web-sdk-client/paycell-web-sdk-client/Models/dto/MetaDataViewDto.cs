using System;

namespace paycell_web_sdk_client.Models.dto
{
    public class MetaDataViewDto
    {
        public string ApplicationName { get; set; }

        public string MerchantCode { get; set; }

        public string TerminalCode { get; set; }

        public string HostAccount { get; set; }

        public string Msisdn { get; set; }

        public string Language { get; set; }

        public string ClientIPAddress { get; set; }
    }

}