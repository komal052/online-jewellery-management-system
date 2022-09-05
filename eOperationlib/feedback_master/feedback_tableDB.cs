using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class feedback_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "feedback_master";

    public feedback_tableDB()
        : base()
    {
    }

    public int OnInsert(feedback_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [feedback_master]
                                   ([user_id_fk],[subject],[message])
                             VALUES
                                   (@user_id_fk,@subject,@message)";

            OnClearParameter();
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@subject", SqlDbType.VarChar, 50, obj.Subject, ParameterDirection.Input);
            AddParameter("@message", SqlDbType.VarChar, 50, obj.Message, ParameterDirection.Input);
          
          
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(feedback_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [feedback_master]
                              SET   [user_id_fk]=@user_id_fk,
                                    [subject]=@subject,
                                    [message]=@message
                                    
                         WHERE [feedback_id_pk]=@feedback_id_pk";
            OnClearParameter();
            AddParameter("@feedback_id_pk", SqlDbType.Int, 50, obj.Feedback_id_pk, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
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
            strQ += @"UPDATE [feedback_master]
                            SET [is_active]=0
                         WHERE [feedback_id_pk]=@feedback_id_pk";

            OnClearParameter();
            AddParameter("@feedback_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private feedback_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            feedback_tableEntities obj = new feedback_tableEntities();

            obj.Feedback_id_pk = (drRow["feedback_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["feedback_id_pk"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Subject = (drRow["subject"].Equals(DBNull.Value)) ? "" : (string)drRow["subject"];
            obj.Message = (drRow["message"].Equals(DBNull.Value)) ? "" : (string)drRow["message"];
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
    public feedback_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        feedback_tableEntities obj = new feedback_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT f.*,r.f_name,r.l_name  FROM [feedback_master] f 
            JOIN [registration_master] r ON f.[user_id_fk]=r.[user_id_pk]  
           WHERE [feedback_id_pk] = @feedback_id_pk";

            OnClearParameter();
            AddParameter("feedback_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<feedback_tableEntities> oList = new List<feedback_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [feedback_master] ";
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

    public List<feedback_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<feedback_tableEntities> oList = new List<feedback_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT f.*,r.f_name,r.l_name  FROM [feedback_master] f 
            JOIN [registration_master] r ON f.[user_id_fk]=r.[user_id_pk]  
           WHERE f.[is_active]=1";
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
            strQ = @"SELECT feedback_id_pk,subject FROM [feedback_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["feedback_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["feedback_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["subject"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["subject"];
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
