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
    public class BoatService : Service, IBoatService
    {
        public BoatService(HavbruksloggenContext dbContext)
            : base(dbContext) {}

        public async Task<IListResponse<BoatData>> GetBoatsAsync()
        {
            var response = new ListResponse<BoatData>();

            try
            {
                var query = BoatRepository.GetBoats();

                List<Boat> boatSet = await query.OrderBy(x => x.Name).ToListAsync();

                List<BoatData> boats = new List<BoatData>();

                foreach (var boat in boatSet)
                {
                    List<CrewData> crew = new List<CrewData>();
                    foreach (var data in boat.BoatCrewCollection)
                    {
                        SailorData sailor = null;
                        if (data.Sailor != null)
                        {
                            sailor = new SailorData
                            {
                                SailorId = data.Sailor.SailorId,
                                Name = data.Sailor.Name,
                                Picture = data.Sailor.Picture,
                                BirthDate = data.Sailor.BirthDate,
                                Email = data.Sailor.Email,
                                CertifiedUntil = data.Sailor.CertifiedUntil
                            };
                        }
                                                    
                        crew.Add(new CrewData()
                        {
                            CrewId = data.CrewId,
                            Sailor = sailor,
                            Role = data.Role
                        });
                    }


                    boats.Add(new BoatData()
                    {
                        BoatId = boat.BoatId,
                        Name = boat.Name,
                        Producer = boat.Producer,
                        BuildNumber = boat.BuildNumber,
                        Loa = boat.Loa,
                        B = boat.B,
                        Picture = boat.Picture,
                        BoatCrewCollection = crew.ToArray()
                    });
                }

                response.Model = boats;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        public async Task<ISingleResponse<BoatData>> GetBoatAsync(Guid? boatId = null)
        {
            var response = new SingleResponse<BoatData>();

            try
            {
                var existingBoat = await BoatRepository.GetBoatAsync(new Boat(boatId));

                if(existingBoat == null)
                    throw new NotImplementedException();

                List<CrewData> crew = new List<CrewData>();
                foreach (var data in existingBoat.BoatCrewCollection)
                {
                    SailorData sailor = null;
                    if (data.Sailor != null)
                    {
                        sailor = new SailorData
                        {
                            SailorId = data.Sailor.SailorId,
                            Name = data.Sailor.Name,
                            Picture = data.Sailor.Picture,
                            BirthDate = data.Sailor.BirthDate,
                            Email = data.Sailor.Email,
                            CertifiedUntil = data.Sailor.CertifiedUntil
                        };
                    }

                    crew.Add(new CrewData()
                    {
                        CrewId = data.CrewId,
                        Sailor = sailor,
                        Role = data.Role
                    });
                }

                var boat = new BoatData
                {
                    BoatId = existingBoat.BoatId,
                    Name = existingBoat.Name,
                    Producer = existingBoat.Producer,
                    BuildNumber = existingBoat.BuildNumber,
                    Loa = existingBoat.Loa,
                    B = existingBoat.B,
                    Picture = existingBoat.Picture,
                    BoatCrewCollection = crew.ToArray()
                };

                response.Model = boat;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        public async Task<ISingleResponse<BoatData>> CreateBoatAsync(Boat boat, Crew[] crewCollection)
        {
            var response = new SingleResponse<BoatData>();

            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var faker = new Faker();
                    boat.Picture = "https://picsum.photos/200/300?random=" + faker.Random.Number(1, 1024);

                    BoatRepository.Add(boat);

                    await BoatRepository.CommitChangesAsync();


                    foreach (var item in crewCollection)
                    {
                        CrewRepository.Add(item);
                    }

                    if (crewCollection.Any())
                        await CrewRepository.CommitChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    response.SetError(ex);
                }
            }

            return response;
        }

        public async Task<ISingleResponse<BoatData>> UpdateBoatAsync(Boat boat, Crew[] crewCollection)
        {
            var response = new SingleResponse<BoatData>();

            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingBoat = await BoatRepository.GetBoatAsync(new Boat(boat.BoatId));

                    if (existingBoat == null)
                        throw new NotImplementedException();

                    existingBoat.Name = boat.Name;
                    existingBoat.Producer = boat.Producer;
                    existingBoat.BuildNumber = boat.BuildNumber;
                    existingBoat.Loa = boat.Loa;
                    existingBoat.B = boat.B;
                    //existingBoat.Picture = boat.Picture;

                    BoatRepository.Update(existingBoat);

                    await BoatRepository.CommitChangesAsync();


                    var queryCrew = CrewRepository.GetBoatCrew(existingBoat.BoatId);

                    var existingCrew = await queryCrew.ToListAsync();

                    foreach (var crewMember in existingCrew)
                    {
                        if (!crewCollection.Any(x => x.CrewId == crewMember.CrewId))
                            CrewRepository.Remove(crewMember);
                    }

                    foreach (var crewMember in crewCollection)
                    {
                        var existingCrewMember = existingCrew.FirstOrDefault(x => x.CrewId == crewMember.CrewId);
                        if (existingCrewMember == null)
                        {
                            var newCrewMember = new Crew()
                            {
                                CrewId = Guid.NewGuid(),
                                BoatId = existingBoat.BoatId,
                                SailorId = crewMember.SailorId,
                                Role = crewMember.Role
                            };

                            CrewRepository.Add(newCrewMember);
                        }
                        else
                        {
                            existingCrewMember.SailorId = crewMember.SailorId;
                            existingCrewMember.Role = crewMember.Role;

                            CrewRepository.Update(existingCrewMember);
                        }
                    }

                    await CrewRepository.CommitChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    response.SetError(ex);
                }
            }

            return response;
        }

        public async Task<ISingleResponse<BoatData>> DeleteBoatAsync(Guid? boatId = null)
        {
            var response = new SingleResponse<BoatData>();

            try
            {
                var existingBoat = await BoatRepository.GetBoatAsync(new Boat(boatId));

                if (existingBoat != null)
                {
                    BoatRepository.Remove(existingBoat);

                    await BoatRepository.CommitChangesAsync();
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
