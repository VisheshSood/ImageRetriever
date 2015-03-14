using System;
using System.Web;
using System.Web.UI;
using System.IO;

namespace ImageRetriever {
	
	public partial class Default : System.Web.UI.Page {
		

		protected void UploadBtn_Click(object sender, EventArgs e)
		{
			if (FileUpLoad1.HasFile)
			{
				Directory.CreateDirectory ("Image/");
				FileUpLoad1.SaveAs(MapPath("Image/" + FileUpLoad1.FileName));
				displayfile (FileUpLoad1);
			}

		}

		protected void displayfile(object file) {

		}
	}
}

