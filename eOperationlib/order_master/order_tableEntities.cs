using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class order_tableEntities
{
    private int order_id_pk = 0;
    private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private string address = "";
    private string total_amount = "";
    private string date = "";
   

    public int Order_id_pk { get => order_id_pk; set => order_id_pk = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public string Address { get => address; set => address = value; }
    public string Total_amount { get => total_amount; set => total_amount = value; }
    public string Date { get => date; set => date = value; }
    
}

