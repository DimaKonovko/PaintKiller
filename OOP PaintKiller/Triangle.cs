using System.Drawing;

namespace OOP_PaintKiller
{
	class Triangle : Figure
	{
		public int LeftX { set; get; }
		public int LeftY { set; get; }
		public int TopX { set; get; }
		public int TopY { set; get; }
		public int RightX { set; get; }

		private int rightY;

		public int RightY { set { rightY = value; } get { return rightY; } }
		
		public override void SetCoord(int startX, int startY, int endX, int endY)
		{
			LeftX = startX;
			LeftY = endY;
			TopX =  startX + (endX - startX) / 2;
			TopY = startY;
			RightX = endX;
			RightY = endY;
		}

		public override void SetCoord(int[] fields)
		{
			LeftX = fields[0];
			LeftY = fields[1];
			TopX = fields[2];
			TopY = fields[3];
			RightX = fields[4];
			RightY = fields[5];
		}

		public override void Draw(Graphics grph, Pen pen)
		{
			grph.DrawLine(pen, LeftX, LeftY, TopX, TopY);
			grph.DrawLine(pen, TopX, TopY, RightX, RightY);
			grph.DrawLine(pen, RightX, RightY, LeftX, LeftY);
		}
	}
}
