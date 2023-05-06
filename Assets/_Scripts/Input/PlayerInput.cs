//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""82dde9e5-214f-4674-be77-9de667758cd6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d212d72a-d805-4de4-9e87-1cf429d91425"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b48b4c87-fc93-4913-91ba-9d5f1f6e9f1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RollForward"",
                    ""type"": ""Button"",
                    ""id"": ""ded69213-c90e-45c2-aed4-faa23658a12b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RollBackward"",
                    ""type"": ""Button"",
                    ""id"": ""3797f55e-d033-4596-9876-ec852d17bd29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RollLeft"",
                    ""type"": ""Button"",
                    ""id"": ""999e9ac3-4374-4b19-b10d-3b63a221b6a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RollRight"",
                    ""type"": ""Button"",
                    ""id"": ""5f17f384-ed54-4d23-9feb-89b2cc9e2fbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d0de4427-6fda-478a-a256-e5c0ae3a99dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TwoHandAttack"",
                    ""type"": ""Button"",
                    ""id"": ""62bd4617-a26e-455a-9b4b-90e5824c93fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""IsMoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""77a7bb7a-062a-42bd-8a41-c1e8b88bd406"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""IsMoveBackward"",
                    ""type"": ""Button"",
                    ""id"": ""6cba5fb4-103e-4b73-9114-ddd1d4496304"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FreeLook"",
                    ""type"": ""Value"",
                    ""id"": ""97896acc-db36-410b-ad84-408e8e52a28b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bdfbc68f-ac1c-4df0-961f-7934097f33a1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""70ca964a-4888-4db4-9673-6c8698a0a5a4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""9e17395b-0b47-498f-80a0-6c6a9dee50e7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""50dd41ac-7165-419f-91f7-1bec2e1a236a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b87ac6dc-9a65-442f-a3e0-9c2ca22ca4b2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d9087b11-cae8-4e03-8dd8-1caae9707090"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""2bf98839-1442-4039-94cc-90d821313778"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollForward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""80fe246d-73ec-495b-b582-b7408708ad08"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""be52c0b1-48b2-422b-91d2-48998b44ade4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""ed73fc1d-5d0c-428a-b532-177bc7dfe636"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollBackward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""26c8650a-cfa2-49e9-9f38-213ba1681bca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""825e14a6-747e-4765-99ca-dc46095bdb86"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""67cfa615-530b-4336-a360-267653695ade"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0743478e-fa85-4b09-affd-70aa0e128b20"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""732eb3f9-306f-4564-b2a5-4c7aeec071ac"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""4411eae4-7639-4c02-aca8-9d404f8436d2"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""71a0392a-4107-4c13-b679-44112f254ff1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""d2c0028a-107a-43f7-97ff-9ce868cecf12"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""858849d8-2be0-4a6b-b65e-9d7d76d95418"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa44d827-9687-429e-b057-a4bdf2c61450"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TwoHandAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""760de00f-610f-4b09-ade6-f9bacf9a8516"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IsMoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0282ac86-de21-4a40-bf59-0daf0368c0af"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IsMoveBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da46efca-58f8-4882-8fcc-0ecb9f0484ce"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FreeLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""30a6774b-75aa-4bb1-9581-396f4809723c"",
            ""actions"": [
                {
                    ""name"": ""K"",
                    ""type"": ""Button"",
                    ""id"": ""11c4fa8d-50f9-4177-9b65-050c2d86e7ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""16954ce2-1cf2-4934-8acf-90fae48471f0"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""K"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_RollForward = m_Player.FindAction("RollForward", throwIfNotFound: true);
        m_Player_RollBackward = m_Player.FindAction("RollBackward", throwIfNotFound: true);
        m_Player_RollLeft = m_Player.FindAction("RollLeft", throwIfNotFound: true);
        m_Player_RollRight = m_Player.FindAction("RollRight", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_TwoHandAttack = m_Player.FindAction("TwoHandAttack", throwIfNotFound: true);
        m_Player_IsMoveForward = m_Player.FindAction("IsMoveForward", throwIfNotFound: true);
        m_Player_IsMoveBackward = m_Player.FindAction("IsMoveBackward", throwIfNotFound: true);
        m_Player_FreeLook = m_Player.FindAction("FreeLook", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_K = m_UI.FindAction("K", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_RollForward;
    private readonly InputAction m_Player_RollBackward;
    private readonly InputAction m_Player_RollLeft;
    private readonly InputAction m_Player_RollRight;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_TwoHandAttack;
    private readonly InputAction m_Player_IsMoveForward;
    private readonly InputAction m_Player_IsMoveBackward;
    private readonly InputAction m_Player_FreeLook;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @RollForward => m_Wrapper.m_Player_RollForward;
        public InputAction @RollBackward => m_Wrapper.m_Player_RollBackward;
        public InputAction @RollLeft => m_Wrapper.m_Player_RollLeft;
        public InputAction @RollRight => m_Wrapper.m_Player_RollRight;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @TwoHandAttack => m_Wrapper.m_Player_TwoHandAttack;
        public InputAction @IsMoveForward => m_Wrapper.m_Player_IsMoveForward;
        public InputAction @IsMoveBackward => m_Wrapper.m_Player_IsMoveBackward;
        public InputAction @FreeLook => m_Wrapper.m_Player_FreeLook;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @RollForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollForward;
                @RollForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollForward;
                @RollForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollForward;
                @RollBackward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollBackward;
                @RollBackward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollBackward;
                @RollBackward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollBackward;
                @RollLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollLeft;
                @RollLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollLeft;
                @RollLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollLeft;
                @RollRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollRight;
                @RollRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollRight;
                @RollRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRollRight;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @TwoHandAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwoHandAttack;
                @TwoHandAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwoHandAttack;
                @TwoHandAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwoHandAttack;
                @IsMoveForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIsMoveForward;
                @IsMoveForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIsMoveForward;
                @IsMoveForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIsMoveForward;
                @IsMoveBackward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIsMoveBackward;
                @IsMoveBackward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIsMoveBackward;
                @IsMoveBackward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIsMoveBackward;
                @FreeLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFreeLook;
                @FreeLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFreeLook;
                @FreeLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFreeLook;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RollForward.started += instance.OnRollForward;
                @RollForward.performed += instance.OnRollForward;
                @RollForward.canceled += instance.OnRollForward;
                @RollBackward.started += instance.OnRollBackward;
                @RollBackward.performed += instance.OnRollBackward;
                @RollBackward.canceled += instance.OnRollBackward;
                @RollLeft.started += instance.OnRollLeft;
                @RollLeft.performed += instance.OnRollLeft;
                @RollLeft.canceled += instance.OnRollLeft;
                @RollRight.started += instance.OnRollRight;
                @RollRight.performed += instance.OnRollRight;
                @RollRight.canceled += instance.OnRollRight;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @TwoHandAttack.started += instance.OnTwoHandAttack;
                @TwoHandAttack.performed += instance.OnTwoHandAttack;
                @TwoHandAttack.canceled += instance.OnTwoHandAttack;
                @IsMoveForward.started += instance.OnIsMoveForward;
                @IsMoveForward.performed += instance.OnIsMoveForward;
                @IsMoveForward.canceled += instance.OnIsMoveForward;
                @IsMoveBackward.started += instance.OnIsMoveBackward;
                @IsMoveBackward.performed += instance.OnIsMoveBackward;
                @IsMoveBackward.canceled += instance.OnIsMoveBackward;
                @FreeLook.started += instance.OnFreeLook;
                @FreeLook.performed += instance.OnFreeLook;
                @FreeLook.canceled += instance.OnFreeLook;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_K;
    public struct UIActions
    {
        private @PlayerInput m_Wrapper;
        public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @K => m_Wrapper.m_UI_K;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @K.started -= m_Wrapper.m_UIActionsCallbackInterface.OnK;
                @K.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnK;
                @K.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnK;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @K.started += instance.OnK;
                @K.performed += instance.OnK;
                @K.canceled += instance.OnK;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRollForward(InputAction.CallbackContext context);
        void OnRollBackward(InputAction.CallbackContext context);
        void OnRollLeft(InputAction.CallbackContext context);
        void OnRollRight(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnTwoHandAttack(InputAction.CallbackContext context);
        void OnIsMoveForward(InputAction.CallbackContext context);
        void OnIsMoveBackward(InputAction.CallbackContext context);
        void OnFreeLook(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnK(InputAction.CallbackContext context);
    }
}