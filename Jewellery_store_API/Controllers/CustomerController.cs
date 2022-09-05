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
    public class CustomerController : ControllerBase
    {
        registration_tableDB objr = new();
        jewellery_tableDB objj = new();
        subtype_jewellery_tableDB objsj = new();
        feedback_tableDB objf = new();
        contactus_tableDB objc = new();
        return_jewellery_tableDB objrj = new();
        discount_tableDB objd = new();
        sale_tableDB objs = new();
        purchase_tableDB objp = new();
        cart_tableDB objca = new();
        bill_tableDB objb = new();
        payment_tableDB objpa = new();
        state_tableDB objstate = new();
        city_tableDB objcity = new();

        private String photoUpload(IFormFileCollection Files)
        {
            Random _random = new Random();
            var file = Files[0];
            var folderName = Path.Combine("uploads", "Images");
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

        [HttpPost("InsertUser"), DisableRequestSizeLimit]

        public JsonResult InserttUser()
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

            int result = objr.OnInsert(user);
            int userId = objr.OnLastRecordInserted();

            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = userId });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //jewellery
        [HttpGet("JewelleryList")]

        public JsonResult JewelleryList()
        {

            List<jewellery_tableEntities> jewellerys = objj.OnGetListdt();

            if (jewellerys.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = jewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("SubtypejewelleyList")]
        public JsonResult SubtypejewelleryList()
        {

            List<subtype_jewellery_tableEntities> subjewellerys = objsj.OnGetListdt();

            if (subjewellerys.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = subjewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("SubJewelleryData/{id}")]

        public JsonResult SubJewelleryData(int id)
        {

            subtype_jewellery_tableEntities subtype = objsj.OnGetData(id);

            if (subtype != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = subtype });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("InsertFeedback")]

        public JsonResult InsertFeddback(feedback_tableEntities feed)
        {

            int result = objf.OnInsert(feed);

            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("InsertContactus")]

        public JsonResult InsertContatus(contactus_tableEntities con)
        {

            int result = objc.OnInsert(con);

            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("InsertReturnjewellery")]

        public JsonResult InsertReturnjewellery(return_jewellery_tableEntities rj)
        {

            int result = objrj.OnInsert(rj);

            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("DiscountList")]
        public JsonResult DiscountList()
        {

            List<discount_tableEntities> discounts = objd.OnGetListdt();

            if (discounts.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = discounts });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("SaleList")]
        public JsonResult SaleList()
        {
            List<sale_tableEntities> sales = objs.OnGetListdt();

            if (sales.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sales });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("PurchaseData/{id}")]
        public JsonResult PurchaseData(int id)
        {
            purchase_tableEntities purchases = objp.OnGetData(id);

            if (purchases != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = purchases });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("UserCartList/{id}")]
        public JsonResult UserCartList(int id)
        {
            cart_tableEntities cart = objca.OnGetUserListdt(id);

            if (cart.Cart_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cart });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }


        [HttpPost("InsertCart")]

        public JsonResult InsertCart(cart_tableEntities carts)
        {

            int result = objca.OnInsert(carts);

            int cartId = objca.OnLastRecordInserted();


            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cartId });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteCart/{id}")]

        public JsonResult DeleteCart(int id)
        {

            int result = objca.OnDelete(id);

            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("CartData/{id}")]
        public JsonResult CartData(int id)
        {

            cart_tableEntities carts = objca.OnGetData(id);

            if (carts != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = carts });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateCart")]
        public JsonResult UpdateCart(cart_tableEntities cart)
        {
            int result = objca.OnUpdate(cart);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }
        /*[HttpPost("UpdateCart/{id}")]
        public JsonResult UpdateCart(int id)
        {
            cart_tableEntities cart = objca.OnUpdate(id);
            if (cart != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cart });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }*/

        [HttpPost("InsertPayment")]

        public JsonResult InsertPayment(payment_tableEntities pays)
        {

            int result = objpa.OnInsert(pays);

            if (result != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("BillData/{id}")]
        public JsonResult BillData(int id)
        {

            bill_tableEntities bills = objb.OnGetData(id);

            if (bills != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = bills });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //wishlist
        wishlist_tableDB wobj = new wishlist_tableDB();

        [HttpGet("WishlishData/{id}")]
        public JsonResult WishlistData(int id)
        {
            wishlist_tableEntities wishlist = wobj.OnGetData(id);
            {
                if (wishlist != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = wishlist });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }

        [HttpGet("WishlistList/{id}")]
        public JsonResult WishlistList(int id)
        {
            List<wishlist_tableEntities> wishlist = wobj.OnGetUserListdt(id);
            if (wishlist.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = wishlist });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertWishlist")]
        public JsonResult InsertWishlist(wishlist_tableEntities wishlist)
        {
            int result = wobj.OnInsert(wishlist);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateWishlist")]
        public JsonResult UpdateWishlist(wishlist_tableEntities wishlist)
        {
            int result = wobj.OnUpdate(wishlist);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteWishlist/{id}")]
        public JsonResult DeleteSilver(int id)
        {
            int result = wobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //product review
        product_review_tableDB pobj = new product_review_tableDB();

        [HttpGet("ProductreviewData/{id}")]
        public JsonResult ProductreviewData(int id)
        {
            product_review_tableEntities review = pobj.OnGetData(id);
            {
                if (review != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = review });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }

        [HttpGet("ProductreviewtList/{id}")]
        public JsonResult ProductreviewList(int id)
        {
            List<product_review_tableEntities> review = pobj.OnGetjewelleryreviewListdt(id);
            if (review.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = review });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertProductreview")]
        public JsonResult InsertProductreview(product_review_tableEntities review)
        {
            int result = pobj.OnInsert(review);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateProductreview")]
        public JsonResult UpdateProductreview(product_review_tableEntities review)
        {
            int result = pobj.OnUpdate(review);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteProductreview/{id}")]
        public JsonResult DeleteProductreview(int id)
        {
            int result = pobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
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
        [HttpPost("LoginData")]
        public JsonResult LoginData(registration_tableEntities reg)
        {

            registration_tableEntities users = objr.OnLoginData(reg.Email, reg.Password);

            if (users != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = users });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("UserData/{id}")]
        public JsonResult UserData(int id)
        {

            registration_tableEntities users = objr.OnGetData(id);

            if (users != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = users });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("TopSubtypejewelleyList")]
        public JsonResult TopSubtypejewelleryList()
        {

            List<subtype_jewellery_tableEntities> subjewellerys = objsj.OnTopGetListdt();

            if (subjewellerys.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = subjewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //cart product
        cartproduct_tableDB cobj = new cartproduct_tableDB();

        /*[HttpGet("CartProductData/{id}")]
        public JsonResult SilverData(int id)
        {
            cartproduct_tableEntities cproduct = cobj.OnGetData(id);
            {
                if (cproduct != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = cproduct });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }*/
        [HttpGet("UserCartProductList/{id}")]
        public JsonResult UserCartProductList(int id)
        {
            List<cartproduct_tableEntities> cartproduct = cobj.OnGetCartproductListdt(id);

            if (cartproduct != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cartproduct });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }


        [HttpGet("CartProductList")]
        public JsonResult SilverList()
        {
            List<cartproduct_tableEntities> cproduct = cobj.OnGetListdt();
            if (cproduct.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = cproduct });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertCartProduct")]
        public JsonResult InsertCartProduct(cartproduct_tableEntities cproduct)
        {
            int result = cobj.OnInsert(cproduct);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateCartProduct")]
        public JsonResult UpdateCartProduct(cartproduct_tableEntities cproduct)
        {
            int result = cobj.OnUpdate(cproduct);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteCartProduct/{id}")]
        public JsonResult DeleteCartProduct(int id)
        {
            int result = cobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //order product
        orderproduct_tableDB opobj = new orderproduct_tableDB();

        [HttpGet("OrderProductData/{id}")]
        public JsonResult OrderProductData(int id)
        {
            orderproduct_tableEntities ocproduct = opobj.OnGetData(id);
            {
                if (ocproduct != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = ocproduct });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }

        [HttpGet("OrderProductList/{id}")]
        public JsonResult OrderProductList(int id)
        {
            List<orderproduct_tableEntities> oproduct = opobj.OnGetUserListdt(id);
            if (oproduct.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = oproduct });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertOrderProduct")]
        public JsonResult InsertOrderProduct(orderproduct_tableEntities oproduct)
        {
            int result = opobj.OnInsert(oproduct);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateOrderProduct")]
        public JsonResult UpdateOrderProduct(orderproduct_tableEntities cproduct)
        {
            int result = opobj.OnUpdate(cproduct);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteOrderProduct/{id}")]
        public JsonResult DeleteOrderProduct(int id)
        {
            int result = cobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //order_master
        order_tableDB orobj = new order_tableDB();
        [HttpGet("OrderData/{id}")]
        public JsonResult OrderData(int id)
        {
            order_tableEntities order = orobj.OnGetData(id);
            {
                if (order != null)
                {
                    return new JsonResult(new { result = "success", message = "Data Found", data = order });
                }
                else
                {
                    return new JsonResult(new { result = "failure", message = "Data Not Found" });
                }
            }
        }

        [HttpGet("OrderList/{id}")]
        public JsonResult OrderList(int id)
        {
            List<order_tableEntities> order = orobj.OnUserOrderListdt(id);
            if (order.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("UserOrderList/{id}")]
        public JsonResult UserOrderList(int id)
        {
            order_tableEntities order = orobj.OnGetUserListdt(id);

            if (order.Order_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = order });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertOrder")]
        public JsonResult InsertOrder(order_tableEntities order)
        {      
            int result = orobj.OnInsert(order);
            int orderId = orobj.OnLastRecordInserted();

            if (result !=0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = orderId });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateOrder")]
        public JsonResult UpdateOrder(order_tableEntities order)
        {
            int result = orobj.OnUpdate(order);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteOrder/{id}")]
        public JsonResult DeleteOrder(int id)
        {
            int result = orobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

    }


}
