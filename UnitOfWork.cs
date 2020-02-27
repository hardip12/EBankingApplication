using Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.EBankingUnitOfWork
{
    public abstract class UnitOfWork :IUnitOfwork
    {
        protected readonly EBankingContext _context;
        public UnitOfWork(EBankingContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    //Log Exception Handling message                      
                    returnValue = false; // ex.ToString();
                    //_logger.LogException(nameof(SaveChanges), ex, "There was an error on '{0}' invocation", nameof(SaveChanges));
                    dbContextTransaction.Rollback();
                    //throw ex;
                }
            }

            return returnValue;
        }

        #region IDisposable Support  
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                //dispose managed state (managed objects).  
            }
            _disposedValue = true;
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.  
        // ~UnitOfWork() {  
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
        //   Dispose(false);  
        // }  

        // This code added to correctly implement the disposable pattern.  
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.  
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

