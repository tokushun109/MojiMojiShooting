using UnityEngine;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{

		void Awake()
		{
			Application.targetFrameRate = 60;
			// シングルトンパターン用
			if (!instance) instance = this;
		}

		// Start is called before the first frame update
		void Start()
		{
			// 文字を生成して、変数にセットする
			setRandomCharacter();
			// 生成した文字に対応したターゲットを生成する
			generateTarget();
		}

	}
}
