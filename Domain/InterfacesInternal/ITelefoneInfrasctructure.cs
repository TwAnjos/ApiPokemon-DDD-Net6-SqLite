using Domain.Utils.InterfaceGenerics;
using Entities.Entities;

namespace Domain.InterfacesInternal
{
    public interface ITelefoneInfrasctructure : IGeneric<Telefone>
    {
        Telefone? GetEntityByUserId(string id);
    }
}