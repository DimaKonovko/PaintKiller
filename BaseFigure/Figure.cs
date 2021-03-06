﻿using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace BaseFigure
{
	public abstract class Figure
	{
		public virtual void Draw(Graphics grph, Pen pen) { }
		public virtual void SetCoord(Point startPoint, Point endPoint) { }
		public virtual void SetCoord(int[] fields) { }
		public virtual void SetList(List<Figure> figures) { }
		public virtual void Recalculate(float percentX, float percentY, int pX, int pY) { }
		public virtual Figure MyClone() { return (Figure)this.MemberwiseClone(); }

			   
		public List<Figure> MyCopy(List<Figure> figures)
		{
			List<Figure> copiedList = new List<Figure>();
			foreach (Figure fig in figures)
			{
				copiedList.Add(fig.MyClone());
			}
			return copiedList;
		}



		public virtual string ToText()
		{
			string textName = this.GetType().Name;
			string textFields = string.Empty;

			PropertyInfo[] fields = this.GetType().GetProperties();
			foreach (PropertyInfo field in fields)
			{
				textFields += field.Name + ":" + field.GetValue(this) + " ";
			}

			return textName + " | " + textFields + "\n";
		}
	}
}
 