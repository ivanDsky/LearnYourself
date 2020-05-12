using System;
using UnityEngine;

namespace GameModeTypes
{
    [Serializable]
    public class GameModeDefault : IGameModeType
    {
        public GameModeType Type => GameModeType.Default;
    }
}