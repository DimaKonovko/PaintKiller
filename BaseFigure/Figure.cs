using System.Collections.Generic;
using System.Drawing;

namespace BaseFigure
{
	public abstract class Figure
	{
		abstract public void SetCoord(Point startPoint, Point endPoint);
		abstract public void SetCoord(int[] fields);
		abstract public void Draw(Graphics grph, Pen pen);

		public virtual void SetList(List<Figure> figures) { }
	}
}
 