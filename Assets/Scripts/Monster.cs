using UnityEngine;

public class Monster : MonoBehaviour
{
    public AudioClip clip;

    private void Attack()
    {
        // °ø°Ý·Î£“
        Managers.Sound.Play(Define.Sound.Effect, "Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(clip);

        //float lifeTime = clip.length;
        //Managers.Resource.Destroy(gameObject, lifeTime * 0.7f);

        Managers.Sound.Play(Define.Sound.Effect, "univ0001");

    }
}
