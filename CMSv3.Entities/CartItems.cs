using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class CartItems
    {
        private string _BookID;
        private string _BookName ;
        private decimal _Price;
        private int _Count;
        private int _Total;
        private string _ImageURL;


        public string BookID
        {
            get { return _BookID; }
            set { _BookID = value; }
        }


        public string BookName
        {
            get { return _BookName; }
            set { _BookName = value; }
        }

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }


        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        public string ImageURL
        {
            get { return _ImageURL; }
            set { _ImageURL = value; }
        }

        

    }
}
