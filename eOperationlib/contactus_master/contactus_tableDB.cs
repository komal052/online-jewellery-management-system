using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class contactus_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "contactus_master";

    public contactus_tableDB()
    {
    }

    public int OnInsert(contactus_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [contactus_master]
                                   ([name],[email_id],[subject],[message])
                             VALUES
                                   (@name,@email_id,@subject,@message)";

            OnClearParameter();
            AddParameter("@name", SqlDbType.VarChar, 50, obj.Name, ParameterDirection.Input);
            AddParameter("@email_id", SqlDbType.VarChar, 50, obj.Email_id, ParameterDirection.Input);
            AddParameter("@subject", SqlDbType.VarChar, 50, obj.Subject, ParameterDirection.Input);
            AddParameter("@message", SqlDbType.VarChar, 50, obj.Message, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public int OnUpdate(contactus_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [contactus_master]
                             SET    [name]=@name,
                                    [email_id]=@email_id,
                                    [subject]=@subject,
                                    [message]=@message
                         WHERE [contactus_id_pk]=@contactus_id_pk";
            OnClearParameter();
            AddParameter("@contactus_id_pk", SqlDbType.Int, 50, obj.Contactus_id_pk, ParameterDirection.Input);
            AddParameter("@name", SqlDbType.VarChar, 50, obj.Name, ParameterDirection.Input);
            AddParameter("@email_id", SqlDbType.VarChar, 50, obj.Email_id, ParameterDirection.Input);
            AddParameter("@subject", SqlDbType.VarChar, 50, obj.Subject, ParameterDirection.Input);
            AddParameter("@message", SqlDbType.VarChar, 50, obj.Message, ParameterDirection.Input);


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
            strQ += @"Update [contactus_master]
                        SET [is_active]=0
                         WHERE [contactus_id_pk]=@contactus_id_pk";

            OnClearParameter();
            AddParameter("@contactus_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private contactus_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            contactus_tableEntities obj = new contactus_tableEntities();

            obj.Contactus_id_pk = (drRow["contactus_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["contactus_id_pk"];
            obj.Name = (drRow["name"].Equals(DBNull.Value)) ? "" : (string)drRow["name"];
            obj.Email_id = (drRow["email_id"].Equals(DBNull.Value)) ? "" : (string)drRow["email_id"];
            obj.Subject = (drRow["subject"].Equals(DBNull.Value)) ? "" : (string)drRow["subject"];
            obj.Message = (drRow["message"].Equals(DBNull.Value)) ? "" : (string)drRow["message"];
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

    public contactus_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        contactus_tableEntities obj = new contactus_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('contactus_master') ";

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

    public contactus_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        contactus_tableEntities obj = new contactus_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [contactus_master] WHERE [contactus_id_pk] = @contactus_id_pk ";

            OnClearParameter();
            AddParameter("contactus_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<contactus_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<contactus_tableEntities> oList = new List<contactus_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from [contactus_master] where [is_active]=1 ";
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
            strQ = @"SELECT [contactus_master].contactus_id_pk
                                   ,[contactus_master].name
                                    FROM [contactus_master] ";

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
                objData.ID = dtTable.Rows[intRow]["contactus_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["contactus_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["name"];
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
    public List<contactus_tableEntities> OnGetLastListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<contactus_tableEntities> oList = new List<contactus_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT TOP 5 * FROM contactus_master where [is_active]=1 AND [is_read]=1
                     ORDER BY [contactus_id_pk] DESC";

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

    public int OnGetLimitListdt()
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [contactus_master]
                               SET  [is_read]= 0 ";
            OnClearParameter();
    
            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
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
            strQ = @"SELECT count(contactus_id_pk) from [contactus_master] where [is_active] = 1  AND [is_read]=1 ";
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
