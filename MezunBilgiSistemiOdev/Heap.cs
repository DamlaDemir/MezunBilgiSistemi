using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
    public class Heap
    {
        public HeapDugumu[] heapArray;
        private int maxSize;
        public int currentSize;
        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            heapArray = new HeapDugumu[maxSize];
        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
		
        public bool Insert(OgrenciBilgi o)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(o);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            while (index > 0 && heapArray[parent].ogr.BasariDerecesi < bottom.ogr.BasariDerecesi)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public HeapDugumu RemoveMax() 
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            return root;
        }
		public OgrenciBilgi MaxHeapGetir() 
		{
			return heapArray[0].ogr;
		}
		public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
            
                if (rightChild < currentSize && heapArray[leftChild].ogr.BasariDerecesi < heapArray[rightChild].ogr.BasariDerecesi)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.ogr.BasariDerecesi >= heapArray[largerChild].ogr.BasariDerecesi)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
        public string DisplayHeap()
        {
            string temp = "";
           
			for (int m = 0; m < currentSize; m++)
			{
				if (heapArray[m] != null)
					temp += "Adı-Soyadı:"+(heapArray[m].ogr.ad + " " +"Adresi:"+ heapArray[m].ogr.adres+" " +"Doğum Tarihi:"+heapArray[m].ogr.dogumTarihi.ToShortDateString()+ " "
						+"E-posta:"+heapArray[m].ogr.eposta+" "+"Telefon Numarası:"+ heapArray[m].ogr.tel+" "+ "İlgi Alanları:"+ heapArray[m].ogr.ilgiAlanlari+ " "+"Staj Bilgileri--> "+ heapArray[m].ogr.StajListesi.DisplayElements()+" "+
					"Mezun Bilgileri--> "+	heapArray[m].ogr.MezunBilgiListesi.DisplayElements())+Environment.NewLine+Environment.NewLine;
                else
                    temp += ("-- ");
            }
            return temp;


        } 

		public string YabanciDileGoreListele(string yabanciDil)
		{
			string temp = "";
			
			for (int m = 0; m < currentSize; m++)
			{
				if (heapArray[m] != null && heapArray[m].ogr.yabanciDil == yabanciDil)
					temp += "Adı-Soyadı:" + heapArray[m].ogr.ad + " " + "Adresi:" + heapArray[m].ogr.adres + " " + "Doğum Tarihi:" + heapArray[m].ogr.dogumTarihi.ToShortDateString() + " "
						+ "E-posta:" + heapArray[m].ogr.eposta + " " + "Telefon Numarası:"+ heapArray[m].ogr.tel + Environment.NewLine ;
				
			}

			return temp;
		}
		public HeapDugumu ElemanSil(OgrenciBilgi o)
		{
			int indis = 0;
			for (int i = 0; i < heapArray.Length; i++)
			{
				if (heapArray[i].ogr.ogrenciNo == o.ogrenciNo)
				{
					indis = i;
					break;
				}
			}
			HeapDugumu root = heapArray[indis];
			heapArray[indis] = heapArray[--currentSize];
			MoveToDown(indis);
			return root;
		}

		

	
	}
}
