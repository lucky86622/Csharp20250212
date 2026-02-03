using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Tetris
{
    public struct BrickData
    {
        public bool isAlive { get; private set; }        // 方塊組是否處於可活動狀態
        public int x;               // 錨點X座標
        public int y;               // 錨點Y座標
        private Vector2Int _pos;    // 錨點座標
        public Vector2Int pos
        {
            get
            {
                _pos.x = x;
                _pos.y = y;
                return _pos;
            }
        }    // 錨點座標公開接口
        public GameData.Type type;  // 形狀類型

        /// <summary>
        /// 設定初始狀態
        /// </summary>
        /// <param name="x">起始X</param>
        /// <param name="y">起始Y</param>
        /// <param name="type">形狀</param>
        public void SetData(int x, int y, GameData.Type type)
        {
            isAlive = true;
            this.x = x;
            this.y = y;
            this.type = type;
        }

        /// <summary>
        /// 產生碰撞鎖定
        /// </summary>
        public void Lock()
        {
            isAlive = false;
        }

        public void Fall()
        {
            this.y -= 1;
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

        /// <summary>
        /// [字典] 方塊形狀對應座標集合物件本體
        /// </summary>
        private static Dictionary<Type, Vector2Int[]> _cells;

        /// <summary>
        /// [字典] 方塊形狀對外公開存取接口
        /// </summary>
        public static Dictionary<Type, Vector2Int[]> cells
        {
            get
            {
                if (_cells == null)
                {
                    InitailCellData();
                }
                return _cells;
            }
        }

        /// <summary>
        /// 初始化方塊資料
        /// </summary>
        private static void InitailCellData()
        {
            _cells = new Dictionary<Type, Vector2Int[]>();
            // I型：軸點為底下算來第二格
            _cells.Add(Type.I, new Vector2Int[]
            {
                new Vector2Int(0, 2),
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),   // 軸點
                new Vector2Int(0, -1)
            });

            // O型：
            _cells.Add(Type.O, new Vector2Int[]
            {
                new Vector2Int(1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),   // 軸點
                new Vector2Int(1, 0)
            });

            // T型：
            _cells.Add(Type.T, new Vector2Int[]
            {
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),   // 軸點
                new Vector2Int(-1, 0),   
                new Vector2Int(1, 0)
            });

            // S型：
            _cells.Add(Type.S, new Vector2Int[]
            {
                new Vector2Int(0, 1),
                new Vector2Int(1, 1),
                new Vector2Int(-1, 0),   
                new Vector2Int(0, 0)    // 軸點
            });

            // Z型：
            _cells.Add(Type.Z, new Vector2Int[]
            {
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),   // 軸點
                new Vector2Int(1, 0)
            });

            // L型：
            _cells.Add(Type.L, new Vector2Int[]
            {
                new Vector2Int(0, 2),
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),   // 軸點
                new Vector2Int(1, 0)
            });

            // J型：
            _cells.Add(Type.J, new Vector2Int[]
            {
                new Vector2Int(0, 2),
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),   // 軸點
                new Vector2Int(-1, 0)
            });
        }

        /// <summary>
        /// [工具] 計算方塊組對應 CellPos
        /// </summary>
        /// <param name="data">方塊組資料</param>
        /// <returns>座標陣列</returns>
        public static Vector2Int[] CalCells(BrickData data)
        {
            Vector2Int[] calCells = cells[data.type];
            for (int i = 0; i < calCells.Length; i++)
            {
                calCells[i] = cells[data.type][i] + data.pos;
            }
            return calCells;
        }
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

