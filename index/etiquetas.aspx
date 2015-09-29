<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="etiquetas.aspx.cs" Inherits="index.etiquetas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar Etiquetas</title>
     <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

    </style>
     <script type="text/javascript">

        

             function Permitir() {

                 var seleccion = document.getElementById("Subir_Archivo").value;
            
                 if (seleccion.length < 1)
                     seleccion = false;
                 else
                     seleccion = true;
                        
                 return seleccion;

             }

    


         function Confirmacion() {

             var seleccion = confirm("Usted desea crear estas nuevas etiquetas?");

             if (seleccion)
                 alert("Usted ha creado etiquetas nuevas correctamente");
             else
                 alert("No acepto crear etiquetas nuevas al ejercicio");

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
                <a class="navbar-brand" href="#">Insertar Etiquetas</a>
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
                    <a href="index.aspx" class="list-group-item ">Editor de Ecuaciones</a>
                    <a href="lector.aspx" class="list-group-item">Lector de Archivos</a>
                    <a href="etiquetas.aspx" class="list-group-item active">Agregar Etiquetas al Ejercicio</a>
                    <a href="decodificador.aspx" class="list-group-item">Decodificador de Etiquetas</a>
                    <a href="homonimos.aspx" class="list-group-item ">Trabajar con Etiquetas Similares</a>
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
                     <table style="width: 100%;">
                <tr>
                    <td style="width:33%"><asp:FileUpload ID="Subir_Archivo" runat="server"  Width="90%" /></td> 
                    
                    <td style="width:33%"><asp:DropDownList ID="DropDownList_Tipo_De_Etiqueta" runat="server" Height="35px" Width="90%">                        
                        <asp:ListItem Value="2">Temas</asp:ListItem>                        
                        <asp:ListItem Value="3">Colegios</asp:ListItem>
                        <asp:ListItem Value="4">Años</asp:ListItem>
                        <asp:ListItem Value="5">Profesores</asp:ListItem>
                        <asp:ListItem Value="6">Materias</asp:ListItem>                        
                        </asp:DropDownList> 
                    </td>
                   <td style="width:33%"><asp:Button ID="Cargar_Ejercicio" Height="35px" Width="90%" class="btn btn-primary" Text="Cargar Ejercicio" runat="server" OnClick="Cargar_Ejercicio_Click" OnClientClick="return Permitir();"/></td>
                </tr>
                       </table>

                            <hr style="margin-top:5px"/>
                
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
                             
                                         
                                      
                    </div>
                    
                </div>

                <div class="well">
                

                    <div class="row">

                     <h4 style="margin-top:-10px" ><a href="#" style="color:rgb(10, 28, 72)">Etiquetas a Insertar  </a> </h4>  
                        
                    <table style="width: 100%;">
                            <tr>
                                <td style="width:33%; text-align:center"><asp:TextBox ID="TextBox13" runat="server" Height="35px" Width="90%" ></asp:TextBox></td>
                                <td style="width:33%; text-align:center"><asp:TextBox ID="TextBox14" runat="server" Height="35px" Width="90%" ></asp:TextBox></td>
                                <td style="width:33%; text-align:center"><asp:TextBox ID="TextBox15" runat="server" Height="35px" Width="90%" ></asp:TextBox></td>
                                

                            </tr>
                        </table>
                      
                          


                       
                       
                            
                                
                                
                           
                           
                        



                    </div>

                    

                    <div class="row">
                        <div class="col-md-12">
                            


                        </div>
                    </div>
                    <hr style="margin-top:0px">


                    <asp:Button ID="Insertar_Etiqueta" class="btn btn-danger" runat="server" Text="Insertar Etiqueta en Ejercicio" OnClick="Insertar_Etiqueta_Click" OnClientClick="return Confirmacion();" />
                    
                    

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

