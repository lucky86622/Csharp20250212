using UnityEngine; // 使用 XXXXX 命名空間

// 命名空間(程式資料夾的概念) 第一層名稱(.的)次一層名稱
namespace Puzzle.Tetris
{
    // 公開權限 類別 名稱 (:繼承) Unity基礎類別
    public class TetrisBasic : MonoBehaviour
    {
        #region 基礎資料
        private static GameData _data;  // [靜態]data資料物件實體
        public static GameData data     // [靜態]公開存取使用的data物件(唯讀)
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

        private const int lv_Range = 1000;  // 級距常數
        private int _level                  // 經由分數計算出來的遊戲等級
        {
            get
            {
                // 級距：1000
                return _score / lv_Range;
            }
        }       
        private int _score;             // 遊戲進行成績
        private bool _isGameOver;       // 遊戲是否結束
        #endregion

        #region 遊戲核心資料結構
        public Brick brickTMP;          // 磚塊模板
        public Transform boardUI;       // 棋盤載體UI
        private Brick[,] _gameBorad;    // 遊戲棋盤二維陣列(複數集合物件)
        #endregion

        #region 生命週期
        private void Start()
        {
            InitialGame();                  // 初始化遊戲
        }

        /// <summary>
        /// 初始化遊戲
        /// </summary>
        private void InitialGame()
        {
            _nextBrickType = data.RandomType();
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
                    _gameBorad[x, y].Initial($"Brick({x}, {y})");
                }
            }
        }

        /// <summary>
        /// 以每秒跳動50次的固定更新週期刷新畫面
        /// </summary>
        private void FixedUpdate()
        {
            _timeCounter++; // 計算畫面更新
            if( _timeCounter >= counter_TH)
            {
                _timeCounter = 0;
                Debug.Log("畫面刷新");
                DropBrick();
            }
        }
        #endregion

        #region 遊戲邏輯控制
        private const int spawn_X = 4;              // [常數]方塊出生座標 X
        private const int spawn_Y = 19;             // [常數]方塊出生座標 Y
        private const int counter_TH = 50;          // [常數]更新計數器
        private int _timeCounter;                   // 更新計數器
        private GameData.Type _nextBrickType;       // 下個出現的方塊形狀
        private BrickData _currentBrick;            // 當前操作中的方塊資料

        /// <summary>
        /// 方塊下墜
        /// </summary>
        private void DropBrick()
        {
            _currentBrick.SetData(spawn_X, spawn_Y, _nextBrickType);
            _nextBrickType = data.RandomType();
            _gameBorad[_currentBrick.x, _currentBrick.y].ActiveColor();
        }
        #endregion
    }
}

