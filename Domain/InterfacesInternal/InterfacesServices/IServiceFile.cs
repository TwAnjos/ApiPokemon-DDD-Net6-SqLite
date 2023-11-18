using Entities.Entities;

namespace Domain.InterfacesInternal.InterfacesServices
{
    public interface IServiceFile
    {
        public List<T> ReadCSV<T>(Stream file);

        public Task<bool> AddCSV(List<UserShawandpartners> userShawandpartnersList);
    }
}