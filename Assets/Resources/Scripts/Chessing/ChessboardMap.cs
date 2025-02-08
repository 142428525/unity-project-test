using System;
using UnityEngine;

public class ChessboardMap
{
	private readonly ChessingManager.ChessboardStyle style;
	private readonly 格子[,] map = new 格子[15, 15];

	public 格子 this[int x, int y]
	{
		get
		{
			return bound_check(x, y) ? map[x, y] :
				throw new IndexOutOfRangeException("Try to touch the unaccessible area on the chessboard.");
		}
	}

	public ChessboardMap(ChessingManager.ChessboardStyle style)
	{
		this.style = style;

		foreach (var item in map)
		{
			item.Initialize();
		}
	}

	public void 落子(int x, int y, GameObject gezi)
	{
		if (map[x, y].chessStat == 格子.Stat.Empty)
		{
			map[x, y].chessStat = 格子.Stat.Player;
			gezi.transform.Find(Constants.格子.CHILD_CHESS).gameObject.SetActive(true);

			格子[,] result = new 格子[8, 3];
			for (int idx = 0; idx < Constants.ChessboardMap.CHEBYSHEV_BASE.Length; idx++)
			{
				for (int i = 0; i < 3; i++)
				{
					var (xh, yh) = Constants.ChessboardMap.CHEBYSHEV_BASE[idx];
					格子 target = map[x + i * xh, y + i * yh];

					if (target.chessStat != 格子.Stat.Player)
					{
						break;
					}

					result[idx, i] = target;



					// todo: update
				}
			}
		}
	}

	private bool bound_check(int x, int y) => style switch
	{
		ChessingManager.ChessboardStyle.One =>
			(x is >= 0 and < 9) && (y is >= 0 and < 9),
		ChessingManager.ChessboardStyle.Two =>
			(x is >= 0 and < 15) && (y is >= 0 and < 9),
		ChessingManager.ChessboardStyle.Three =>
			(x is >= 0 and < 15) && (y is >= 0 and < 9) ||
			(x is >= 0 and < 9) && (y is >= 0 and < 15),
		ChessingManager.ChessboardStyle.Four =>
			(x is >= 0 and < 15) && (y is >= 0 and < 15),
		_ => throw new System.ArgumentOutOfRangeException(nameof(style),
			$"Invalid enum value '{style}'. Is this possible???")
	};
}