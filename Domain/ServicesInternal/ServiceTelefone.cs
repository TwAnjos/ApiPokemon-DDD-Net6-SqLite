using Domain.InterfacesInternal;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;

namespace Domain.ServicesInternal
{
    public class ServiceTelefone : IServiceTelefone
    {
        private readonly ITelefoneInfrasctructure _ITelefoneInfrasctructure;

        public ServiceTelefone(ITelefoneInfrasctructure iTelefoneInfrasctructure)
        {
            _ITelefoneInfrasctructure = iTelefoneInfrasctructure;
        }

        public async Task Adicionar(Telefone tel)
        {
            await _ITelefoneInfrasctructure.Add(tel);
        }

        public Telefone? GetByUserId(string id)
        {
            return _ITelefoneInfrasctructure.GetEntityByUserId(id);
        }
    }
}