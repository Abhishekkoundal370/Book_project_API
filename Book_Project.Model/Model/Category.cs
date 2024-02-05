using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project.Model.Model
{
    public class Category
    {
        ////Why we create Model 
        //Model is responsible for data comes from database.
          // in dynamic website data comes form database through Model.
          // once data comes from daṭabase ,the controller action method returns model to view.

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
