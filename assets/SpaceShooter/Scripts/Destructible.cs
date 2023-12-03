using UnityEngine;
using UnityEngine.Events;


namespace SpaceShooter
{
    /// <summary>
    /// Уничтожаемый объект на сцене. То что может иметь хитпоинты.
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties
        /// <summary>
        /// Объект игнорирует повреждения.
        /// </summary>
        [SerializeField] private bool m_Indestructible;
        public bool IsIndestructible => m_Indestructible;

        /// <summary>
        /// Стартовое кол-во хитпоинтов.
        /// </summary>
        [SerializeField] private int m_HitPoints;

        /// <summary>
        /// Текущее кол-во хитпоинтов.
        /// </summary>
        private int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;

        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            m_CurrentHitPoints = m_HitPoints;
        }
        #endregion

        #region Public API
        /// <summary>
        /// Применение дамага к объекту
        /// </summary>
        /// <param name="damage"> Урон наносимый объекту </param>
        public void ApplyDamage(int damage)
        {
            if (m_Indestructible)
                return;

            m_CurrentHitPoints -= damage;

            if (m_CurrentHitPoints <= 0)
                OnDeath();
        }
        #endregion

        /// <summary>
        /// Уничтожение объекта, когда хитпоинты ниже нуля.
        /// </summary>
        protected virtual void OnDeath()
        {
            Destroy(gameObject);
            m_EventOnDeath?.Invoke();
        }

        [SerializeField] private UnityEvent m_EventOnDeath;
        public UnityEvent EventOnDeath => m_EventOnDeath;
    }
}
