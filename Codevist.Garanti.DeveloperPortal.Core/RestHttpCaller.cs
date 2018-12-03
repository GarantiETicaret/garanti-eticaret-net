using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using Codevist.Garanti.DeveloperPortal.Core.Request;

namespace Codevist.Garanti.DeveloperPortal.Core
{
    /// <summary>
    ///XML çağrıları için oluşturulan xml'i verilen adrese post eden sınıftır. Response sonucu oluşan xml çıktısı execute metoduna gönderilir.
    /// </summary>
    public class RestHttpCaller
    {
        public static RestHttpCaller Create()
        {
            return new RestHttpCaller();
        }

        // cevap olarak geri dönen xml i ekranda gösterebilmek bu fonksiyonu da yazdık
        public string PostXMLString(String url, VPOSRequest request)
        {
            HttpClient httpClient = new HttpClient();
          
            var xml = XmlBuilder.SerializeToXMLString(request);
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, xml).Result;
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return result; 
        }
        
        public string PostXMLString(String url, Sale3DSecureRequest request)
        {
            HttpClient httpClient = new HttpClient();
            
            
            StringContent a = new StringContent(request.ToString(), Encoding.UTF8);
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, a).Result;
            
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return result;
        }

        // bu fonksiyonda kullanılabilir. bunun ile xml deki elementlere tek tek ulaşabilirsiniz.
        public T PostXML<T>(String url, VPOSRequest request)
        {
            HttpClient httpClient = new HttpClient();

            var xml = XmlBuilder.SerializeToXMLString(request);
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, xml).Result;
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return XmlBuilder.DeserializeObject<T>(result);
        }
    }
}