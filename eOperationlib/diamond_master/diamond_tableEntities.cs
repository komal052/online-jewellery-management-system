using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class diamond_tableEntities
{

    private int diamond_id_pk = 0;
    private string diamond_color = "";
    private string diamond_cut = "";
    private string polish = "";
    private string clarity = "";
    private int certi_id_fk = 0;
    private string shape = "";
    private string stone_weight = "";
    private string selling_cost = "";
    private string buying_cost = "";
    private string certi_no = "";
    private String image = "";
   
    private int is_active = 0;
   
    

    public int Diamond_id_pk { get => diamond_id_pk; set => diamond_id_pk = value; }
    public string Diamond_color { get => diamond_color; set => diamond_color = value; }
    public string Diamond_cut { get => diamond_cut; set => diamond_cut = value; }
    public string Polish { get => polish; set => polish = value; }
    public string Clarity { get => clarity; set => clarity = value; }
    public int Certi_id_fk { get => certi_id_fk; set => certi_id_fk = value; }
    public string Shape { get => shape; set => shape = value; }
    public string Stone_weight { get => stone_weight; set => stone_weight = value; }
    public string Selling_cost { get => selling_cost; set => selling_cost = value; }
    public string Buying_cost { get => buying_cost; set => buying_cost = value; }
    public string Certi_no { get => certi_no; set => certi_no = value; }
    public string Image { get => image; set => image = value; }

    public int Is_active { get => is_active; set => is_active = value; }
    
}

