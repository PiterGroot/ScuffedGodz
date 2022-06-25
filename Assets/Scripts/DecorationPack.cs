using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Decoration Pack", menuName = "ScuffedGodz/Decoration/New Planet Decoration Pack")]
public class DecorationPack : ScriptableObject
{
    public List<GameObject> decorations = new List<GameObject>();
}
