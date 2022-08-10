using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dll;
using entidades;

namespace biblioteca
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Logica_negocios LN = null;
        List<Usuarios> lista_usuarios = new List<Usuarios>();
        List<publicaciones> lista_publicaciones = new List<publicaciones>();
        List<Consulta> Lista_Consulta = new List<Consulta>();
        string mensaje = "", mensajeC = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LN = new Logica_negocios(ConfigurationManager.ConnectionStrings["Biblioteca3"].ConnectionString);
                Session["negocioServer"] = LN;

                lista_usuarios = LN.L_Usuarios(ref mensaje, ref mensajeC);
                DropDownList1.Items.Add("");
                for (int i = 0; i < lista_usuarios.Count; i++)
                {
                    DropDownList1.Items.Add(lista_usuarios[i].IdAusuario.ToString());
                }

                lista_publicaciones = LN.L_publicaciones(ref mensaje, ref mensajeC);
                DropDownList2.Items.Add("");
                for (int i = 0; i < lista_publicaciones.Count; i++)
                {
                    DropDownList2.Items.Add(lista_publicaciones[i].Idpublicacion.ToString());
                }

                DropDownList3.Items.Add("");//ya que al momento de seleccionar en el dropdown nos van a estar apareciendo los nombres que tine esa tabla(lista)
                for (int i = 0; i < lista_usuarios.Count; i++)
                {
                    DropDownList3.Items.Add(lista_usuarios[i].Nombre);//esta linea de codigo determina que es lo que vamos a recuperar de la lista, en este caso el nombre
                }

            }
            else
            {
                LN = (Logica_negocios)Session["negocioServer"];
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] datos = new string[6];

            datos[0] = TextBox1.Text;
            datos[1] = TextBox2.Text;
            datos[2] = TextBox3.Text;
            datos[3] = TextBox4.Text;
            datos[4] = TextBox5.Text;
            datos[5] = TextBox6.Text;

            try
            {
                LN.insertar_usuarios(datos, ref mensaje, ref mensajeC);
                Label1.Text = "Se agregaron los datos con exito";
            }
            catch
            {
                Label1.Text = "Error al insertar los datos ";
            }
        }

      

        protected void actualizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DropDownList1.SelectedItem.Text);
            lista_usuarios = LN.L_Usuarios(ref mensaje, ref mensajeC);

           string[] datos = new string[6];

            datos[0] = TextBox1.Text;
            datos[1] = TextBox2.Text;
            datos[2] = TextBox3.Text;
            datos[3] = TextBox4.Text;
            datos[4] = TextBox5.Text;
            datos[5] = TextBox6.Text;

            LN.Act_Usu(datos, ref mensaje, ref mensajeC, Id);

            try
            {
                Label1.Text = "se actualizo";
            }
            catch
            {
                Label1.Text = "error checa tus datos";
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(DropDownList1.SelectedItem.Text);

                LN.Elim_Usuarios(ref mensaje, ref mensajeC, Id);

                Label1.Text = "se elimino";
            }
            catch
            {
                Label1.Text = "error checa tus datos";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = LN.tablaUsuarios(ref mensaje, ref mensajeC);
            GridView1.DataBind();
        }



        protected void Button5_Click(object sender, EventArgs e)
        {
            string[] datos = new string[2];

            datos[0] = TextBox7.Text;
            datos[1] = TextBox8.Text;
           

            try
            {
                LN.Insertar_publicaciones(datos, ref mensaje, ref mensajeC);
                Label2.Text = "Se agregaron los datos con exito";
            }
            catch
            {
                Label2.Text = "Error al insertar los datos ";
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DropDownList2.SelectedItem.Text);
            lista_publicaciones = LN.L_publicaciones(ref mensaje, ref mensajeC);

            string[] datos = new string[2];

            datos[0] = TextBox7.Text;
            datos[1] = TextBox8.Text;
            

            LN.Act_publicaciones(datos, ref mensaje, ref mensajeC, Id);

            try
            {
                Label2.Text = "se actualizo";
            }
            catch
            {
                Label2.Text = "error checa tus datos";
            }
        }

        

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(DropDownList2.SelectedItem.Text);

                LN.Elim_Publicaciones(ref mensaje, ref mensajeC, Id);

                Label2.Text = "se elimino";
            }
            catch
            {
                Label2.Text = "error checa tus datos";
            }
        }

        

        protected void Button8_Click(object sender, EventArgs e)
        {
            GridView2.DataSource = LN.tablaPublicaciones(ref mensaje, ref mensajeC);
            GridView2.DataBind();
        }


        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();//Limpiamos el lisbox

            string msj = "", msjc = "", consult = "", publi = "", numin = ""; //colocamos variables que vayamos a utilizar
            int users;// esta variable se coloco para que en "IdUsuario" no se tenga que poner el.ToString

            numin = DropDownList3.SelectedItem.Text;//El numin es la variable que utilizaremos para que lo que se seleccione en el drop se almacene en esta variable 

            //Lenamos las listas
            Lista_Consulta = LN.L_Consulta(ref msj, ref msjc);
            lista_publicaciones = LN.L_publicaciones(ref msj, ref msjc);
            lista_usuarios = LN.L_Usuarios(ref msj, ref msjc);

            //Aqui queremos que users sea igual a la lista de usuarios mientras que sea igual al nombre de lo que traigo en numin
            //es decir que lo que traiga de numin que es la seleccion del drop empate con lo que estoy buscando en la consulta 
            //para que en "FirstOrDefault" pueda traer o recuperar el ID del usuario 
            users = lista_usuarios.Where(x => x.Nombre == numin).FirstOrDefault().IdAusuario;//aqui se esta ocupando la tabla de usuarios

            //Label segunda consulta sera parecida a la primera con la diferencia de que lo voy a comparar con lo que traiga la variable "consult"
            //que en este caso esa variable trae el id del usuario
            //para que en "FirstOrDefault" pueda traer o recuperar el ID de la publicacion
            consult = Lista_Consulta.Where(x => x.IdUsuario == users).FirstOrDefault().IdPublicacion.ToString();//aqui se esta ocupando la tabla de consultas

            //Para terminar se va a hacer el mismo procedimiento que en las consultas anteriores pero ahora con la tabla de publicaciones 
            //en este caso lo vamos a comprarar con la variable consult que empare con el id de publicaciones 
            //para que en "FirstOrDefault" pueda traer o recuperar el titulo de la publicacion
            publi = lista_publicaciones.Where(x => x.Idpublicacion.ToString() == consult).FirstOrDefault().titulo;//aqui se esta ocupando la tabla de consultas

            //ultimo pasoen el listbox es lo que queremos mostrar 
            //en este caso queremos mostrar que consulta o que libro consulto el usuario 
            //por esa razon la variable public que es la que trae el titulo del libro es la que colocaremos
            ListBox1.Items.Add("Su consulta fue de = " + publi);

            //al momento de ejecutar el programa se podra mostrar lo que se necesita 
        }
    }
}