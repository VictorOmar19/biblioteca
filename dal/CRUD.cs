using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entidades;

namespace dal
{
    public class CRUD
    {

        private Acceso_Datos AC = null;
        public CRUD(string connection)
        {
            AC = new Acceso_Datos(connection);
        }

        public List<Usuarios> ListaUsuarios(ref string mensaje, ref string mensajeC)//Metodo de la Lista Actualización
        {
            string comandoSql = "select * from usuarios;", etiqueta = "Biblioteca3";//Variables y Utilidades
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Usuarios> actualizacion = new List<Usuarios>();//Creacion de una lista del tipo Actualizacion para trabajar

            dataSet = AC.LecturaSet(comandoSql, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);//Se llena el DataSet con los datos de la BD
            if (dataSet != null)//Si e DataSet tiene datos entonces
            {
                dataTable = dataSet.Tables[0];//Se crea un DataTable y se llena con la informacion del DataSet
                actualizacion = dataTable.AsEnumerable().Select(row => new Usuarios//El datatable es como un numerable y se hace una seleccion, cada row será igual a un nuevo objeto de a clase seleccionada
                {//Por cada iterancia vamos a pasar los parámetros de mi objeto
                    IdAusuario = row.Field<int>("id_usuarios"),
                    Nombre = row.Field<string>("nombre"),
                     Colonia= row.Field<string>("colonia"),
                    Numero = row.Field<int>("numero"),
                    Cp = row.Field<int>("cp"),
                    Nombre_centrotrabajo = row.Field<string>("nom_centroTrabajo"),
                    Telefono = row.Field<string>("telefono"),
                }).ToList();//Se añade la información a la Lista
            }
            return actualizacion;//Se retorna la Lista 
        }


        

        public bool InsertarUsuarios(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            bool respuesta = false;

            string instrccion = "INSERT INTO usuarios(id_usuarios, nombre, colonia, numero, cp, nom_centroTrabajo, telefono)" +
                "values (@id_usuarios, @nombre, @colonia, @numero, @cp, @nom_centroTrabajo, @telefono)";
            SqlParameter[] info = new SqlParameter[]
            {
                new SqlParameter("@id_usuarios",SqlDbType.Int),
                new SqlParameter("@nombre",SqlDbType.VarChar, 40),
                new SqlParameter("@colonia",SqlDbType.VarChar, 20),
                new SqlParameter("@numero",SqlDbType.Int),
                new SqlParameter("@cp",SqlDbType.Int),
                new SqlParameter("@nom_centroTrabajo",SqlDbType.VarChar, 30),
                new SqlParameter("@colonia",SqlDbType.VarChar, 12),
            };
            info[0].Value = Convert.ToInt32(nuevoDatos[0]);
            info[1].Value = nuevoDatos[1];
            info[2].Value = nuevoDatos[2];
            info[3].Value = Convert.ToInt32(nuevoDatos[3]);
            info[4].Value = Convert.ToInt32(nuevoDatos[4]);
            info[5].Value = nuevoDatos[5];
            info[6].Value = nuevoDatos[6];;
            respuesta = AC.BaseSegura(instrccion, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, info);
            return respuesta;
        }

        public bool InsertarPublicaciones(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            bool respuesta = false;

            string instrccion = "INSERT INTO publicaciones(id_publicacion, titulo, num_ejemplar )" +
                "values (@id_publicacion, @titulo, @num_ejemplar )";
            SqlParameter[] info = new SqlParameter[]
            {
                new SqlParameter("@id_publicacion",SqlDbType.Int),
                new SqlParameter("@titulo",SqlDbType.VarChar, 40),
                new SqlParameter("@num_ejemplar",SqlDbType.Int),
       
            };
            info[0].Value = Convert.ToInt32(nuevoDatos[0]);
            info[1].Value = nuevoDatos[1];
            info[2].Value = Convert.ToInt32(nuevoDatos[2]);

            respuesta = AC.BaseSegura(instrccion, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, info);
            return respuesta;
        }


        public bool ActualizarUsuarios(string[] nuevoDatos, ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "UPDATE Usuarios " +
                "set  id_usuarios = @id_usuarios, nombre = @nombre, colonia = @colonia, numero = @numero, cp = @cp, nom_centroTrabajo = @nombre_centroTrabajo, telefono = @telefono " +
                " where id_usuarios = @id_usuarios;";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@nombre",SqlDbType.VarChar, 40),
                new SqlParameter("@colonia",SqlDbType.VarChar, 20),
                new SqlParameter("@numero",SqlDbType.Int),
                new SqlParameter("@cp",SqlDbType.Int),
                new SqlParameter("@nom_centroTrabajo",SqlDbType.VarChar, 30),
                new SqlParameter("@colonia",SqlDbType.VarChar, 12),
                new SqlParameter("@id_usuarios",SqlDbType.Int),
            };

            evaluacion[0].Value = nuevoDatos[0];
            evaluacion[1].Value = nuevoDatos[1];
            evaluacion[2].Value = nuevoDatos[2];
            evaluacion[3].Value = nuevoDatos[3];
            evaluacion[4].Value = nuevoDatos[4];
            evaluacion[5].Value = nuevoDatos[5];
            evaluacion[6].Value = ID;

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref MensajeC), ref Mensaje, evaluacion);

            return respuesta;
        }

        public bool Actualizarpublicaciones(string[] nuevoDatos, ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "UPDATE publicaciones " +
                "set  id_publicaciones = @id_publicaciones, titulo = @titulo, num_ejemplar = @num_ejemplar " +
                " where id_usuarios = @id_usuarios;";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@titulo",SqlDbType.VarChar, 40),
                new SqlParameter("@num_ejemplar",SqlDbType.Int),
                new SqlParameter("@id_publicacion",SqlDbType.Int),
            };

            evaluacion[0].Value = nuevoDatos[0];
            evaluacion[1].Value = nuevoDatos[1];        
            evaluacion[2].Value = ID;

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref MensajeC), ref Mensaje, evaluacion);

            return respuesta;
        }


        public bool EliminarUsuarios(ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "DELETE from usuarios where id_usuarios = @id_usuarios";

            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@id_usuarios",SqlDbType.Int)
            };

            evaluacion[0].Value = ID;

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref MensajeC), ref Mensaje, evaluacion);

            return respuesta;
        }


        public bool EliminarPublicacion(ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "DELETE from publicacion where id_publicacion = @id_publicacion";

            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@id_publicacion",SqlDbType.Int)
            };

            evaluacion[0].Value = ID;

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref MensajeC), ref Mensaje, evaluacion);

            return respuesta;
        }

    }
}
