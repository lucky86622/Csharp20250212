using System;
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
                    // 委派清除顏色功能到 Action
                    UpdateBricks += _gameBorad[x, y].UpdateColor;
                }
            }
        }

        /// <summary>
        /// 以每秒跳動50次的固定更新週期刷新畫面
        /// </summary>
        private void FixedUpdate()
        {
            _timeCounter++; // 計算畫面更新
            if( _timeCounter >= GameSpeed)
            {
                _timeCounter = 0;
                Debug.Log("畫面刷新");
                DropBrick();
            }
        }
        #endregion

        #region 狀態數據
        // 當前操作中方塊組合是否存活
        private bool BrickAlive => _currentBrick.isAlive;
        // 遊戲速率 (共 10 級)
        private int GameSpeed => counter_TH - speed * 5;
        #endregion

        #region 遊戲邏輯控制
        private const int spawn_X = 4;              // [常數]方塊出生座標 X
        private const int spawn_Y = 20;             // [常數]方塊出生座標 Y
        private const int counter_TH = 50;          // [常數]更新計數器
        [Range(0, 9)]                               // [調速]速度等級 ( 倍率：一個單位 5 )
        public int speed = 0;                       
        private int _timeCounter;                   // 更新計數器
        private GameData.Type _nextBrickType;       // 下個出現的方塊形狀
        private BrickData _currentBrick;            // 當前操作中的方塊資料

        private Action UpdateBricks;              // 所有的 Brick 的 ClearColor 功能集合

        /// <summary>
        /// 方塊下墜
        /// </summary>
        private void DropBrick()
        {
            if (!BrickAlive)
            {
                // 產生新的方塊組
                _currentBrick.SetData(spawn_X, spawn_Y, _nextBrickType);
                _nextBrickType = data.RandomType();
            }
            else if (CheckCells(GameData.CalCells(_currentBrick, Vector2Int.down)))
            {
                // 原方塊組下落：先清除原本位置狀態
                ClearCells(GameData.CalCells(_currentBrick));
                _currentBrick.Fall();
            }
            // 視覺更新
            ValidCells(GameData.CalCells(_currentBrick));
        }


        /// <summary>
        /// 撞擊確認
        /// </summary>
        /// <param name="cells">方塊座標陣列</param>
        /// <returns是否可以通過</returns>
        private bool CheckCells(Vector2Int[] cells)
        {
            bool pass = true;
            // 先檢查是否能更新視覺
            foreach (Vector2Int cell in cells)
            {
                if (cell.y >= data.boardHeight) continue;
                // 0. 左右超界檢查
                // 1. 觸底檢查 (預判) or 2. 觸碰堆疊
                if (cell.y < 0 || _gameBorad[cell.x, cell.y].state == Brick.State.Occupied)
                {
                    _currentBrick.Lock();
                    pass = false;
                    break;
                }
            }
            return pass;
        }

        /// <summary>
        /// 清除狀態
        /// </summary>
        /// <param name="cells">方塊組座標陣列</param>
        private void ClearCells(Vector2Int[] cells)
        {
            foreach (Vector2Int cell in cells)
            {
                // continue：略過超出範圍的 cell
                if (cell.y >= data.boardHeight) continue;
                _gameBorad[cell.x, cell.y].ChangeState(Brick.State.None);
            }
        }

        /// <summary>
        /// 可視化棋盤 Cells
        /// </summary>
        private void ValidCells(Vector2Int[] cells)
        {
            // 更新磚塊狀態
            foreach (Vector2Int cell in cells)
            {
                if (cell.y >= data.boardHeight) continue;
                // 三元運算：if => ?，else => ：
                _gameBorad[cell.x, cell.y].ChangeState(BrickAlive ? Brick.State.Exist : Brick.State.Occupied);
            }
            // 統一更新所有方塊顏色
            UpdateBricks();
        }
        #endregion
    }
}

