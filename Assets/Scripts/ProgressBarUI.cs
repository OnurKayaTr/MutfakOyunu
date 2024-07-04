using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProggesGameOBJ;
    [SerializeField] private Image barImage;
    private IHasProgges hasProgges;
    private void Start()
    {
        hasProgges = hasProggesGameOBJ.GetComponent<IHasProgges>();
        hasProgges.OnProgressCahanged += HasProgges_OnProgressCahanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void HasProgges_OnProgressCahanged(object sender, IHasProgges.OnProgressCahangedEventArgs e)
    {
        barImage.fillAmount = e.progressNomralized;

        if (e.progressNomralized == 0f || e.progressNomralized == 1f) { Hide(); }
        else { Show(); }
    }

    private void Show() { gameObject.SetActive(true); }
    private void Hide() { gameObject.SetActive(false); }

}
