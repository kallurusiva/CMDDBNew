using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class Products
    {
        private int _ProductID;
        private string _ProductName;
        private string _ProductCode;
        private string _ProductPrice;
        private string _ProductDescription;
        private string _ProductBenefits;
        private int _ProductImageID;
        private string _ProductRenewal;
        private bool _Active;
        private int _ProductType;

      


        public int ProductID
        {
            set { _ProductID = value; }
            get { return _ProductID; }
        }


        public string ProductName
        {
            set { _ProductName = value; }
            get { return _ProductName; }
        }


        public string ProductCode
        {
            set { _ProductCode = value; }
            get { return _ProductCode; }
        }

        public string ProductPrice
        {
            set { _ProductPrice = value; }
            get { return _ProductPrice; }
        }

        public string ProductDescription
        {
            set { _ProductDescription = value; }
            get { return _ProductDescription; }
        }

        public string ProductBenefits
        {
            set { _ProductBenefits = value; }
            get { return _ProductBenefits; }
        }

        public int ProductImageID
        {
            set { _ProductImageID = value; }
            get { return _ProductImageID; }
        }


        public string ProductRenewal
        {
            set { _ProductRenewal = value; }
            get { return _ProductRenewal; }
        }


        public bool Active
        {
            set { _Active = value; }
            get { return _Active; }
        }

        public int ProductType
        {
            set { _ProductType = value; }
            get { return _ProductType; }
        }

    }
}
