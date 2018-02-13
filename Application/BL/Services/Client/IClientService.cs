using System.Collections.Generic;
using BL.Services.Client.Models;

namespace BL.Services.Client
{
    public interface IClientService
    {
        ClientModel Add(ClientModel client);
        IEnumerable<ClientModel> GetAll();
        ClientModel Get(int id);
        void Delete(int id);
        void Update(ClientModel client);

        IEnumerable<DisabilityModel> GetDisabilities();
        IEnumerable<MaritalStatusModel> GetMaritalStatuses();
        IEnumerable<TownModel> GetTowns();
        IEnumerable<CitizenshipModel> GetCitizenships();
    }
}
