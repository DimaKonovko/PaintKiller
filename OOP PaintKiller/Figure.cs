﻿using System.Drawing;

namespace OOP_PaintKiller
{
	abstract class Figure
	{
		//public bool Public { get; set; }
		abstract public void SetCoord(int startX, int startY, int endX, int endY);
		abstract public void SetCoord(int[] fields);
		abstract public void Draw(Graphics grph, Pen pen);
	}
}
 