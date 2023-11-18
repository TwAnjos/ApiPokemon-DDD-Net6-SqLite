using CsvHelper;
using Domain.InterfacesInternal;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;
using System.Globalization;

namespace Domain.ServicesInternal
{
    public class ServiceFile : IServiceFile
    {
        private readonly IFileInfrastructure _IFileInfrastructure;

        public ServiceFile(IFileInfrastructure fileInfrastructure)
        {
            _IFileInfrastructure = fileInfrastructure;
        }

        public List<T> ReadCSV<T>(Stream file)
        {
            StreamReader reader = new StreamReader(file);
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<T>().ToList();
        }

        public async Task AddCSV(List<UserShawandpartners> userShawandpartnersList)
        {
            await _IFileInfrastructure.AddAll(userShawandpartnersList);
        }

        public async Task<List<UserShawandpartners>> FindUsers(string q)
        {
            List<UserShawandpartners> users = new();

            users.AddRange(await _IFileInfrastructure.FindUserByColumnName(f => f.Name.ToLower().Contains(q.ToLower())));
            users.AddRange(await _IFileInfrastructure.FindUserByColumnName(f => f.City.ToLower().Contains(q.ToLower())));
            users.AddRange(await _IFileInfrastructure.FindUserByColumnName(f => f.Country.ToLower().Contains(q.ToLower())));
            users.AddRange(await _IFileInfrastructure.FindUserByColumnName(f => f.Favorite_sport.ToLower().Contains(q.ToLower())));
            users.AddRange(await _IFileInfrastructure.FindUserByColumnName(f => f.Id.ToString().Contains(q.ToLower())));

            return users;
        }
    }
}