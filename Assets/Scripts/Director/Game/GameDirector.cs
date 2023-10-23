using UnityEngine;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{

		void Awake()
		{
			// シングルトンパターン用
			if (!instance) instance = this;

			// TODO キャラクターをランダムで選択するメソッドを呼び出すようにする
			currentCharacter = new Character(CharacterTypeEnum.Hiragana, (int)HiraganaIndexEnum.お);
			characterText.text = currentCharacter.displayCharacter;
		}

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		// void Update()
		// {

		// }
	}
}
