using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolanKuyDesktopPalingbaru.Akomodasi
{
    
        public class ModelListAkomodasi
        {
            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string description { get; set; }
            public int category_id { get; set; }
            public string image { get; set; }
            public string contact { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int distance { get; set; }
        }

        /* public class Galery
        {
            public int id { get; set; }
            public int list_location_id { get; set; }
            public string filename { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        } */

        public class RootAkomodasi
        {
            public List<ModelListAkomodasi> acomodation { get; set; }
            //public List<Galery> galery { get; set; }
        }
    
}
