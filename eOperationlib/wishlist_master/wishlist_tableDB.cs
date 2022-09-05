using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class wishlist_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "wishlist_master";

    public wishlist_tableDB()
        : base()
    {
    }

    public int OnInsert(wishlist_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [wishlist_master]
                                   ([subtype_jewellery_id_fk],[user_id_fk])
                             VALUES
                                   (@subtype_jewellery_id_fk,@user_id_fk)";

            OnClearParameter();
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(wishlist_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [wishlist_master]                                    
                             SET   [subtype_jewellery_id_fk],
                                   [user_id_fk]
                                   
                         WHERE [wishlist_id_pk]=@wishlist_id_pk";
            OnClearParameter();
            AddParameter("@wishlist_id_pk", SqlDbType.Int, 50, obj.Wishlist_id_pk, ParameterDirection.Input);
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);
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
            strQ += @"Delete from [wishlist_master]                            
                         WHERE [wishlist_id_pk]=@wishlist_id_pk";

            OnClearParameter();
            AddParameter("@wishlist_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private wishlist_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            wishlist_tableEntities obj = new wishlist_tableEntities();

            obj.Wishlist_id_pk = (drRow["wishlist_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["wishlist_id_pk"];            
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Subtype_jewellery_id_fk  = (drRow["subtype_jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["subtype_jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];            
            obj.Price = (drRow["price"].Equals(DBNull.Value)) ? "" : (string)drRow["price"];
            obj.Images = (drRow["images"].Equals(DBNull.Value)) ? "" : (string)drRow["images"];



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
    public wishlist_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        wishlist_tableEntities obj = new wishlist_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT w.*,r.f_name,r.l_name,j.jewellery_name,sj.price,sj.images FROM [wishlist_master] w
            JOIN [subtype_jewellery_master] sj ON w.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]
            JOIN [registration_master] r ON w.[user_id_fk]=r.[user_id_pk]
            WHERE [wishlist_id_pk] = @wishlist_id_pk";

            OnClearParameter();
            AddParameter("wishlist_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<wishlist_tableEntities> oList = new List<wishlist_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [wishlist_master] ";
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

    public List<wishlist_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<wishlist_tableEntities> oList = new List<wishlist_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT w.*,r.f_name,r.l_name,j.jewellery_name,sj.price,sj.images FROM [wishlist_master] w
            JOIN [subtype_jewellery_master] sj ON w.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]
            JOIN [registration_master] r ON w.[user_id_fk]=r.[user_id_pk]";
            

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

    public List<wishlist_tableEntities> OnGetUserListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<wishlist_tableEntities> oList = new List<wishlist_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT w.*,r.f_name,r.l_name,j.jewellery_name,sj.price,sj.images FROM [wishlist_master] w
            JOIN [subtype_jewellery_master] sj ON w.[subtype_jewellery_id_fk]= sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]
            JOIN [registration_master] r ON w.[user_id_fk]=r.[user_id_pk]
            WHERE[user_id_fk] = @user_id_fk";


            OnClearParameter();
            AddParameter("user_id_fk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
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
            strQ = @"SELECT wishlist_id_pk,jewellery_name FROM [wishlist_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["wishlist_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["wishlist_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["date"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["date"];
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
