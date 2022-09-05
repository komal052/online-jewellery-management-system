using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class registration_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "registration_master";

    public registration_tableDB() 
    {
    }

    public int OnInsert(registration_tableEntities obj)
    {

        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [registration_master]
                                   ([f_name],[l_name],[gender],[birthdate],[status],[anniversary_date],[state_id_fk],[city_id_fk],[address],
                                    [pincode],[email],[password],[contact],[u_type],[profile])
                             VALUES
                                   (@f_name,@l_name,@gender,@birthdate,@status,@anniversary_date,@state_id_fk,@city_id_fk,@address,
                                      @pincode,@email,@password,@contact,@u_type,@profile) ";

            OnClearParameter();
            AddParameter("@f_name", SqlDbType.VarChar, 50, obj.F_name, ParameterDirection.Input);
            AddParameter("@l_name", SqlDbType.VarChar, 50, obj.L_name, ParameterDirection.Input);
            AddParameter("@gender", SqlDbType.VarChar, 50, obj.Gender, ParameterDirection.Input);
            AddParameter("@birthdate", SqlDbType.VarChar, 50, obj.Birthdate, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.VarChar, 50, obj.Status, ParameterDirection.Input);
            AddParameter("@anniversary_date", SqlDbType.VarChar, 50, obj.Anniversary_date, ParameterDirection.Input);
            AddParameter("@state_id_fk", SqlDbType.VarChar, 50, obj.State_id_fk, ParameterDirection.Input);
            AddParameter("@city_id_fk", SqlDbType.VarChar, 50, obj.City_id_fk, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 50, obj.Address, ParameterDirection.Input);
            AddParameter("@pincode", SqlDbType.VarChar, 50, obj.Pincode, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, obj.Password, ParameterDirection.Input);
            AddParameter("@contact", SqlDbType.VarChar, 50, obj.Contact, ParameterDirection.Input);
            AddParameter("@u_type", SqlDbType.VarChar, 50, obj.U_type, ParameterDirection.Input);
            AddParameter("@profile", SqlDbType.VarChar, 50, obj.Profile, ParameterDirection.Input);

            return OnExecNonQuery(strQ);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnUpdate(registration_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"UPDATE [registration_master]
                             SET    [f_name]=@f_name,
                                    [l_name]=@l_name,
                                    [gender]=@gender,
                                    [birthdate]=@birthdate,
                                    [status]=@status,
                                    [anniversary_date]=@anniversary_date,
                                    [state_id_fk]=@state_id_fk,
                                    [city_id_fk]=@city_id_fk,
                                    [address]=@address,
                                    [pincode]=@pincode,
                                    [email]=@email,
                                    [password]=@password,
                                    [contact]=@contact,
                                    [u_type]=@u_type,
                                    [profile]=@profile
      
                         WHERE [user_id_pk]=@user_id_pk";
            OnClearParameter();
            AddParameter("@user_id_pk", SqlDbType.Int, 50, obj.User_id_pk, ParameterDirection.Input);
            AddParameter("@f_name", SqlDbType.VarChar, 50, obj.F_name, ParameterDirection.Input);
            AddParameter("@l_name", SqlDbType.VarChar, 50, obj.L_name, ParameterDirection.Input);
            AddParameter("@gender", SqlDbType.VarChar, 50, obj.Gender, ParameterDirection.Input);
            AddParameter("@birthdate", SqlDbType.VarChar, 50, obj.Birthdate, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.VarChar, 50, obj.Status, ParameterDirection.Input);
            AddParameter("@anniversary_date", SqlDbType.VarChar, 50, obj.Anniversary_date, ParameterDirection.Input);
            AddParameter("@state_id_fk", SqlDbType.VarChar, 50, obj.State_id_fk, ParameterDirection.Input);
            AddParameter("@city_id_fk", SqlDbType.VarChar, 50, obj.City_id_fk, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 50, obj.Address, ParameterDirection.Input);
            AddParameter("@pincode", SqlDbType.VarChar, 50, obj.Pincode, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, obj.Password, ParameterDirection.Input);
            AddParameter("@contact", SqlDbType.VarChar, 50, obj.Contact, ParameterDirection.Input);
            AddParameter("@u_type", SqlDbType.VarChar, 50, obj.U_type, ParameterDirection.Input);
            AddParameter("@profile", SqlDbType.VarChar, 50, obj.Profile, ParameterDirection.Input);


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
            strQ += @"UPDATE [registration_master]
                            SET [is_active]=0
                         WHERE [user_id_pk]=@user_id_pk";

            OnClearParameter();
            AddParameter("@user_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private registration_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            registration_tableEntities obj = new registration_tableEntities();

            obj.User_id_pk = (drRow["user_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_pk"];
            obj.F_name = (drRow["f_name"].Equals(DBNull.Value)) ? "" : (string)drRow["f_name"];
            obj.L_name = (drRow["l_name"].Equals(DBNull.Value)) ? "" : (string)drRow["l_name"];
            obj.Gender = (drRow["gender"].Equals(DBNull.Value)) ? "" : (string)drRow["gender"];
            obj.Birthdate = (drRow["birthdate"].Equals(DBNull.Value)) ? "" : (string)drRow["birthdate"];
            obj.Status = (drRow["status"].Equals(DBNull.Value)) ? "" : (string)drRow["status"];
            obj.Anniversary_date = (drRow["anniversary_date"].Equals(DBNull.Value)) ? "" : (string)drRow["anniversary_date"];
            obj.State_id_fk = (drRow["state_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["state_id_fk"];
            obj.State_name = (drRow["state_name"].Equals(DBNull.Value)) ? "" : (string)drRow["state_name"];
            obj.City_id_fk = (drRow["city_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["city_id_fk"];
            obj.City_name = (drRow["city_name"].Equals(DBNull.Value)) ? "" : (string)drRow["city_name"];
            obj.Address = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.Pincode = (drRow["pincode"].Equals(DBNull.Value)) ? "" : (string)drRow["pincode"];
            obj.Email = (drRow["email"].Equals(DBNull.Value)) ? "" : (string)drRow["email"];
            obj.Password = (drRow["password"].Equals(DBNull.Value)) ? "" : (string)drRow["password"];
            obj.Contact = (drRow["contact"].Equals(DBNull.Value)) ? "" : (string)drRow["contact"];
            obj.U_type = (drRow["u_type"].Equals(DBNull.Value)) ? "" : (string)drRow["u_type"];
            obj.Profile = (drRow["profile"].Equals(DBNull.Value)) ? "" : (string)drRow["profile"];

            obj.Is_active = (drRow["is_active"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["is_active"].ToString());

            

           


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
    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        int lastId = 0;

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('registration_master') ";

            OnClearParameter();

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                lastId = Int32.Parse(dtTable.Rows[0].ItemArray[0].ToString());
            }

            return lastId;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public registration_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        registration_tableEntities obj = new registration_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT r.*,s.state_name,c.city_name from [registration_master] r 
                JOIN [state_master] s ON r.[state_id_fk]= s.[state_id_pk]
                JOIN [city_master] c ON r.[city_id_fk]=c.[city_id_pk]
                where [user_id_pk]=@user_id_pk ";

            OnClearParameter();
            AddParameter("user_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
        List<registration_tableEntities> oList = new List<registration_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [registration_master] ";
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

    public List<registration_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<registration_tableEntities> oList = new List<registration_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT r.*,s.state_name,c.city_name from [registration_master] r 
                JOIN [state_master] s ON r.[state_id_fk]= s.[state_id_pk]
                JOIN [city_master] c ON r.[city_id_fk]=c.[city_id_pk]
                where r.[is_active]=1 ";
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
            strQ = @"SELECT user_id_pk,f_name FROM [registration_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["user_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["user_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["f_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["f_name"];
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
   
    public registration_tableEntities OnLoginData(String email,String password)
    {
        Exception exForce;
        DataTable dtTable;

        registration_tableEntities obj = new registration_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT r.*,s.state_name,c.city_name from [registration_master] r 
                JOIN [state_master] s ON r.[state_id_fk]= s.[state_id_pk]
                JOIN [city_master] c ON r.[city_id_fk]=c.[city_id_pk] where [is_active]=1 and email=@email and password= @password ";

            OnClearParameter();
            //AddParameter("user_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);

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
    //
    public registration_tableEntities OnCheckEmail(String email)
    {
        Exception exForce;
        DataTable dtTable;

        registration_tableEntities obj = new registration_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT r.*,s.state_name,c.city_name from [registration_master] r 
                JOIN [state_master] s ON r.[state_id_fk]= s.[state_id_pk]
                JOIN [city_master] c ON r.[city_id_fk]=c.[city_id_pk] where [is_active]=1 and email=@email" ;

            OnClearParameter();
            
            AddParameter("@email", SqlDbType.VarChar, 50, email, ParameterDirection.Input);
           

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
    public List<int> OnGetTableCount()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<int> oList = new List<int>();
        string strQ = "";
        try
        {
            strQ = @"SELECT count(user_id_pk) from [registration_master] where [is_active] = 1";
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
