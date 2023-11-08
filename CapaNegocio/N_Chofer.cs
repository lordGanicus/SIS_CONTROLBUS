using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio
{
   public class N_Chofer
    {
        CapaDatos.D_Chofer _Chofer = new CapaDatos.D_Chofer();

        public int Guardar(CapaEntidad.E_Chofer chofer)
        {
            int res = 0;
            if (chofer.ID == 0)
            {
                res = _Chofer.Insertar(chofer);
            }
            {
                res = _Chofer.Editar(chofer);
            }
            return res;
        }

        public int Eliminar(CapaEntidad.E_Chofer chofer)
        {
            return _Chofer.Eliminar(chofer);
        }

        public DataTable ListarDisponibles()
        {
            return _Chofer.Listar_Disponibles();
        }

        public DataTable Listar()
        {
            return _Chofer.Listar();
        }
        public E_Chofer BuscarPorNombre(string nombre)
        {
            // Lógica para buscar un chofer por su nombre de usuario
            // Debes acceder a la capa de datos para realizar la consulta a la base de datos
            D_Chofer dChofer = new D_Chofer();
            DataTable tabla = dChofer.BuscarPorNombre(nombre);

            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                int id = Convert.ToInt32(fila["ID"]);
                string nombreChofer = fila["NOMBRE"].ToString();
                string apellido = fila["APELLIDO"].ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(fila["FECHA_NACIMIENTO"]);
                string cedula = fila["CEDULA"].ToString();

                return new E_Chofer(id, nombreChofer, apellido, fechaNacimiento, cedula);
            }
            return null; // Retorna null si no se encuentra el chofer
        }
    }
}
