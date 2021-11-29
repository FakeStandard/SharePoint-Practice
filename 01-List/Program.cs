using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace _01_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Site Collection
            using (SPSite site = new SPSite("http://sp-server-2016"))
            {
                // Site
                using (SPWeb web = site.OpenWeb())
                {
                    // List
                    SPList list = web.Lists["My Contacts"];

                    int i = 1;
                    foreach (SPListItem item in list.Items)
                    {
                        Console.WriteLine($"Item: {(i++).ToString()}");

                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Title);

                        Console.WriteLine(item.GetFormattedValue("FirstName"));
                        Console.WriteLine(item.GetFormattedValue("LastName"));

                        Console.WriteLine(String.Empty);

                    }
                }
            }

            Console.ReadKey(false);
        }
    }
}
