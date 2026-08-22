using System;
using System.Collections.Generic;
using _01.Scripts.SO;
using JetBrains.Annotations;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerPartManager : MonoBehaviour
    {
        [SerializeField] private PlayerPartSO[] equippedParts = new PlayerPartSO[3];

        public float PlusBattery { get; private set; }
        public float PlusSpeed { get; private set; }
        public float PlusJetPackGage { get; private set; }
        public float PlusInventoryScale { get; private set; }

        [field:SerializeField] public PartType EquippedType { get; private set; }

        private void Awake()
        {
        }

        public void GetBodyPart(PlayerPartSO data, int index)
        {
            equippedParts[index] = data;
            ChangePart();
        }

        private void ChangePart()
        {
            EquippedType = PartType.None;
            float battery = 0;
            float speed = 0;
            float jetPackGage = 0;
            float inventoryScale = 0;
            foreach (var part in equippedParts)
            {
                battery += part.PlusBattery;
                speed += part.PlusSpeed;
                jetPackGage += part.PlusJetpack;
                inventoryScale += part.PlusInventory;
                EquippedType |= part.Type;
            }

            PlusBattery = battery;
            PlusSpeed = speed;
            PlusJetPackGage = jetPackGage;
            PlusInventoryScale = inventoryScale;
        }
    }
}