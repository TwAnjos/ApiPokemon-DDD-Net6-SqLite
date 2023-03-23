﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServicePokemonsCapturados
    {
        Task Adicionar(PokemonsCapturados pokemonsCapturados);
        Task Atualizar(PokemonsCapturados pokemonsCapturados);
        Task<List<PokemonsCapturados>> ListarPokemonsCapturadosAtivos(string userId);
    }
}
