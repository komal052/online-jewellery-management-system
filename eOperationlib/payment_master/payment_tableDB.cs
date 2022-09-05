using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class payment_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "payment_master";

    public payment_tableDB()
        : base()
    {
    }

    public int OnInsert(payment_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [payment_master]
                                   ([payment_type],[bill_id_fk],[user_id_fk])
                             VALUES
                                   (@payment_type,@bill_id_fk,@user_id_fk)";

            OnClearParameter();
            AddParameter("@payment_type", SqlDbType.VarChar, 50, obj.Payment_type, ParameterDirection.Input);
            AddParameter("@bill_id_fk", SqlDbType.VarChar, 50, obj.Bill_id_fk, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(payment_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [payment_master]
                             SET    [payment_type]=@payment_type,
                                    [bill_id_fk]=@bill_id_fk,
                                    [user_id_fk]=@user_id_fk                                                                      

                         WHERE [payment_id_pk]=@payment_id_pk";
            OnClearParameter();
            AddParameter("@payment_id_pk", SqlDbType.Int, 50, obj.Payment_id_pk, ParameterDirection.Input);
            AddParameter("@payment_type", SqlDbType.VarChar, 50, obj.Payment_type, ParameterDirection.Input);
            AddParameter("@bill_id_fk", SqlDbType.VarChar, 50, obj.Bill_id_fk, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            
            
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
            strQ += @"UPDATE [payment_master]
                            SET [is_active]=0
                         WHERE [payment_id_pk]=@payment_id_pk";

            OnClearParameter();
            AddParameter("@payment_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private payment_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            payment_tableEntities obj = new payment_tableEntities();

            obj.Payment_id_pk = (drRow["payment_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["payment_id_pk"];
            obj.Payment_type = (drRow["payment_type"].Equals(DBNull.Value)) ? "" : (string)drRow["payment_type"];
            obj.Bill_id_fk = (drRow["bill_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["bill_id_fk"];
            obj.Total_amount = (drRow["total_amount"].Equals(DBNull.Value)) ? "" : (string)drRow["total_amount"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
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
    public payment_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        payment_tableEntities obj = new payment_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT p.*,b.total_amount,r.f_name,r.l_name FROM [payment_master] p 
            JOIN [bill_master] b ON p.[bill_id_fk]=b.[bill_id_pk]
            JOIN [registration_master] r ON p.[user_id_fk]=r.[user_id_pk]
            WHERE [payment_id_pk] = @payment_id_pk";

            OnClearParameter();
            AddParameter("payment_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<payment_tableEntities> oList = new List<payment_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [payment_master] ";
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

    public List<payment_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<payment_tableEntities> oList = new List<payment_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT p.*,b.total_amount,r.f_name,r.l_name FROM [payment_master] p 
            JOIN [bill_master] b ON p.[bill_id_fk]=b.[bill_id_pk]
            JOIN [registration_master] r ON p.[user_id_fk]=r.[user_id_pk]
            WHERE p.[is_active]=1";

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
            strQ = @"SELECT payment_id_pk,payment_type FROM [payment_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["payment_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["payment_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["payment_type"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["payment_type"];
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
            strQ = @"SELECT count(payment_id_pk) from [payment_master] where [is_active] = 1";
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
