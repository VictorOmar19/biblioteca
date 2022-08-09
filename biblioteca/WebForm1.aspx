<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="biblioteca.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Tabla Usuarios<br />
        <br />
        <br />
        escribe un nombre
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        escribe tu colonia<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        escribe el numero
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        escribe tu codigo postal<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        escribe el nombre o centro de trabajo<br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        escribe tu telefono<br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
















        <br />
        <asp:Button ID="Button1" runat="server" Text="agregar datos" OnClick="Button1_Click" />
&nbsp;
        <asp:Button ID="actualizar" runat="server" Text="actualizar" OnClick="actualizar_Click" />
&nbsp;
        <asp:Button ID="Button3" runat="server" Text="eliminar" />
&nbsp;<asp:Button ID="Button4" runat="server" Text="Mostar Datos" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        Tabla Publicaciones<br />
        <br />
        Escribe el nombre del titulo<br />
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <br />
        escribe el numero de ejemplar
        <br />
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button5" runat="server" Text="agregar" />
&nbsp;
        <asp:Button ID="Button6" runat="server" Text="actualizar" />
&nbsp;
        <asp:Button ID="Button7" runat="server" Text="eliminar" />
&nbsp;
        <asp:Button ID="Button8" runat="server" Text="mostrar Datos" />
        <br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
















    </form>
    
</body>
</html>
