using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CORE_EX1_507 : SimTemplate //* 鱼人领军 Murloc Warleader
    {
        //Whenever you summon a Murloc, gain +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnMurlocWarleader++;
            else p.anzEnemyMurlocWarleader++;

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 2, 0);
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnMurlocWarleader--;
            else p.anzEnemyMurlocWarleader--;

            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(mn, -2, 0);
            }
        }

    }
}