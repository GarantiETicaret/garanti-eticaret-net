using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Codevist.Garanti.DeveloperPortal.Core;
using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using Codevist.Garanti.DeveloperPortal.Core.Request;
using Codevist.Garanti.DeveloperPortal.Core.Response;

namespace Codevist.Garanti.DeveloperPortal.WebSamples.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int a)
        {

            return View();
        }


        #region İşlem Servisleri

        #region Sales

        public ActionResult Sales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new SalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new SalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N"
            };

            var response = SalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Ürün bilgileri gönderimi ile satış

        public ActionResult SalesWithProductInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesWithProductInfo(string creditCardNo, string expireDate, string cvv, string price, string totalAmount, string orderID, int quantity)
        {
            var request = new SalesWithProductInfoRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var item = new Item()
            {
                Number = 1,
                ProductID = "1234",
                ProductCode = "1234",
                Quantity = quantity,
                Price = price,
                TotalAmount = totalAmount,
                Description = "abcdef"
            };

            var itemList = new List<Item>();
            itemList.Add(item);

            request.Order = new SalesWithProductInfoOrderRequest()
            {
                OrderID = orderID,
                Description = string.Empty,
                ItemList = itemList
            };
            request.Transaction = new SalesTransactionRequest()
            {
                Amount = "2000",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N"
            };

            var response = SalesWithProductInfoRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Adres bilgileri gönderimi ile satış

        public ActionResult SalesWithAddressInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesWithAddressInfo(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new SalesWithAddressInfoRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var address = new Address()
            {
                Type = "S",
                Name = "Ali",
                LastName = "Mehmet",
                Company = "ABC",
                Text = "Üsküdar/İstanbul",
                City = "İstanbul",
                Country = "Türkiye",
                PostalCode = "34000",
                PhoneNumber = "02123212121"
            };

            var addressList = new List<Address>();
            addressList.Add(address);

            request.Order = new SalesWithAddressInfoOrderRequest()
            {
                OrderID = orderID,
                Description = string.Empty,
                AddressList = addressList
            };
            request.Transaction = new SalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N"
            };

            var response = SalesWithAddressInfoRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region özel alan bilgileri gönderimi ile satış

        public ActionResult SalesWithCommentInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesWithCommentInfo(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, int number, string text)
        {
            var request = new SalesWithCommentInfoRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var comment = new Comment()
            {
                Number = number,
                Text = text
            };

            var commentList = new List<Comment>();
            commentList.Add(comment);

            request.Order = new SalesWithCommentInfoOrderRequest()
            {
                OrderID = orderID,
                Description = string.Empty,
                CommentList = commentList
            };
            request.Transaction = new SalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N"
            };

            var response = SalesWithCommentInfoRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Installment Sales

        public ActionResult InstallmentSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InstallmentSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, int installmentCnt)
        {
            var request = new InstallmentSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new InstallmentSalesTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N",
                InstallmentCnt = installmentCnt

            };

            var response = InstallmentSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Void - İptal

        public ActionResult Void()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Void(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, string originalRetrefNum)
        {
            var request = new VoidRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;

            terminal.ProvUserID = "PROVRFN";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new VoidTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = "void",
                OriginalRetrefNum = originalRetrefNum,

            };

            var response = VoidRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Refund - İade
        public ActionResult Refund()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Refund(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new RefundRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;

            terminal.ProvUserID = "PROVRFN";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new RefundTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.refund.ToString()

            };

            var response = RefundRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

            //return View(response);

        }
        #endregion

        #region Ötemeli Satış
        public ActionResult DelaySales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DelaySales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, int delayDayCount)
        {
            var request = new DelaySalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new DelaySalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N",
                DelayDayCount = delayDayCount
            };

            var response = DelaySalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Peşinatlı Satış
        public ActionResult DownPaymentSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DownPaymentSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, int downPaymentRate, int installmentCnt)
        {
            var request = new DownPaymentSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new DownPaymentSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N",
                DownPaymentRate = downPaymentRate,
                InstallmentCnt = installmentCnt
            };

            var response = DownPaymentSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Bonus Kullanımı Satış
        public ActionResult RewardSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RewardSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, string usedAmount)
        {
            var request = new RewardSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var rewardRequest = new RewardRequest()
            {
                Type = "BNS",
                UsedAmount = usedAmount

            };

            var rewardList = new List<RewardRequest>();
            rewardList.Add(rewardRequest);

            request.Transaction = new RewardSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N",
                RewardList = rewardList
            };

            var response = RewardSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Firma Bonus Kullanımı Satış
        public ActionResult FirmRewardSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FirmRewardSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, string usedAmount)
        {
            var request = new FirmRewardSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var rewardRequest = new RewardRequest()
            {
                Type = "FBB",
                UsedAmount = usedAmount

            };

            var rewardList = new List<RewardRequest>();
            rewardList.Add(rewardRequest);

            request.Transaction = new FirmRewardSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N",
                RewardList = rewardList
            };

            var response = FirmRewardSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Player Çek Kullanımı Satış
        public ActionResult PlayerChequeSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlayerChequeSales(string creditCardNo, string expireDate, string cvv, string ID, int count, string transactionAmount, string orderID, string amount, string bitmap)
        {

            var request = new PlayerChequeSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var chequeRequest = new ChequeRequest()
            {
                Type = "P",
                Amount = amount,
                Count = count,
                ID = ID,
                Bitmap = bitmap
            };

            var chequeList = new List<ChequeRequest>();
            chequeList.Add(chequeRequest);

            request.Transaction = new PlayerChequeSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "N",
                ChequeList = chequeList
            };

            var response = PlayerChequeSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Sözünüze Ürün Çek Kullanımı Satış
        public ActionResult ProductCheque()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductCheque(string creditCardNo, string expireDate, string cvv, string ID, int count, string transactionAmount, string orderID, string amount, string bitmap)
        {

            var request = new ProductChequeRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var chequeRequest = new ChequeRequest()
            {
                Type = "S",
                Amount = amount,
                Count = count,
                ID = ID,
                Bitmap = bitmap
            };

            var chequeList = new List<ChequeRequest>();
            chequeList.Add(chequeRequest);

            request.Transaction = new ProductChequeTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "n",
                ChequeList = chequeList
            };

            var response = ProductChequeRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Preauth

        public ActionResult Preauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Preauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new PreauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new PreauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.preauth.ToString(),
                MotoInd = "N"
            };

            var response = PreauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

            //return View(response);

        }

        #endregion

        #region Postauth

        public ActionResult Postauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Postauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new PostauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new PostauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.postauth.ToString(),
                MotoInd = "N"
            };

            var response = PostauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

            //return View(response);

        }

        #endregion

        #region Tüketici Kredisi

        public ActionResult ExtentedCreditSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtentedCreditSales(string creditCardNo, string expireMonth, string expireYear, string cvv, string transactionAmount, string orderID, string installmentCount)
        {
            var request = new Sale3DPayRequest();

            request.apiversion = settings3D.apiversion;
            request.mode = settings3D.mode;


            request.terminalid = "30691298";
            request.terminaluserid = "PROVAUT";
            request.terminalprovuserid = "PROVAUT";
            request.terminalmerchantid = "7000679";
            request.successurl = "http://localhost:4336/Home/OOSSuccess";
            request.errorurl = "http://localhost:4336/Home/OOSError";
            request.customeremailaddress = "eticaret@garanti.com.tr";
            request.customeripaddress = "127.0.0.1";
            request.secure3dsecuritylevel = "CUSTOM_PAY";
            request.orderid = orderID;
            request.txnamount = transactionAmount;
            request.txntype = "extendedcredit";
            request.txninstallmentcount = installmentCount;
            request.txncurrencycode = "949";
            request.storekey = "12345678";
            request.txntimestamp = DateTime.Now.Ticks.ToString();
            request.cardnumber = creditCardNo;
            request.cardexpiredatemonth = expireMonth;
            request.cardexpiredateyear = expireYear;
            request.cardcvv2 = cvv;

            var form = Sale3DPayRequest.Execute(request, settings3D);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();

            return View();

            /* var request = new ExtentedCreditSalesRequest();
             request.Version = settings.Version;
             request.Mode = settings.Mode;
             request.Terminal = terminal;

             request.Card = new Card()
             {
                 CVV2 = cvv,
                 ExpireDate = expireDate,
                 Number = creditCardNo

             };
             request.Customer = new Customer()
             {
                 EmailAddr = "eticaret@garanti.com.tr",
                 IPAddress = "127.0.0.1"
             };
             request.Order = new Order()
             {
                 OrderID = orderID,
                 Description = string.Empty
             };
             request.Transaction = new ExtentedCreditSalesTransactionRequest()
             {
                 Amount = transactionAmount,
                 InstallmentCnt = installmentCount,
                 CurrencyCode = 949,
                 Type = TransactionTypeEnum.extendedcredit.ToString(),
                 MotoInd = "N"
             };

             var response = ExtentedCreditSalesRequest.Execute(request, settings);
             ServicesXmlResponse responseMessage = new ServicesXmlResponse();
             responseMessage.XmlResponse = response;
             return View(responseMessage);*/

        }

        #endregion

        #region DCC Sales

        public ActionResult DCCSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DCCSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, int currency, string originalRetrefNum)
        {


            var request = new DCCSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            terminal.MerchantID = "3424113";
            terminal.ID = "30690133";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var dcc = new DCC();
            dcc.Currency = currency;

            request.Transaction = new DCCSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "H",
                SubType = "dcc",
                DCC = dcc,
                OriginalRetrefNum = originalRetrefNum // sorgu sonucu dönen değeri alacaktır.
            };

            var response = DCCSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Firma Kart Eşleştirme

        public ActionResult FirmCardRel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FirmCardRel(string creditCardNo, string expireDate, string cvv, string firmCardNo)
        {
            var request = new FirmCardRelRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            terminal.ID = "30690168";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };
            request.Transaction = new FirmCardRelTransactionRequest()
            {
                Amount = "1",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.firmcardrel.ToString(),
                MotoInd = "H",
                FirmCardNo = firmCardNo
            };

            var response = FirmCardRelRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Firma Kart Satış

        public ActionResult FirmCardSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FirmCardSales(string transactionAmount, string firmCreditCardNo, string orderID)
        {
            var request = new FirmCardSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            terminal.ID = "30690168";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = firmCreditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new FirmCardSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.firmcardsales.ToString(),
                MotoInd = "N"
            };

            var response = FirmCardSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Firma Kart Ön Oto.

        public ActionResult FirmCardPreauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FirmCardPreauth(string transactionAmount, string firmCreditCardNo, string orderID)
        {
            var request = new FirmCardPreauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            terminal.ID = "30690168";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = firmCreditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new FirmCardPreauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.firmcardpreauth.ToString(),
                MotoInd = "N"
            };

            var response = FirmCardPreauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Ortak Kart Satış
        public ActionResult CommercialCardExtendedCredit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CommercialCardExtendedCredit(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new CommercialCardExtendedCreditRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var paymentRequest = new PaymentRequest()
            {
                Number = 1,
                DueDate = "20181221",
                Amount = "1200"
            };

            var paymentList = new List<PaymentRequest>();
            paymentList.Add(paymentRequest);

            paymentRequest = new PaymentRequest()
            {
                Number = 2,
                DueDate = "20190114",
                Amount = "1200"
            };
            paymentList.Add(paymentRequest);

            var commercialCardExtendedCredit = new CommercialCardExtendedCredit();
            commercialCardExtendedCredit.PaymentList = paymentList;

            request.Transaction = new CommercialCardExtendedCreditTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                InstallmentCnt = 2,
                Type = TransactionTypeEnum.commercialcardextendedcredit.ToString(),
                MotoInd = "N",
                CommercialCardExtendedCredit = commercialCardExtendedCredit
            };

            var response = CommercialCardExtendedCreditRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Ortak Kart Preauth

        public ActionResult CommercialCardPreauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CommercialCardPreauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new CommercialCardPreauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new CommercialCardPreauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.commercialcardpreauth.ToString(),
                MotoInd = "H"
            };

            var response = CommercialCardPreauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Sms Preauth

        public ActionResult SMSPreauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SMSPreauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new SMSPreauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            request.Transaction = new SMSPreauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.preauth.ToString(),
                SubType = "sms",
                MotoInd = "N"
            };

            var response = SMSPreauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Sms Postauth 

        public ActionResult SMSPostauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SMSPostauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, string smsPassword)
        {


            var request = new SMSPostauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var verification = new Verification();
            verification.SMSPassword = smsPassword;
            verification.ExtreInfo = "";
            verification.Identity = "";

            request.Transaction = new SMSPostauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.postauth.ToString(),
                MotoInd = "N",
                SubType = "sms",
                Verification = verification
            };

            var response = SMSPostauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Ekstre Preauth

        public ActionResult ExtrePreauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtrePreauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, string extreInfo)
        {
            var request = new ExtrePreauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var verification = new Verification();
            verification.SMSPassword = "";
            verification.ExtreInfo = extreInfo;
            verification.Identity = "";

            request.Transaction = new ExtrePreauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.preauth.ToString(),
                SubType = "extre",
                MotoInd = "N",
                Verification = verification
            };

            var response = ExtrePreauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Ekstre Postauth 

        public ActionResult ExtrePostauth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtrePostauth(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID, string extreInfo)
        {


            var request = new ExtrePostauthRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var verification = new Verification();
            verification.SMSPassword = "";
            verification.ExtreInfo = extreInfo;
            verification.Identity = "";

            request.Transaction = new ExtrePostauthTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.postauth.ToString(),
                MotoInd = "H",
                SubType = "extre",
                Verification = verification
            };

            var response = ExtrePostauthRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Sabit Tekrarlı Satış

        public ActionResult RecurringSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecurringSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new RecurringSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            var recurringRequest = new RecurringRequest();
            recurringRequest.TotalPaymentNum = "2"; // tekrar sayısı girilir.
            recurringRequest.FrequencyInterval = "2"; // tekrar sıklığının girildiği alandır. Ör: 2 girilirse type W için iki haftada bir anlamına gelir.
            recurringRequest.FrequencyType = "D";  // tekrar tipi girilir. Günlük: D, Haftalık: W, Aylık: M, Yıllık: Y
            recurringRequest.Type = "R"; // tekrarlı işlem tipi
            recurringRequest.StartDate = "20181201"; //YYYYMMGG
            recurringRequest.RecurringRetryAttemptCount = "10"; // red alan işlemin kaç gün tekrarlanacağı bilgisi
            recurringRequest.RetryAttemptEmail = "eticaret@garanti.com.tr"; // işlem durumunun gönderileceği adres

            request.Order = new RecurringSalesOrderRequest()
            {
                OrderID = orderID,
                Description = string.Empty,
                Recurring = recurringRequest
            };

            request.Transaction = new RecurringSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "Y"
            };

            var response = RecurringSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Değişken Tekrarlı Satış

        public ActionResult VRecurringSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VRecurringSales(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new VRecurringSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            var paymentRequest = new RecurringPaymentRequest()
            {
                PaymentNum = 1,
                Amount = "100"
            };

            var paymentList = new List<RecurringPaymentRequest>();
            paymentList.Add(paymentRequest);

            paymentRequest = new RecurringPaymentRequest()
            {
                PaymentNum = 2,
                Amount = "100"
            };
            paymentList.Add(paymentRequest);

            var recurring = new Recurring();
            recurring.PaymentList = paymentList;
            recurring.TotalPaymentNum = "2"; // tekrar sayısı girilir.
            recurring.FrequencyInterval = "1"; // tekrar sıklığının girildiği alandır. Ör: 2 girilirse type W için iki haftada bir anlamına gelir.
            recurring.FrequencyType = "M";  // tekrar tipi girilir. Günlük: D, Haftalık: W, Aylık: M, Yıllık: Y
            recurring.Type = "R"; // değişken tekrarlı işlem tipi
            recurring.StartDate = "20181201"; // YYYYMMGG
            recurring.RecurringRetryAttemptCount = "10"; // red alan işlemin kaç gün tekrarlanacağı bilgisi
            recurring.RetryAttemptEmail = "eticaret@garanti.com.tr"; // işlem durumunun gönderileceği adres

            request.Order = new VRecurringSalesOrderRequest()
            {
                OrderID = orderID,
                Description = string.Empty,
                Recurring = recurring
            };

            request.Transaction = new VRecurringSalesTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.sales.ToString(),
                MotoInd = "Y"
            };

            var response = VRecurringSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Tekrarlı İptal

        public ActionResult RecurringVoid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecurringVoid(string creditCardNo, string expireDate, string cvv, string orderID)
        {
            var request = new RecurringVoidRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;

            terminal.ProvUserID = "PROVRFN";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,  // Tekrarlı yapılan bir satış işlemindeki orderID buraya yazılmalıdır. Satışı olmayan bir işlemin iptali olmaz.
                Description = string.Empty
            };
            request.Transaction = new RecurringVoidTransactionRequest()
            {
                Amount = "1",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.recurringvoid.ToString()
            };

            var response = RecurringVoidRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Tekrarlı Satış Update

        public ActionResult RecurringUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecurringUpdate(string creditCardNo, string expireDate, string cvv, string orderID)
        {
            var request = new RecurringUpdateRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            var paymentRequest = new RUpdatePaymentRequest()
            {
                PaymentNum = 1,
                Amount = "101"
            };

            var paymentList = new List<RUpdatePaymentRequest>();
            paymentList.Add(paymentRequest);

            paymentRequest = new RUpdatePaymentRequest()
            {
                PaymentNum = 2,
                Amount = "101"
            };
            paymentList.Add(paymentRequest);

            var recurring = new RecurringUpdate();
            recurring.PaymentList = paymentList;

            request.Order = new RecurringUpdateOrderRequest()
            {
                OrderID = orderID,
                Description = string.Empty,
                Recurring = recurring
            };

            request.Transaction = new RecurringUpdateTransactionRequest()
            {
                Amount = "1",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.recurringupdate.ToString(),
                MotoInd = "H"
            };

            var response = RecurringUpdateRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }

        #endregion

        #region Fatura Ödeme

        public ActionResult UtilityPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UtilityPayment(string creditCardNo, string expireDate, string cvv, string subscriberCode, string institutionCode, string invoiceID, string invoiceAmount)
        {
            var request = new UtilityPaymentRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var utilitypayment = new UtilityPaymentListRequest();
            utilitypayment.Amount = invoiceAmount;
            utilitypayment.SubscriberCode = subscriberCode;
            utilitypayment.InstitutionCode = institutionCode;
            utilitypayment.InvoiceID = invoiceID;

            request.Transaction = new UtilityPaymentTransactionRequest()
            {
                Amount = invoiceAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.utilitypayment.ToString(),
                MotoInd = "H",
                UtilityPayment = utilitypayment
            };

            var response = UtilityPaymentRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);


        }

        #endregion

        #region GSM TL Ödeme

        public ActionResult GsmUnitSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GsmUnitSales(string creditCardNo, string expireDate, string cvv, string subscriberCode, string institutionCode, string unitID, string quantity, string invoiceAmount)
        {
            var request = new GsmUnitSalesRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var gsmUnitSales = new GSMUnitSalesListRequest();
            gsmUnitSales.Amount = invoiceAmount;
            gsmUnitSales.SubscriberCode = subscriberCode;
            gsmUnitSales.InstitutionCode = institutionCode;
            gsmUnitSales.UnitID = unitID;
            gsmUnitSales.Quantity = quantity;

            request.Transaction = new GsmUnitSalesTransactionRequest()
            {
                Amount = invoiceAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.gsmunitsales.ToString(),
                MotoInd = "H",
                GSMUnitSales = gsmUnitSales
            };

            var response = GsmUnitSalesRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region BonusPay Ödeme

        public ActionResult BonusPay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BonusPay(string gsmNumber, string paymentType, string transactionAmount)
        {
            var request = new BonusPayRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var cepBank = new CepBankRequest();
            cepBank.PaymentType = paymentType;
            cepBank.GSMNumber = gsmNumber;

            request.Transaction = new BonusPayTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.cepbank.ToString(),
                MotoInd = "H",
                CepBank = cepBank
            };

            var response = BonusPayRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region BonusPay İptal

        public ActionResult BonusPayVoid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BonusPayVoid(string transactionAmount, string originalRetrefNum)
        {
            var request = new BonusPayVoidRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            terminal.ProvUserID = "PROVRFN";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            request.Transaction = new BonusPayVoidTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.cepbankvoid.ToString(),
                OriginalRetrefNum = originalRetrefNum,
            };

            var response = BonusPayVoidRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #endregion

        #region Sorgu Servisleri

        #region Bonus Sorgulama
        public ActionResult RewardInquiry()
        {
            return View();
        }

        #region Bonus Sorgulama/Deseriliaze Yöntem ile
        //[HttpPost]
        //public ActionResult RewardInquiry(int? a)
        //{
        //    var request = new RewardingRequest();
        //    request.Version = settings.Version;
        //    request.Mode = settings.Mode;
        //    request.Terminal = terminal;

        //    request.Card = new Card()
        //    {
        //        CVV2 = "",
        //        ExpireDate = "0514",
        //        Number = "5586990000001076"

        //    };
        //    request.Customer = new Customer()
        //    {
        //        EmailAddress = "eticaret@garanti.com.tr",
        //        IPAddress = "127.0.0.1"
        //    };

        //    request.Order = new Order()
        //    {
        //        OrderID = "1",
        //        Description = string.Empty
        //    };
        //    request.Transaction = new RewardingTransactionRequest()
        //    {
        //        Amount = "100",
        //        CurrencyCode = 949,
        //        Type = TransactionTypeEnum.rewardinq.ToString(),
        //        MotoInd = "H",
        //        CardholderPresentCode = "0"
        //    };

        //    var response = RewardingRequest.Execute(request, settings);
        //    return View(response);

        //}
        #endregion

        [HttpPost]
        public ActionResult RewardInquiry(string creditCardNo, string expireDate, string cvv)
        {
            var request = new RewardInquiryRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };
            request.Transaction = new RewardInquiryTransactionRequest()
            {
                Amount = "1",   // AMount alanu boş gönderilmemelidir. Minimum 1 gönderilmelidir.
                CurrencyCode = 949,
                Type = TransactionTypeEnum.rewardinq.ToString(),
                MotoInd = "H",
                CardholderPresentCode = "0"
            };

            var response = RewardInquiryRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Tüketici Kredisi Sorgulama

        public ActionResult ExtendedCreditInquiry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtendedCreditInquiry(string creditCardNo, string expireDate, string cvv, int installmentCnt, string transactionAmount)
        {
            var request = new ExtendedCreditInquiryRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };
            request.Transaction = new ExtendedCreditInquiryTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.extendedcreditinq.ToString(),
                InstallmentCnt = installmentCnt,
                MotoInd = "H",
                CardholderPresentCode = "0"
            };

            var response = ExtendedCreditInquiryRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Ortak Kart Limit Sorgulama
        public ActionResult CommercialCardLimitInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CommercialCardLimitInq(string creditCardNo, string expireDate, string cvv, string transactionAmount)
        {
            var request = new CommercialCardLimitInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };
            request.Transaction = new CommercialCardLimitInqTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.commercialcardlimitinq.ToString(),
                MotoInd = "H",
                CardholderPresentCode = "0"
            };

            var response = CommercialCardLimitInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region DCC Sorgulama
        public ActionResult DccInquiry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DccInquiry(string creditCardNo, string expireDate, string cvv, string transactionAmount, string orderID)
        {
            var request = new DccInquiryRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            terminal.MerchantID = "3424113";
            terminal.ID = "30690133";
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };

            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new DccInquiryTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.dccinq.ToString(),
                MotoInd = "H",
                CardholderPresentCode = "0"
            };

            var response = DccInquiryRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }
        #endregion

        #region Fatura Sorgulama
        public ActionResult UtilityPaymentInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UtilityPaymentInq(string creditCardNo, string expireDate, string cvv, string subscriberCode, string institutionCode)
        {
            var request = new UtilityPaymentInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var utilityPaymentInq = new UtilityPaymentInq();
            utilityPaymentInq.SubscriberCode = subscriberCode;
            utilityPaymentInq.InstitutionCode = institutionCode;

            request.Transaction = new UtilityPaymentInqTransactionRequest()
            {
                Amount = "10000",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.utilitypaymentinq.ToString(),
                MotoInd = "H",
                UtilityPaymentInq = utilityPaymentInq
            };

            var response = UtilityPaymentInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region GSM TL Sorgulama
        public ActionResult GsmUnitInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GsmUnitInq(string creditCardNo, string expireDate, string cvv, string subscriberCode, string institutionCode, string quantity)
        {
            var request = new GsmUnitInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var gsmUnitInq = new GSMUnitInq();
            gsmUnitInq.SubscriberCode = subscriberCode;
            gsmUnitInq.InstitutionCode = institutionCode;
            gsmUnitInq.Quantity = quantity;

            request.Transaction = new GSMUnitInqTransactionRequest()
            {
                Amount = "10000",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.gsmunitinq.ToString(),
                MotoInd = "H",
                GSMUnitInq = gsmUnitInq
            };

            var response = GsmUnitInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }
        #endregion

        #region BonusPay Bonus Sorgulama

        public ActionResult BonusPayInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BonusPayInq(string gsmNumber, string paymentType, string transactionAmount)
        {
            var request = new BonusPayInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var cepBank = new CepBankRequest();
            cepBank.PaymentType = paymentType;
            cepBank.GSMNumber = gsmNumber;

            request.Transaction = new BonusPayInqTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                Type = TransactionTypeEnum.cepbankbns.ToString(),
                MotoInd = "N",
                CepBank = cepBank
            };

            var response = BonusPayInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region TCKN Doğrulama Sorgulama
        public ActionResult IdentityInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IdentityInq(string creditCardNo, string expireDate, string cvv, string identity)
        {


            var request = new IdentityInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = cvv,
                ExpireDate = expireDate,
                Number = creditCardNo

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var verification = new IVerification();
            verification.Identity = identity;

            request.Transaction = new IdentityInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.identifyinq.ToString(),
                MotoInd = "H",
                Verification = verification
            };

            var response = IdentityInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);

        }
        #endregion

        #region Sipariş Sorgulama

        public ActionResult OrderInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderInq(string orderID)
        {
            var request = new OrderInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new OrderInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.orderinq.ToString()
            };

            var response = OrderInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Sipariş Detay Sorgulama

        public ActionResult OrderHistoryInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderHistoryInq(string orderID)
        {
            var request = new OrderHistoryInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new OrderHistoryInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.orderhistoryinq.ToString()
            };

            var response = OrderHistoryInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Sipariş Tarih Aralığı Sorgulama

        public ActionResult OrderListInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderListInq(string startDate, string endDate)
        {
            var request = new OrderListInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new OrderListInqOrderRequest()
            {
                OrderID = "",
                Description = string.Empty,
                StartDate = startDate,
                EndDate = endDate,
                ListPageNum = 1
            };
            request.Transaction = new OrderListInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.orderlistinq.ToString()
            };

            var response = OrderListInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Batch Sorgulama

        public ActionResult BatchInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BatchInq(string batchNum)
        {
            var request = new BatchInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new BatchInqOrderRequest()
            {
                OrderID = "",
                Description = string.Empty,
                ListPageNum = 1
            };
            request.Transaction = new BatchInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.batchinq.ToString(),
                BatchNum = batchNum
            };

            var response = BatchInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region BIN Sorgulama

        public ActionResult BINInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BINInq(string cardType, string groupType)
        {
            var request = new BINInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };

            var binInq = new BINInqTransaction();
            binInq.CardType = cardType;
            binInq.Group = groupType;

            request.Transaction = new BINInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.bininq.ToString(),
                _BINInq = binInq
            };

            var response = BINInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Ürün Sorgulama

        public ActionResult OrderItemInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderItemInq(string orderID)
        {
            var request = new OrderItemInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };
            request.Transaction = new OrderItemInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.orderiteminq.ToString()
            };

            var response = OrderItemInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Kredi Kartı ile İşlem Sorgulama

        public ActionResult CardtxnListInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CardtxnListInq(string startDate, string endDate, string crediCard)
        {
            var request = new CardtxnListInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = crediCard

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new CardtxnListInqOrderRequest()
            {
                OrderID = "",
                Description = string.Empty,
                StartDate = startDate,
                EndDate = endDate,
                ListPageNum = 1
            };
            request.Transaction = new CardtxnListInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.cardtxnlistinq.ToString()
            };

            var response = CardtxnListInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Gün Sonu Sorgulama

        public ActionResult SettlementInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SettlementInq(string date)
        {
            var request = new SettlementInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = "",
                Description = string.Empty
            };
            request.SettlementInq = new SettlementInq()
            {
                Date = date
            };
            request.Transaction = new SettlementInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.settlementinq.ToString()
            };

            var response = SettlementInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region BonusPay İşlem Sorgulama

        public ActionResult CepBankInq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CepBankInq(string orderID, string gsmNumber)
        {
            var request = new CepBankInqRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var cepBank = new CepBankRequest();
            cepBank.GSMNumber = gsmNumber;

            request.Transaction = new CepBankInqTransactionRequest()
            {
                Amount = "100",
                CurrencyCode = 949,
                Type = TransactionTypeEnum.cepbankinq.ToString(),
                CepBankInq = cepBank
            };

            var response = CepBankInqRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #endregion

        #region 3D Secure

        #region 3D Secure Satış
        public ActionResult Sale3DSecure()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sale3DSecure(string creditCardNo, string expireMonth, string expireYear, string cvv, string transactionAmount, string orderID)
        {
            var request = new Sale3DSecureRequest();

            request.apiversion = settings3D.apiversion;
            request.mode = settings3D.mode;
            request.terminalid = "30691297";
            request.terminaluserid = "PROVAUT";
            request.terminalprovuserid = "PROVAUT";
            request.terminalmerchantid = "7000679";


            request.successurl = "http://localhost:4336/Home/Success";
            request.errorurl = "http://localhost:4336/Home/Error";
            request.customeremailaddress = "eticaret@garanti.com.tr";
            request.customeripaddress = "127.0.0.1";
            request.secure3dsecuritylevel = "3D";
            request.orderid = orderID;
            request.txnamount = transactionAmount;
            request.txntype = "sales";
            request.txninstallmentcount = "";
            request.txncurrencycode = "949";
            request.storekey = "12345678";
            request.txntimestamp = DateTime.Now.Ticks.ToString();
            request.cardnumber = creditCardNo;
            request.cardexpiredatemonth = expireMonth;
            request.cardexpiredateyear = expireYear;
            request.cardcvv2 = cvv;
            request.lang = "tr";
            request.refreshtime = "5";

            var form = Sale3DSecureRequest.Execute(request, settings3D);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();

            return View();
        }
        #endregion

        #region 3D OOS Satış
        public ActionResult Sale3DOOSPay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sale3DOOSPay(string transactionAmount, string orderID, string secure3dsecuritylevel)
        {
            var request = new Sale3DOOSPayRequest();

            request.apiversion = settings3D.apiversion;
            request.mode = settings3D.mode;
            request.terminalid = "30691299";
            request.terminaluserid = "PROVOOS";
            request.terminalprovuserid = "PROVOOS";
            request.terminalmerchantid = "7000679";
            request.successurl = "http://localhost:4336/Home/OOSSuccess";
            request.errorurl = "http://localhost:4336/Home/OOSError";
            request.customeremailaddress = "eticaret@garanti.com.tr";
            request.customeripaddress = "127.0.0.1";
            request.secure3dsecuritylevel = secure3dsecuritylevel;
            request.orderid = orderID;
            request.txnamount = transactionAmount;
            request.txntype = "sales";
            request.txninstallmentcount = "";
            request.txncurrencycode = "949";
            request.storekey = "12345678";
            request.txntimestamp = DateTime.Now.Ticks.ToString();
            request.lang = "tr";
            request.refreshtime = "10";
            request.companyname = "deneme";

            var form = Sale3DOOSPayRequest.Execute(request, settings3D);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();

            return View();
        }
        #endregion

        #region 3D Pay Satış
        public ActionResult Sale3DPay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sale3DPay(string creditCardNo, string expireMonth, string expireYear, string cvv, string transactionAmount, string orderID, string secure3dsecuritylevel)
        {
            var request = new Sale3DPayRequest();

            request.apiversion = settings3D.apiversion;
            request.mode = settings3D.mode;
            request.terminalid = "30691298";
            request.terminaluserid = "PROVAUT";
            request.terminalprovuserid = "PROVAUT";
            request.terminalmerchantid = "7000679";
            request.successurl = "http://localhost:4336/Home/OOSSuccess";
            request.errorurl = "http://localhost:4336/Home/OOSError";
            request.customeremailaddress = "eticaret@garanti.com.tr";
            request.customeripaddress = "127.0.0.1";
            request.secure3dsecuritylevel = secure3dsecuritylevel;
            request.orderid = orderID;
            request.txnamount = transactionAmount;
            request.txntype = "sales";
            request.txninstallmentcount = "";
            request.txncurrencycode = "949";
            request.storekey = "12345678";
            request.txntimestamp = DateTime.Now.Ticks.ToString();
            request.cardnumber = creditCardNo;
            request.cardexpiredatemonth = expireMonth;
            request.cardexpiredateyear = expireYear;
            request.cardcvv2 = cvv;

            var form = Sale3DPayRequest.Execute(request, settings3D);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();

            return View();
        }
        #endregion

        #region OOS Pay Satış
        public ActionResult SaleOOSPay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaleOOSPay(string transactionAmount, string orderID)
        {
            var request = new SaleOOSPayRequest();

            request.apiversion = settings3D.apiversion;
            request.mode = settings3D.mode;
            request.terminalid = "30691300";
            request.terminaluserid = "PROVOOS";
            request.terminalprovuserid = "PROVOOS";
            request.terminalmerchantid = "7000679";
            request.successurl = "http://localhost:4336/Home/OOSSuccess";
            request.errorurl = "http://localhost:4336/Home/OOSError";
            request.customeremailaddress = "eticaret@garanti.com.tr";
            request.customeripaddress = "127.0.0.1";
            request.secure3dsecuritylevel = "OOS_PAY";
            request.orderid = orderID;
            request.txnamount = transactionAmount;
            request.txntype = "sales";
            request.txninstallmentcount = "";
            request.txncurrencycode = "949";
            request.storekey = "12345678";
            request.txntimestamp = DateTime.Now.Ticks.ToString();
            request.refreshtime = "10";
            request.lang = "tr";
            request.companyname = "deneme";

            var form = SaleOOSPayRequest.Execute(request, settings3D);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();

            return View();
        }
        #endregion

        #region Custom PAY / GarantiPay Satış
        public ActionResult GarantiPay()
        {
            return View();
        }

        // web üzerinden garanti pay isteğinin oluşturulması
        [HttpPost]
        public ActionResult GarantiPay(string transactionAmount, string orderID)
        {
            var request = new GarantiPayRequest();

            request.apiversion = settings3D.apiversion;
            request.mode = settings3D.mode;
            request.terminalid = "30690133";
            request.terminaluserid = "PROVOOS";
            request.terminalprovuserid = "PROVOOS";
            request.terminalmerchantid = "3424113";
            request.successurl = "http://localhost:4336/Home/GarantiPaySuccess";
            request.errorurl = "http://localhost:4336/Home/GarantiPayError";
            request.customeremailaddress = "eticaret@garanti.com.tr";
            request.customeripaddress = "127.0.0.1";
            request.secure3dsecuritylevel = "CUSTOM_PAY";
            request.orderid = orderID;
            request.txnamount = transactionAmount;
            request.txntype = "gpdatarequest";
            request.txnsubtype = "sales";
            request.txninstallmentcount = "";
            request.totallinstallmentcount = "2";
            request.installmentamount1 = "110";
            request.installmentamount2 = "120";
            request.installmentnumber1 = "2";
            request.installmentnumber2 = "3";
            request.bnsuseflag = "N";
            request.chequeuseflag = "N";
            request.fbbuseflag = "N";
            request.garantipay = "Y";
            request.txntimeoutperiod = "300";
            request.installmentratewithreward1 = "1000";
            request.installmentratewithreward2 = "2000";
            request.companyname = "DENEME";
            request.txncurrencycode = "949";
            request.storekey = "12345678";
            request.txntimestamp = DateTime.Now.Ticks.ToString();
            request.lang = "tr";
            request.refreshtime = "1";

            var form = GarantiPayRequest.Execute(request, settings3D);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();

            return View();
        }
        #endregion

        #region MailOrder ile GarantiPay 

        public ActionResult GarantiPayMO()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GarantiPayMO(string transactionAmount, string orderID, string tckn, string gsmNumber)
        {
            var request = new GarantiPayMORequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };


            var gpInstallments = new GPInstallments()
            {
                Installmentnumber = 2,
                Installmentamount = "10200"
            };
            var installementList = new List<GPInstallments>();
            installementList.Add(gpInstallments);

            gpInstallments = new GPInstallments()
            {
                Installmentnumber = 4,
                Installmentamount = "10400"
            };
            installementList.Add(gpInstallments);

            var garantiPaY = new GarantiPaY()
            {
                bnsuseflag = "N",
                fbbuseflag = "N",
                chequeuseflag = "N",
                mileuseflag = "N",
                CompanyName = "Abc",
                OrderInfo = "ürün hakkında bilgi içerir.",
                TxnTimeOutPeriod = "300",
                NotifSendInd = "Y",
                TCKN = (tckn == null ? "" : tckn),
                GSMNumber = (gsmNumber == null ? "" : gsmNumber),
                InstallmentOnlyForCommercialCard = "N",
                TotalInstallmentCount = "2",
                GPInstallments = installementList,
                ReturnUrl = "https://abc.abc.com/abc"
            };

            request.Transaction = new GarantiPayMOTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                CardholderPresentCode = 0,
                ReturnServerUrl = "https://abc.abc.com/abc",
                SubType = "sales",
                Type = "gpdatarequest",
                MotoInd = "Y",
                GarantiPaY = garantiPaY,
            };

            var response = GarantiPayMORequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region GarantiPay App

        public ActionResult GarantiPayApp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GarantiPayApp(string transactionAmount, string orderID, string tckn, string gsmNumber)
        {
            var request = new GarantiPayAppRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };


            var gpInstallments = new GPIns()
            {
                Installmentnumber = 2,
                Installmentamount = "10200"
            };
            var installementList = new List<GPIns>();
            installementList.Add(gpInstallments);

            gpInstallments = new GPIns()
            {
                Installmentnumber = 4,
                Installmentamount = "10400"
            };
            installementList.Add(gpInstallments);

            var garantiPaY = new GPApp()
            {
                bnsuseflag = "N",
                fbbuseflag = "N",
                chequeuseflag = "N",
                mileuseflag = "N",
                CompanyName = "Abc",
                TxnTimeOutPeriod = "300",
                NotifSendInd = "N",
                TCKN = (tckn == null ? "" : tckn),
                GSMNumber = (gsmNumber == null ? "" : gsmNumber),
                InstallmentOnlyForCommercialCard = "N",
                TotalInstallmentCount = "2",
                GPInstallments = installementList,
                ReturnUrl = "https://abc.abc.com/abc"
            };

            request.Transaction = new GarantiPayAppTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                CardholderPresentCode = 0,
                ReturnServerUrl = "https://abc.abc.com/abc",
                SubType = "sales",
                Type = "gpdatarequest",
                MotoInd = "N",
                GarantiPaY = garantiPaY,
            };

            var response = GarantiPayAppRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region GarantiPay Bekleyen İşlemin İptali

        public ActionResult GarantiPayVoid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GarantiPayVoid(string transactionAmount, string orderID, string gpID)
        {
            var request = new GarantiPayVoidRequest();
            request.Version = settings.Version;
            request.Mode = settings.Mode;
            request.Terminal = terminal;

            request.Card = new Card()
            {
                CVV2 = "",
                ExpireDate = "",
                Number = ""

            };
            request.Customer = new Customer()
            {
                EmailAddress = "eticaret@garanti.com.tr",
                IPAddress = "127.0.0.1"
            };
            request.Order = new Order()
            {
                OrderID = orderID,
                Description = string.Empty
            };

            var garantiPayV = new GarantiPayV()
            {
                GPID = gpID,
                Status = "E"
            };

            request.Transaction = new GarantiPayVoidTransactionRequest()
            {
                Amount = transactionAmount,
                CurrencyCode = 949,
                CardholderPresentCode = 0,
                ReturnServerUrl = "",
                Type = "garantipaycancel",
                MotoInd = "N",
                GarantiPayV = garantiPayV,
            };

            var response = GarantiPayVoidRequest.Execute(request, settings);
            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = response;
            return View(responseMessage);
        }

        #endregion

        #region Garanti Pay Error/Success Page
        public ActionResult GarantiPayError()
        {
            string[] keys = Request.Form.AllKeys;
            StringBuilder strForm = new StringBuilder();
            for (int i = 0; i < keys.Length; i++)
            {
                strForm.Append(keys[i] + ": " + Request.Form[keys[i]]);
                strForm.AppendLine();
            }

            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = strForm.ToString();
            return View(responseMessage);
        }

        public ActionResult GarantiPaySuccess()
        {
            // procreturncode == "00"
            if (Request.Form.Get("gphashdata") != null && Request.Form.Get("gphashdata") != "")
            {
                string storeKey = "12345678";
                string gpHash = Request.Form.Get("clientid") + Request.Form.Get("oid") + Request.Form.Get("authcode")
                    + Request.Form.Get("procreturncode") + Request.Form.Get("gpinstallmentamount") + Request.Form.Get("gpinstallment") + storeKey;
                string gphashdata = Request.Form.Get("gphashdata");

                if (Helper.Validate3DReturn(gpHash, gphashdata))
                {
                    string[] keys = Request.Form.AllKeys;
                    StringBuilder strForm = new StringBuilder();
                    for (int i = 0; i < keys.Length; i++)
                    {
                        strForm.Append(keys[i] + ": " + Request.Form[keys[i]]);
                        strForm.AppendLine();
                    }

                    ServicesXmlResponse responseMessage = new ServicesXmlResponse();
                    responseMessage.XmlResponse = strForm.ToString();
                    return View(responseMessage);
                }
                else
                    Response.Write("Hash Doğrulaması Yapılamadı.");
            }
            else
                Response.Write("gpHashData alanı boş. İşlem hatalı.");
            return View();
        }
        #endregion

        #region 3D OOS Pay Error/Success Page
        public ActionResult OOSError()
        {
            string[] keys = Request.Form.AllKeys;
            StringBuilder strForm = new StringBuilder();
            for (int i = 0; i < keys.Length; i++)
            {
                strForm.Append(keys[i] + ": " + Request.Form[keys[i]]);
                strForm.AppendLine();
            }

            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = strForm.ToString();
            return View(responseMessage);
        }

        public ActionResult OOSSuccess()
        {
            //Validation kontrolü yapılır.
            string hash = Request.Form.Get("hash");
            string hashParamsVal = "";
            string storeKey = "12345678";
            string hashParams = Request.Form.Get("hashparams");
            bool valid = false;

            if (hashParams != null && hashParams != "")
            {
                var result = hashParams.Split(':');

                foreach (string param in result)
                {
                    hashParamsVal += Request.Form.Get(param);
                }
                hashParamsVal += storeKey;
                valid = Helper.Validate3DReturn(hashParamsVal, hash);
            }

            if (valid)
            {
                string[] keys = Request.Form.AllKeys;
                StringBuilder strForm = new StringBuilder();
                for (int i = 0; i < keys.Length; i++)
                {
                    strForm.Append(keys[i] + ": " + Request.Form[keys[i]]);
                    strForm.AppendLine();
                }

                ServicesXmlResponse responseMessage = new ServicesXmlResponse();
                responseMessage.XmlResponse = strForm.ToString();
                return View(responseMessage);
            }
            else
                Response.Write("Hash Doğrulaması Yapılamadı.");
            return View();

        }
        #endregion

        #region 3D Error/Success Page
        public ActionResult Error()
        {
            string[] keys = Request.Form.AllKeys;
            StringBuilder strForm = new StringBuilder();
            for (int i = 0; i < keys.Length; i++)
            {
                strForm.Append(keys[i] + ": " + Request.Form[keys[i]]);
                strForm.AppendLine();
            }

            ServicesXmlResponse responseMessage = new ServicesXmlResponse();
            responseMessage.XmlResponse = strForm.ToString();
            return View(responseMessage);
        }

        [HttpPost]
        public ActionResult Success()
        {
            //Validation kontrolü yapılır.
            string hash = Request.Form.Get("hash");
            string hashParamsVal = "";
            string storeKey = "12345678";  // kendi storekey değeri girilmelidir.
            string hashParams = Request.Form.Get("hashparams");
            bool valid = false;

            if (hashParams != null && hashParams != "")
            {
                var result = hashParams.Split(':');

                foreach (string param in result)
                {
                    hashParamsVal += Request.Form.Get(param);
                }
                hashParamsVal += storeKey;
                valid = Helper.Validate3DReturn(hashParamsVal, hash);
            }

            if (valid)
            {
                // işlem başarılı ise değerler alınır.
                if ((Request.Form.Get("mdstatus").ToString() == "1") || (Request.Form.Get("mdstatus").ToString() == "2")
                || (Request.Form.Get("mdstatus").ToString() == "3") || (Request.Form.Get("mdstatus").ToString() == "4"))
                {
                    var secure3DResponse = new Secure3DResponse()
                    {
                        orderID = Request.Form.Get("orderid"),
                        authenticationCode = Server.UrlEncode(Request.Form.Get("cavv")),
                        securityLevel = Server.UrlEncode(Request.Form.Get("eci")),
                        txnID = Server.UrlEncode(Request.Form.Get("xid")),
                        MD = Server.UrlEncode(Request.Form.Get("md")),

                        mode = Request.Form.Get("mode"),
                        apiversion = Request.Form.Get("apiversion"),

                        terminalProvUserID = Request.Form.Get("terminalprovuserid"),
                        installmentCount = Request.Form.Get("txninstallmentcount"),
                        terminalUserID = Request.Form.Get("terminaluserid"),
                        terminalID = Request.Form.Get("clientid"),

                        amount = Request.Form.Get("txnamount"),
                        currencyCode = Request.Form.Get("txncurrencycode"),
                        customerIpAddres = Request.Form.Get("customeripaddress"),
                        customerEmailAddress = Request.Form.Get("customeremailaddress"),
                        terminalMerchantID = Request.Form.Get("terminalmerchantid"),
                        txnType = Request.Form.Get("txntype"),
                        procreturnCode = Request.Form.Get("procreturncode"),
                        authcode = Request.Form.Get("authcode"),
                        response = Request.Form.Get("response"),
                        mdstatus = Request.Form.Get("msstatus"),
                        rnd = Request.Form.Get("rnd"),
                        xmlResponse = ""

                    };

                    var request = new Secure3DCompleteRequest();

                    request.Version = secure3DResponse.apiversion;
                    request.Mode = secure3DResponse.mode;

                    request.Terminal = new Terminal()
                    {
                        ID = secure3DResponse.terminalID,
                        MerchantID = secure3DResponse.terminalMerchantID,
                        ProvUserID = secure3DResponse.terminalProvUserID,
                        UserID = secure3DResponse.terminalUserID
                    };
                    request.Card = new Card()
                    {
                        CVV2 = "",
                        ExpireDate = "",
                        Number = ""

                    };
                    request.Customer = new Customer()
                    {
                        EmailAddress = secure3DResponse.customerEmailAddress,
                        IPAddress = secure3DResponse.customerIpAddres
                    };

                    var secure3D = new Secure3D();
                    secure3D.AuthenticationCode = secure3DResponse.authenticationCode;
                    secure3D.Md = secure3DResponse.MD;
                    secure3D.SecurityLevel = secure3DResponse.securityLevel;
                    secure3D.TxnID = secure3DResponse.txnID;

                    request.Order = new Order()
                    {
                        OrderID = secure3DResponse.orderID,
                        Description = string.Empty
                    };

                    request.Transaction = new Secure3DCompleteTransactionRequest()
                    {
                        Amount = secure3DResponse.amount,
                        CurrencyCode = secure3DResponse.currencyCode,
                        InstallmentCnt = secure3DResponse.installmentCount,
                        Type = secure3DResponse.txnType,
                        MotoInd = "N",
                        CardholderPresentCode = 13,
                        Secure3D = secure3D
                    };


                    var response = Secure3DCompleteRequest.Execute(request, settings);
                    secure3DResponse.xmlResponse = response;
                    return View(secure3DResponse);
                }
                return View();
            }
            else
                Response.Write("Hash Doğrulaması Yapılamadı.");
            return View();
        }
        #endregion

        #endregion

    }

}