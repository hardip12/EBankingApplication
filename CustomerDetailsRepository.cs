using InfraStructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Repository
{
    public class CustomerDetailsRepository : GenericRepository<Models.DomainModels.CustomerDetails>
    {

        private readonly EBankingContext _context;
        public CustomerDetailsRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
        
    }

}

