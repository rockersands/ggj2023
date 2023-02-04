// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/rocco/PlayerMovement.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMovement : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovement"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""16716e34-eb8b-4f68-a7ec-07e07d28c6aa"",
            ""actions"": [
                {
                    ""name"": ""rightStickPress"",
                    ""type"": ""Button"",
                    ""id"": ""a115beb3-d4f8-4b7a-abb1-1349e1cb5f98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""leftStickPress"",
                    ""type"": ""Button"",
                    ""id"": ""08c06477-1d7c-4040-add1-f325ff95a9f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""4ce83e6d-abf9-4f99-97a5-dd11e05142c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""pausa"",
                    ""type"": ""Button"",
                    ""id"": ""2e901bd5-d260-4874-9f78-979bee0978d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightBumper"",
                    ""type"": ""Button"",
                    ""id"": ""19cf6bc1-ba9c-4f35-9b7c-d11b34192a15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftBumper"",
                    ""type"": ""Button"",
                    ""id"": ""e94f299f-d2b0-43e4-aad5-233cbaf19da5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Trigger"",
                    ""type"": ""Value"",
                    ""id"": ""f2ecebdb-20a0-400c-b416-9002b39b3fba"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Trigger"",
                    ""type"": ""Value"",
                    ""id"": ""143482a7-330f-4f5b-b044-1386e146a3e8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""y"",
                    ""type"": ""Button"",
                    ""id"": ""7a12b44e-8014-4b57-9b25-14c7ac402aa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""x"",
                    ""type"": ""Button"",
                    ""id"": ""c9c84bb3-41c6-4a0a-ac85-559d5883396f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""b"",
                    ""type"": ""Button"",
                    ""id"": ""06f85ca6-4e8b-4334-ad66-b4c0db6352a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""db586170-b2f0-4a7d-a6fd-ed9338a396df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dpad"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b66f20f-c89b-4124-8707-c8f21fcc6eda"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""45e9b2b6-831c-4384-9cbf-baff9f0c909d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1288eff8-d960-4fc0-87b8-0d73b02318ca"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""33113ad3-f53a-46ef-b0ba-92470a397ee6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7759f3a3-8e49-491e-9d2d-ffcdde8fb605"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""52b92479-4428-4601-a582-4e9e9ffbff8e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a3a33e51-eb7a-4add-9079-07c7b9a5493b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a4ac4fe0-284c-41d3-9474-1f76ee179286"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""teclado"",
                    ""id"": ""106af266-8c7c-4282-817e-bcef80ce67b6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""64d3dfca-1d21-46e9-83ca-c1274656d648"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d9c42bd6-cbb6-4c73-b22c-88ea247bb48d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""70d497ad-b3a0-452d-81e9-cc4a24a89504"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""311f29d5-d711-4944-8184-d62e579355a1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Control"",
                    ""id"": ""54752345-fa5e-495e-98d5-4495ca0bb854"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5f402f5c-76cd-444f-9c48-b24f64c070e6"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ac986ac-e57a-4212-925d-6536d13dcfc3"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""912133dc-c681-4327-b582-07a7b409e5c6"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1e3b212-7ca0-464b-9879-2f54f2006c62"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keyboard"",
                    ""id"": ""a035583d-ff63-4d01-b17f-b8ad45132f8a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e277a01b-f62a-45f9-9ffa-3b856ddee0b8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8136f134-8fb3-4c4f-b5f1-3d0272b2b2d3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8b0f7db8-7efd-4bd5-8bdd-cf6a41de287a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""13da473a-1947-47eb-b4cd-0b5999b8a09c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5fd7a37e-a38e-4fbb-af40-6f768d9dcb49"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aa88a436-e0e6-4236-af55-e62fe83bcfe6"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""51257ad4-3055-4aad-acb6-8fb2054da809"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ef5bdb7b-4090-4e83-b8fc-a2090424e324"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""15006499-e5d2-46bc-bf32-0d3fa286d801"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d341a514-5f71-4d1d-af55-38cc1675722e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3c92a61-ef44-4da2-9e5d-990bc9ec999d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18277ef7-bd47-4a05-a033-fdeedf89f7ca"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""b"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37b2a3e1-4606-47d7-9a9b-b5b33e470240"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""x"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3f3e815-bed8-429c-9a5e-c53ecc2fba98"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a26958c0-7e45-48f9-95d6-4e875cbdb0b2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fd42efd-ef90-48b6-9909-1e6c8df84592"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""769519c6-fa4c-41b2-b139-9a6372627d6a"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftBumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfc890e1-0ec1-4029-bb26-ab1aad1f2619"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightBumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee288028-1a5a-46ed-a968-b64b13831170"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d449f39-2385-4b34-afca-94cebff3e4c2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""991f3d8c-590c-4cea-bf83-842073646bcf"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7499698-a9f9-42df-8318-85177329317c"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftStickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f24d6f63-ab68-4bdf-acdc-6438a6f5b98b"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightStickPress"",
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
        m_Player_rightStickPress = m_Player.FindAction("rightStickPress", throwIfNotFound: true);
        m_Player_leftStickPress = m_Player.FindAction("leftStickPress", throwIfNotFound: true);
        m_Player_Select = m_Player.FindAction("Select", throwIfNotFound: true);
        m_Player_pausa = m_Player.FindAction("pausa", throwIfNotFound: true);
        m_Player_RightBumper = m_Player.FindAction("RightBumper", throwIfNotFound: true);
        m_Player_LeftBumper = m_Player.FindAction("LeftBumper", throwIfNotFound: true);
        m_Player_RightTrigger = m_Player.FindAction("Right Trigger", throwIfNotFound: true);
        m_Player_LeftTrigger = m_Player.FindAction("Left Trigger", throwIfNotFound: true);
        m_Player_y = m_Player.FindAction("y", throwIfNotFound: true);
        m_Player_x = m_Player.FindAction("x", throwIfNotFound: true);
        m_Player_b = m_Player.FindAction("b", throwIfNotFound: true);
        m_Player_A = m_Player.FindAction("A", throwIfNotFound: true);
        m_Player_Dpad = m_Player.FindAction("Dpad", throwIfNotFound: true);
        m_Player_RightStick = m_Player.FindAction("RightStick", throwIfNotFound: true);
        m_Player_LeftStick = m_Player.FindAction("LeftStick", throwIfNotFound: true);
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
    private readonly InputAction m_Player_rightStickPress;
    private readonly InputAction m_Player_leftStickPress;
    private readonly InputAction m_Player_Select;
    private readonly InputAction m_Player_pausa;
    private readonly InputAction m_Player_RightBumper;
    private readonly InputAction m_Player_LeftBumper;
    private readonly InputAction m_Player_RightTrigger;
    private readonly InputAction m_Player_LeftTrigger;
    private readonly InputAction m_Player_y;
    private readonly InputAction m_Player_x;
    private readonly InputAction m_Player_b;
    private readonly InputAction m_Player_A;
    private readonly InputAction m_Player_Dpad;
    private readonly InputAction m_Player_RightStick;
    private readonly InputAction m_Player_LeftStick;
    public struct PlayerActions
    {
        private @PlayerMovement m_Wrapper;
        public PlayerActions(@PlayerMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @rightStickPress => m_Wrapper.m_Player_rightStickPress;
        public InputAction @leftStickPress => m_Wrapper.m_Player_leftStickPress;
        public InputAction @Select => m_Wrapper.m_Player_Select;
        public InputAction @pausa => m_Wrapper.m_Player_pausa;
        public InputAction @RightBumper => m_Wrapper.m_Player_RightBumper;
        public InputAction @LeftBumper => m_Wrapper.m_Player_LeftBumper;
        public InputAction @RightTrigger => m_Wrapper.m_Player_RightTrigger;
        public InputAction @LeftTrigger => m_Wrapper.m_Player_LeftTrigger;
        public InputAction @y => m_Wrapper.m_Player_y;
        public InputAction @x => m_Wrapper.m_Player_x;
        public InputAction @b => m_Wrapper.m_Player_b;
        public InputAction @A => m_Wrapper.m_Player_A;
        public InputAction @Dpad => m_Wrapper.m_Player_Dpad;
        public InputAction @RightStick => m_Wrapper.m_Player_RightStick;
        public InputAction @LeftStick => m_Wrapper.m_Player_LeftStick;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @rightStickPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStickPress;
                @rightStickPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStickPress;
                @rightStickPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStickPress;
                @leftStickPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStickPress;
                @leftStickPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStickPress;
                @leftStickPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStickPress;
                @Select.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @pausa.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPausa;
                @pausa.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPausa;
                @pausa.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPausa;
                @RightBumper.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightBumper;
                @RightBumper.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightBumper;
                @RightBumper.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightBumper;
                @LeftBumper.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftBumper;
                @LeftBumper.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftBumper;
                @LeftBumper.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftBumper;
                @RightTrigger.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightTrigger;
                @LeftTrigger.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftTrigger;
                @y.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnY;
                @y.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnY;
                @y.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnY;
                @x.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnX;
                @x.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnX;
                @x.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnX;
                @b.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnB;
                @b.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnB;
                @b.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnB;
                @A.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                @Dpad.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDpad;
                @Dpad.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDpad;
                @Dpad.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDpad;
                @RightStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStick;
                @LeftStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @rightStickPress.started += instance.OnRightStickPress;
                @rightStickPress.performed += instance.OnRightStickPress;
                @rightStickPress.canceled += instance.OnRightStickPress;
                @leftStickPress.started += instance.OnLeftStickPress;
                @leftStickPress.performed += instance.OnLeftStickPress;
                @leftStickPress.canceled += instance.OnLeftStickPress;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @pausa.started += instance.OnPausa;
                @pausa.performed += instance.OnPausa;
                @pausa.canceled += instance.OnPausa;
                @RightBumper.started += instance.OnRightBumper;
                @RightBumper.performed += instance.OnRightBumper;
                @RightBumper.canceled += instance.OnRightBumper;
                @LeftBumper.started += instance.OnLeftBumper;
                @LeftBumper.performed += instance.OnLeftBumper;
                @LeftBumper.canceled += instance.OnLeftBumper;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @y.started += instance.OnY;
                @y.performed += instance.OnY;
                @y.canceled += instance.OnY;
                @x.started += instance.OnX;
                @x.performed += instance.OnX;
                @x.canceled += instance.OnX;
                @b.started += instance.OnB;
                @b.performed += instance.OnB;
                @b.canceled += instance.OnB;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @Dpad.started += instance.OnDpad;
                @Dpad.performed += instance.OnDpad;
                @Dpad.canceled += instance.OnDpad;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRightStickPress(InputAction.CallbackContext context);
        void OnLeftStickPress(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnPausa(InputAction.CallbackContext context);
        void OnRightBumper(InputAction.CallbackContext context);
        void OnLeftBumper(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnDpad(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
    }
}
