using Entities.Entities;
using System.Security.Claims;

namespace WebAPIs.Utils
{
    public static class UserUtils
    {
        /// <summary>
        /// Retorna o Id do Usuário logado no sistema.
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> RetornaIdUsuarioLogado(ClaimsPrincipal User)
        {
            try
            {
                if (User != null)
                {
                    var idUsuario = User.FindFirst("idUsuario");
                    return idUsuario.Value;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
