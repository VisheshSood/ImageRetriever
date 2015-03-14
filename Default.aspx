<%@ Page Language="C#" Inherits="ImageRetriever.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>RGB Retriever</title>
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

	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">

    <Columns>
        <asp:ImageField DataImageUrlField="Value" ControlStyle-Height=500 ControlStyle-Width=500/>
    	
        <asp:BoundField DataField="Text" />

    </Columns>
  
	</asp:GridView>
	</center>
</body>
</html>

