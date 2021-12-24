using Evaluasi.Dtos;
using Evaluasi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluasi.DAL
{
    public class AuthorDAL : IAuthor
    {
        private ApplicationDbContext _db;
        public AuthorDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"data course {id} tidak ditemukan");
                _db.Authors.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"error: {dbEx.Message}");
            }

        }
        
        public async Task<IEnumerable<Author>> GetAll()
        {
            var results = await (from a in _db.Authors
                                 orderby a.AuthorID ascending
                                 select a).ToListAsync();
            return results;
        }


        public async Task<Author> GetById(string id)
        {
            var result = await (from a in _db.Authors
                                where a.AuthorID == Convert.ToInt32(id)
                                select a).SingleOrDefaultAsync();
            if (result == null) throw new Exception($"data id {id} tidak ditemukan");

            return result;
        }


        public async Task<IEnumerable<Author>> GetByName(string Name)
        {
            var results = await (from a in _db.Authors
                                 where a.FirstName.ToLower().Contains(Name.ToLower()) || a.LastName.ToLower().Contains(Name.ToLower())
                                 orderby a.FirstName ascending
                                 select a).ToListAsync();
            return results;
        }

        public async Task<Author> Insert(Author obj)
        {
            try
            {
                _db.Authors.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

       
        public async Task<Author> Update(string id, Author obj)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"data course id {id} tidak ditemukan");
                result.FirstName = obj.FirstName;
                result.LastName = obj.LastName;
                result.DateOfBirth = obj.DateOfBirth;
                result.MainCategory = obj.MainCategory;
                await _db.SaveChangesAsync();
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }
    }
}
