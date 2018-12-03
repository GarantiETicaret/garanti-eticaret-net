using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core
{
    /// <summary>
    /// Istekleri XML olarak oluşturucak sınıftır. 
    /// </summary>
    public class XmlBuilder
    {
        public static StringContent SerializeToXMLString(object request)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(request.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, request, emptyNamespaces);
                return new StringContent(stream.ToString().Insert(0, "data="), Encoding.UTF8, "application/xml");
            }
        }

        public static T DeserializeObject<T>(string xmlString)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                return (T)Convert.ChangeType(xs.Deserialize(memoryStream), typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Byte[] StringToUTF8ByteArray(String xmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(xmlString);
            return byteArray;
        }
        
    }
}
