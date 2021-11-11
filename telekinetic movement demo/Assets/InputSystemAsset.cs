// GENERATED AUTOMATICALLY FROM 'Assets/InputSystemAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystemAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystemAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystemAsset"",
    ""maps"": [
        {
            ""name"": ""actions"",
            ""id"": ""0b27be18-affd-478d-bf9d-c5e4432524a8"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""02e6bab0-d25c-47ec-b517-2f54dd28a5d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1dd77c66-6ea3-4698-8002-2f648f11ff3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""5ac30d30-7ebd-4a8d-9c41-60e3ff886075"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""fde613b3-a62b-4b69-bdeb-78a027797bca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Warp"",
                    ""type"": ""Button"",
                    ""id"": ""b4c28979-8775-41dc-ad02-3775e9d7bbc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""98d72bbd-5e32-4614-94ac-e09a5e574d0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""70e6eb0a-6546-4f4c-b28d-398f201ae8c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextGun"",
                    ""type"": ""Button"",
                    ""id"": ""74e2aaea-0632-4287-a2e6-f1259d0e2fec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevGun"",
                    ""type"": ""Button"",
                    ""id"": ""a7157040-2fb9-4e97-a009-e0263983672e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d17eae3c-eab6-4b35-8cc2-c8bcefe46c75"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e1871111-c339-47a6-a3e4-a653064a42be"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2d83877-bbea-4d7c-81b4-0520be18b2e8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d17cbad6-222a-4144-9340-f772fea21d42"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3f0c3305-849b-46b3-a4a0-69986ef15661"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""374b1421-2074-4096-983b-f4cef66eab7a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""07f793a1-2e2a-4253-a770-bed8f97bb7ce"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f5a062a2-e23d-480b-ab1a-a693b21eda06"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b97b78e1-e2fc-468e-b2fa-f095d9044aec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f8ff56e6-9475-466e-a7ce-68b89386aaf2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a936a51-b1a8-4fa6-90c4-e95c9daed6a9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98fb8177-f15f-4ce3-bd5f-50c02504f735"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9c8c36d0-b028-4e5a-9e50-c7dd0791f06b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7eaf5c3-7546-4db4-9920-3597e61b02d8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de1ed644-1101-455c-9376-62c713038b65"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c96389a3-27f0-4e3c-b5b9-2f6e3a1a9f88"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42d13238-9cd0-42c5-84c9-92ce8f75ebba"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bc8b142-2f9d-40bb-a066-5593681f9d66"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24149fc8-28e9-4c49-b8c2-a9422cef1c05"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f8ade7e-9db5-4d80-b6f1-142bbf7d97ba"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e518db54-a8b3-4acd-8136-cf9b6d688657"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fa4874a-14db-48e9-bc6e-6876bfaaa551"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b55d5a8d-ef16-47e0-943d-fcb24d1fff3e"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fedd017-18cc-42c0-825d-b9bee9212f71"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa75fd8a-2b03-4b3c-9f7f-0def335709d1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e037e9a4-a2fb-4aec-9040-d6ff0aa4c8e8"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""958816c3-a282-4fa8-883e-108d195ee1d8"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84e4811f-b085-4269-8cc3-43375320006a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // actions
        m_actions = asset.FindActionMap("actions", throwIfNotFound: true);
        m_actions_Aim = m_actions.FindAction("Aim", throwIfNotFound: true);
        m_actions_Movement = m_actions.FindAction("Movement", throwIfNotFound: true);
        m_actions_Shoot = m_actions.FindAction("Shoot", throwIfNotFound: true);
        m_actions_Dash = m_actions.FindAction("Dash", throwIfNotFound: true);
        m_actions_Warp = m_actions.FindAction("Warp", throwIfNotFound: true);
        m_actions_Melee = m_actions.FindAction("Melee", throwIfNotFound: true);
        m_actions_Pause = m_actions.FindAction("Pause", throwIfNotFound: true);
        m_actions_NextGun = m_actions.FindAction("NextGun", throwIfNotFound: true);
        m_actions_PrevGun = m_actions.FindAction("PrevGun", throwIfNotFound: true);
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

    // actions
    private readonly InputActionMap m_actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_actions_Aim;
    private readonly InputAction m_actions_Movement;
    private readonly InputAction m_actions_Shoot;
    private readonly InputAction m_actions_Dash;
    private readonly InputAction m_actions_Warp;
    private readonly InputAction m_actions_Melee;
    private readonly InputAction m_actions_Pause;
    private readonly InputAction m_actions_NextGun;
    private readonly InputAction m_actions_PrevGun;
    public struct ActionsActions
    {
        private @InputSystemAsset m_Wrapper;
        public ActionsActions(@InputSystemAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_actions_Aim;
        public InputAction @Movement => m_Wrapper.m_actions_Movement;
        public InputAction @Shoot => m_Wrapper.m_actions_Shoot;
        public InputAction @Dash => m_Wrapper.m_actions_Dash;
        public InputAction @Warp => m_Wrapper.m_actions_Warp;
        public InputAction @Melee => m_Wrapper.m_actions_Melee;
        public InputAction @Pause => m_Wrapper.m_actions_Pause;
        public InputAction @NextGun => m_Wrapper.m_actions_NextGun;
        public InputAction @PrevGun => m_Wrapper.m_actions_PrevGun;
        public InputActionMap Get() { return m_Wrapper.m_actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAim;
                @Movement.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnShoot;
                @Dash.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                @Warp.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnWarp;
                @Warp.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnWarp;
                @Warp.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnWarp;
                @Melee.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMelee;
                @Pause.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPause;
                @NextGun.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnNextGun;
                @NextGun.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnNextGun;
                @NextGun.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnNextGun;
                @PrevGun.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPrevGun;
                @PrevGun.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPrevGun;
                @PrevGun.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPrevGun;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Warp.started += instance.OnWarp;
                @Warp.performed += instance.OnWarp;
                @Warp.canceled += instance.OnWarp;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @NextGun.started += instance.OnNextGun;
                @NextGun.performed += instance.OnNextGun;
                @NextGun.canceled += instance.OnNextGun;
                @PrevGun.started += instance.OnPrevGun;
                @PrevGun.performed += instance.OnPrevGun;
                @PrevGun.canceled += instance.OnPrevGun;
            }
        }
    }
    public ActionsActions @actions => new ActionsActions(this);
    public interface IActionsActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnWarp(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnNextGun(InputAction.CallbackContext context);
        void OnPrevGun(InputAction.CallbackContext context);
    }
}
