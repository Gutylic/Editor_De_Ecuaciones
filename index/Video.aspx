<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="index.Video" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Videos</title>

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
                    <a href="decodificador.aspx" class="list-group-item">Decodificador de Etiquetas</a>
                    <a href="homonimos.aspx" class="list-group-item ">Trabajar con Etiquetas Similares</a>
                    <a href="buscar.aspx" class="list-group-item ">Buscador de Ejercicios</a>
                    <a href="respuesta.aspx" class="list-group-item">Respuestas</a>
                    <a href="#" class="list-group-item active">Videos</a>
                    <a href="Cargar_Archivos.aspx" class="list-group-item">Cargar Archivos</a>
                     <a href="Cargar_Administradores.aspx" class="list-group-item">Cargar Administradores</a>
                    <a href="Vaciar_Base.aspx" class="list-group-item" style="color:red; font-weight:bolder">Limpiar Base</a>
                </div>
            </div>
        
            <div class="col-md-9">

                <div class="thumbnail" style=" margin-top:60px" >
                   
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4><a href="#" style="color:#981E1E;">Buscar Videos</a>
                        </h4>
                        <asp:TextBox ID="TextBox_Videos" TextMode="MultiLine" style="padding-left:3px" runat="server" Height="200px" Width="100%"></asp:TextBox>
                   
               

                           <hr />

                        <asp:Button ID="Boton" Width="100%" CssClass="btn btn-warning" runat="server" Text="Videos" OnClick="Boton_Click" />
                                      
                    </div>

                       
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
