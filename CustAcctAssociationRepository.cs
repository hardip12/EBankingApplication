﻿using InfraStructure.GenericRepository;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Repository
{
    public class CustAcctAssociationRepository : GenericRepository<Models.DomainModels.CustAcctAssociation>
    {
        private readonly EBankingContext _context;
        public CustAcctAssociationRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
    }
}
