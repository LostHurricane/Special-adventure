using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SpecialAdventure
{
    public class LevelGeneratorView : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _tilemap;

        [SerializeField]
        private List<TileInfo> _tiles;

        [SerializeField]
        private int _widthMap;

        [SerializeField]
        private int _heightMap;

        [SerializeField]
        private int _factorSmooth;

        [SerializeField, Range (0, 100)]
        private int _randomFillingPercent;



        public Tilemap Tilemap => _tilemap;
        public List<TileInfo> Tiles => _tiles;
        public int WidthMap => _widthMap;
        public int HeightMap => _heightMap;
        public int FactorSmooth => _factorSmooth;
        public int RandomFillingPercent => _randomFillingPercent;




    }
}
