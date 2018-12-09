using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;

namespace Codevist.Garanti.DeveloperPortal.Core
{
    public class Helper
    {


        /// <summary>
        ///success url sayfası içerisinde HashParam  değerinin doğruluğunu kontrol etmek amacıyla oluşturulan  Verilen string'i SHA1 ile hashleyip Base64 formatına çeviren fonksiyondur. 
        /// CreateToken'dan farklı  olarak token oluşturmaz sadece hassh hesaplar
        /// </summary>
        /// <param name="hashString"></param>
        /// <returns></returns>
        public static string ComputeHash(string hashString)
        {
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashString);
            byte[] inputbytes = sha.ComputeHash(hashbytes);
            return Convert.ToBase64String(inputbytes);
        }

        public static string ComputeHash(VPOSRequest request, Settings settings)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            var temp = settings.Password + request.Terminal.ID.PadLeft(9, '0');
            var hashedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(temp));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)

            {

                sb.Append(hashedPassword[i].ToString("X2"));

            }

            temp = request.Order.OrderID + request.Terminal.ID + request.Card.Number + request.Transaction.Amount +
                   sb.ToString();
            var hashData = sha.ComputeHash(Encoding.UTF8.GetBytes(temp));
            sb = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                sb.Append(hashData[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string ComputeHash(string hashString, string terminalID, Settings settings)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            var temp = settings.Password + terminalID.PadLeft(9, '0');
            var hashedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(temp));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)

            {
                sb.Append(hashedPassword[i].ToString("X2"));
            }

            temp = hashString + sb.ToString();
            var hashData = sha.ComputeHash(Encoding.UTF8.GetBytes(temp));
            sb = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                sb.Append(hashData[i].ToString("X2"));
            }
            return sb.ToString();
        }

        //post edilecek formu oluşturur.
        public static String PreparePOSTForm(string url, NameValueCollection data)
        {
            string formID = "PostForm";
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (string key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key +
                               "\" value=\"" + data[key] + "\">");
            }

            strForm.Append("</form>");
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language=\"javascript\">");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            return strForm.ToString() + strScript.ToString();
        }

        //provizyon işlemlerinde fraud önlemek için yapılan validation kontrolü yapılır.
        public static string XmlValidation(string result, Settings settings)
        {
            //(ResponseCode + RRN + AuthCode + ProvDate + OrderID + HASH(password + TerminalID))
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(result);
            string reasonCode = xDoc.SelectSingleNode("//GVPSResponse/Transaction/Response/ReasonCode").InnerText;
            string retRefNum = xDoc.SelectSingleNode("//GVPSResponse/Transaction/RetrefNum").InnerText;
            string authCode = xDoc.SelectSingleNode("//GVPSResponse/Transaction/AuthCode").InnerText;
            string provDate = xDoc.SelectSingleNode("//GVPSResponse/Transaction/ProvDate").InnerText;
            string orderId = xDoc.SelectSingleNode("//GVPSResponse/Order/OrderID").InnerText;
            string terminalId = xDoc.SelectSingleNode("//GVPSResponse/Terminal/ID").InnerText;
            string hashData = xDoc.SelectSingleNode("//GVPSResponse/Transaction/HashData").InnerText;

            string hashString = reasonCode + retRefNum + authCode + provDate + orderId;

            string validhash = ComputeHash(hashString, terminalId, settings);

            if (reasonCode == "00" && hashData != null && hashData != "")
            {
                if(hashData == validhash)
                {
                    return result;
                }
                return "Validation Hatalı";
            }
            return result;
        }

        // 3D işlem doğrulama
        public static bool Validate3DReturn(string hashString, string validHash)
        {
            var hashData = ComputeHash(hashString);

            if (hashData == validHash)
                return true;
            return false;
        }

      
    }
}
