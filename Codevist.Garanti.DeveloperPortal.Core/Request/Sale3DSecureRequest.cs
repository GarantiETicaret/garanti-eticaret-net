using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{
    [XmlRoot("GVPSRequest")]
    public class Sale3DSecureRequest
    {
        [XmlElement("mode")]
        public string mode { get; set; }
        [XmlElement("apiversion")]
        public string apiversion { get; set; }
        [XmlElement("terminalprovuserid")]
        public string terminalprovuserid { get; set; }
        [XmlElement("terminaluserid")]
        public string terminaluserid { get; set; }
        [XmlElement("terminalmerchantid")]
        public string terminalmerchantid { get; set; }
        [XmlElement("terminalid")]
        public string terminalid { get; set; }
        [XmlElement("errorurl")]
        public string errorurl { get; set; }
        [XmlElement("secure3dsecuritylevel")]
        public string secure3dsecuritylevel { get; set; }
        [XmlElement("successurl")]
        public string successurl { get; set; }
        [XmlElement("secure3dhash")]
        public string secure3dhash { get; set; }
        [XmlElement("orderid")]
        public string orderid { get; set; }
        [XmlElement("txnamount")]
        public string txnamount { get; set; }
        [XmlElement("txntype")]
        public string txntype { get; set; }
        [XmlElement("txninstallmentcount")]
        public string txninstallmentcount { get; set; }
        [XmlElement("txncurrencycode")]
        public string txncurrencycode { get; set; }
        [XmlElement("customeremailaddress")]
        public string customeremailaddress { get; set; }
        [XmlElement("customeripaddress")]
        public string customeripaddress { get; set; }
        [XmlElement("storekey")]
        public string storekey { get; set; }

        [XmlElement("cardnumber")]
        public string cardnumber { get; set; }
        [XmlElement("cardexpiredatemonth")]
        public string cardexpiredatemonth { get; set; }
        [XmlElement("cardexpiredateyear")]
        public string cardexpiredateyear { get; set; }
        [XmlElement("cardcvv2")]
        public string cardcvv2 { get; set; }
        [XmlElement("txntimestamp")]
        public string txntimestamp { get; set; }
        [XmlElement("lang")]
        public string lang { get; set; }
        [XmlElement("refreshtime")]
        public string refreshtime { get; set; }

        public static string Execute(Sale3DSecureRequest request, Settings3D settings3D)
        {
            request.secure3dhash = Compute3DHash(request, settings3D);
            return CreateThreeDPaymentForm(request, settings3D);
            //return RestHttpCaller.Create().PostXMLString(settings3D.BaseUrl, request);
        }

        public static string Compute3DHash(Sale3DSecureRequest request, Settings3D settings3D)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            var temp = settings3D.Password + request.terminalid.PadLeft(9, '0');
            var hashedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(temp));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)

            {
                sb.Append(hashedPassword[i].ToString("X2"));
            }

            temp = request.terminalid + request.orderid + request.txnamount + request.successurl + request.errorurl + request.txntype
                + request.txninstallmentcount + request.storekey + sb.ToString();
            var hashData = sha.ComputeHash(Encoding.UTF8.GetBytes(temp));
            sb = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                sb.Append(hashData[i].ToString("X2"));
            }

            return sb.ToString();

        }

        public static string CreateThreeDPaymentForm(Sale3DSecureRequest request, Settings3D settings3D)
        {
           
            StringBuilder builder = new StringBuilder();
            builder.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            builder.Append("<html>");
            builder.Append("<body>");
            builder.Append("<form //action=\"" + settings3D.BaseUrl + "\" method=\"POST\" id=\"three_d_form\" >");

            builder.Append("<input type=\"hidden\" name=\"secure3dsecuritylevel\" id=\"secure3dsecuritylevel\" value=\"" + request.secure3dsecuritylevel + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"mode\" id=\"mode\" value=\"" + request.mode + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"apiversion\" id=\"apiversion\" value=\"" + request.apiversion + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"terminalid\" id=\"terminalid\" value=\"" + request.terminalid + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"terminalprovuserid\" id=\"terminalprovuserid\" value=\"" + request.terminalprovuserid + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"terminaluserid\" id=\"terminaluserid\" value=\"" + request.terminaluserid + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"terminalmerchantid\" id=\"terminalmerchantid\" value=\"" + request.terminalmerchantid + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"txntype\" id=\"txntype\" value=\"" + request.txntype + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardnumber\" id=\"cardnumber\" value=\"" + request.cardnumber + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardexpiredatemonth\" id=\"cardexpiredatemonth\" value=\"" + request.cardexpiredatemonth + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardexpiredateyear\" id=\"cardexpiredateyear\" value=\"" + request.cardexpiredateyear + "\"/>");

            builder.Append("<input type=\"hidden\" name=\"cardcvv2\" id=\"cardcvv2\" value=\"" + request.cardcvv2 + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"txnamount\" id=\"txnamount\" value=\"" + request.txnamount + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"txncurrencycode\" id=\"txncurrencycode\" value=\"" + request.txncurrencycode + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"txninstallmentcount\" id=\"txninstallmentcount\" value=\"" + request.txninstallmentcount + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"orderid\" id=\"orderid\" value=\"" + request.orderid + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"successurl\" id=\"successurl\" value=\"" + request.successurl + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"errorurl\" id=\"errorurl\" value=\"" + request.errorurl + "\"/>");

            builder.Append("<input type=\"hidden\" name=\"secure3dhash\" id=\"secure3dhash\" value=\"" + request.secure3dhash + "\"/>");
            //builder.Append("<input type=\"hidden\" name=\"companyname\" id=\"companyname\" value=\"" + request.companyname + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"customeremailaddress\" id=\"customeremailaddress\" value=\"" + request.customeremailaddress + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"customeripaddress\" id=\"customeripaddress\" value=\"" + request.customeripaddress + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"txntimestamp\" id=\"txntimestamp\" value=\"" + request.txntimestamp + "\"/>");

            builder.Append("<input type=\"hidden\" name=\"lang\" id=\"lang\" value=\"" + request.lang + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"customeripaddress\" id=\"customeripaddress\" value=\"" + request.customeripaddress + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"refreshtime\" id=\"refreshtime\" value=\"" + request.refreshtime + "\"/>");

            builder.Append("<input type=\"submit\" value=\"Öde\" style=\"display:none;\"/>");
            builder.Append("</form>");
            builder.Append("</body>");
            builder.Append("<script>document.getElementById(\"three_d_form\").submit();</script>");
            builder.Append("</html>");
            return builder.ToString();
        }
    }

}
