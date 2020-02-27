using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.EBankingUnitOfWork
{
    public interface IUnitOfwork :IDisposable
    {
        bool SaveChanges();
    }
}
