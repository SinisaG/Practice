using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePlayground
{
    public class Renderer
    {
        private IDataForRender _data;
        public Renderer(IDataForRender data)
        {
            _data = data;
        }

        public Renderer() : this(new DataAdapter())
        {
        }

        public void Render()
        {
            var display = _data.Fill(); 
            Console.WriteLine();
            Console.WriteLine("Members of {0}", display.Title);
            Console.WriteLine();
            foreach (var m in display.Members)
            {
                Console.WriteLine(m);
            }
        }

    }
}
