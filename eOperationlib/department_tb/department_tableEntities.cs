using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class department_tableEntities
{

    private int deptid = 0;
    private string deptname = "";
    private int is_active = 1;

    public int Dept_id { get => deptid; set => deptid = value; }
    public string Dept_name { get => deptname; set => deptname = value; }
    public int Is_active { get => is_active; set => is_active = value; }
}

