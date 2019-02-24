using System;

namespace OOP_PaintKiller
{
	class Circle : Figure
	{
		public int Radius { set; get; }
		public int CenterX { set; get; }
		public int CenterY { set; get; }

		public Circle() { }

		public Circle(int x, int y, int radius)
		{
			CenterX = x;
			CenterY = y;
			Radius = radius;
		}

		public override void Draw() { }
	}
}
