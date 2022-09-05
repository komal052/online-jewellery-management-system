using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class contactus_tableEntities
{

    private int contactus_id_pk = 0;
    private string name = "";
    private string email_id = "";
    private string subject = "";
    private string message = "";
    private int is_active = 1;
    private int is_read = 1;

    public int Contactus_id_pk { get => contactus_id_pk; set => contactus_id_pk = value; }
    public string Name { get => name; set => name = value; }
    public string Email_id { get => email_id; set => email_id = value; }
    public string Subject { get => subject; set => subject = value; }
    public string Message { get => message; set => message = value; }
    public int Is_active { get => is_active; set => is_active = value; }
    public int Is_read { get => is_read; set => is_read = value; }


}

