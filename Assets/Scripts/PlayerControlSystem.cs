// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Battles"",
            ""id"": ""f1e4e5d8-36dc-4008-9059-28672b9248b3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""58f977d1-7dfc-4573-8d31-6a37bd28e727"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""PassThrough"",
                    ""id"": ""40e6f5e8-6156-45a6-bad6-093617aacf4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54964abd-bf73-4546-971b-19ad6f1a01d6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Sideways"",
                    ""id"": ""432c03b7-e8bc-4b7b-8f51-c4c971ed3134"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8d6c0c92-dfea-4a70-9678-e6c90b25eb52"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fb31a925-c070-435b-8ada-22e25d27ffba"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c85fdfc-ec72-4c45-a1b8-dc45b2500e43"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Overworld"",
            ""id"": ""ad0289d1-40fd-4d32-80ea-ec20b43a9834"",
            ""actions"": [
                {
                    ""name"": ""MoveVertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa0ad4f4-4408-4a73-8b73-803559d00135"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a10e85f5-263c-4f18-b5d4-85d9347e4466"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6a8b6f00-3cfd-46e4-9f09-1e9eba4f81b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""137391e7-11cf-4778-a5ac-1b34cfbfcd55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""ceaa617c-3355-4de9-9f55-e695a9bce6e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ca533f84-d41a-4b24-bb14-9b9d1bfa2572"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""01337a3a-236b-4534-9216-83fb6b6a5868"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""51f4498b-c91f-4ca8-a260-04d0dbd75168"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7ffae8d3-20d6-4c75-ae10-5e6eaebbd71d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""55daf836-e8c1-4213-b9ca-b14cba58f90b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b986d91f-7943-4a01-b850-a9880ff2ffff"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0fb4912d-a5b4-4f08-b981-89ffe9eb26dd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0eec8903-97f2-462d-9c00-149824650dc3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ac48be25-7422-467f-80f3-a430bbf462c5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b3a1f2da-a3cc-42f6-9902-630a8fbb3257"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4c3983a2-64f0-4c78-b149-3529f004197a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8f7076f9-97b4-4d42-b78a-2563b75186bb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""44bc18bb-fb27-42fb-9be3-e2b8f7345f51"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b5861fab-4e4f-4ed3-85ad-ac2fd4f3a560"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e6f0b1d2-cd72-4129-aa0d-d47eb128c471"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ee1cab5-0769-48ba-bffa-9245f56cf892"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""061ccc8e-67dd-47d8-b134-e0050fb7814a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Battles
        m_Battles = asset.FindActionMap("Battles", throwIfNotFound: true);
        m_Battles_Move = m_Battles.FindAction("Move", throwIfNotFound: true);
        m_Battles_Select = m_Battles.FindAction("Select", throwIfNotFound: true);
        // Overworld
        m_Overworld = asset.FindActionMap("Overworld", throwIfNotFound: true);
        m_Overworld_MoveVertical = m_Overworld.FindAction("MoveVertical", throwIfNotFound: true);
        m_Overworld_MoveHorizontal = m_Overworld.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_Overworld_Select = m_Overworld.FindAction("Select", throwIfNotFound: true);
        m_Overworld_Interact = m_Overworld.FindAction("Interact", throwIfNotFound: true);
        m_Overworld_Space = m_Overworld.FindAction("Space", throwIfNotFound: true);
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

    // Battles
    private readonly InputActionMap m_Battles;
    private IBattlesActions m_BattlesActionsCallbackInterface;
    private readonly InputAction m_Battles_Move;
    private readonly InputAction m_Battles_Select;
    public struct BattlesActions
    {
        private @PlayerControlSystem m_Wrapper;
        public BattlesActions(@PlayerControlSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Battles_Move;
        public InputAction @Select => m_Wrapper.m_Battles_Select;
        public InputActionMap Get() { return m_Wrapper.m_Battles; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattlesActions set) { return set.Get(); }
        public void SetCallbacks(IBattlesActions instance)
        {
            if (m_Wrapper.m_BattlesActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_BattlesActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BattlesActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BattlesActionsCallbackInterface.OnMove;
                @Select.started -= m_Wrapper.m_BattlesActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_BattlesActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_BattlesActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_BattlesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public BattlesActions @Battles => new BattlesActions(this);

    // Overworld
    private readonly InputActionMap m_Overworld;
    private IOverworldActions m_OverworldActionsCallbackInterface;
    private readonly InputAction m_Overworld_MoveVertical;
    private readonly InputAction m_Overworld_MoveHorizontal;
    private readonly InputAction m_Overworld_Select;
    private readonly InputAction m_Overworld_Interact;
    private readonly InputAction m_Overworld_Space;
    public struct OverworldActions
    {
        private @PlayerControlSystem m_Wrapper;
        public OverworldActions(@PlayerControlSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveVertical => m_Wrapper.m_Overworld_MoveVertical;
        public InputAction @MoveHorizontal => m_Wrapper.m_Overworld_MoveHorizontal;
        public InputAction @Select => m_Wrapper.m_Overworld_Select;
        public InputAction @Interact => m_Wrapper.m_Overworld_Interact;
        public InputAction @Space => m_Wrapper.m_Overworld_Space;
        public InputActionMap Get() { return m_Wrapper.m_Overworld; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OverworldActions set) { return set.Get(); }
        public void SetCallbacks(IOverworldActions instance)
        {
            if (m_Wrapper.m_OverworldActionsCallbackInterface != null)
            {
                @MoveVertical.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMoveVertical;
                @MoveVertical.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMoveVertical;
                @MoveHorizontal.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMoveHorizontal;
                @Select.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnSelect;
                @Interact.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnInteract;
                @Space.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnSpace;
            }
            m_Wrapper.m_OverworldActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveVertical.started += instance.OnMoveVertical;
                @MoveVertical.performed += instance.OnMoveVertical;
                @MoveVertical.canceled += instance.OnMoveVertical;
                @MoveHorizontal.started += instance.OnMoveHorizontal;
                @MoveHorizontal.performed += instance.OnMoveHorizontal;
                @MoveHorizontal.canceled += instance.OnMoveHorizontal;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
            }
        }
    }
    public OverworldActions @Overworld => new OverworldActions(this);
    public interface IBattlesActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IOverworldActions
    {
        void OnMoveVertical(InputAction.CallbackContext context);
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
    }
}
