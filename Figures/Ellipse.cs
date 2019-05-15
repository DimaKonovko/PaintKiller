using System.Drawing;
using BaseFigure;

namespace Figures
{
	public class EllipseKiller : Figure, IFigure
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
			grph.DrawEllipse(pen, LeftTopX, LeftTopY, RightBottomX - LeftTopX, RightBottomY - LeftTopY);
		}
	}
}
