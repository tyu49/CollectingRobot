using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "tirePart", menuName = "Part/tire", order = 0)]
    public class PlayerTirePartSO : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int RequiringTrash { get; private set; }
        [field:SerializeField] public int PlusSpeed { get; private set; }
        [field:SerializeField] public TirePartType Type { get; private set; }
        [field:SerializeField, TextArea(6, 10)] public string Description { get; private set; }
    }

    public enum TirePartType
    {
        None = 0,
        Tube = 1 << 0, //물에 뜰 수 있음
        
    }
}