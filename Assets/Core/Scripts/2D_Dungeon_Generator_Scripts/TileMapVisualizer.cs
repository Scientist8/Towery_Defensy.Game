using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTileMap, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop, wallSideRight, wallSideLeft, wallBottom, wallFull,
                     wallInnerCornerDownLeft, wallInnerCornerDownRight,
                     wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft;



    [SerializeField]
    private GameObject towerTilePrefab, cornerTilePrefab;
    [SerializeField]
    private GameObject towerTileParent, cornerTileParent;

    [SerializeField] TowerSpawner towerSpawner;

    public List<GameObject> towerTiles = new List<GameObject>();

    private List<GameObject> cornerTiles = new List<GameObject>();

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTileMap, floorTile);
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        //Binary type is new
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (WallTypesHelper.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        }
        else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }
        else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSideLeft;
        }
        else if (WallTypesHelper.wallBottom.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if (WallTypesHelper.wallFull.Contains(typeAsInt))
        {
            tile = wallFull;
        }


        if (tile != null)
        {
            PaintSingleTile(wallTileMap, tile, position);
        }

        // Instantiate tower tiles at walls
        GameObject go = Instantiate(towerTilePrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
        go.transform.parent = towerTileParent.transform;

        // This list gets empty somehow when in play mode,
        // if you wanted to change the dungeon delete all tower tiles and corner tiles then generate new dungeon
        towerTiles.Add(go as GameObject);
        // Add the transform to the transform list in tower spawner
        towerSpawner.towerTransformList.Add(go);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tileMap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tileMap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tileMap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tileMap.WorldToCell((Vector3Int)position);
        tileMap.SetTile(tilePosition, tile);
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        // Corner walls are new
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallTypesHelper.wallFullEightDirections.Contains(typeAsInt))
        {
            tile = wallFull;
        }
        else if (WallTypesHelper.wallBottmEightDirections.Contains(typeAsInt))
        {
            tile = wallBottom;
        }


        if (tile != null)
        {
            PaintSingleTile(wallTileMap, tile, position);
        }

        
        //Instantiate tower tiles as game objects on corner walls
        GameObject go = Instantiate(cornerTilePrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
        go.transform.parent = cornerTileParent.transform;

        // Dont add this tile to the general tile list because I don't want towers on corners, make its own list

        cornerTiles.Add(go as GameObject);
    }

    public void Clear()
    {
        floorTileMap.ClearAllTiles();
        wallTileMap.ClearAllTiles();

        //Clear tower and corner tiles
        for (int i = 0; i < towerTiles.Count; i++)
        {
            DestroyImmediate(towerTiles[i]);
        }

        for (int i = 0; i < cornerTiles.Count; i++)
        {
            DestroyImmediate(cornerTiles[i]);
        }
        towerTiles.Clear();
        towerSpawner.towerTransformList.Clear();
    }
}
