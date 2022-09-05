using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Jewellery_store_API.Controllers
{
    //Function Names 
    //city_list
    //CityData/{id}
    //InsertCity
    //UpdateCity
    //DeleteCity

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        registration_tableDB objreg = new();
        jewellery_tableDB objjwel = new();
        gold_tableDB objgold = new();
        silver_tableDB objsilver = new();
        diamond_tableDB objdiamond = new();
        certificate_tableDB objcerti = new();
        subtype_jewellery_tableDB objsubjwel = new();
        sale_tableDB objsale = new();
        employee_tableDB objemp = new();
        supplier_tableDB objsup = new();
        discount_tableDB objdis = new();
        order_tableDB objorder = new();
        purchase_tableDB objpur = new();
        cart_tableDB objcart = new();
        bill_tableDB objbill = new();
        payment_tableDB objpayment = new();
        return_jewellery_tableDB objreturnjwel = new();
        contactus_tableDB objcnt = new();
        feedback_tableDB objfeed = new();
        jewellery_image_tableDB objimg = new();
        city_tableDB objcity = new();
        state_tableDB objstate = new();

        //User(Registration)

        [HttpGet("UserList")]
        public JsonResult UserList()
        {

            List<registration_tableEntities> users = objreg.OnGetListdt();

            if (users.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = users });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertUser"), DisableRequestSizeLimit]
        public JsonResult InsertUser()
        {
            registration_tableEntities user = new registration_tableEntities();
            String photo_path = photoUpload(Request.Form.Files);
            user.Profile = photo_path;
            user.F_name = Request.Form["f_name"];
            user.L_name = Request.Form["l_name"];
            user.Gender = Request.Form["gender"];
            user.Birthdate = Request.Form["birthdate"];
            user.Status = Request.Form["status"];
            user.Anniversary_date = Request.Form["anniversary_date"];
            user.State_id_fk = Int32.Parse(Request.Form["state_id_fk"]);
            user.City_id_fk = Int32.Parse(Request.Form["city_id_fk"]);
            user.Address = Request.Form["address"];
            user.Pincode = Request.Form["pincode"];
            user.Email = Request.Form["email"];
            user.Password = Request.Form["password"];
            user.Contact = Request.Form["contact"];
            user.U_type = Request.Form["u_type"];

            int res = objreg.OnInsert(user);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteUser/{id}")]

        public JsonResult DeleteUser(int id)
        {
            int res = objreg.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateUser"), DisableRequestSizeLimit]
        public JsonResult UpdateUser()
        {
            registration_tableEntities user = new registration_tableEntities();

            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    user.Profile = photo_path;
                }
                else
                {
                    user.Profile = Request.Form["profile"];
                }
            }
            else
            {
                user.Profile = Request.Form["profile"];
            }
            user.User_id_pk = Int32.Parse(Request.Form["user_id_pk"]);
            user.F_name = Request.Form["f_name"];
            user.L_name = Request.Form["l_name"];
            user.Gender = Request.Form["gender"];
            user.Birthdate = Request.Form["birthdate"];
            user.Status = Request.Form["status"];
            user.Anniversary_date = Request.Form["anniversary_date"];
            user.State_id_fk = Int32.Parse(Request.Form["state_id_fk"]);
            user.City_id_fk = Int32.Parse(Request.Form["city_id_fk"]);
            user.Address = Request.Form["address"];
            user.Pincode = Request.Form["pincode"];
            user.Email = Request.Form["email"];
            user.Password = Request.Form["password"];
            user.Contact = Request.Form["contact"];
            user.U_type = Request.Form["u_type"];

            int res = objreg.OnUpdate(user);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("UserData/{id}")]

        public JsonResult UserData(int id)
        {

            registration_tableEntities users = objreg.OnGetData(id);

            if (users != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = users });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("UserListCount")]
        public JsonResult UserListCount()
        {
            List<int> table = objreg.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Jewellery 

        [HttpGet("JewelleryList")]
        public JsonResult JewelleryList()
        {

            List<jewellery_tableEntities> jwel = objjwel.OnGetListdt();

            if (jwel.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = jwel });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertJewellery"), DisableRequestSizeLimit]
        public JsonResult InsertJewellery()
        {
            jewellery_tableEntities jewel = new jewellery_tableEntities();
            String photo_path = photoUpload(Request.Form.Files);
            jewel.Images = photo_path;
            jewel.Jewellery_name = Request.Form["jewellery_name"];
            jewel.Diamond_id_fk = Int32.Parse(Request.Form["diamond_id_fk"]);
            jewel.Gold_id_fk = Int32.Parse(Request.Form["gold_id_fk"]);



            int res = objjwel.OnInsert(jewel);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteJewellery/{id}")]

        public JsonResult DeleteJewellery(int id)
        {
            int res = objjwel.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateJewellery"), DisableRequestSizeLimit]

        public JsonResult UpdateJewellery()
        {
            jewellery_tableEntities jewel = new jewellery_tableEntities();
            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    jewel.Images = photo_path;
                }
                else
                {
                    jewel.Images = Request.Form["images"];
                }
            }
            else
            {
                jewel.Images = Request.Form["images"];
            }
            jewel.Jewellery_id_pk = Int32.Parse(Request.Form["jewellery_id_pk"]);
            jewel.Jewellery_name = Request.Form["jewellery_name"];
            jewel.Diamond_id_fk = Int32.Parse(Request.Form["diamond_id_fk"]);
            jewel.Gold_id_fk = Int32.Parse(Request.Form["gold_id_fk"]);

            int res = objjwel.OnUpdate(jewel);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("JewelleryData/{id}")]

        public JsonResult JewelleryData(int id)
        {

            jewellery_tableEntities jwel = objjwel.OnGetData(id);

            if (jwel != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = jwel });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("JewelleryListCount")]
        public JsonResult JewelleryListCount()
        {
            List<int> table = objjwel.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //gold

        [HttpGet("GoldList")]
        public JsonResult GoldList()
        {

            List<gold_tableEntities> gold = objgold.OnGetListdt();

            if (gold.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = gold });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertGold")]
        public JsonResult InsertGold(gold_tableEntities reg)
        {
            int res = objgold.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteGold/{id}")]

        public JsonResult DeleteGold(int id)
        {
            int res = objgold.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateGold")]

        public JsonResult UpdateGold(gold_tableEntities reg)
        {
            int res = objgold.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("GoldData/{id}")]

        public JsonResult GoldData(int id)
        {

            gold_tableEntities gold = objgold.OnGetData(id);

            if (gold != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = gold });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }


        //silver

        [HttpGet("SilverList")]
        public JsonResult SilverList()
        {

            List<silver_tableEntities> silver = objsilver.OnGetListdt();

            if (silver.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = silver });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertSilver")]
        public JsonResult InsertSilver(silver_tableEntities reg)
        {
            int res = objsilver.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteSilver/{id}")]

        public JsonResult DeleteSilver(int id)
        {
            int res = objsilver.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateSilver")]

        public JsonResult UpdateSilver(silver_tableEntities reg)
        {
            int res = objsilver.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("SilverData/{id}")]

        public JsonResult SilverData(int id)
        {

            silver_tableEntities silver = objsilver.OnGetData(id);

            if (silver != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = silver });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //diamond

        [HttpGet("DiamondList")]
        public JsonResult DiamondList()
        {

            List<diamond_tableEntities> diamond = objdiamond.OnGetListdt();

            if (diamond.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = diamond });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertDiamond")]
        public JsonResult InsertDiamond(diamond_tableEntities reg)
        {
            int res = objdiamond.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteDiamond/{id}")]

        public JsonResult DeleteDiamond(int id)
        {
            int res = objdiamond.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateDiamond")]

        public JsonResult UpdateDiamond(diamond_tableEntities reg)
        {
            int res = objdiamond.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("DiamondData/{id}")]

        public JsonResult DiamondData(int id)
        {

            diamond_tableEntities diamond = objdiamond.OnGetData(id);

            if (diamond != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = diamond });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //certificate

        [HttpGet("CertiList")]
        public JsonResult CertiList()
        {

            List<certificate_tableEntities> certi = objcerti.OnGetListdt();

            if (certi.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = certi });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertCerti"), DisableRequestSizeLimit]
        public JsonResult InsertCerti()
        {
            certificate_tableEntities certi = new certificate_tableEntities();
            String photo_path = photoUpload(Request.Form.Files);
            certi.Image = photo_path;

            certi.Certi_no = Request.Form["certi_no"];
            int res = objcerti.OnInsert(certi);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteCerti/{id}")]

        public JsonResult DeleteCerti(int id)
        {
            int res = objcerti.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateCerti")]

        public JsonResult UpdateCerti()
        {
            certificate_tableEntities certi = new certificate_tableEntities();

            if (Request.Form.Files.Count != 0)
            {
                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    certi.Image = photo_path;
                }
                else
                {
                    certi.Image = Request.Form["image"];

                }

            }
            else
            {
                certi.Image = Request.Form["image"];
            }

            certi.Certi_id_pk = Int32.Parse(Request.Form["certi_id_pk"]);
            certi.Certi_no = Request.Form["certi_no"];

            int res = objcerti.OnUpdate(certi);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("CertiData/{id}")]

        public JsonResult CertiData(int id)
        {

            certificate_tableEntities certi = objcerti.OnGetData(id);

            if (certi != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = certi });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //sub-type jewellery

        [HttpGet("SubJewelleryList")]
        public JsonResult SubJewelleryList()
        {

            List<subtype_jewellery_tableEntities> subtype = objsubjwel.OnGetListdt();

            if (subtype.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = subtype });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertSubJewellery"), DisableRequestSizeLimit]
        public JsonResult InsertSubJewellery()
        {
            subtype_jewellery_tableEntities sjewel = new subtype_jewellery_tableEntities();
            String photo_path = photoUpload(Request.Form.Files);
            sjewel.Images = photo_path;

            sjewel.Jewellery_id_fk = Int32.Parse(Request.Form["jewellery_id_fk"]);
            sjewel.Subtype = Request.Form["subtype"];
            sjewel.Price = Request.Form["price"];
            sjewel.Description = Request.Form["description"];

            int res = objsubjwel.OnInsert(sjewel);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteSubJewellery/{id}")]

        public JsonResult DeleteSubJewellery(int id)
        {
            int res = objsubjwel.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateSubJewellery"), DisableRequestSizeLimit]

        public JsonResult UpdateSubJewellery()
        {
            subtype_jewellery_tableEntities sjewel = new subtype_jewellery_tableEntities();
            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    sjewel.Images = photo_path;
                }
                else
                {
                    sjewel.Images = Request.Form["images"];
                }
            }
            else
            {
                sjewel.Images = Request.Form["images"];
            }
            sjewel.Subtype_jewellery_id_pk = Int32.Parse(Request.Form["subtype_jewellery_id_pk"]);
            sjewel.Jewellery_name = Request.Form["jewellery_name"];
            sjewel.Jewellery_id_fk = Int32.Parse(Request.Form["jewellery_id_fk"]);
            sjewel.Subtype = Request.Form["subtype"];
            sjewel.Price = Request.Form["price"];
            sjewel.Description = Request.Form["description"];

            int res = objsubjwel.OnUpdate(sjewel);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("SubJewelleryData/{id}")]

        public JsonResult SubJewelleryData(int id)
        {

            subtype_jewellery_tableEntities subtype = objsubjwel.OnGetData(id);

            if (subtype != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = subtype });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("SubJewelleryListCount")]
        public JsonResult SubJewelleryListCount()
        {
            List<int> table = objsubjwel.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //sale

        [HttpGet("SaleList")]
        public JsonResult SaleList()
        {

            List<sale_tableEntities> sale = objsale.OnGetListdt();

            if (sale.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sale });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertSale")]
        public JsonResult InsertSale(sale_tableEntities reg)
        {
            int res = objsale.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteSale/{id}")]

        public JsonResult DeleteSale(int id)
        {
            int res = objsale.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateSale")]

        public JsonResult UpdateSale(sale_tableEntities reg)
        {
            int res = objsale.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("SaleData/{id}")]

        public JsonResult SaleData(int id)
        {

            sale_tableEntities sale = objsale.OnGetData(id);

            if (sale != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sale });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Employee

        [HttpGet("EmployeeList")]
        public JsonResult EmployeeList()
        {

            List<employee_tableEntities> emp = objemp.OnGetListdt();

            if (emp.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = emp });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertEmployee")]
        public JsonResult InsertEmployee(employee_tableEntities reg)
        {
            int res = objemp.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]

        public JsonResult DeleteEmployee(int id)
        {
            int res = objemp.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateEmployee")]

        public JsonResult UpdateEmployee(employee_tableEntities reg)
        {
            int res = objemp.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("EmployeeData/{id}")]

        public JsonResult EmployeeData(int id)
        {

            employee_tableEntities emp = objemp.OnGetData(id);

            if (emp != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = emp });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("EmployeeListCount")]
        public JsonResult EmployeeListCount()
        {
            List<int> table = objemp.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Supplier

        [HttpGet("SupplierList")]
        public JsonResult SupplierList()
        {

            List<supplier_tableEntities> sup = objsup.OnGetListdt();

            if (sup.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sup });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertSupplier")]
        public JsonResult InsertSupplier(supplier_tableEntities reg)
        {
            int res = objsup.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteSupplier/{id}")]

        public JsonResult DeleteSupplier(int id)
        {
            int res = objsup.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateSupplier")]

        public JsonResult UpdateSupplier(supplier_tableEntities reg)
        {
            int res = objsup.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("SupplierData/{id}")]

        public JsonResult SupplierData(int id)
        {

            supplier_tableEntities sup = objsup.OnGetData(id);

            if (sup != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sup });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Discount

        [HttpGet("DiscountList")]
        public JsonResult DiscountList()
        {

            List<discount_tableEntities> dis = objdis.OnGetListdt();

            if (dis.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = dis });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertDiscount")]
        public JsonResult InsertDiscount(discount_tableEntities reg)
        {
            int res = objdis.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteDiscount/{id}")]

        public JsonResult DeleteDiscount(int id)
        {
            int res = objdis.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateDiscount")]

        public JsonResult UpdateDiscount(discount_tableEntities reg)
        {
            int res = objdis.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("DiscountData/{id}")]

        public JsonResult DiscountData(int id)
        {

            discount_tableEntities dis = objdis.OnGetData(id);

            if (dis != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = dis });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Order

        [HttpGet("OrderList")]
        public JsonResult OrderList()
        {

            List<order_tableEntities> order = objorder.OnGetListdt();

            if (order.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertOrder")]
        public JsonResult InsertOrder(order_tableEntities reg)
        {
            int res = objorder.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteOrder/{id}")]

        public JsonResult DeleteOrder(int id)
        {
            int res = objorder.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateOrder")]

        public JsonResult UpdateOrder(order_tableEntities reg)
        {
            int res = objorder.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("OrderData/{id}")]

        public JsonResult OrderData(int id)
        {

            order_tableEntities order = objorder.OnGetData(id);

            if (order != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        /* [HttpGet("OrderListCount")]
         public JsonResult OrderListCount()
         {
             List<int> table = objorder.OnGetTableCount();
             if (table.Count != 0)
             {
                 return new JsonResult(new { result = "success", message = "Data Found", data = table });
             }
             else
             {
                 return new JsonResult(new { result = "failure", message = "Data Not Found" });
             }
         }*/

        //Purchase

        [HttpGet("PurchaseList")]
        public JsonResult PurchaseList()
        {

            List<purchase_tableEntities> purchase = objpur.OnGetListdt();

            if (purchase.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = purchase });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertPurchase")]
        public JsonResult InsertPurchase(purchase_tableEntities reg)
        {
            int res = objpur.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeletePurchase/{id}")]

        public JsonResult DeletePurchase(int id)
        {
            int res = objpur.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdatePurchase")]

        public JsonResult UpdatePurchase(purchase_tableEntities reg)
        {
            int res = objpur.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("PurchaseData/{id}")]

        public JsonResult PurchaseData(int id)
        {

            purchase_tableEntities purchase = objpur.OnGetData(id);

            if (purchase != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = purchase });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Cart

        [HttpGet("CartList")]
        public JsonResult CartList()
        {

            List<cart_tableEntities> cart = objcart.OnGetListdt();

            if (cart.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cart });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertCart")]
        public JsonResult InsertCart(cart_tableEntities reg)
        {
            int res = objcart.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteCart/{id}")]

        public JsonResult DeleteCart(int id)
        {
            int res = objcart.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        // [HttpPost("UpdateCart")]

        /*public JsonResult UpdateCart(cart_tableEntities reg)
        {
            int res = objcart.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }*/

        [HttpGet("CartData/{id}")]

        public JsonResult CartData(int id)
        {

            cart_tableEntities cart = objcart.OnGetData(id);

            if (cart != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cart });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //Bill

        [HttpGet("BillList")]
        public JsonResult BillList()
        {

            List<bill_tableEntities> bill = objbill.OnGetListdt();

            if (bill.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = bill });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertBill")]
        public JsonResult InsertBill(bill_tableEntities reg)
        {
            int res = objbill.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteBill/{id}")]

        public JsonResult DeleteBill(int id)
        {
            int res = objbill.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateBill")]

        public JsonResult UpdateBill(bill_tableEntities reg)
        {
            int res = objbill.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("BillData/{id}")]

        public JsonResult BillData(int id)
        {

            bill_tableEntities bill = objbill.OnGetData(id);

            if (bill != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = bill });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("BillListCount")]
        public JsonResult BillListCount()
        {
            List<int> table = objbill.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteReturnJewellery")]
        public JsonResult DeleteReturnJewellery(int id)
        {
            int result = objreturnjwel.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ReturnJewelleryList")]
        public JsonResult ReturnJewellerytList()
        {
            List<return_jewellery_tableEntities> rjewellery = objreturnjwel.OnGetListdt();
            if (rjewellery.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = rjewellery });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("InsertReturnJewellery")]
        public JsonResult ReturnJewelleryPayment(return_jewellery_tableEntities insrj)
        {
            int result = objreturnjwel.OnInsert(insrj);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateReturnJewellery")]
        public JsonResult UpdateReturnJewellery(return_jewellery_tableEntities updaterj)
        {
            int result = objreturnjwel.OnUpdate(updaterj);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ReturnJewelleryData/{id}")]
        public JsonResult ReturnJewelleryData(int id)
        {
            return_jewellery_tableEntities rjewellery = objreturnjwel.OnGetData(id);
            if (rjewellery != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = rjewellery });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ReturnJewelleryListCount")]
        public JsonResult ReturnJewelleryListCount()
        {
            List<int> table = objreturnjwel.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        //payment

        [HttpGet("PaymentData/{id}")]
        public JsonResult PaymentData(int id)
        {
            payment_tableEntities payment = objpayment.OnGetData(id);
            if (payment != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = payment });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("PaymentList")]
        public JsonResult PaymentList()
        {
            List<payment_tableEntities> payment = objpayment.OnGetListdt();
            if (payment.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = payment });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("InsertPayment")]
        public JsonResult InsertPayment(payment_tableEntities inspay)
        {
            int result = objpayment.OnInsert(inspay);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdatePayment")]
        public JsonResult UpdatePayment(payment_tableEntities updatepay)
        {
            int result = objpayment.OnUpdate(updatepay);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeletePayment/{id}")]
        public JsonResult DeletePayment(int id)
        {
            int result = objpayment.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("PaymentListCount")]
        public JsonResult PaymentListCount()
        {
            List<int> table = objpayment.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ContactusList")]
        public JsonResult ContactusList()
        {
            List<contactus_tableEntities> contact = objcnt.OnGetListdt();
            if (contact.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = contact });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ContactusData/{id}")]
        public JsonResult ContactusData(int id)
        {
            contactus_tableEntities contact = objcnt.OnGetData(id);
            if (contact != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = contact });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteContactus/{id}")]
        public JsonResult DeleteContactus(int id)
        {
            int result = objcnt.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ContactusListCount")]
        public JsonResult ContactusListCount()
        {
            List<int> table = objcnt.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("FeedbackList")]
        public JsonResult FeedbackList()
        {
            List<feedback_tableEntities> feedback = objfeed.OnGetListdt();
            if (feedback.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = feedback });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteFeedback/{id}")]
        public JsonResult DeleteFeedback(int id)
        {
            int result = objfeed.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        //jewellery image

        [HttpGet("ImageList")]
        public JsonResult ImageList()
        {

            List<jewellery_image_tableEntities> images = objimg.OnGetListdt();

            if (images.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = images });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertImage")]
        public JsonResult InsertImage(jewellery_image_tableEntities reg)
        {
            int res = objimg.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteImage/{id}")]

        public JsonResult DeleteImage(int id)
        {
            int res = objimg.OnDelete(id);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpPost("UpdateImage")]

        public JsonResult UpdateImage(jewellery_image_tableEntities reg)
        {
            int res = objimg.OnUpdate(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpGet("ImageData/{id}")]

        public JsonResult ImageData(int id)
        {

            jewellery_image_tableEntities images = objimg.OnGetData(id);

            if (images != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = images });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //city
        [HttpGet("CityList")]
        public JsonResult CityList()
        {
            List<city_tableEntities> city = objcity.OnGetListdt();

            if (city.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = city });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //state

        [HttpGet("StateList")]
        public JsonResult StateList()
        {
            List<state_tableEntities> state = objstate.OnGetListdt();

            if (state.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = state });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("StateData/{id}")]
        public JsonResult StateData(int id)
        {
            state_tableEntities state = objstate.OnGetData(id);
            if (state != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = state });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("cityData/{id}")]
        public JsonResult CityData(int id)
        {
            List<city_tableEntities> city = objcity.OnGetListState(id);
            if (city != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = city });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        private String photoUpload(IFormFileCollection Files)
        {
            Random _random = new Random();
            var file = Files[0];
            var folderName = Path.Combine("uploads", "images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = "IMG_" + _random.Next(1, 999) + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return dbPath;

        }
        // [HttpPost("LoginData")]

        /*  public JsonResult LoginUser(registration_tableEntities reg)
          {
              int res = objreg.OnLoginData(reg);
              if (res == 1)
              {
                  return new JsonResult(new { result = "success", message = "Data Found", data = res });
              }
              else
              {
                  return new JsonResult(new { result = "failure", message = "Data Not Found" });
              }

          }*/
        [HttpPost("LoginData")]

        public JsonResult LoginData(registration_tableEntities reg)
        {

            registration_tableEntities users = objreg.OnLoginData(reg.Email, reg.Password);

            if (users != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = users });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //
        [HttpPost("CheckEmail")]

        public JsonResult CheckEmail(registration_tableEntities reg)
        {

            registration_tableEntities users = objreg.OnCheckEmail(reg.Email);

            if (users != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = users });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ContactusLimit")]
        public JsonResult ContactusLimit()
        {
            int contact = objcnt.OnGetLimitListdt();
            if (contact != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = contact });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        /* [HttpGet("OrderLimit")]
         public JsonResult OrderLimit()
         {
             int order = objorder.OnGetLimitListdt();
             if (order != 0)
             {
                 return new JsonResult(new { result = "success", message = "Data Found", data = order });
             }
             else
             {
                 return new JsonResult(new { result = "failure", message = "Data Not Found" });
             }
         }*/

        [HttpGet("SupplierListCount")]
        public JsonResult SupplierListCount()
        {
            List<int> table = objsup.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ContactusLastList")]
        public JsonResult ContactusLastList()
        {
            List<contactus_tableEntities> contact = objcnt.OnGetLastListdt();

            if (contact.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = contact });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("goldListCount")]
        public JsonResult goldListCount()
        {
            List<int> table = objgold.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("diamondListCount")]
        public JsonResult diamondListCount()
        {
            List<int> table = objdiamond.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        orderproduct_tableDB objp = new();

        [HttpGet("ProductOrderListCount")]

        public JsonResult ProductOrderListCount()
        {
            List<int> table = objp.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }




        [HttpGet("ProductOrderList")]
        public JsonResult ProductOrderList()
        {
            List<orderproduct_tableEntities> order = objp.OnGetListdt();
            if (order.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }


        [HttpGet("ProductOrderLimit")]
        public JsonResult ProductOrderLimit()
        {
            int orderproduct = objp.OnGetLimitListdt();
            if (orderproduct != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = orderproduct });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ProductOrderlastList")]
        public JsonResult ProductOrderlastList()
        {
            List<orderproduct_tableEntities> op = objp.OnGetLastListdt();

            if (op.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = op });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("OrderStatus/{id}")]
        public JsonResult OrderStatus(int id)
        {
            int order = objp.OnGetStatusListdt(id);
            if (order != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        product_review_tableDB pobj = new product_review_tableDB();

        [HttpGet("ProductreviewList")]
        public JsonResult ProductreviewList()
        {
            List<product_review_tableEntities> order = pobj.OnGetListdt();
            if (order.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

    }
}
