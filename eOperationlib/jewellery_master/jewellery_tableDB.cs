using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class jewellery_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "jewellery_master";

    public jewellery_tableDB()
        : base()
    {
    }

    public int OnInsert(jewellery_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [jewellery_master]
                                   ([jewellery_name],[diamond_id_fk],[gold_id_fk],[images])
                             VALUES
                                   (@jewellery_name,@diamond_id_fk,@gold_id_fk,@images)";

            OnClearParameter();
            AddParameter("@jewellery_name", SqlDbType.VarChar, 50, obj.Jewellery_name, ParameterDirection.Input);
            AddParameter("@diamond_id_fk", SqlDbType.VarChar, 50, obj.Diamond_id_fk, ParameterDirection.Input);
            AddParameter("@gold_id_fk", SqlDbType.VarChar, 50, obj.Gold_id_fk, ParameterDirection.Input);            
            AddParameter("@images", SqlDbType.VarChar, 50, obj.Images, ParameterDirection.Input);
          
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(jewellery_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [jewellery_master]
                             SET    [jewellery_name]=@jewellery_name,
                                    [diamond_id_fk]=@diamond_id_fk,
                                    [gold_id_fk]=@gold_id_fk,                                    
                                    [images]=@images

                         WHERE [jewellery_id_pk]=@jewellery_id_pk";
            OnClearParameter();
            AddParameter("@jewellery_id_pk", SqlDbType.Int, 50, obj.Jewellery_id_pk, ParameterDirection.Input);
            AddParameter("@jewellery_name", SqlDbType.VarChar, 50, obj.Jewellery_name, ParameterDirection.Input);
            AddParameter("@diamond_id_fk", SqlDbType.VarChar, 50, obj.Diamond_id_fk, ParameterDirection.Input);
            AddParameter("@gold_id_fk", SqlDbType.VarChar, 50, obj.Gold_id_fk, ParameterDirection.Input);            
            AddParameter("@images", SqlDbType.VarChar, 50, obj.Images, ParameterDirection.Input);
            
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
            strQ += @"UPDATE [jewellery_master]
                            SET [is_active]=0
                         WHERE [jewellery_id_pk]=@jewellery_id_pk";

            OnClearParameter();
            AddParameter("@jewellery_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private jewellery_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            jewellery_tableEntities obj = new jewellery_tableEntities();

            obj.Jewellery_id_pk = (drRow["jewellery_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_pk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Diamond_id_fk = (drRow["diamond_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["diamond_id_fk"];
            obj.Diamond_color= (drRow["diamond_color"].Equals(DBNull.Value)) ? "" : (string)drRow["diamond_color"];
            obj.Shape = (drRow["shape"].Equals(DBNull.Value)) ? "" : (string)drRow["shape"];
            obj.Gold_id_fk = (drRow["gold_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["gold_id_fk"];
            obj.Gold_type = (drRow["gold_type"].Equals(DBNull.Value)) ? "" : (string)drRow["gold_type"];                        
            obj.Images  = (drRow["images"].Equals(DBNull.Value)) ? "" : (string)drRow["images"];
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
    public jewellery_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        jewellery_tableEntities obj = new jewellery_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT j.*,d.diamond_color, d.shape,g.gold_type FROM [jewellery_master] j 
           JOIN [diamond_master] d ON j.[diamond_id_fk]=d.[diamond_id_pk]
           JOIN [gold_master] g ON j.[gold_id_fk]=g.[gold_id_pk]           
           WHERE [jewellery_id_pk] = @jewellery_id_pk";

            OnClearParameter();
            AddParameter("jewellery_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<jewellery_tableEntities> oList = new List<jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [jewellery_master] ";
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

    public List<jewellery_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<jewellery_tableEntities> oList = new List<jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT j.*,d.diamond_color, d.shape,g.gold_type
            FROM [jewellery_master] j 
           JOIN [diamond_master] d ON j.[diamond_id_fk]=d.[diamond_id_pk]
           JOIN [gold_master] g ON j.[gold_id_fk]=g.[gold_id_pk]           
           WHERE  j.[is_active]=1 ";

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
            strQ = @"SELECT jewellery_id_pk,jewellery_name FROM [jewellery_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["jewellery_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["jewellery_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["jewellery_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["jewellery_name"];
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
            strQ = @"SELECT count(jewellery_id_pk) from [jewellery_master] where [is_active] = 1";
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
