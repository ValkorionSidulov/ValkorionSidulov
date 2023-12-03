using UnityEngine;

namespace SpaceShooter
{
    public class TrailRenderer : MonoBehaviour
    {
        [SerializeField] private GameObject m_Trail;

        [SerializeField] private SpaceShip m_SpaceShip;

        private void Update()
        {
            if (m_SpaceShip.ThurstControl != 0 || m_SpaceShip.TorqueControl != 0)
                m_Trail.SetActive(true);
            else
                m_Trail.SetActive(false);
        }
    }
}
