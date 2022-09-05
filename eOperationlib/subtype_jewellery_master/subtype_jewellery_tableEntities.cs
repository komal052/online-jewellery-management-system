using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class subtype_jewellery_tableEntities
{

    private int subtype_jewellery_id_pk = 0;
    private int jewellery_id_fk = 0;
    private string subtype = "";
    private string price = "";
    private string images = "";
    private string description = ""; 
    private int is_active = 0;

    private string jewellery_name = "";

   

    public int Subtype_jewellery_id_pk { get => subtype_jewellery_id_pk; set => subtype_jewellery_id_pk = value; }
    public int Jewellery_id_fk { get => jewellery_id_fk; set => jewellery_id_fk = value; }
    public string Subtype { get => subtype; set => subtype = value; }
    public string Price { get => price; set => price = value; }
    public string Images { get => images; set => images = value; }
    public string Description { get => description; set => description = value; }
    public int Is_active { get => is_active; set => is_active = value; }

    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
}

