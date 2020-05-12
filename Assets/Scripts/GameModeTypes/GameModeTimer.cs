using System;
using UnityEngine;

namespace GameModeTypes
{
    [Serializable]
    public class GameModeTimer : IGameModeType
    {
        public GameModeType Type => GameModeType.Timer;
    }
}