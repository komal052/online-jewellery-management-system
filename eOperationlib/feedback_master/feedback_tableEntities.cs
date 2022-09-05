using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class feedback_tableEntities
{
    private int feedback_id_pk = 0;
    private int user_id_fk = 0;
    private string subject = "";
    private string message = "";
    private int is_active = 0;
    private string f_name = "";
    private string l_name = "";

  

    public int Feedback_id_pk { get => feedback_id_pk; set => feedback_id_pk = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string Subject { get => subject; set => subject = value; }
    public string Message { get => message; set => message = value; }
    public int Is_active { get => is_active; set => is_active = value; }

    public string F_name { get => f_name; set => f_name = value; }
    public string L_name { get => l_name; set => l_name = value; }


}
