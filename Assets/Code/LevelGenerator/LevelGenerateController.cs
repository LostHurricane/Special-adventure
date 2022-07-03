using System;
using System.Collections;
using System.Collections.Generic;
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
            _randomFillingPercent = levelGeneratorView.FactorSmooth;

            _map = new int[_widthMap, _heightMap];
        }

        public void Start ()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            RandomFillLevel();

            for (var i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }
            GeneratePlatforms();
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
                    var neighbors = GetSurroundingPoints(i,j);

                    if (neighbors > COUNT_PLATFORMS)
                    {
                        _map[i, j] = 0;
                    }
                }

            }

        }

        private int GetSurroundingPoints(int x, int y)
        {
            var pointCount = 0;


            for (var i = x - 5 ; i <= x + 5; i++)
            {
                for (var j = y - 5; j <= y + 5; j++)
                {
                    if (i >= 5 && i <= _widthMap - 5 && j >= 0 && j <= _heightMap - 5)
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

            return pointCount;
        }

        private void GeneratePlatforms()
        {
            for (var i = 0; i < _widthMap; i++)
            {
                for (var j = 0; j < _heightMap; j++)
                {
                   //если с двух сторон от кирпича нет другого заполняй случайным кол едениц вокруг него
                }

            }
        }
    }
}
