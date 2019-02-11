using paycell_web_sdk_client.Models.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace paycell_web_sdk_client.Util
{
    public class HashFactory
    {

        /**
         * Security Data : Sha256(SecureCode + TerminalCode)
         * Merchant Hash Data : Sha256(paymentReferenceNumber + terminalCode + amount + currency + paymentSecurity +
         *  hostAccount + installmentPlan (lineId sırası ile taksit bilgileri birleştirilir --> lineId + paymentMethodType +
         *  cardBrand + count + amount) + SecurityData)

         */
        public static string CreateHash(Merchant merchant, Payment payment, String hostAccount)
        {
            string securityData = Sha256(Constants.SECURE_CODE + merchant.TerminalCode);
            StringBuilder sb = new StringBuilder();

            sb.Append(payment.PaymentReferenceNumber);
            sb.Append(merchant.TerminalCode);
            sb.Append(payment.Amount);
            sb.Append(payment.Currency);
            sb.Append(payment.PaymentSecurity);
            sb.Append(hostAccount);
            /*
            for(InstalmentPlan instalmentPlan : SortByLineId(payment.InstalmentPlan)){
                sb.Append(instalmentPlan.LineId);
                sb.Append(instalmentPlan.PaymentMethodType.ToString());
                sb.Append(instalmentPlan.CardBrand.ToString());
                sb.Append(instalmentPlan.Count);
                sb.Append(instalmentPlan.Amount);
            }*/
            sb.Append(securityData);
            return Sha256(sb.ToString());
        }

        /**
         * Sorts list by line id asc
         * @param instalmentPlans a list of {@link InstalmentPlan}
         * @return sorted list
         */
        static List<InstalmentPlan> SortByLineId(List<InstalmentPlan> instalmentPlans)
        {
            List<InstalmentPlan> final = instalmentPlans.OrderBy(o => o.LineId).ToList();
            return final;
        }

        /**
         * Encode string with sha256 and represented in Base64
         * @param originalString text to be encoded
         * @return encoded text
         */
        static string Sha256(string originalString)
        {
            try
            {
                SHA256 mySHA256 = SHA256.Create();
                string hash = Convert.ToBase64String(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(originalString)));
                return hash;

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

}