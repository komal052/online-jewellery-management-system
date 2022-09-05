using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class orderproduct_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "order_product";

    public orderproduct_tableDB()
        : base()
    {
    }

    public int OnInsert(orderproduct_tableEntities obj)
    {

        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [order_product]
                                   ([order_id_fk],[subtype_jewellery_id_fk],[quantity],[status])
                             VALUES
                                   (@order_id_fk,@subtype_jewellery_id_fk,@quantity,@status)";

            OnClearParameter();

            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);            
            AddParameter("@quantity", SqlDbType.VarChar, 50, obj.Quantity, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.VarChar, 50, obj.Status, ParameterDirection.Input);
            return OnExecNonQuery(strQ);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(orderproduct_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [order_product]
                             SET   
                                    [order_id_fk],[subtype_jewellery_id_fk],[quantity],[status],                                    
                                   
                         WHERE [order_product_id_pk]=@order_product_id_pk";
            OnClearParameter();
            AddParameter("@order_product_id_pk", SqlDbType.Int, 50, obj.Order_product_id_pk, ParameterDirection.Input);
            AddParameter("@order_id_fk", SqlDbType.VarChar, 50, obj.Order_id_fk, ParameterDirection.Input);
            AddParameter("@subtype_jewellery_id_fk", SqlDbType.VarChar, 50, obj.Subtype_jewellery_id_fk, ParameterDirection.Input);            
            AddParameter("@quantity", SqlDbType.VarChar, 50, obj.Quantity, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.VarChar, 50, obj.Status, ParameterDirection.Input);



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
            strQ += @"Delete from [order_product]                            
                         WHERE [order_product_id_pk]=@order_product_id_pk";

            OnClearParameter();
            AddParameter("@order_product_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private orderproduct_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            orderproduct_tableEntities obj = new orderproduct_tableEntities();

            obj.Order_product_id_pk = (drRow["order_product_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["order_product_id_pk"];
            obj.Subtype_jewellery_id_fk = (drRow["subtype_jewellery_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["subtype_jewellery_id_fk"];
            obj.Jewellery_name = (drRow["jewellery_name"].Equals(DBNull.Value)) ? "" : (string)drRow["jewellery_name"];
            obj.Images = (drRow["images"].Equals(DBNull.Value)) ? "" : (string)drRow["images"];
            obj.Quantity = (drRow["quantity"].Equals(DBNull.Value)) ? "" : (string)drRow["quantity"];
            obj.Price = (drRow["price"].Equals(DBNull.Value)) ? "" : (string)drRow["price"];
            obj.Order_id_fk = (drRow["order_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["order_id_fk"];
            obj.Total_amount = (drRow["total_amount"].Equals(DBNull.Value)) ? "" : (string)drRow["total_amount"];
            obj.Status = (drRow["status"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["status"].ToString());
            obj.Date = (drRow["date"].Equals(DBNull.Value)) ? "" : (string)drRow["date"];
            obj.Is_read = (drRow["is_read"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_read"].ToString());



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
    public orderproduct_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        orderproduct_tableEntities obj = new orderproduct_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,j.jewellery_name,sj.images,sj.price,c.total_amount  FROM [order_product] cp
            JOIN [order_master] c ON cp.[order_id_fk]=c.[order_id_pk]            
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]=sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]
           
            WHERE [order_product_id_pk] = @order_product_id_pk";

            OnClearParameter();
            AddParameter("order_product_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<orderproduct_tableEntities> oList = new List<orderproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [order_product] ";
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

    public List<orderproduct_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<orderproduct_tableEntities> oList = new List<orderproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,j.jewellery_name,sj.images,c.total_amount,c.date,sj.price FROM [order_product] cp
            JOIN [order_master] c ON cp.[order_id_fk]=c.[order_id_pk]            
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]=sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]";

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

    public List<orderproduct_tableEntities> OnGetUserListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<orderproduct_tableEntities> oList = new List<orderproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,j.jewellery_name,sj.images,c.total_amount,sj.price,c.date FROM [order_product] cp
            JOIN [order_master] c ON cp.[order_id_fk]=c.[order_id_pk]            
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]=sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk]
              where [order_id_fk]= @order_id_fk";

            OnClearParameter();
            AddParameter("order_id_fk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
            
            
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
            strQ = @"SELECT order_product_id_pk  FROM [order_product]  ";

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
                objData.ID = dtTable.Rows[intRow]["order_product_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["order_product_id_pk"];
                // objData.NAME = dtTable.Rows[intRow]["jewellery_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["jewellery_name"];
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
            strQ = @"SELECT count(order_product_id_pk) from [order_product] where  [is_read]=1";
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
    public List<orderproduct_tableEntities> OnGetLastListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<orderproduct_tableEntities> oList = new List<orderproduct_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,j.jewellery_name,sj.images,c.total_amount,c.date,sj.price FROM [order_product] cp
            JOIN [order_master] c ON cp.[order_id_fk]=c.[order_id_pk]            
            JOIN [subtype_jewellery_master] sj ON cp.[subtype_jewellery_id_fk]=sj.[subtype_jewellery_id_pk]
            JOIN [jewellery_master] j ON sj.[jewellery_id_fk]= j.[jewellery_id_pk] 
             where  [is_read]=1  ORDER BY [order_product_id_pk] DESC";

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
            throw ex;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }
    public int OnGetLimitListdt()
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [order_product]
                               SET  [is_read]= 0 ";
            OnClearParameter();

            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int OnGetStatusListdt(int ID)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [order_product]
                              SET  [status]= 0 
                     where [order_product_id_pk]= @order_product_id_pk";
            OnClearParameter();
            AddParameter("order_product_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
