using System;
using UnityEngine;

namespace Game.Director
{
    public partial class GameDirector : MonoBehaviour
    {
        public Vector2 GetPosition()
        {
            return currentCharacter.positions[currentPositionIndex];
        }

        public void NextPosition()
        {
            currentPositionIndex++;
        }

        public void ResetPosition()
        {
            currentPositionIndex = 0;
        }
    }
}
