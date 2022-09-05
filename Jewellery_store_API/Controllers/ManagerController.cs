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
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        //certificate
        certificate_tableDB objDB = new certificate_tableDB();
        jewellery_tableDB objjwel = new jewellery_tableDB();
        subtype_jewellery_tableDB objsubjwel = new subtype_jewellery_tableDB();
        registration_tableDB objreg = new registration_tableDB();
        supplier_tableDB objsup = new supplier_tableDB();
        city_tableDB objcity = new();
        state_tableDB objstate = new();

        [HttpGet("CertiData/{id}")]
        public JsonResult CertiData(int id)
        {
            certificate_tableEntities certi = objDB.OnGetData(id);
            if(certi != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = certi });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("CertiList")]
        public JsonResult CertiList()
        {
            List<certificate_tableEntities> certi = objDB.OnGetListdt();            
            if (certi.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = certi });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertCerti")]
        public JsonResult InsertCerti(certificate_tableEntities certi)
        {
            int result = objDB.OnInsert(certi);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateCerti")]
        public JsonResult UpdateCerti(certificate_tableEntities certi)
        {
            int result = objDB.OnUpdate(certi);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteCerti/{id}")]
        public JsonResult DeleteCerti(int id)
        {
            int result = objDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("CertiListCount")]
        public JsonResult CertiListCount()
        {
            List<int> table = objDB.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }


        //silver
        silver_tableDB Sobj = new silver_tableDB();

        [HttpGet("SilverData/{id}")]
        public JsonResult SilverData(int id)
        {
            silver_tableEntities silver = Sobj.OnGetData(id);
            {
                if(silver != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = silver });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }           
            }
        }

        [HttpGet("SilverList")]
        public JsonResult SilverList()
        {
            List<silver_tableEntities> silver = Sobj.OnGetListdt();
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
        public JsonResult InsertSilver(silver_tableEntities silver)
        {
            int result = Sobj.OnInsert(silver);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateSilver")]
        public JsonResult UpdateSilver(silver_tableEntities silver)
        {
            int result = Sobj.OnUpdate(silver);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteSilver/{id}")]
        public JsonResult DeleteSilver(int id)
        {
            int result = Sobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("silverListCount")]
        public JsonResult silverListCount()
        {
            List<int> table = Sobj.OnGetTableCount();
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
        gold_tableDB gobj = new gold_tableDB();        
        [HttpGet("GoldData/{id}")]
        public JsonResult GoldData(int id)
        {
            gold_tableEntities gold = gobj.OnGetData(id);
            {
                if (gold != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = gold });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }

        [HttpGet("GoldList")]
        public JsonResult GoldList()
        {
            List<gold_tableEntities> gold = gobj.OnGetListdt();
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
        public JsonResult InsertGold(gold_tableEntities gold)
        {
            int result = gobj.OnInsert(gold);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateGold")]
        public JsonResult UpdateGold(gold_tableEntities gold)
        {
            int result = gobj.OnUpdate(gold);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteGold/{id}")]
        public JsonResult DeleteGold(int id)
        {
            int result = gobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("goldListCount")]
        public JsonResult goldListCount()
        {
            List<int> table = gobj.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }



        //diamond
        diamond_tableDB dobj = new diamond_tableDB();
        [HttpGet("DiamondData/{id}")]
        public JsonResult DiamondData(int id)
        {
            diamond_tableEntities diamond = dobj.OnGetData(id);
            {
                if (diamond != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = diamond });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }

        [HttpGet("DiamondList")]
        public JsonResult DiamondList()
        {
            List<diamond_tableEntities> diamond = dobj.OnGetListdt();
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
        public JsonResult InsertDiamond(diamond_tableEntities diamond)
        {
            int result = dobj.OnInsert(diamond);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateDiamond")]
        public JsonResult UpdateDiamond(diamond_tableEntities diamond)
        {
            int result = dobj.OnUpdate(diamond);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteDiamond/{id}")]
        public JsonResult DeleteDiamond(int id)
        {
            int result = dobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("diamondListCount")]
        public JsonResult diamondListCount()
        {
            List<int> table = dobj.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
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






    }
}
