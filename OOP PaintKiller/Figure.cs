using System.Drawing;

namespace OOP_PaintKiller
{
	class Figure
	{
		public virtual void SetCoord(int startX, int startY, int endX, int endY) { }
		public virtual void Draw(Graphics grph, Pen pen) { }
	}
}
 