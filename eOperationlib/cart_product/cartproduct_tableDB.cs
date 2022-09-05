using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class cartproduct_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "cart_product";

    public cartproduct_tableDB()
        : base()
    {
    }

    public int OnInsert(cartproduct_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [cart_product]
                                   ([cart_id_fk],[subtype_jewellery_id_fk],[quantity])
                             VALUES
                                   (@cart_id_fk,@subtype_jewellery_id_fk,@quantity)";

            OnClearParameter();
          
            AddParameter("@cart_id_fk", SqlDbType.VarChar, 50, obj.Cart_id_fk, ParameterDirection.Input);      
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@quantity", SqlDbType.VarChar, 50, obj.Quantity, ParameterDirection.Input);            
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(cartproduct_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [cart_product]
                             SET   
                                    [cart_id_fk]=@cart_id_fk,                                    
                                    [subtype_jewellery_id_fk]=@subtype_jewellery_id_fk,
                                    [quantity]=@quantity,
                                    [price]=@price
                                   
                         WHERE [cart_product_id_pk]=@cart_product_id_pk";
            OnClearParameter();
            AddParameter("@cart_product_id_pk", SqlDbType.Int, 50, obj.Cart_product_id_pk, ParameterDirection.Input);
            AddParameter("@cart_id_fk", SqlDbType.VarChar, 50, obj.Cart_id_fk, ParameterDirection.Input);
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnDelete(int ID)
    {
        string strQ = "";
      
        try
        {
            strQ += @"Delete from [cart_product]                            
                         WHERE [cart_product_id_pk]=@cart_product_id_pk";

            OnClearParameter();
            AddParameter("@cart_product_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private cartproduct_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            cartproduct_tableEntities obj = new cartproduct_tableEntities();

            obj.Cart_product_id_pk = (drRow["cart_product_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["cart_product_id_pk"];
          
            obj.Cart_id_fk = (drRow["cart_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["cart_id_fk"];

            obj.Subtype_jewellery_id_fk = (drRow["subtype_jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["subtype_jewellery_id_fk"];

            obj.Quantity = (drRow["quantity"].Equals(DBNull.Value)) ? "" : (string)drRow["quantity"];

            obj.Price = (drRow["price"].Equals(DBNull.Value)) ? "" : (string)drRow["price"];

            obj.Subtype = (drRow["subtype"].Equals(DBNull.Value)) ? "" : (string)drRow["subtype"];

            //obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];

            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];

            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];

            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];

            obj.Images = (drRow["images"].Equals(DBNull.Value)) ? "" : (string)drRow["images"];





            //if (DateTime.TryParseExact((string)drRow["addon"], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtdata))
            //{
            //    obj.Addon = dtdata;
            //}

            //if (DateTime.TryParseExact((string)drRow["modifyon"], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtdata))
            //{
            //    obj.Modifyon = dtdata;
            //}

            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
    }
    public cartproduct_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        cartproduct_tableEntities obj = new cartproduct_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,sj.subtype,sj.price,r.f_name,r.l_name FROM [cart_product] cp
            JOIN [cart_master] c ON cp.[cart_id_fk]=c.[cart_id_pk] 
            JOIN [registration_master] r ON c.[user_id_fk]=r.[user_id_pk]
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]=sj.[subtype_jewellery_id_pk]
            WHERE [cart_product_id_pk] = @cart_product_id_pk";

            OnClearParameter();
            AddParameter("cart_product_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
            return obj;
        }
    }

    public DataTable OnGetCategory()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cartproduct_tableEntities> oList = new List<cartproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [cart_product] ";
            OnClearParameter();
            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            return dtTable;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }
    public List<cartproduct_tableEntities> OnGetCartproductListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cartproduct_tableEntities> oList = new List<cartproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,sj.subtype,sj.price,r.f_name,r.l_name,j.jewellery_name,sj.images,sj.price FROM [cart_product] cp
            JOIN [cart_master] c ON cp.[cart_id_fk]=c.[cart_id_pk] 
            JOIN [registration_master] r ON c.[user_id_fk]=r.[user_id_pk]
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]
            WHERE [cart_id_fk]=@cart_id_fk";


            OnClearParameter();
            AddParameter("cart_id_fk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            // throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }

    public List<cartproduct_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cartproduct_tableEntities> oList = new List<cartproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,sj.subtype,sj.price,r.f_name,r.l_name,j.jewellery_name,sj.price,sj.images FROM [cart_product] cp
            JOIN [cart_master] c ON cp.[cart_id_fk]=c.[cart_id_pk] 
            JOIN [registration_master] r ON c.[user_id_fk]=r.[user_id_pk]
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]";

            OnClearParameter();

            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
           // throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }

    public List<cartproduct_tableEntities> OnGetUserListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cartproduct_tableEntities> oList = new List<cartproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,sj.subtype,sj.price,r.f_name,r.l_name,j.jewellery_name,sj.price,sj.images FROM[cart_product] cp
           JOIN[cart_master] c ON cp.[cart_id_fk] = c.[cart_id_pk]
            JOIN[registration_master] r ON c.[user_id_fk] = r.[user_id_pk]
            JOIN[subtype_jewellery_master] sj ON w.[subtype_jewellery_id_fk] = sj.[subtype_jewellery_id_pk]
            JOIN[jewellery_master] j ON sj.[jewellery_id_fk] = j.[jewellery_id_pk]";

            OnClearParameter();
            AddParameter("user_id_fk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            // throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }

    public List<ComboboxItem> OnGetListForCombo()
    {
        Exception exForce;
        DataTable dtTable;

        List<ComboboxItem> oList = new List<ComboboxItem>();

        string strQ = "";

        try
        {

            OnClearParameter();
            strQ = @"SELECT cart_product_id_pk  FROM [cart_product]  ";

            dtTable = OnExecQuery(strQ, "list").Tables[0];

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }

            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                ComboboxItem objData = new ComboboxItem();
                objData.ID = dtTable.Rows[intRow]["cart_product_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["cart_product_id_pk"];
               // objData.NAME = dtTable.Rows[intRow]["jewellery_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["jewellery_name"];
                oList.Add(objData);

                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
            return oList;
        }
    }
  
   /* public List<cartproduct_tableEntities> OnGetcartproductCount(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cartproduct_tableEntities> oList = new List<cartproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT count(cartproduct_id_pk) from [cartproduct_master]  WHERE [user_id_fk] = @user_id_fk ";            

            OnClearParameter();
            AddParameter("user_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            // throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }*/
   
}
