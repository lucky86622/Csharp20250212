using UnityEngine;

namespace Puzzle.Tetris
{
    public class GameData
    {
        public int boardWidth;
        public int boardHeight;

        /// <summary>
        /// 建構式(初始化class用)
        /// </summary>
        public GameData()
        {
            boardWidth = 10;
            boardHeight = 20;
        }

        /// <summary>
        /// 建構式(可自訂初始值版本)
        /// </summary>
        /// <param name="Width">寬</param>
        /// <param name="Height">高</param>
        public GameData(int Width, int Height)
        {
            boardWidth = Width;
            boardHeight = Height;
        }
    }
}

