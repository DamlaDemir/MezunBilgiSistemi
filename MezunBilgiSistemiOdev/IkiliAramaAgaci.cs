using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
	public class IkiliAramaAgaci
	{
		private IkiliAramaAgacDugumu kok;
		private string dugumler;
		public string tempOrtalama="";
		public string advancedTemp = " ";
		public bool kilit = false;
		public int Yukseklik = -1;
		public IkiliAramaAgaci()
		{
		}
		public IkiliAramaAgaci(IkiliAramaAgacDugumu kok)
		{
			this.kok = kok;
		}
		public int DugumSayisi()
		{
			return DugumSayisi(kok);
		}
		public int DugumSayisi(IkiliAramaAgacDugumu dugum)
		{
			int count = 0;
			if (dugum != null)
			{
				count = 1;
				count += DugumSayisi(dugum.sol);
				count += DugumSayisi(dugum.sag);
			}
			return count;
		}
		

		public void PreOrder90()
		{
			Ziyaret90(kok);
		}


		private void Ziyaret90(IkiliAramaAgacDugumu dugum)
		{
			
			if (dugum == null)
				return;
			double notOrtalamasi = dugum.veri.MezunBilgiListesi.OrtalamaBul();
			if (notOrtalamasi != 0)
			{
				tempOrtalama += dugum.veri.ad +Environment.NewLine;
			}

			Ziyaret90(dugum.sol);
			Ziyaret90(dugum.sag);

		}

		public void OgrenciAdinaGoreAra(string ad, string sifre)
		{
			kilit = false;
			OgrenciAdinaGoreArama(kok, ad, sifre);

		}



		private void OgrenciAdinaGoreArama(IkiliAramaAgacDugumu dugum, string adi, string sifresi)
		{

			if (dugum == null)
				return;
			if (dugum.veri.ad == adi && dugum.veri.sifre == sifresi)
			{
				kilit = true;

			}
			else if (!kilit)
			{
				OgrenciAdinaGoreArama(dugum.sol, adi, sifresi);
				OgrenciAdinaGoreArama(dugum.sag, adi, sifresi);
			}

		}
		public string DugumleriYazdir()
		{
			return dugumler;
		}


		public void PreOrder()
		{
			dugumler = "";
			PreOrderInt(kok);
		}
		private void PreOrderInt(IkiliAramaAgacDugumu dugum)
		{
			if (dugum == null)
				return;
			Ziyaret(dugum);
			PreOrderInt(dugum.sol);
			PreOrderInt(dugum.sag);
		}
		
		public void InOrder()
		{
			dugumler = "";
			InOrderInt(kok);
		}
		private void InOrderInt(IkiliAramaAgacDugumu dugum)
		{
			if (dugum == null)
				return;
			InOrderInt(dugum.sol);
			Ziyaret(dugum);
			InOrderInt(dugum.sag);
		}
		private void Ziyaret(IkiliAramaAgacDugumu dugum)
		{
			dugumler += "Adı-Soyadı:"+dugum.veri.ad+" "+"Mezun Bilgileri--> "+ dugum.veri.MezunBilgiListesi.DisplayElements()+Environment.NewLine+Environment.NewLine;
		}
		public void PostOrder()
		{
			dugumler = "";
			PostOrderInt(kok);
		}
		private void PostOrderInt(IkiliAramaAgacDugumu dugum)
		{
			if (dugum == null)
				return;
			PostOrderInt(dugum.sol);
			PostOrderInt(dugum.sag);
			Ziyaret(dugum);
		}
		public void Ekle(OgrenciBilgi deger)
		{
			
			IkiliAramaAgacDugumu tempParent = new IkiliAramaAgacDugumu();
	
			IkiliAramaAgacDugumu tempSearch = kok;

			while (tempSearch != null)
			{
				tempParent = tempSearch;
				
				if (deger.ogrenciNo == tempSearch.veri.ogrenciNo)
					return;
				else if (deger.ogrenciNo < tempSearch.veri.ogrenciNo)
					tempSearch = tempSearch.sol;
				else
					tempSearch = tempSearch.sag;
			}
			IkiliAramaAgacDugumu eklenecek = new IkiliAramaAgacDugumu(deger);
		
			if (kok == null)
				kok = eklenecek;
			else if (deger.ogrenciNo < tempParent.veri.ogrenciNo)
				tempParent.sol = eklenecek;
			else
				tempParent.sag = eklenecek;

		}

		public IkiliAramaAgacDugumu OgrenciNumarasinaGoreAra(int anahtar)
		{
			return OgrenciNoAraInt(kok, anahtar);
		}
		private IkiliAramaAgacDugumu OgrenciNoAraInt(IkiliAramaAgacDugumu dugum,
											int anahtar)
		{
			if (dugum == null)
				return null;
			else if ((int)dugum.veri.ogrenciNo == anahtar)
				return dugum;
			else if ((int)dugum.veri.ogrenciNo > anahtar)
				return (OgrenciNoAraInt(dugum.sol, anahtar));
			else
				return (OgrenciNoAraInt(dugum.sag, anahtar));
		}
	

	

		private IkiliAramaAgacDugumu Successor(IkiliAramaAgacDugumu silDugum)
		{
			IkiliAramaAgacDugumu successorParent = silDugum;
			IkiliAramaAgacDugumu successor = silDugum;
			IkiliAramaAgacDugumu current = silDugum.sag;
			while (current != null)
			{
				successorParent = successor;
				successor = current;
				current = current.sol;
			}
			if (successor != silDugum.sag)
			{
				successorParent.sol = successor.sag;
				successor.sag = silDugum.sag;
			}
			return successor;
		}
		public bool Sil(int deger)
		{
			IkiliAramaAgacDugumu current = kok;
			IkiliAramaAgacDugumu parent = kok;
			bool issol = true;
			//DÜĞÜMÜ BUL
			while ((int)current.veri.ogrenciNo != deger)
			{
				parent = current;
				if (deger < (int)current.veri.ogrenciNo)
				{
					issol = true;
					current = current.sol;
				}
				else
				{
					issol = false;
					current = current.sag;
				}
				if (current == null)
					return false;
			}
			//DURUM 1: YAPRAK DÜĞÜM
			if (current.sol == null && current.sag == null)
			{
				if (current == kok)
					kok = null;
				else if (issol)
					parent.sol = null;
				else
					parent.sag = null;
			}
			//DURUM 2: TEK ÇOCUKLU DÜĞÜM
			else if (current.sag == null)
			{
				if (current == kok)
					kok = current.sol;
				else if (issol)
					parent.sol = current.sol;
				else
					parent.sag = current.sol;
			}
			else if (current.sol == null)
			{
				if (current == kok)
					kok = current.sag;
				else if (issol)
					parent.sol = current.sag;
				else
					parent.sag = current.sag;
			}
			//DURUM 3: İKİ ÇOCUKLU DÜĞÜM
			else
			{
				IkiliAramaAgacDugumu successor = Successor(current);
				if (current == kok)
					kok = successor;
				else if (issol)
					parent.sol = successor;
				else
					parent.sag = successor;
				successor.sol = current.sol;
			}
			return true;
		}

		

		 public IkiliAramaAgacDugumu OgrenciNumarasinaGoreGuncelle(OgrenciBilgi ogr)
		 {
			 return OgrenciNoGuncelle(kok, ogr);
		 }
		 private IkiliAramaAgacDugumu OgrenciNoGuncelle(IkiliAramaAgacDugumu dugum,
											 OgrenciBilgi ogr)
		 {

			  if ((int)dugum.veri.ogrenciNo == ogr.ogrenciNo)
			 {
				 dugum.veri = ogr;
				 return dugum;
			 }  
			 else if ((int)dugum.veri.ogrenciNo > ogr.ogrenciNo)
				 return (OgrenciNoGuncelle(dugum.sol, ogr));
			 else
				 return (OgrenciNoGuncelle(dugum.sag, ogr));
		 }

		public void PreOrderAdvanced()
		{
			ZiyaretAdvanced(kok);
		}

		
		private void ZiyaretAdvanced(IkiliAramaAgacDugumu dugum)
		{

			if (dugum == null)
				return;
		
			if (dugum.veri.yabanciDil== "Advanced")
			{
				advancedTemp +="Adı-Soyad:"+ dugum.veri.ad + Environment.NewLine;
			}

			ZiyaretAdvanced(dugum.sol);
			ZiyaretAdvanced(dugum.sag);

		}
		
        private void DerinlikBulInt(IkiliAramaAgacDugumu dugum)
		{
			if (dugum == null)
				return;
			else
			{
			    Yukseklik ++;
			     DerinlikBulInt(dugum.sol); //Düğümün solu oldukça sola git
				
				
			}
		}

		public void DerinlikBul()
		{
			 Yukseklik = -1;
			 DerinlikBulInt(kok);
		}
	}
}
