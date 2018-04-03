using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis;

namespace TurkcellFacebookDunyasi.ServiceConnector.Dummy
{
    public class MobileBillAnalysis
    {
        public static invoiceLevel1[] FillDummyData()
        { 
            invoiceLevel1[] data = new invoiceLevel1[4];

            for (int i = 0; i < 4; i++)
            {
                invoiceLevel1 iLevel = new invoiceLevel1();

                if (i == 0) iLevel.amount = 60;
                if (i == 1) iLevel.amount = 15.059999999999999;
                if (i == 2) iLevel.amount = 0.03;
                if (i == 3) iLevel.amount = 1.31;

                if (i == 0) iLevel.description = "Tarife ve Paket Ücretleri";
                if (i == 1) iLevel.description = "Kullanım Ücretleri";
                if (i == 2) iLevel.description = "Kota Aşım Ücreti";
                if (i == 3) iLevel.description = "Vergiler";
                
                iLevel.id = (i + 1).ToString();

                data[i] = iLevel;
            }

            return data;
        }
    }
}