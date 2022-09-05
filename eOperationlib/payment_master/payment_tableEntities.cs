using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class payment_tableEntities
{

    private int payment_id_pk = 0;
    private string payment_type = "";
    private int bill_id_fk = 0;
    private string total_amount = "";
    private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private int is_active = 0;

    public int Payment_id_pk { get => payment_id_pk; set => payment_id_pk = value; }
    public string Payment_type { get => payment_type; set => payment_type = value; }
    public int Bill_id_fk { get => bill_id_fk; set => bill_id_fk = value; }
    public string Total_amount { get => total_amount; set => total_amount = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public int Is_active { get => is_active; set => is_active = value; }
}

