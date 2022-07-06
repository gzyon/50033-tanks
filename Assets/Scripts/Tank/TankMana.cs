using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankMana : MonoBehaviour
{
    public float m_StartingMana = 50f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthMana = Color.blue;  
    // public Color m_ZeroHealthColor = Color.red;    
    // public GameObject m_ExplosionPrefab;
    
    // private AudioSource m_ExplosionAudio;          
    // private ParticleSystem m_ExplosionParticles;   
    private float m_CurrentMana;  
    private bool m_Dead;            
    private TankHealth tankHealth;


    private void Awake()
    {
        // m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        // m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        // m_ExplosionParticles.gameObject.SetActive(false);
        tankHealth = GetComponent<TankHealth>();
        m_FillImage.color = Color.blue;
    }

    private void Start() {
        StartCoroutine(restoreMana());
    }

    private void Update() {
        // StartCoroutine(restoreMana());
    }


    private void OnEnable()
    {
        m_CurrentMana = m_StartingMana;
        // m_Dead = false;

        SetManaUI();
    }

    public void LoseMana(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentMana -= amount;

        SetManaUI();

        // disable shooting
        if (m_CurrentMana <= 0f && !m_Dead) Debug.Log("Ran out of mana");
    }


    private void SetManaUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = m_CurrentMana;
        // m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }

    private IEnumerator restoreMana() {
        while (tankHealth.GetHealth() > 0f) {
            Debug.Log(m_CurrentMana);
            if (m_CurrentMana > m_StartingMana - 5) yield return new WaitForSeconds(1.0f);
            else {
                Debug.Log("restoring mana");
                m_CurrentMana += 5;
                SetManaUI();
                yield return new WaitForSeconds(2.0f);
            }
        }
    }

    public float GetMana() {
        return m_CurrentMana;
    }

    // private void OnDeath()
    // {
    //     // Play the effects for the death of the tank and deactivate it.
    //     m_Dead = true;

    //     m_ExplosionParticles.transform.position = transform.position;
    //     m_ExplosionParticles.gameObject.SetActive(true);
    //     m_ExplosionParticles.Play();
    //     m_ExplosionAudio.Play();

    //     gameObject.SetActive(false);
    // }
}