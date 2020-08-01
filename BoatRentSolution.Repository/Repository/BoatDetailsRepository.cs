using BoatRentSolution.Data.Models;
using BoatRentSolution.Repository.Common;
using BoatRentSolution.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentSolution.Repository.Repository
{
    public class BoatDetailsRepository : Repository<BoatDetails>, IBoatDetailsRepository
    {
        public BoatDetailsRepository(BoatRentContext context) : base(context) { }
    }
}
