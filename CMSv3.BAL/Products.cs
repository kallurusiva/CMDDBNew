using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class Products
    {

        CMSv3.DAL.Products objProducts = new CMSv3.DAL.Products();

        public int InsertProduct(CMSv3.Entities.Products vObjProducts, int vUserId, CMSv3.Entities.MyImage vImage, int vSelLanguage)
        {

            return objProducts.InsertProduct(vObjProducts, vUserId, vImage, vSelLanguage);
        }

        public DataSet RetrieveAllProducts_ByUserID(int vUserId, string mRetreiveType, int vSelLanguage,int vProductType)
        {
            return objProducts.RetrieveAllProducts_ByUserID(vUserId, mRetreiveType, vSelLanguage, vProductType);
        }

        public DataTable RetrieveAllProducts_ByProductID(int vUserId, int vProductID)
        {
            return objProducts.RetrieveAllProducts_ByProductID(vUserId, vProductID);
        }

        public int UpdateProductsData(CMSv3.Entities.Products vObjProducts, int vUserId, CMSv3.Entities.MyImage vImage, bool vActive)
        {
            return objProducts.UpdateProductsData(vObjProducts, vUserId, vImage, vActive);

        }

        public bool DeleteProductsData(int vUserId, int vProductID)
        {
            return objProducts.DeleteProductsData(vUserId, vProductID);
        }

        public bool InsertUpdate_ProductPriority(int vUserId, int vProductID, bool vActive)
        {
            return objProducts.InsertUpdate_ProductPriority(vUserId, vProductID, vActive);
        }

        public DataSet User_GETAll_Products_ByUserID(int mUserId, int mProductType)
        {
            return objProducts.User_GETAll_Products_ByUserID(mUserId, mProductType);
        }

        public int INFO_Create(int vUserId, string vInfoTitle, string vInfoContent, int vDisplayatWeb)
        {
            return objProducts.INFO_Create(vUserId, vInfoTitle, vInfoContent, vDisplayatWeb); 
        }


        public int INFO_Update(int vUserId, string vInfoTitle, string vInfoContent, int vDisplayatWeb, int vInfoID)
        {
            return objProducts.INFO_Update(vUserId, vInfoTitle, vInfoContent, vDisplayatWeb, vInfoID); 
        }

        public DataSet INFO_RetrieveAll(int vUserId, String vShowItems)
        {
            return objProducts.INFO_RetrieveAll(vUserId, vShowItems);
        }

        public int INFO_Delete(int vUserId, int vInfoID)
        {
            return objProducts.INFO_Delete(vUserId, vInfoID);
        }

        public DataSet INFO_Retrieve_byInfoID(int vINFOid)
        {
            return objProducts.INFO_Retrieve_byInfoID(vINFOid);
        }
    }
}
