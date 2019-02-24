using System;

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

		public Treangle() { }

		public Treangle(int leftX, int leftY, int topX, int topY, int rightX, int rightY)
		{
			LeftX = leftX;
			LeftY = leftY;
			TopX = topX;
			TopY = topY;
			RightX = rightX;
			RightY = rightY;
		}

		public override void Draw() { }
	}
}
