using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace _04_ListItem_Add_Update_Delete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://sp-server-2016/"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    SPList list = web.Lists["Tasks"];

                    // Add
                    for (int i = 0; i < 9; i++)
                    {
                        SPListItem additem = list.Items.Add();
                        additem["Title"] = $"{i}. New Task";
                        additem.Update();
                    }


                    // Edit
                    SPListItem edititem = list.Items[0];
                    edititem["Title"] = "Edited Task";
                    edititem.Update();

                    // Delete
                    SPListItem delitem = list.Items[3];
                    delitem.Delete();
                }
            }
        }
    }
}
