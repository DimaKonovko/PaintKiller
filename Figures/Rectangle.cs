using System.Drawing;
using System;
using BaseFigure;

namespace Figures
{
	public class RectangleKiller : Figure, IFigures
	{
		public int LeftTopX     { set; get; }
		public int LeftTopY     { set; get; }
		public int RightBottomX { set; get; }
		public int RightBottomY { set; get; }
	


		public override void SetCoord(Point start, Point end)
		{
			LeftTopX     = start.X;
			LeftTopY     = start.Y;
			RightBottomX = end.X;
			RightBottomY = end.Y;
		} 



		public override void SetCoord(int[] fields)
		{
			LeftTopX     = fields[0];
			LeftTopY     = fields[1];
			RightBottomX = fields[2];
			RightBottomY = fields[3];
		}



		public override void Draw(Graphics grph, Pen pen)
		{
			int temp;
			if (RightBottomX < LeftTopX)
			{
				temp = LeftTopX;
				LeftTopX = RightBottomX;
				RightBottomX = temp;
			}
			if (RightBottomY < LeftTopY)
			{
				temp = LeftTopY;
				LeftTopY = RightBottomY;
				RightBottomY = temp;
			}
			grph.DrawRectangle(pen, LeftTopX, LeftTopY, Math.Abs(RightBottomX - LeftTopX), Math.Abs(RightBottomY - LeftTopY));
		}
	}
}
