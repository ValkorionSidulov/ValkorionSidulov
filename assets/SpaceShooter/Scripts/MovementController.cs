using UnityEngine;

namespace SpaceShooter
{
    public class MovementController : MonoBehaviour
    {
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        [SerializeField] private SpaceShip m_TargetShip;
        public void SetTargetShip(SpaceShip ship) => m_TargetShip = ship;

        [SerializeField] private VirtualJoystick m_VirtualJoystick;

        [SerializeField] private ControlMode m_ControlMode;

        private void Start()
        {
            if (m_ControlMode == ControlMode.Keyboard)
                m_VirtualJoystick.gameObject.SetActive(false);
            else
                m_VirtualJoystick.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (m_TargetShip == null) return;

            if (m_ControlMode == ControlMode.Keyboard)
                ControlKeyboard();

            if (m_ControlMode == ControlMode.Mobile)
                ControlMobile();
        }

        private void ControlMobile()
        {
            var dir = m_VirtualJoystick.Value;

            m_TargetShip.ThurstControl = dir.y;
            m_TargetShip.TorqueControl = -dir.x;
        }

        private void ControlKeyboard()
        {
            float thurst = 0;
            float torque = 0;

            if (Input.GetKey(KeyCode.W))
                thurst += 1.0f;

            if (Input.GetKey(KeyCode.S))
                thurst -= 1.0f;

            if (Input.GetKey(KeyCode.A))
                torque += 1.0f;

            if (Input.GetKey(KeyCode.D))
                torque -= 1.0f;

            m_TargetShip.ThurstControl = thurst;
            m_TargetShip.TorqueControl = torque;
        }
    }
}
