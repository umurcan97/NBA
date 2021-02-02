using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly INBAContext _dataContext;

        public UnitOfWork(INBAContext dataContext)
        {
            this._dataContext = dataContext;
        }

        /// <summary>
        /// * Entity' ler üzerindeki tüm değişiklikleri tek bir transaction içerisinde database'e comit eder.
        /// * Atomic çalışır.
        /// * Bu methdod DbUpdateConcurrencyException alırsa tercihe göre resolve eder yada throw eder.
        /// 
        ///    Not: MerchantBalance DbUpdateConcurrencyException' ları throw edilmez , resolve edilir.
        ///    Ancak User Entity üzerindeki DbUpdateConcurrencyException' lar throw edilmelidir,
        ///    aksi halde User' ın aylık limitlerini aşabileceği durumlar oluşabilir.
        /// 
        /// </summary>
        public int Commit()
        {
            var result = 0;

            bool concurrencyExceptionOccurred;

            /* DbUpdateConcurrencyException problemi resolve edilene kadar çalışan bir döngüdür.*/
            do
            {
                concurrencyExceptionOccurred = false;

                try
                {
                    result = ((NBAContext)this._dataContext).SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    concurrencyExceptionOccurred = true;

                    DbEntityEntry entry = exception.Entries.Single();

                    throw;
                }
            } while (concurrencyExceptionOccurred);

            return result;
        }
    }
}
