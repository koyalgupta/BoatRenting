using BoatRentSolution.Data.Models;
using BoatRentSolution.Repository.Common;
using BoatRentSolution.Repository.IRepository;
using BoatRentSolution.Service.Common;
using BoatRentSolution.Service.IService;
using System;
using System.Collections.Generic;
namespace BoatRentSolution.Service.Service
{
    public class BoatDetailsService : Services<BoatDetails>, IBoatDetailsService
    {
        private readonly IBoatDetailsRepository boatDetailsRepository;
        public BoatDetailsService(IBoatDetailsRepository _boatDetailsRepository, IRepository<BoatDetails> boatRepository) : base(boatRepository)
        {
            boatDetailsRepository = _boatDetailsRepository;
        }
        
    }
}
