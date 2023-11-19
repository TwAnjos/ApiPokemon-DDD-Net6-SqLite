using Entities.Entities;

namespace Domain.InterfacesInternal.InterfacesServices
{
    public interface IServiceFile
    {
        public List<T> ReadCSV<T>(Stream file);

        public Task AddCSV(List<UserShawandpartners> userShawandpartnersList);

        public Task<List<UserShawandpartners>> FindUsers(string q);
    }
}