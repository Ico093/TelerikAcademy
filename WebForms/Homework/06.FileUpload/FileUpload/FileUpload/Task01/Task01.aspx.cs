using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload.Task01
{
    public partial class Task01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            if (FileUploadArchive.HasFile)
            {
                if (FileUploadArchive.PostedFile.ContentType == "application/octet-stream")
                {
                    Stream fileStream = null;

                    fileStream = FileUploadArchive.PostedFile.InputStream;


                    using (ZipFile zip = ZipFile.Read(fileStream))
                    {
                        byte[] fileData = null;
                        Stream fileStream1 = null;
                        int length = 0;

                        foreach (ZipEntry item in zip)
                        {
                            length = (int)item.UncompressedSize;
                            fileData = new byte[length + 1];
                            fileStream1 = item.OpenReader();
                            fileStream1.Read(fileData, 0, length);

                            MemoryStream stream = new MemoryStream(fileData);

                            string text=Encoding.ASCII.GetString(stream.ToArray());

                            LabelContent.Text += text;
                        }
                    }

                    LabelResult.Text = "Success!";
                }
                else
                {
                    LabelResult.Text = "Only .zip files are accepted.";
                }
            }
            else
            {
                LabelResult.Text = "No file was selected.";
            }
        }
    }
}