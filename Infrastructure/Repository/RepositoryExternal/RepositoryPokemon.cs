﻿using Domain.InterfacesExternal;
using Entities.Entities;
using Entities.EntitiesExternal;
using Infrastructure.Repository.Generics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryExternal
{
    public class RepositoryPokemon : RepositoryGenerics<Pokemon>,  IPokemon
    {
        //https://pokeapi.co/api/v2/pokemon/1
        private readonly string urlApi = "https://pokeapi.co/api/v2/pokemon/";

        private List<Species> _listSpeciesEvolutions;

        public RepositoryPokemon()
        {
            _listSpeciesEvolutions = new List<Species>();
        }

        public Pokemon? GetPokemonById(int idPokemon)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.GetAsync(urlApi + idPokemon);
                    resposta.Wait();

                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        var pokemon = JsonConvert.DeserializeObject<Pokemon>(retorno.Result);
                        pokemon.evolutions = GetSpeciesDetailsPokemon(pokemon.species.url);
                        pokemon.spriteBase64 = GetSpriteB64(pokemon.sprites.front_default);

                        return pokemon;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private byte[] GetSpriteB64(string filePathSpriteImg)
        {
            if(filePathSpriteImg == null)
            {
                return null;
            }
            using(var client = new WebClient())
            {
                return client.DownloadData(filePathSpriteImg);
            }
        }

        private List<Species> GetSpeciesDetailsPokemon(string url)
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    Task<HttpResponseMessage> response = client.GetAsync($"{url}");
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        Task<string> result = response.Result.Content.ReadAsStringAsync();
                        SpeciesDetails? details = JsonConvert.DeserializeObject<SpeciesDetails>(result.Result);

                        return GetEvolutionListFromChainPokemon(details.evolution_chain.url);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        
        private List<Species>? GetEvolutionListFromChainPokemon(string url)
        {
            _listSpeciesEvolutions.Clear();
            EvolutionChainDetails? details = new EvolutionChainDetails();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Task<HttpResponseMessage> response = client.GetAsync($"{url}");
                    response.Wait();

                    if(response.Result.IsSuccessStatusCode)
                    {
                        Task<string> result = response.Result.Content.ReadAsStringAsync();
                        details = JsonConvert.DeserializeObject<EvolutionChainDetails>(result.Result);

                        _listSpeciesEvolutions.Add(details.chain.species);

                        //temos que achar a species dentro de cada evolve_to e add em _listSpeciesEvolutions
                        CarregaListadeEspeciesPokemon(details.chain.evolves_to);
                        return _listSpeciesEvolutions;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        private void CarregaListadeEspeciesPokemon(List<EvolvesTo> listEvolvesTo)
        {
            foreach (var item in listEvolvesTo)
            {
                if (item.species is not null)
                {
                    _listSpeciesEvolutions.Add(item.species);
                    CarregaListadeEspeciesPokemon(item.evolves_to);
                }
            }
        }


        public Pokemon GetPokemonByName(string namePokemon)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.GetAsync(urlApi + namePokemon);
                    resposta.Wait();

                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        var pokemon = JsonConvert.DeserializeObject<Pokemon>(retorno.Result);
                        pokemon.evolutions = GetSpeciesDetailsPokemon(pokemon.species.url);
                        pokemon.spriteBase64 = GetSpriteB64(pokemon.sprites.front_default);

                        return pokemon;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pokemon> List10PokemonRandom()
        {
            var list10Pokemons = new List<Pokemon>();
            var random = new Random();

            for(int i = 0; i < 10; i++)
            {
                //1010 é o número máximo de pokemons atualmente.
                var numeroRND = random.Next(1, 1010);

                list10Pokemons.Add(GetPokemonById(numeroRND));
            }
            return list10Pokemons;
        }

        public Task Add(Pokemon entity)
        {
            throw new NotImplementedException("Não implementado");
        }

        public Task Update(Pokemon entity)
        {
            throw new NotImplementedException("Não implementado");
        }

        public Task Delete(Pokemon entity)
        {
            throw new NotImplementedException("Não implementado");
        }

        public Task<Pokemon> GetEntityById(int Id)
        {
            throw new NotImplementedException("Não implementado");
        }

        public Task<List<Pokemon>> GetAll()
        {
            throw new NotImplementedException("Não implementado");
        }
    }
}
