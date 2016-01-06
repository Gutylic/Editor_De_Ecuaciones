<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargar_Administradores.aspx.cs" Inherits="index.Cargar_Administradores" %>

<!DOCTYPE html>

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

        function validar_numerico(evento) {

            var tecla = document.all ? tecla = evento.which : tecla = evento.keyCode;
            return (tecla > 47 && tecla < 58);

        };

        function Insertar_Administrador() {

            var seleccion = confirm("Usted quiere insertar un administrador ?");

            if (seleccion)
                alert("El administrador fué insertado");
            else
                alert("No acepto la opción");

            return seleccion;

        }

        function Actualizar_Administrador() {

            var seleccion = confirm("Usted quiere actualizar un administrador ?");

            if (seleccion)
                alert("El administrador fué actualizado");
            else
                alert("No acepto la opción");

            return seleccion;

        }

        function Borrar_Administrador() {

            var seleccion = confirm("Usted quiere borrar un administrador ?");

            if (seleccion)
                alert("El administrador fué borrado");
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
                    <a href="#" class="list-group-item active">Cargar Administradores</a>
                    <a href="Vaciar_Base.aspx" class="list-group-item" style="color:red; font-weight:bolder">Limpiar Base</a>
                </div>
            </div>

            <div class="col-md-9">

                <div class="thumbnail" style=" margin-top:60px" >
                    
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4 ><a href="#" style="color:#981E1E;">Cargar Administradores:</a>
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
               <h4 style="margin-top:-10px"><a href="#" style="color:rgb(10, 28, 72)">Password</a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:100%">
                        <asp:TextBox ID="TextBox_Insertar_Password" runat="server" style="padding-left:3px" Height="36px" Width="100%"></asp:TextBox>

                    </td>
                    
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>        
                        
                    <h4 style="margin-top:-10px"><a href="#" style="color:rgb(10, 28, 72)">Empresa </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:100%">
                         <asp:TextBox ID="TextBox_Insertar_Empresa" MaxLength="20" runat="server" style="padding-left:3px" Height="36px" Width="100%"></asp:TextBox>
                    </td>
                    </tr>
                    </table>
                  
                    <hr style="margin-top:5px"/>           
                        
                     
                      
                                      
                    </div>
                    
                </div>

                <div class="well">
                

                    <div class="row">
                        <div class="col-xs-4">
                        <asp:Button ID="Boton_Cargar" CssClass="btn btn-danger" runat="server" Text="Insertar Administrador" Width="100%" OnClientClick="return Cargar_Administrador();" OnClick="Boton_Cargar_Click"  />
                    </div>
                    <div class="col-xs-4">
                        <asp:Button ID="Boton_Actualizar" CssClass="btn btn-warning" runat="server" Text="Actualizar Administrador" OnClientClick="return Actualizar_Administrador();" Width="100%" OnClick="Boton_Actualizar_Click"  />
                    </div>
                    <div class="col-xs-4">
                        <asp:Button ID="Boton_Borrar" CssClass="btn btn-primary" runat="server" Text="Borrar Administrador" OnClientClick="return Borrar_Administrador();" Width="100%" OnClick="Boton_Borrar_Click"  />
                    </div>
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
