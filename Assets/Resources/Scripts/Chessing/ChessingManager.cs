using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChessingManager : MonoBehaviour
{
	public GameObject CHESSING_PANEL;
	public GameObject CHESSBOARD;
	public GameObject PREFAB_格子;
	public ChessboardStyle chessboardStyle = ChessboardStyle.One;

	private bool is_chessing = false;
	private 格子[,] chessboard_map = new 格子[15, 15];

	public static ChessingManager Instance { get; private set; }

	public enum ChessboardStyle
	{
		One = 1,
		Two,
		Three,
		Four
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);    // destroy extra objects
		}
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (is_chessing && Mouse.current.leftButton.wasPressedThisFrame)
		{
			var colli = Physics2D.OverlapPoint(Mouse.current.position.value);

			//
			//Debug.Log($"{Mouse.current.position.value}: {(colli != null ? colli : "(Nothing)")}");
			//

			if (colli != null)
			{
				var idx = get_idx_from_格子_pos(colli.gameObject.transform.parent
					.GetComponent<RectTransform>().anchoredPosition);

				//
				Debug.Log($"{Mouse.current.position.value}: {idx}");
				//
			}
			else
			{
				//
				Debug.Log($"{Mouse.current.position.value}: (Nothing)");
				//
			}
		}
	}

	public void InvokeStart()
	{
		Debug.Log("Ciallo world! (Chessing Manager)");  // control flow enters

		CHESSING_PANEL.SetActive(true);

		CHESSBOARD.GetComponent<RectTransform>().sizeDelta = get_格子_num() * Constants.格子_SIZE_PX;

		for (int i = 0; i < get_格子_num().x; i++)
		{
			for (int j = 0; j < get_格子_num().y; j++)
			{
				if (chessboardStyle == ChessboardStyle.Three && i >= 9 && j >= 9)
				{
					continue;   // deal with non-square chessboard
				}

				Instantiate(PREFAB_格子, CHESSBOARD.transform)
					.GetComponent<RectTransform>().anchoredPosition =
					new Vector2Int(i * Constants.格子_SIZE_PX, -j * Constants.格子_SIZE_PX);
			}
		}

		Debug.Log("Chessboard generation completes.");

		is_chessing = true;
	}

	/// <returns>x向右，y向下</returns>
	private Vector2Int get_格子_num() => chessboardStyle switch
	{
		ChessboardStyle.One => new Vector2Int(9, 9),    // 9 * 64 = 576
		ChessboardStyle.Two => new Vector2Int(15, 9),   // 15 * 64 = 960
		ChessboardStyle.Three or ChessboardStyle.Four => new Vector2Int(15, 15),
		_ => throw new System.ArgumentOutOfRangeException(nameof(chessboardStyle),
			$"Invalid enum value '{chessboardStyle}'. Is this possible???")
	};

	private Vector2Int get_idx_from_格子_pos(Vector2 pos_p)
	{
		Vector2 tmp = pos_p / Constants.格子_SIZE_PX;  // integer guaranteed
		return new Vector2Int((int)tmp.x, (int)-tmp.y);
	}
}
