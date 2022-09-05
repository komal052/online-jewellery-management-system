using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;


public class state_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "state_master";

    public state_tableDB()
    {
    }

    public int OnInsert(state_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [state_master]
                                   ([state_name])
                             VALUES
                                   (@state_name)";

            OnClearParameter();
            AddParameter("@state_name", SqlDbType.VarChar, 50, obj.State_name, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public int OnUpdate(state_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [state_master]
                             SET    [state_name]=@state_name
                         WHERE [state_id_pk]=@state_id_pk";
            OnClearParameter();
            AddParameter("@state_id_pk", SqlDbType.Int, 50, obj.State_id_pk, ParameterDirection.Input);
            AddParameter("@state_name", SqlDbType.VarChar, 50, obj.State_name, ParameterDirection.Input);


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
            strQ += @"Update [state_master]
                     
                         WHERE [state_id_pk]=@state_id_pk";

            OnClearParameter();
            AddParameter("@state_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private state_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;

            state_tableEntities obj = new state_tableEntities();

            obj.State_id_pk = (drRow["state_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["state_id_pk"];
            obj.State_name = (drRow["state_name"].Equals(DBNull.Value)) ? "" : (string)drRow["state_name"];
           // obj.Is_active = (drRow["is_active"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_active"].ToString());



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

    public state_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;


        state_tableEntities obj = new state_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('state_master') ";

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
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public state_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        state_tableEntities obj = new state_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [state_master] WHERE [state_id_pk] = @state_id_pk ";

            OnClearParameter();
            AddParameter("state_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<state_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<state_tableEntities> oList = new List<state_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from [state_master] ";
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
            throw ex;
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
            strQ = @"SELECT [state_master].state_id_pk
                                   ,[state_master].state_name
                                    FROM [state_master] ";

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
                objData.ID = dtTable.Rows[intRow]["state_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["state_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["state_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["state_name"];
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
}
