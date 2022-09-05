using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class orderproduct_tableEntities
{
    private int order_product_id_pk = 0;       
    private int order_id_fk = 0;
    private int subtype_jewellery_id_fk = 0;
    private string jewellery_name = "";
    private string images = "";
    private string quantity = "";
    private string price = "";
    private string total_amount = "";
    private string date = "";
    private int status = 1;
    private int is_read = 1;
   

    public int Order_product_id_pk { get => order_product_id_pk; set => order_product_id_pk = value; }
    public int Order_id_fk { get => order_id_fk; set => order_id_fk = value; }
    public int Subtype_jewellery_id_fk { get => subtype_jewellery_id_fk; set => subtype_jewellery_id_fk = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
    public string Images { get => images; set => images = value; }
    public string Quantity { get => quantity; set => quantity = value; }
    public string Total_amount { get => total_amount; set => total_amount = value; }
    public string Date { get => date; set => date = value; }
    public int Status { get => status; set => status = value; }
    public int Is_read { get => is_read; set => is_read = value; }
    public string Price { get => price; set => price = value; }
   
}

