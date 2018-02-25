using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BL.Services.Client.Models;
using BL.Services.Common.Model;
using BL.Services.Utilities;
using ORMLibrary;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Client
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService() : base()
        {
            if (!Context.Disabilities.Any())
            {
                InitStatuses();
            }
        }

        public ClientModel Add(ClientModel client)
        {
            try
            {
                if (Context.Clients.Any(e => e.IdentificationNumber == client.IdentificationNumber))
                    throw new ValidationException("User with the same identification number is already exists.");
                if (Context.Clients.Any(
                        e => e.PassportNumber == client.PassportNumber && e.PassportSeries == client.PassportSeries))
                    throw new ValidationException("User with the same passport seria and number is already exists.");
                var dbClient = Mapper.Map<ClientModel, ORMLibrary.Client>(client);
                dbClient.Disability = Context.Disabilities.First(e => e.Id == client.Disability.Id);
                dbClient.Town = Context.Towns.First(e => e.Id == client.Town.Id);
                dbClient.MartialStatus = Context.MartialStatus.First(e => e.Id == client.MartialStatus.Id);
                dbClient.Citizenship = Context.Citizenships.First(e => e.Id == client.Citizenship.Id);
                dbClient = Context.Clients.Add(dbClient);
                Context.SaveChanges();
                return Mapper.Map<ORMLibrary.Client, ClientModel>(dbClient);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Exception during client adding.", ex);
            }
        }

        public IEnumerable<ClientModel> GetAll()
        {
            return Context.Clients.ToArray().Select(Mapper.Map<ORMLibrary.Client, ClientModel>);
        }

        public ClientModel Get(int id)
        {
            var client = Context.Clients.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Client, ClientModel>(client);
        }

        public void Delete(int id)
        {
            try
            {
                var client = Context.Clients.FirstOrDefault(e => e.Id == id);
                if (client != null)
                {
                    Context.Clients.Remove(client);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ServiceException("Exception during client deleting.", ex);
            }
        }

        public void Update(ClientModel client)
        {
            try
            {
                var dbClient = Context.Clients.Where(e => e.Id == client.Id).FirstOrDefault();

                if (null == dbClient)
                {
                    throw new ServiceException("User not found.");
                }

                Mapper.Map(client, dbClient);

                dbClient.Disability = Context.Disabilities.First(e => e.Id == client.Disability.Id);
                dbClient.Town = Context.Towns.First(e => e.Id == client.Town.Id);
                dbClient.MartialStatus = Context.MartialStatus.First(e => e.Id == client.MartialStatus.Id);
                dbClient.Citizenship = Context.Citizenships.First(e => e.Id == client.Citizenship.Id);

                Context.Entry(dbClient).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (ServiceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Exception during client updating.", ex);
            }
        }

        public IEnumerable<DisabilityModel> GetDisabilities()
        {
            return Context.Disabilities.ToArray().Select(Mapper.Map<Disability, DisabilityModel>);
        }

        public IEnumerable<MaritalStatusModel> GetMaritalStatuses()
        {
            return Context.MartialStatus.ToArray().Select(Mapper.Map<MartialStatus, MaritalStatusModel>);
        }

        public IEnumerable<TownModel> GetTowns()
        {
            return Context.Towns.ToArray().Select(Mapper.Map<Town, TownModel>);
        }

        public IEnumerable<CitizenshipModel> GetCitizenships()
        {
            return Context.Citizenships.ToArray().Select(Mapper.Map<Citizenship, CitizenshipModel>);
        }

        private void InitStatuses()
        {
            Context.Disabilities.AddRange(new[]
            {
                new Disability() {Status = "Not disable"},
                new Disability() {Status = "Disability of 3 degree."},
                new Disability() {Status = "Disability of 2 degree."},
                new Disability() {Status = "Disability of 1 degree."}
            });
            Context.MartialStatus.AddRange(new[]
            {
                new MartialStatus() {Status = "Married"},
                new MartialStatus() {Status = "Single"}
            });
            Context.Towns.AddRange(new[]
            {
                new Town() {Name = "Minsk", Country = "Belarus"},
                new Town() {Name = "Brest", Country = "Belarus"},
                new Town() {Name = "Grodno", Country = "Belarus"},
                new Town() {Name = "Gomel", Country = "Belarus"},
                new Town() {Name = "Mogilev", Country = "Belarus"},
                new Town() {Name = "Vitebsk", Country = "Belarus"},
            });
            Context.Citizenships.AddRange(new[]
            {
                new Citizenship() {Country = "Belarus"},
                new Citizenship() {Country = "Russia"},
                new Citizenship() {Country = "Poland"},
                new Citizenship() {Country = "Ukraine"},
                new Citizenship() {Country = "Lithuania"},
                new Citizenship() {Country = "Latvia"},
            });
            Context.SaveChanges();
        }
    }
}
