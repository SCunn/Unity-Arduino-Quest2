using UnityEngine;
// Code sourced from Naoise Collins Game Manager Tutorial
namespace GameManagers
{
    public class AudioManager : MonoBehaviour
    {
        // Variables ///////////////////

        // Instance to be used as a Singleton, only one instance of this class can exist
        public static AudioManager Instance;

        // AudioClip holds an array of audio clips which will be reffered to as soundEffects
        public AudioClip[] soundEffects;
        // AudioSource is a class component in Unity that plays audio clips, in this script it will be referenced as audioPlay
        private AudioSource audioPlay;

        private void Awake()
        {   // This code will make sure that there will be only one instance of our audio manager
            // if the AudioManager instance is null
            if (Instance == null)
            {   //set it to this instance and dont destroy it on load. The "this" keyword refers to the current instance of the class 
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this) // if any other occurance of this Instanse is created, then destroy the gameObject
            {
                Destroy(gameObject);
                return;
            }
            //  GetComponent<AudioSource>() will retrieve the AudioSource component attached to this instance
            audioPlay = GetComponent<AudioSource>();
        }

        // Methods //////////////////////

        // Play Sound Effect
        public void PlaySoundEffect(string clipName)
        {
            AudioClip clip = FindClipByName(clipName);
            if(clip != null)
            {
                audioPlay.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("Sound Effect not found: " + clipName);
            }
        }

        // Find Clip by Name
        private AudioClip FindClipByName(string clipName)
        {
            foreach(AudioClip clip in soundEffects) // loop trough the audioclips 
            {
                if (clip.name.Equals(clipName))     // if the name of the equals what we are looking for 
                {
                    return clip;        // return the clip
                }
            }
            return null;
        }

    }
}
