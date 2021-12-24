using Evaluasi.Models;
using System;
using System.Linq;

namespace Evaluasi.DAL
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any())
            {
                return;
            }


            var authors = new Author[]
            {
                new Author{FirstName="Aina", LastName="Aji", DateOfBirth=DateTime.Parse("2021-12-24"), MainCategory="Artificial Intelligence"},
                new Author{FirstName="Dian", LastName="Pertiwi", DateOfBirth=DateTime.Parse("2021-12-24"), MainCategory="Physicist"},
                new Author{FirstName="Agus", LastName="Kurniawan", DateOfBirth=DateTime.Parse("2021-12-24"), MainCategory="Astrophysicist"},
                new Author{FirstName="Budi", LastName="Kurniawan", DateOfBirth=DateTime.Parse("2021-12-24"), MainCategory="Programming"}
            };

            foreach (var a in authors)
            {
                context.Authors.Add(a);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals",Description="This Book For Study Purpose Only"},
                new Course{Title="Microservices Architecture",Description="This Book For Study Purpose Only"},
                new Course{Title="Frontend Programming",Description="This Book For Study Purpose Only"},
                new Course{Title="Backend RESTful API",Description="This Book For Study Purpose Only"},
                new Course{Title="Entity Frmework Core",Description="This Book For Study Purpose Only"}
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }
    }
}
