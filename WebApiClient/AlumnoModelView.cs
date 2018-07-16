using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class AlumnoModelView
    {
        public AlumnoModelView(int id, string nombre, string apellidos, string dni)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Dni = dni;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as AlumnoModelView;
            return model != null &&
                   Id == model.Id &&
                   Nombre == model.Nombre &&
                   Apellidos == model.Apellidos &&
                   Dni == model.Dni;
        }

        public override int GetHashCode()
        {
            var hashCode = -1407328918;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            return hashCode;
        }
    }
}
