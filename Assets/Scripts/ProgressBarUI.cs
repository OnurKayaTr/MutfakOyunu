using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image barImage;
    private void Start()
    {
        cuttingCounter.OnProgressCahanged += CuttingCounter_OnProgressCahanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void CuttingCounter_OnProgressCahanged(object sender, CuttingCounter.OnProgressCahangedEventArgs e)
    {
        barImage.fillAmount = e.progressNomralized;

        if (e.progressNomralized == 0f || e.progressNomralized == 1f) { Hide(); }
        else { Show(); }
    }

    private void Show() { gameObject.SetActive(true); }
    private void Hide() { gameObject.SetActive(false); }

}
