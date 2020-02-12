using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EjemploWpfApp.Entidades;
using EjemploWpfApp.DAL;

namespace EjemploWpfApp.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Personas.Add(persona) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Persona Buscar(int id)
        {
            Persona persona = new Persona();
            Contexto db = new Contexto();
            try
            {
                persona = db.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Eliminar = PersonasBLL.Buscar(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            List<Persona> Lista = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Personas.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
