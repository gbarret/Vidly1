using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.RepositoryGbs;

namespace Vidly1.Controllers
{
    public class CalculatorController : Controller
    {
        // Using the interface ... I need to instatiate the Interface in the controller's constructor ...
        // This way I can use it in any of Action Methods in this Controller ...
        private ICalculator Calculator;

        public CalculatorController()
        {
            this.Calculator = new Calculator();
        }
        
        // GET: Calculator
        public ActionResult Index()
        {
            //Calculator Calculator = new Calculator();
            ViewBag.X = 4;
            ViewBag.Y = 6;
            ViewBag.Add = Calculator.Add(ViewBag.X, ViewBag.Y);
            ViewBag.Sub = Calculator.Subtract(ViewBag.X, ViewBag.Y);

            return View();
        }


    }
}