using Havbruksloggen.Data;
using Havbruksloggen.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Havbruksloggen.Business.Services
{
    public abstract class Service : IService
    {
        protected bool Disposed;
        protected readonly HavbruksloggenContext DbContext;

        protected IBoatRepository m_boatRepository;
        protected ISailorRepository m_sailorRepository;
        protected ICrewRepository m_crewRepository;



        public Service(HavbruksloggenContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                DbContext?.Dispose();

                Disposed = true;
            }
        }


        protected IBoatRepository BoatRepository
            => m_boatRepository ?? (m_boatRepository = new BoatRepository(DbContext));

        protected ISailorRepository SailorRepository
            => m_sailorRepository ?? (m_sailorRepository = new SailorRepository(DbContext));

        protected ICrewRepository CrewRepository
            => m_crewRepository ?? (m_crewRepository = new CrewRepository(DbContext));


    }
}
