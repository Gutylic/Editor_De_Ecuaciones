<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homonimos.aspx.cs" Inherits="index.homonimos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Etiquetas Similares</title>
     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

    </style>

    <script type="text/javascript">

        function Confirmacion_Relacionar() {

            var seleccion = confirm("Usted desea relacionar etiquetas ?");

            if (seleccion)
                alert("Las etiquetas fueron relacionadas correctamente");
            else
                alert("No acepto relacionar las etiquetas");

            return seleccion;

        }

        function Confirmacion_Agregar() {

            var seleccion = confirm("Usted desea agregar etiquetas ?");

            if (seleccion)
                alert("La etiqueta fue correctamente agregada");
            else
                alert("No acepto agregar la etiqueta");

            return seleccion;

        }

        function Confirmacion_Modificar() {

            var seleccion = confirm("Usted desea modificar la etiqueta ?");

            if (seleccion)
                alert("La etiqueta fue correctamente modificada");
            else
                alert("No acepto modificar las etiquetas");

            return seleccion;

        }

        function Confirmacion_Borrar() {

            var seleccion = confirm("Usted desea borrar la etiqueta ?");

            if (seleccion)
                alert("La etiqueta fue borrada");
            else
                alert("La etiqueta no fué borrada");

            return seleccion;

        }

        function Confirmacion_Tabla() {

            var seleccion = confirm("Usted crear la tabla ?");

            if (seleccion)
                alert("La tabla fue correctamente creada esta en c:/XML");
            else
                alert("No acepto crear la tabla");

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
                    <a href="#" class="list-group-item active ">Trabajar con Etiquetas Similares</a>
                    <a href="buscar.aspx" class="list-group-item ">Buscador de Ejercicios</a>
                    <a href="respuesta.aspx" class="list-group-item ">Respuestas</a>
                    <a href="Video.aspx" class="list-group-item">Videos</a>
                     <a href="Cargar_Archivos.aspx" class="list-group-item">Cargar Archivos</a>
                     <a href="Cargar_Administradores.aspx" class="list-group-item">Cargar Administradores</a>
                </div>
            </div>

            <div class="col-md-9">

                <div class="thumbnail" style=" margin-top:60px" >
                    
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4 ><a href="#" style="color:#981E1E;">Etiqueta Buscada y Codificador</a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:45%"><asp:TextBox ID="Etiquetas_A_Decodificar" style="padding-left:3px" runat="server" Height="35px" Width="95%"></asp:TextBox></td>
                    <td style="width:10%"><asp:TextBox ID="Etiqueta_Decodificadora" style="text-align:center" runat="server" Height="35px" Width="95%"></asp:TextBox></td>
                    <td style="width:45%"><asp:DropDownList ID="DropDownList_Tipo_De_Etiqueta" runat="server" Height="35px" Width="95%">                        
                        <asp:ListItem Value="2">Temas</asp:ListItem>                        
                        <asp:ListItem Value="3">Colegios</asp:ListItem>
                        <asp:ListItem Value="4">Años</asp:ListItem>
                        <asp:ListItem Value="5">Profesores</asp:ListItem>
                        <asp:ListItem Value="6">Materias</asp:ListItem>                        
                        </asp:DropDownList> </td>

                </tr>
                       </table>
                        <hr />
                        <h4 ><a href="#" style="color:rgb(10, 28, 72);">Nueva Etiqueta y Codificador</a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:45%"><asp:TextBox ID="Etiqueta_Nueva" style="padding-left:3px" runat="server" Height="35px" Width="95%"></asp:TextBox></td>
                    <td style="width:10%"><asp:TextBox ID="Nueva_Etiqueta_Codificadora" style="text-align:center" runat="server" Width="95%" Height="35px"></asp:TextBox></td>
                    <td style="width:45%"><asp:DropDownList ID="Etiqueta_Predeterminada" runat="server" Height="35px" Width="95%">
                        <asp:ListItem Value="1">Cargar si esta vacia la superior </asp:ListItem>                        
                        <asp:ListItem Value="2">Temas</asp:ListItem>                        
                        <asp:ListItem Value="3">Colegios</asp:ListItem>
                        <asp:ListItem Value="4">Años</asp:ListItem>
                        <asp:ListItem Value="5">Profesores</asp:ListItem>
                        <asp:ListItem Value="6">Materias</asp:ListItem>                        
                        </asp:DropDownList> </td>
                </tr>
                          </table>   
                           <hr />
                       
                        <table style="width: 100%;">
                <tr>
                    <td style="width:100%"> <asp:Button ID="Cargar_Etiqueta" Width="100%" class="btn btn-danger" runat="server" Text="Cargar Etiquetas" OnClick="Cargar_Etiqueta_Click"/></td>
                   
                </tr>
                          </table>                  
                                      
                    </div>
                    
                </div>

                <div class="well">
                

                    <div class="row">
                    
                     <h4 style="margin-top:-10px" ><a href="#" style="color:rgb(10, 28, 72)">Botonera de Etiquetas  </a> </h4>  
                        
                    
                       

                            
                
                        <table style="width: 100%;">
                <tr>
                    <td style="width:25%"><asp:Button ID="Relacionar_Etiquetas" Width="90%" Height="35px" class="btn btn-primary" runat="server" Text="Relacionar Etiquetas" OnClick="Relacionar_Etiquetas_Click" OnClientClick="return Confirmacion_Relacionar();"/></td>
                    <td style="width:25%"><asp:Button ID="Agregar_Etiqueta" Width="90%" Height="35px" class="btn btn-success" runat="server" Text="Agregar Etiqueta" OnClick="Agregar_Etiqueta_Click"  OnClientClick="return Confirmacion_Agregar();"/></td>
                    <td style="width:25%"><asp:Button ID="Modificar_Etiqueta" Width="90%" Height="35px" class="btn btn-warning" runat="server" Text="Modificar Etiqueta" OnClick="Modificar_Etiqueta_Click"  OnClientClick="return Confirmacion_Modificar();"/></td>
                    <td style="width:25%"><asp:Button ID="Borrar_Etiqueta" Width="90%" Height="35px" class="btn btn-default" runat="server" Text="Borrar Etiqueta" OnClick="Borrar_Etiqueta_Click" OnClientClick="return Confirmacion_Borrar();"/></td>
                </tr>
            </table>
                   
             <hr />
<h4 style="margin-top:-10px" ><a href="#" style="color:#981E1E;">Guardar las Tablas en C:/XML  </a> </h4>  
                <table style="width: 100%;">
                <tr>
                    <td style="width:20%"><asp:Button ID="Guardar_Materia" Width="90%" Height="35px" class="btn btn-warning" runat="server" Text="Tabla Materia" OnClick="Guardar_Materia_Click" OnClientClick="return Confirmacion_Tabla();"/></td>
                    <td style="width:20%"><asp:Button ID="Guardar_Profesor" Width="90%" Height="35px" class="btn btn-default" runat="server" Text="Tabla Profesor" OnClick="Guardar_Profesor_Click" OnClientClick="return Confirmacion_Tabla();"/></td>
                    <td style="width:20%"><asp:Button ID="Guardar_Ano" Width="90%" Height="35px" class="btn btn-primary" runat="server" Text="Tabla Año" OnClick="Guardar_Ano_Click" OnClientClick="return Confirmacion_Tabla();"/></td>                                        
                    <td style="width:20%"><asp:Button ID="Guardar_Colegio" Width="90%" Height="35px" class="btn btn-danger" runat="server" Text="Tabla Colegio" OnClick="Guardar_Colegio_Click" OnClientClick="return Confirmacion_Tabla();"/></td>
                    <td style="width:20%"><asp:Button ID="Guardar_Tema" Width="90%" Height="35px" class="btn btn-success" runat="server" Text="Tabla Tema" OnClick="Guardar_Tema_Click" OnClientClick="return Confirmacion_Tabla();"/></td>
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