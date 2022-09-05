using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class jewellery_image_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "jewellery_image_master";

    public jewellery_image_tableDB()
        : base()
    {
    }

    public int OnInsert(jewellery_image_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [jewellery_image_master]
                                   ([jewellery_id_fk],[img_path])
                             VALUES
                                   (@jewellery_id_fk,@img_path)";

            OnClearParameter();
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@img_path", SqlDbType.VarChar, 50, obj.Img_path, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(jewellery_image_tableEntities obj)
    {
        string strQ = "";
        try
        {

            strQ = @"UPDATE [jewellery_image_master]
                             SET    [img_path]=@img_path,
                                    [jewellery_id_fk]=@jewellery_id_fk
                         WHERE [image_id_pk]=@image_id_pk";
            OnClearParameter();
            AddParameter("@image_id_pk", SqlDbType.Int, 50, obj.Image_id_pk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@img_path", SqlDbType.VarChar, 50, obj.Img_path, ParameterDirection.Input);

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

            strQ += @"UPDATE [jewellery_image_master]
                            SET [is_active]=0
                         WHERE [image_id_pk]=@image_id_pk";

            OnClearParameter();
            AddParameter("@image_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private jewellery_image_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            jewellery_image_tableEntities obj = new jewellery_image_tableEntities();


            obj.Image_id_pk = (drRow["image_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["image_id_pk"];
            obj.Jewellery_id_fk = (drRow["jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_fk"];
            obj.Img_path = (drRow["img_path"].Equals(DBNull.Value)) ? "" : (string)drRow["img_path"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];






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
    public jewellery_image_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        jewellery_image_tableEntities obj = new jewellery_image_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,s.jewellery_name FROM [jewellery_image_master] c  JOIN [jewellery_master] s 
             ON c.[jewellery_id_fk]=s.[jewellery_id_pk] WHERE [image_id_pk]=@image_id_pk ";

            OnClearParameter();
            AddParameter("image_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<jewellery_image_tableEntities> oList = new List<jewellery_image_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [jewellery_image_master] ";
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

    public List<jewellery_image_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<jewellery_image_tableEntities> oList = new List<jewellery_image_tableEntities>();
        string strQ = "";

        try
        {

            strQ = @"SELECT c.*,s.jewellery_name FROM [jewellery_image_master] c  
            JOIN [jewellery_master] s ON c.[jewellery_id_fk]=s.[jewellery_id_pk] 
            WHERE c.[is_active]=1";

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
            strQ = @"SELECT image_id_pk,img_path FROM [jewellery_image_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["image_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["image_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["img_path"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["img_path"];
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
