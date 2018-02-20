using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
	public class OgrenciBilgi
	{
		public string ad { get; set; }
		public string sifre { get; set; }
		public string adres { get; set; }
		public string tel { get; set; }
		public string eposta { get; set; }
		public string uyruk { get; set; }
		public DateTime dogumTarihi { get; set; }
		public int ogrenciNo { get; set; }
		public string yabanciDil { get; set; }
		public string ilgiAlanlari { get; set; }
        public double BasariDerecesi { get; set; }
		public LinkedListStaj StajListesi { get; set; }
		public LinkedListMezun MezunBilgiListesi { get; set; }

		public OgrenciBilgi()
		{
			StajListesi = new LinkedListStaj();
			MezunBilgiListesi = new LinkedListMezun();
		}
	}
}

