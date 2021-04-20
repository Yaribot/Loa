
using UnityEngine;

[CreateAssetMenu(fileName = "New Pool", menuName = "Practice/PoolSystem/Pool")]
public class Pool : ScriptableObject
{
    public string tag;
    public GameObject prefab;
    public int size;
}
