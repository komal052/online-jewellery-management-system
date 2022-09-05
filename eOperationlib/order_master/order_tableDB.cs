using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class order_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "order_master";

    public order_tableDB()
        : base()
    {
    }

    public int OnInsert(order_tableEntities obj)
    {

        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [order_master]
                                   ([user_id_fk],[total_amount],[date])
                             VALUES
                                   (@user_id_fk,@total_amount,@date)";

            OnClearParameter();

            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@total_amount", SqlDbType.VarChar, 50, obj.Total_amount, ParameterDirection.Input);
            AddParameter("@date", SqlDbType.VarChar, 50, obj.Date, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(order_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [order_master]
                             SET                                       
                                     [user_id_fk]=@user_id_fk,                                                                           
                                     [date]=@date,
                                     
                                   
                         WHERE [order_id_pk]=@order_id_pk";
            OnClearParameter();
            AddParameter("@order_id_pk", SqlDbType.Int, 50, obj.Order_id_pk, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@total_amount", SqlDbType.VarChar, 50, obj.Total_amount, ParameterDirection.Input);
            AddParameter("@date", SqlDbType.VarChar, 50, obj.Date, ParameterDirection.Input);
            

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
            strQ += @"UPDATE [order_master]
                            SET [is_active]=0
                         WHERE [order_id_pk]=@order_id_pk";

            OnClearParameter();
            AddParameter("@order_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private order_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            order_tableEntities obj = new order_tableEntities();

            obj.Order_id_pk = (drRow["order_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["order_id_pk"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Address = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.Total_amount = (drRow["total_amount"].Equals(DBNull.Value)) ? "" : (string)drRow["total_amount"];
            obj.Date = (drRow["date"].Equals(DBNull.Value)) ? "" : (string)drRow["date"];
            


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
    public order_tableEntities OnGetUserListdt(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        order_tableEntities obj = new order_tableEntities();

        string strQ = "";

        try
        {
           
            strQ = @"SELECT o.*,r.f_name,r.l_name,r.address FROM [order_master] o                        
            JOIN [registration_master] r ON o.[user_id_fk]=r.[user_id_pk]           
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
    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        int lastId = 0;

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('order_master') ";

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
    public order_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        order_tableEntities obj = new order_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT o.*,r.f_name,r.l_name,r.address FROM [order_master] o                        
            JOIN [registration_master] r ON o.[user_id_fk]=r.[user_id_pk]     
            WHERE [order_id_pk] = @order_id_pk";

            OnClearParameter();
            AddParameter("order_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<order_tableEntities> oList = new List<order_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [order_master] ";
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

    public List<order_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<order_tableEntities> oList = new List<order_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT o.*,r.f_name,r.l_name,r.address FROM [order_master] o            
            JOIN [registration_master] r ON o.[user_id_fk]=r.[user_id_pk]";

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
    public List<order_tableEntities> OnUserOrderListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<order_tableEntities> oList = new List<order_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT o.*,r.f_name,r.l_name,r.address FROM [order_master] o            
            JOIN [registration_master] r ON o.[user_id_fk]=r.[user_id_pk]
            where [user_id_fk]=@user_id_fk";

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
            strQ = @"SELECT order_id_pk,total_price FROM [order_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["order_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["order_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["total_price"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["total_price"];
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
   /* public List<int> OnGetTableCount()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<int> oList = new List<int>();
        string strQ = "";
        try
        {
            strQ = @"SELECT count(order_id_pk) from [order_master] where [is_active] = 1 
";
            OnClearParameter();

            dtTable = OnExecQuery(strQ, "list").Tables[0];
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            int count = (int)dtTable.Rows[0][0];
            oList.Add(count);
            intRow = intRow + 1;
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
            // return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }*/
    /* public List<order_tableEntities> OnGetLimitListdt()
     {
         Exception exForce;
         //IDataReader oReader;
         DataTable dtTable;
         List<order_tableEntities> oList = new List<order_tableEntities>();
         string strQ = "";

         try
         {
             strQ = @"SELECT  TOP 4  o.*,j.jewellery_name,r.f_name,r.l_name,d.discount FROM [order_master] o
             JOIN [jewellery_master] j ON o.[jewellery_id_fk]=j.[jewellery_id_pk]
             JOIN [registration_master] r ON o.[user_id_fk]=r.[user_id_pk]  
             JOIN [discount_master] d ON o.[discount_id_fk]=d.[discount_id_pk] 
             WHERE o.[is_active]=1" ;

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
     }*/
    public int OnGetLimitListdt()
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [order_master]
                               SET    [is_read]=0";
            OnClearParameter();

            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /*public int OnGetStatusListdt()
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [order_master]
                               SET  [status]= 0 ";
            OnClearParameter();

            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }*/
}
