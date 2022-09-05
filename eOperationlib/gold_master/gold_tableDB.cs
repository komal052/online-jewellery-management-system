using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class gold_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "gold_master";

    public gold_tableDB()
        : base()
    {
    }

    public int OnInsert(gold_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [gold_master]
                                   ([gold_type],[carat],[weight],[certi_id_fk])
                             VALUES
                                   (@gold_type,@carat,@weight,@certi_id_fk)";

            OnClearParameter();
            AddParameter("@gold_type", SqlDbType.VarChar, 50, obj.Gold_type, ParameterDirection.Input);
            AddParameter("@carat", SqlDbType.VarChar, 50, obj.Carat, ParameterDirection.Input);
            AddParameter("@weight", SqlDbType.VarChar, 50, obj.Weight, ParameterDirection.Input);
            AddParameter("@certi_id_fk", SqlDbType.VarChar, 50, obj.Certi_id_fk, ParameterDirection.Input);
                      
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(gold_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [gold_master]
                             SET    [gold_type]=@gold_type,
                                    [carat]=@carat,
                                    [weight]=@weight,
                                    [certi_id_fk]=@certi_id_fk                                 

                         WHERE [gold_id_pk]=@gold_id_pk";
            OnClearParameter();
            AddParameter("@gold_id_pk", SqlDbType.Int, 50, obj.Gold_id_pk, ParameterDirection.Input);
            AddParameter("@gold_type", SqlDbType.VarChar, 50, obj.Gold_type, ParameterDirection.Input);
            AddParameter("@carat", SqlDbType.VarChar, 50, obj.Carat, ParameterDirection.Input);
            AddParameter("@weight", SqlDbType.VarChar, 50, obj.Weight, ParameterDirection.Input);
            AddParameter("@certi_id_fk", SqlDbType.VarChar, 50, obj.Certi_id_fk, ParameterDirection.Input);

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
            strQ += @"UPDATE [gold_master]
                            SET [is_active]=0
                         WHERE [gold_id_pk]=@gold_id_pk";

            OnClearParameter();
            AddParameter("@gold_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private gold_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            gold_tableEntities obj = new gold_tableEntities();

            obj.Gold_id_pk = (drRow["gold_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["gold_id_pk"];
            obj.Gold_type = (drRow["gold_type"].Equals(DBNull.Value)) ? "" : (string)drRow["gold_type"];
            obj.Carat = (drRow["carat"].Equals(DBNull.Value)) ? "" : (string)drRow["carat"];
            obj.Weight = (drRow["weight"].Equals(DBNull.Value)) ? "" : (string)drRow["weight"];
            obj.Certi_id_fk = (drRow["certi_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["certi_id_fk"];
            obj.Certi_no= (drRow["certi_no"].Equals(DBNull.Value)) ? "" : (string)drRow["certi_no"];
            obj.Image = (drRow["image"].Equals(DBNull.Value)) ? "" : (string)drRow["image"];
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
    public gold_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        gold_tableEntities obj = new gold_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT g.*,c.certi_no,c.image FROM [gold_master] g 
                     JOIN [certificate_master] c ON g.[certi_id_fk]=c.[certi_id_pk] 
                     WHERE [gold_id_pk] = @gold_id_pk";

            OnClearParameter();
            AddParameter("gold_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<gold_tableEntities> oList = new List<gold_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [gold_master] ";
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

    public List<gold_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<gold_tableEntities> oList = new List<gold_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT g.*,c.certi_no,c.image FROM [gold_master] g 
                     JOIN [certificate_master] c ON g.[certi_id_fk]=c.[certi_id_pk]
                     WHERE g.[is_active]=1 ";
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
            strQ = @"SELECT gold_id_pk,gold_type FROM [gold_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["gold_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["gold_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["gold_type"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["gold_type"];
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
            strQ = @"SELECT count(gold_id_pk) from [gold_master] where [is_active] = 1";
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
