using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class diamond_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "diamond_master";

    public diamond_tableDB()
        : base()
    {
    }

    public int OnInsert(diamond_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [diamond_master]
                                   ([diamond_color],[diamond_cut],[polish],[clarity],[certi_id_fk],[shape],[stone_weight],[selling_cost],[buying_cost])
                             VALUES
                                   (@diamond_color,@diamond_cut,@polish,@clarity,@certi_id_fk,@shape,@stone_weight,@selling_cost,@buying_cost)";

            OnClearParameter();
            AddParameter("@diamond_color", SqlDbType.VarChar, 50, obj.Diamond_color, ParameterDirection.Input);
            AddParameter("@diamond_cut", SqlDbType.VarChar, 50, obj.Diamond_cut, ParameterDirection.Input);
            AddParameter("@polish", SqlDbType.VarChar, 50, obj.Polish, ParameterDirection.Input);
            AddParameter("@clarity", SqlDbType.VarChar, 50, obj.Clarity, ParameterDirection.Input);
            AddParameter("@certi_id_fk", SqlDbType.VarChar, 50, obj.Certi_id_fk, ParameterDirection.Input);
            AddParameter("@shape", SqlDbType.VarChar, 50, obj.Shape, ParameterDirection.Input);
            AddParameter("@stone_weight", SqlDbType.VarChar, 50, obj.Stone_weight, ParameterDirection.Input);
            AddParameter("@selling_cost", SqlDbType.VarChar, 50, obj.Selling_cost, ParameterDirection.Input);
            AddParameter("@buying_cost", SqlDbType.VarChar, 50, obj.Buying_cost, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(diamond_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [diamond_master]
                             SET   [diamond_color]=@diamond_color,
                                   [diamond_cut]=@diamond_cut,
                                   [polish]=@polish,
                                   [clarity]=@clarity,
                                   [certi_id_fk]=@certi_id_fk,
                                   [shape]=@shape,
                                   [stone_weight]=@stone_weight,
                                   [selling_cost]=@selling_cost,
                                   [buying_cost]=@buying_cost

                         WHERE [diamond_id_pk]=@diamond_id_pk";
            OnClearParameter();
            AddParameter("@diamond_id_pk", SqlDbType.Int, 50, obj.Diamond_id_pk, ParameterDirection.Input);
            AddParameter("@diamond_color", SqlDbType.VarChar, 50, obj.Diamond_color, ParameterDirection.Input);
            AddParameter("@diamond_cut", SqlDbType.VarChar, 50, obj.Diamond_cut, ParameterDirection.Input);
            AddParameter("@polish", SqlDbType.VarChar, 50, obj.Polish, ParameterDirection.Input);
            AddParameter("@clarity", SqlDbType.VarChar, 50, obj.Clarity, ParameterDirection.Input);
            AddParameter("@certi_id_fk", SqlDbType.VarChar, 50, obj.Certi_id_fk, ParameterDirection.Input);
            AddParameter("@shape", SqlDbType.VarChar, 50, obj.Shape, ParameterDirection.Input);
            AddParameter("@stone_weight", SqlDbType.VarChar, 50, obj.Stone_weight, ParameterDirection.Input);
            AddParameter("@selling_cost", SqlDbType.VarChar, 50, obj.Selling_cost, ParameterDirection.Input);
            AddParameter("@buying_cost", SqlDbType.VarChar, 50, obj.Buying_cost, ParameterDirection.Input);
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
            strQ += @"UPDATE [diamond_master]
                            SET [is_active]=0
                         WHERE [diamond_id_pk]=@diamond_id_pk";

            OnClearParameter();
            AddParameter("@diamond_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private diamond_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;s
            diamond_tableEntities obj = new diamond_tableEntities();

            obj.Diamond_id_pk = (drRow["diamond_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["diamond_id_pk"];
            obj.Diamond_color = (drRow["diamond_color"].Equals(DBNull.Value)) ? "" : (string)drRow["diamond_color"];
            obj.Diamond_cut = (drRow["diamond_cut"].Equals(DBNull.Value)) ? "" : (string)drRow["diamond_cut"];
            obj.Polish = (drRow["polish"].Equals(DBNull.Value)) ? "" : (string)drRow["polish"];
            obj.Clarity = (drRow["clarity"].Equals(DBNull.Value)) ? "" : (string)drRow["clarity"];
            obj.Certi_id_fk = (drRow["certi_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["certi_id_fk"];
            obj.Certi_no = (drRow["certi_no"].Equals(DBNull.Value)) ? "" : (string)drRow["certi_no"];
            obj.Image = (drRow["image"].Equals(DBNull.Value)) ? "" : (string)drRow["image"];
            obj.Shape = (drRow["shape"].Equals(DBNull.Value)) ? "" : (string)drRow["shape"];
            obj.Stone_weight = (drRow["stone_weight"].Equals(DBNull.Value)) ? "" : (string)drRow["stone_weight"]; 
            obj.Selling_cost = (drRow["selling_cost"].Equals(DBNull.Value)) ? "" : (string)drRow["selling_cost"];
            obj.Buying_cost = (drRow["buying_cost"].Equals(DBNull.Value)) ? ""  : (string)drRow["buying_cost"];
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
    public diamond_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        diamond_tableEntities obj = new diamond_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT d.*,c.certi_no,c.image FROM [diamond_master] d 
                     JOIN [certificate_master]c ON d.[certi_id_fk] = c.[certi_id_pk] 
                     WHERE [diamond_id_pk]=@diamond_id_pk";

            OnClearParameter();
            AddParameter("diamond_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<diamond_tableEntities> oList = new List<diamond_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [diamond_master] ";
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

    public List<diamond_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<diamond_tableEntities> oList = new List<diamond_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT d.*,c.certi_no,c.image FROM [diamond_master] d 
                     JOIN [certificate_master] c ON d.[certi_id_fk]=c.[certi_id_pk]
                     WHERE d.[is_active]=1 ";
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
            strQ = @"SELECT diamond_id_pk,diamond_cut FROM [diamond_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["diamond_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["diamond_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["diamond_cut"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["diamond_cut"];
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
            strQ = @"SELECT count(diamond_id_pk) from [diamond_master] where [is_active] = 1";
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
