using CsvHelper;
using Domain.InterfacesInternal;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
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
    }
}