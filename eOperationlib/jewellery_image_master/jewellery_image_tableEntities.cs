using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class jewellery_image_tableEntities
{

    private int image_id_pk= 0;
    private int jewellery_id_fk = 0;
    private string img_path = "";
    private string jewellery_name = "";

    public int Image_id_pk { get => image_id_pk; set => image_id_pk = value; }
    public int Jewellery_id_fk { get => jewellery_id_fk; set => jewellery_id_fk = value; }
    public string Img_path { get => img_path; set => img_path = value; }
    public string Jewellery_name { get => jewellery_name; set => jewellery_name = value; }
}

