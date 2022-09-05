using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class registration_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "registration_master";

    public registration_tableDB()
        : base()
    {
    }

    public int OnInsert(registration_tableEntities obj)
    {

        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [registration_master]
                                   ([f_name],[l_name],[gender][birthdate],[status],[anniversary_date],[state_id_fk],[city_id_fk],[address],
                                    [email],[password],[contact],[u_type])
                             VALUES
                                   (@f_name,@l_name,@gender,@birthdate,@status,@anniversary_date,@state_id_fk,@city_id_fk,@address,
                                      @email,@password,@contact,@u_type)";

            OnClearParameter();
            AddParameter("@f_name", SqlDbType.VarChar, 50, obj.F_name, ParameterDirection.Input);
            AddParameter("@l_name", SqlDbType.VarChar, 50, obj.L_name, ParameterDirection.Input);
            AddParameter("@gender", SqlDbType.VarChar, 50, obj.Gender, ParameterDirection.Input);
            AddParameter("@birthdate", SqlDbType.VarChar, 50, obj.birthdate, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.VarChar, 50, obj.status, ParameterDirection.Input);
            AddParameter("@anniversary_date", SqlDbType.VarChar, 50, obj.anniversary_date, ParameterDirection.Input);
            AddParameter("@state_id_fk", SqlDbType.VarChar, 50, obj.state_id_fk, ParameterDirection.Input);
            AddParameter("@city_id_fk", SqlDbType.VarChar, 50, obj.city_id_fk, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 50, obj.address, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, obj.password, ParameterDirection.Input);
            AddParameter("@contact", SqlDbType.VarChar, 50, obj.contact, ParameterDirection.Input);
            AddParameter("@u_type", SqlDbType.VarChar, 50, obj.u_type, ParameterDirection.Input);

            return OnExecNonQuery(strQ);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(registration_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [registration_master]
                             SET    [f_name]=@f_name,
                                    [state_id_fk]=@state_id_fk,
                                    [anniversary_date]=@anniversary_date,
                                    [address]=@address,
                                    [email]=@email

                         WHERE [empid]=@empid";
            OnClearParameter();
            AddParameter("@empid", SqlDbType.Int, 50, obj.Emp_id, ParameterDirection.Input);
            AddParameter("@f_name", SqlDbType.VarChar, 50, obj.L_name, ParameterDirection.Input);
            AddParameter("@state_id_fk", SqlDbType.VarChar, 50, obj.state_id_fk, ParameterDirection.Input);
            AddParameter("@anniversary_date", SqlDbType.VarChar, 50, obj.anniversary_date, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 50, obj.address, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.email, ParameterDirection.Input);

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
            strQ += @"UPDATE [registration_master]
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

    private registration_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            registration_tableEntities obj = new registration_tableEntities();

            obj.Emp_id = (drRow["empid"].Equals(DBNull.Value)) ? 0 : (int)drRow["empid"];
            obj.L_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.state_id_fk = (drRow["state_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["state_id_fk"];
            obj.anniversary_date = (drRow["anniversary_date"].Equals(DBNull.Value)) ? "" : (string)drRow["anniversary_date"];
            obj.address = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.email = (drRow["email"].Equals(DBNull.Value)) ? "" : (string)drRow["email"];
            obj.Is_active = (drRow["is_active"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_active"].ToString());

            department_tableDB objdept = new department_tableDB();
            obj.Dept = objdept.OnGetData(obj.state_id_fk);


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
    public registration_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        registration_tableEntities obj = new registration_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [registration_master] WHERE [empid] = @empid";

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
        List<registration_tableEntities> oList = new List<registration_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [registration_master] ";
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

    public List<registration_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<registration_tableEntities> oList = new List<registration_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from registration_master where [is_active]=1 ";
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
            strQ = @"SELECT empid,f_name FROM [registration_master]  ";

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
                objData.NAME = dtTable.Rows[intRow]["f_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["f_name"];
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
