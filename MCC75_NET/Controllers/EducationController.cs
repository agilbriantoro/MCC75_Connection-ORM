using MCC75_NET.Models;
using MCC75_NET.ViewModels;
using MCC75_NET.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using MCC75NET.Repositories;

namespace MCC75_NET.Controllers;
public class EducationController : Controller
{
    private readonly EducationRepository educationRepository;
    private readonly UniversityRepository universityRepository;

    public EducationController(EducationRepository educationRepository,
        UniversityRepository universityRepository)
    {
        this.educationRepository = educationRepository;
        this.universityRepository = universityRepository;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        var educations = educationRepository.GetEducationUniversities();
        return View(educations);
    }
    public IActionResult Details(int id)
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        return View(educationRepository.GetByIdEducations(id));

    }
    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var universities = universityRepository.GetAll()
            .Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Name
            });
        ViewBag.University = universities;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EducationUniversityVM educations)
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var result = educationRepository.Insert(new Education
        {
            Id = educations.Id,
            degree = educations.Degree,
            Gpa = educations.GPA,
            Major = educations.Major,
            UniversityId = Convert.ToInt32(educations.UniversityName)
        });
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }

    public IActionResult Edit(int id)
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var universities = universityRepository.GetAll()
            .Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Name
            });
        ViewBag.University = universities;

        return View(educationRepository.GetByIdEducations(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EducationUniversityVM educations)
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var result = educationRepository.Update(new Education
        {
            Id = educations.Id,
            degree = educations.Degree,
            Gpa = educations.GPA,
            Major = educations.Major,
            UniversityId = Convert.ToInt32(educations.UniversityName)
        });
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var educations = educationRepository.GetById(id);
        return View(new EducationUniversityVM
        {
            Id = educations.Id,
            Degree = educations.degree,
            GPA = educations.Gpa,
            Major = educations.Major,
            UniversityName = universityRepository.GetById(educations.UniversityId).Name
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var result = educationRepository.Delete(id);
        if (result == 0)
        {
            // Data Tidak Ditemukan
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Delete));
    }
}