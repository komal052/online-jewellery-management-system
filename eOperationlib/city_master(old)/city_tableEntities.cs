﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class employee_tableEntities
{

    private int city_id_pk= 0;
    private string city_name = "";
    private int state_id_fk = 0;
   

    private state_tableEntities dept = new state_tableEntities();

    public int City_id_pk { get => city_id_pk; set => city_id_pk = value; }
    public string City_name { get => city_name; set => city_name = value; }
    public int State_id_fk { get => state_id_fk; set => state_id_fk = value; }
   
    public state_tableEntities St { get => st; set => st = value; }
}

