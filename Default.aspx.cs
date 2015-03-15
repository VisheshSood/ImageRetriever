using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using System.Drawing;
namespace ImageRetriever {

	public partial class Default : System.Web.UI.Page {


		protected void UploadBtn_Click(object sender, EventArgs e) {
			if (FileUpLoad1.HasFile) {
				string extension = System.IO.Path.GetExtension (FileUpLoad1.FileName);
				if (extension == ".jpg" || extension == ".jpeg") {
					if (FileUpLoad1.HasFile) {
						string filesName = FileUpLoad1.FileName;
						Directory.CreateDirectory ("Image/");
						FileUpLoad1.SaveAs (MapPath ("Image/" + filesName));
						HttpPostedFile pf = FileUpLoad1.PostedFile;
						System.Drawing.Image bm = System.Drawing.Image.FromStream (pf.InputStream);
						bm = ResizeBitmap ((Bitmap)bm, 250, 250);
						bm.Save (Path.Combine ("Image/Extra/", "2.jpg"));
					}
					Response.Redirect (Request.RawUrl);
				} else {
					Response.Write ("Please submit a .jpg/.jpeg file.");
				} 
			} else {
				Response.Write ("Please submit a .jpg/.jpeg file.");
			}

		}

		private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight) {
			Bitmap result = new Bitmap(nWidth, nHeight);
			using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
				g.DrawImage(b, 0, 0, nWidth, nHeight);
			return result;
		}

		protected void DeleteBtn_Click(object sender, EventArgs e) {
			Array.ForEach(Directory.GetFiles("Image/"), File.Delete);
			Array.ForEach(Directory.GetFiles("Image/Extra/"), File.Delete);
			Response.Redirect (Request.RawUrl);
		}

		protected void DeleteLst_Click(object sender, EventArgs e) {
			if (isEmpty()) {
				Response.Redirect (Request.RawUrl);
			} else {
				var directory = new DirectoryInfo ("Image/");
				var myFile = (from f in directory.GetFiles ()
					orderby f.LastWriteTime descending
				              select f).First ();
				myFile.Delete ();
				Array.ForEach(Directory.GetFiles("Image/Extra/"), File.Delete);

				Response.Redirect (Request.RawUrl);
			}
		}

		private bool isEmpty() {
			return !Directory.EnumerateFiles ("Image/").Any ();

		}

		protected void Page_Load(object sender, EventArgs e) {
			Directory.CreateDirectory ("Image/");
			Directory.CreateDirectory ("Image/Extra/");

			if (!IsPostBack)
			{
				string[] filePaths = Directory.GetFiles(Server.MapPath("~/Image/"));
				List<ListItem> files = new List<ListItem>();
				foreach (string filePath in filePaths){
					string fileName = Path.GetFileName(filePath);
					if (!fileName.Equals("2.jpg")) {
						files.Add(new ListItem("~/Image/" + fileName, "~/Image/" + fileName));
					}
				}
				GridView1.DataSource = files;
				GridView1.DataBind();
			}
		}


	}
}