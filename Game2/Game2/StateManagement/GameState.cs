using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.StateManagement
{
    public enum GameState
    {
        StartScreen,
        Game,
        PauseScreen
    }

    /// <summary>
    /// Set the start of the game screen to the StartScreen
    /// </summary>
    public class GameManager
    {
        public GameState CurrentGameState { get; set; } = GameState.StartScreen;
    }
}
