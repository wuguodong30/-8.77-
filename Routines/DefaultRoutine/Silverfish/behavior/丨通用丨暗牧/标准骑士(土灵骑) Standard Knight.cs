using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBot.Mulligan
{
    [Serializable]
    public class DefaultMulliganProfile : MulliganProfile
    {
        List<Card.Cards> CardsToKeep = new List<Card.Cards>();

        private readonly List<Card.Cards> WorthySpells = new List<Card.Cards> {};
        // 一费卡
        private readonly HashSet<Card.Cards> OneCostCards = new HashSet<Card.Cards>
        {
            Card.Cards.RLK_039,
        };
        // 保留的卡
        private readonly HashSet<Card.Cards> KeepableCards = new HashSet<Card.Cards>
        {
            Card.Cards.WW_331, // 奇迹推销员 WW_331
            Card.Cards.WW_344, //威猛银翼巨龙 WW_344
            Card.Cards.WW_391, //  淘金客 WW_391
            Card.Cards.DEEP_017, //   采矿事故 DEEP_017
            Card.Cards.VAC_955, //  戈贡佐姆 VAC_955
            Card.Cards.CORE_ICC_038, // 正义保护者 CORE_ICC_038
            Card.Cards.CORE_ULD_723, //鱼人木乃伊 CORE_ULD_723
            Card.Cards.CORE_GVG_061, //  作战动员 CORE_GVG_061
            Card.Cards.ETC_318, //  布吉舞乐 ETC_318
            Card.Cards.TTN_860, //  无人机拆解器 TTN_860
            Card.Cards.ETC_418, //  乐器技师 ETC_418
            Card.Cards.CORE_CFM_753, //  污手街供货商 CORE_CFM_753
            Card.Cards.YOG_525, //  健身肌器人 YOG_525
            Card.Cards.TOY_810, //  画师的美德 TOY_810
            Card.Cards.VAC_958, //  VAC_958	进化融合怪
            // 土灵骑
            Card.Cards.WORK_006, //  拨号机器人 WORK_006
            Card.Cards.VAC_332, //  海滩导购 VAC_332
            Card.Cards.VAC_330, //  金属探测器 VAC_330
            Card.Cards.TTN_900, //  石心之王 TTN_900
            Card.Cards.TTN_856, //  阿米图斯的信徒 TTN_856
            Card.Cards.TOY_812, //  皮普希·彩蹄 TOY_812
        };

        public List<Card.Cards> HandleMulligan(List<Card.Cards> choices, Card.CClass opponentClass, Card.CClass ownClass)
        {
            bool HasCoin = choices.Count >= 4;
            int flag1 = choices.Count(card => OneCostCards.Contains(card));
            int kuaigong = (opponentClass == Card.CClass.PALADIN || opponentClass == Card.CClass.HUNTER || opponentClass == Card.CClass.PRIEST || opponentClass == Card.CClass.ROGUE || opponentClass == Card.CClass.WARRIOR || opponentClass == Card.CClass.DEMONHUNTER) ? 1 : 0;
            int mansu = (opponentClass == Card.CClass.DRUID || opponentClass == Card.CClass.MAGE || opponentClass == Card.CClass.SHAMAN) ? 1 : 0;

            foreach (Card.Cards card in choices.Where(card => KeepableCards.Contains(card) && !CardsToKeep.Contains(card)))
            {
                Keep(card);
            }

            return CardsToKeep;
        }

        public void Keep(Card.Cards card)
        {
            CardsToKeep.Add(card);
        }
    }
}
