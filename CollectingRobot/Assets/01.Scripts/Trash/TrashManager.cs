using System;
using System.Collections.Generic;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Trash
{
    public class TrashManager : MonoBehaviour
    {
        [SerializeField] private TrashCreatList data;
        
        private void Start()
        {
            List<Vector3> points = new List<Vector3>(data.Points);
            for (int i = 0; i < data.Count; i++)
            {
                
            }
        }
    }
}