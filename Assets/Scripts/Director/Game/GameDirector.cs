using UnityEngine;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{

		void Awake()
		{
			// シングルトンパターン用
			if (!instance) instance = this;
			// 文字を生成して、変数にセットする
			setRandomCharacter();
		}

		// Start is called before the first frame update
		// void Start()
		// {

		// }

		// Update is called once per frame
		// void Update()
		// {

		// }
	}
}
