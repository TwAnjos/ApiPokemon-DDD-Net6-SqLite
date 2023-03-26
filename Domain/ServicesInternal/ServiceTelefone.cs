using Domain.InterfacesInternal;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServicesInternal
{
    public class ServiceTelefone: IServiceTelefone
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
    }
}
