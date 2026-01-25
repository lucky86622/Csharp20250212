using UnityEngine;

namespace Puzzle.Tetris
{
    public struct BrickData
    {
        public int x;               // 錨點X座標
        public int y;               // 錨點Y座標
        public GameData.Type type;  // 形狀類型

        /// <summary>
        /// 設定初始狀態
        /// </summary>
        /// <param name="x">起始X</param>
        /// <param name="y">起始Y</param>
        /// <param name="type">形狀</param>
        public void SetData(int x, int y, GameData.Type type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }
    }

    public class GameData
    {
        #region 規格訊息
        /// <summary>
        /// 方塊種類(形狀)的列舉
        /// </summary>
        public enum Type
        {
            I, O, T, S, Z, L, J
        }

        public int boardWidth;      // 棋盤寬
        public int boardHeight;     // 棋盤高
        #endregion

        #region 建構式
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
        #endregion

        /// <summary>
        /// 隨機取得一個方塊形狀
        /// </summary>
        /// <returns>方塊形狀</returns>
        public Type RandomType()
        {
            return (Type)Random.Range(0, 7);
        }
    }
}

