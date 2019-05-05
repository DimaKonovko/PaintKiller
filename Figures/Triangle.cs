using System.Drawing;
using BaseFigure;

namespace Figures
{
	public class TriangleKiller : Figure
	{
		public int LeftX  { set; get; }
		public int LeftY  { set; get; }
		public int TopX   { set; get; }
		public int TopY   { set; get; }
		public int RightX { set; get; }
		public int RightY { set; get; }
		


		public override void SetCoord(Point start, Point end)
		{
			LeftX  = start.X;
			LeftY  = end.Y;
			TopX   = start.X + (end.X - start.X) / 2;
			TopY   = start.Y;
			RightX = end.X;
			RightY = end.Y;
		}



		public override void SetCoord(int[] fields)
		{
			LeftX  = fields[0];
			LeftY  = fields[1];
			TopX   = fields[2];
			TopY   = fields[3];
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
