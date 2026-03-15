using UnityEngine;
using System.Collections;

public class SlenderFlashlightScript : MonoBehaviour
{
    [SerializeField] private Light torch;
    [SerializeField] private AudioSource flashlightSource;
    [SerializeField] private float battery = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Flashlight"))
        {
            if (torch.enabled) torch.enabled = false;
            else
            {
                if (battery > 0f)
                    torch.enabled = true;
            }
            flashlightSource.Play();
        }
    }
}
