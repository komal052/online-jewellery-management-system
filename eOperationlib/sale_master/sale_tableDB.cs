using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class sale_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "sale_master";

    public sale_tableDB()
        : base()
    {
    }

    public int OnInsert(sale_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [sale_master]
                                   ([jewellery_id_fk],[sale_date],[qty],[price])
                             VALUES
                                   (@jewellery_id_fk,@sale_date,@qty,@price)";

            OnClearParameter();
            
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@sale_date", SqlDbType.VarChar, 50, obj.Sale_date, ParameterDirection.Input);
            AddParameter("@qty", SqlDbType.VarChar, 50, obj.Qty, ParameterDirection.Input);
            AddParameter("@price", SqlDbType.VarChar, 50, obj.Price, ParameterDirection.Input);
          
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(sale_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [sale_master]
                             SET    
                                    [jewellery_id_fk]=@jewellery_id_fk,
                                    [sale_date]=@sale_date,
                                    [qty]=@qty,
                                    [price]=@price

                         WHERE [sale_id_pk]=@sale_id_pk";
            OnClearParameter();
            AddParameter("@sale_id_pk", SqlDbType.Int, 50, obj.Sale_id_pk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@sale_date", SqlDbType.VarChar, 50, obj.Sale_date, ParameterDirection.Input);
            AddParameter("@qty", SqlDbType.VarChar, 50, obj.Qty, ParameterDirection.Input);
            AddParameter("@price", SqlDbType.VarChar, 50, obj.Price, ParameterDirection.Input);

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
            strQ += @"UPDATE [sale_master]
                            SET [is_active]=0
                         WHERE [sale_id_pk]=@sale_id_pk";

            OnClearParameter();
            AddParameter("@sale_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private sale_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            sale_tableEntities obj = new sale_tableEntities();

            obj.Sale_id_pk = (drRow["sale_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["sale_id_pk"];
            obj.Jewellery_id_fk = (drRow["jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Sale_date = (drRow["sale_date"].Equals(DBNull.Value)) ? "" : (string)drRow["sale_date"];
            obj.Qty = (drRow["qty"].Equals(DBNull.Value)) ? 0 : (int)drRow["qty"]; 
            obj.Price = (drRow["price"].Equals(DBNull.Value)) ? "" : (string)drRow["price"];
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
    public sale_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        sale_tableEntities obj = new sale_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT s.*,j.jewellery_name  FROM [sale_master] s 
                   JOIN [jewellery_master] j ON s.[jewellery_id_fk]=j.[jewellery_id_pk]
                   WHERE [sale_id_pk] = @sale_id_pk";

            OnClearParameter();
            AddParameter("sale_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<sale_tableEntities> oList = new List<sale_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM  [sale_master] ";
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

    public List<sale_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<sale_tableEntities> oList = new List<sale_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT s.*,j.jewellery_name FROM [sale_master] s 
                     JOIN [jewellery_master] j ON s.[jewellery_id_fk]=j.[jewellery_id_pk] 
                     WHERE s.[is_active]=1 ";
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
            strQ = @"SELECT sale_id_pk,sale_date FROM [sale_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["sale_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["sale_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["sale_date"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["sale_date"];
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
