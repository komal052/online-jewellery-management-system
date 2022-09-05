using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class cart_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "cart_master";

    public cart_tableDB()
        : base()
    {
    }

    public int OnInsert(cart_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [cart_master]
                                   ([user_id_fk],[total_amount])
                             VALUES
                                   (@user_id_fk,@total_amount)";

            OnClearParameter();
          
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);      
            AddParameter("@total_amount", SqlDbType.VarChar, 50, obj.Total_amount, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(cart_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [cart_master]
                             SET                                       
                                    [total_amount]=@total_amount
                                   
                         WHERE [user_id_fk]=@user_id_fk";
            OnClearParameter();
            AddParameter("@user_id_fk", SqlDbType.Int, 50, obj.User_id_fk, ParameterDirection.Input);            
            AddParameter("@total_amount", SqlDbType.VarChar, 50, obj.Total_amount, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /*public cart_tableEntities OnUpdate(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        cart_tableEntities obj = new cart_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"UPDATE [cart_master]
                             SET                                       
                                    [total_amount]=@total_amount                                 
                         WHERE [user_id_fk]=@user_id_fk";
            OnClearParameter();
            
            //AddParameter("@cart_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.Int, 50, obj.Cart_id_pk, ParameterDirection.Input);
            AddParameter("@total_amount", SqlDbType.VarChar, 50, obj.Total_amount, ParameterDirection.Input);

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
    }*/

    public int OnDelete(int ID)
    {
        string strQ = "";
      
        try
        {
            strQ += @"Delete from [cart_master]                            
                         WHERE [cart_id_pk]=@cart_id_pk";

            OnClearParameter();
            AddParameter("@cart_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private cart_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            cart_tableEntities obj = new cart_tableEntities();

            obj.Cart_id_pk = (drRow["cart_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["cart_id_pk"];
          
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Total_amount = (drRow["total_amount"].Equals(DBNull.Value)) ? "" : (string)drRow["total_amount"];
         

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
    public cart_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        cart_tableEntities obj = new cart_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,r.f_name,r.l_name FROM [cart_master] c
            JOIN [registration_master] r ON c.[user_id_fk]=r.[user_id_pk]  
            WHERE [cart_id_pk] = @cart_id_pk";

            OnClearParameter();
            AddParameter("cart_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        int lastId = 0;

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('cart_master') ";

            OnClearParameter();

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                lastId = Int32.Parse(dtTable.Rows[0].ItemArray[0].ToString());
            }

            return lastId;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable OnGetCategory()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cart_tableEntities> oList = new List<cart_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [cart_master] ";
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

    public List<cart_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cart_tableEntities> oList = new List<cart_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,r.l_name FROM [cart_master] c
            JOIN [registration_master] r ON c.[user_id_fk]=r.[user_id_pk]";             

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

    public cart_tableEntities OnGetUserListdt(int ID)
    {
        Exception exForce;        
        DataTable dtTable;

        cart_tableEntities obj = new cart_tableEntities();
        
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,r.F_name,r.L_name FROM [cart_master] c
            JOIN [registration_master] r ON c.[user_id_fk]=r.[user_id_pk]
            WHERE [user_id_fk] = @user_id_fk";

            OnClearParameter();
            AddParameter("user_id_fk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
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

    public List<ComboboxItem> OnGetListForCombo()
    {
        Exception exForce;
        DataTable dtTable;

        List<ComboboxItem> oList = new List<ComboboxItem>();

        string strQ = "";

        try
        {

            OnClearParameter();
            strQ = @"SELECT cart_id_pk  FROM [cart_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["cart_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["cart_id_pk"];
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
  
   /* public List<cart_tableEntities> OnGetCartCount(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<cart_tableEntities> oList = new List<cart_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT count(cart_id_pk) from [cart_master]  WHERE [user_id_fk] = @user_id_fk ";            

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
