using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class employee_tableEntities
{

    private int emp_id_pk = 0;
    private string emp_name = "";
    private string emp_address = "";
    private string emp_contact = "";
    private int is_active = 0;

    public int Emp_id_pk { get => emp_id_pk; set => emp_id_pk = value; }
    public string Emp_name { get => emp_name; set => emp_name = value; }
    public string Emp_address { get => emp_address; set => emp_address = value; }
    public string Emp_contact { get => emp_contact; set => emp_contact = value; }
    public int Is_active { get => is_active; set => is_active = value; }
}

