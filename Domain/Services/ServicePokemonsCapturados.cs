using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicePokemonsCapturados : IServicePokemonsCapturados
    {
        private readonly IPokemonsCapturados _IPokemonsCapturados;
        public ServicePokemonsCapturados(IPokemonsCapturados iPokemonsCapturadosk)
        {
            _IPokemonsCapturados = iPokemonsCapturadosk;
        }

        public async Task Adicionar(PokemonsCapturados pokemonsCapturados)
        {
            bool validaTitulo = pokemonsCapturados.ValidarPropriedadeiNT(pokemonsCapturados.PokemonId, "PokemonId");
            if (validaTitulo)
            {
                pokemonsCapturados.DataCapturado = DateTime.Now;
                pokemonsCapturados.DataAlteracao = DateTime.Now;
                pokemonsCapturados.Ativo = true;
                await _IPokemonsCapturados.Add(pokemonsCapturados);
            }
            else
            {
                throw new Exception("Erro ao salvar pokemon capturado.");
            }
        }

        public async Task Atualizar(PokemonsCapturados pokemonsCapturados)
        {
            bool validaTitulo = pokemonsCapturados.ValidarPropriedadeiNT(pokemonsCapturados.PokemonId, "PokemonId");
            if (validaTitulo)
            {
                pokemonsCapturados.DataAlteracao = DateTime.Now;
                await _IPokemonsCapturados.Add(pokemonsCapturados);
            }
        }

        public async Task<List<PokemonsCapturados>> ListarPokemonsCapturadosAtivos(string userId)
        {
            return await _IPokemonsCapturados.ListarPokemonsCapturados(p => p.Ativo && p.UserId == userId);
        }
    }
}
