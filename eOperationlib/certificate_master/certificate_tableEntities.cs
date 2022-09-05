using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class certificate_tableEntities
{

    private int certi_id_pk = 0;
    private string certi_no = "";
    private string image = "";
    private int is_active = 1;

    public int Certi_id_pk { get => certi_id_pk; set => certi_id_pk = value; }
    public string Certi_no { get => certi_no; set => certi_no = value; }
    public string Image { get => image; set => image = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    
}

