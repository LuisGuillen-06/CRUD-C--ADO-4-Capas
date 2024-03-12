using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Entities;
using Common.Attributes;

namespace Domain.CRUD
{
    public class CPersona
    {
        Persona persona = new Persona();

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable();
            dt = persona.Mostrar();
            return dt;
        }

        public void Insertar(AttributesPeople obj)
        {
            persona.Insertar(obj);
        }

        public void Modificar(AttributesPeople obj)
        {
            persona.Modificar(obj);
        }

        public void Eliminar(AttributesPeople obj)
        {
            persona.Eliminar(obj);
        }

        public DataTable Buscar(string Buscar)
        {
            DataTable dt = new DataTable();
            dt = persona.Buscar(Buscar);
            return dt;
        }
    }
}
