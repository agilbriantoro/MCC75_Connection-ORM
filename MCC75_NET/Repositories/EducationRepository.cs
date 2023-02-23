using MCC75_NET.Contexts;
using MCC75_NET.Models;
using MCC75_NET.Repositories.Interface;
using MCC75_NET.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MCC75_NET.Repositories
{
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
            throw new NotImplementedException();
        }

        //Index
        public List<Education> GetAll()
        {
            return context.Educations.ToList();
        }
        

        //Detail
        public Education GetById(int key)
        {
            return context.Educations.Find(key);
        }

        //Create
        public int Insert(Education entity)
        {
            int result = 0;
            context.Add(entity);
            result = context.SaveChanges();
            return result;
        }

        // Edit
        public int Update(Education entity)
        {
            int result = 0;
            context.Entry(entity).State = EntityState.Modified;
            result = context.SaveChanges();
            return result;
        }

        public EducationUniversityVM GetEduUnivById(int key)
        {
            var educations = GetById(key);
            var results = new EducationUniversityVM
            {
                Id = educations.Id,
                Degree = educations.degree,
                GPA = educations.Gpa,
                Major = educations.Major,
                UniversityName = universityRepository.GetById(educations.UniversityId).Name
            };
            return results;
        }

        public List<EducationUniversityVM> GetEducationUniversities(UniversityRepository universityRepository)
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
    }
}
