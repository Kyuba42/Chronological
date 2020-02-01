using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarFade : MonoBehaviour
{

    private Image stamImage;
    private void Awake()
    {
        stamImage = transform.Find("StamBar").GetComponent<Image>();
    }

    //change stam amount to change bar
    private void SetStam(float normalizedstam)
    {
        stamImage.fillAmount = normalizedstam;
    }

    float currentTime = 0f;
    float startTime = 20f;
    [SerializeField] Image stamBar;
    //if using timer

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        SetStam(currentTime/20);
    }
}
