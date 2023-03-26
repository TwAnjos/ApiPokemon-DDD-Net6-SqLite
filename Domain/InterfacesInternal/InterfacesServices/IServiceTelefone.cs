using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesInternal.InterfacesServices
{
    public interface IServiceTelefone
    {
        Task Adicionar(Telefone tel);
    }
}
