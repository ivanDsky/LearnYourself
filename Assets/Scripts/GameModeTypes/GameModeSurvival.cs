using System;
using UnityEngine;

namespace GameModeTypes
{
    [Serializable]
    public class GameModeSurvival : IGameModeType
    {
        public GameModeType Type => GameModeType.Survival;
    }
}