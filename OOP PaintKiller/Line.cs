using System;

namespace OOP_PaintKiller
{
	class Line : Figure
	{
		public int LeftX { set; get; }
		public int LeftY { set; get; }
		public int RightX { set; get; }
		public int RightY { set; get; }

		public Line() { }

		public Line(int leftX, int leftY, int rightX, int rightY)
		{
			LeftX = leftX;
			LeftY = leftY;
			RightX = rightX;
			RightY = rightY;
		}

		public override void Draw()	{	}
	}
}
