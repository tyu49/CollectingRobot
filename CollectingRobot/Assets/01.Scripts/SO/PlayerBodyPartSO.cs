using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "bodyPart", menuName = "Part/body", order = 0)]
    public class PlayerBodyPartSO : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int RequiringTrash { get; private set; }
        [field:SerializeField] public int PlusSpeed { get; private set; }
        [field:SerializeField] public int PlusJetpack { get; private set; }
        [field:SerializeField] public int PlusBattery { get; private set; }
    }
}