using LabNet.EF.Entities;
using LabNet.EF.Logic;
using LabNet.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNet.EF.MVC.Controllers
{
    public class CustomersController : Controller
    {
        readonly CustomersLogic logic = new CustomersLogic();
        // GET: Customers
        public ActionResult Index()
        {

            try
            {
                List<Entities.Customers> customers = logic.GetAll();

                List<CustomersView> customersViews = customers.Select(s => new CustomersView
                {
                    CustomerID = s.CustomerID,
                    CompanyName = s.CompanyName
                }).ToList();

                return View(customersViews);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomersView customersView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customers customerEntity = new Customers();
                    customerEntity.CompanyName = customersView.CompanyName;
                    customerEntity.ContactName = customersView.ContactName;
                    customerEntity.ContactTitle = customersView.ContactTitle;
                    customerEntity.Address = customersView.Address;
                    customerEntity.City = customersView.City;
                    customerEntity.Region = customersView.Region;
                    customerEntity.PostalCode = customersView.PostalCode;
                    customerEntity.Country = customersView.Country;
                    customerEntity.Phone = customersView.Phone;
                    customerEntity.Fax = customersView.Fax;

                    logic.Add(customerEntity);

                    return RedirectToAction("Index");
                }
                return View(customersView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                Customers customerEntity = logic.FindById(id);
                CustomersView customer = new CustomersView();
                customer.CustomerID = customerEntity.CustomerID;
                customer.CompanyName = customerEntity.CompanyName;
                customer.ContactName = customerEntity.ContactName;
                customer.ContactTitle = customerEntity.ContactTitle;
                customer.Address = customerEntity.Address;
                customer.City = customerEntity.City;
                customer.Region = customerEntity.Region;
                customer.PostalCode = customerEntity.PostalCode;
                customer.Country = customerEntity.Country;
                customer.Phone = customerEntity.Phone;
                customer.Fax = customerEntity.Fax;

                ViewBag.customer = customerEntity;

                return View("Insert", customer);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(CustomersView customersView)
        {
            try
            {
                Customers customer = logic.FindById(customersView.CustomerID);
                customer.CompanyName = customersView.CompanyName;
                customer.ContactName = customersView.ContactName;
                customer.ContactTitle = customersView.ContactTitle;
                customer.Address = customersView.Address;
                customer.City = customersView.City;
                customer.Region = customersView.Region;
                customer.PostalCode = customersView.PostalCode;
                customer.Country = customersView.Country;
                customer.Phone = customersView.Phone;
                customer.Fax = customersView.Fax;

                logic.Update(customer);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                logic.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensaje = ex.Message});
            }
        }
    }
}