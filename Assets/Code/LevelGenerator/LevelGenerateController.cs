using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SpecialAdventure
{
    public class LevelGenerateController
    {
        private int COUNT_PLATFORMS = 4;

        private Tilemap _tilemap;
        private List<TileInfo> _tiles;
        private int _widthMap;
        private int _heightMap;
        private int _factorSmooth;
        private int _randomFillingPercent;

        private int[,] _map;

        public LevelGenerateController (LevelGeneratorView levelGeneratorView)
        {
            _tilemap = levelGeneratorView.Tilemap;
            _tiles = levelGeneratorView.Tiles;
            _widthMap = levelGeneratorView.WidthMap;
            _heightMap = levelGeneratorView.HeightMap;
            _factorSmooth = levelGeneratorView.FactorSmooth;
            _randomFillingPercent = levelGeneratorView.RandomFillingPercent;

            _map = new int[_widthMap, _heightMap];

        }

        public void Start ()
        {
            GenerateLevel();
        }

        public void Clean()
        {
                _tilemap?.ClearAllTiles();   
        }

        private void GenerateLevel()
        {
            RandomFillLevel();

            for (var i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }
            
            DrawTilesOnMap();

        }

        

        private void RandomFillLevel()
        {
            var randomiser = new System.Random();

            for (var i = 0; i < _widthMap; i++)
            {
                for (var j = 0; j < _heightMap; j++)
                {
                    _map[i, j] = (randomiser.Next(0, 100) < _randomFillingPercent) ? 1 : 0;
                }

            }
        }


        private void SmoothMap()
        {

            for (var i = 0; i < _widthMap; i++)
            {
                for (var j = 0; j < _heightMap; j++)
                {
                    var neighbors = GetSurroundingPoints(i, j, 1);

                    if (neighbors > COUNT_PLATFORMS)
                    {
                        _map[i, j] = 1;
                    }
                    else if (neighbors < COUNT_PLATFORMS)
                    {
                        _map[i, j] = 0;
                    }
                }

            }

        }

        private int GetSurroundingPoints(int x, int y, int range = 5)
        {
            var pointCount = 0;


            for (var i = x - range; i <= x + range; i++)
            {
                for (var j = y - range; j <= y + range; j++)
                {
                    if (i >= 0 && i < _widthMap && j >= 0 && j < _heightMap)
                    {

                        if (i != x || j != y)
                        {
                            pointCount += _map[i, j];
                        }
                    }
                    else
                    {
                        pointCount += 1;
                    }
                }
            }
            Debug.Log(pointCount);
            return pointCount;
        }

        private void DrawTilesOnMap ()
        {
            if (_map == null)
            {
                throw new Exception("Cant acsess map");
            }
            var platform = _tiles.FirstOrDefault(tile => tile.Type == TileType.Platform).Tile;

            for (var i = 0; i < _widthMap; i++)
            {
                for (var j = 0; j < _heightMap; j++)
                {
                    Debug.Log("Draw");
                    if (_map [i,j] == 1)
                    {
                        
                           var positionTile = new Vector3Int(-_widthMap / 2 + i, -_heightMap / 2 + j, 0);
                        _tilemap.SetTile(positionTile, platform);

                    }
                }

            }

        }
    }
}
