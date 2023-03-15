// GENERATED AUTOMATICALLY FROM 'Assets/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Player01"",
            ""id"": ""78daf338-c30a-458f-9a16-8a27c241473b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""32388231-504e-4017-82a9-8c55274a5fc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c7203656-eb4b-43fa-82d3-1e73df5a1d3e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a5b3eeb-fc24-41f2-92c8-a019b36d3fb2"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdec3292-8a58-4882-8931-26e55ade4ce3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player01
        m_Player01 = asset.FindActionMap("Player01", throwIfNotFound: true);
        m_Player01_Move = m_Player01.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player01
    private readonly InputActionMap m_Player01;
    private IPlayer01Actions m_Player01ActionsCallbackInterface;
    private readonly InputAction m_Player01_Move;
    public struct Player01Actions
    {
        private @NewControls m_Wrapper;
        public Player01Actions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player01_Move;
        public InputActionMap Get() { return m_Wrapper.m_Player01; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player01Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer01Actions instance)
        {
            if (m_Wrapper.m_Player01ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player01ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player01ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player01ActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_Player01ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public Player01Actions @Player01 => new Player01Actions(this);
    public interface IPlayer01Actions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
