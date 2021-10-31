using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using DefaultNamespace;

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

    private Dictionary<TileBase, Type> dict = new Dictionary<TileBase, Type>();

#if UNITY_EDITOR
    [SerializeField] private Tiles debugTileset;
    private Dictionary<TileBase, TileBase> debugMap = new Dictionary<TileBase, TileBase>();
#endif
    
    // Start is called before the first frame update 
    private void Start()
    {
        dict.Add(tileset.crystal, typeof(CrystalElement));
        dict.Add(tileset.mixer, typeof(MixerElement));
        dict.Add(tileset.source, typeof(SourceElement));
        dict.Add(tileset.pipe_straight, typeof(GridElement));
        dict.Add(tileset.pipe_bridge, typeof(GridElement));
        dict.Add(tileset.pipe_curve, typeof(GridElement));
        dict.Add(tileset.pipe_t, typeof(GridElement));
        dict.Add(tileset.pipe_cross, typeof(GridElement));
        
        debugMap.Add(tileset.crystal, debugTileset.crystal);
        debugMap.Add(tileset.mixer, debugTileset.mixer);
        debugMap.Add(tileset.source, debugTileset.source);
        debugMap.Add(tileset.pipe_straight, debugTileset.pipe_straight);
        debugMap.Add(tileset.pipe_bridge, debugTileset.pipe_bridge);
        debugMap.Add(tileset.pipe_curve, debugTileset.pipe_curve);
        debugMap.Add(tileset.pipe_t, debugTileset.pipe_t);
        debugMap.Add(tileset.pipe_cross, debugTileset.pipe_cross);
        
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
                    //Debug.Log(intPos+ " "+tileBase.name);
                    
#if UNITY_EDITOR
                    if (debugMap.ContainsKey(tileBase) && tileBase != debugMap[tileBase]) {
                        tilemap.SwapTile(tileBase, debugMap[tileBase]);
                    }
#endif

                    var eulers = tilemap.GetTransformMatrix(intPos).rotation.eulerAngles;
                    //Debug.Log(tileBase);
                    CheckTile(tileBase);
                    Debug.Log(eulers);

                }}
 
        }
    }

    private void DoSomething(Type elementType)
    {
        Debug.Log(elementType);
    }

    private void CheckTile(TileBase tileBase)
    {
        if (tileBase != null && dict.ContainsKey(tileBase))
        {
            DoSomething(dict[tileBase]);
        }
    }
}
