//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class 格子 : MonoBehaviour
//{
public struct 格子
{
	public Stat chessStat;
	public Features feature;

	public enum Stat
	{
		Unavailable = -1,
		Empty,
		First,
		Second,
		Third,
		Fourth,
		Player,
		Reserved
	}

	public enum Features    // 地物
	{
		Empty,
		Grass,
		Flower  // etc.
	}

	public void Initialize()    // pseudo-ctor
	{
		// C#，你就是这一点不行啊（指没有结构体默认构造）
		chessStat = Stat.Empty;
		feature = Features.Empty;
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
