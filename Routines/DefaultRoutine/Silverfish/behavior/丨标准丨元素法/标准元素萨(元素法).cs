using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
using SmartBotAPI.Plugins.API;
using SmartBotAPI.Battlegrounds;
using SmartBot.Plugins.API.Actions;


/* Explanation on profiles :
 * 
 * 配置文件中定义的所有值都是百分比修饰符，这意味着它将影响基本配置文件的默认值。
 * 
 * 修饰符值可以在[-10000;范围内设置。 10000]（负修饰符有相反的效果）
 * 您可以为非全局修改器指定目标，这些目标特定修改器将添加到卡的全局修改器+修改器之上（无目标）
 * 
 * 应用的总修改器=全局修改器+无目标修改器+目标特定修改器
 * 
 * GlobalDrawModifier --->修改器应用于卡片绘制值
 * GlobalWeaponsAttackModifier --->修改器适用于武器攻击的价值，它越高，人工智能攻击武器的可能性就越小
 * 
 * GlobalCastSpellsModifier --->修改器适用于所有法术，无论它们是什么。修饰符越高，AI玩法术的可能性就越小
 * GlobalCastMinionsModifier --->修改器适用于所有仆从，无论它们是什么。修饰符越高，AI玩仆从的可能性就越小
 * 
 * GlobalAggroModifier --->修改器适用于敌人的健康值，越高越好，人工智能就越激进
 * GlobalDefenseModifier --->修饰符应用于友方的健康值，越高，hp保守的将是AI
 * 
 * CastSpellsModifiers --->你可以为每个法术设置个别修饰符，修饰符越高，AI玩法术的可能性越小
 * CastMinionsModifiers --->你可以为每个小兵设置单独的修饰符，修饰符越高，AI玩仆从的可能性越小
 * CastHeroPowerModifier --->修饰符应用于heropower，修饰符越高，AI玩它的可能性就越小
 * 
 * WeaponsAttackModifiers --->适用于武器攻击的修饰符，修饰符越高，AI攻击它的可能性越小
 * 
 * OnBoardFriendlyMinionsValuesModifiers --->修改器适用于船上友好的奴才。修饰语越高，AI就越保守。
 * OnBoardBoardEnemyMinionsModifiers --->修改器适用于船上的敌人。修饰符越高，AI就越会将其视为优先目标。
 *
 */

namespace SmartBotProfiles
{
    [Serializable]
    public class standardeggPaladin  : Profile
    {
        #region 英雄技能
        //幸运币
        private const Card.Cards TheCoin = Card.Cards.GAME_005;
        //战士
        private const Card.Cards ArmorUp = Card.Cards.HERO_01bp;
        //萨满
        private const Card.Cards TotemicCall = Card.Cards.HERO_02bp;
        //盗贼
        private const Card.Cards DaggerMastery = Card.Cards.HERO_03bp;
        //圣骑士
        private const Card.Cards Reinforce = Card.Cards.HERO_04bp;
        //猎人
        private const Card.Cards SteadyShot = Card.Cards.HERO_05bp;
        //德鲁伊
        private const Card.Cards Shapeshift = Card.Cards.HERO_06bp;
        //术士
        private const Card.Cards LifeTap = Card.Cards.HERO_07bp;
        //法师
        private const Card.Cards Fireblast = Card.Cards.HERO_08bp;
        //牧师
        private const Card.Cards LesserHeal = Card.Cards.HERO_09bp;
        #endregion

#region 英雄能力优先级
        private readonly Dictionary<Card.Cards, int> _heroPowersPriorityTable = new Dictionary<Card.Cards, int>
        {
            {SteadyShot, 9},//猎人
            {LifeTap, 8},//术士
            {DaggerMastery, 7},//盗贼
            {Reinforce, 5},//骑士
            {Fireblast, 4},//法师
            {Shapeshift, 3},//德鲁伊
            {LesserHeal, 2},//牧师
            {ArmorUp, 1},//战士
        };
        private int GetTag(Card c, Card.GAME_TAG tag)
        {
            if (c.tags != null && c.tags.ContainsKey(tag))
                return c.tags[tag];
            return -1;
        }
         private int GetSireDenathriusDamageCount(Card c)
        {
            return GetTag(c, Card.GAME_TAG.TAG_SCRIPT_DATA_NUM_2);
        }
#endregion

#region 直伤卡牌 标准模式
        //直伤法术卡牌（必须是可打脸的伤害） 需要计算法强
        private static readonly Dictionary<Card.Cards, int> _spellDamagesTable = new Dictionary<Card.Cards, int>
        {
            //萨满
            {Card.Cards.CORE_EX1_238, 3},//闪电箭 Lightning Bolt     CORE_EX1_238
            {Card.Cards.DMF_701, 4},//深水炸弹 Dunk Tank     DMF_701
            {Card.Cards.DMF_701t, 4},//深水炸弹 Dunk Tank     DMF_701t
            {Card.Cards.BT_100, 3},//毒蛇神殿传送门 Serpentshrine Portal     BT_100 
            //德鲁伊

            //猎人
            {Card.Cards.BAR_801, 1},//击伤猎物 Wound Prey     BAR_801
            {Card.Cards.CORE_DS1_185, 2},//奥术射击 Arcane Shot     CORE_DS1_185
            {Card.Cards.CORE_BRM_013, 3},//快速射击 Quick Shot     CORE_BRM_013
            {Card.Cards.BT_205, 3},//废铁射击 Scrap Shot     BT_205 
            //法师
            {Card.Cards.BAR_541, 2},//符文宝珠 Runed Orb     BAR_541 
            {Card.Cards.CORE_CS2_029, 6},//火球术 Fireball     CORE_CS2_029
            {Card.Cards.BT_291, 5},//埃匹希斯冲击 Apexis Blast     BT_291 
            //骑士
            {Card.Cards.CORE_CS2_093, 2},//奉献 Consecration     CORE_CS2_093 
            //牧师
            //盗贼
            {Card.Cards.BAR_319, 2},//邪恶挥刺（等级1） Wicked Stab (Rank 1)     BAR_319
            {Card.Cards.BAR_319t, 4},//邪恶挥刺（等级2） Wicked Stab (Rank 2)     BAR_319t
            {Card.Cards.BAR_319t2, 6},//邪恶挥刺（等级3） Wicked Stab (Rank 3)     BAR_319t2 
            {Card.Cards.CORE_CS2_075, 3},//影袭 Sinister Strike     CORE_CS2_075
            {Card.Cards.TSC_086, 4},//剑鱼 TSC_086
            //术士
            {Card.Cards.CORE_CS2_062, 3},//地狱烈焰 Hellfire     CORE_CS2_062
            //战士
            {Card.Cards.DED_006, 6},//重拳先生 DED_006
            //中立
            {Card.Cards.DREAM_02, 5},//伊瑟拉苏醒 Ysera Awakens     DREAM_02
            {Card.Cards.TOY_508, 2},//立体书  TOY_508
        };
        //直伤随从卡牌（必须可以打脸）
        private static readonly Dictionary<Card.Cards, int> _MinionDamagesTable = new Dictionary<Card.Cards, int>
        {
            //盗贼
            {Card.Cards.BAR_316, 2},//油田伏击者 Oil Rig Ambusher     BAR_316 
            //萨满
            {Card.Cards.CORE_CS2_042, 4},//火元素 Fire Elemental     CORE_CS2_042 
            //德鲁伊
            //术士
            {Card.Cards.CORE_CS2_064, 1},//恐惧地狱火 Dread Infernal     CORE_CS2_064 
            //中立
            {Card.Cards.CORE_CS2_189, 1},//精灵弓箭手 Elven Archer     CORE_CS2_189
            {Card.Cards.CS3_031, 8},//生命的缚誓者阿莱克丝塔萨 Alexstrasza the Life-Binder     CS3_031 
            {Card.Cards.DMF_174t, 4},//马戏团医师 Circus Medic     DMF_174t
            {Card.Cards.DMF_066, 2},//小刀商贩 Knife Vendor     DMF_066 
            {Card.Cards.SCH_199t2, 2},//转校生 Transfer Student     SCH_199t2 
            {Card.Cards.SCH_273, 1},//莱斯·霜语 Ras Frostwhisper     SCH_273
            {Card.Cards.BT_187, 3},//凯恩·日怒 Kayn Sunfury     BT_187
            {Card.Cards.BT_717, 2},//潜地蝎 Burrowing Scorpid     BT_717 
            {Card.Cards.CORE_EX1_249, 2},//迦顿男爵 Baron Geddon     CORE_EX1_249 
            {Card.Cards.DMF_254, 30},//迦顿男爵 Baron Geddon     CORE_EX1_249 
            {Card.Cards.RLK_222t2, 14},//火焰使者阿斯塔洛 Astalor, the Flamebringer ID：RLK_222t2
            {Card.Cards.RLK_224, 2},//监督者弗里吉达拉 Overseer Frigidara ID：RLK_224
             {Card.Cards.RLK_063, 5},//冰霜巨龙之怒 Frostwyrm's Fury ID：RLK_063 
            {Card.Cards.RLK_015, 3},//凛风冲击 Howling Blast ID：RLK_015 
            {Card.Cards.RLK_516, 2},//碎骨手斧 Bone Breaker ID：RLK_516
        };
        #endregion

#region 攻击模式和自定义 
      private string _log = "";   // 日志字符串
      public ProfileParameters GetParameters(Board board)
      {
            var p = new ProfileParameters(BaseProfile.Rush) { DiscoverSimulationValueThresholdPercent = -10 }; 
            //  增加思考时间
             
            int a =(board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - BoardHelper.GetEnemyHealthAndArmor(board);
            //攻击模式切换
            // 德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER
            if(board.HeroEnemy.CurrentHealth<=10){
                p.GlobalAggroModifier = 200;
                AddLog("走脸");
            }else
            {
                p.GlobalAggroModifier = (int)(a * 0.625 + 300.5);
                AddLog("攻击值"+(a * 0.625 + 300.5));
            }	   

       {
 
        
            int myAttack = 0;
            int enemyAttack = 0;

            if (board.MinionFriend != null)
            {
                for (int x = 0; x < board.MinionFriend.Count; x++)
                {
                    myAttack += board.MinionFriend[x].CurrentAtk;
                }
            }

            if (board.MinionEnemy != null)
            {
                for (int x = 0; x < board.MinionEnemy.Count; x++)
                {
                    enemyAttack += board.MinionEnemy[x].CurrentAtk;
                }
            }

            if (board.WeaponEnemy != null)
            {
                enemyAttack += board.WeaponEnemy.CurrentAtk;
            }

            if ((int)board.EnemyClass == 2 || (int)board.EnemyClass == 7 || (int)board.EnemyClass == 8)
            {
                enemyAttack += 1;
            }
            else if ((int)board.EnemyClass == 6)
            {
                enemyAttack += 2;
            }   
         //定义场攻  用法 myAttack <= 5 自己场攻大于小于5  enemyAttack  <= 5 对面场攻大于小于5  已计算武器伤害

            int myMinionHealth = 0;
            int enemyMinionHealth = 0;

            if (board.MinionFriend != null)
            {
                for (int x = 0; x < board.MinionFriend.Count; x++)
                {
                    myMinionHealth += board.MinionFriend[x].CurrentHealth;
                }
            }

            if (board.MinionEnemy != null)
            {
                for (int x = 0; x < board.MinionEnemy.Count; x++)
                {
                    enemyMinionHealth += board.MinionEnemy[x].CurrentHealth;
                }
            }
            // 友方随从数量
            int friendCount = board.MinionFriend.Count;
            // 手牌数量
            int HandCount = board.Hand.Count;
             // 通电机器人 BOT_907
            int usedtd=board.MinionFriend.Count(x => x.Template.Id == Card.Cards.BOT_907)+board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.BOT_907);
            int aomiCount = board.Secret.Count;
            int minionNumber=board.Hand.Count(card => card.Type == Card.CType.MINION);
            var TheVirtuesofthePainter = board.Hand.FirstOrDefault(x => x.Template.Id == Card.Cards.TOY_810);
            // 可攻击随从
            int canAttackMINIONs=board.MinionFriend.Count(card => card.CanAttack);
            // 坟场邪能法术的数量 伞降咒符 VAC_925
            int felCount = board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.VAC_925);
            // 立体书  TOY_508 坟场自然法术   电流导联 YOG_522
            int toyCount = board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.TOY_508)+board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.YOG_522);
            // 即兴演奏 JAM_013 坟场火焰法术
            int jamCount = board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.JAM_013);
            // 坟场暗影法术,生死一线 VAC_931
            int shadowCount = board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.VAC_931);
            //   本轮使用过的元素 
            var isUsedEle = board.MinionFriend.Any(x => x.Template.IsRace(Card.CRace.ELEMENTAL)&& x.GetTag(Card.GAME_TAG.JUST_PLAYED) ==1);
            var useAFeeEntourage = board.MinionFriend.Any(x => x.CurrentCost==1&& x.GetTag(Card.GAME_TAG.JUST_PLAYED) ==1);
            AddLog("本轮使用过元素"+isUsedEle);
            AddLog("本轮使用过1费"+useAFeeEntourage);
            
 #endregion
 #region 不送的怪
          p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.WW_331, new Modifier(150)); //奇迹推销员 WW_331
        //   p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.CORE_ULD_723, new Modifier(150)); //鱼人木乃伊 CORE_ULD_723 
#endregion
#region 送的怪
        
          if(board.HasCardOnBoard(Card.Cards.TSC_962)){//修饰老巨鳍 Gigafin ID：TSC_962 
          p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.TSC_962t, new Modifier(-100)); //修饰老巨鳍之口 Gigafin's Maw ID：TSC_962t 
          }
          p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.REV_373t, new Modifier(-100)); //具象暗影 Shadow Manifestation ID：REV_373t 
          p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.REV_955, new Modifier(-100)); //执事者斯图尔特 Stewart the Steward ID：REV_955 
#endregion

#region Card.Cards.HERO_02bp 英雄技能
        p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.HERO_02bp, new Modifier(130)); 
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.HERO_02bp, new Modifier(-5)); 
#endregion

#region WW_331	奇迹推销员
         if(board.HasCardInHand(Card.Cards.WW_331)
         &&board.MaxMana>=5
		){
        	p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_331, new Modifier(150)); 
					AddLog("奇迹推销员 150");
		}else{
        	p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_331, new Modifier(250)); 
        }
#endregion

#region 戈贡佐姆 VAC_9150
        // 提高优先级
        if(board.HasCardInHand(Card.Cards.VAC_955)
        )
        {
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_955, new Modifier(-350));
          AddLog("戈贡佐姆-350");
        }

#endregion

#region 飞行员帕奇斯 VAC_933
        if(board.HasCardInHand(Card.Cards.VAC_933)){
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_933, new Modifier(-350)); 
                AddLog("飞行员帕奇斯 -350");
        }
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.VAC_933, new Modifier(999)); 
#endregion


#region 伞降咒符 VAC_925
       if(board.HasCardInHand(Card.Cards.VAC_925)
        &&friendCount<5
        ){
        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.VAC_925, new Modifier(-550));   
        AddLog("伞降咒符 -550");
        }
#endregion

#region 贪婪的伴侣 WW_901
    //  如果没有被active,则不用
    if(board.Hand.Exists(card => GetTag(card, Card.GAME_TAG.POWERED_UP) == 1 && card.Template.Id == Card.Cards.WW_901)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_901, new Modifier(-99)); 
        AddLog("贪婪的伴侣 -99");
    }else{
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_901, new Modifier(350)); 
    }
#endregion

#region 悠闲的曲奇 VAC_450
    // 当场上可攻击随从大于的等于2时,提高优先级
    if (canAttackMINIONs >= 2 
        && board.HasCardInHand(Card.Cards.VAC_450)
        )
        {
            // 如果场上海盗大于2，提高优先级
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_450, new Modifier(canAttackMINIONs*-99));
        AddLog("悠闲的曲奇" + (canAttackMINIONs*-99));
        }
        else
        {
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_450, new Modifier(350));
        }
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.VAC_450, new Modifier(999)); 
#endregion

#region VAC_955t 美味奶酪
    // 如果当前手牌数小于等于3,且最大回合数大于等于8,提高优先级
     if (board.MinionFriend.Count<=4
     && board.MaxMana >= 8
     && board.HasCardInHand(Card.Cards.VAC_955t))
    {
        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.VAC_955t, new Modifier(-150));
        AddLog("美味奶酪 -150");
    }else{
        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.VAC_955t, new Modifier(350));
    }
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.VAC_955t, new Modifier(999));
#endregion

#region 硬币 GAME_005
    if(board.HasCardInHand(Card.Cards.GAME_005)
    && board.MaxMana >= 2
    ){
     p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(55));//硬币 GAME_005
    }
#endregion

#region 摇滚巨石 ETC_742
    // 如果ETC_742标记状态,提高优先级
     if(board.Hand.Exists(card => GetTag(card, Card.GAME_TAG.POWERED_UP) == 1 && card.Template.Id == Card.Cards.ETC_742)
    //  我方攻击力大于敌方攻击力
    &&myAttack>enemyAttack
        ){
            foreach(var c in board.Hand){
            if(c.Template.Id ==Card.Cards.ETC_742 && c.IsPowered){
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ETC_742, new Modifier(-150));
            AddLog("摇滚巨石 -150");
            }
            if(c.Template.Id ==Card.Cards.WW_436 && !c.IsPowered){
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ETC_742, new Modifier(350));
                }
            }
        }
#endregion

#region JAM_036 乐坛灾星玛加萨
        if(board.HasCardInHand(Card.Cards.JAM_036)
        &&board.Hand.Count <=5
        )
        {
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.JAM_036, new Modifier(-350)); 
          p.PlayOrderModifiers.AddOrUpdate(Card.Cards.JAM_036, new Modifier(3999)); 
          AddLog("乐坛灾星玛加萨 -350");
        }
#endregion

#region 烈焰亡魂 TTN_479
        if(board.HasCardInHand(Card.Cards.TTN_479)
        )
        {
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TTN_479, new Modifier(-350)); 
          p.PlayOrderModifiers.AddOrUpdate(Card.Cards.TTN_479, new Modifier(999)); 
          AddLog("烈焰亡魂 -350");
        }
        // 场上有烈焰亡魂,不送
        if(board.HasCardOnBoard(Card.Cards.TTN_479)
        ){
          p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.TTN_479, new Modifier(150)); 
          AddLog("烈焰亡魂 150");
        }
#endregion

#region 火羽精灵 CORE_UNG_809
        if(board.HasCardInHand(Card.Cards.CORE_UNG_809)
        )
        {
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CORE_UNG_809, new Modifier(-99)); 
          AddLog("火羽精灵 -99");
        }
#endregion

#region 艾泽里特巨人 WW_025
        if(board.HasCardInHand(Card.Cards.WW_025)
        &&isUsedEle!=true
        )
        {
          p.PlayOrderModifiers.AddOrUpdate(Card.Cards.WW_025, new Modifier(-50));
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_025, new Modifier(-99)); 
          AddLog("艾泽里特巨人使用优先级滞后");
        }else{
          p.PlayOrderModifiers.AddOrUpdate(Card.Cards.WW_025, new Modifier(999));
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_025, new Modifier(-550));
          AddLog("艾泽里特巨人-550");
        }
#endregion

#region 暗石守卫 DEEP_027
        if(board.HasCardInHand(Card.Cards.DEEP_027)
        )
        {
          p.ForgeModifiers.AddOrUpdate(Card.Cards.DEEP_027, new Modifier(-99)); 
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DEEP_027, new Modifier(350)); 
          AddLog("锻造暗石守卫");
        }
#endregion

#region 暗石守卫 DEEP_027t
        if(board.HasCardInHand(Card.Cards.DEEP_027t)
        )
        {
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DEEP_027t, new Modifier(-99)); 
          AddLog("暗石守卫-99");
        }
#endregion

#region 湍流元素特布勒斯 WORK_013
        if(board.HasCardInHand(Card.Cards.WORK_013)
        )
        {
          p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WORK_013, new Modifier(-550)); 
          AddLog("湍流元素特布勒斯 -550");
        }
#endregion

#region 降低非元素随从牌使用优先级
    //    遍历手牌,如果不是元素随从牌,降低对其使用优先级
    foreach(var c in board.Hand)
    {
        if(!c.Template.IsRace(Card.CRace.ELEMENTAL)&&!isUsedEle){
            p.CastMinionsModifiers.AddOrUpdate(c.Template.Id, new Modifier(200));
            p.CastSpellsModifiers.AddOrUpdate(c.Template.Id, new Modifier(200));
            AddLog("非元素随从牌使用优先级降低"+c.Template.Id);
        }
    }
#endregion

 #region WW_027	可靠陪伴
           // 遍历场上随从,如果类型是图腾,提高可靠陪伴
           if(board.HasCardInHand(Card.Cards.WW_027)
           &&isUsedEle==true
           ){
            foreach (var minion in board.Hand)
            {
                    if (minion.IsRace(Card.CRace.TOTEM))
                    {
                        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.WW_027, new Modifier(350,minion.Template.Id));
                        AddLog("降低可靠陪伴对图腾的使用优先级");
                    }
                    if (minion.IsRace(Card.CRace.ELEMENTAL)
                    &&minion.CanAttack==true
                    )
                    {
                        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.WW_027, new Modifier(-99,minion.Template.Id));
                        AddLog("提高可靠陪伴对可攻击元素的使用优先级");
                    }
                }
           }
#endregion

#region 步移山丘 WW_382
    // 提高优先级
    if(board.HasCardInHand(Card.Cards.WW_382)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_382, new Modifier(-350));
        AddLog("步移山丘 -350");
    }
#endregion

#region 消融元素 VAC_328
    // 提高优先级
    if(board.HasCardInHand(Card.Cards.VAC_328)
    ){
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.VAC_328, new Modifier(500));
        AddLog("消融元素 500");
    }
#endregion

#region 塞拉赞恩 DEEP_036
    // 提高优先级
    if(board.HasCardInHand(Card.Cards.DEEP_036)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DEEP_036, new Modifier(-350));
        AddLog("塞拉赞恩 -350");
    }
    if(board.HasCardOnBoard(Card.Cards.DEEP_036)
    ){
        // 主动送掉
        p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.DEEP_036, new Modifier(-350));
        AddLog("塞拉赞恩 送");
    }
#endregion

#region 燃灯元素 VAC_442
    // 提高优先级
    if(board.HasCardInHand(Card.Cards.VAC_442)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_442, new Modifier(350));
        AddLog("燃灯元素 350");
    }
    // 燃灯元素 VAC_442不对骑士泰坦TTN_858	维和者阿米图斯使用
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_442, new Modifier(350,Card.Cards.TTN_858));
#endregion

 #region CORE_AT_053 先祖知识
        if(board.HasCardInHand(Card.Cards.CORE_AT_053)
        &&isUsedEle==true
        ){
        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CORE_AT_053, new Modifier(-150)); 
        AddLog("先祖知识-150");
        }else{
        p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CORE_AT_053, new Modifier(150)); 
        }	
 #endregion

 #region 消融元素 VAC_328
        // 如果敌方没有随从,降低消融元素优先级
        if(board.MinionEnemy.Count==0
        // 且我方血量大于15
        &&board.HeroFriend.CurrentHealth>=15
        &&board.HasCardInHand(Card.Cards.VAC_328)
        ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_328, new Modifier(200));
        AddLog("消融元素 200");
        }
 #endregion

 #region 摇滚巨石 ETC_742
    //  处于非标记状态,降低使用优先级
    if(board.Hand.Exists(card => GetTag(card, Card.GAME_TAG.POWERED_UP) != 1 && card.Template.Id == Card.Cards.ETC_742)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ETC_742, new Modifier(150));
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.ETC_742, new Modifier(-500));
        AddLog("摇滚巨石 150");
    }   
 #endregion

 #region 伊辛迪奥斯 VAC_321
      if(board.HasCardInHand(Card.Cards.VAC_321)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.VAC_321, new Modifier(-150));
        AddLog("伊辛迪奥斯 -150");
    }
 #endregion

 #region 页岩蛛 DEEP_034
    //  处于非标记状态,降低使用优先级
    if(board.Hand.Exists(card => GetTag(card, Card.GAME_TAG.POWERED_UP) == 1 && card.Template.Id == Card.Cards.DEEP_034)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DEEP_034, new Modifier(-150));
        AddLog("页岩蛛 -150");
    }   
 #endregion

 #region 矿车巡逻兵 WW_326
    if(board.Hand.Exists(card => GetTag(card, Card.GAME_TAG.POWERED_UP) == 1 && card.Template.Id == Card.Cards.WW_326)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_326, new Modifier(-99));
        AddLog("矿车巡逻兵 -99");
    }   
 #endregion

 #region 冰川裂片 CORE_UNG_205
     if(board.HasCardInHand(Card.Cards.CORE_UNG_205)
    ){
        // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CORE_UNG_205, new Modifier(130));
        // AddLog("冰川裂片 130");
        // 遍历敌方随从,冻结攻击力最大的那个
        int maxAtk = 0;
        Card target = null;
        foreach (var minion in board.MinionEnemy)
        {
            if (minion.CurrentAtk > maxAtk)
            {
                maxAtk = minion.CurrentAtk;
                target = minion;
            }
        }
        if (target != null)
        {
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CORE_UNG_205, new Modifier(-99, target.Template.Id));
            AddLog("冰川裂片 -99"+target.Template.Id);
        }
    }
        p.PlayOrderModifiers.AddOrUpdate(Card.Cards.CORE_UNG_205, new Modifier(-99));
 #endregion

 #region 苏打火山 TOY_500
     if(board.HasCardInHand(Card.Cards.TOY_500)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TOY_500, new Modifier(-5));
        AddLog("苏打火山 -5");
    }
 #endregion

 #region 灾变飓风斯卡尔 WW_026
     if(board.HasCardInHand(Card.Cards.WW_026)
    ){
        p.CastMinionsModifiers.AddOrUpdate(Card.Cards.WW_026, new Modifier(130));
        AddLog("灾变飓风斯卡尔 130");
    }
 #endregion


#region 重新思考
var resimulationCardModifiers = new Dictionary<Card.Cards, int>
{
    { Card.Cards.CORE_UNG_205,0 }, // 冰川裂片 CORE_UNG_205
    { Card.Cards.CORE_UNG_809,0 }, // 火羽精灵 CORE_UNG_809
    { Card.Cards.YOG_524,0 }, // 雷电跳蛙 YOG_524
    { Card.Cards.CORE_BOT_533,0 }, // 凶恶的雨云 CORE_BOT_533
    { Card.Cards.WW_027,0 }, // 可靠陪伴 WW_027
    { Card.Cards.ETC_742,0 }, // 摇滚巨石 ETC_742
    { Card.Cards.TTN_479,0 }, // 烈焰亡魂 TTN_479
    { Card.Cards.DEEP_034,0 }, // 页岩蛛 DEEP_034
    { Card.Cards.VAC_328,0 }, // 消融元素 VAC_328
    { Card.Cards.WORK_013,0 }, // 湍流元素特布勒斯 WORK_013
    { Card.Cards.WW_326,0 }, // 矿车巡逻兵 WW_326
    { Card.Cards.VAC_442,0 }, // 燃灯元素 VAC_442
    { Card.Cards.JAM_036,0 }, // 乐坛灾星玛加萨 JAM_036
    { Card.Cards.WW_024,0 }, // 活体原野岩 WW_024
    { Card.Cards.WW_026,0 }, // 灾变飓风斯卡尔 WW_026
    { Card.Cards.Core_UNG_211,0 }, // 荒蛮之主卡利莫斯 Core_UNG_211
    { Card.Cards.WW_025,0 }, // 艾泽里特巨人 WW_025
    { Card.Cards.WW_375,0 }, // 偃息的焰喉  WW_375
};

foreach (var cardModifier in resimulationCardModifiers)
{
    p.ForcedResimulationCardList.Add(cardModifier.Key);
}
#endregion

#region 攻击优先 卡牌威胁
var cardModifiers = new Dictionary<Card.Cards, int>
{
    { Card.Cards.VAC_507, 200 }, // 阳光汲取者莱妮莎 VAC_507
    { Card.Cards.WORK_042, 200 }, // 食肉格块 WORK_042
    { Card.Cards.WW_344, 200 }, // 威猛银翼巨龙 
    { Card.Cards.TOY_812, -5 },//TOY_812 皮普希·彩蹄
    { Card.Cards.VAC_532, 200 },//椰子火炮手 VAC_532
    { Card.Cards.RLK_511, 200 },//寒冬先锋	RLK_511
    { Card.Cards.TOY_518, 250 },//TOY_518	宝藏经销商
    { Card.Cards.TOY_505, 200 },//TOY_505	玩具船
 { Card.Cards.TOY_351t, 350 },//TOY_351t	神秘的蛋
    { Card.Cards.TOY_351, 350 },//TOY_351	神秘的蛋
    { Card.Cards.VAC_926t, 100 },//VAC_926t	坠落的伊利达雷
    { Card.Cards.TOY_381, 200 },//TOY_381	纸艺天使
    { Card.Cards.TSC_908, 55 }, // TSC_908	海中向导芬利爵士
    
    { Card.Cards.WORK_013, 55 }, // 湍流元素特布勒斯 WORK_013
    { Card.Cards.WW_901, 100 }, // WW_901	贪婪的伴侣
    { Card.Cards.TOY_824, 200 }, // 黑棘针线师
    { Card.Cards.VAC_927, 200 }, // 狂飙邪魔
    { Card.Cards.VAC_938, 200 }, // 粗暴的猢狲
    { Card.Cards.ETC_355, 200 }, // 剃刀沼泽摇滚明星
    { Card.Cards.WW_091, 200 },  // 腐臭淤泥波普加
    { Card.Cards.VAC_450, 999 }, // 悠闲的曲奇
    { Card.Cards.TOY_028, 200 }, // 团队之灵
    { Card.Cards.VAC_436, 200 }, // 脆骨海盗
    { Card.Cards.VAC_321, 200 }, // 伊辛迪奥斯
    { Card.Cards.TTN_800, 200 }, // 雷霆之神高戈奈斯
    { Card.Cards.TTN_415, 200 }, // 卡兹格罗斯
    { Card.Cards.ETC_541, 200 }, // 盗版之王托尼
    { Card.Cards.CORE_LOOT_231, 200 }, // 奥术工匠
    { Card.Cards.ETC_339, 200 }, // 心动歌手
    { Card.Cards.ETC_833, 200 }, // 箭矢工匠
    { Card.Cards.MIS_026, 500 }, // 傀儡大师多里安
    { Card.Cards.CORE_WON_065, 200 }, // 随船外科医师
    { Card.Cards.WW_357, 200 }, // 老腐和老墓
    { Card.Cards.DEEP_999t2, 200 }, // 深岩之洲晶簇
    { Card.Cards.CFM_039, 200 }, // 杂耍小鬼
    { Card.Cards.WW_364t, 200 }, // 狡诈巨龙威拉罗克
    { Card.Cards.TSC_026t, 200 }, // 可拉克的壳
   
    { Card.Cards.WW_415, 200 }, // 许愿井
    { Card.Cards.CS3_014, 200 }, // 赤红教士
    { Card.Cards.YOG_516, 200 }, // 脱困古神尤格-萨隆
    { Card.Cards.NX2_033, 200 }, // 巨怪塔迪乌斯
    { Card.Cards.JAM_004, 200 }, // 镂骨恶犬
    { Card.Cards.TTN_330, 200 }, // Kologarn
    { Card.Cards.TTN_729, 200 }, // Melted Maker
    { Card.Cards.TTN_812, 150 }, // Victorious Vrykul
    { Card.Cards.TTN_479, 200 }, // Flame Revenant
    { Card.Cards.TTN_732, 250 }, // Invent-o-matic
    { Card.Cards.TTN_466, 250 }, // Minotauren
    { Card.Cards.TTN_801, 350 }, // Champion of Storms
    { Card.Cards.TTN_833, 200 }, // Disciple of Golganneth
    { Card.Cards.TTN_730, 300 }, // Lab Constructor
    { Card.Cards.TTN_920, 300 }, // Mimiron, the Mastermind
    { Card.Cards.TTN_856, 200 }, // Disciple of Amitus
    { Card.Cards.TTN_907, 200 }, // Astral Serpent
    { Card.Cards.TTN_071, 200 }, // Sif
    { Card.Cards.TTN_078, 200 }, // Observer of Myths
    { Card.Cards.TTN_843, 200 }, // Eredar Deceptor
    { Card.Cards.TTN_960, 600 }, // Sargeras, the Destroyer TITAN
    { Card.Cards.TTN_721, 600 }, // V-07-TR-0N Prime TITAN
    { Card.Cards.TTN_429, 600 }, // Aman'Thul TITAN
    { Card.Cards.TTN_858, 600 }, // Amitus, the Peacekeeper TITAN
    { Card.Cards.TTN_075, 600 }, // Norgannon TITAN
    { Card.Cards.TTN_092, 600 }, // Aggramar, the Avenger TITAN
    { Card.Cards.TTN_903, 600 }, // Eonar, the Life Binder TITAN
    { Card.Cards.TTN_862, 600 }, // Argus, the Emerald Star TITAN
    { Card.Cards.TTN_737, 600 }, // The Primus TITAN
    { Card.Cards.NX2_006, 200 }, // 旗标骷髅
    { Card.Cards.ETC_105, 200 }, // 立体声图腾
    { Card.Cards.ETC_522, 200 }, // 尖叫女妖
    { Card.Cards.RLK_121, 200 }, // 死亡侍僧
    { Card.Cards.RLK_539, 200 }, // 达尔坎·德拉希尔
    { Card.Cards.RLK_061, 200 }, // 战场通灵师
    { Card.Cards.RLK_824, 200 }, // 肢体商贩
    { Card.Cards.CORE_EX1_012, 200 }, // 血法师萨尔诺斯
    { Card.Cards.TSC_074, 200 }, // 克托里·光刃
    { Card.Cards.RLK_607, 200 }, // 搅局破法者
    { Card.Cards.RLK_924, 200 }, // 血骑士领袖莉亚德琳
    { Card.Cards.CORE_NEW1_020, 200 }, // 狂野炎术师
    { Card.Cards.RLK_083, 200 }, // 死亡寒冰
    { Card.Cards.RLK_572, 550 }, // 药剂大师普崔塞德
    { Card.Cards.RLK_218, 200 }, // 银月城奥术师
    { Card.Cards.REV_935, 200 }, // 派对图腾
    { Card.Cards.RLK_912, 200 }, // 天灾巨魔
    { Card.Cards.DMF_709, 200 }, // 巨型图腾埃索尔
    { Card.Cards.RLK_970, 200 }, // 陆行鸟牧人
    { Card.Cards.MAW_009t, 200 }, // 影犬
    { Card.Cards.TSC_922, 200 }, // 驻锚图腾
    { Card.Cards.AV_137, 200 }, // 深铁穴居人
    { Card.Cards.REV_515, 200 }, // 豪宅管家俄里翁
    { Card.Cards.TSC_959, 200 }, // 扎库尔
    { Card.Cards.TSC_218, 200 }, // 赛丝诺女士
    { Card.Cards.TSC_962, 200 }, // 老巨鳍
    { Card.Cards.REV_016, 200 }, // 邪恶的厨师
    { Card.Cards.REV_828t, 200 }, // 绑架犯的袋子
    { Card.Cards.KAR_006, 200 }, // 神秘女猎手
    { Card.Cards.REV_332, 200 }, // 心能提取者
    { Card.Cards.REV_011, 200 }, // 嫉妒收割者
    { Card.Cards.LOOT_412, 200 }, // 狗头人幻术师
    { Card.Cards.TSC_950, 200 }, // 海卓拉顿
    { Card.Cards.SW_062, 200 }, // 闪金镇豺狼人
    { Card.Cards.REV_513, 200 }, // 健谈的调酒师
    { Card.Cards.ONY_007, 200 }, // 监护者哈尔琳
    { Card.Cards.CS3_032, 200 }, // 龙巢之母奥妮克希亚
    { Card.Cards.SW_431, 200 }, // 花园猎豹
    { Card.Cards.AV_340, 200 }, // 亮铜之翼
    { Card.Cards.SW_458t, 200 }, // 塔维什的山羊
    { Card.Cards.WC_006, 200 }, // 安娜科德拉
    { Card.Cards.ONY_004, 200 }, // 团本首领奥妮克希亚
    { Card.Cards.TSC_032, 200 }, // 剑圣奥卡尼
    { Card.Cards.SW_319, 200 }, // 农夫
    { Card.Cards.TSC_002, 200 }, // 刺豚拳手
    { Card.Cards.CORE_LOE_077, 200 }, // 布莱恩·铜须
    { Card.Cards.TSC_620, 200 }, // 恶鞭海妖
    { Card.Cards.TSC_073, 200 }, // 拉伊·纳兹亚
    { Card.Cards.DED_006, 200 }, // 重拳先生
    { Card.Cards.CORE_AT_029, 200 }, // 锈水海盗
    { Card.Cards.BAR_074, 200 }, // 前沿哨所
    { Card.Cards.AV_118, 200 }, // 历战先锋
    { Card.Cards.GVG_040, 200 }, // 沙鳞灵魂行者
    { Card.Cards.BT_304, 200 }, // 改进型恐惧魔王
    { Card.Cards.SW_068, 200 }, // 莫尔葛熔魔
    { Card.Cards.DED_519, 200 }, // 迪菲亚炮手
    { Card.Cards.CFM_807, 200 }, // 大富翁比尔杜
    { Card.Cards.TSC_054, 200 }, // 机械鲨鱼
    { Card.Cards.GIL_646, 200 }, // 发条机器人
    { Card.Cards.SW_115, 200 }, // 伯尔纳·锤喙
    { Card.Cards.DMF_237, 200 }, // 狂欢报幕员
    { Card.Cards.DMF_217, 200 }, // 越线的游客
    { Card.Cards.DMF_120, 200 }, // 纳兹曼尼织血者
    { Card.Cards.DMF_707, 200 }, // 鱼人魔术师
    { Card.Cards.DMF_082, 200 }, // 暗月雕像
    { Card.Cards.DMF_708, 200 }, // 伊纳拉·碎雷
    { Card.Cards.DMF_102, 200 }, // 游戏管理员
    { Card.Cards.DMF_222, 200 }, // 获救的流民
    { Card.Cards.ULD_003, 200 }, // 了不起的杰弗里斯
    { Card.Cards.GVG_104, 200 }, // 大胖
    { Card.Cards.UNG_900, 250 }, // 灵魂歌者安布拉
    { Card.Cards.ULD_240, 250 }, // 对空奥术法师
    { Card.Cards.FP1_022, 50 }, // 空灵
    { Card.Cards.FP1_004, 50 }, // 疯狂的科学家
    { Card.Cards.BRM_002, 500 }, // 火妖
    { Card.Cards.CFM_020, 0 }, // 缚链者拉兹
    { Card.Cards.EX1_608, 250 }, // 巫师学徒
    { Card.Cards.BOT_447, -10 }, // 晶化师
    { Card.Cards.SCH_600t3, 250 }, // 加攻击的恶魔伙伴
    { Card.Cards.DRG_320, 0 }, // 新伊瑟拉
    { Card.Cards.CS2_237, 300 }, // 饥饿的秃鹫
    { Card.Cards.YOP_031, 250 }, // 螃蟹骑士
    { Card.Cards.BAR_537, 200 }, // 钢鬃卫兵
    { Card.Cards.BAR_035, 200 }, // 科卡尔驯犬者
    { Card.Cards.BAR_871, 250 }, // 士兵车队
    { Card.Cards.BAR_312, 200 }, // 占卜者车队
    { Card.Cards.BAR_043, 250 }, // 鱼人宝宝车队
    { Card.Cards.BAR_720, 230 }, // 古夫·符文图腾
    { Card.Cards.BAR_038, 200 }, // 塔维什·雷矛
    { Card.Cards.BAR_545, 200 }, // 奥术发光体
    { Card.Cards.BAR_888, 200 }, // 霜舌半人马
    { Card.Cards.BAR_317, 200 }, // 原野联络人
    { Card.Cards.BAR_918, 250 }, // 塔姆辛·罗姆
    { Card.Cards.BAR_076, 200 }, // 莫尔杉哨所
    { Card.Cards.BAR_890, 200 }, // 十字路口大嘴巴
    { Card.Cards.BAR_082, 200 }, // 贫瘠之地诱捕者
    { Card.Cards.BAR_540, 200 }, // 腐烂的普雷莫尔
    { Card.Cards.BAR_878, 200 }, // 战地医师老兵
    { Card.Cards.BAR_048, 200 }, // 布鲁坎
    { Card.Cards.BAR_075, 200 }, // 十字路口哨所
    { Card.Cards.BAR_744, 200 }, // 灵魂医者
    { Card.Cards.FP1_028, 200 }, // 送葬者
    { Card.Cards.CS3_019, 200 }, // 考瓦斯·血棘
    { Card.Cards.CORE_FP1_031, 200 }, // 瑞文戴尔男爵
    { Card.Cards.SCH_317, 200 }, // 团伙核心
    { Card.Cards.BAR_847, 200 }, // 洛卡拉
    { Card.Cards.CS3_025, 200 }, // 伦萨克大王
    { Card.Cards.YOP_021, 200 }, // 被禁锢的凤凰
    { Card.Cards.CS3_033, 200 }, // 沉睡者伊瑟拉
    { Card.Cards.CS3_034, 200 }, // 织法者玛里苟斯
    { Card.Cards.CORE_EX1_110, 0 }, // 凯恩·血蹄
    { Card.Cards.BAR_072, 0 }, // 火刃侍僧
    { Card.Cards.SCH_351, 200 } // 詹迪斯·巴罗夫
};

foreach (var cardModifier in cardModifiers)
{
    if (board.MinionEnemy.Any(minion => minion.Template.Id == cardModifier.Key))
    {
        p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(cardModifier.Key, new Modifier(cardModifier.Value));
    }
}
#endregion
						 
#region Bot.Log
Bot.Log(_log);         
#endregion                       


//德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER
            return p;
        }}
				 // 向 _log 字符串添加日志的私有方法，包括回车和新行
        private void AddLog(string log)
        {
            _log += "\r\n" + log;
        }
        //芬利·莫格顿爵士技能选择
        public Card.Cards SirFinleyChoice(List<Card.Cards> choices)
        {
            var filteredTable = _heroPowersPriorityTable.Where(x => choices.Contains(x.Key)).ToList();
            return filteredTable.First(x => x.Value == filteredTable.Max(y => y.Value)).Key;
        }
    
        //卡扎库斯选择
        public Card.Cards KazakusChoice(List<Card.Cards> choices)
        {
            return choices[0];
        }

        //计算类
        public static class BoardHelper
        {
            //得到敌方的血量和护甲之和
            public static int GetEnemyHealthAndArmor(Board board)
            {
                return board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor;
            }

            //得到自己的法强
            public static int GetSpellPower(Board board)
            {
                //计算没有被沉默的随从的法术强度之和
                return board.MinionFriend.FindAll(x => x.IsSilenced == false).Sum(x => x.SpellPower);
            }

            //获得第二轮斩杀血线
            public static int GetSecondTurnLethalRange(Board board)
            {
                //敌方英雄的生命值和护甲之和减去可释放法术的伤害总和
                return GetEnemyHealthAndArmor(board) - GetPlayableSpellSequenceDamages(board);
            }

            //下一轮是否可以斩杀敌方英雄
            public static bool HasPotentialLethalNextTurn(Board board)
            {
                //如果敌方随从没有嘲讽并且造成伤害
                //(敌方生命值和护甲的总和 减去 下回合能生存下来的当前场上随从的总伤害 减去 下回合能攻击的可使用随从伤害总和)
                //后的血量小于总法术伤害
                if (!board.MinionEnemy.Any(x => x.IsTaunt) &&
                    (GetEnemyHealthAndArmor(board) - GetPotentialMinionDamages(board) - GetPlayableMinionSequenceDamages(GetPlayableMinionSequence(board), board))
                        <= GetTotalBlastDamagesInHand(board))
                {
                    return true;
                }
                //法术释放过敌方英雄的血量是否大于等于第二轮斩杀血线
                return GetRemainingBlastDamagesAfterSequence(board) >= GetSecondTurnLethalRange(board);
            }

            //获得下回合能生存下来的当前场上随从的总伤害
            public static int GetPotentialMinionDamages(Board board)
            {
                return GetPotentialMinionAttacker(board).Sum(x => x.CurrentAtk);
            }

            //获得下回合能生存下来的当前场上随从集合
            public static List<Card> GetPotentialMinionAttacker(Board board)
            {
                //下回合能生存下来的当前场上随从集合
                var minionscopy = board.MinionFriend.ToArray().ToList();

                //遍历 以敌方随从攻击力 降序排序 的 场上敌方随从集合
                foreach (var mi in board.MinionEnemy.OrderByDescending(x => x.CurrentAtk))
                {
                    //以友方随从攻击力 降序排序 的 场上的所有友方随从集合，如果该集合存在生命值大于与敌方随从攻击力
                    if (board.MinionFriend.OrderByDescending(x => x.CurrentAtk).Any(x => x.CurrentHealth <= mi.CurrentAtk))
                    {
                        //以友方随从攻击力 降序排序 的 场上的所有友方随从集合,找出该集合中友方随从的生命值小于等于敌方随从的攻击力的随从
                        var tar = board.MinionFriend.OrderByDescending(x => x.CurrentAtk).FirstOrDefault(x => x.CurrentHealth <= mi.CurrentAtk);
                        //将该随从移除掉
                        minionscopy.Remove(tar);
                    }
                }

                return minionscopy;
            }

            //获得下回合能生存下来的对面随从集合
            public static List<Card> GetSurvivalMinionEnemy(Board board)
            {
                //下回合能生存下来的当前对面场上随从集合
                var minionscopy = board.MinionEnemy.ToArray().ToList();

                //遍历 以友方随从攻击力 降序排序 的 场上友方可攻击随从集合
                foreach (var mi in board.MinionFriend.FindAll(x => x.CanAttack).OrderByDescending(x => x.CurrentAtk))
                {
                    //如果存在友方随从攻击力大于等于敌方随从血量
                    if (board.MinionEnemy.OrderByDescending(x => x.CurrentHealth).Any(x => x.CurrentHealth <= mi.CurrentAtk))
                    {
                        //以敌方随从血量降序排序的所有敌方随从集合，找出敌方生命值小于等于友方随从攻击力的随从
                        var tar = board.MinionEnemy.OrderByDescending(x => x.CurrentHealth).FirstOrDefault(x => x.CurrentHealth <= mi.CurrentAtk);
                        //将该随从移除掉
                        minionscopy.Remove(tar);
                    }
                }
                return minionscopy;
            }

            //获取可以使用的随从集合
            public static List<Card.Cards> GetPlayableMinionSequence(Board board)
            {
                //卡片集合
                var ret = new List<Card.Cards>();

                //当前剩余的法力水晶
                var manaAvailable = board.ManaAvailable;

                //遍历以手牌中费用降序排序的集合
                foreach (var card in board.Hand.OrderByDescending(x => x.CurrentCost))
                {
                    //如果当前卡牌不为随从，继续执行
                    if (card.Type != Card.CType.MINION) continue;

                    //当前法力值小于卡牌的费用，继续执行
                    if (manaAvailable < card.CurrentCost) continue;

                    //添加到容器里
                    ret.Add(card.Template.Id);

                    //修改当前使用随从后的法力水晶
                    manaAvailable -= card.CurrentCost;
                }

                return ret;
            }

            //获取可以使用的奥秘集合
            public static List<Card.Cards> GetPlayableSecret(Board board)
            {
                //卡片集合
                var ret = new List<Card.Cards>();

                //遍历手牌中所有奥秘集合
                foreach (var card1 in board.Hand.FindAll(card => card.Template.IsSecret))
                {
                    if (board.Secret.Count > 0)
                    {
                        //遍历头上奥秘集合
                        foreach (var card2 in board.Secret.FindAll(card => CardTemplate.LoadFromId(card).IsSecret))
                        {

                            //如果手里奥秘和头上奥秘不相等
                            if (card1.Template.Id != card2)
                            {
                                //添加到容器里
                                ret.Add(card1.Template.Id);
                            }
                        }
                    }
                    else
                    { ret.Add(card1.Template.Id); }
                }
                return ret;
            }


            //获取下回合能攻击的可使用随从伤害总和
            public static int GetPlayableMinionSequenceDamages(List<Card.Cards> minions, Board board)
            {
                //下回合能攻击的可使用随从集合攻击力相加
                return GetPlayableMinionSequenceAttacker(minions, board).Sum(x => CardTemplate.LoadFromId(x).Atk);
            }

            //获取下回合能攻击的可使用随从集合
            public static List<Card.Cards> GetPlayableMinionSequenceAttacker(List<Card.Cards> minions, Board board)
            {
                //未处理的下回合能攻击的可使用随从集合
                var minionscopy = minions.ToArray().ToList();

                //遍历 以敌方随从攻击力 降序排序 的 场上敌方随从集合
                foreach (var mi in board.MinionEnemy.OrderByDescending(x => x.CurrentAtk))
                {
                    //以友方随从攻击力 降序排序 的 场上的所有友方随���集合，如果该集合存在生命值大于与敌方随从攻击力
                    if (minions.OrderByDescending(x => CardTemplate.LoadFromId(x).Atk).Any(x => CardTemplate.LoadFromId(x).Health <= mi.CurrentAtk))
                    {
                        //以友方随从攻击力 降序排序 的 场上的所有友方随从集合,找出该集合中友方随从的生命值小于等于敌方随从的攻击力的随从
                        var tar = minions.OrderByDescending(x => CardTemplate.LoadFromId(x).Atk).FirstOrDefault(x => CardTemplate.LoadFromId(x).Health <= mi.CurrentAtk);
                        //将该随从移除掉
                        minionscopy.Remove(tar);
                    }
                }

                return minionscopy;
            }

            //获取当前回合手牌中的总法术伤害
            public static int GetTotalBlastDamagesInHand(Board board)
            {
                //从手牌中找出法术伤害表存在的法术的伤害总和(包括法强)
                return
                    board.Hand.FindAll(x => _spellDamagesTable.ContainsKey(x.Template.Id))
                        .Sum(x => _spellDamagesTable[x.Template.Id] + GetSpellPower(board));
            }

            //获取可以使用的法术集合
            public static List<Card.Cards> GetPlayableSpellSequence(Board board)
            {
                //卡片集合
                var ret = new List<Card.Cards>();

                //当前剩余的法力水晶
                var manaAvailable = board.ManaAvailable;

                if (board.Secret.Count > 0)
                {
                    //遍历以手牌中费用降序排序的集合
                    foreach (var card in board.Hand.OrderBy(x => x.CurrentCost))
                    {
                        //如果手牌中又不在法术序列的法术牌，继续执行
                        if (_spellDamagesTable.ContainsKey(card.Template.Id) == false) continue;

                        //当前法力值小于卡牌的费用，继续执行
                        if (manaAvailable < card.CurrentCost) continue;

                        //添加到容器里
                        ret.Add(card.Template.Id);

                        //修改当前使用随从后的法力水晶
                        manaAvailable -= card.CurrentCost;
                    }
                }
                else if (board.Secret.Count == 0)
                {
                    //遍历以手牌中费用降序排序的集合
                    foreach (var card in board.Hand.FindAll(x => x.Type == Card.CType.SPELL).OrderBy(x => x.CurrentCost))
                    {
                        //如果手牌中又不在法术序列的法术牌，继续执行
                        if (_spellDamagesTable.ContainsKey(card.Template.Id) == false) continue;

                        //当前法力值小于卡牌的费用，继续执行
                        if (manaAvailable < card.CurrentCost) continue;

                        //添加到容器里
                        ret.Add(card.Template.Id);

                        //修改当前使用随从后的法力水晶
                        manaAvailable -= card.CurrentCost;
                    }
                }

                return ret;
            }
            
            //获取存在于法术列表中的法术集合的伤害总和(包括法强)
            public static int GetSpellSequenceDamages(List<Card.Cards> sequence, Board board)
            {
                return
                    sequence.FindAll(x => _spellDamagesTable.ContainsKey(x))
                        .Sum(x => _spellDamagesTable[x] + GetSpellPower(board));
            }

            //得到可释放法术的伤害总和
            public static int GetPlayableSpellSequenceDamages(Board board)
            {
                return GetSpellSequenceDamages(GetPlayableSpellSequence(board), board);
            }
            
            //计算在法术释放过敌方英雄的血量
            public static int GetRemainingBlastDamagesAfterSequence(Board board)
            {
                //当前回合总法术伤害减去可释放法术的伤害总和
                return GetTotalBlastDamagesInHand(board) - GetPlayableSpellSequenceDamages(board);
            }

            public static bool IsOutCastCard(Card card, Board board)
            {
                var OutcastLeft = board.Hand.Find(x => x.CurrentCost >= 0);
                var OutcastRight = board.Hand.FindLast(x => x.CurrentCost >= 0);
                if (card.Template.Id == OutcastLeft.Template.Id
                    || card.Template.Id == OutcastRight.Template.Id)
                {
                    return true;
                    
                }
                return false;
            }
            public static bool IsGuldanOutCastCard(Card card, Board board)
            {
                if ((board.FriendGraveyard.Exists(x => CardTemplate.LoadFromId(x).Id == Card.Cards.BT_601)
                    && card.Template.Cost - card.CurrentCost == 3))
                {
                    return true;
                }
                
                return false;
            }
            public static bool  IsOutcast(Card card,Board board)
            {
                if(IsOutCastCard(card,board) || IsGuldanOutCastCard(card,board))
                {
                    return true;
                }
                return false;
            }


            //在没有法术的情况下有潜在致命的下一轮
            public static bool HasPotentialLethalNextTurnWithoutSpells(Board board)
            {
                if (!board.MinionEnemy.Any(x => x.IsTaunt) &&
                    (GetEnemyHealthAndArmor(board) -
                     GetPotentialMinionDamages(board) -
                     GetPlayableMinionSequenceDamages(GetPlayableMinionSequence(board), board) <=
                     0))
                {
                    return true;
                }
                return false;
            }
        }
    }
}