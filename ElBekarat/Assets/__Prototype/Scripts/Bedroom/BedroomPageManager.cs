using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom
{
    public class BedroomPageManager : MonoBehaviour
    {
        [SerializeField] private Image overlayGFX;

        private void Start()
        {
            StartCoroutine(StartPage());
        }

        private IEnumerator OverlayFade(float _fade)
        {
            overlayGFX.gameObject.SetActive(true);

            if (_fade == 0)
            {
                overlayGFX.canvasRenderer.SetAlpha(1f);
            }
            else
            {
                overlayGFX.canvasRenderer.SetAlpha(0f);
            }

            overlayGFX.CrossFadeAlpha(_fade, 2f, false);

            yield return new WaitForSeconds(2f);
        }

        private IEnumerator StartPage()
        {
            StartCoroutine(OverlayFade(0));
            yield return new WaitForSeconds(2f);
            overlayGFX.gameObject.SetActive(false);
        }

        private IEnumerator EndPage()
        {
            StartCoroutine(OverlayFade(1));

            yield return new WaitForSeconds(3f);

            // SceneManager.LoadScene("");
        }

        public static BedroomPageManager Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
