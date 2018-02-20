using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
	public class LinkedListMezun:ListADT
	{
		public override void InsertFirst(object value)
		{

			Node tmpHead = new Node
			{
				Data = value
			};



			if (Head == null)
				Head = tmpHead;
			else
			{
	
				tmpHead.Next = Head;
				Head = tmpHead;
			}
			Size++;
		}

		public override void InsertLast(object value)
		{

			Node oldLast = Head;

			if (Head == null)
				InsertFirst(value);
			else
			{

				Node newLast = new Node
				{
					Data = value
				};

				while (oldLast != null)
				{
					if (oldLast.Next != null)
						oldLast = oldLast.Next;
					else
						break;
				}


				oldLast.Next = newLast;
				Size++;
			}
		}

		public override string DisplayElements()
		{
			string temp = "";
			Node item = Head;
			MezunBilgi m;
			while (item != null)
			{
				m = (MezunBilgi)item.Data;
				temp += "Bolüm Adı:" + m.bolumAdi + " " + "Başlangıç Yılı:" + m.baslangicYili + " " + "Bitiş Yılı:" + m.bitisYili + " " + "Not Ortalaması:" + m.notOrtalamasi + " ";
				if(m.basariBelgesi)
					temp+="Başarı Belgesi:" + "Evet";
				else
					temp+="Başarı Belgesi:" + "Hayır";
				item = item.Next;
			}

			return temp;
		}

		public double OrtalamaBul()
		{
			double temp = 0;
			Node item = Head;
			MezunBilgi m;
			while (item != null)
			{
				m = (MezunBilgi)item.Data;
				if (m.notOrtalamasi >= 90)
				{
					temp = m.notOrtalamasi;
					break;
				}
				
				item = item.Next;
			}

			return temp;
		}

		public string BolumBul()
		{
			string temp = " ";
			Node item = Head;
			MezunBilgi m;
			while (item != null)
			{
				    m = (MezunBilgi)item.Data;
	 
					temp = m.bolumAdi;
					break;
				
				  item = item.Next;
			}

			return temp;

		}
	}
}

