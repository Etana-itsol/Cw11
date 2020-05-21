using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class DbService : IDbService
    {
        private readonly MyDbContext _dbContext;

        public DbService(MyDbContext context)
        {
            this._dbContext = context;
        }

        public IEnumerable<Doctor> getDoctor()
        {
            var doctors = _dbContext.Doctor.ToList();

            return doctors;
        }

        public void addDoctor(Doctor doctor)
        {
            _dbContext.Add(doctor);
            _dbContext.SaveChanges();
        }

        public void deleteDoctor(int id)
        {
            var doc = _dbContext.Doctor.FirstOrDefault(sr => sr.IdDoctor.Equals(id));
            if (doc == null)
               throw new Exception();
            
            _dbContext.Doctor.Remove(doc);
            _dbContext.SaveChanges();
        }
        public void updateDoctor(Doctor doctor)
        {
            _dbContext.Doctor.Attach(doctor);
            _dbContext.Entry(doctor).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
