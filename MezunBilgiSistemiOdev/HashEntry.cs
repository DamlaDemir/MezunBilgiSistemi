using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
    public class HashEntry
    {
        public string anahtar { get; set; }
        public Heap h;

        public HashEntry(string anahtar)
        {
            this.anahtar = anahtar;
        }
    }
}
