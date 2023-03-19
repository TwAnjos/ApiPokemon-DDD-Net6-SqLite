using Domain.InterfacesExternal;
using Entities.EntitiesExternal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryExternal
{
    public class RepositoryPokemon : IPokemon
    {
        //https://pokeapi.co/api/v2/pokemon/1
        private readonly string urlApi = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonDetails GetPokemonById(int idPokemon)
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
                        var pokemon = JsonConvert.DeserializeObject<PokemonDetails>(retorno.Result);
                        return pokemon;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PokemonDetails GetPokemonByName(string namePokemon)
        {
            throw new NotImplementedException();
        }

        public List<PokemonDetails> List10PokemonRandom()
        {
            //tem que disparar 10 vezes essa chamada?

            //var retorno = new List<PokemonDetails>();
            var retorno = new PokemonDetails();

            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.GetStringAsync(urlApi+"2");
                    resposta.Wait();

                    retorno = JsonConvert.DeserializeObject<PokemonDetails>(resposta.Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var list10Pokemons = new List<PokemonDetails>();
            list10Pokemons.Add(retorno);

            return list10Pokemons;
        }

        //creates...
        //https://youtu.be/wxUk5mVGL7Y?list=PLP8qOphXwRnIOzXzoviI5xwxcc4-dV_pd&t=815
    }
}
