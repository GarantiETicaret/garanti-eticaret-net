using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Codevist.Garanti.DeveloperPortal.Core;
using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;

namespace Codevist.Garanti.DeveloperPortal.WebSamples.Controllers
{
    public class BaseController : Controller
    {
        public Terminal terminal = new Terminal()
        {
            ID = "30691297", //Garanti bankası tarafından sağlanan kendi bilgileriniz ile değiştirmelisiniz. 
            MerchantID = "7000679", //Garanti bankası tarafından sağlanan kendi bilgileriniz ile değiştirmelisiniz. 
            ProvUserID = "PROVAUT", //Garanti bankası tarafından sağlanan kendi bilgileriniz ile değiştirmelisiniz. 
            UserID = "PROVAUT", //Garanti bankası tarafından sağlanan kendi bilgileriniz ile değiştirmelisiniz. 
            HashData = "", //Hesaplanacak
        };

        public Settings settings = new Settings()
        {
            Version = "V0.1", // Sabit Kalmalı 
            Mode = "Test", // Kullandığınız ortama göre değiştirmelisiniz. 
            BaseUrl = "https://sanalposprovtest.garanti.com.tr/VPServlet", //Test Adresi  // Üretim otamına geçtiğinizde adresi değiştirmelisiniz. 
            Password = "123qweASD/" //Kendi şifreniz ile değiştirmelisiniz. 
        };

        public Settings3D settings3D = new Settings3D()
        {
            mode = "Test",
            apiversion = "V0.1",
            BaseUrl = "https://sanalposprovtest.garanti.com.tr/servlet/gt3dengine",
            Password = "123qweASD/"
        };

    }
}