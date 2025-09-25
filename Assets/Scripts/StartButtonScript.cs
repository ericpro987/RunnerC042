using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeRotation()
    {
        if(transform.rotation.y == 0)
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    public void Click()
    {
        this.GetComponent<Animator>().Play("BasketAnimation");
        new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }

}
