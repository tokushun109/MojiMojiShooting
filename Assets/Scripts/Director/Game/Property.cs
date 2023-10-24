using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Director
{
	public partial class GameDirector : MonoBehaviour
	{
		// シングルトンパターン用
		public static GameDirector instance;

		[SerializeField, Header("表示文字のテキスト")] Text characterText;
		[SerializeField, Header("ゲームクリアのテキスト")] Text clearText;
		[SerializeField, Header("次へのテキスト")] Text nextText;
		[SerializeField, Header("最初からのテキスト")] Text resetText;

		// 現在の文字
		public Character currentCharacter;
		// 現在のターゲット位置のインデックス番号
		public int currentPositionIndex { get; private set; } = 0;
		// これまで選択されたcharacterの情報をリストで保存
		public List<(CharacterTypeEnum, int)> characterHistories;

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
						int maxIndex = Enum.GetNames(typeof(HiraganaIndexEnum)).Length - 1;
						if (index > maxIndex) throw new Exception(index + "は" + maxIndex + "の範囲を超えています");
						HiraganaIndexEnum indexEnum = (HiraganaIndexEnum)Enum.ToObject(typeof(HiraganaIndexEnum), index);
						// enumから表示文字を取得
						displayCharacter = Enum.GetName(typeof(HiraganaIndexEnum), indexEnum);
						// ひらがなのポジションを設定
						switch (indexEnum)
						{
							case HiraganaIndexEnum.あ:
								positions = new Vector2[] {
									new Vector2(-225, 138),
									new Vector2(178, 160),
									new Vector2(-52, 232),
									new Vector2(-41, -279),
									new Vector2(118, 65),
									new Vector2(-240, -238),
									new Vector2(9, 22),
									new Vector2(253, -133),
									new Vector2(65, -304),
								};
								break;
							case HiraganaIndexEnum.い:
								positions = new Vector2[] {
									new Vector2(-233, 170),
									new Vector2(-100, -274),
									new Vector2(153, 138),
									new Vector2(259, -174),
								};
								break;
							case HiraganaIndexEnum.う:
								positions = new Vector2[] {
									new Vector2(-140, 212),
									new Vector2(120, 180),
									new Vector2(-201, 11),
									new Vector2(162, 4),
									new Vector2(-93, -300),
								};
								break;
							case HiraganaIndexEnum.え:
								positions = new Vector2[] {
									new Vector2(-110, 215),
									new Vector2(103, 186),
									new Vector2(-196, 29),
									new Vector2(103, 46),
									new Vector2(-221, -293),
									new Vector2(17, -136),
									new Vector2(78, -291),
									new Vector2(247, -293),
								};
								break;
							case HiraganaIndexEnum.お:
								positions = new Vector2[] {
									new Vector2(-235, 97),
									new Vector2(40, 122),
									new Vector2(-93, 223),
									new Vector2(-108, -292),
									new Vector2(-248, -204),
									new Vector2(42, -45),
									new Vector2(224, -146),
									new Vector2(38, -291),
									new Vector2(155, 139),
									new Vector2(273, 58),
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
