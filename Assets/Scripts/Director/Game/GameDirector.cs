using UnityEngine;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{

		void Awake()
		{
			if (!instance) instance = this;
		}

		// Start is called before the first frame update
		void Start()
		{
			// TODO キャラクターをランダムで選択するメソッドを呼び出すようにする
			currentCharacter = new Character(CharacterTypeEnum.Hiragana, (int)HiraganaIndexEnum.あ);
			characterText.text = currentCharacter.displayCharacter;
		}

		// Update is called once per frame
		// void Update()
		// {

		// }
	}
}
