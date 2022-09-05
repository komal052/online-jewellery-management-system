using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class discount_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "discount_master";

    public discount_tableDB()
        : base()
    {
    }

    public int OnInsert(discount_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [discount_master]
                                   ([discount],[jewellery_id_fk])
                             VALUES
                                   (@discount,@jewellery_id_fk)";

            OnClearParameter();
            AddParameter("@discount", SqlDbType.VarChar, 50, obj.Discount, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);          
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(discount_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [discount_master]
                             SET    [discount]=@discount,
                                    [jewellery_id_fk]=@jewellery_id_fk

                         WHERE [discount_id_pk]=@discount_id_pk";
            OnClearParameter();
            AddParameter("@discount_id_pk", SqlDbType.Int, 50, obj.Discount_id_pk, ParameterDirection.Input);
            AddParameter("@discount", SqlDbType.VarChar, 50, obj.Discount, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);                       

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
            strQ += @"UPDATE [discount_master]
                            SET [is_active]=0
                         WHERE [discount_id_pk]=@discount_id_pk";

            OnClearParameter();
            AddParameter("@discount_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private discount_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            discount_tableEntities obj = new discount_tableEntities();

            obj.Discount_id_pk = (drRow["discount_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["discount_id_pk"];
            obj.Discount = (drRow["discount"].Equals(DBNull.Value)) ? "" : (string)drRow["discount"];
            obj.Jewellery_id_fk = (drRow["jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
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
    public discount_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        discount_tableEntities obj = new discount_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT d.*,j.jewellery_name FROM [discount_master] d
            JOIN [jewellery_master] j ON d.[jewellery_id_fk]=j.[jewellery_id_pk]        
            WHERE [discount_id_pk] = @discount_id_pk";

            OnClearParameter();
            AddParameter("discount_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<discount_tableEntities> oList = new List<discount_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [discount_master] ";
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

    public List<discount_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<discount_tableEntities> oList = new List<discount_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT d.*,j.jewellery_name FROM [discount_master] d
            JOIN [jewellery_master] j ON d.[jewellery_id_fk]=j.[jewellery_id_pk]        
            WHERE  d.[is_active]=1";

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
            strQ = @"SELECT discount_id_pk,total_price FROM [discount_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["discount_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["discount_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["discount"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["discount"];
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
