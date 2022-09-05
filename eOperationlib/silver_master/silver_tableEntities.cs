using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class silver_tableEntities
{

    private int silver_id_pk = 0;
    private string weight = "";
    private string carat = "";
    private int certi_id_fk =0;
    private string certi_no = "";
    private int is_active = 0;
    

    public int Silver_id_pk { get => silver_id_pk; set => silver_id_pk = value; }
    public string Weight { get => weight; set => weight = value; }
    public string Carat { get => carat; set => carat = value; }
    public int Certi_id_fk { get => certi_id_fk; set => certi_id_fk = value; }
    public string Certi_no { get => certi_no; set => certi_no = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    
}

