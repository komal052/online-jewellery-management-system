using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class supplier_tableEntities
{

    private int sup_id_pk = 0;
    private string sup_name = "";
    private string factory_name = "";
    private string factory_contact= "";
    private string sup_contact = "";
    private int is_active = 1;

    public int Sup_id_pk { get => sup_id_pk; set => sup_id_pk = value; }
    public string Sup_name { get => sup_name; set => sup_name = value; }
    public string Factory_name { get => factory_name; set => factory_name = value; }
    public string Factory_contact { get => factory_contact; set => factory_contact = value; }
    public string Sup_contact { get => sup_contact; set => sup_contact = value; }
    public int Is_active { get => is_active; set => is_active = value; }
}

