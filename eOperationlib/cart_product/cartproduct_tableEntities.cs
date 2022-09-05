using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class cartproduct_tableEntities
{
    private int cart_product_id_pk = 0;
    private int subtype_jewellery_id_fk = 0;
    private string subtype = "";
    private int cart_id_fk = 0;
    private string quantity= "";
   // private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private string price = "";
    private string jewellery_name = "";
    private string images = "";


    public int Cart_product_id_pk { get => cart_product_id_pk; set => cart_product_id_pk = value; }
    public int Cart_id_fk { get => cart_id_fk; set => cart_id_fk = value; }
    public int Subtype_jewellery_id_fk { get => subtype_jewellery_id_fk; set => subtype_jewellery_id_fk = value; }
    public string Subtype { get => subtype; set => subtype = value; }
    public string Quantity { get => quantity; set => quantity = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public string Price { get => price; set => price = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
    public string Images { get => images; set => images = value; }

    // public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
}

