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
	</form>
	<asp:Image ID="imgViewFile" runat="server" />
</body>
</html>

