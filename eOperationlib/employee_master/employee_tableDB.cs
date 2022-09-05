using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class employee_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "employee_master";

    public employee_tableDB()
        : base()
    {
    }

    public int OnInsert(employee_tableEntities obj)
    {

        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [employee_master]
                                   ([emp_name],[emp_address],[emp_contact])
                             VALUES
                                   (@emp_name,@emp_address,@emp_contact)";

            OnClearParameter();
            AddParameter("@emp_name", SqlDbType.VarChar, 50, obj.Emp_name, ParameterDirection.Input);
            AddParameter("@emp_address", SqlDbType.VarChar, 50, obj.Emp_address, ParameterDirection.Input);
            AddParameter("@emp_contact", SqlDbType.VarChar, 50, obj.Emp_contact, ParameterDirection.Input);

            return OnExecNonQuery(strQ);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(employee_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [employee_master]
                             SET    [emp_name]=@emp_name,                                  
                                    [emp_address]=@emp_address,
                                    [emp_contact]=@emp_contact

                         WHERE [emp_id_pk]=@emp_id_pk";
            OnClearParameter();
            AddParameter("@emp_id_pk", SqlDbType.Int, 50, obj.Emp_id_pk, ParameterDirection.Input);
            AddParameter("@emp_name", SqlDbType.VarChar, 50, obj.Emp_name, ParameterDirection.Input);
            AddParameter("@emp_address", SqlDbType.VarChar, 50, obj.Emp_address, ParameterDirection.Input);
            AddParameter("@emp_contact", SqlDbType.VarChar, 50, obj.Emp_contact, ParameterDirection.Input);

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
            strQ += @"UPDATE [employee_master]
                            SET [is_active]=0
                         WHERE [emp_id_pk]=@emp_id_pk";

            OnClearParameter();
            AddParameter("@emp_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private employee_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            employee_tableEntities obj = new employee_tableEntities();

            obj.Emp_id_pk = (drRow["emp_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["emp_id_pk"];
            obj.Emp_name = (drRow["emp_name"].Equals(DBNull.Value)) ? "" : (string)drRow["emp_name"];
            obj.Emp_address = (drRow["emp_address"].Equals(DBNull.Value)) ? "" : (string)drRow["emp_address"];
            obj.Emp_contact = (drRow["emp_contact"].Equals(DBNull.Value)) ? "" : (string)drRow["emp_contact"];
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
    public employee_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        employee_tableEntities obj = new employee_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [employee_master] WHERE [emp_id_pk] = @emp_id_pk";

            OnClearParameter();
            AddParameter("emp_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<employee_tableEntities> oList = new List<employee_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [employee_master] ";

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

    public List<employee_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<employee_tableEntities> oList = new List<employee_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from employee_master where [is_active]=1 ";
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
            strQ = @"SELECT emp_id_pk,emp_name FROM [employee_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["emp_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["emp_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["emp_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["emp_name"];

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
            strQ = @"SELECT count(emp_id_pk) from [employee_master] where [is_active] = 1";
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
