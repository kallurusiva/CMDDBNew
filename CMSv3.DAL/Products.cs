using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CMSv3.Entities;
using System.Data;
using System.Data.SqlClient;

namespace CMSv3.DAL
{
    public class Products
    {

        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;
        DataTable dt;

        string dbString = ConfigurationSettings.AppSettings["CMSdb"].ToString();



        #endregion



        #region SqlConstants

        private const string SP_InsertProducts = "usp_Products_InsertData";
        private const string SP_UpdateProduct_ByUProductId = "usp_Products_Update_ByProductID";
        private const string SP_DeleteProduct_ByUserId = "usp_Products_Delete_ByUserID";
        private const string SP_InsertUpdateProduct_Priority = "usp_Products_InsertUpdate_Priority";

        private const string SP_RetrieveAll_Products_ByUserID = "usp_Products_Retrieve_ByUserID";
        private const string SP_Retrieve_Product_ByProductID = "usp_Products_Retrieve_ByProductID";

        private const string SP_USER_GET_Products_ByUserID = "User_GETAll_Products_ByUserID";


        #endregion


         #region Functionality

      // Constructor to open the dbConnection 
        public Products()
        {

            try
            {
                dbConn = new SqlConnection(dbString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Function to insert record into tblProductDetails table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts and returns 1 if inserted else 0</remarks> 
        /// 
        public int InsertProduct(CMSv3.Entities.Products vObjProducts, int vUserId, CMSv3.Entities.MyImage vImage, int vSelLanguage)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_InsertProducts, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@PdName", SqlDbType.NVarChar).Value = vObjProducts.ProductName;
                dbCmd.Parameters.Add("@PdCode", SqlDbType.NVarChar).Value = vObjProducts.ProductCode;
                dbCmd.Parameters.Add("@PdPrice", SqlDbType.NVarChar).Value = vObjProducts.ProductPrice;
                dbCmd.Parameters.Add("@PdDescription", SqlDbType.NVarChar).Value = vObjProducts.ProductDescription;
                dbCmd.Parameters.Add("@PdBenefits", SqlDbType.NVarChar).Value = vObjProducts.ProductBenefits;

                dbCmd.Parameters.Add("@PdUserID", SqlDbType.Int).Value = vUserId;
                
                dbCmd.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = vImage.ImgName;
                dbCmd.Parameters.Add("@ImageType", SqlDbType.TinyInt).Value = vImage.ImgType;
                dbCmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = vImage.ImgPath;
                dbCmd.Parameters.Add("@ImageActName", SqlDbType.VarChar).Value = vImage.ActualImgName;

                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;
                dbCmd.Parameters.Add("@vActive", SqlDbType.Bit).Value = vObjProducts.Active;
                dbCmd.Parameters.Add("@vProductType", SqlDbType.TinyInt).Value = vObjProducts.ProductType;
                

                

                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }




        /// <summary>
        /// Function to Retrieves records from the tblProductDetails table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves all the records based on UserId and returns a Dataset</remarks> 
        /// 


        public DataSet RetrieveAllProducts_ByUserID(int vUserId, string mRetreiveType, int vSelLanguage, int vProductType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_Products_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@PrdUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@RtrType", SqlDbType.VarChar).Value = mRetreiveType;
                dbCmd.Parameters.Add("@LgType", SqlDbType.VarChar).Value = vSelLanguage;
                dbCmd.Parameters.Add("@vProductType", SqlDbType.TinyInt).Value = vProductType;

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



        }


        public int INFO_Create(int vUserId, string vInfoTitle, string vInfoContent, int vDisplayatWeb)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_INFO_Create]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vInfoTitle", SqlDbType.NVarChar).Value = vInfoTitle;
                dbCmd.Parameters.Add("@vInfoContent", SqlDbType.NVarChar).Value = vInfoContent;
                dbCmd.Parameters.Add("@isDisplay", SqlDbType.Bit).Value = vDisplayatWeb; 
                
                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }


        public int INFO_Update(int vUserId, string vInfoTitle, string vInfoContent, int vDisplayatWeb, int vInfoID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_INFO_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vInfoTitle", SqlDbType.NVarChar).Value = vInfoTitle;
                dbCmd.Parameters.Add("@vInfoContent", SqlDbType.NVarChar).Value = vInfoContent;
                dbCmd.Parameters.Add("@isDisplay", SqlDbType.Bit).Value = vDisplayatWeb;
                dbCmd.Parameters.Add("@vInfoID", SqlDbType.Int).Value = vInfoID;

                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }


        public int INFO_Delete(int vUserId, int vInfoID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_INFO_Delete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vInfoID", SqlDbType.Bit).Value = vInfoID;

                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }


        public DataSet INFO_Retrieve_byInfoID(int vINFOid)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_INFO_Retrieve_ByINFOid", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vINFOid", SqlDbType.Int).Value = vINFOid;
    
                

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



        }


        public DataSet INFO_RetrieveAll(int vUserId, String vShowItems)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_INFO_Retrieve_ByUserID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vShowItems", SqlDbType.VarChar).Value = vShowItems;
                
                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



        }


        /// <summary>
        /// Function to Retrieves a specific record from the tblProductDetails table based on Product id 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves one record based on Product ID  and returns a dataset</remarks> 
        /// 
        public DataTable RetrieveAllProducts_ByProductID(int vUserId, int vProductID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retrieve_Product_ByProductID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = vProductID;

                dbAdap = new SqlDataAdapter(dbCmd);
                //ds = new DataSet();
                dt = new DataTable();

                //dbAdap.Fill(ds);
                dbAdap.Fill(dt);

                //return ds;
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



        }



        /// <summary>
        /// Function to update record into tblProductDetails table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>bool</returns>
        /// <remarks>This function updates and returns number of records updated</remarks> 
        /// 
        public int UpdateProductsData(CMSv3.Entities.Products vObjProducts, int vUserId, CMSv3.Entities.MyImage vImage, bool vActive)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_UpdateProduct_ByUProductId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = vObjProducts.ProductID;
                dbCmd.Parameters.Add("@PdName", SqlDbType.NVarChar).Value = vObjProducts.ProductName;
                dbCmd.Parameters.Add("@PdCode", SqlDbType.NVarChar).Value = vObjProducts.ProductCode;
                dbCmd.Parameters.Add("@PdPrice", SqlDbType.NVarChar).Value = vObjProducts.ProductPrice;
                dbCmd.Parameters.Add("@PdDescription", SqlDbType.NVarChar).Value = vObjProducts.ProductDescription;
                dbCmd.Parameters.Add("@PdBenefits", SqlDbType.NVarChar).Value = vObjProducts.ProductBenefits;

                dbCmd.Parameters.Add("@PdUserID", SqlDbType.Int).Value = vUserId;

                dbCmd.Parameters.Add("@ImageID", SqlDbType.VarChar).Value = vImage.ImgID;
                dbCmd.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = vImage.ImgName;
                dbCmd.Parameters.Add("@ImageType", SqlDbType.TinyInt).Value = vImage.ImgType;
                dbCmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = vImage.ImgPath;
                dbCmd.Parameters.Add("@ImageActName", SqlDbType.VarChar).Value = vImage.ActualImgName;
                
                dbCmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = vActive;


                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }


        /// <summary>
        /// Function to Delete record from tblProductDetails table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>boolen</returns>
        /// <remarks>This function deletes and returns true if inserted else false</remarks> 
        /// 
        public bool DeleteProductsData(int vUserId, int vProductID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteProduct_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = vProductID;

                int rowCount = dbCmd.ExecuteNonQuery();

                if (rowCount > 0)
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }


        /// <summary>
        /// Function to change the priority order for products 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>boolen</returns>
        /// <remarks>This function inserts or updates </remarks> 
        /// 
        public bool InsertUpdate_ProductPriority(int vUserId, int vProductID, bool vActive)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_InsertUpdateProduct_Priority, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = vProductID;
                dbCmd.Parameters.Add("@Active", SqlDbType.Int).Value = vActive;

                int rowCount = dbCmd.ExecuteNonQuery();

                if (rowCount > 0)
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }



        #endregion




        #region  USER related functionality


        /// <summary>
        /// Function to retrive all the Products  on the home page. 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function updates and returns 1 if inserted else 0</remarks> 
        /// 
        public DataSet User_GETAll_Products_ByUserID(int mUserId, int mProductType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_USER_GET_Products_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@PrdUserID", SqlDbType.Int).Value = mUserId;
                dbCmd.Parameters.Add("@PrdType", SqlDbType.Int).Value = mProductType;
                
                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }


        #endregion



    }
}
