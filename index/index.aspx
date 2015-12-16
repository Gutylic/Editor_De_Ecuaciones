<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="index.index" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


   

    <title>Editor De Ecuaciones</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    
    <script src="http://www.wiris.net/demo/editor/editor"></script>
    
    <script type="text/javascript">

        var toolbart = '<toolbar ref="general" removeLinks="true"><tab ref="general"><removeItem ref="setFontSize"/><removeItem ref="parenthesis"/><removeItem ref="curlyBracket"/><removeItem ref="squareBracket"/><removeItem ref="setFontFamily"/><removeItem ref="forceLigature"/><removeItem ref="rtl"/><removeItem ref="mtext"/><removeItem ref="setColor"/><removeItem ref="autoItalic"/><removeItem ref="italic"/><removeItem ref="bold"/><removeItem ref="undo"/><removeItem ref="redo"/><removeItem ref="paste"/><removeItem ref="cut"/><removeItem ref="copy"/><removeItem ref="&#247;"/><removeItem ref="+"/><removeItem ref="-"/><removeItem ref="&#215;"/><removeItem ref="&#247"/><removeItem ref="bevelledFraction"/><removeItem ref="/"/></tab><tab ref="symbols"><removeItem ref="&#10878;"/><removeItem ref="&#10877;"/><removeItem ref="*"/><removeItem ref="="/><removeItem ref="<"/><removeItem ref=">"/><removeItem ref="&#247;"/><removeItem ref="+"/><removeItem ref="-"/><removeItem ref="&#215;"/><removeItem ref="&#247"/><removeItem ref="bevelledFraction"/><removeItem ref="/"/></tab><tab ref="greek"><removeItem ref="naturals"/><removeItem ref="rationals"/><removeItem ref="reals"/><removeItem ref="integers"/><removeItem ref="complexes"/><removeItem ref="primes"/><removeItem ref="&#8465;"/><removeItem ref="&#8476;"/><removeItem ref="ell"/><removeItem ref="&#8501;"/><removeItem ref="&#8472;"/><removeItem ref="&#8497;"/><removeItem ref="&#8466;"/><removeItem ref="zTransform"/><removeItem ref="arabicIndicNumbers"/><removeItem ref="easternArabicIndicNumbers"/></tab><tab ref="matrices"><removeItem ref="piecewiseFunction"/><removeItem ref="equationAlign"/></tab><tab ref="scriptsAndLayout"><removeItem ref="bigOpUnderover"/><removeItem ref="bigOpUnder"/><removeItem ref="bigOpSubsuperscript"/><removeItem ref="bigOpSubscript"/><removeItem ref="bevelledFraction"/><removeItem ref="smallBevelledFraction"/><removeItem ref="smallFraction"/><removeItem ref="digitSpace"/><removeItem ref="backSpace"/><removeItem ref="thinnerSpace"/><removeItem ref="thinSpace"/></tab><tab ref="bracketsAndAccents"><removeItem ref="parenthesis"/><removeItem ref="squareBracket"/><removeItem ref="angleBrackets"/><removeItem ref="curlyBracket"/><removeItem ref="openParenthesis"/><removeItem ref="closeParenthesis"/><removeItem ref="openSquareBracket"/><removeItem ref="closeSquareBracket"/><removeItem ref="openAngleBracket"/><removeItem ref="closeAngleBracket"/><removeItem ref="openCurlyBracket"/><removeItem ref="closeCurlyBracket"/></tab><tab ref="bigOps"><removeItem ref="sumSubsuperscript"/><removeItem ref="sumSubscript"/><removeItem ref="productSubsuperscript"/><removeItem ref="productSubscript"/><removeItem ref="bigOpSubsuperscript"/><removeItem ref="bigOpSubscript"/></tab><tab ref="calculus"><removeItem ref="sinus"/><removeItem ref="cosinus"/><removeItem ref="tangent"/><removeItem ref="log"/><removeItem ref="nlog"/><removeItem ref="naturalLog"/><removeItem ref="cosecant"/><removeItem ref="secant"/><removeItem ref="cotangent"/><removeItem ref="arcsinus"/><removeItem ref="arccosinus"/><removeItem ref="arctangent"/></tab>               <tab ref="contextual"><removeItem ref="alignLeft"/><removeItem ref="alignCenter"/><removeItem ref="alignRight"/><removeItem ref="addFrame"/><removeItem ref="removeFrame"/><removeItem ref="matrixSolidLine"/><removeItem ref="matrixDashLine"/><removeItem ref="removeLineBelow"/><removeItem ref="removeLineRight"/><removeItem ref="alignRowsTop"/><removeItem ref="alignRowsCenter"/><removeItem ref="alignRowsBottom"/> <removeItem ref="alignRowsBottom"/><removeItem ref="alignRowsBaseline"/>  <removeItem ref="alignRowsAxis"/><removeItem ref="equalRowHeight"/><removeItem ref="equalColWidth"/><removeItem ref="setColumnSpacing"/><removeItem ref="setRowSpacing"/><removeItem ref="alignLeft"/><removeItem ref="alignCenter"/><removeItem ref="alignRight"/></tab></toolbar>';

        var editor;
        window.onload = function () {
            editor = com.wiris.jsEditor.JsEditor.newInstance({ 'language': 'es', 'toolbar': toolbart });
            editor.insertInto(document.getElementById('editorContainer'));
                       
            if ('<%=Session["Contenido_Wiris"]%>' != "") {
               
                editor.setMathML('<%=Session["Contenido_Wiris"]%>');
            };

        }

        function Cargar_Editor_Con_Variable_CSharp(Mensaje)
        {
            editor.setMathML(document.getElementById('Contenido_Wiris').value);
            
        }

        function Cargar_Variable_CSharp() {
            document.getElementById("Contenido_Wiris").value = editor.getMathML();
        };

    </script>

    <style>

        a:link {
            text-decoration:none;   
        }

    </style>

</head>

<body>
    
    <form id="form1" runat="server">
       
    <div>
        
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            
            <div class="container">
         
                <div class="navbar-header">
                
                    <a class="navbar-brand">Editor De Ecuaciones</a>

                </div>
           
            </div>
        
        </nav>

    
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
                    <asp:HiddenField ID="Contenido_Wiris" runat="server" />
                    
                    <div id="editorContainer" style="height:300px;"></div>
                    <div class="caption-full">
                        <h4 class="pull-right"></h4>
                        <h4><a href="#">Titulo Del Ejercicio</a>
                        </h4>
                        <p><asp:TextBox ID="Titulo" runat="server" Height="36px" Width="100%" MaxLength="50"></asp:TextBox></p>                        
                    </div>                    
                </div>

                <div class="well">
                <table style="width: 100%; margin-top:0px">
                    <tr>
                        <td style="text-align:center; width:33%"><h5 style="font-size:16px; color: rgb(51,122,183); margin-top:0px; margin-bottom:-10px">Tipo de Institucion</h5></td>
                        <td style="text-align:center; width:33%"><h5 style="font-size:16px; color: rgb(51,122,183); margin-top:0px; margin-bottom:-10px">Tipo de Producto</h5></td>
                        <td style="text-align:center; width:33%"><h5 style="font-size:16px; color: rgb(51,122,183); margin-top:0px; margin-bottom:-10px">Explicacion Diseñada</h5></td>
                    </tr>
                    
            </table>
                    

                    <hr>

                    <div class="row">
                       
                    <asp:DropDownList ID="DropDownList_Institucion" runat="server" Height="40px" Width="33%">
                        <asp:ListItem Value="1">Ninguno</asp:ListItem>
                        <asp:ListItem Value="2">Secundario</asp:ListItem>
                        <asp:ListItem Value="3">Ciclo Medio</asp:ListItem>
                        <asp:ListItem Value="4">Ciclo Superior</asp:ListItem>
                        <asp:ListItem Value="5">Terceario</asp:ListItem>
                        <asp:ListItem Value="6">Universidad</asp:ListItem>
                        <asp:ListItem Value="7">Varios</asp:ListItem>
                        <asp:ListItem Value="8">Otros</asp:ListItem>
                    </asp:DropDownList>

    
                    <asp:DropDownList ID="DropDownList_Tipo" runat="server" Height="40px" Width="33%">
                        <asp:ListItem Value="1">Ejercicio</asp:ListItem>
                        <asp:ListItem Value="2">Explicacion</asp:ListItem>
                        <asp:ListItem Value="3">Video</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="DropDownList_Enunciado_Realizado" runat="server" Height="40px" Width="33%" style="text-align: right">
                        
                        <asp:ListItem Value="false">No realizado</asp:ListItem> 
                        <asp:ListItem Value="true">Realizado</asp:ListItem>
                    </asp:DropDownList>

                    </div>

                    <hr>

                    <div class="row">
                        <div class="col-md-12">
                            
<table style="width: 100%;">
                            <tr>
                                <td style="width: 20%;font-size:16px; color: rgb(51,122,183)">Ubicacion del Video</td>
                                <td style="width: 80%;"><asp:TextBox ID="Ubicacion_Del_Video_Y_Explicacion" runat="server" Width="102%" Height="36px" style="margin-left: 0px"></asp:TextBox></td>
                                
                            </tr>
                           
                        </table>

                        </div>
                    </div>
                    <hr>


                    <asp:Button ID="Siguiente" class="btn btn-primary" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Siguiente >>" OnClick="Siguiente_Click" />
                    
                    

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
