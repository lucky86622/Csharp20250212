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
        /// <summary>
        /// 經由分數計算出來的遊戲等級
        /// </summary>
        private int _level
        {
            get
            {
                // 級距：1000
                return _score / 1000;
            }
        }
        /// <summary>
        /// 遊戲進行成績
        /// </summary>
        private int _score;
        /// <summary>
        /// 遊戲是否結束
        /// </summary>
        private bool _isGameOver;
        #endregion

        #region 遊戲核心資料結構
        /// <summary>
        /// 磚塊模板
        /// </summary>
        public Brick brickTMP;

        /// <summary>
        /// 棋盤載體UI
        /// </summary>
        public Transform boardUI;

        /// <summary>
        /// 遊戲棋盤二維陣列(複數集合物件)
        /// </summary>
        private Brick[,] _gameBorad;

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
            InitialGame();
        }

        /// <summary>
        /// 初始化遊戲
        /// </summary>
        private void InitialGame()
        {
            _score = 0;
            _isGameOver = false;
            _gameBorad = new Brick[data.boardWidth, data.boardHeight];

            // For迴圈：起始值；終點值；迭代值；
            for (int y = 0; y < data.boardHeight; y++)
            {
                // 巢狀迴圈： 10 * 20 次
                for (int x = 0; x < data.boardWidth; x++)
                {
                    // 棋盤[指定的座標] = 具現化物件到特定座標
                    _gameBorad[x, y] = Instantiate(brickTMP, boardUI);
                    // 為了辨識容易將每個Brick依座標命名
                    _gameBorad[x, y].name = $"Brick({x}, {y})";
                }
            }
        }
    }
}

