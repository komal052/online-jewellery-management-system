using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //employee
        employee_tableDB objemp = new();
        city_tableDB objcity = new();
        state_tableDB objstate = new();

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

        //registration
        registration_tableDB objreg = new();

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

        [HttpPost("InsertUser")]
        public JsonResult InsertUser(registration_tableEntities reg)
        {
            int res = objreg.OnInsert(reg);
            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateUser")]
        public JsonResult UpdateUser(registration_tableEntities reg)
        {
            int res = objreg.OnUpdate(reg);
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

        //jewellery
        jewellery_tableDB objDB = new();

        [HttpGet("JewelleryData/{id}")]
        public JsonResult JewelleryData(int id)
        {
            jewellery_tableEntities jewellerys = objDB.OnGetData(id);
            if (jewellerys != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = jewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("JewelleryList")]
        public JsonResult JewelleryList()
        {
            List<jewellery_tableEntities> jewellerys = objDB.OnGetListdt();
            if (jewellerys.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = jewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertJewellery")]
        public JsonResult InsertJewellery(jewellery_tableEntities insjewellery)
        {
            int result = objDB.OnInsert(insjewellery);
            if(result==1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateJewellery")]
        public JsonResult UpdateJewellery(jewellery_tableEntities updatejewellery)
        {
            int result = objDB.OnUpdate(updatejewellery);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteJewellery/{id}")]
        public JsonResult DeleteJewellery(int id)
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
        [HttpGet("JewelleryListCount")]
        public JsonResult JewelleryListCount()
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
        //subjewellery

        subtype_jewellery_tableDB sobj = new();

        [HttpGet("SubJewelleryDataByid/{id}")]
        public JsonResult SubJewelleryData(int id)
        {
            subtype_jewellery_tableEntities sjewellerys = sobj.OnGetData(id);
            if (sjewellerys != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sjewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("SubJewelleryList")]
        public JsonResult SubJewelleryList()
        {
            List<subtype_jewellery_tableEntities> sjewellerys = sobj.OnGetListdt();
            if (sjewellerys.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sjewellerys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertSubtypeJewellery")]
        public JsonResult InsertSubtypeJewellery(subtype_jewellery_tableEntities inssjewellery)
        {
            int result = sobj.OnInsert(inssjewellery);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateSubtypeJewellery")]
        public JsonResult UpdateSubtypeJewellery(subtype_jewellery_tableEntities updatesjewellery)
        {
            int result = sobj.OnUpdate(updatesjewellery);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteSubtypeJewellery/{id}")]
        public JsonResult DeleteSubtypeJewellery(int id)
        {
            int result = sobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("SubtypeJewelleryListCount")]
        public JsonResult SubtypeJewelleryListCount()
        {
            List<int> table = sobj.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        gold_tableDB objgold = new();
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
        diamond_tableDB objdiamond = new();

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

        //order
        order_tableDB objorder = new();

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

        [HttpGet("OrderList")]
        public JsonResult OrdereList()
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
     /*   [HttpGet("OrderListCount")]
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
        }
*/
        //sale
        sale_tableDB saleobj = new();

        [HttpGet("SaleData/{id}")]
        public JsonResult SaleData(int id)
        {
            sale_tableEntities sale = saleobj.OnGetData(id);
            if (sale != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = sale });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("SaleList")]
        public JsonResult SaleList()
        {
            List<sale_tableEntities> sale = saleobj.OnGetListdt();
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
        public JsonResult InsertSale(sale_tableEntities inssale)
        {
            int result = saleobj.OnInsert(inssale);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateSale")]
        public JsonResult UpdateSale(sale_tableEntities updatesale)
        {
            int result = saleobj.OnUpdate(updatesale);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }

        }

        [HttpDelete("DeleteSale/{id}")]
        public JsonResult DeleteSale(int id)
        {
            int result = saleobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }


        //supplier
        supplier_tableDB spobj = new();

        [HttpGet("SupllierData/{id}")]
        public JsonResult SupplierData(int id)
        {
            supplier_tableEntities supplier = spobj.OnGetData(id);
            if (supplier != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = supplier });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("SupplierList")]
        public JsonResult SupplierList()
        {
            List<supplier_tableEntities> supplier = spobj.OnGetListdt();
            if (supplier.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = supplier });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertSupplier")]
        public JsonResult InsertsSupplier(supplier_tableEntities inssupplier)
        {
            int result = spobj.OnInsert(inssupplier);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateSupplier")]
        public JsonResult UpdateSupplier(supplier_tableEntities updatesupplier)
        {
            int result = spobj.OnUpdate(updatesupplier);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //discount
        discount_tableDB dcobj = new();

        [HttpGet("DiscountData/{id}")]
        public JsonResult DiscountData(int id)
        {
            discount_tableEntities discount = dcobj.OnGetData(id);
            if (discount != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = discount });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("DiscountList")]
        public JsonResult DiscountList()
        {
            List<discount_tableEntities> discount = dcobj.OnGetListdt();
            if (discount.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = discount });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("InsertDiscount")]
        public JsonResult InsertDiscount(discount_tableEntities insdiscount)
        {
           int result = dcobj.OnInsert(insdiscount);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateDiscount")]
        public JsonResult UpdateDiscount(discount_tableEntities updatediscount)
        {
            int result = dcobj.OnUpdate(updatediscount);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteDiscount/{id}")]
        public JsonResult DeleteDiscount(int id)
        {
            int result = dcobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //purchased
        purchase_tableDB pobj = new();

        [HttpGet("PurchaseData/{id}")]
        public JsonResult PurchaseData(int id)
        {
            purchase_tableEntities purchase = pobj.OnGetData(id);
            if (purchase != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = purchase });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("PurchaseList")]
        public JsonResult PurchaseList()
        {
            List<purchase_tableEntities> purchase = pobj.OnGetListdt();
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
        public JsonResult InsertPurchase(purchase_tableEntities inspurchase)
        {
            int result = pobj.OnInsert(inspurchase);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdatePurchase")]
        public JsonResult UpdatePurchase(purchase_tableEntities updatepurchase)
        {
            int result = pobj.OnUpdate(updatepurchase);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeletePurchase/{id}")]
        public JsonResult DeletePurchase(int id)
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

        //bill
        bill_tableDB bobj = new();

        [HttpGet("BillData/{id}")]
        public JsonResult BillData(int id)
        {
            bill_tableEntities bill = bobj.OnGetData(id);
            if (bill != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = bill });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("BillList")]
        public JsonResult BillList()
        {
            List<bill_tableEntities> bill = bobj.OnGetListdt();
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
        public JsonResult InsertBill(bill_tableEntities insbill)
        {
            int result = bobj.OnInsert(insbill);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateBill")]
        public JsonResult UpdateBill(bill_tableEntities updatebill)
        {
            int result = bobj.OnUpdate(updatebill);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteBill/{id}")]
        public JsonResult DeleteBill(int id)
        {
            int result = bobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("BillListCount")]
        public JsonResult BillListCount()
        {
            List<int> table = bobj.OnGetTableCount();
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
        payment_tableDB payobj = new();

        [HttpGet("PaymentData/{id}")]
        public JsonResult PaymentData(int id)
        {
            payment_tableEntities payment = payobj.OnGetData(id);
            if (payment != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = payment });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("PaymentListCount")]
        public JsonResult PaymentListCount()
        {
            List<int> table = payobj.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("PaymentList")]
        public JsonResult PaymentList()
        {
            List<payment_tableEntities> payment = payobj.OnGetListdt();
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
            int result = payobj.OnInsert(inspay);
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
            int result = payobj.OnUpdate(updatepay);
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
            int result = payobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        //retuen jewellery
        return_jewellery_tableDB rjobj = new();

        [HttpGet("ReturnJewelleryData/{id}")]
        public JsonResult ReturnJewelleryData(int id)
        {
            return_jewellery_tableEntities rjewellery = rjobj.OnGetData(id);
            if (rjewellery != null)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = rjewellery });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ReturnJewelleryList")]
        public JsonResult ReturnJewellerytList()
        {
            List<return_jewellery_tableEntities> rjewellery = rjobj.OnGetListdt();
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
            int result = rjobj.OnInsert(insrj);
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
            int result = rjobj.OnUpdate(updaterj);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteReturnJewellery/{id}")]
        public JsonResult DeleteReturnJewellery(int id)
        {
            int result = rjobj.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ReturnJewelleryListCount")]
        public JsonResult ReturnJewelleryListCount()
        {
            List<int> table = rjobj.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        contactus_tableDB objcnt = new();

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
        feedback_tableDB objfeed = new();

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
        product_review_tableDB obj = new product_review_tableDB();

        [HttpGet("ProductreviewList")]
        public JsonResult ProductreviewList()
        {
            List<product_review_tableEntities> order = obj.OnGetListdt();
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

