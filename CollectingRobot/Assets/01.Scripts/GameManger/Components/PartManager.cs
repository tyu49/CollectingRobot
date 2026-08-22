using System;
using _01.Scripts.UI;
using UnityEngine;

namespace _01.Scripts.GameManger.Components
{
    public class PartManager : MonoBehaviour
    {
        
        
        private GameManger _manger;

        public event Action<PartSelector, int> OnEquippedPart;

        public void Initialize(GameManger owner)
        {
            _manger = owner;
        }
        
        public void TryMake(PartSelector selector)
        {
            if (selector.MyData.RequiringTrash > _manger.CurrentTrashes) return;
            selector.Make();
            _manger.UseTrashed(selector.MyData.RequiringTrash);
        }

        public void EquipPart(PartSelector selector, int index)
        {   
            OnEquippedPart?.Invoke(selector, index);
        }
    }
}