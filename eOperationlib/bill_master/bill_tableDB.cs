using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class bill_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "bill_master";

    public bill_tableDB()
        : base()
    {
    }

    public int OnInsert(bill_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [bill_master]
                                   ([user_id_fk],[order_id_fk],[tax],[gst],[total_amount],[date])
                             VALUES
                                   (@user_id_fk,@order_id_fk,@tax,@gst,@total_amount,@date)";

            OnClearParameter();
            
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@tax", SqlDbType.VarChar, 50, obj.Tax, ParameterDirection.Input);
            AddParameter("@gst", SqlDbType.VarChar, 50, obj.Gst, ParameterDirection.Input);
            AddParameter("@total_amount", SqlDbType.VarChar, 50, obj.Total_amount, ParameterDirection.Input);
            AddParameter("@date", SqlDbType.VarChar, 50, obj.Date, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(bill_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [bill_master]
                             SET    [order_id_fk]=@order_id_fk,
                                    [user_id_fk]=@user_id_fk,
                                    [tax]=@tax,
                                    [gst]=@gst,
                                    [total_amount]=@total_amount,
                                    [date]=@date
                                   
                         WHERE [bill_id_pk]=@bill_id_pk";
            OnClearParameter();
            AddParameter("@bill_id_pk", SqlDbType.Int, 50, obj.Bill_id_pk, ParameterDirection.Input);            
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@tax", SqlDbType.VarChar, 50, obj.Tax, ParameterDirection.Input);
            AddParameter("@gst", SqlDbType.VarChar, 50, obj.Gst, ParameterDirection.Input);
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
            strQ += @"UPDATE [bill_master]
                            SET [is_active]=0
                         WHERE [bill_id_pk]=@bill_id_pk";

            OnClearParameter();
            AddParameter("@bill_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private bill_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            bill_tableEntities obj = new bill_tableEntities();

            obj.Bill_id_pk = (drRow["bill_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["bill_id_pk"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Order_id_fk = (drRow["order_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["order_id_fk"];
            obj.Total_price= (drRow["total_price"].Equals(DBNull.Value)) ? "" : (string)drRow["total_price"];
            obj.Tax  = (drRow["tax"].Equals(DBNull.Value)) ? "" : (string)drRow["tax"];
            obj.Gst = (drRow["gst"].Equals(DBNull.Value)) ? "" : (string)drRow["gst"];
            obj.Total_amount = (drRow["total_amount"].Equals(DBNull.Value)) ? "" : (string)drRow["total_amount"];
            obj.Date = (drRow["date"].Equals(DBNull.Value)) ? "" : (string)drRow["date"];
            obj.Is_active  = (drRow["is_active"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_active"].ToString());
      

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
    public bill_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        bill_tableEntities obj = new bill_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT b.*,o.total_price,r.f_name,r.l_name FROM [bill_master] b
            JOIN [order_master] o ON b.[order_id_fk]=o.[order_id_pk]
            JOIN [registration_master] r ON b.[user_id_fk]=r.[user_id_pk]                        
            WHERE [bill_id_pk] = @bill_id_pk";

            OnClearParameter();
            AddParameter("bill_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<bill_tableEntities> oList = new List<bill_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [bill_master] ";
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

    public List<bill_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<bill_tableEntities> oList = new List<bill_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT b.*,o.total_price,r.f_name,r.l_name FROM [bill_master] b
            JOIN [order_master] o ON b.[order_id_fk]=o.[order_id_pk]
            JOIN [registration_master] r ON b.[user_id_fk]=r.[user_id_pk]                        
            WHERE b.[is_active]=1";
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
    public List<ComboboxItem> OnGetListForCombo()
    {
        Exception exForce;
        DataTable dtTable;

        List<ComboboxItem> oList = new List<ComboboxItem>();

        string strQ = "";

        try
        {

            OnClearParameter();
            strQ = @"SELECT bill_id_pk,jewellery_name FROM [bill_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["bill_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["bill_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["jewellery_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["jewellery_name"];
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
    public List<int> OnGetTableCount()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<int> oList = new List<int>();
        string strQ = "";
        try
        {
            strQ = @"SELECT count(bill_id_pk) from [bill_master] where [is_active] = 1";
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
    }
}
