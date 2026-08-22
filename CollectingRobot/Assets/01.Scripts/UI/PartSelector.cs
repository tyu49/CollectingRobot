using _01.Scripts.SO;
using TMPro;
using UnityEngine;

namespace _01.Scripts.UI
{
    public class PartSelector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        
        
        public PlayerPartSO MyData { get; private set; }
        private bool _selected;
        private bool _made;
        
        
        public void Initialize(PlayerPartSO data)
        {
            MyData = data;
            text.SetText(data.Name);
        }

        public void Make()
        {
            _made = true;
        }

        public void Select()
        {
            
        }
    }
}