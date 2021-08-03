<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroAuto.aspx.cs" Inherits="TallerMecanico.RegistroAuto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet"  media="all" />
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>
    <link href="vendor/select2/select2.min.css" rel="stylesheet"  media="all"/>
    <link href="vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all" />
    <link href="css/main.css" rel="stylesheet"  media="all" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="page-wrapper bg-gra-02 p-t-130 p-b-100 font-poppins">
        <div class="wrapper wrapper--w680">

            <div class="card card-4">
                <div class="card-body">
                     <ul class="pager">
                         <a href="RegistroCliente.aspx">Registrar clientes</a>
                         <a href="Consultas.aspx">Realizar consultas </a>
        <a href="Consultas.aspx">Realizar consultas </a>
        </ul>
            <h1>Registro</h1>
           <h2 class="title">Control de reparaciones de automóviles</h2>
             <h3>Informacion de auto</h3>
                              <div class="row row-space">

                                  <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Marca de vehiculo: </label>
                                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>  
                                  
                                        </div>
                                   </div>
                                  <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Id cliente: </label>
                                        <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>  
                                  
                                        </div>
                                   </div>
                                   <div class="col-2">
                                  <div class="input-group">
                                        <label class="label">Modelo</label>
                                        <asp:TextBox ID="TextBox1"   runat="server"  BorderStyle="Solid"></asp:TextBox>  
                                   </div>
                                   </div>
                                  <div class="col-2">
                                  <div class="input-group">
                                        <label class="label">Año</label>
                                        <asp:TextBox ID="TextBox2"   runat="server"  BorderStyle="Solid"></asp:TextBox>  
                                   </div>
                                   </div>
                                  <div class="col-2">
                                  <div class="input-group">
                                        <label class="label">Placas</label>
                                        <asp:TextBox ID="TextBox3"   runat="server"  BorderStyle="Solid"></asp:TextBox>  
                                   </div>
                                   </div>
                                  <div class="col-2">
                                  <div class="input-group">
                                        <label class="label">Color</label>
                                        <asp:TextBox ID="TextBox4"   runat="server"  BorderStyle="Solid"></asp:TextBox>  
                                   </div>
                                   </div>
                                  <div class="col-2">
                                  <div class="input-group">
                                        <label class="label">Fecha de ingreso:  </label>
                                        <i class="zmdi zmdi-calendar-note input-icon js-btn-calendar"></i>   
                                        <asp:TextBox ID="TextBox5"   runat="server" ></asp:TextBox>  
                                   </div>
                                   </div>
                                 
                                   <div class="col-2">
                                   <div class="input-group">
                                        <label class="label">Describe el problema: </label>
                                        <asp:TextBox ID="TextBox6"  runat="server" BorderColor="Black" BorderStyle="Solid" Height="37px" Width="220px"></asp:TextBox>
                                     </div>
                                    </div>
                          </div>
                      </div>
                     </div>
                 </div>
                     </div>
                 </div>
 
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/datepicker/moment.min.js"></script>
    <script src="vendor/datepicker/daterangepicker.js"></script>
    <script src="js/global.js"></script>
     
    </form>
</body>
</html>
