<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscar_x_ficha.aspx.cs" Inherits="index.buscar_x_ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Respuestas Ejercicios</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>

        a:link {
            text-decoration:none;   
        }

        .navbar-default {background-color:#f4f4f4;margin-top:50px;border-width:0;z-index:5;}
.navbar-default .navbar-nav > .active > a,.navbar-default .navbar-nav > li:hover > a {border:0 solid #4285f4;border-bottom-width:2px;font-weight:800;background-color:transparent;}
.navbar-default .dropdown-menu {background-color:#ffffff;}
.fondo {
    color: #fff;
    background-color: #6D4A70;
    border-color: #ddd;
}

div.cerrar_session {
    text-align:right;
    margin-top:30px;

}


#Volver_A_Consola {
    font-weight: bolder;
    font-size: 23px;
    color: white;
    margin-right: 100px;
    text-decoration: none;
}

div.consola_de_control {
    margin-top:6px;

}

div.ip {
    margin-top:-27px;
    color:white;
}

div.hora {
    margin-top:-8px;
    color:white
}

h1.titulo {
    color:white;
}

div.administrador {
    margin-top:23px;
}

#Etiqueta_Administrador {
    color:white;
    font-size:18px;

}

.fondo_encabezado {
    background:#6D4A70;
    height:92px;
}

hr {border-color:#ececec;}

button {
 outline: 0;
}

textarea {
 resize: none;
 outline: 0; 
}





.modal-footer {
 border-width:0;
}
.dropdown-menu {
 background-color:#f4f4f4;
 border-color:#f0f0f0;
 border-radius:0;
 margin-top:-1px;
}
/* end theme */

/* template layout*/
#subnav {
 position:fixed;
 width:100%;
}

@media (max-width: 768px) {
 #subnav {
  padding-top: 6px;
 }
}

#main {
 padding-top:120px;
}


h4.datos_del_administrador {
    text-align:center;

}

.clases {
    margin-top:20px;
}

#Etiqueta_Nombre {
    margin-top:20px;
    margin-left:23px;
}
#Etiqueta_Categoria {
    margin-top:20px;
    margin-left:23px;
}
#TextBox_Password {
    padding-left:23px;
    margin-top:10px;
    width:100%;
    height:36px;
}

div.encabezado_panel {
    background-color:#4285F4;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-fixed-top header fondo_encabezado">
 	            <div class="col-md-12">
                    <div class="Container">
                        <div class="row">
                            <div class="col-xs-4 administrador">
                                
                            </div>
                            <div class="col-xs-4 consola_de_control">
                                <h1 class="titulo"style="text-align:center">Respuestas</h1>
                            </div> 
                            <div class="col-xs-4 cerrar_session">                             
                                
                            </div>
                        </div>                    
                      
                    </div>
                </div>
            </nav>
        <div class="container">
            <div class="row">
                <div class="class-xs-12">
                    
                    <div class="well" id="Lista" runat="server" style="margin-top:120px;">
                        <div class="panel-heading"><h4>Listado de Ejercicios</h4></div> 
                        <asp:DataList ID="Resultado_DataList" runat="server" Width="90%">

                            <ItemTemplate>

                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width:50%; text-align:center"><asp:Label ID="Etiqueta_Ejercicio" runat="server" Text='<%# Eval("ID_Ejercicio") %>'></asp:Label></td>
                                        <td style="width:50%; text-align:center"><asp:Image ID="Imangen_Enunciado" ImageUrl='<%# "~/enunciados/Enunciado" + Eval("ID_Ejercicio") + ".png" %>' runat="server" /></td>
                                        
                                    </tr>
                                </table>
                                
                                
                                
                           </ItemTemplate>
                            
                        </asp:DataList>
                    
                        <hr />

                      <div id="Centros_Paginados" style="text-align:center" runat="server" visible="false">
                            <asp:LinkButton ID="Anterior" runat="server" OnClick="Anterior_Click" style="margin-right:10px;"><< Anterior</asp:LinkButton>
                            <asp:LinkButton ID="Siguiente" runat="server" OnClick="Siguiente_Click" style="margin-left:10px;">Siguiente >></asp:LinkButton>
                        </div>
                        <div id="Extremos_Paginados" runat="server" style="text-align:center">
                            <asp:LinkButton ID="Anterior_Ultimo" runat="server" style="margin-right:10px;" visible="false" OnClick="Anterior_Click"><< Anterior</asp:LinkButton>
                            <asp:LinkButton ID="Siguiente_Primero" runat="server" style="margin-left:10px;" OnClick="Siguiente_Click">Siguiente >></asp:LinkButton>
                            
                        </div>

                    </div>
                
                </div>
            </div>
        </div>
        <hr />
         <footer>
                <div class=" container">
                    <div class="row">
                        <div class="col-xs-6">
                            <h6>Copyrigth®2015 - Webmaster Martina Ivana Romero</h6>
                        </div>
                        <div class="col-xs-6"></div>
                    </div>
                </div>
            </footer>

    </form>
</body>
</html>
