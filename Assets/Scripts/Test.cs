using UnityEngine;

public class Test : MonoBehaviour
{    
    void Start()
    {
        PlayerPrefs.SetString("NAME", "KYH");
        string name = PlayerPrefs.GetString("NAME");

        PlayerPrefs.SetFloat("EXP", 323344f);
        float exp = PlayerPrefs.GetFloat("EXP");

        PlayerPrefs.SetInt("HP", 100);
        int hp = PlayerPrefs.GetInt("HP");

        PlayerPrefs.Save();
    }
}
