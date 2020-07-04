using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Havbruksloggen.Business.Contracts;
using Havbruksloggen.Business.Models;
using Havbruksloggen.Business.Responses;
using Havbruksloggen.Data;
using Havbruksloggen.Entities;
using Bogus;

namespace Havbruksloggen.Business.Services
{
    public class SailorService : Service, ISailorService
    {
        public SailorService(HavbruksloggenContext dbContext)
            : base(dbContext) { }

        public async Task<IListResponse<SailorData>> GetSailorsAsync()
        {
            var response = new ListResponse<SailorData>();

            try
            {
                var query = SailorRepository.GetSailors();

                List<Sailor> sailorSet = await query.OrderBy(x => x.Name).ToListAsync();

                List<SailorData> sailors = new List<SailorData>();

                foreach (var sailor in sailorSet)
                {
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    TimeSpan span = DateTime.Now - sailor.BirthDate;

                    sailors.Add(new SailorData()
                    {
                        SailorId = sailor.SailorId,
                        Name = sailor.Name,
                        Picture = sailor.Picture,
                        BirthDate = sailor.BirthDate,
                        Email = sailor.Email,
                        CertifiedUntil = sailor.CertifiedUntil,
                        Age = DateTime.Now > sailor.BirthDate ? (zeroTime + span).Year - 1 : 0
                });
                }

                response.Model = sailors;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        public async Task<ISingleResponse<SailorData>> GetSailorAsync(Guid? sailorId = null)
        {
            var response = new SingleResponse<SailorData>();

            try
            {
                var existingSailor = await SailorRepository.GetSailorAsync(new Sailor(sailorId));

                if (existingSailor == null)
                    throw new NotImplementedException();

                var sailor = new SailorData
                {
                    SailorId = existingSailor.SailorId,
                    Name = existingSailor.Name,
                    Picture = existingSailor.Picture,
                    BirthDate = existingSailor.BirthDate,
                    Email = existingSailor.Email,
                    CertifiedUntil = existingSailor.CertifiedUntil
                };

                response.Model = sailor;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }


        public async Task<ISingleResponse<SailorData>> CreateSailorAsync(Sailor sailor)
        {
            var response = new SingleResponse<SailorData>();

            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var faker = new Faker();
                    sailor.Picture = "https://picsum.photos/200/300?random=" + faker.Random.Number(1, 1024);

                    SailorRepository.Add(sailor);

                    await SailorRepository.CommitChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    response.SetError(ex);
                }
            }

            return response;
        }

        public async Task<ISingleResponse<SailorData>> UpdateSailorAsync(Sailor sailor)
        {
            var response = new SingleResponse<SailorData>();

            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingSailor = await SailorRepository.GetSailorAsync(new Sailor(sailor.SailorId));

                    if (existingSailor == null)
                        throw new NotImplementedException();

                    existingSailor.Name = sailor.Name;
                    //existingSailor.Picture = sailor.Picture;
                    existingSailor.BirthDate = sailor.BirthDate;
                    existingSailor.Email = sailor.Email;
                    existingSailor.CertifiedUntil = sailor.CertifiedUntil;

                    SailorRepository.Update(existingSailor);

                    await SailorRepository.CommitChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    response.SetError(ex);
                }
            }

            return response;
        }

        public async Task<ISingleResponse<SailorData>> DeleteSailorAsync(Guid? sailorId = null)
        {
            var response = new SingleResponse<SailorData>();

            try
            {
                var existingSailor = await SailorRepository.GetSailorAsync(new Sailor(sailorId));

                if (existingSailor != null)
                {
                    SailorRepository.Remove(existingSailor);

                    await SailorRepository.CommitChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }
    }
}
