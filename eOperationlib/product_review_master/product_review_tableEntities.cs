using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class product_review_tableEntities
{
    private int review_id_pk = 0;
    private int subtype_jewellery_id_fk = 0;
    private string jewellery_name = "";
    private string rating = "";    
    private string description = "";
    private int user_id_fk = 0;
    private string f_name = "";
    private string l_name = "";
    private string profile = "";
    private int is_active = 0;

    public int Review_id_pk { get => review_id_pk; set => review_id_pk = value; }
    public int Subtype_jewellery_id_fk { get => subtype_jewellery_id_fk; set => subtype_jewellery_id_fk = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
    public string Rating { get => rating; set => rating = value; }
    public string Description { get => description; set => description = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }
    public string Profile { get => profile; set => profile = value; }
}

