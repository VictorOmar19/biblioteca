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
        string mensaje = "", mensajeC = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LN = new Logica_negocios(ConfigurationManager.ConnectionStrings["BDInventario"].ConnectionString);
                Session["negocioServer"] = LN;
               
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
            lista_categoria = LN.L_Categoria(ref mensaje, ref mensajeC);
            string[] datos = new string[1];

            datos[0] = TextBox2.Text;

            LN.Act_Usuarios(datos, ref mensaje, ref mensajeC, Id);

        }
    }
}