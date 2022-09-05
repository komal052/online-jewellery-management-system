using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class department_tableEntities
{

    private int user_id_pk = 0;
    private string f_name = "";
    private string l_name = "";
    private string gender = "";
    private string birthdate = "";
    private string status = "";
    private string anniversary_date = "";
    private int state_id_fk = 0;
    private int city_id_fk = 0;
    private string address = "";
    private string email = "";
    private string password = "";
    private string contact = "";
    private string u_type = "";
    private int is_active = 1;

    private state_tableEntities dept = new state_tableEntities();
    private city_tableEntities dept = new city_tableEntities();

    public int User_id_pk { get => user_id_pk; set => user_id_pk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public string Gender { get => gender; set => gender = value; }
    public string Birthdate { get => birthdate; set => birthdate = value; }
    public string Status { get => status; set => status = value; }
    public string Anniversary_date { get => anniversary_date; set => anniversary_date = value; }
    public int State_id_fk { get => state_id_fk; set => state_id_fk = value; }
    public int City_id_fk { get => city_id_fk; set => city_id_fk = value; }
    public string Address { get => address; set => address = value; }
    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    public string Contact { get => contact; set => contact = value; }
    public string U_type { get => u_type; set => u_type = value; }

    public state_tableEntities St { get => st; set => st = value; }
    public city_tableEntities Ct { get => ct; set => ct = value; }
}

