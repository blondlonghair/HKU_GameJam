using JetBrains.Annotations;
using UnityEngine;

namespace JongChan
{
    public class AIStuff : Stuff
    {
        public void LeaveMessage(bool isFire)
        {
            if (isFire)
            {
                if (IsBroken)
                {
                    UIManager.Instance.ShowNotification("", "There's no fire in this ship. It's clean.", 2f);
                    SoundManager.Instance.PlaySFXSound("Siren");
                    SoundManager.Instance.PlaySFXSound("Fire-Broken");
                }
                else
                {
                    UIManager.Instance.ShowNotification("", "Our spaceship is on fire", 2f);
                    SoundManager.Instance.PlaySFXSound("Siren");
                    SoundManager.Instance.PlaySFXSound("Fire-Normal");
                }
            }

            else
            {
                if (IsBroken)
                {
                    UIManager.Instance.ShowNotification("", "Welcom stranger it is your new home", 2f);
                    SoundManager.Instance.PlaySFXSound("Siren");
                    SoundManager.Instance.PlaySFXSound("Enemy-Broken");
                }
                else
                {
                    UIManager.Instance.ShowNotification("", "Unwelcom visitor come into our ship", 2f);
                    SoundManager.Instance.PlaySFXSound("Siren");
                    SoundManager.Instance.PlaySFXSound("Enemy-Normal");
                }
            }
        }
    }
}