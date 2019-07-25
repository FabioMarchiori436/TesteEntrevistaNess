using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAplicacaoNess.Models
{
    public class UsuarioRepositorio_Ness : IInterface_Ness  //obs
    {
        
        EntitiesUsuario db = new EntitiesUsuario();

        public UsuarioRepositorio_Ness()
        {
            this.db = new EntitiesUsuario();
        }

        public UsuarioRepositorio_Ness(EntitiesUsuario ctx) // obs
        {
            this.db = ctx;  
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            try
            {
                var novoUsuario = db.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault(); // obs
                novoUsuario.Nome = usuario.Nome;
                novoUsuario.Cpf = usuario.Cpf;
                novoUsuario.Telefone = usuario.Telefone;
                db.SaveChanges();
                novoUsuario = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        public void DeletaUsuarioPorID(int Param_usuarioId)
        {
            try
            {
                Usuario _usuario = db.Usuarios.SingleOrDefault(x => x.Id == Param_usuarioId);// obs
                db.Usuarios.Remove(_usuario);
                db.SaveChanges();
                _usuario = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        public Usuario Detalhes(int param_usuarioId)
        {
            try
            {
                dynamic obj = new Usuario();
                obj = db.Usuarios.SingleOrDefault(s => s.Id == param_usuarioId);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        public IEnumerable<Usuario> BuscarDetalhesUsuarios()
        {
            try
            {
                return db.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        public Usuario BuscarUsuarioPorID(int param_usuarioId)
        {
            try
            {
                return db.Usuarios.SingleOrDefault(x => x.Id == param_usuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }
    }
}