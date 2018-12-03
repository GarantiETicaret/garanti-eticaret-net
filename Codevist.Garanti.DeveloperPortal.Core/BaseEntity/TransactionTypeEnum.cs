using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public enum TransactionTypeEnum
    {
        sales,
        refund,
        preauth,
        rewardinq,
        postauth,
        extendedcredit,
        firmcardrel,
        firmcardsales,
        firmcardpreauth,
        commercialcardextendedcredit,
        commercialcardpreauth,
        recurringvoid,
        utilitypayment,
        gsmunitsales,
        cepbank,
        cepbankvoid,
        recurringupdate,
        extendedcreditinq,
        commercialcardlimitinq,
        dccinq,
        utilitypaymentinq,
        gsmunitinq,
        cepbankbns,
        identifyinq,
        orderinq,
        orderhistoryinq,
        orderlistinq,
        batchinq,
        bininq,
        orderiteminq,
        cardtxnlistinq,
        settlementinq,
        cepbankinq
    }
}
