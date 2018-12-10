using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{
    public class Sale3DOOSPayRequest
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
        [XmlElement("txntimestamp")]
        public string txntimestamp { get; set; }
        [XmlElement("lang")]
        public string lang { get; set; }
        [XmlElement("refreshtime")]
        public string refreshtime { get; set; }
        [XmlElement("companyname")]
        public string companyname { get; set; }

        public static string Execute(Sale3DOOSPayRequest request, Settings3D settings3D)
        {
            request.secure3dhash = Compute3DHash(request, settings3D);
            NameValueCollection Data = new NameValueCollection();
            Data.Add("mode", request.mode);
            Data.Add("secure3dsecuritylevel", request.secure3dsecuritylevel);
            Data.Add("apiversion", request.apiversion);
            Data.Add("terminalprovuserid", request.terminalprovuserid);
            Data.Add("terminaluserid", request.terminaluserid);
            Data.Add("terminalmerchantid", request.terminalmerchantid);
            Data.Add("terminalid", request.terminalid);
            Data.Add("txntype", request.txntype);
            Data.Add("txnamount", request.txnamount);
            Data.Add("txncurrencycode", request.txncurrencycode);
            Data.Add("txninstallmentcount", request.txninstallmentcount);
            Data.Add("orderid", request.orderid);
            Data.Add("successurl", request.successurl);
            Data.Add("errorurl", request.errorurl);
            Data.Add("customeremailaddress", request.customeremailaddress);
            Data.Add("customeripaddress", request.customeripaddress);
            Data.Add("secure3dhash", request.secure3dhash);
            Data.Add("lang", request.lang);
            Data.Add("refreshtime", request.refreshtime);
            Data.Add("txntimestamp", request.txntimestamp);
            Data.Add("companyname", request.companyname);

            return Helper.PreparePOSTForm(settings3D.BaseUrl, Data);
        }

        public static string Compute3DHash(Sale3DOOSPayRequest request, Settings3D settings3D)
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
        
    }
}
