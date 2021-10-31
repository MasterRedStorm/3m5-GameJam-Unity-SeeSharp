using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using DefaultNamespace;

using CreateFn = System.Func<
    UnityEngine.Vector3Int,
    UnityEngine.Tilemaps.Tilemap,
    DefaultNamespace.MapHandler,
    DefaultNamespace.FlowElement>;

[Serializable]
public class Tiles
{
    public TileBase crystal;
    public TileBase mixer;
    public TileBase source;
    public TileBase pipe_straight;
    public TileBase pipe_bridge;
    public TileBase pipe_curve;
    public TileBase pipe_t;
    public TileBase pipe_cross;
}

public class TilemapIterator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tiles tileset;
    [SerializeField] private GameController _gameController;

    private Dictionary<TileBase, CreateFn> dict = new ();

    private List<FlowElement> flowElements = new List<FlowElement>();

    private MapHandler _mapHandler;
    private int _offsetX;
    private int _offsetY;
    private int _zLayer;

//#if UNITY_EDITOR
    //private bool swapTilesAtRuntime = false;
    
    [SerializeField] private Tiles debugTileset;
    private Dictionary<TileBase, TileBase> debugMap = new Dictionary<TileBase, TileBase>();
//#endif

    // Start is called before the first frame update 
    private void Start()
    {
        dict.Add(tileset.crystal, (Vector3Int pos, Tilemap tm, MapHandler m) => CrystalElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.mixer, (Vector3Int pos, Tilemap tm, MapHandler m) => MixerElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.source, (Vector3Int pos, Tilemap tm, MapHandler m) => SourceElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.pipe_straight, (Vector3Int pos, Tilemap tm, MapHandler m) => PipeElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.pipe_bridge, (Vector3Int pos, Tilemap tm, MapHandler m) => PipeElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.pipe_curve, (Vector3Int pos, Tilemap tm, MapHandler m) => PipeElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.pipe_t, (Vector3Int pos, Tilemap tm, MapHandler m) => PipeElement.CreateElement(pos, tm, m, this));
        dict.Add(tileset.pipe_cross, (Vector3Int pos, Tilemap tm, MapHandler m) => PipeElement.CreateElement(pos, tm, m, this));

        //debugMap.Add(tileset.crystal, debugTileset.crystal);
        //debugMap.Add(tileset.mixer, debugTileset.mixer);
        //debugMap.Add(tileset.source, debugTileset.source);
        debugMap.Add(tileset.pipe_straight, debugTileset.pipe_straight);
        //debugMap.Add(tileset.pipe_bridge, debugTileset.pipe_bridge);
        debugMap.Add(tileset.pipe_curve, debugTileset.pipe_curve);
        debugMap.Add(tileset.pipe_t, debugTileset.pipe_t);
        debugMap.Add(tileset.pipe_cross, debugTileset.pipe_cross);
        
        //debugMap.Add(debugTileset.crystal, tileset.crystal);
        //debugMap.Add(debugTileset.mixer, tileset.mixer);
        //debugMap.Add(debugTileset.source, tileset.source);
        debugMap.Add(debugTileset.pipe_straight, tileset.pipe_straight);
        //debugMap.Add(debugTileset.pipe_bridge, tileset.pipe_bridge);
        debugMap.Add(debugTileset.pipe_curve, tileset.pipe_curve);
        debugMap.Add(debugTileset.pipe_t, tileset.pipe_t);
        debugMap.Add(debugTileset.pipe_cross, tileset.pipe_cross);

        var cellBounds = tilemap.cellBounds;
        
        var size = cellBounds.size;
        _mapHandler = new MapHandler(size.x, size.y);
        
        var minX = cellBounds.min.x;
        var minY = cellBounds.min.y;
        
        _offsetX = -minX;
        _offsetY = -minY;

        for (var x = minX; x < cellBounds.max.x; x++)
        {
            for (var y = minY; y < cellBounds.max.y; y++)
            {
                for (var z = cellBounds.min.z; z < cellBounds.max.z; z++)
                {
                    var intPos = new Vector3Int(x, y, z);

                    var tileBase = tilemap.GetTile(intPos);

                    if (tileBase == null)
                    {
                        continue;
                    }

/*#if UNITY_EDITOR
                    if (swapTilesAtRuntime &&
                        debugMap.ContainsKey(tileBase) &&
                        tileBase != debugMap[tileBase])
                    {
                        tilemap.SwapTile(tileBase, debugMap[tileBase]);
                    }
#endif*/

                    CheckTile(tileBase, intPos);
                }
            }
        }

        _gameController.Initialize(flowElements);
    }

    private void CheckTile(TileBase tileBase, Vector3Int intPos)
    {
        if (dict.ContainsKey(tileBase))
        {
            AddFlowElement(intPos, dict[tileBase]);
        }
        else
        {
            Debug.LogWarning($"Tile not found: {tileBase}");
        }
    }

    private void AddFlowElement(Vector3Int intPos, CreateFn createElement)
    {
        var eulers = tilemap.GetTransformMatrix(intPos).rotation.eulerAngles;
        
        intPos.x += _offsetX;
        intPos.y += _offsetY;
        var element = createElement(intPos, tilemap, _mapHandler);
        flowElements.Add(element);
    }

    public void SwapTile(Position position)
    {
        var intPos = new Vector3Int(
            position.x - _offsetX,
            position.x - _offsetX,
            0);
        
        var tileBase = tilemap.GetTile(intPos);

        if (debugMap.ContainsKey(tileBase) &&
            tileBase != debugMap[tileBase])
        {
            tilemap.SwapTile(tileBase, debugMap[tileBase]);
        }
    }
}
