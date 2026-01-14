using UnityEngine; // 使用 XXXXX 命名空間

// 命名空間(程式資料夾的概念) 第一層名稱(.的)次一層名稱
namespace Puzzle.Tetris
{
    // 公開權限 類別 名稱 (:繼承) Unity基礎類別
    public class TetrisBasic : MonoBehaviour
    {
        #region 基礎資料
        /// <summary>
        /// [靜態]data資料物件實體
        /// </summary>
        private static GameData _data;
        /// <summary>
        /// [靜態]公開存取使用的data物件(唯讀)
        /// </summary>
        public static GameData data
        {
            get
            {
                if( _data == null)
                {
                    // 如果(資料實體 不存在) 建立新的
                    _data = new GameData();
                }
                return _data;
            }
        }
        #endregion

        #region 遊戲核心資料結構
        /// <summary>
        /// 磚塊模板
        /// </summary>
        public Brick brickTMP;

        /// <summary>
        /// 
        /// </summary>
        public Transform boardUI;

        /// <summary>
        /// 遊戲棋盤二維陣列(複數集合物件)
        /// </summary>
        private bool[,] _gameBorad;

        /// <summary>
        /// 方塊種類(形狀)的列舉
        /// </summary>
        private enum Type
        {
            I, O, T, S, Z, L, J
        }
        #endregion

        private void Start()
        {
            // For迴圈：起始值；終點值；迭代值；
            for (int y = 0; y < data.boardHeight; y++)
            {
                // 巢狀迴圈： 10 * 20 次
                for (int x = 0; x < data.boardWidth; x++)
                {
                    // 具現化物件到特定目標
                    Instantiate(brickTMP, boardUI).name = $"Brick({x}, {y})";
                }
            }

            _gameBorad = new bool[data.boardWidth, data.boardHeight];
            Debug.Log(_gameBorad[0, 0]);
        }
    }
}

