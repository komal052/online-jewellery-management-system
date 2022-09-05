using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class purchase_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "purchase_master";

    public purchase_tableDB()
        : base()
    {
    }

    public int OnInsert(purchase_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [purchase_master]
                                   ([user_id_fk],[jewellery_id_fk],[order_id_fk],[purchase_date],[quantity],[price])
                             VALUES
                                   (@user_id_fk,@jewellery_id_fk,@order_id_fk,@purchase_date,@quantity,@price)";

            OnClearParameter();
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@purchase_date",SqlDbType.VarChar, 50, obj.Purchase_date, ParameterDirection.Input);
            AddParameter("@quantity", SqlDbType.VarChar, 50, obj.Quantity, ParameterDirection.Input);
            AddParameter("@price", SqlDbType.VarChar, 50, obj.Price, ParameterDirection.Input);
          
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(purchase_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [purchase_master]
                          SET       [user_id_fk]=@user_id_fk,
                                    [jewellery_id_fk]=@jewellery_id_fk,
                                    [order_id_fk]=@order_id_fk,
                                    [purchase_date]=@purchase_date,
                                    [quantity]=@quantity,
                                    [price]=@price

                         WHERE [purchase_id_pk]=@purchase_id_pk";
            OnClearParameter();
            AddParameter("@purchase_id_pk", SqlDbType.Int, 50, obj.Purchase_id_pk, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.VarChar, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@jewellery_id_fk", SqlDbType.VarChar, 50, obj.Jewellery_id_fk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@purchase_date", SqlDbType.VarChar, 50, obj.Purchase_date, ParameterDirection.Input);
            AddParameter("@quantity", SqlDbType.VarChar, 50, obj.Quantity, ParameterDirection.Input);
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
            strQ += @"UPDATE [purchase_master]
                            SET [is_active]=0
                         WHERE [purchase_id_pk]=@purchase_id_pk";

            OnClearParameter();
            AddParameter("@purchase_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private purchase_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            purchase_tableEntities obj = new purchase_tableEntities();

            obj.Purchase_id_pk = (drRow["purchase_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["purchase_id_pk"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Jewellery_id_fk = (drRow["jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Order_id_fk = (drRow["order_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["order_id_fk"];
            obj.Total_price = (drRow["total_price"].Equals(DBNull.Value)) ? "" : (string)drRow["total_price"];
            obj.Purchase_date = (drRow["purchase_date"].Equals(DBNull.Value)) ? "" : (string)drRow["purchase_date"];
            obj.Quantity = (drRow["quantity"].Equals(DBNull.Value)) ? "" : (string)drRow["quantity"]; 
            obj.Price  = (drRow["price"].Equals(DBNull.Value)) ? "" : (string)drRow["price"];
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
    public purchase_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        purchase_tableEntities obj = new purchase_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT p.*,r.f_name,r.l_name,j.jewellery_name,o.total_price FROM [purchase_master] p
             JOIN [registration_master] r ON p.[user_id_fk]=r.[user_id_pk]
             JOIN [jewellery_master] j ON p.[jewellery_id_fk]=j.[jewellery_id_pk]
             JOIN [order_master] o ON p.[order_id_fk]=o.[order_id_pk]
             WHERE [purchase_id_pk] = @purchase_id_pk";

            OnClearParameter();
            AddParameter("purchase_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<purchase_tableEntities> oList = new List<purchase_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [purchase_master] ";
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

    public List<purchase_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<purchase_tableEntities> oList = new List<purchase_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT p.*,r.f_name,r.l_name,j.jewellery_name,o.total_price FROM [purchase_master] p
             JOIN [registration_master] r ON p.[user_id_fk]=r.[user_id_pk]
             JOIN [jewellery_master] j ON p.[jewellery_id_fk]=j.[jewellery_id_pk]
             JOIN [order_master] o ON p.[order_id_fk]=o.[order_id_pk]
             WHERE p.[is_active]=1 ";

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
            strQ = @"SELECT purchase_id_pk FROM [purchase_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["purchase_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["purchase_id_pk"];
                //objData.NAME = dtTable.Rows[intRow]["empname"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["empname"];
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
