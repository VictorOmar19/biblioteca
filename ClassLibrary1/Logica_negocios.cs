using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using entidades;
using System.Data;
using System.Data.SqlClient;


namespace dll
{
    public class Logica_negocios
    {
        private Acceso_Datos AC = null;

        private CRUD OPC = null;
        public Logica_negocios(string connection)
        {
            AC = new Acceso_Datos(connection);
            OPC = new CRUD(connection);
        }
        public string insertar_usuarios(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            string resp = "";
            if (!OPC.InsertarUsuarios(nuevoDatos, ref mensaje, ref mensajeC))
            {
                resp = "nu";

            }
            else
            {
                resp = "funciona";
            }
            return resp;
        }
        public string Act_Usuarios(string[] nuevoDatos, ref string mensaje, ref string mensajeC, int ID)
        {
            string resp = "";
            if (!OPC.ActualizarUsuarios(nuevoDatos, ref mensaje, ref mensajeC, ID))
            {
                resp = "nu";

            }
            else
            {
                resp = "funciona";
            }
            return resp;
        }
        public string insertar_publicaciones(string[] nuevoDatos, ref string mensaje, ref string mensajeC)
        {
            string resp = "";
            if (!OPC.InsertarPublicaciones(nuevoDatos, ref mensaje, ref mensajeC))
            {
                resp = "nu";

            }
            else
            {
                resp = "funciona";
            }
            return resp;
        }

        public string Act_publicaciones(string[] nuevoDatos, ref string mensaje, ref string mensajeC, int ID)
        {
            string resp = "";
            if (!OPC.Actualizarpublicaciones(nuevoDatos, ref mensaje, ref mensajeC, ID))
            {
                resp = "nu";

            }
            else
            {
                resp = "funciona";
            }
            return resp;
        }
        public string Elim_Usuarios(ref string Mensaje, ref string MensajeC, int ID)
        {
            string resp = "";
            if (!OPC.EliminarUsuarios(ref Mensaje, ref MensajeC, ID))
            {
                resp = "nu";

            }
            else
            {
                resp = "Viejo sabroso:3";
            }
            return resp;
        }

        public string Elim_Publicaciones(ref string Mensaje, ref string MensajeC, int ID)
        {
            string resp = "";
            if (!OPC.EliminarPublicacion(ref Mensaje, ref MensajeC, ID))
            {
                resp = "nu";

            }
            else
            {
                resp = "Viejo sabroso:3";
            }
            return resp;
        }
    }
}
