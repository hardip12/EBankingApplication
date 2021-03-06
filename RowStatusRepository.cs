﻿using InfraStructure.GenericRepository;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Repository
{
    public class RowStatusRepository : GenericRepository<Models.DomainModels.RowStatus>
    {
        private readonly EBankingContext _context;
        public RowStatusRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
    }
}
