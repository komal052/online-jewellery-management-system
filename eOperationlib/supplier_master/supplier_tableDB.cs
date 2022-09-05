using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class supplier_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "supplier_master";

    public supplier_tableDB()
    {
    }

    public int OnInsert(supplier_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [supplier_master]
                                   ([sup_name],[factory_name],[factory_contact],[sup_contact])
                             VALUES
                                   (@sup_name,@factory_name,@factory_contact,@sup_contact)";

            OnClearParameter();
            AddParameter("@sup_name", SqlDbType.VarChar, 50, obj.Sup_name, ParameterDirection.Input);
            AddParameter("@factory_name", SqlDbType.VarChar, 50, obj.Factory_name, ParameterDirection.Input);
            AddParameter("@factory_contact", SqlDbType.VarChar, 50, obj.Factory_contact, ParameterDirection.Input);
            AddParameter("@sup_contact", SqlDbType.VarChar, 50, obj.Sup_contact, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public int OnUpdate(supplier_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [supplier_master]
                             SET    [sup_name]=@sup_name,
                                    [factory_name]=@factory_name,
                                    [factory_contact]=@factory_contact,
                                    [sup_contact]=@sup_contact
                         WHERE [sup_id_pk]=@sup_id_pk";
            OnClearParameter();
            AddParameter("@sup_id_pk", SqlDbType.Int, 50, obj.Sup_id_pk, ParameterDirection.Input);
            AddParameter("@sup_name", SqlDbType.VarChar, 50, obj.Sup_name, ParameterDirection.Input);
            AddParameter("@factory_name", SqlDbType.VarChar, 50, obj.Factory_name, ParameterDirection.Input);
            AddParameter("@factory_contact", SqlDbType.VarChar, 50, obj.Factory_contact, ParameterDirection.Input);
            AddParameter("@sup_contact", SqlDbType.VarChar, 50, obj.Sup_contact, ParameterDirection.Input);

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
            strQ += @"Update [supplier_master]
                        SET [is_active]=0
                         WHERE [sup_id_pk]=@sup_id_pk";

            OnClearParameter();
            AddParameter("@sup_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private supplier_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            supplier_tableEntities obj = new supplier_tableEntities();

            obj.Sup_id_pk = (drRow["sup_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["sup_id_pk"];
            obj.Sup_name = (drRow["sup_name"].Equals(DBNull.Value)) ? "" : (string)drRow["sup_name"];
            obj.Factory_name = (drRow["factory_name"].Equals(DBNull.Value)) ? "" : (string)drRow["factory_name"];
            obj.Factory_contact = (drRow["factory_contact"].Equals(DBNull.Value)) ? "" : (string)drRow["factory_contact"];
            obj.Sup_contact = (drRow["sup_contact"].Equals(DBNull.Value)) ? "" : (string)drRow["sup_contact"];
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

    public supplier_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        supplier_tableEntities obj = new supplier_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('supplier_master') ";

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

    public supplier_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        supplier_tableEntities obj = new supplier_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [supplier_master] WHERE [sup_id_pk] = @sup_id_pk ";

            OnClearParameter();
            AddParameter("sup_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<supplier_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<supplier_tableEntities> oList = new List<supplier_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from [supplier_master] where [is_active]=1";
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
            strQ = @"SELECT [supplier_master].sup_id_pk
                                   ,[supplier_master].sup_name
                                    FROM [supplier_master] ";

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
                objData.ID = dtTable.Rows[intRow]["sup_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["sup_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["sup_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["sup_name"];
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
            strQ = @"SELECT count(sup_id_pk) from [supplier_master] where [is_active] = 1";
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
