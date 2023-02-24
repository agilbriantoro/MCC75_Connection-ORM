﻿using MCC75_NET.Models;
using MCC75_NET.Repositories.Interface;
using MCC75_NET.Repositories;
using MCC75_NET.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCC75_NET.Contexts;

namespace MCC75NET.Repositories;

public class EducationRepository : IRepository<int, Education>
{
    private readonly MyContext context;
    private readonly UniversityRepository universityRepository;
    public EducationRepository(MyContext context, UniversityRepository universityRepository)
    {
        this.context = context;
        this.universityRepository = universityRepository;
    }
    public int Delete(int key)
    {
        int result = 0;
        var education = GetById(key);
        if (education == null)
        {
            return result;
        }

        context.Remove(education);
        result = context.SaveChanges();

        return result;
    }

    public List<Education> GetAll()
    {
        return context.Educations.ToList();
    }

    public Education GetById(int key)
    {
        return context.Educations.Find(key);
    }
    public int Insert(Education entity)
    {
        int result = 0;
        context.Add(entity);
        result = context.SaveChanges();

        return result;
    }

    public int Update(Education entity)
    {
        int result = 0;
        context.Entry(entity).State = EntityState.Modified;
        result = context.SaveChanges();

        return result;
    }
    public List<EducationUniversityVM> GetEducationUniversities()
    {
        var results = (from e in GetAll()
                       join u in universityRepository.GetAll()
                       on e.UniversityId equals u.Id
                       select new EducationUniversityVM
                       {
                           Id = e.Id,
                           Degree = e.degree,
                           GPA = e.Gpa,
                           Major = e.Major,
                           UniversityName = u.Name
                       }).ToList();

        return results;
    }
    public EducationUniversityVM GetByIdEducations(int key)
    {
        var education = GetById(key);
        var results = new EducationUniversityVM
        {
            Id = education.Id,
            Degree = education.degree,
            GPA = education.Gpa,
            Major = education.Major,
            UniversityName = universityRepository.GetById(education.UniversityId).Name,
        };

        return results;
    }
}