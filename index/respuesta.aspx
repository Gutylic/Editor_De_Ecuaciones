<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="respuesta.aspx.cs" Inherits="index.respuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Respuestas</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

    </style>

    <script type="text/javascript">

        function validar_numerico(evento) {

            var tecla = document.all ? tecla = evento.which : tecla = evento.keyCode;
            return (tecla > 47 && tecla < 58);

        };

    </script>
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
                    <a href="#" class="list-group-item">Editor de Ecuaciones</a>
                    <a href="lector.aspx" class="list-group-item">Lector de Archivos</a>
                    <a href="etiquetas.aspx" class="list-group-item">Agregar Etiquetas al Ejercicio</a>
                    <a href="decodificador.aspx" class="list-group-item">Decodificador de Etiquetas</a>
                    <a href="homonimos.aspx" class="list-group-item ">Trabajar con Etiquetas Similares</a>
                    <a href="buscar.aspx" class="list-group-item ">Buscador de Ejercicios</a>
                    <a href="#" class="list-group-item active">Respuestas</a>
                    <a href="Video.aspx" class="list-group-item">Videos</a>
                     <a href="Cargar_Archivos.aspx" class="list-group-item">Cargar Archivos</a>
                     <a href="Cargar_Administradores.aspx" class="list-group-item">Cargar Administradores</a>
                </div>
            </div>

            <div class="col-md-9">

                <div class="thumbnail" style=" margin-top:60px" >
                    
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4><a href="#" style="color:#981E1E;">Buscar Respuesta</a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:50%"><asp:TextBox ID="TextBox_Respuesta" style="padding-left:3px" runat="server" Height="36px" Width="90%" onKeyPress="return validar_numerico(event)"></asp:TextBox></td>
                    <td style="width:50%"><asp:Button ID="Boton_Respuesta" runat="server" Text="Respuesta" Width="90%" CssClass="btn btn-warning" OnClick="Boton_Respuesta_Click" /></td>
                    
                </tr>
                       </table>

                           
               
                                      
                    </div>
                    
                </div>

                <div class="well">
                
                     <table style="width: 100%;">
                <tr>
                    <td>
                       
                        <asp:Image ID="Respuesta_Del_Ejercicio" runat="server" Visible="false" Width="807px" />
                        
                    </td>
                    
                    
                </tr>
                       </table>
                   

                    

                   


                
                    

                </div>

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
