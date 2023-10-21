using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{
		// シングルトンパターン用
		public static GameDirector instance;

		[SerializeField, Header("表示文字のテキスト")] Text characterText;

		// 現在の文字
		public Character currentCharacter;

		public class Character
		{
			// 表示する文字
			public string displayCharacter { get; private set; }
			// ターゲットを表示させる位置
			public Vector2[] positions { get; private set; }

			public Character(CharacterTypeEnum characterType, int index)
			{
				switch (characterType)
				{
					case CharacterTypeEnum.Hiragana:
						int maxIndex = Enum.GetValues(typeof(HiraganaIndexEnum)).Length - 1;
						if (index > maxIndex) throw new Exception(index + "は" + maxIndex + "の範囲を超えています");
						HiraganaIndexEnum indexEnum = (HiraganaIndexEnum)Enum.ToObject(typeof(HiraganaIndexEnum), index);
						// enumから表示文字を取得
						displayCharacter = Enum.GetName(typeof(HiraganaIndexEnum), indexEnum);
						// ひらがなのポジションを設定
						switch (indexEnum)
						{
							case HiraganaIndexEnum.あ:
								positions = new Vector2[] {
									new Vector2(-1.35f, 1),
									new Vector2(1, 1.3f),
									new Vector2(-0.37f, 1.7f),
									new Vector2(-0.12f, -1.14f),
									new Vector2(0.57f, 0.39f),
									new Vector2(-1.38f, -0.87f),
									new Vector2(-0.37f, 0.37f),
									new Vector2(1.34f, -0.39f),
									new Vector2(0.52f, -1.46f),
								};
								break;
								// TODO これ以降で別の文字も設定していく
						}
						break;
				}
			}
		}
	}
}
