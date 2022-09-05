using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class department_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "depatmenttb";

    public department_tableDB()
    {
    }

    public int OnInsert(department_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [departmenttb]
                                   ([deptname])
                             VALUES
                                   (@deptname)";

            OnClearParameter();
            AddParameter("@deptname", SqlDbType.VarChar, 50, obj.Dept_name, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public int OnUpdate(department_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [departmenttb]
                             SET    [deptname]=@deptname
                         WHERE [deptid]=@deptid";
            OnClearParameter();
            AddParameter("@deptid", SqlDbType.Int, 50, obj.Dept_id, ParameterDirection.Input);
            AddParameter("@deptname", SqlDbType.VarChar, 50, obj.Dept_name, ParameterDirection.Input);


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
            strQ += @"Update [departmenttb]
                        SET [is_active]=0
                         WHERE [deptid]=@deptid";

            OnClearParameter();
            AddParameter("@deptid", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private department_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            department_tableEntities obj = new department_tableEntities();

            obj.Dept_id = (drRow["deptid"].Equals(DBNull.Value)) ? 0 : (int)drRow["deptid"];
            obj.Dept_name = (drRow["deptname"].Equals(DBNull.Value)) ? "" : (string)drRow["deptname"];
            obj.Is_active = (drRow["is_active"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_active"].ToString());



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

    public department_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        department_tableEntities obj = new department_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('departmenttb') ";

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

    public department_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        department_tableEntities obj = new department_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [departmenttb] WHERE [deptid] = @deptid ";

            OnClearParameter();
            AddParameter("deptid", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<department_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<department_tableEntities> oList = new List<department_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from [departmenttb] where [is_active]=1";
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
            strQ = @"SELECT [departmenttb].deptid
                                   ,[departmenttb].deptname
                                    FROM [departmenttb] ";

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
                objData.ID = dtTable.Rows[intRow]["deptid"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["deptid"];
                objData.NAME = dtTable.Rows[intRow]["deptname"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["deptname"];
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
