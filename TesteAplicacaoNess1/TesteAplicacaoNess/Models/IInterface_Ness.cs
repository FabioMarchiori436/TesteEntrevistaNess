using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAplicacaoNess.Models
{
    public interface IInterface_Ness
    {
        IEnumerable<Usuario> BuscarDetalhesUsuarios();
        Usuario BuscarUsuarioPorID(int usuarioId);
        void AdicionarUsuario(Usuario usuario);
        void DeletaUsuarioPorID(int usuarioId);
        void AtualizaUsuario(Usuario usuario);
        Usuario Detalhes(int usuarioId);
    }
}
