using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    //Enumerators

    //Structs

    //Set Params
    [Header("References")]
    [SerializeField] private Transform m_waveable = null;

    [Header("Values")]
    [SerializeField] private bool m_unscaledDeltaTime = false;
    public bool UnscaledDeltaTime { get => m_unscaledDeltaTime; set => m_unscaledDeltaTime = value; }

    //X
    [SerializeField] private bool m_moveInX = false;
    public bool MoveInX
    {
        set
        {
            m_moveInX = value;
            StartEndBrain();
        }
    }

    [SerializeField] [Range(0, 359)] private float m_angleX = 0;
    [SerializeField] private float m_offsetX = 0f;
    public float OffsetX
    {
        set
        {
            m_offsetX = value;
            SetAngles();
        }
    }

    [SerializeField] private float m_intensityX = 0.5f;
    public float IntensityX
    {
        set
        {
            m_intensityX = value;
            SetAngles();
        }
    }

    [SerializeField] private float m_speedX = 60f;

    //Y
    [SerializeField] private bool m_moveInY = false;
    public bool MoveInY
    {
        set
        {
            m_moveInY = value;
            StartEndBrain();
        }
    }

    [SerializeField] [Range(0, 359)] private float m_angleY = 0;
    [SerializeField] private float m_offsetY = 0f;
    public float OffsetY
    {
        set
        {
            m_offsetY = value;
            SetAngles();
        }
    }

    [SerializeField] private float m_intensityY = 0.5f;
    public float IntensityY
    {
        set
        {
            m_intensityY = value;
            SetAngles();
        }
    }

    [SerializeField] private float m_speedY = 60f;

    //Z
    [SerializeField] private bool m_moveInZ = false;
    public bool MoveInZ
    {
        set
        {
            m_moveInZ = value;
            StartEndBrain();
        }
    }

    [SerializeField] [Range(0, 359)] private float m_angleZ = 0;
    [SerializeField] private float m_offsetZ = 0f;
    public float OffsetZ
    {
        set
        {
            m_offsetZ = value;
            SetAngles();
        }
    }
    [SerializeField] private float m_intensityZ = 0.5f;
    public float IntensityZ
    {
        set
        {
            m_intensityZ = value;
            SetAngles();
        }
    }

    [SerializeField] private float m_speedZ = 60f;

    //Coroutine
    private bool m_isRunning = false;

    //Methods
    private void OnEnable()
    {
        StartEndBrain();
    }
    private void OnDisable()
    {
        m_isRunning = false;
        StopAllCoroutines();
    }
    private void OnValidate()
    {
        SetAngles();
    }

    private void StartEndBrain()
    {
        if (!Application.isPlaying) return;
        if (!m_waveable) return;

        if (m_moveInX || m_moveInY || m_moveInZ)
        {
            if (m_isRunning == false)
            {
                m_isRunning = true;
                StartCoroutine(Brain());
            }
        }
        else
        {
            m_isRunning = false;
            StopAllCoroutines();
        }
    }
    private void AddAngles()
    {
        float m_deltaTime = m_unscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;

        if (m_moveInX)
        {
            m_angleX += m_speedX * m_deltaTime;
            if (m_angleX > 360) m_angleX -= 360;
            else if (m_angleX < 0) m_angleX += 360;
        }
        if (m_moveInY)
        {
            m_angleY += m_speedY * m_deltaTime;
            if (m_angleY > 360) m_angleY -= 360;
            else if (m_angleY < 0) m_angleY += 360;
        }
        if (m_moveInZ)
        {
            m_angleZ += m_speedZ * m_deltaTime;
            if (m_angleZ > 360) m_angleZ -= 360;
            else if (m_angleZ < 0) m_angleZ += 360;
        }

        SetAngles();
    }
    private void SetAngles()
    {
        if (!m_waveable) return;

        float m_x = Mathf.Sin(m_angleX * Mathf.Deg2Rad) * m_intensityX * (m_moveInX ? 1 : 0);
        float m_y = Mathf.Sin(m_angleY * Mathf.Deg2Rad) * m_intensityY * (m_moveInY ? 1 : 0);
        float m_z = Mathf.Sin(m_angleZ * Mathf.Deg2Rad) * m_intensityZ * (m_moveInZ ? 1 : 0);

        m_waveable.localPosition = new Vector3(m_x, m_y, m_z);
    }

    //Coroutines
    private IEnumerator Brain()
    {
        WaitForEndOfFrame m_waitForEndOfFrame = new WaitForEndOfFrame();
        m_isRunning = true;

        while (m_isRunning)
        {
            AddAngles();
            yield return m_waitForEndOfFrame;
        }
    }
}