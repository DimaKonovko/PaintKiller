using System.Drawing;
using BaseFigure;

namespace Figures
{
	public class LineKiller : Figure, IFigure
	{
		public int LeftX  { set; get; }
		public int LeftY  { set; get; }
		public int RightX { set; get; }
		public int RightY { set; get; }



		public override void SetCoord(Point start, Point end)
		{
			LeftX  = start.X;
			LeftY  = start.Y;
			RightX = end.X;
			RightY = end.Y;
		}



		public override void SetCoord(int[] fields)
		{
			LeftX  = fields[0];
			LeftY  = fields[1];
			RightX = fields[2];
			RightY = fields[3];
		}



		public override void Draw(Graphics grph, Pen pen)
		{
			grph.DrawLine(pen, LeftX, LeftY, RightX, RightY);
		}
	}
}
