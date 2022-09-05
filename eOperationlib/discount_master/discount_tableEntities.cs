using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class discount_tableEntities
{
    private int discount_id_pk = 0;
    private string discount = "";
    private int jewellery_id_fk = 0;
    private string jewellery_name = "";         
    private int is_active = 0;

    public int Discount_id_pk { get => discount_id_pk; set => discount_id_pk = value; }
    public string Discount { get => discount; set => discount = value; }
    public int Jewellery_id_fk { get => jewellery_id_fk; set => jewellery_id_fk = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
    public int Is_active { get => is_active; set => is_active = value; }
}

