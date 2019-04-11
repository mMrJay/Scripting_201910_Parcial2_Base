using UnityEngine;

public class DoKamikazeAttack : Task
{
    private bool tocando;

    public override bool Execute()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        if (Vector3.Distance(transform.position, playerPos) < 1)
            tocando = true;

        if (tocando)
        {
            print("Te hice daño");
            GetComponent<AICharacter>().ModifyHP(TargetAI.GetComponent<AICharacter>().HP * -1.0f);
            print(TargetAI.GetComponent<AICharacter>().HP);
        }

        print("estoy tocando:" + tocando);
        return tocando;
    }

    
}