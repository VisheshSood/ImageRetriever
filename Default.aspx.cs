using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ImageRetriever {
	
	public partial class Default : System.Web.UI.Page {
		

		protected void UploadBtn_Click(object sender, EventArgs e) {
			if (FileUpLoad1.HasFile)
			{
				Directory.CreateDirectory ("Image/");
				FileUpLoad1.SaveAs(MapPath("Image/" + FileUpLoad1.FileName));
			}
			Response.Redirect (Request.RawUrl);
		}

		protected void DeleteBtn_Click(object sender, EventArgs e) {
			Array.ForEach(Directory.GetFiles("Image/"), File.Delete);
			Response.Redirect (Request.RawUrl);
		}

		protected void Page_Load(object sender, EventArgs e) {
			Directory.CreateDirectory ("Image/");
			if (!IsPostBack)
			{
				string[] filePaths = Directory.GetFiles(Server.MapPath("~/Image/"));
				List<ListItem> files = new List<ListItem>();
				foreach (string filePath in filePaths)
				{
					string fileName = Path.GetFileName(filePath);
					files.Add(new ListItem(fileName, "~/Image/" + fileName));
				}
				GridView1.DataSource = files;
				GridView1.DataBind();
			}
		}

	}
}

