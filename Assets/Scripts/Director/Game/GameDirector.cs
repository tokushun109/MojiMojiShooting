using System;
using UnityEngine;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{

		void Awake()
		{
			// シングルトンパターン用
			if (!instance) instance = this;

			// キャラクタータイプの項目数を取得
			int characterTypeMax = Enum.GetNames(typeof(CharacterTypeEnum)).Length;
			int targetCharacterTypeIndex = UnityEngine.Random.Range(0, characterTypeMax);
			CharacterTypeEnum targetCharacterType = (CharacterTypeEnum)Enum.ToObject(typeof(CharacterTypeEnum), targetCharacterTypeIndex);
			currentCharacter = new Character(targetCharacterType, (int)HiraganaIndexEnum.お);
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
