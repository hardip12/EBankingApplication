using InfraStructure.GenericRepository;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Repository
{
    public class TransactionRepository : GenericRepository<Models.DomainModels.Transactions>
    {
        private readonly EBankingContext _context;
        public TransactionRepository(EBankingContext context) : base(context)
        {
            _context = context;
        }
    }
}
