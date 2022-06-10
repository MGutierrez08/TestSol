<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="CapaPresentacionWebForm.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Lista de Empleados</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <h4>Presione el botón + para agregar un nuevo empleado</h4>
                <hr />

                <asp:Label ID="txtNombre" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <br />

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;<br />
                <asp:Label ID="txtApellidoPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<br />
                <asp:Label ID="txtApellidoMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                &nbsp;<br />
                <asp:Label ID="Label2" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <br />
                <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="141px"></asp:TextBox>
                &nbsp;&nbsp;<br />
                <asp:Label ID="Label3" runat="server" Text="Sueldo"></asp:Label>
                <br />
                <asp:TextBox ID="txtSueldo" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<br />
                <asp:Label runat="server" Text="Area"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="235px">
                </asp:DropDownList>
                &nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Button ID="btnAgregar" runat="server" OnClick="Button4_Click" Text="Agregar" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEditar" runat="server" Text="Editar" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button6" runat="server" Text="Button" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>

        </div>

        <br />

        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="1163px">
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
            </div>
        </div>

        <%--<div class="row">
            <div class="col-md-12">
                <table class="table table-bordered">
            <thead>
                <tr>
                    <td>Editar</td>
                    <td>IdEmpleado</td>
                    <td>Nombre del Empleado</td>
                    <td>IdArea</td>
                    <td>Area</td>
                    <td>Fecha de Nacimiento</td>
                    <td>Sueldo</td>
                    <td>Eliminar</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tbody>
        </table>
            </div>
        </div>--%>
    </div>
</asp:Content>
