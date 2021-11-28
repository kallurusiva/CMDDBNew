using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMSv3.DAL;
using CMSv3.Entities;
using System.Data;


namespace CMSv3.BAL
{
    public class PayPal
    {
        CMSv3.DAL.PayPal objPayPal = new CMSv3.DAL.PayPal();

   
        public DataSet EB_PayPal_RetrieveTX(int vUserID, string vSearchQuery)
        {

            return objPayPal.EB_PayPal_RetrieveTX(vUserID, vSearchQuery); 
        }

        public int EB_PostPaymentDetails_Update(String vTxID, String PytStatus, String PytAmt, String PytCurrency, String vUniqueID, String vItemNumber, String vCustomMsg)
        {
            return objPayPal.EB_PostPaymentDetails_Update(vTxID, PytStatus, PytAmt, PytCurrency, vUniqueID, vItemNumber, vCustomMsg); 
        }

        public DataSet EB_PayPal_RetrieveDetailsByUniqueID(String vUniqueID, String vItemNumber, int vUserID)
        {
            return objPayPal.EB_PayPal_RetrieveDetailsByUniqueID(vUniqueID, vItemNumber, vUserID); 
        }
    }
}
