﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Bienvenido: <asp:Label ID="lb_usuario" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/pajarito.jpg" Visible="False" />
    <asp:Panel Style="margin-top: 100px; margin-left:100px; margin-right:100px;" ID="Panel1" runat="server" Visible="False">
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:Button Style="float: right; margin-right: 300px" ID="btn_limpiar" runat="server" Text="Limpiar" CausesValidation="false" />
        <table id="tabla" class="auto-style1">
            <tr>
                <td class="auto-style4" colspan="2">
                    <h1>Formulario Inscripción</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Nombre:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nombre" ErrorMessage="Campo vacío"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Apellidos:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_apellidos" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_apellidos" ErrorMessage="Campo vacío"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">DNI:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_dni" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_letra" runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dni" ErrorMessage="Campo vacío"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_dni" ErrorMessage="Ha de introducir un dni correcto" ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Teléfono:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_telefono" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_telefono" ErrorMessage="Campo vacío"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_telefono" ErrorMessage="Escriba un telefono correcto" ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Comunidad Autónoma:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="lista_comunidades" runat="server">
                        <asp:ListItem>Andalucía</asp:ListItem>
                        <asp:ListItem>Aragón</asp:ListItem>
                        <asp:ListItem>Principado de Asturias</asp:ListItem>
                        <asp:ListItem>Baleares</asp:ListItem>
                        <asp:ListItem>Canarias</asp:ListItem>
                        <asp:ListItem>Cantabria</asp:ListItem>
                        <asp:ListItem>Castilla-La Mancha</asp:ListItem>
                        <asp:ListItem>Castilla y León</asp:ListItem>
                        <asp:ListItem>Cataluña</asp:ListItem>
                        <asp:ListItem>Extremadura</asp:ListItem>
                        <asp:ListItem>Galicia</asp:ListItem>
                        <asp:ListItem>La Rioja</asp:ListItem>
                        <asp:ListItem>Comunidad de Madrid</asp:ListItem>
                        <asp:ListItem>Región de Murcia</asp:ListItem>
                        <asp:ListItem>Comunidad Foral de Navarra</asp:ListItem>
                        <asp:ListItem>País Vasco</asp:ListItem>
                        <asp:ListItem>Comunidad Valenciana</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_email" ErrorMessage="Campo vacío"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email" ErrorMessage="Escriba un email adecuado" ValidationExpression="(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*|'(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*')@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])">

                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" Text="Submit" type="submit" />
                </td>
                <td class="auto-style2">
                    <asp:Image ID="Image2" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button class="botones_abajo" ID="btn_anterior" runat="server" Text="Anterior" CausesValidation="false" /><asp:Button class="botones_abajo" ID="btn_listado" runat="server" Text="Listado" CausesValidation="false" Style="height: 26px" /><asp:Button class="botones_abajo" ID="btn_siguiente" runat="server" Text="Siguiente" CausesValidation="false" />
        <br />
        <br />
        <asp:Button class="botones_abajo" ID="btn_anteriorbbdd" runat="server" Text="AnteriorBBDD" CausesValidation="false" />
        <asp:Button ID="btn_modificar" runat="server" Text="Modificar" />
        <asp:Button class="botones_abajo" ID="btn_siguientebbdd" runat="server" Text="SiguienteBBDD" CausesValidation="false" />
        <br />
        <br />
        <asp:Button class="boton_grid" ID="btn_gridview" runat="server" Text="Grivdiew" CausesValidation="false" />
        <asp:FileUpload class="botones_abajo" ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_upload" runat="server" Text="Subir foto" />
        <asp:Label class="botones_abajo" ID="LabelUpload" runat="server"></asp:Label>
        <asp:RegularExpressionValidator
            ID="FileUpLoadValidator" runat="server"
            ErrorMessage="Solo puedes subir archivos Jpeg y Gif"
            ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF)$"
            ControlToValidate="FileUpload1">  
        </asp:RegularExpressionValidator>
    </asp:Panel>
    <br />
    <asp:Button Style="margin-bottom:50px;" ID="btn_cerrar" runat="server" Text="Cerrar sesión" CausesValidation="false"/>
</asp:Content>

