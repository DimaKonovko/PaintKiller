using BaseFigure;
using System.Collections.Generic;
using System.Drawing;


namespace OOP_PaintKiller
{
	class DrawingController
	{
		Bitmap bitmap;
		Graphics grph;
		Pen pen;

		public Point startPoint, endPoint; 

		public void InitializeGraphics(int width, int height)
		{
			bitmap = new Bitmap(width, height);
			grph = Graphics.FromImage(bitmap);
			pen = new Pen(Color.Black);
			pen.Width = 3.0F;
		}



		public Bitmap Redraw(List<Figure> figures)
		{
			grph.Clear(Color.White);

			foreach (Figure fig in figures)
			{
				fig.Draw(grph, pen);
			}
			return bitmap;
		}



		public void SaveStartPoint(int x, int y)
		{
			this.startPoint.X = x;
			this.startPoint.Y = y;
		}



		public void SaveEndPoint(int x, int y)
		{
			this.endPoint.X = x;
			this.endPoint.Y = y;
		}



		public int[] Coordinates()
		{
			int[] coordinates = new int[] { startPoint.X, startPoint.Y, endPoint.X, endPoint.Y };
			return coordinates;
		}
	}
}
