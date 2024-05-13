using Adrenak.UniVoice;
using Adrenak.UniVoice.AudioSourceOutput;
using Adrenak.UniVoice.MirrorNetwork;
using Adrenak.UniVoice.UniMicInput;
using UnityEngine;

public class ChatroomManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var agent = new ChatroomAgent(new UniVoiceMirrorNetwork(), new UniVoiceUniMicInput(0, 8000, 50), new UniVoiceAudioSourceOutput.Factory());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
