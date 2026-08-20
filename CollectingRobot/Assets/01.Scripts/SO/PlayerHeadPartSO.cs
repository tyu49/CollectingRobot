using System;
using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "headPart", menuName = "Part/head", order = 0)]
    public class PlayerHeadPartSO : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int RequiringTrash { get; private set; }
        [field:SerializeField] public int PlusSpeed { get; private set; }
        [field:SerializeField] public HeadPartType Type { get; private set; }
        [field:SerializeField, TextArea(6, 10)] public string Description { get; private set; }
    }
    
    public enum HeadPartType
    {
        None = 0,
        NightVision = 1 << 0,
        
    }
}