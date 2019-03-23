using System.Drawing;

namespace OOP_PaintKiller
{
	class Treangle : Figure
	{
		public int LeftX { set; get; }
		public int LeftY { set; get; }
		public int TopX { set; get; }
		public int TopY { set; get; }
		public int RightX { set; get; }
		public int RightY { set; get; }
		
		public override void SetCoord(int startX, int startY, int endX, int endY)
		{
			LeftX = startX;
			LeftY = endY;
			TopX =  startX + (endX - startX) / 2;
			TopY = startY;
			RightX = endX;
			RightY = endY;
		}

		public override void Draw(Graphics grph, Pen pen)
		{
			grph.DrawLine(pen, LeftX, LeftY, TopX, TopY);
			grph.DrawLine(pen, TopX, TopY, RightX, RightY);
			grph.DrawLine(pen, RightX, RightY, LeftX, LeftY);
		}
	}
}
