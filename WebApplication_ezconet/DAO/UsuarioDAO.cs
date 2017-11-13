using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication_ezconet.Models;

namespace WebApplication_ezconet.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var context = new ezconetContext())
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
            }
        }

        public void Remove(Usuario usuario)
        {
            using (var context = new ezconetContext())
            {
                context.Usuario.Remove(usuario);
                context.SaveChanges();
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var context = new ezconetContext())
            {
                context.Update(usuario);
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var context = new ezconetContext())
            {
                IList<Usuario> usuarios = context.Usuario.ToList();
                return usuarios;
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new ezconetContext())
            {
                return contexto.Usuario.Find(id);
            }
        }

        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new ezconetContext())
            {
                return contexto.Usuario.FirstOrDefault(u => u.Email == login && u.Senha == senha);
            }
        }

    }
}