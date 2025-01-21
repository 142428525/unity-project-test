//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class 格子 : MonoBehaviour
//{
public class 格子
{
	public bool haveChess = false;  // C#，你就是这一点不行啊（指没有结构体默认构造）
	public Features feature = Features.Empty;

	public enum Features    // 地物
	{
		Empty,
		Grass,
		Flower
	}
}

//	// Start is called before the first frame update
//	void Start()
//	{

//	}

//	// Update is called once per frame
//	void Update()
//	{

//	}
//}
