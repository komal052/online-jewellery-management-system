using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class registration_tableEntities
{

    private int user_id_pk = 0;
    private string f_name = "";
    private string l_name = "";
    private string gender = "";
    private string birthdate = "";
    private string status = "";
    private string anniversary_date = "";
    private int state_id_fk = 0;
    private string state_name = "";    
    private int city_id_fk = 0;
    private string city_name = "";
    private string address = "";
    private string pincode = "";
    private string email = "";
    private string password = "";
    private string contact = "";
    private string u_type = "";
    private string profile = "";
    private int is_active = 1;

    

    

    public int User_id_pk { get => user_id_pk; set => user_id_pk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public string Gender { get => gender; set => gender = value; }
    public string Birthdate { get => birthdate; set => birthdate = value; }
    public string Status { get => status; set => status = value; }
    public string Anniversary_date { get => anniversary_date; set => anniversary_date = value; }
    public int State_id_fk { get => state_id_fk; set => state_id_fk = value; }
    public string State_name { get => state_name; set => state_name = value; }
    public int City_id_fk { get => city_id_fk; set => city_id_fk = value; }
    public string City_name { get => city_name; set => city_name = value; }
    public string Address { get => address; set => address = value; }
    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    public string Contact { get => contact; set => contact = value; }
    public string U_type { get => u_type; set => u_type = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    public string Profile { get => profile; set => profile = value; }
    public string Pincode { get => pincode; set => pincode = value; }
}

