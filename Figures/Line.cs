using System.Drawing;
using BaseFigure;

namespace Figures
{
	public class LineKiller : Figure
	{
		public int LeftX { set; get; }
		public int LeftY { set; get; }
		public int RightX { set; get; }
		public int RightY { set; get; }



		public override void SetCoord(int startX, int startY, int endX, int endY)
		{
			LeftX = startX;
			LeftY = startY;
			RightX = endX;
			RightY = endY;
		}



		public override void SetCoord(int[] fields)
		{
			LeftX = fields[0];
			LeftY = fields[1];
			RightX = fields[2];
			RightY = fields[3];
		}



		public override void Draw(Graphics grph, Pen pen)
		{
			grph.DrawLine(pen, LeftX, LeftY, RightX, RightY);
		}
	}
}
