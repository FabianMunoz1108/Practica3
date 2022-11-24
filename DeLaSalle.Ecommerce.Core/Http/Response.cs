using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSalle.Ecommerce.Core.Http
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Messafe { get; set; } = "";
        public List<string> Errors { get; set; } = new List<string>();
    }
}
