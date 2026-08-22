using System;
using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "bodyPart", menuName = "Part/body", order = 0)]
    public class PlayerPartSO : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int RequiringTrash { get; private set; }
        [field:SerializeField] public float PlusSpeed { get; private set; }
        [field:SerializeField] public float PlusJetpack { get; private set; }
        [field:SerializeField] public float PlusBattery { get; private set; }
        [field:SerializeField] public float PlusInventory { get; private set; }
        [field:SerializeField] public PartType Type { get; private set; }

        
}
    [Flags]
    public enum PartType
    {
        None = 0,
        NightVision = 1 << 0,
        LostTracker = 1 << 1,
        BaseTracker = 1 << 2,
        BatteryRecycle = 1 << 3,
        
    }
}