using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemiOdev
{
	public abstract class ListADT
	{
		public Node Head;
		public int Size = 0;
		public abstract void InsertFirst(object value);
		public abstract void InsertLast(object value);
		public abstract string DisplayElements();
	}
}
