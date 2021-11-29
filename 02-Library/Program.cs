using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Site Collection
            using (SPSite site = new SPSite("http://sp-server-2016/"))
            {
                // Site
                using (SPWeb web = site.OpenWeb())
                {
                    // Library
                    SPDocumentLibrary library = web.Lists["My Docs"] as SPDocumentLibrary;

                    int i = 1;
                    foreach (SPListItem item in library.Items)
                    {
                        Console.WriteLine($"Item: {(i++).ToString()}");

                        Console.WriteLine(item.File.Name);
                        Console.WriteLine(item.File.Length);

                        Console.WriteLine(String.Empty);
                    }
                }
            }

            Console.ReadKey(false);

        }
    }
}
