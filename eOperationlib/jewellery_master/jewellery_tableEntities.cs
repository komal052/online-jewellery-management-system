using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class jewellery_tableEntities
{

    private int jewellery_id_pk = 0;
    private string jewellery_name = "";
    private int diamond_id_fk = 0;
    private int gold_id_fk = 0;    
    private string images = "";
    private int is_active = 0;
    private string diamond_color = "";
    private string shape = "";
    private string gold_type = "";    
    

    public int Jewellery_id_pk { get => jewellery_id_pk; set => jewellery_id_pk = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
    public int Diamond_id_fk { get => diamond_id_fk; set => diamond_id_fk = value; }
    public int Gold_id_fk { get => gold_id_fk; set => gold_id_fk = value; }
    
    public string Images { get => images; set => images = value; }
    public int Is_active { get => is_active; set => is_active = value; }

    public string Diamond_color { get => diamond_color; set => diamond_color = value; }
    public string Shape { get => shape; set => shape = value; }
    public string Gold_type { get => gold_type; set => gold_type = value; }
    



}

