using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.InterfacesInternal.InterfacesServices
{
    public interface IServiceFile
    {
        public List<T> ReadCSV<T>(Stream file);

        Task AddCSV(List<UserShawandpartners> userShawandpartnersList);
    }
}