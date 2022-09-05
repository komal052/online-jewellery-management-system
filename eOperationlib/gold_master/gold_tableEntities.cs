using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class gold_tableEntities
{

    private int gold_id_pk = 0;
    private string gold_type = "";
    private string carat = "";
    private string weight = "";
    private int certi_id_fk =0;
    private string certi_no = "";
    private string image = "";
    private int is_active = 0;
   
    public int Gold_id_pk { get => gold_id_pk; set => gold_id_pk = value; }
    public string Gold_type { get => gold_type; set => gold_type = value; }
    public string Carat { get => carat; set => carat = value; }
    public string Weight { get => weight; set => weight = value; }
    public int Certi_id_fk { get => certi_id_fk; set => certi_id_fk = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    public String Certi_no { get => certi_no; set => certi_no = value; }
    public string Image { get => image; set => image = value; }
}

