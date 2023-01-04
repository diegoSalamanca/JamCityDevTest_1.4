/*Exercise made by Diego Salamanca for Jam City, on January 3 of 2023
Email: Diegocolmayor@gmial.com
Phone: +57 3508232690 Bogotá Colombia*/
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField]
    Player player;
    
    [SerializeField]
    AudioSource SFXAudioSource;

     [SerializeField]
    AudioSource StepsAudioSource;

     [SerializeField]
    AudioSource MusicAudioSource;

    [SerializeField]
    AudioClip[] stepsSounds;

    [SerializeField]
    AudioClip[] sfxSounds;



    void PlayRandomSfxSound()
    {
        var index = (int)Random.Range(0,sfxSounds.Length);
        SFXAudioSource.PlayOneShot(sfxSounds[index]);
    }

   private void Update() {

    if( Input.GetKeyDown(KeyCode.Space) )
    {
        PlayRandomSfxSound();
    }


    if(player.IsMoving)
    {
        switch (player.CurrentFloor)
        {
            
            default:
            StepsAudioSource.clip = stepsSounds[0];
            

            break;

            case FloorType.None:
                StepsAudioSource.clip = stepsSounds[3];
                
            break;

             case FloorType.Grass:
                StepsAudioSource.clip = stepsSounds[0];
            
            break;

             case FloorType.Metal:
                StepsAudioSource.clip = stepsSounds[1];
            
            break;

             case FloorType.Wood:
                StepsAudioSource.clip = stepsSounds[2];
            
            break;
        }
        
        if(!StepsAudioSource.isPlaying)
        StepsAudioSource.Play();
    }
    else
    {
        StepsAudioSource.Stop();
    }
    
   }

   public void MusicVolumenSet(float value)
   {
      MusicAudioSource.volume = value;
   }

   public void SFXVolumenSet(float value)
   {
      SFXAudioSource.volume = value;
   }

    public void StepVolumenSet(float value)
   {
      StepsAudioSource.volume = value;
   }

   public void MasterVolumenSet(float value)
   {
     AudioListener.volume = value;
   }

}
