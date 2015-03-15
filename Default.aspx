<%@ Page Language="C#" Inherits="ImageRetriever.Default" EnableEventValidation ="false"%>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>RGB Retriever</title>

	<script language="JavaScript">
	function point_it(event){
	pos_x = event.offsetX?(event.offsetX):event.pageX-document.getElementById("pointer_div").offsetLeft;
	pos_y = event.offsetY?(event.offsetY):event.pageY-document.getElementById("pointer_div").offsetTop;
	document.getElementById("cross").style.left = (pos_x-1) ;
	document.getElementById("cross").style.top = (pos_y-15) ;
	document.getElementById("cross").style.visibility = "visible" ;
	document.pointform.form_x.value = pos_x;
	document.pointform.form_y.value = pos_y;
}
</script>
</head>
<body>
<center>
<h1>Image RGB Retriever</h1>
	<br> <h3 align="center"> Please Enter A File</h3> </br>

	 <form id="form1" runat="server">
		<asp:FileUpLoad id="FileUpLoad1" runat="server" />
		<asp:Button id="UploadBtn" Text="Upload File" OnClick="UploadBtn_Click" runat="server" Width="105px" />	
		<asp:Button id="DeleteBtn" Text="Delete Folder" OnClick="DeleteBtn_Click" runat="server" Width="105px" />
		<asp:Button id="DeleteLst" Text="Delete Last" OnClick="DeleteLst_Click" runat="server" Width="105px" />
	</form> 
	<hr />

	<form name="pointform" method="post">
	<div id="pointer_div" onclick="point_it(event)" style = "background-image:url('~/Image/2.jpg');width:250px;height:250px;repeat">
	<img src="" id="cross" style="position:relative;visibility:hidden;z-index:2;"></div>

	You pointed on x = <input type="text" name="form_x" size="4" /> - y = <input type="text" name="form_y" size="4" />
	<br></br>
	<br></br>
	<br></br>
	<br></br>
	Here are the files you have uploaded.
	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">

    <Columns>
    <asp:ImageField DataImageUrlField="Value" ControlStyle-Height=500 ControlStyle-Width=500/>

    <asp:BoundField DataField="Text" />
    </Columns>
  
	</asp:GridView>


	</center>	

</body>
</html>