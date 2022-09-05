using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class wishlist_tableEntities
{

    private int wishlist_id_pk = 0;        
    private int subtype_jewellery_id_fk = 0;
    private string price = "";    
    private string jewellery_name = "";
    private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private string images = "";

    public int Wishlist_id_pk { get => wishlist_id_pk; set => wishlist_id_pk = value; }
    public int Subtype_jewellery_id_fk { get => subtype_jewellery_id_fk; set => subtype_jewellery_id_fk = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }   
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }       
    public string Price { get => price; set => price = value; }
    public string Images { get => images; set => images = value; }
}

