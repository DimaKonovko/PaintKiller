using System.Drawing;
using BaseFigure;

namespace Figures
{
	public class EllipseKiller : Figure
	{
		public int LeftTopX { set; get; }
		public int LeftTopY { set; get; }
		public int RightBottomX { set; get; }
		public int RightBottomY { set; get; }

		public override void SetCoord(int startX, int startY, int endX, int endY)
		{
			LeftTopX = startX;
			LeftTopY = startY;
			RightBottomX = endX;
			RightBottomY = endY;
		}

		public override void SetCoord(int[] fields)
		{
			LeftTopX = fields[0];
			LeftTopY = fields[1];
			RightBottomX = fields[2];
			RightBottomY = fields[3];
		}

		public override void Draw(Graphics grph, Pen pen)
		{
			grph.DrawEllipse(pen, LeftTopX, LeftTopY, RightBottomX - LeftTopX, RightBottomY - LeftTopY);
		}
	}
}
