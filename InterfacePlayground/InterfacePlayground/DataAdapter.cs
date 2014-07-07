using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePlayground
{
    public class DataAdapter:IDataForRender
    {
        public Presenter Fill()
        {
            string t = "Some title";
            var l = new DataSource().Members();
            return new Presenter(){Title = t, Members = l};
        }
    }
}
