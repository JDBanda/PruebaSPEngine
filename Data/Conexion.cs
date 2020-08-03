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
        public static DataTable Listado(string n, List<Parameter> lst)
        {
            return SPEngine.ExecuteConsultSP(n, lst);
        }
    }
}
