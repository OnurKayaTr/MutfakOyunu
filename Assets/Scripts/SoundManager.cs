using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_EFF_VOLUME = "SoundEffVolume";
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefSO audioClipRefSO;

    private float volume=1f;
    private void Awake()
    {
        Instance = this;
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFF_VOLUME, 1f);
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnpickedSomething += Player_OnpickedSomething;
        BaseCounter.OnAnyObjPlacedHere += BaseCounter_OnAnyObjPlacedHere;
        TrashCounter.OnAnyObjTrashed += TrashCounter_OnAnyObjTrashed;

    }

    private void TrashCounter_OnAnyObjTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;

        PlaySound(audioClipRefSO.trash, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipRefSO.objectDrop, baseCounter.transform.position);
    }

    private void Player_OnpickedSomething(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.objectPickup, Player.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRefSO.chop, cuttingCounter.transform.position);

    }


    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefSO.deliveryFail, deliveryCounter.transform.position);
        

    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefSO.deliverySuccses, deliveryCounter.transform.position);
        

    }

    private void PlaySound(AudioClip audioClip , Vector3 position , float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip , position , volume );
    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volumeMultiplayer = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volumeMultiplayer * volume);
        
    }

   /* public void PlayerFootstepsSound(Vector3 position,float volume)
    {
        PlaySound(audioClipRefSO.footStep,position,volume);
    }*/

    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f) { volume = 0f; }

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFF_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() { return volume; }
}
