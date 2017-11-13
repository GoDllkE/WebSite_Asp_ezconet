using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication_ezconet.Models;

namespace WebApplication_ezconet.DAO
{
    public class SexoDAO
    {
        public void Adiciona(Sexo sexo)
        {
            using (var context = new ezconetContext())
            {
                context.Sexo.Add(sexo);
                context.SaveChanges();
            }
        }

        public void Remove(Sexo sexo)
        {
            using (var context = new ezconetContext())
            {
                context.Sexo.Remove(sexo);
                context.SaveChanges();
            }
        }

        public void Atualiza(Sexo sexo)
        {
            using (var context = new ezconetContext())
            {
                context.Update(sexo);
                context.SaveChanges();
            }
        }

        public IList<Sexo> Lista()
        {
            using (var context = new ezconetContext())
            {
                IList<Sexo> sexo = context.Sexo.ToList();
                return sexo;
            }
        }

        public Sexo BuscaPorId(int id)
        {
            using (var contexto = new ezconetContext())
            {
                return contexto.Sexo.Find(id);
            }
        }
    }
}