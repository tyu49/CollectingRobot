using System.Collections.Generic;
using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "TrashList", menuName = "Trash/CreatOption", order = 0)]
    public class TrashCreatList : ScriptableObject
    {
        [field:SerializeField] public int Count { get; private set; }
        [field:SerializeField] public List<Vector3> Points { get; private set; }
    }
}