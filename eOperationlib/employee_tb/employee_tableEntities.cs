using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class employee_tableEntities
{

    private int empid = 0;
    private string empname = "";
    private int dept_id_fk = 0;
    private string joinning_date = "";
    private string designation = "";
    private string qualification = "";
    private int is_active = 0;

    private department_tableEntities dept = new department_tableEntities();

    public int Emp_id { get => empid; set => empid = value; }
    public string Emp_name { get => empname; set => empname = value; }
    public int Department_id_fk { get => dept_id_fk; set => dept_id_fk = value; }
    public string Joinning_date { get => joinning_date; set => joinning_date = value; }
    public string Designation { get => designation; set => designation = value; }
    public string Qualification { get => qualification; set => qualification = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    public department_tableEntities Dept { get => dept; set => dept = value; }
}

