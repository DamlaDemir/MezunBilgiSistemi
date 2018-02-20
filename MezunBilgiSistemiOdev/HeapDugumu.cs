using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
    public class HeapDugumu
    {
        public OgrenciBilgi ogr { get; set; }
        public HeapDugumu(OgrenciBilgi o)
        {
            this.ogr = o;
        }
    }
}
