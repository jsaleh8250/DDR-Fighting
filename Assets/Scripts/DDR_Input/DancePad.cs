using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DancePadInput
{
    public enum Player
    {
        Any,
        One = 1,
        Two = 2,
    }

    public enum DancePadButton
    {
        Left = 0,
        Down = 1,
        Up = 2,
        Right = 3,
        Triangle = 4,
        Square = 5,
        X = 6,
        Circle = 7,
        Start = 8,
        Select = 9
    }

    public static class DancePad
    {
        private static DancePadState _stateUpdater;

        private static void Initialize()
        {
            _stateUpdater = new GameObject("Dance pad state updater").AddComponent<DancePadState>();
            Object.DontDestroyOnLoad(_stateUpdater.gameObject);
        }

        public static bool GetButton(DancePadButton button, Player player)
        {
            if (_stateUpdater == null)
            {
                Initialize();
            }

            string inputKey = player == Player.Any
                ? "joystick button " + (int)button
                : "joystick " + (int)player + " button " + (int)button;

            return Input.GetButton(inputKey);
        }

        public static bool GetButtonDown(DancePadButton button, Player player)
        {
            if (_stateUpdater == null)
            {
                Initialize();
                return GetButton(button, player);
            }
            else
            {
                return GetButton(button, player) && !_stateUpdater.GetButton(button, player);
            }
        }

        public static bool GetButtonUp(DancePadButton button, Player player)
        {
            if (_stateUpdater == null)
            {
                Initialize();
                return false;
            }
            else
            {
                return !GetButton(button, player) && _stateUpdater.GetButton(button, player);
            }
        }
    }
}