<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index1.aspx.cs" Inherits="index.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Editor De Ecuaciones</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

    </style>

    <script type="text/javascript">

        function Confirmacion() {

            var seleccion = confirm("Usted desea crear este ejercicio ?");

            if (seleccion)
                alert("El ejercicio fue creado correctamente");
            else
                alert("No acepto crear el ejercicio");
                        
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
                    <a href="#" class="list-group-item active">Editor de Ecuaciones</a>
                    <a href="lector.aspx" class="list-group-item">Lector de Archivos</a>
                    <a href="etiquetas.aspx" class="list-group-item">Agregar Etiquetas al Ejercicio</a>
                    <a href="decodificador.aspx" class="list-group-item">Decodificador de Etiquetas</a>
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
                        <h4 ><a href="#" style="color:#981E1E;">Tema por Homonimo  </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Tema1" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Tema2" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Tema3" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                </tr>
                       </table>

                            <hr style="margin-top:5px"/>
                <h4 style="margin-top:-10px" ><a href="#" style="color:rgb(10, 28, 72)">Tema por Sinonimo  </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Tema1_S" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Tema2_S" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Tema3_S" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                </tr>
            </table>
                    <hr style="margin-top:5px"/>
               <h4 style="margin-top:-10px"><a href="#" style="color:rgb(10, 28, 72)">Materia por Sinonimo  </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Materia1" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Materia2" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Materia3" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>        
                        
                    <h4 style="margin-top:-10px"><a href="#" style="color:#981E1E;">Colegio por Homonimo  </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Colegio1" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Colegio2" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Colegio3" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>
                        
                     <h4 style="margin-top:-10px"><a href="#" style="color:#981E1E">Año por Homonimo  </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Ano1" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Ano2" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Ano3" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                    <hr style="margin-top:5px"/>           
                        
                      <h4 style="margin-top:-10px"><a href="#" style="color:rgb(10, 28, 72)">Profesor por Sinonimo  </a>
                        </h4>
                        <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Profesor1" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Profesor2" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    <td style="width:33%"><asp:TextBox ID="TextBox_Profesor3" runat="server" Height="35px" Width="90%"></asp:TextBox></td>
                    </tr>
                    </table>
                      
                                      
                    </div>
                    
                </div>

                <div class="well">
                

                    <div class="row">

                     <h4 style="margin-top:-10px" ><a href="#" style="color:rgb(10, 28, 72)">Etiquetas Creadas  </a>  </h4> 
                        
                    <table style="width: 100%;">
                            <tr>
                                <td style="width: 20%; text-align:center"><h4 ><a href="#" style="color:#981E1E;">Tema</a></h4></td>
                                <td style="width: 20%; text-align:center"><h4 ><a href="#" style="color:rgb(10, 28, 72;">Materia</a></h4></td>
                                <td style="width: 20%; text-align:center"><h4 ><a href="#" style="color:#981E1E;">Colegio</a></h4></td>
                                <td style="width: 20%; text-align:center"><h4 ><a href="#" style="color:rgb(10, 28, 72;">Año</a></h4></td>
                                <td style="width: 20%; text-align:center"><h4 ><a href="#" style="color:#981E1E;">Profesor</a></h4></td>
                                
                            </tr>
                            <tr>
                                <td style="width:20%; text-align:center"><asp:TextBox ID="TextBox_Tema" runat="server" Height="35px" Width="90%" ReadOnly="true" style="font-size:11px"></asp:TextBox></td>
                                <td style="width:20%; text-align:center"><asp:TextBox ID="TextBox_Materia" runat="server" Height="35px" Width="90%" ReadOnly="true" style="font-size:11px"></asp:TextBox></td>
                                <td style="width:20%; text-align:center"><asp:TextBox ID="TextBox_Colegio" runat="server" Height="35px" Width="90%" ReadOnly="true" style="font-size:11px"></asp:TextBox></td>
                                <td style="width:20%; text-align:center"><asp:TextBox ID="TextBox_Ano" runat="server" Height="35px" Width="90%" ReadOnly="true" style="font-size:11px"></asp:TextBox></td>
                                <td style="width:20%; text-align:center"><asp:TextBox ID="TextBox_Profesor" runat="server" Height="35px" Width="90%" ReadOnly="true" style="font-size:11px"></asp:TextBox></td>
                                
                            </tr>
                          
                    </table>
                        <hr>
                         <h4><a href="#" style="color:#981E1E;">Archivo Creado:</a><asp:Label ID="Nombre_Del_Archivo" runat="server" Text=""></asp:Label></h4>
                  
                    </div>

                    

                    <div class="row">
                        <div class="col-md-12">
                            


                        </div>
                    </div>
                    <hr style="margin-top:0px">


                    <asp:Button ID="Anterior" class="btn btn-primary" runat="server" Text="<< Anterior" OnClick="Anterior_Click"  />
                    <asp:Button ID="Cargar_Ejercicio" class="btn btn-danger" runat="server" Text="Cargar Ejercicio" OnClick="Cargar_Ejercicio_Click" OnClientClick ="return Confirmacion();"  />
                    
                    

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
