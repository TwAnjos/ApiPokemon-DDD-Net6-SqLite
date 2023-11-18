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

        public async Task<bool> AddCSV(List<UserShawandpartners> userShawandpartnersList)
        {
            var result = _IFileInfrastructure.Add(userShawandpartnersList);
            return true;
        }

        public List<T> ReadCSV<T>(Stream file)
        {
            StreamReader reader = new StreamReader(file);
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<T>().ToList();
        }
    }
}