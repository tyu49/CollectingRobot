using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _01.Scripts.Interactable
{
    public class Trash : InteractableAbstract
    {
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private List<Sprite> sprites;

        private void OnEnable()
        {
            sr.sprite = sprites[Random.Range(0, sprites.Count)];
        }

        public override void Interact(Player.Player owner)
        {
            base.Interact(owner);
        }
    }
}