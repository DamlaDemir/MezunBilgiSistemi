using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
	public class LinkedListStaj:ListADT
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
			StajBilgi s;
			while (item != null)
			{
				s = (StajBilgi)item.Data;
				temp +="Şireket Adı:"+ s.sirketAdi + " " +"Departman:"+ s.departman + " " + "Gorevi:"+s.gorev + " " +"Staj Tarihi:"+ s.stajTarihi.ToShortDateString()+Environment.NewLine;
				item = item.Next;
			}

			return temp;
		}
	}
}

