using System.Drawing;

namespace Figures
{
	abstract class Figure
	{
		abstract public void SetCoord(int startX, int startY, int endX, int endY);
		abstract public void SetCoord(int[] fields);
		abstract public void Draw(Graphics grph, Pen pen);
	}
}
 