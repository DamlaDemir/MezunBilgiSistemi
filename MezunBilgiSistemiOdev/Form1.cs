using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace MezunBilgiSistemiOdev
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
        LinkedListSirket ls = new LinkedListSirket();
        IkiliAramaAgaci aramaAgaci = new IkiliAramaAgaci();
        HashMapChain hm = new HashMapChain();
		IkiliAramaAgacDugumu aramaDugum = new IkiliAramaAgacDugumu();

        public double BasariDerecesiHesapla(double ortalama, bool basariBelgesi)
        {
            if (basariBelgesi)
                ortalama += 10;
            return ortalama;

        }

		private void Form1_Load(object sender, EventArgs e)
		{
            Assembly a = Assembly.GetExecutingAssembly();
            Stream stream = a.GetManifestResourceStream("MezunBilgiSistemiOdev.Resources.OgrenciBilgi.txt");
            StreamReader oku = new StreamReader(stream);

     
         string yazi;

         while ((yazi = oku.ReadLine()) != null)
         {
             MezunBilgi mb = new MezunBilgi();
             StajBilgi sb = new StajBilgi();
             OgrenciBilgi o = new OgrenciBilgi();
             o.ad = yazi;
             yazi = oku.ReadLine();
             o.adres = yazi;
             yazi = oku.ReadLine();
             o.tel = yazi;
             yazi = oku.ReadLine();
             o.eposta = yazi;
             yazi = oku.ReadLine();
             o.uyruk = yazi;
             yazi = oku.ReadLine();
             o.dogumTarihi = Convert.ToDateTime(yazi);
             yazi = oku.ReadLine();
             o.ogrenciNo = Convert.ToInt32(yazi);
             yazi = oku.ReadLine();
             o.yabanciDil = yazi;
             yazi = oku.ReadLine();
             o.ilgiAlanlari = yazi;
             yazi = oku.ReadLine();
             sb.sirketAdi = yazi;
             yazi = oku.ReadLine();
             sb.stajTarihi = Convert.ToDateTime(yazi);
             yazi = oku.ReadLine();
             sb.departman = yazi;
             yazi = oku.ReadLine();
             sb.gorev = yazi;
             yazi = oku.ReadLine();
             if (yazi == "Yazilim Muhendisligi")
                 mb.bolumAdi = "Yazılım Mühendisliği";
             else if (yazi == "Makina ve Imalat Muhendisligi") 
             mb.bolumAdi = "Makina ve İmalat Mühendisliği";
             else if(yazi== "Enerji Sistemleri Muhendisligi")
             mb.bolumAdi="Enerji Sistemleri Mühendisliği";
             yazi = oku.ReadLine();
             mb.baslangicYili = yazi;
             yazi = oku.ReadLine();
             mb.bitisYili = yazi;
             yazi = oku.ReadLine();
             mb.notOrtalamasi = Convert.ToDouble(yazi);
             yazi = oku.ReadLine();
             mb.basariBelgesi = Convert.ToBoolean(yazi);
			yazi = oku.ReadLine();
			o.BasariDerecesi = Convert.ToDouble(yazi);
			yazi = oku.ReadLine();
			o.sifre = yazi;

			 o.StajListesi.InsertLast(sb);
             o.MezunBilgiListesi.InsertLast(mb);
             hm.Add(mb.bolumAdi, o);
             aramaAgaci.Ekle(o);
              

         }

			aramaAgaci.PreOrder90();
			 txt90Ustu.Text= aramaAgaci.tempOrtalama;
			tb1.TabPages.Remove(tbpAnasayfa);
			tb1.TabPages.Remove(tbpGuncelle);


		}
		private void btnGiris_Click(object sender, EventArgs e)
		{
			aramaAgaci.OgrenciAdinaGoreAra(txtGirisKulAdi.Text, txtGirisSifre.Text);
			bool kayitliMi = aramaAgaci.kilit;
			if (kayitliMi)
			{
				MessageBox.Show("Başırılı bir şekilde giriş yaptınız");
				lblHosgeldin.Text += " " + txtGirisKulAdi.Text;
                tb1.TabPages.Insert(2, tbpAnasayfa);
                tb1.TabPages.Insert(3, tbpGuncelle);
                tb1.SelectedIndex = 2;
            } 
			else if (!kayitliMi)
			{
				if (ls.AdaGoreAra(txtGirisKulAdi.Text, txtGirisSifre.Text))
				{
					MessageBox.Show("Başarılı bir şekilde giriş yaptınız");
					lblHosgeldin.Text += " " + txtGirisKulAdi.Text;
                    tb1.TabPages.Insert(2, tbpAnasayfa);
                    tb1.TabPages.Insert(3, tbpGuncelle);
                    tb1.SelectedIndex = 2;
                }
				else
					MessageBox.Show("Hatalı giriş");
			}

			txtGirisKulAdi.Text = "";
			txtGirisSifre.Text = "";
			



		}

        private void btnİsverenKayit_Click(object sender, EventArgs e)
        {
            Sirket s = new Sirket();
            s.sirketAdi = txtSirketAdi.Text;
            s.adres = txtSirketAdres.Text;
            s.eposta = txtSirketePosta.Text;
            s.tel = txtSirketTel.Text;
            s.sifre = txtSirketKayitSifre.Text;
            ls.InsertLast(s);
			MessageBox.Show("Başarılı Bir Şekilde Kayıt Yaptınız");
			txtSirketAdi.Text = "";
			txtSirketAdres.Text= "";
		    txtSirketePosta.Text="";
			txtSirketTel.Text = "";
			txtSirketKayitSifre.Text="";
		}

        private void btnMezunKayit_Click(object sender, EventArgs e)
        {
            OgrenciBilgi o = new OgrenciBilgi();
            MezunBilgi mb = new MezunBilgi();
            StajBilgi sb = new StajBilgi();

            o.ad = txtOgrenciAd.Text;
            o.adres = txtOgrAdres.Text;
            o.dogumTarihi = Convert.ToDateTime(dtPDogumTarihi.Value);
            o.eposta = txtOgrePosta.Text;
            o.ilgiAlanlari = txtIlgiAlanları.Text;
            o.ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text);
            o.sifre = txtOgrKayitSifre.Text;
            o.tel = txtOgrTel.Text;
            o.uyruk = cbUyruk.SelectedItem.ToString();
            o.yabanciDil = cbYabanciDil.SelectedItem.ToString();
            mb.baslangicYili = txtBaslangicYili.Text;
            mb.bitisYili = txtBitisYili.Text;
            if (rbEvet.Checked)
                mb.basariBelgesi = true;
            else if (rbHayir.Checked)
                mb.basariBelgesi = false;
            mb.bolumAdi = cbBolumAdi.SelectedItem.ToString();
            mb.notOrtalamasi = Convert.ToDouble(txtNotOrtalamasi.Text);
            o.MezunBilgiListesi.InsertLast(mb);
            sb.departman = txtDepartman.Text;
            sb.gorev = txtGorev.Text;
            sb.sirketAdi = txtStajSirketi.Text;
            sb.stajTarihi = Convert.ToDateTime(stPStajTarihi.Value);
            o.BasariDerecesi = BasariDerecesiHesapla(mb.notOrtalamasi, mb.basariBelgesi);
            o.StajListesi.InsertLast(sb);
            o.MezunBilgiListesi.InsertLast(mb);
            aramaAgaci.Ekle(o);
            hm.Add(mb.bolumAdi, o);
			MessageBox.Show("Başarılı Bir Şekilde Kayıt Yaptınız");
			txtOgrenciAd.Text= "";
			txtOgrAdres.Text=" ";
			txtOgrePosta.Text=" ";
			txtIlgiAlanları.Text=" ";
			txtOgrenciNo.Text = " ";
			txtOgrKayitSifre.Text = " ";
			txtOgrTel.Text = " ";
			txtBaslangicYili.Text = " ";
			txtBitisYili.Text="";
			txtNotOrtalamasi.Text = "";
			txtDepartman.Text = " ";
			txtGorev.Text=" ";
			txtStajSirketi.Text = " ";
        }

		private void btnKayitSil_Click(object sender, EventArgs e)
		{
			OgrenciBilgi o = new OgrenciBilgi();
			o.ogrenciNo = Convert.ToInt32(txtSilinecekOgrenciNo.Text);
			
			aramaDugum = aramaAgaci.OgrenciNumarasinaGoreAra(Convert.ToInt32(txtSilinecekOgrenciNo.Text));
			aramaAgaci.Sil(o.ogrenciNo);
			string anahtar=aramaDugum.veri.MezunBilgiListesi.BolumBul();
			int x = hm.hashFonksiyonu(anahtar, 3);
			hm.table[x].h.ElemanSil(aramaDugum.veri);
			MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi");
			txtSilinecekOgrenciNo.Text = "";

		}

		private void btnGuncelle_Click(object sender, EventArgs e)
		{
			OgrenciBilgi o = new OgrenciBilgi();
			MezunBilgi mb = new MezunBilgi();
			StajBilgi sb = new StajBilgi();
			o.ad = txtGuncelAdSoyad.Text;
			o.adres = txtGuncelAdres.Text;
			o.dogumTarihi = Convert.ToDateTime(dtpGuncelDogumTarihi.Value);
			o.eposta = txtGuncelEposta.Text;
			o.ilgiAlanlari = txtGuncelIlgiAlanlari.Text;
			o.ogrenciNo = Convert.ToInt32(txtGuncelOgrenciNo.Text);
			o.sifre = txtGuncelSifre.Text;
			o.tel = txtGuncelTelefon.Text;
			o.uyruk = cbGuncelUyruk.SelectedItem.ToString();
			o.yabanciDil = cbGuncelYabanciDil.SelectedItem.ToString();
			mb.baslangicYili = txtGuncelBaslangicYili.Text;
			mb.bitisYili = txtGuncelBitisYili.Text;
			if (rbGuncelEvet.Checked)
				mb.basariBelgesi = true;
			else if (rbGuncelHayir.Checked)
				mb.basariBelgesi = false;
			mb.bolumAdi = cbGuncelBolumAdi.SelectedItem.ToString();
			mb.notOrtalamasi = Convert.ToDouble(txtGuncelNotOrtalamasi.Text);
			o.MezunBilgiListesi.InsertLast(mb);
			sb.departman = txtGuncelDepartman.Text;
			sb.gorev = txtGuncelGorev.Text;
			sb.sirketAdi = txtGuncelSirketAdi.Text;
			sb.stajTarihi = Convert.ToDateTime(dtpGuncelStajTarihi.Value);
			o.BasariDerecesi = BasariDerecesiHesapla(mb.notOrtalamasi, mb.basariBelgesi);
			o.StajListesi.InsertLast(sb);
			o.MezunBilgiListesi.InsertLast(mb);
			aramaAgaci.OgrenciNumarasinaGoreGuncelle(o);
			int x=hm.hashFonksiyonu(mb.bolumAdi, 3);
			hm.OgrenciGuncelle(hm.table[x].h,o);

			MessageBox.Show("Güncelleme İşlemi Tamamlandı");
		}

		private void btnEnUygunMezunuBul_Click(object sender, EventArgs e)
		{
			OgrenciBilgi o = new OgrenciBilgi();
			string anahtar = cbEnUygunMezun.SelectedItem.ToString();
			int x = hm.hashFonksiyonu(anahtar, 3);
			o = hm.table[x].h.MaxHeapGetir();
			txtEnUygunMezun.Text = "Adı:"+o.ad + " " +"Başarı Derecesi:"+ o.BasariDerecesi + " " +"Telefonu:"+ o.tel + " " + "Yabancı Dili:"+o.yabanciDil;
        }

		private void btnYabanciDileGore_Click(object sender, EventArgs e)
		{
			string yabanciDil = "";
			string yd = cbYabanciDileGore.SelectedItem.ToString();
			for (int i = 0; i < 3; i++)
			{
			yabanciDil+=hm.table[i].h.YabanciDileGoreListele(yd);
			}

			txtYabanciDileGore.Text = yabanciDil;
		}

		private void btnOgrenciNoGore_Click(object sender, EventArgs e)
		{
			int ogrNo;
			IkiliAramaAgacDugumu dugum;
			ogrNo = Convert.ToInt32(txtOgrenciNoGore.Text);
			dugum= aramaAgaci.OgrenciNumarasinaGoreAra(ogrNo);

			txtOgrenciNoyaGore.Text = "Adı-Soyadı:"+dugum.veri.ad+" "+"Doğum Tarihi:" + dugum.veri.dogumTarihi.ToShortDateString() + "Adresi:"+dugum.veri.adres+" "+"E-posta:"+dugum.veri.eposta+" "+
				"Telefon Numarası:"+dugum.veri.tel+" "+"Mezun Bilgileri--> " + dugum.veri.MezunBilgiListesi.DisplayElements() +" "+"Başarı Derecesi:"+dugum.veri.BasariDerecesi +" "+"Staj Bilgileri--> " + dugum.veri.StajListesi.DisplayElements() + Environment.NewLine;


		}

		private void btnBolumeGoreAra_Click(object sender, EventArgs e)
		{
			string anahtar = cbBolumAra.SelectedItem.ToString();
			int x=hm.hashFonksiyonu(anahtar, 3);
			txtBolumeGore.Text= hm.table[x].h.DisplayHeap();
		}

		private void btnAdvencedDuzeyeGoreAra_Click(object sender, EventArgs e)
		{
			aramaAgaci.PreOrderAdvanced();
			txtAdvencedDuzeyeGore.Text=aramaAgaci.advancedTemp;
		}

		private void btnPreOrder_Click(object sender, EventArgs e)
		{
			aramaAgaci.PreOrder();
			txtListeleme.Text = aramaAgaci.DugumleriYazdir();
		}

		private void btnInOrder_Click(object sender, EventArgs e)
		{
			aramaAgaci.InOrder();
			txtListeleme.Text = aramaAgaci.DugumleriYazdir();

		}

		private void btnPostOrder_Click(object sender, EventArgs e)
		{
			aramaAgaci.PostOrder();
			txtListeleme.Text = aramaAgaci.DugumleriYazdir();
		}

		private void btnDerinlikBul_Click(object sender, EventArgs e)
		{
			  aramaAgaci.DerinlikBul();
		     lblDerinlik.Text = "Ağacın derinliği:" + aramaAgaci.Yukseklik;
		}

		private void btnElemanSayisi_Click(object sender, EventArgs e)
		{
			lblElemanSayisi.Text = "Ağacın Eleman Sayısı:"+aramaAgaci.DugumSayisi().ToString();
		}

		private void lblBilgileriGuncelle_Click(object sender, EventArgs e)
		{
			tb1.SelectedIndex = 3;
		}

		private void label30_Click(object sender, EventArgs e)
		{
			tb1.SelectedIndex = 3;
		}
	}
}
