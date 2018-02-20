using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
    public class LinkedListSirket:ListADT
    {
		public bool AdaGoreAra(string ad, string sifresi)
		{
			bool kilit = false;
			Sirket s;
			Node oldLast = Head;

			while (oldLast != null)
			{
				s = (Sirket)oldLast.Data;
				if (s.sirketAdi == ad && s.sifre == sifresi)
				{
					kilit = true;
					break;
				}

				oldLast = oldLast.Next;

			}

			return kilit;
		}
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
            while (item != null)
            {
                temp += "-->" + item.Data;
                item = item.Next;
            }

            return temp;
        }
    }
}
