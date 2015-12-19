<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscar.aspx.cs" Inherits="index.buscar" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<title>Buscar Ejercicios</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <script type="text/javascript" src="http://www.wiris.net/demo/editor/editor"></script>

	<script type="text/javaScript">

	    var toolbart = '<toolbar ref="general" removeLinks="true"><tab ref="general"><removeItem ref="setFontSize"/><removeItem ref="parenthesis"/><removeItem ref="curlyBracket"/><removeItem ref="squareBracket"/><removeItem ref="setFontFamily"/><removeItem ref="forceLigature"/><removeItem ref="rtl"/><removeItem ref="mtext"/><removeItem ref="setColor"/><removeItem ref="autoItalic"/><removeItem ref="italic"/><removeItem ref="bold"/><removeItem ref="undo"/><removeItem ref="redo"/><removeItem ref="paste"/><removeItem ref="cut"/><removeItem ref="copy"/><removeItem ref="&#247;"/><removeItem ref="+"/><removeItem ref="-"/><removeItem ref="&#215;"/><removeItem ref="&#247"/><removeItem ref="bevelledFraction"/><removeItem ref="/"/></tab><tab ref="symbols"><removeItem ref="&#10878;"/><removeItem ref="&#10877;"/><removeItem ref="*"/><removeItem ref="="/><removeItem ref="<"/><removeItem ref=">"/><removeItem ref="&#247;"/><removeItem ref="+"/><removeItem ref="-"/><removeItem ref="&#215;"/><removeItem ref="&#247"/><removeItem ref="bevelledFraction"/><removeItem ref="/"/></tab><tab ref="greek"><removeItem ref="naturals"/><removeItem ref="rationals"/><removeItem ref="reals"/><removeItem ref="integers"/><removeItem ref="complexes"/><removeItem ref="primes"/><removeItem ref="&#8465;"/><removeItem ref="&#8476;"/><removeItem ref="ell"/><removeItem ref="&#8501;"/><removeItem ref="&#8472;"/><removeItem ref="&#8497;"/><removeItem ref="&#8466;"/><removeItem ref="zTransform"/><removeItem ref="arabicIndicNumbers"/><removeItem ref="easternArabicIndicNumbers"/></tab><tab ref="matrices"><removeItem ref="piecewiseFunction"/><removeItem ref="equationAlign"/></tab><tab ref="scriptsAndLayout"><removeItem ref="bigOpUnderover"/><removeItem ref="bigOpUnder"/><removeItem ref="bigOpSubsuperscript"/><removeItem ref="bigOpSubscript"/><removeItem ref="bevelledFraction"/><removeItem ref="smallBevelledFraction"/><removeItem ref="smallFraction"/><removeItem ref="digitSpace"/><removeItem ref="backSpace"/><removeItem ref="thinnerSpace"/><removeItem ref="thinSpace"/></tab><tab ref="bracketsAndAccents"><removeItem ref="parenthesis"/><removeItem ref="squareBracket"/><removeItem ref="angleBrackets"/><removeItem ref="curlyBracket"/><removeItem ref="openParenthesis"/><removeItem ref="closeParenthesis"/><removeItem ref="openSquareBracket"/><removeItem ref="closeSquareBracket"/><removeItem ref="openAngleBracket"/><removeItem ref="closeAngleBracket"/><removeItem ref="openCurlyBracket"/><removeItem ref="closeCurlyBracket"/></tab><tab ref="bigOps"><removeItem ref="sumSubsuperscript"/><removeItem ref="sumSubscript"/><removeItem ref="productSubsuperscript"/><removeItem ref="productSubscript"/><removeItem ref="bigOpSubsuperscript"/><removeItem ref="bigOpSubscript"/></tab><tab ref="calculus"><removeItem ref="sinus"/><removeItem ref="cosinus"/><removeItem ref="tangent"/><removeItem ref="log"/><removeItem ref="nlog"/><removeItem ref="naturalLog"/><removeItem ref="cosecant"/><removeItem ref="secant"/><removeItem ref="cotangent"/><removeItem ref="arcsinus"/><removeItem ref="arccosinus"/><removeItem ref="arctangent"/></tab>               <tab ref="contextual"><removeItem ref="alignLeft"/><removeItem ref="alignCenter"/><removeItem ref="alignRight"/><removeItem ref="addFrame"/><removeItem ref="removeFrame"/><removeItem ref="matrixSolidLine"/><removeItem ref="matrixDashLine"/><removeItem ref="removeLineBelow"/><removeItem ref="removeLineRight"/><removeItem ref="alignRowsTop"/><removeItem ref="alignRowsCenter"/><removeItem ref="alignRowsBottom"/> <removeItem ref="alignRowsBottom"/><removeItem ref="alignRowsBaseline"/>  <removeItem ref="alignRowsAxis"/><removeItem ref="equalRowHeight"/><removeItem ref="equalColWidth"/><removeItem ref="setColumnSpacing"/><removeItem ref="setRowSpacing"/><removeItem ref="alignLeft"/><removeItem ref="alignCenter"/><removeItem ref="alignRight"/></tab></toolbar>';

	    var editor;


	    window.onload = function () {
	        editor = com.wiris.jsEditor.JsEditor.newInstance({ 'language': 'es', 'toolbar': toolbart });

	        editor.insertInto(document.getElementById('editorContainer'));

	        if ('<%=Session["Contenido_Wiris"]%>' != "") {
	            editor.setMathML('<%=Session["Contenido_Wiris"]%>');
	        };

	        source = 'mathml';
	        lastSource = null;

	        var counter = 0;

	        setInterval(function () {
	            var mathML = editor.getMathML();

	            if (mathML != lastSource) {


	                if (source == 'mathml') {
	                    document.getElementById('source').value = mathML;

	                }


	                lastSource = mathML;
	            }
	        }, 1000);



	        window.changeSourceTo = function (newSource) {
	            lastSource = null;
	            source = newSource;
	            document.getElementById('source').value = '';
	            document.getElementById('source').style.color = null;
	            document.getElementById('source_set').style.display = null;

	        }

	        document.getElementById('source_set_button').onclick = function () {
	            if (source == 'mathml') {
	                //var mensaje1 = document.getElementById('TextBox_MATH').value;
	                //var posicion = mensaje1.indexOf('╝');
	                //var mensaje1 = mensaje1.substring(0,posicion);
	                editor.setMathML(document.getElementById('TextBox_MATH').value);
	                //editor.setMathML(mensaje1);
	            }


	        }

	        document.getElementById('source_cancel_button').onclick = function () {
	            if (source == 'mathml') {
	              // el textbox  
	                document.getElementById('TextBox_MATH').value = document.getElementById('source').value;
	            }

	        }
	    }

	    function validar_numerico(evento) {

	        var tecla = document.all ? tecla = evento.which : tecla = evento.keyCode;
	        return (tecla > 47 && tecla < 58);

	    };

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
                    <a href="index.aspx" class="list-group-item">Editor de Ecuaciones</a>
                    <a href="lector.aspx" class="list-group-item">Lector de Archivos</a>
                    <a href="etiquetas.aspx" class="list-group-item">Agregar Etiquetas al Ejercicio</a>
                    <a href="decodificador.aspx" class="list-group-item">Decodificador de Etiquetas</a>
                    <a href="homonimos.aspx" class="list-group-item ">Trabajar con Etiquetas Similares</a>
                    <a href="#" class="list-group-item active">Buscador de Ejercicios</a>
                    <a href="respuesta.aspx" class="list-group-item ">Respuestas</a>
                    <a href="Video.aspx" class="list-group-item">Videos</a>
                    <a href="Cargar_Archivos.aspx" class="list-group-item">Cargar Archivos</a>
                    <a href="Cargar_Administradores.aspx" class="list-group-item">Cargar Administradores</a>
                    <a href="Vaciar_Base.aspx" class="list-group-item" style="color:red; font-weight:bolder">Limpiar Base</a>
                </div>
            </div>

            <div class="col-md-6">

                <div class="thumbnail" style=" margin-top:60px" >
                    <asp:HiddenField ID="Contenido_Wiris" runat="server" />
                    
                    <div id="editorContainer" style="height:300px;"></div>
                              
                </div>
            </div>
            <div class="col-md-3">
            <textarea id="source" spellcheck="false" style="visibility:hidden"></textarea>
                <div class="thumbnail" style=" margin-top:7px" >
                   
                    <div class="caption-full">
                       
                       <asp:TextBox ID="TextBox_MATH" TextMode="MultiLine" style="height:300px;width:100%;" runat="server" Text='<math xmlns="http://www.w3.org/1998/Math/MathML"></math>'></asp:TextBox>
                    </div>                    
                </div>
            </div>
            <div class="col-md-6">
            <div class="caption-full">
                       <asp:FileUpload ID="Subir_Archivo" runat="server" Height="36px" Width="100%"/>
                                            
                    </div>          
                </div>
            <div class="col-md-3">
            <div class="caption-full">
                       <asp:Button ID="Boton_Para_Leer_Archivo" runat="server" Width="100%" Text="Cargar" class="btn btn-info" OnClick="Boton_Para_Leer_Archivo_Click"/>
                                            
                    </div>          
                </div>
            
        
            <div class="col-md-3"></div>
            <div class="col-md-9">
            <div class="well" style="margin-top:20px">
                <div id="source_set" class="setter">
                    <table style="width: 100%;margin-top:0px">
                        <tr>
                            <td style="text-align:center; width:33%"><input id="source_cancel_button" style="width:90%" type="button" value="Texto => MATH" class="btn btn-success" /></td>
                            <td style="text-align:center; width:33%"><input id="source_set_button" style="width:90%" type="button" value="Texto <= MATH " class="btn btn-warning" /></td>                            
                            <td style="text-align:center; width:33%"><asp:Button ID="Boton_De_Borrado_Del_TextArea_MATH" style="width:90%" runat="server" Width="100%" Text="Borrar" CssClass="btn btn-danger" OnClick="Boton_De_Borrado_Del_TextArea_MATH_Click"/></td>
                        </tr>
                   
                    </table>
                </div>
            </div>
            </div>
            <div class="col-md-3"></div>
            <div class="col-md-9">
            <div class="well" style="margin-top:0px">
                
                    <table style="width: 100%;margin-top:0px">
                        <tr>
                            <td style="text-align:center; width:33%"><asp:TextBox ID="TextBox_Profundidad" Width="90%" Height="36px" placeholder="Valor" style="padding-left:3px" runat="server" onKeyPress="return validar_numerico(event)"></asp:TextBox></td>
                            <td style="text-align:center; width:33%"><asp:Button ID="Boton_Busqueda_Enunciado_Profundidad" OnClientClick="Cargar_Variable_CSharp()" Width="90%" runat="server" Text="Buscar x Profundidad" CssClass="btn btn-info" OnClick="Boton_Busqueda_Enunciado_Profundidad_Click"/></td>                            
                            <td style="text-align:center; width:33%"><asp:Button ID="Boton_Busqueda_En_Enunciado_Limpio_Porcentaje" OnClientClick="Cargar_Variable_CSharp()" Width="90%" runat="server" Text="Buscar x Porcentaje" CssClass="btn btn-primary" OnClick="Boton_Busqueda_En_Enunciado_Limpio_Porcentaje_Click" /></td>
                        </tr>
                   
                    </table>
                
            </div>
           <div class="well" style="margin-top:5px">
                
                    <table style="width: 100%;margin-top:0px">
                        <tr>
                            <td style="text-align:center; width:33%"><asp:Button ID="Boton_Busqueda_En_Enunciado_Limpio_Palabras_Claves" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Buscar x Palabras Claves" CssClass="btn btn-info" Width="90%" OnClick="Boton_Busqueda_En_Enunciado_Limpio_Palabras_Claves_Click"/>  </td>
                            <td style="text-align:center; width:33%"><asp:DropDownList ID="DropDownList_Tipo_De_Institucion" runat="server" Width="90%" Height="36px" >
                            <asp:ListItem Value="1">Ninguno</asp:ListItem>
                            <asp:ListItem Value="2">Secundario</asp:ListItem>
                            <asp:ListItem Value="3">Ciclo Medio</asp:ListItem>
                            <asp:ListItem Value="4">Ciclo Superior</asp:ListItem>
                            <asp:ListItem Value="5">Terceario</asp:ListItem>
                            <asp:ListItem Value="6">Universidad</asp:ListItem>
                            <asp:ListItem Value="7">Varios</asp:ListItem>
                            <asp:ListItem Value="8">Ciclo Inicial</asp:ListItem>
                            <asp:ListItem Value="9">Ingreso Universidad</asp:ListItem>
                            <asp:ListItem Value="10">Ingreso Secundario</asp:ListItem>
                            <asp:ListItem Value="11">Ingreso Terceario</asp:ListItem>
                            <asp:ListItem Value="12">Otros</asp:ListItem>
                            
                        </asp:DropDownList></td>                            
                            <td style="text-align:center; width:33%"><asp:Button ID="Boton_Busqueda_Por_Institucion" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Buscar x Institución" CssClass="btn btn-default" Width="90%" OnClick="Boton_Busqueda_Por_Institucion_Click" /></td>
                        </tr>
                   
                    </table>
                
            </div>

                <div class="well">
                <table style="width: 100%; margin-top:0px">
                    <tr>
                        <td style="text-align:center; width:16.66%"><asp:TextBox ID="TextBox_Por_Tema" style="padding-left:3px" runat="server" Height="36px" Width="90%" placeholder="Tema"></asp:TextBox></td>
                        <td style="text-align:center; width:16.66%"><asp:Button ID="Boton_Busqueda_Por_Tema" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Tema" Width="90%" CssClass="btn btn-success" OnClick="Boton_Busqueda_Por_Tema_Click"/></td>
                        <td style="text-align:center; width:16.66%"><asp:TextBox ID="TextBox_Por_Materia" style="padding-left:3px" Placeholder="Materia" runat="server" Height="36px" Width="90%" placehoder="Materia"></asp:TextBox></td>
                        <td style="text-align:center; width:16.66%"><asp:Button ID="Boton_Busqueda_Por_Materia" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Materia" Width="90%" CssClass="btn btn-success" OnClick="Boton_Busqueda_Por_Materia_Click"/></td>
                        <td style="text-align:center; width:16.66%"><asp:TextBox ID="TextBox_Por_Colegio" style="padding-left:3px" runat="server" Height="36px" Width="90%" placeholder="Colegio"></asp:TextBox></td>
                        <td style="text-align:center; width:16.66%"><asp:Button ID="Boton_Busqueda_Por_Colegio" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Colegio" Width="90%" CssClass="btn btn-success" OnClick="Boton_Busqueda_Por_Colegio_Click"/></td>
                    
                    </tr>
                  </table>
                 </div>
                
                <div class="well">
                <table style="width: 100%; margin-top:0px">  
                    <tr >
                        <td style="text-align:center; width:16.66%"><asp:TextBox ID="TextBox_Por_Profesor" style="padding-left:3px" runat="server" Height="36px" Width="90%" placeholder="Profesor"></asp:TextBox></td>
                        <td style="text-align:center; width:16.66%"><asp:Button ID="Boton_Busqueda_Por_Profesor" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Profesor"  Width="90%" CssClass="btn btn-success" OnClick="Boton_Busqueda_Por_Profesor_Click"/></td>
                        <td style="text-align:center; width:16.66%"><asp:TextBox ID="TextBox_Por_Ano" style="padding-left:3px" runat="server" Height="36px" Width="90%" placeholder="Año"></asp:TextBox></td>
                        <td style="text-align:center; width:16.66%"><asp:Button ID="Boton_Busqueda_Por_Ano" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Año" Width="90%" CssClass="btn btn-success" OnClick="Boton_Busqueda_Por_Ano_Click" /></td>
                        <td style="text-align:center; width:33.33%"><asp:Button ID="Boton_Busqueda_Por_Ficha_Completa" OnClientClick="Cargar_Variable_CSharp()" runat="server" Text="Buscar x Ficha" Width="90%" CssClass="btn btn-warning" OnClick="Boton_Busqueda_Por_Ficha_Completa_Click"/></td>
                        
                    
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

