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

            }
            else
            {
                LN = (Logica_negocios)Session["negocioServer"];
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] datos = new string[4];

            datos[0] = TextBox1.Text;
            datos[1] = TextBox2.Text;
            datos[2] = TextBox3.Text;
            datos[3] = TextBox4.Text;
            datos[4] = TextBox4.Text;
            datos[5] = TextBox4.Text;

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

           string[] datos = new string[1];

            datos[0] = TextBox1.Text;
            datos[1] = TextBox1.Text;
            datos[2] = TextBox1.Text;
            datos[3] = TextBox1.Text;
            datos[4] = TextBox1.Text;
            datos[5] = TextBox1.Text;

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
    }
}