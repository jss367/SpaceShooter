using UnityEngine;
using System.Collections;

/// <summary>
/// This class should be attached to the game object that contains an audio source.  If enabled, it will replace 
/// the current clip on the audio source with the microphone input.
/// </summary>
[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Visualizer Studio/Utility/Microphone")]
public class VisMicrophone : MonoBehaviour
{
    public string microphoneDevice = "Default";

    float totalTime = 0.0f;
    float currentTime = 0.0f;
    float elapsedTime = 0.0f;
    int totalFrames = 0;

    void Start()
    {
        totalTime = audio.clip.length;
        currentTime = 0.0f;

        audio.Play();
        audio.volume = 0.0f;

        

        //make sure it's okay to start the microphone
        /*if (audio && Microphone.devices != null && Microphone.devices.Length > 0)
        {
            //get index
            int index = 0;
            for (int i = 0; i < Microphone.devices.Length; i++)
            {
                if (Microphone.devices[i].Equals(microphoneDevice, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            //assign and start microphone and then mute the audio source
            audio.clip = Microphone.Start(Microphone.devices[index], true, 999, AudioSettings.outputSampleRate);
            audio.mute = true;

            //HACK - Wait for microphone to be ready
            while (!(Microphone.GetPosition(Microphone.devices[index]) > 0)) { }

            //start the audio source
            audio.Play();
        }
        else if (audio)
            Debug.LogWarning("No audio source was found, can't start microphone! You must attach thise script to the same Game Object as an Audio Source.");
        else if (Microphone.devices == null || Microphone.devices.Length <= 0)
            Debug.LogWarning("No microphone devices were found, can't start microphone!");
        else
            Debug.LogWarning("Unknown issue, can't start microphone!");*/
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (currentTime <= totalTime)
        {
            totalFrames++;
            float[] samples = audio.GetSpectrumData(256, 0, FFTWindow.Blackman);

            //Debug.Log("Sample 16 = " + samples[16] + " @ " + audio.time);

            currentTime += 0.1f;
            audio.time = currentTime;
        }
        else if (audio.isPlaying)
        {
            audio.Stop();

            Debug.Log("Finished processing " + totalTime + " seconds (" + totalFrames + " frames) of audio in " + elapsedTime + " seconds!");
        }
    }
}