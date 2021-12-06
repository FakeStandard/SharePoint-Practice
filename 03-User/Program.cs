using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace _03_User
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://sp-server-2016/"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    foreach (SPUser user in web.AllUsers)
                        Console.WriteLine($"User: {user.Name}");
                }
            }

            Console.ReadKey(false);
        }
    }
}
