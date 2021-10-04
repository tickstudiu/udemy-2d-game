// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""634b1e1b-ebdc-4803-a6b7-9ecab5815f48"",
            ""actions"": [
                {
                    ""name"": ""JUMP"",
                    ""type"": ""Button"",
                    ""id"": ""0eecdc56-55da-49bd-a712-3186a4449651"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MOVE"",
                    ""type"": ""Value"",
                    ""id"": ""341c3d77-9682-4789-946a-11b3141f5675"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ATTACK"",
                    ""type"": ""Button"",
                    ""id"": ""8d594b3f-ddd1-4e37-8be7-8b6738ffd6ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CLIMB"",
                    ""type"": ""Value"",
                    ""id"": ""717ea97f-aa3b-42cf-bb41-3db0e3c1dc01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4bc62ade-4060-474f-8e5a-742e91a25255"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JUMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f2394494-d4a2-496c-bd27-b14ca3187b94"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7a751596-6437-429a-be12-477f485e3687"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a2565321-6413-428d-9e72-44bd32a8fe67"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ce26a283-0bc5-4f2e-b48f-5c6cf2a2c399"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ATTACK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""811301f8-db2b-4017-8356-0968b2d09fdd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CLIMB"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5053676e-7e48-4a99-aa75-6a1d4b87ed4d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CLIMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0b564a0f-4de6-40bb-b66a-4b62f78a4c92"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CLIMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""8c263035-0077-4c4d-8470-0cac2d7c77dd"",
            ""actions"": [
                {
                    ""name"": ""PAUSE"",
                    ""type"": ""Button"",
                    ""id"": ""46d6e1a1-c7bf-4cbe-ae4f-ca6548cad22f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68b0809e-1f7e-499b-b776-08c6a93ed844"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PAUSE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_JUMP = m_Player.FindAction("JUMP", throwIfNotFound: true);
        m_Player_MOVE = m_Player.FindAction("MOVE", throwIfNotFound: true);
        m_Player_ATTACK = m_Player.FindAction("ATTACK", throwIfNotFound: true);
        m_Player_CLIMB = m_Player.FindAction("CLIMB", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PAUSE = m_UI.FindAction("PAUSE", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_JUMP;
    private readonly InputAction m_Player_MOVE;
    private readonly InputAction m_Player_ATTACK;
    private readonly InputAction m_Player_CLIMB;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JUMP => m_Wrapper.m_Player_JUMP;
        public InputAction @MOVE => m_Wrapper.m_Player_MOVE;
        public InputAction @ATTACK => m_Wrapper.m_Player_ATTACK;
        public InputAction @CLIMB => m_Wrapper.m_Player_CLIMB;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @JUMP.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJUMP;
                @JUMP.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJUMP;
                @JUMP.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJUMP;
                @MOVE.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMOVE;
                @MOVE.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMOVE;
                @MOVE.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMOVE;
                @ATTACK.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnATTACK;
                @ATTACK.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnATTACK;
                @ATTACK.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnATTACK;
                @CLIMB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCLIMB;
                @CLIMB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCLIMB;
                @CLIMB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCLIMB;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JUMP.started += instance.OnJUMP;
                @JUMP.performed += instance.OnJUMP;
                @JUMP.canceled += instance.OnJUMP;
                @MOVE.started += instance.OnMOVE;
                @MOVE.performed += instance.OnMOVE;
                @MOVE.canceled += instance.OnMOVE;
                @ATTACK.started += instance.OnATTACK;
                @ATTACK.performed += instance.OnATTACK;
                @ATTACK.canceled += instance.OnATTACK;
                @CLIMB.started += instance.OnCLIMB;
                @CLIMB.performed += instance.OnCLIMB;
                @CLIMB.canceled += instance.OnCLIMB;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PAUSE;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PAUSE => m_Wrapper.m_UI_PAUSE;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PAUSE.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPAUSE;
                @PAUSE.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPAUSE;
                @PAUSE.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPAUSE;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PAUSE.started += instance.OnPAUSE;
                @PAUSE.performed += instance.OnPAUSE;
                @PAUSE.canceled += instance.OnPAUSE;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJUMP(InputAction.CallbackContext context);
        void OnMOVE(InputAction.CallbackContext context);
        void OnATTACK(InputAction.CallbackContext context);
        void OnCLIMB(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPAUSE(InputAction.CallbackContext context);
    }
}
