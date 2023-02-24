using MCC75_NET.Contexts;
using MCC75_NET.Models;
using MCC75_NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC75_NET.Controllers
{
    public class AccountController : Controller
    {

        public AccountController(MyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET : Account/Register
        public IActionResult Register()
        {
            var genders = new List<SelectListItem>{
            new SelectListItem
            {
                Value = "0",
                Text = "Male"
            },
            new SelectListItem
            {
                Value = "1",
                Text = "Female"
            },
        };

            ViewBag.Genders = genders;
            return View();
        }

        // POST : Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                // Bikin kondisi untuk mengecek apakah data university sudah ada
                University university = new University
                {
                    Name = registerVM.UniversityName
                };
                context.Universities.Add(university);
                context.SaveChanges();

                Education education = new Education
                {
                    Major = registerVM.Major,
                    degree = registerVM.Degree,
                    Gpa = (float)registerVM.GPA,
                    UniversityId = university.Id
                };
                context.Educations.Add(education);
                context.SaveChanges();

                Employee employee = new Employee
                {
                    NIK = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    BirthDate = registerVM.BirthDate,
                    Gender = (Models.GenderEnum)registerVM.Gender,
                    HiringDate = registerVM.HiringDate,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.PhoneNumber,
                };
                context.Employees.Add(employee);
                context.SaveChanges();

                Account account = new Account
                {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET : Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            var getAccounts = context.Employees.Join(
            context.Accounts,
            e => e.NIK,
            a => a.EmployeesNik,
            (e, a) => new LoginVM
            {
                Email = e.Email,
                Password = a.Password
            });

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Account or Password Not Found!");
            return View();
        }
    }
}
