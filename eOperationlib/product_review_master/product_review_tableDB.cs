using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class product_review_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "product_review_master";

    public product_review_tableDB()
        : base()
    {
    }

    public int OnInsert(product_review_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [product_review_master]
                                   ([subtype_jewellery_id_fk],[rating],[description],[user_id_fk])
                             VALUES
                                   (@subtype_jewellery_id_fk,@rating,@description,@user_id_fk)";

            OnClearParameter();
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);            
            AddParameter("@rating", SqlDbType.VarChar, 50, obj.Rating, ParameterDirection.Input);
            AddParameter("@description", SqlDbType.VarChar, 50, obj.Description, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(product_review_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [product_review_master]
                             SET    [subtype_jewellery_id_fk]=@subtype_jewellery_id_fk,
                                    [rating]=@rating,                                    
                                    [description]=@description,
                                    [user_id_fk]=@user_id_fk
                                   
                         WHERE [review_id_pk]=@review_id_pk";
            OnClearParameter();
            AddParameter("@review_id_pk", SqlDbType.Int, 50, obj.Review_id_pk, ParameterDirection.Input);
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@rating", SqlDbType.VarChar, 50, obj.Rating, ParameterDirection.Input);
            AddParameter("@description", SqlDbType.VarChar, 50, obj.Description, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
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
            strQ += @"UPDATE [product_review_master]
                            SET [is_active]=0
                         WHERE [review_id_pk]=@review_id_pk";

            OnClearParameter();
            AddParameter("@review_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private product_review_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            product_review_tableEntities obj = new product_review_tableEntities();

            obj.Review_id_pk = (drRow["review_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["review_id_pk"];
            obj.Subtype_jewellery_id_fk = (drRow["subtype_jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["subtype_jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Rating = (drRow["rating"].Equals(DBNull.Value)) ? "" : (string)drRow["rating"];
            obj.Description = (drRow["description"].Equals(DBNull.Value)) ? "" : (string)drRow["description"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Profile = (drRow["profile"].Equals(DBNull.Value)) ? "" : (string)drRow["profile"];
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
    public product_review_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        product_review_tableEntities obj = new product_review_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT p.*,j.jewellery_name, sj.subtype,r.f_name,r.l_name,r.profile FROM [product_review_master] p
            JOIN [subtype_jewellery_master] sj ON p.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]            
            JOIN [registartion_master] r ON p.[user_id_fk]= r.[user_id_pk]            
            WHERE [review_id_pk] = @review_id_pk";

            OnClearParameter();
            AddParameter("review_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<product_review_tableEntities> oList = new List<product_review_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [product_review_master] ";
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

    public List<product_review_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<product_review_tableEntities> oList = new List<product_review_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT p.*,j.jewellery_name, sj.subtype,r.f_name,r.l_name,r.profile FROM [product_review_master] p
            JOIN [subtype_jewellery_master] sj ON p.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk] 
            JOIN [registration_master] r ON p.[user_id_fk]=r.[user_id_pk]
             WHERE p.[is_active]=1";

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
    public List<product_review_tableEntities> OnGetjewelleryreviewListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<product_review_tableEntities> oList = new List<product_review_tableEntities>();
        string strQ = "";

        try
        {            

            strQ = @"SELECT p.*,j.jewellery_name, sj.subtype,r.f_name,r.l_name,r.profile FROM [product_review_master] p
            JOIN [subtype_jewellery_master] sj ON p.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk] 
            JOIN [registration_master] r ON p.[user_id_fk]=r.[user_id_pk]
             WHERE p.[is_active]=1 AND p.[subtype_jewellery_id_fk]=@subtype_jewellery_id_fk";

            OnClearParameter();
            AddParameter("subtype_jewellery_id_fk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
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
            strQ = @"SELECT review_id_pk,jewellery_name FROM [product_review_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["review_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["review_id_pk"];
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
}
