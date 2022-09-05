using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class return_jewellery_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "return_jewellery_master";

    public return_jewellery_tableDB()
        : base()
    {
    }

    public int OnInsert(return_jewellery_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [return_jewellery_master]
                                   ([user_id_fk],[jewellery_id_fk],[order_id_fk],[date])
                             VALUES
                                   (@user_id_fk,@jewellery_id_fk,@order_id_fk,@date)";

            OnClearParameter();
            
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@date", SqlDbType.VarChar, 50, obj.Date, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(return_jewellery_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [return_jewellery_master]                                    
                             SET    [user_id_fk]=@user_id_fk,
                                    [jewellery_id_fk]=@jewellery_id_fk,
                                    [order_id_fk]=@order_id_fk,                                    
                                    [date]=@date
                                   
                         WHERE [return_id_pk]=@return_id_pk";
            OnClearParameter();
            AddParameter("@return_id_pk", SqlDbType.Int, 50, obj.Return_id_pk, ParameterDirection.Input);            
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
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
            strQ += @"UPDATE [return_jewellery_master]
                            SET [is_active]=0
                         WHERE [return_id_pk]=@return_id_pk";

            OnClearParameter();
            AddParameter("@return_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private return_jewellery_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            return_jewellery_tableEntities obj = new return_jewellery_tableEntities();

            obj.Return_id_pk = (drRow["return_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["return_id_pk"];            
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Jewellery_id_fk = (drRow["jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Order_id_fk = (drRow["order_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["order_id_fk"];
            obj.Total_price = (drRow["total_price"].Equals(DBNull.Value)) ? "" : (string)drRow["total_price"];
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
    public return_jewellery_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        return_jewellery_tableEntities obj = new return_jewellery_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT re.*,j.jewellery_name,r.f_name,r.l_name,o.total_price FROM [return_jewellery_master] re
            JOIN [jewellery_master] j ON re.[jewellery_id_fk]=j.[jewellery_id_pk]
            JOIN [registration_master] r ON re.[user_id_fk]=r.[user_id_pk]
            JOIN [order_master] o ON re.[order_id_fk]=o.[order_id_pk]
            WHERE [return_id_pk] =@return_id_pk";

            OnClearParameter();
            AddParameter("return_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<return_jewellery_tableEntities> oList = new List<return_jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [return_jewellery_master] ";
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

    public List<return_jewellery_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<return_jewellery_tableEntities> oList = new List<return_jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT re.*,j.jewellery_name,r.f_name,r.l_name,o.total_price FROM [return_jewellery_master] re
            JOIN [jewellery_master] j ON re.[jewellery_id_fk]=j.[jewellery_id_pk]
            JOIN [registration_master] r ON re.[user_id_fk]=r.[user_id_pk]
            JOIN [order_master] o ON re.[order_id_fk]=o.[order_id_pk]
            WHERE re.[is_active]=1";

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
            strQ = @"SELECT return_id_pk,jewellery_name FROM [return_jewellery_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["return_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["return_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["date"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["date"];
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
            strQ = @"SELECT count(return_id_pk) from [return_jewellery_master] where [is_active] = 1";
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
