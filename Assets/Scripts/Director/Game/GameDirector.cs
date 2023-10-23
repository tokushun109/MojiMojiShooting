using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{

		void Awake()
		{
			// シングルトンパターン用
			if (!instance) instance = this;

			// TODO この部分を関数化する

			// キャラクタータイプの項目数を取得
			int characterTypeMax = Enum.GetNames(typeof(CharacterTypeEnum)).Length;

			CharacterTypeEnum targetCharacterType;
			int targetIndex = 0;
			while (true)
			{
				int targetCharacterTypeIndex = UnityEngine.Random.Range(0, characterTypeMax);
				targetCharacterType = (CharacterTypeEnum)Enum.ToObject(typeof(CharacterTypeEnum), targetCharacterTypeIndex);
				switch (targetCharacterType)
				{
					case CharacterTypeEnum.Hiragana:
						int indexMax = Enum.GetNames(typeof(HiraganaIndexEnum)).Length;
						targetIndex = UnityEngine.Random.Range(0, indexMax);
						break;
				}

				// 選択済みの文字がないときは初期化して、whileから抜ける
				if (characterHistories == null)
				{
					characterHistories = new List<(CharacterTypeEnum, int)>();
					break;
				}

				bool isSelected = false;
				// すでに選択ずみの文字の場合は、選択済みフラグをtrueにする
				foreach (var item in characterHistories)
				{
					(CharacterTypeEnum characterType, int characterIndex) = item;
					if (targetCharacterType == characterType && targetIndex == characterIndex)
					{
						isSelected = true;
						break;
					}
				}

				if (!isSelected) break;
			}

			// 選択済みの文字として保存しておく
			characterHistories.Add((targetCharacterType, targetIndex));

			currentCharacter = new Character(targetCharacterType, targetIndex);
			characterText.text = currentCharacter.displayCharacter;
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
