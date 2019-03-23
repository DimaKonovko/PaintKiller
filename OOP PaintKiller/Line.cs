using System.Drawing;

namespace OOP_PaintKiller
{
	class Line : Figure
	{
		public int LeftX { set; get; }
		public int LeftY { set; get; }
		public int RightX { set; get; }
		public int RightY { set; get; }
		
		public override void SetCoord(int startX, int startY, int endX, int endY)
		{
			LeftX = startX;
			LeftY = startY;
			RightX = endX;
			RightY = endY;
		}

		public override void Draw(Graphics grph, Pen pen)
		{
			grph.DrawLine(pen, LeftX, LeftY, RightX, RightY);
		}
	}
}
