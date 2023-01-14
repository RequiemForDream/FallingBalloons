using UnityEngine;

namespace BalloonStaff 
{   
    public class BalloonDestruction : MonoBehaviour
    {
        public void PlayerDestruction(int reward, float damage, BalloonType balloonType)
        {
           switch (balloonType)            
           {
                    case BalloonType.BonusBalloon:
                    EventBus.SendPlayerDestruction(reward);                 
                    break;
                    case BalloonType.DefaultBalloon:
                    EventBus.SendPlayerDestruction(reward);
                    break;                                       
                    case BalloonType.DamageBalloon:
                    EventBus.SendFallDestruction(damage);                   
                    break;
           }
        }

        public void FallDestruction(int reward, float damage, BalloonType balloonType)
        {
            switch (balloonType)
            {
                    case BalloonType.DefaultBalloon:
                    EventBus.SendFallDestruction(damage);
                    break;
                    case BalloonType.BonusBalloon:
                    EventBus.SendFallDestruction(damage);
                    break;
                    case BalloonType.DamageBalloon:
                    EventBus.SendPlayerDestruction(reward);
                    break;
            }
        }
    }
}


