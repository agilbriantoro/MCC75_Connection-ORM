﻿using MCC75_NET.Contexts;
using MCC75_NET.Models;
using MCC75_NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC75_NET.Controllers
{
    public class EducationController : Controller
    {
        private readonly MyContext context;
        private readonly EducationVM educationVM;
        public EducationController(MyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var results = context.Educations.Join(
                context.Universities,
                e => e.UniversityId,
                u => u.Id,
                (e, u) => new EducationVM
                {
                    Id = e.Id,
                    Degree = e.degree,
                    GPA = e.Gpa,
                    Major = e.Major,
                    UniversityName = u.Name
                });
            /*var educations = context.Educations.ToList();*/
            return View(results);
        }
        public IActionResult Details(int id)
        {
            var education = context.Educations.Find(id);
            return View(new EducationVM
            {
                Id = education.Id,
                Degree = education.degree,
                GPA = education.Gpa,
                Major = education.Major,
                UniversityName = context.Universities.Find(education.UniversityId).Name
            });
        }
        public IActionResult Create()
        {
            var universities = context.Universities.ToList()
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Name
                });
            ViewBag.UniversityId = universities;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EducationVM education)
        {
            context.Add(new Education
            {
                Id = education.Id,
                degree = education.Degree,
                Gpa = education.GPA,
                Major = education.Major,
                UniversityId = Convert.ToInt16(education.UniversityName)
            });
            var result = context.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
            /*context.Add(education);*/
        }
        public IActionResult Edit(int id)
        {
            var education = context.Educations.Find(id);

            var universities = context.Universities.ToList()
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Name
                });
            ViewBag.University = universities;

            return View(new EducationVM
            {
                Id = education.Id,
                Degree = education.degree,
                GPA = education.Gpa,
                Major = education.Major,
                UniversityName = context.Universities.Find(education.UniversityId).Name
            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EducationVM education)
        {
            var request = context.Educations.Find(education.Id);
            if (request != null)
            {
                request.Id = education.Id;
                request.degree = education.Degree;
                request.Gpa = education.GPA;
                request.Major = education.Major;
                request.UniversityId = Convert.ToInt16(education.UniversityName);
            }
            var update = context.SaveChanges();
            if (update > 0)
                return RedirectToAction(nameof(Index));
            return View();
        }
        public IActionResult Delete(int id)
        {
            var education = context.Educations.Find(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(EducationVM education)
        {
            var getId = context.Educations.Find(education.Id);
            context.Remove(getId);
            var result = context.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

