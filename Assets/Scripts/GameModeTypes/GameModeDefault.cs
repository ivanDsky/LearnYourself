using UnityEngine;

namespace GameModeTypes
{
    public class GameModeDefault : IGameModeType
    {
        public GameModeType Type => GameModeType.Default;
    }
}