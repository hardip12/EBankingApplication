﻿using InfraStructure.GenericRepository;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Repository
{
    public class CustomerRepository : GenericRepository<Models.DomainModels.Customer>
    {
        private readonly EBankingContext _context;
        public CustomerRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
    }
}