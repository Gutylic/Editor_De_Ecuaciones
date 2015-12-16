<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="decodificador.aspx.cs" Inherits="index.decodificador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Decodificador de Etiquetas</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    
                <div class="container">
        
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    
                </button>
                <a class="navbar-brand" href="#">Editor De Ecuaciones</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-md-3"   style="margin-top: 80px";>
                <p class="lead">Seleccione su Opción</p>
                <div class="list-group">
                    <a href="index.aspx" class="list-group-item">Editor de Ecuaciones</a>
                    <a href="lector.aspx" class="list-group-item">Lector de Archivos</a>
                    <a href="etiquetas.aspx" class="list-group-item">Agregar Etiquetas al Ejercicio</a>
                    <a href="#" class="list-group-item active">Decodificador de Etiquetas</a>
                    <a href="homonimos.aspx" class="list-group-item ">Trabajar con Etiquetas Similares</a>
                    <a href="buscar.aspx" class="list-group-item ">Buscador de Ejercicios</a>
                    <a href="respuesta.aspx" class="list-group-item ">Respuestas</a>
                    <a href="Video.aspx" class="list-group-item">Videos</a>
                     <a href="Cargar_Archivos.aspx" class="list-group-item">Cargar Archivos</a>
                     <a href="Cargar_Administradores.aspx" class="list-group-item">Cargar Administradores</a>
                    <a href="Vaciar_Base.aspx" class="list-group-item" style="color:red; font-weight:bolder">Limpiar Base</a>
                </div>
            </div>

            <div class="col-md-9">

                <div class="thumbnail" style=" margin-top:60px" >
                    
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4 ><a href="#" style="color:#981E1E;">Etiqueta a Decodificar</a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:50%"><asp:TextBox ID="Etiquetas_A_Decodificar" runat="server" Height="35px" Width="95%"></asp:TextBox></td>
                    <td style="width:50%"><asp:Button ID="Boton_De_Decodificacion" class="btn btn-danger" runat="server" Text="Decodificar Etiqueta" Width="95%" Height="35px" OnClick="Boton_De_Decodificacion_Click"/></td>
                </tr>
                       </table>

                        
                             
                                         
                                      
                    </div>
                    
                </div>

                <div class="well">
                

                    <div class="row">
                    
                     <h4 style="margin-top:-10px" ><a href="#" style="color:rgb(10, 28, 72)">Etiquetas Decodificadas  </a> </h4>  
                        
                    
                       

                            
                
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_1" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_2" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_3" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                </tr>
            </table>
                    <hr style="margin-top:5px"/>
             
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_4" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_5" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_6" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>        
                  
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_7" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_8" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_9" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>
                   
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_10" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_11" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_12" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                        <hr style="margin-top:5px"/>
<table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_13" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_14" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_15" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                </tr>
            </table>
                    <hr style="margin-top:5px"/>
             
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_16" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_17" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_18" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>        
                  
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_19" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_20" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_21" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>
                   
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_22" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_23" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_24" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>

                        </div>
                    </div>
                </div>
            

    <!-- /.container -->

    <div class="container">

        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Martina Ivana Romero 2015</p>
                </div>
            </div>
        </footer>

    </div>
    <!-- /.container -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    </div>
    </form>
    
</body>

</html>
