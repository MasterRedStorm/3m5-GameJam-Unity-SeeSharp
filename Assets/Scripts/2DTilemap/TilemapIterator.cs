using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

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
#if UNITY_EDITOR
    [SerializeField] private Tiles debugTileset;
    private Dictionary<TileBase, TileBase> debugMap = new Dictionary<TileBase, TileBase>();
#endif

    private Dictionary<TileBase, Action<TileBase>> dict = new Dictionary<TileBase, Action<TileBase>>();

    // Start is called before the first frame update
    private void Start()
    {
        dict.Add(tileset.crystal, DoSomething);
        dict.Add(tileset.mixer, DoSomething);
        dict.Add(tileset.source, DoSomething);
        dict.Add(tileset.pipe_straight, DoSomething);
        dict.Add(tileset.pipe_bridge, DoSomething);
        dict.Add(tileset.pipe_curve, DoSomething);
        dict.Add(tileset.pipe_t, DoSomething);
        dict.Add(tileset.pipe_cross, DoSomething);
        
        debugMap.Add(tileset.crystal, debugTileset.crystal);
        debugMap.Add(tileset.mixer, debugTileset.crystal);
        debugMap.Add(tileset.source, debugTileset.crystal);
        debugMap.Add(tileset.pipe_straight, debugTileset.crystal);
        debugMap.Add(tileset.pipe_bridge, debugTileset.crystal);
        debugMap.Add(tileset.pipe_curve, debugTileset.crystal);
        debugMap.Add(tileset.pipe_t, debugTileset.crystal);
        debugMap.Add(tileset.pipe_cross, debugTileset.crystal);
        
        var cellBounds = tilemap.cellBounds;
        Debug.Log(cellBounds);
        for(var x = cellBounds.min.x; x< cellBounds.max.x;x++){
            for(var y= cellBounds.min.y; y< cellBounds.max.y;y++){
                for(var z= cellBounds.min.z;z< cellBounds.max.z;z++)
                {
                    var intPos = new Vector3Int(x, y, z);
                    var tileBase = tilemap.GetTile(intPos);

                    if (tileBase == null)
                    {
                        continue;
                    }
                    
#if UNITY_EDITOR
                    tilemap.SwapTile(tileBase, debugMap[tileBase]);
#endif

                    var eulers = tilemap.GetTransformMatrix(intPos).rotation.eulerAngles;
                    //Debug.Log(tileBase);
                    CheckTile(tileBase);
                    Debug.Log(eulers);

                }}
 
        }
    }

    private void DoSomething(TileBase tilebase)
    {
        Debug.Log(tilebase);
    }

    private void CheckTile(TileBase tileBase)
    {
        if (tileBase != null && dict.ContainsKey(tileBase))
        {
            dict[tileBase](tileBase);
        }
    }
}
