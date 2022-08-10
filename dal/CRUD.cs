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
                    IdAusuario = row.Field<int>("id_usuario"),
                    Nombre = row.Field<string>("nombre"),
                    Colonia = row.Field<string>("colonia"),
                    Numero = row.Field<int>("numero"),
                    Cp = row.Field<int>("cp"),
                    Nombre_centrotrabajo = row.Field<string>("nom_centroTrabajo"),
                    Telefono = row.Field<string>("telefono"),
                }).ToList();//Se añade la información a la Lista
            }
            return actualizacion;//Se retorna la Lista 
        }

        public List<Consulta> ListaConsulta(ref string mensaje, ref string mensajeC)//Metodo de la Lista Consulta
        {
            string comandoSql = "select * from consulta;", etiqueta = "Biblioteca3";//Variables y Utilidades
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Consulta> consulta = new List<Consulta>();//Creacion de una lista del tipo Actualizacion para trabajar

            dataSet = AC.LecturaSet(comandoSql, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);//Se llena el DataSet con los datos de la BD
            if (dataSet != null)//Si e DataSet tiene datos entonces
            {
                dataTable = dataSet.Tables[0];//Se crea un DataTable y se llena con la informacion del DataSet
                consulta = dataTable.AsEnumerable().Select(row => new Consulta//El datatable es como un numerable y se hace una seleccion, cada row será igual a un nuevo objeto de a clase seleccionada
                {//Por cada iterancia vamos a pasar los parámetros de mi objeto
                    IdUsuario = row.Field<int>("id_usuario"),
                    IdPublicacion = row.Field<int>("id_publicacion"),
                }).ToList();//Se añade la información a la Lista
            }
            return consulta;//Se retorna la Lista 
        }


            public List<publicaciones> ListaPublicaciones(ref string mensaje, ref string mensajeC)//Metodo de la Lista Actualización
        {
            string comandoSql = "select * from publicaciones;", etiqueta = "Biblioteca3";//Variables y Utilidades
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<publicaciones> actualizacion = new List<publicaciones>();//Creacion de una lista del tipo Actualizacion para trabajar

            dataSet = AC.LecturaSet(comandoSql, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);//Se llena el DataSet con los datos de la BD
            if (dataSet != null)//Si e DataSet tiene datos entonces
            {
                dataTable = dataSet.Tables[0];//Se crea un DataTable y se llena con la informacion del DataSet
                actualizacion = dataTable.AsEnumerable().Select(row => new publicaciones//El datatable es como un numerable y se hace una seleccion, cada row será igual a un nuevo objeto de a clase seleccionada
                {//Por cada iterancia vamos a pasar los parámetros de mi objeto
                    Idpublicacion = row.Field<int>("id_publicacion"),
                    titulo = row.Field<string>("titulo"),
                    num_ejemplar = row.Field<int>("num_ejemplar"),
                }).ToList();//Se añade la información a la Lista
            }
            return actualizacion;//Se retorna la Lista 
        }




        public bool InsertarUsuarios(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            bool respuesta = false;

            string instrccion = "INSERT INTO usuarios (nombre, colonia, numero, cp, nom_centroTrabajo, telefono) " +
                "values (@nombre, @colonia, @numero, @cp, @nom_centroTrabajo, @telefono)";
            SqlParameter[] info = new SqlParameter[]
            {
                
                new SqlParameter("@nombre",SqlDbType.VarChar, 40),
                new SqlParameter("@colonia",SqlDbType.VarChar, 20),
                new SqlParameter("@numero",SqlDbType.Int),
                new SqlParameter("@cp",SqlDbType.Int),
                new SqlParameter("@nom_centroTrabajo",SqlDbType.VarChar, 30),
                new SqlParameter("@telefono",SqlDbType.VarChar, 12),
            };
           
            info[0].Value = nuevoDatos[0];
            info[1].Value = nuevoDatos[1];
            info[2].Value = Convert.ToInt32(nuevoDatos[2]);
            info[3].Value = Convert.ToInt32(nuevoDatos[3]);
            info[4].Value = nuevoDatos[4];
            info[5].Value = nuevoDatos[5];
            respuesta = AC.BaseSegura(instrccion, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, info);
            return respuesta;
        }

        public bool InsertarPublicaciones(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            bool respuesta = false;

            string instrccion = "INSERT INTO publicaciones (titulo, num_ejemplar )" +
                "values (@titulo, @num_ejemplar )";
            SqlParameter[] info = new SqlParameter[]
            {
                new SqlParameter("@titulo",SqlDbType.VarChar, 40),
                new SqlParameter("@num_ejemplar",SqlDbType.Int),
       
            };
            info[0].Value = nuevoDatos[0];
            info[1].Value = Convert.ToInt32(nuevoDatos[1]);

            respuesta = AC.BaseSegura(instrccion, AC.ConnectionEstablecida(ref mensajeC), ref mensaje, info);
            return respuesta;
        }


        public bool ActualizarUsuarios(string[] nuevoDatos, ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "UPDATE usuarios " +
                "set  nombre = @nombre, colonia = @colonia, numero = @numero, cp = @cp, nom_centroTrabajo = @nom_centroTrabajo, telefono = @telefono " +
                " where id_usuario = @id_usuario;";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@nombre",SqlDbType.VarChar, 40),
                new SqlParameter("@colonia",SqlDbType.VarChar, 20),
                new SqlParameter("@numero",SqlDbType.Int),
                new SqlParameter("@cp",SqlDbType.Int),
                new SqlParameter("@nom_centroTrabajo",SqlDbType.VarChar, 30),
                new SqlParameter("@telefono",SqlDbType.VarChar, 12),
                new SqlParameter("@id_usuario",SqlDbType.Int),
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
                "set  titulo = @titulo, num_ejemplar = @num_ejemplar " +
                " where id_publicacion = @id_publicacion;";
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

            string instruccion = "DELETE from usuarios where id_usuario = @id_usuario";

            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@id_usuario",SqlDbType.Int)
            };

            evaluacion[0].Value = ID;

            respuesta = AC.BaseSegura(instruccion, AC.ConnectionEstablecida(ref MensajeC), ref Mensaje, evaluacion);

            return respuesta;
        }


        public bool EliminarPublicacion(ref string Mensaje, ref string MensajeC, int ID)
        {
            bool respuesta = false;

            string instruccion = "DELETE from publicaciones where id_publicacion = @id_publicacion";

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
