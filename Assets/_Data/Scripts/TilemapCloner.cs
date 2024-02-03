using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCloner : MonoBehaviour
{
    [SerializeField] private Tilemap[] allTilemaps;
    [SerializeField] public Tilemap originalTilemap;

    void Start()
    {
        originalTilemap = allTilemaps[Random.Range(0, allTilemaps.Length)];
        CloneTilemap(originalTilemap);
    }

    void CloneTilemap(Tilemap original)
    {
        // Lấy các ô của map ban đầu
        BoundsInt bounds = original.cellBounds;
        TileBase[] allTiles = original.GetTilesBlock(bounds);

        // Tạo Tilemap mới
        Tilemap newTilemap = gameObject.AddComponent<Tilemap>();
        TilemapRenderer tilemapRenderer = gameObject.AddComponent<TilemapRenderer>();
        tilemapRenderer.material = original.GetComponent<TilemapRenderer>().material;

        // Cập nhật các ô trong tilemap mới với các ô lấy ban đầu
        newTilemap.SetTilesBlock(bounds, allTiles);
    }
}
