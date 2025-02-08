public static class Constants
{
	public static class 格子
	{
		public const int SIZE_PX = 64;
		public const string CHILD_CHESS = "Chess";
		public const string CHILD_FEATURE = "Feature";
	}

	public static class ChessboardMap
	{
		public static (int x, int y)[] CHEBYSHEV_BASE =
		{
			(1, 0), (-1, 0), (0, 1), (0, -1),
			(1, 1), (-1, 1), (1, -1), (-1, -1)
		};
	}
}
