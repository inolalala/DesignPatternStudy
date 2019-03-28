using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyCodeReserver : MonoBehaviour {

    [SerializeField] private List<KeyEvent> keys = new List<KeyEvent>();

    [Serializable]
    public class KeyEvent
    {
        public KeyCode key;
        public UnityEvent keyEvent;
    }

    public List<KeyEvent> GetUsingKeyCodes()
    {
        return keys;
    }

    private void Update()
    {
        for (int i = 0; i < GetUsingKeyCodes().Count; i++)
        {
            KeyEvent pressedKeyCode = GetUsingKeyCodes()[i];
            if (Input.GetKeyDown(pressedKeyCode.key))
            {
                pressedKeyCode.keyEvent.Invoke();
            }
        }
    }
}
