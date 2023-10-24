using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Director
{
    public partial class GameDirector : MonoBehaviour
    {
        /// <summary>
        /// ランダムに文字を生成して、各変数に入れる
        /// </summary>
        void setRandomCharacter()
        {
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

        /// <summary>
        /// ターゲットのポジションをリセットする
        /// </summary>
        void resetPosition()
        {
            currentPositionIndex = 0;
        }

        /// <summary>
        /// クリア関連のテキストの表示を一括で変更する
        /// </summary>
        /// <param name="isActive"></param>
        void setActiveForClearText(bool isActive)
        {
            characterText.color = new Color(1, 1, 1, isActive ? 0.8f : 0.4f);
            clearText.gameObject.SetActive(isActive);
            if (characterHistories.Count < stageCount) nextText.gameObject.SetActive(isActive);
            resetText.gameObject.SetActive(isActive);
        }

        /// <summary>
        /// ターゲットを生成する
        /// </summary>
        void generateTarget()
        {
            GameObject target = Instantiate(targetObj);
            target.transform.SetParent(canvasObj.transform, false);
            target.GetComponent<RectTransform>().anchoredPosition = GetPosition();
        }

        /// <summary>
        /// 現在のターゲットのポジションを取得する
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return currentCharacter.positions[currentPositionIndex];
        }

        /// <summary>
        /// ターゲットのポジションを次に移動する
        /// </summary>
        public void NextPosition()
        {
            currentPositionIndex++;
        }

        /// <summary>
        /// ステージクリア時の処理
        /// </summary>
        public void StageClear()
        {
            resetPosition();
            // テキストを表示する
            setActiveForClearText(true);
        }

        public void NextStage()
        {
            setActiveForClearText(false);
            setRandomCharacter();
            generateTarget();
        }

        /// <summary>
        /// ステージを初めからスタートする
        /// </summary>
        public void Restart()
        {
            SceneManager.LoadScene(SceneNames.GAME_SCENE);
        }
    }
}
