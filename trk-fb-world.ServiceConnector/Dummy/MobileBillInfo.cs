using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo;

namespace TurkcellFacebookDunyasi.ServiceConnector.Dummy
{
    public class MobileBillInfo
    {
        public static invoiceList FillDummyData()
        {
            invoiceList iList = new ServiceConnector.MobileBillInfo.invoiceList();
            invoice[] arrInv = new invoice[6];

            for (int i = 0; i < 6; i++)
            {
                invoice inv = new invoice();
                inv.invoiceAmount =  (double)LIB.Util.RandomNumber(200, 40);
                inv.invoiceDate = DateTime.Now.AddMonths(i * -1);
                inv.invoiceNumber = "13363104" + LIB.Util.RandomNumber(99, 10).ToString();
                inv.invoiceOpen = false;
                inv.invoiceType = 1;
                inv.isPaid = true;
                inv.notInHobimList = false;
                inv.notReadyDisplay = false;
                inv.paymentLastDate = DateTime.Now.AddDays(i);
                inv.period = DateTime.Now.AddMonths(i * -1).Month.ToString().PadLeft(2, '0');

                arrInv[i] = inv;
            }
            iList.invoicelist = arrInv;
            return iList;
        }
    }
}
