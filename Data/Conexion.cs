using System;
using System.Collections.Generic;
using System.Data;
using SPEngineCSharp;

namespace Data
{
    public static class Conexion
    {
        //Clase que hace referencia a la conexión con la BD
        public static IDbConnection conn()
        {
            ConnectionDB.StringConnection =
                "Data source=DESKTOP-JKSHGI9\\SQLEXPRESS;Initial Catalog=ESCUELA;Integrated Security=true;";
            ConnectionDB.CType = ConnectionDB.ConnectionType.SqlServer;
            return ConnectionDB.Conection();
        }

        /*Para listar los datos de una consulta se necesita
         * 1 argumento, nombre del SP
         */

        //Tal vez necesito crear otro objeto y pasarle la referencia
        public static DataTable Listado(SPEngine sp)
        {
            sp.Execute(ConnectionDB.SPType.Select, sp);
            return sp.TableResponse;
        }

        public static Boolean EjecutarSP(SPEngine sp)
        {
            sp.Execute(ConnectionDB.SPType.InsertUpdateDelete, sp);
            return sp.Response;
        }
    }
}
