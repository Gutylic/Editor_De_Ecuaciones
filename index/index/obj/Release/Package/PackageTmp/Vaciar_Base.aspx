<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vaciar_Base.aspx.cs" Inherits="index.Vaciar_Base" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Cargar Administradores</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

    </style>

    <script type="text/javascript">

        

        function Borrar_Administrador() {

            var seleccion = confirm("Usted quiere borrar los datos?");

            if (seleccion)
                alert("los datos fueron borrados");
            else
                alert("No acepto la opción");

            return seleccion;

        }

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
                    <a href="index.aspx" class="list-group-item">Editor de Ecuaciones</a>
                    <a href="lector.aspx" class="list-group-item">Lector de Archivos</a>
                    <a href="etiquetas.aspx" class="list-group-item">Agregar Etiquetas al Ejercicio</a>
                    <a href="decodificador.aspx" class="list-group-item">Decodificador de Etiquetas</a>
                    <a href="homonimos.aspx" class="list-group-item ">Trabajar con Etiquetas Similares</a>
                    <a href="buscar.aspx" class="list-group-item ">Buscador de Ejercicios</a>
                    <a href="respuesta.aspx" class="list-group-item ">Respuestas</a>
                    <a href="Video.aspx" class="list-group-item">Videos</a>                    
                    <a href="Cargar_Archivos.aspx" class="list-group-item">Cargar Archivos</a>
                    <a href="Cargar_Administradores.aspx" class="list-group-item">Cargar Administradores</a>
                    <a href="#" class="list-group-item active" style="color:silver; font-weight:bolder">Limpiar Base</a>
                </div>
            </div>

            <div class="col-md-9">

                <div class="thumbnail" style=" margin-top:60px" >
                    
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4 ><a href="#" style="color:#981E1E;">Limpiar la base de datos:</a>
                        </h4>
                       

                            <hr style="margin-top:5px"/>
                <h4 style="margin-top:-10px" ><a href="#" style="color:rgb(10, 28, 72)">Administrador </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                   
                    <td style="width:100%">
                       <asp:TextBox ID="TextBox_Insertar_Administrador" style="padding-left:3px" Height="36px" Width="100%" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                    
                </tr>
            </table>
                    <hr style="margin-top:5px"/>
               <h4 style="margin-top:-10px"><a href="#" style="color:rgb(10, 28, 72)">Clave</a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:100%">
                        <asp:TextBox ID="TextBox_Insertar_Password" runat="server" style="padding-left:3px" Height="36px" Width="100%"></asp:TextBox>

                    </td>
                    
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>        
                        
                    
                        <table style="width: 100%;">
                <tr>
                    
                    </tr>
                    </table>
                  
                    <hr style="margin-top:5px"/>           
                        
                     
                      
                                      
                    </div>
                    
                </div>

                <div class="well">
                

                    <div class="row">
                        <div class="col-xs-3">
                       <asp:Button ID="Boton_Borrar_Anos" CssClass="btn btn-danger" runat="server" Text="Años" Width="100%" OnClientClick="return Borrar_Administrador();" OnClick="Boton_Borrar_Anos_Click"  />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="Boton_Borrar_Temas" CssClass="btn btn-danger" runat="server" Text="Temas" OnClientClick="return Borrar_Administrador();" Width="100%" OnClick="Boton_Borrar_Temas_Click"   />
                    </div>
                    <div class="col-xs-3">
                       <asp:Button ID="Boton_Borror_Colegios" CssClass="btn btn-danger" runat="server" Text="Colegios" OnClientClick="return Borrar_Administrador();" Width="100%" OnClick="Boton_Borror_Colegios_Click"  />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="Boton_Borrar_Profesores" CssClass="btn btn-danger" runat="server" Text="Profesores" Width="100%" OnClientClick="return BOrrar_Administrador();" OnClick="Boton_Borrar_Profesores_Click"   />
                    </div>
                    </div>

                    
                    

                </div>
                <div class="well">
                

                    <div class="row">
                        <div class="col-xs-3">
                        <asp:Button ID="Boton_Borrar_Materias" CssClass="btn btn-danger" runat="server" Text="Materias" Width="100%" OnClientClick="return Borrar_Administrador();" OnClick="Boton_Borrar_Materias_Click"   />
                    </div>
                    <div class="col-xs-3">
                        <asp:Button ID="Boton_Borrar_Administradores" CssClass="btn btn-danger" runat="server" Text="Administradores" OnClientClick="return Borrar_Administrador();" Width="100%" OnClick="Boton_Borrar_Administradores_Click"  />
                    </div>
                    <div class="col-xs-3">
                       <asp:Button ID="Boton_Borrar_Empresas" CssClass="btn btn-danger" runat="server" Text="Empresas" OnClientClick="return Borrar_Administrador();" Width="100%" OnClick="Boton_Borrar_Empresas_Click"  />
                    </div>
                    
                    <div class="col-xs-3">
                       <asp:Button ID="Boton_Borrar_Ejercicios" CssClass="btn btn-danger" runat="server" Text="Ejercicios" OnClientClick="return Borrar_Administrador();" Width="100%" OnClick="Boton_Borrar_Ejercicios_Click"  />
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
