using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class TeachersService : CrudService<Teacher>, ITeachersService
    {
        public IEnumerable<Teacher> ReadBySpecialization(string specialization)
        {
            return _entities.Where(x => x.Specialization == specialization).ToList();
        }
    }
}
