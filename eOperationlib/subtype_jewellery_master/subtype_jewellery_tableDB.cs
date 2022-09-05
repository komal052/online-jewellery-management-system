using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class subtype_jewellery_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "subtype_jewellery_master";

    public subtype_jewellery_tableDB()
        : base()
    {
    }

    public int OnInsert(subtype_jewellery_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [subtype_jewellery_master]
                                   ([jewellery_id_fk],[subtype],[price],[images],[description])
                             VALUES
                                   (@jewellery_id_fk,@subtype,@price,@images,@description)";

            OnClearParameter();
           
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@subtype", SqlDbType.VarChar, 50, obj.Subtype, ParameterDirection.Input);
            AddParameter("@price", SqlDbType.VarChar, 50, obj.Price, ParameterDirection.Input);
            AddParameter("@images", SqlDbType.VarChar, 50, obj.Images, ParameterDirection.Input);
            AddParameter("@description", SqlDbType.VarChar, 50, obj.Description, ParameterDirection.Input);
          
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(subtype_jewellery_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [subtype_jewellery_master]

                             SET    [subtype]=@subtype,
                                    [jewellery_id_fk]=@jewellery_id_fk,
                                    [price]=@price,
                                    [images]=@images,
                                    [description]=@description

                         WHERE [Subtype_jewellery_id_pk]=@Subtype_jewellery_id_pk";
            OnClearParameter();
            AddParameter("@Subtype_jewellery_id_pk", SqlDbType.Int, 50, obj.Subtype_jewellery_id_pk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@subtype", SqlDbType.VarChar, 50, obj.Subtype, ParameterDirection.Input);
            AddParameter("@price", SqlDbType.VarChar, 50, obj.Price, ParameterDirection.Input);
            AddParameter("@images", SqlDbType.VarChar, 50, obj.Images, ParameterDirection.Input);
            AddParameter("@description", SqlDbType.VarChar, 50, obj.Description, ParameterDirection.Input);
            
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
            strQ += @"UPDATE [subtype_jewellery_master]
                            SET [is_active]=0
                         WHERE [Subtype_jewellery_id_pk]=@Subtype_jewellery_id_pk";

            OnClearParameter();
            AddParameter("@Subtype_jewellery_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private subtype_jewellery_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            subtype_jewellery_tableEntities obj = new subtype_jewellery_tableEntities();

            obj.Subtype_jewellery_id_pk = (drRow["Subtype_jewellery_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["Subtype_jewellery_id_pk"];         
            obj.Jewellery_id_fk = (drRow["jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Subtype = (drRow["subtype"].Equals(DBNull.Value)) ? "" : (string)drRow["subtype"];
            obj.Price = (drRow["price"].Equals(DBNull.Value)) ? "" : (string)drRow["price"];
            obj.Images = (drRow["images"].Equals(DBNull.Value)) ? "" : (string)drRow["images"]; 
            obj.Description  = (drRow["description"].Equals(DBNull.Value)) ? "" : (string)drRow["description"];
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
    public subtype_jewellery_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        subtype_jewellery_tableEntities obj = new subtype_jewellery_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT sj.*,j.jewellery_name FROM [subtype_jewellery_master] sj
             JOIN [jewellery_master] j  ON  sj.[jewellery_id_fk]=j.[jewellery_id_pk]
            WHERE [Subtype_jewellery_id_pk] = @Subtype_jewellery_id_pk";

            OnClearParameter();
            AddParameter("Subtype_jewellery_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<subtype_jewellery_tableEntities> oList = new List<subtype_jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [subtype_jewellery_master] ";
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

    public List<subtype_jewellery_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<subtype_jewellery_tableEntities> oList = new List<subtype_jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT sj.*,j.jewellery_name FROM [subtype_jewellery_master] sj
             JOIN [jewellery_master] j  ON  sj.[jewellery_id_fk]=j.[jewellery_id_pk]
             WHERE  sj.[is_active]=1 ";
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
            strQ = @"SELECT Subtype_jewellery_id_pk,subtype FROM [subtype_jewellery_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["Subtype_jewellery_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["Subtype_jewellery_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["subtype"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["subtype"];
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
            strQ = @"SELECT count(subtype_jewellery_id_pk) from [subtype_jewellery_master] where [is_active] = 1";
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
    public List<subtype_jewellery_tableEntities> OnTopGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<subtype_jewellery_tableEntities> oList = new List<subtype_jewellery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT TOP 12 sj.*,j.jewellery_name FROM [subtype_jewellery_master] sj
             JOIN [jewellery_master] j  ON  sj.[jewellery_id_fk]=j.[jewellery_id_pk]
             WHERE  sj.[is_active]=1 ";
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
}
