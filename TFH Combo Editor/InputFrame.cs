using System;

public class InputFrame
{
	public int counter;
	public int direction;
	public int aState, bState, cState, dState;
	public bool a, b, c, d;
	public bool isSpecialFrame = false;

	public InputFrame()
	{
	}

	public InputFrame(int dir, bool a, bool b, bool c, bool d)
	{
		this.direction = dir;
		this.a = a;
		this.b = b;
		this.c = c;
		this.d = d;
	}
}
