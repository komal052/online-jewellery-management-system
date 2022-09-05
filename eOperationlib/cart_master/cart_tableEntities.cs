using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class cart_tableEntities
{
    private int cart_id_pk = 0;
    private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private string total_amount = "";
    

    public int Cart_id_pk { get => cart_id_pk; set => cart_id_pk = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }        
    public string Total_amount { get => total_amount; set => total_amount = value; }
}

