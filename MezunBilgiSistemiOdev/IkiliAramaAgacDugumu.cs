using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
	
		public class IkiliAramaAgacDugumu
		{
			public OgrenciBilgi veri;
			public IkiliAramaAgacDugumu sol;
			public IkiliAramaAgacDugumu sag;

			public IkiliAramaAgacDugumu()
			{
			}

			public IkiliAramaAgacDugumu(OgrenciBilgi ogr)
			{
				this.veri = ogr;
				sol = null;
				sag = null;
			}
		}
	}

