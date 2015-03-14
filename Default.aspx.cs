using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using System.Windows.Forms;


namespace ImageRetriever {

	public partial class Default : System.Web.UI.Page {


		protected void UploadBtn_Click(object sender, EventArgs e) {
			if (FileUpLoad1.HasFile) {
				string extension = System.IO.Path.GetExtension(FileUpLoad1.FileName);
				if (extension == ".jpg" || extension == ".jpeg") {
					if (FileUpLoad1.HasFile) {
						string filesName = "1" + FileUpLoad1.FileName;
						Directory.CreateDirectory ("Image/");
						FileUpLoad1.SaveAs (MapPath ("Image/" + filesName));
					}
					Response.Redirect (Request.RawUrl);
				}
			} else {
				Response.Write("Only .Jpg allowed");
			}
		}

		protected void DeleteBtn_Click(object sender, EventArgs e) {
			Array.ForEach(Directory.GetFiles("Image/"), File.Delete);
			Response.Redirect (Request.RawUrl);
		}

		protected void DeleteLst_Click(object sender, EventArgs e) {
			var directory = new DirectoryInfo("Image/");
			var myFile = (from f in directory.GetFiles()
				orderby f.LastWriteTime descending
				select f).First();
			myFile.Delete();
			Response.Redirect (Request.RawUrl);
		}

		protected void Page_Load(object sender, EventArgs e) {
			Directory.CreateDirectory ("Image/");
			if (!IsPostBack) {
				string[] filePaths = Directory.GetFiles(Server.MapPath("~/Image/"));
				List<ListItem> files = new List<ListItem>();
				foreach (string filePath in filePaths) {
					string fileName = Path.GetFileName(filePath);
					files.Add(new ListItem("0,0", "~/Image/" + fileName));
				}
				GridView1.DataSource = files;
				GridView1.DataBind();
			}
		}
	}
}
