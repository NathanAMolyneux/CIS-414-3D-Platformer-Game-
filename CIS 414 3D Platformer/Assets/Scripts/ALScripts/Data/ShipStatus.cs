using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace ALScripts.Data
{
    public class ShipStatus
    {
        private static ShipStatus instance;
        public static ShipStatus Instance => instance ??= new ShipStatus();

        public event Action OnStatusChanged;

        private float shipCondition = 100f;
        private float shipSpeed = 24.5f;
        private int repairedBreaches = 0;
        private int totalBreaches = 3;

        public float ShipCondition => shipCondition;
        public float ShipSpeed => shipSpeed;
        public int RepairedBreaches => repairedBreaches;
        public int TotalBreaches => totalBreaches;

        public void SetTotalBreaches(int value)
        {
            totalBreaches = value;
            NotifyObservers();
        }

        public void DamageShip(float amount)
        {
            shipCondition -= amount;
            if (shipCondition < 0f) shipCondition = 0f;
            NotifyObservers();
        }

        public void RepairShip(float amount)
        {
            shipCondition += amount;
            if (shipCondition > 100f) shipCondition = 100f;
            NotifyObservers();
        }

        public void SetSpeed(float value)
        {
            shipSpeed = value;
            NotifyObservers();
        }

        public void RegisterRepair()
        {
            repairedBreaches++;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            OnStatusChanged?.Invoke();
        }
    }
}