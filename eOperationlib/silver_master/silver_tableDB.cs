using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class silver_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "silver_master";

    public silver_tableDB()
        : base()
    {
    }

    public int OnInsert(silver_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [silver_master]
                                   ([weight],[carat],[certi_id_fk])
                             VALUES
                                   (@weight,@carat,@certi_id_fk)";

            OnClearParameter();
            AddParameter("@weight", SqlDbType.VarChar, 50, obj.Weight, ParameterDirection.Input);
            AddParameter("@carat", SqlDbType.VarChar, 50, obj.Carat, ParameterDirection.Input);
            AddParameter("@certi_id_fk", SqlDbType.VarChar, 50, obj.Certi_id_fk, ParameterDirection.Input);
                      
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(silver_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [silver_master]
                             SET  
                                    [weight]=@weight,   
                                    [carat]=@carat,         
                                    [certi_id_fk]=@certi_id_fk

                         WHERE [silver_id_pk]=@silver_id_pk";
            OnClearParameter();
            AddParameter("@silver_id_pk", SqlDbType.Int, 50, obj.Silver_id_pk, ParameterDirection.Input);
            AddParameter("@weight", SqlDbType.VarChar, 50, obj.Weight, ParameterDirection.Input);
            AddParameter("@carat", SqlDbType.VarChar, 50, obj.Carat, ParameterDirection.Input);
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
            strQ += @"UPDATE [silver_master]
                            SET [is_active]=0
                         WHERE [silver_id_pk]=@silver_id_pk";

            OnClearParameter();
            AddParameter("@silver_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private silver_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            silver_tableEntities obj = new silver_tableEntities();

            obj.Silver_id_pk = (drRow["silver_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["silver_id_pk"];
            obj.Weight = (drRow["weight"].Equals(DBNull.Value)) ? "" : (string)drRow["weight"];
            obj.Carat = (drRow["carat"].Equals(DBNull.Value)) ? "" : (string)drRow["carat"];
            obj.Certi_id_fk = (drRow["certi_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["certi_id_fk"];
            obj.Certi_no= (drRow["certi_no"].Equals(DBNull.Value)) ? "" : (string)drRow["certi_no"];
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
    public silver_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        silver_tableEntities obj = new silver_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT s.*,c.certi_no FROM [silver_master] s 
            JOIN [certificate_master] c ON s.[certi_id_fk]=c.[certi_id_pk] 
            WHERE [silver_id_pk] = @silver_id_pk ";

            OnClearParameter();
            AddParameter("silver_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<silver_tableEntities> oList = new List<silver_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [silver_master] ";
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

    public List<silver_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<silver_tableEntities> oList = new List<silver_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT s.*,c.certi_no FROM [silver_master] s 
                     JOIN [certificate_master] c ON s.[certi_id_fk]=c.[certi_id_pk] 
                     WHERE  s.[is_active]=1 ";
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
            strQ = @"SELECT silver_id_pk, FROM [silver_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["silver_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["silver_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["weight"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["weight"];
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
            strQ = @"SELECT count(silver_id_pk) from [silver_master] where [is_active] = 1";
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
