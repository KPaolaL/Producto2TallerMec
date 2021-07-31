<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="TallerMecanico.Consultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #66FFFF;
        }

         body { background-color: lavender; }
        
        
        .auto-style2 {}
        .auto-style3 {
            background-color: #FFCCFF;
        }
        .auto-style4 {}
        
        
        .auto-style5 {}
        .auto-style6 {}
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <div class="page-wrapper bg-gra-02 p-t-130 p-b-100 font-poppins">
        <div>
             <center> <h1>Consultas taller mecanico</h1> 
            <div class="col-2">
            <div class="input-group">
                 <h2>Lista de autos del clientes</h2>
                     <asp:GridView ID="GridView1" runat="server" CssClass="auto-style1" style="font-size: medium; color: #000000; background-color: #CCFFFF">
                    </asp:GridView>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Visualiza los clientes" Width="223px" />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button2" runat="server" CssClass="auto-style4" Text="Autos del cliente" Width="157px" />
                   </div>
                </div>
                
                 <div class="col-2">
            <div class="input-group">
                  <h2>Historial de revisiones del auto con Mecanico que se encargo</h2>

                </div>
                </div>
                
                 <asp:GridView ID="GridView2" runat="server" CssClass="auto-style3">
                 </asp:GridView>
                
            <br />
                    

           
                 <asp:Button ID="Button3" runat="server" CssClass="auto-style2" Text="Historial de revisiones del auto" Width="312px" />
                 <br />
                 <br />
                    

           
                 <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style5" Height="123px" Width="395px"></asp:ListBox>
&nbsp;<br />
                 <asp:Button ID="Button4" runat="server" CssClass="auto-style6" Text="Detalles de reparacion" Width="237px" />
            <br />
                    

                 </center>  
        </div> 

          </div>


    </form>
     
</body>
</html>
