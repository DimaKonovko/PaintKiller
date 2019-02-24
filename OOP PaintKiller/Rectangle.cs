using System;

namespace OOP_PaintKiller
{
	class Rectangle : Figure
	{
		public int LeftTopX { set; get; }
		public int LeftTopY { set; get; }
		public int RightBottomX { set; get; }
		public int RightBottomY { set; get; }

		public Rectangle() { }

		public Rectangle(int leftTopX, int leftTopY, int rightBottomX, int rightBottomY)
		{
			LeftTopX = leftTopX;
			LeftTopY = leftTopY;
			RightBottomX = rightBottomX;
			RightBottomY = rightBottomY;
		}

		public override void Draw() { }
	}
}
