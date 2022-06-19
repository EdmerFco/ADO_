using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public interface ICRUDEstatus
    {
        List<Estatus> Consultar();
        Estatus Consultar(int id);
        int Agregar(Estatus estatus);
        void Actulizar(Estatus estatus);
        void Eliminar (Estatus estatus);
    }
}
