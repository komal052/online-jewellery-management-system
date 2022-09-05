using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class bill_tableEntities
{

    private int bill_id_pk = 0;    
    private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private int order_id_fk = 0;
    private string total_price = "";
    private string tax = "";
    private string gst = "";
    private string total_amount = "";
    private string date = "";
    private int is_active = 0;

    public int Bill_id_pk { get => bill_id_pk; set => bill_id_pk = value; }    
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public int Order_id_fk { get => order_id_fk; set => order_id_fk = value; }
    public string Total_price { get => total_price; set => total_price = value; }
    public string Tax { get => tax; set => tax = value; }
    public string Gst { get => gst; set => gst = value; }
    public string Total_amount { get => total_amount; set => total_amount = value; }
    public string Date { get => date; set => date = value; }
    public int Is_active { get => is_active; set => is_active = value; }
   
}

