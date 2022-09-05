using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class sale_tableEntities
{

    private int sale_id_pk = 0;
    private int jewellery_id_fk = 0;
    private string sale_date = "";
    private int qty = 0;
    private string  price = "";
    private string jewellery_name = "";
    private int is_active = 0;


    public int Sale_id_pk { get => sale_id_pk; set => sale_id_pk = value; }
    public int Jewellery_id_fk { get => jewellery_id_fk; set => jewellery_id_fk = value; }
    public string Sale_date { get => sale_date; set => sale_date = value; }
    public int Qty { get => qty; set => qty = value; }
    public string Price { get => price; set => price = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }

    
}

