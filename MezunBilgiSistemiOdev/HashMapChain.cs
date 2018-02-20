using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
    public class HashMapChain
    {
        public HashEntry[] table;
        Heap h;

        public HashMapChain()
        {
            table = new HashEntry[3];
            for (int i = 0; i < 3; i++)
            {
                table[i] = null;
            }
        }

        public void Add(string key, OgrenciBilgi value)
        {
            int hash = hashFonksiyonu(key, 3);
            if (table[hash] == null)
            {
                table[hash] = new HashEntry(key);
                table[hash].h = new Heap(100);
                table[hash].h.Insert(value);
            }
            else
            {
                table[hash].h.Insert(value);
            }

        }
     
        public int hashFonksiyonu(string key, int tableSize)
        {

            int sonuc=0;
     
            int hashVal = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hashVal += key[i];

            }
            sonuc = hashVal % tableSize;
         return sonuc;
        }

		public void OgrenciGuncelle(Heap h,OgrenciBilgi ogr)
		{
			for (int i = 0; i <h.currentSize; i++)
			{
				if (h.heapArray[i].ogr.ogrenciNo == ogr.ogrenciNo)
					h.heapArray[i].ogr = ogr;
			}
		}
    }
}
