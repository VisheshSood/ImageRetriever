<%@ Page Language="C#" Inherits="ImageRetriever.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>RGB Retriever</title>
</head>
<body>
<h1>Image RGB Retriever</h1>
	<br>Please Enter a File</br>
	<form id="form1" runat="server">
		<asp:FileUpLoad id="FileUpLoad1" runat="server" />
		<asp:Button id="UploadBtn" Text="Upload File" OnClick="UploadBtn_Click" runat="server" Width="105px" />	
		<asp:Button id="DeleteBtn" Text="Delete Folder" OnClick="DeleteBtn_Click" runat="server" Width="105px" />
	</form>
	<hr />

	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">

    <Columns>
        <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="500" ControlStyle-Width="500" />
         <asp:BoundField DataField="UnitPrice" HeaderText="PricePerUnit" ReadOnly="true" SortExpression="UnitPrice" />
        </Columns>
	</asp:GridView>

</body>
</html>

