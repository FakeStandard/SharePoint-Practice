using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DocumentLibrary_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://sp-server-2016/"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    // Create document library.
                    SPListTemplate listTemplate = web.ListTemplates["Document Library"];
                    //SPListTemplate listTemplate = web.ListTemplates["文件庫"];
                    SPDocTemplate docTemplate = (from SPDocTemplate dt in web.DocTemplates
                                                 where dt.Type == 122
                                                 select dt).FirstOrDefault();

                    Guid guid = web.Lists.Add("My Docs", "My Documents", listTemplate, docTemplate);

                    SPDocumentLibrary library = web.Lists[guid] as SPDocumentLibrary;
                    library.OnQuickLaunch = true;
                    library.Update();

                    // Upload document.
                    SPDocumentLibrary uploadLib = web.Lists["My Docs"] as SPDocumentLibrary;
                    SPFile uploadFile = uploadLib.RootFolder.Files.Add("sample.xlsx", File.ReadAllBytes("sample.xlsx"));

                    // Download document.
                    SPDocumentLibrary downloadLib = web.Lists["My Docs"] as SPDocumentLibrary;
                    SPFile downloadFile = web.GetFile(downloadLib.RootFolder.Url + "/sample.xlsx");
                    Stream stream = downloadFile.OpenBinaryStream();
                    FileStream fileStream = new FileStream("out.xlsx", FileMode.OpenOrCreate, FileAccess.Write);

                    int buffer = 4096;
                    int read = buffer;
                    byte[] bytes = new byte[buffer];

                    while (read == buffer)
                    {
                        read = stream.Read(bytes, 0, buffer);
                        fileStream.Write(bytes, 0, read);

                        if (read < buffer) break;
                    }

                    stream.Dispose();
                    fileStream.Dispose();
                }
            }
        }
    }
}
