using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DancePadInput;
using UnityEngine;

public class DancePadState : MonoBehaviour
{
    private Dictionary<Player, Dictionary<DancePadButton, bool>> _playerToButtonToState;

    void Awake()
    {
        _playerToButtonToState = new Dictionary<Player, Dictionary<DancePadButton, bool>>();

        int playersLength = Enum.GetNames(typeof(Player)).Length;
        int buttonsLength = Enum.GetNames(typeof(DancePadButton)).Length;

        for (int p = 0; p < playersLength; p++)
        {
            _playerToButtonToState.Add((Player)p, new Dictionary<DancePadButton, bool>());

            for (int b = 0; b < buttonsLength; b++)
            {
                _playerToButtonToState[(Player)p].Add((DancePadButton)b, false);
            }
        }
    }

    void LateUpdate()
    {
        SaveState();
    }

    public bool GetButton(DancePadButton button, Player player)
    {
        return _playerToButtonToState[player][button];
    }

    private void SaveState()
    {
        int playersLength = Enum.GetNames(typeof(Player)).Length;
        int buttonsLength = Enum.GetNames(typeof(DancePadButton)).Length;

        for (int p = 0; p < playersLength; p++)
        {
            for (int b = 0; b < buttonsLength; b++)
            {
                _playerToButtonToState[(Player)p][(DancePadButton)b] = DancePad.GetButton((DancePadButton)b, (Player)p);
            }
        }
    }
}