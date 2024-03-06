using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArManager : MonoBehaviour
{
    [SerializeField] private FoundationData[] Foundations;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private AudioSource audioSource;
    private AudioClip audioClip;
    private int choiceFoundation;
    public int lenguageID;
    private bool isMusicPlaying = false; // Menandakan apakah musik sedang diputar

    // Start is called before the first frame update
    void Start()
    {
        // mengambil penyimpanan data
        choiceFoundation = PlayerPrefs.GetInt("ChoiceFoundation"); 
        lenguageID = PlayerPrefs.GetInt("LocaleKey");
        if (lenguageID == 0)
        {
            DisplayDescriptionFoundationEN();
        }
        else
        {
            DisplayDescriptionFoundationID();
        }
    }

    void DisplayDescriptionFoundationID() // fungsi menampilkan bahasa indonesia
    {
        titleText.text = Foundations[choiceFoundation].namaPondasi;
        descriptionText.text = Foundations[choiceFoundation].deskripsiPondasi;
        audioClip = Foundations[choiceFoundation].suaraPenjelasan;
    }

    void DisplayDescriptionFoundationEN() // fungsi menampilkan bahasa inggirs
    {
        titleText.text = Foundations[choiceFoundation].foundationName;
        descriptionText.text = Foundations[choiceFoundation].foundationDescription;
        audioClip = Foundations[choiceFoundation].soundDescription;
    }

    public void ToggleMusic() // fungsi untuk mengeluarkan suara
    {
        if (isMusicPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }

        isMusicPlaying = !isMusicPlaying; // Mengubah status pemutaran musik
    }
}
