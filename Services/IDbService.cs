using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public interface IDbService
    {
        public IEnumerable<Doctor> getDoctor();
        public void deleteDoctor(int id);
        public void updateDoctor(Doctor doctor);
        public void addDoctor(Doctor doctor);
    }
}
