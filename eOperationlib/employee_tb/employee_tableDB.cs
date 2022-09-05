using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class employee_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "employeetb";

    public employee_tableDB()
        : base()
    {
    }

    public int OnInsert(employee_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [employeetb]
                                   ([empname],[dept_id_fk],[joining_date],[designation],[qualification])
                             VALUES
                                   (@empname,@dept_id_fk,@joining_date,@designation,@qualification)";

            OnClearParameter();
            AddParameter("@empname", SqlDbType.VarChar, 50, obj.Emp_name, ParameterDirection.Input);
            AddParameter("@dept_id_fk", SqlDbType.VarChar, 50, obj.Department_id_fk, ParameterDirection.Input);
            AddParameter("@joining_date", SqlDbType.VarChar, 50, obj.Joinning_date, ParameterDirection.Input);
            AddParameter("@designation", SqlDbType.VarChar, 50, obj.Designation, ParameterDirection.Input);
            AddParameter("@qualification", SqlDbType.VarChar, 50, obj.Qualification, ParameterDirection.Input);
          
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
            strQ = @"UPDATE [employeetb]
                             SET    [empname]=@empname,
                                    [dept_id_fk]=@dept_id_fk,
                                    [joining_date]=@joining_date,
                                    [designation]=@designation,
                                    [qualification]=@qualification

                         WHERE [empid]=@empid";
            OnClearParameter();
            AddParameter("@empid", SqlDbType.Int, 50, obj.Emp_id, ParameterDirection.Input);
            AddParameter("@empname", SqlDbType.VarChar, 50, obj.Emp_name, ParameterDirection.Input);
            AddParameter("@dept_id_fk", SqlDbType.VarChar, 50, obj.Department_id_fk, ParameterDirection.Input);
            AddParameter("@joining_date", SqlDbType.VarChar, 50, obj.Joinning_date, ParameterDirection.Input);
            AddParameter("@designation", SqlDbType.VarChar, 50, obj.Designation, ParameterDirection.Input);
            AddParameter("@qualification", SqlDbType.VarChar, 50, obj.Qualification, ParameterDirection.Input);
            
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
            strQ += @"UPDATE [employeetb]
                            SET [is_active]=0
                         WHERE [empid]=@empid";

            OnClearParameter();
            AddParameter("@empid", SqlDbType.Int, 50, ID, ParameterDirection.Input);
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

            obj.Emp_id = (drRow["empid"].Equals(DBNull.Value)) ? 0 : (int)drRow["empid"];
            obj.Emp_name = (drRow["empname"].Equals(DBNull.Value)) ? "" : (string)drRow["empname"];
            obj.Department_id_fk = (drRow["dept_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["dept_id_fk"];
            obj.Joinning_date = (drRow["joining_date"].Equals(DBNull.Value)) ? "" : (string)drRow["joining_date"];
            obj.Designation = (drRow["designation"].Equals(DBNull.Value)) ? "" : (string)drRow["designation"]; 
            obj.Qualification  = (drRow["qualification"].Equals(DBNull.Value)) ? "" : (string)drRow["qualification"];
            obj.Is_active  = (drRow["is_active"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_active"].ToString());

            department_tableDB objdept = new department_tableDB();
            obj.Dept = objdept.OnGetData(obj.Department_id_fk);


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
            strQ = @"SELECT * FROM [employeetb] WHERE [empid] = @empid";

            OnClearParameter();
            AddParameter("empid", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
            strQ = @"SELECT * FROM [employeetb] ";
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
            strQ = @"SELECT * from employeetb where [is_active]=1 ";
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
            strQ = @"SELECT empid,empname FROM [employeetb]  ";

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
                objData.ID = dtTable.Rows[intRow]["empid"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["empid"];
                objData.NAME = dtTable.Rows[intRow]["empname"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["empname"];
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
