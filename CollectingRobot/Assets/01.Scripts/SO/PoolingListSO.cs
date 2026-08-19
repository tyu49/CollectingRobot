using System.Collections.Generic;
using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "PoolingList", menuName = "Pooling/List", order = 0)]
    public class PoolingListSO : ScriptableObject
    {
        [field:SerializeField] public List<PoolItemSO> List { get; private set; }
    }
}