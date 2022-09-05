using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;


public class certificate_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "certificate_master";

    public certificate_tableDB()
    {
    }

    public int OnInsert(certificate_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [certificate_master]
                                   ([certi_no],[image])
                             VALUES
                                   (@certi_no,@image)";

            OnClearParameter();
            AddParameter("@certi_no", SqlDbType.VarChar, 50, obj.Certi_no, ParameterDirection.Input);
            AddParameter("@image", SqlDbType.VarChar, 50, obj.Image, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(certificate_tableEntities obj)
    {
        string strQ = "";
        try
        {

            strQ = @"UPDATE [certificate_master]
                             SET    [certi_no]=@certi_no,
                                    [image]=@image
                         WHERE [certi_id_pk]=@certi_id_pk";
            OnClearParameter();
            AddParameter("@certi_id_pk", SqlDbType.Int, 50, obj.Certi_id_pk, ParameterDirection.Input);
            AddParameter("@certi_no", SqlDbType.VarChar, 50, obj.Certi_no, ParameterDirection.Input);
            AddParameter("@image", SqlDbType.VarChar, 50, obj.Image, ParameterDirection.Input);

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
            strQ += @"Update [certificate_master]
                        SET [is_active]=0
                         WHERE [certi_id_pk]=@certi_id_pk";

            OnClearParameter();
            AddParameter("@certi_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private certificate_tableEntities BuildEntities(DataRow drRow)

    {

        try
        {
            //DateTime dtdata;

            certificate_tableEntities obj = new certificate_tableEntities();

            obj.Certi_id_pk = (drRow["certi_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["certi_id_pk"];
            obj.Certi_no = (drRow["certi_no"].Equals(DBNull.Value)) ? "" : (string)drRow["certi_no"];
            obj.Image = (drRow["image"].Equals(DBNull.Value)) ? "" : (string)drRow["image"];
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

    public certificate_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        certificate_tableEntities obj = new certificate_tableEntities();

        string strQ = "";

        try
        {

            strQ = @"SELECT IDENT_CURRENT('certificate_master') ";

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

    public certificate_tableEntities OnGetData(int ID)

    {
        Exception exForce;
        DataTable dtTable;

        certificate_tableEntities obj = new certificate_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [certificate_master] WHERE [certi_id_pk] = @certi_id_pk ";

            OnClearParameter();
            AddParameter("certi_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
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


    public List<certificate_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<certificate_tableEntities> oList = new List<certificate_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from [certificate_master] where [is_active]=1";
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
            strQ = @"SELECT [certificate_master].certi_id_pk
                                   ,[certificate_master].image
                                    FROM [certificate_master] ";

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
                objData.ID = dtTable.Rows[intRow]["certi_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["certi_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["image"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["image"];
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
            strQ = @"SELECT count(certi_id_pk) from [certificate_master] where [is_active] = 1";
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
