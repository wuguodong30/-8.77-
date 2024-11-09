namespace HREngine.Bots
{

    public enum searchmode
    {
        searchLowestHP,
        searchHighestHP,
        searchLowestAttack,
        searchHighestAttack,
        searchHighAttackLowHP, //get max attack/hp ratio
        searchHighHPLowAttack, //get max hp/attack ratio
        searchLowestCost,
        searchHighesCost,
    }
    
    public enum GAME_TAGs
    {
        TAG_SCRIPT_DATA_NUM_1 = 2,  // �ű����ݱ��1
        TAG_SCRIPT_DATA_NUM_2 = 3,  // �ű����ݱ��2
        TAG_SCRIPT_DATA_ENT_1 = 4,  // �ű�����ʵ��1
        TAG_SCRIPT_DATA_ENT_2 = 5,  // �ű�����ʵ��2
        MISSION_EVENT = 6,          // �����¼�
        TIMEOUT = 7,                // ��ʱ
        TURN_START = 8,             // �غϿ�ʼ
        TURN_TIMER_SLUSH = 9,       // �غϼ�ʱ������
        PREMIUM = 12,               // �߼�������𿨣�
        GOLD_REWARD_STATE = 13,     // ��ҽ���״̬
        PLAYSTATE = 17,             // ��Ϸ״̬
        LAST_AFFECTED_BY = 18,      // ���Ӱ��ÿ��Ƶ�ʵ��
        STEP = 19,                  // ��Ϸ����
        TURN = 20,                  // ��ǰ�غ���
        FATIGUE = 22,               // ƣ��
        CURRENT_PLAYER = 23,        // ��ǰ���
        FIRST_PLAYER = 24,          // �������
        RESOURCES_USED = 25,        // ʹ�õ���Դ��
        RESOURCES = 26,             // ��ǰ������Դ��
        HERO_ENTITY = 27,           // Ӣ��ʵ��ID
        MAXHANDSIZE = 28,           // �����������
        STARTHANDSIZE = 29,         // ��ʼ��������
        PLAYER_ID = 30,             // ���ID
        TEAM_ID = 31,               // ����ID
        TRIGGER_VISUAL = 32,        // �����Ӿ�Ч��
        RECENTLY_ARRIVED = 33,      // �������
        PROTECTING = 34,            // ���ڱ���
        PROTECTED = 35,             // ������
        DEFENDING = 36,             // ������
        PROPOSED_DEFENDER = 37,     // ����ķ�����
        ATTACKING = 38,             // ������
        PROPOSED_ATTACKER = 39,     // ����Ľ�����
        ATTACHED = 40,              // �Ѹ���
        EXHAUSTED = 43,             // ��ƣ���������ܹ�����
        DAMAGE = 44,                // �˺�
        HEALTH = 45,                // ����ֵ
        ATK = 47,                   // ������
        COST = 48,                  // ����
        ZONE = 49,                  // �����������ơ��ƿ⡢ս���ȣ�
        CONTROLLER = 50,            // ������
        OWNER = 51,                 // ӵ����
        DEFINITION = 52,            // ����
        ENTITY_ID = 53,             // ʵ��ID
        HISTORY_PROXY = 54,         // ��ʷ����
        COPY_DEATHRATTLE = 55,      // ��������
        ELITE = 114,                // ��Ӣ��
        MAXRESOURCES = 176,         // �����Դ��
        CARD_SET = 183,             // ������������չ��
        CARDTEXT_INHAND = 184,      // �����еĿ�������
        CARDNAME = 185,             // ��������
        CARD_ID = 186,              // ����ID
        DURABILITY = 187,           // �����;ö�
        SILENCED = 188,             // ����Ĭ
        WINDFURY = 189,             // ��ŭ
        TAUNT = 190,                // ����
        STEALTH = 191,              // Ǳ��
        SPELLPOWER = 192,           // �����˺�
        DIVINE_SHIELD = 194,        // ʥ��
        CHARGE = 197,               // ���
        NEXT_STEP = 198,            // ��һ��
        CLASS = 199,                // ְҵ
        CARDRACE = 200,             // ��������
        FACTION = 201,              // ��Ӫ
        CARDTYPE = 202,             // �������ͣ���ӡ������������ȣ�
        RARITY = 203,               // ϡ�ж�
        STATE = 204,                // ״̬
        SUMMONED = 205,             // ���ٻ�
        FREEZE = 208,               // ����
        ENRAGED = 212,              // ��ŭ
        OVERLOAD = 215,             // ����
        LOYALTY = 216,              // �ҳ�
        DEATHRATTLE = 217,          // ����
        BATTLECRY = 218,            // ս��
        SECRET = 219,               // ����
        NATURE = 643,               // ��Ȼ����
        COMBO = 220,                // ����
        CANT_HEAL = 221,            // ���ܱ�����
        CANT_DAMAGE = 222,          // ��������˺�
        CANT_SET_ASIDE = 223,       // ���ܱ��ƿ�
        CANT_REMOVE_FROM_GAME = 224,// �����Ƴ���Ϸ
        CANT_READY = 225,           // ����׼������
        CANT_ATTACK = 227,          // ���ܹ���
        CANT_DISCARD = 230,         // ��������
        CANT_PLAY = 231,            // ����ʹ��
        CANT_DRAW = 232,            // ���ܳ���
        CANT_BE_HEALED = 239,       // ���ܱ�����
        IMMUNE = 240,               // ����
        CANT_BE_SET_ASIDE = 241,    // ���ܱ��ƿ�
        CANT_BE_REMOVED_FROM_GAME = 242,// �����Ƴ���Ϸ
        CANT_BE_READIED = 243,      // ����׼��
        CANT_BE_ATTACKED = 245,     // ���ܱ�����
        CANT_BE_TARGETED = 246,     // ���ܳ�ΪĿ��
        CANT_BE_DESTROYED = 247,    // ���ܱ��ݻ�
        CANT_BE_SUMMONING_SICK = 253,// ���ܽ����ٻ�ƣ��״̬
        FROZEN = 260,               // ����״̬
        JUST_PLAYED = 261,          // �ոձ�ʹ��
        LINKED_ENTITY = 262,        // ���ӵ�ʵ��
        ZONE_POSITION = 263,        // ����λ��
        CANT_BE_FROZEN = 264,       // ���ܱ�����
        COMBO_ACTIVE = 266,         // ��������
        CARD_TARGET = 267,          // ����Ŀ��
        NUM_CARDS_PLAYED_THIS_TURN = 269,// ���غ���ʹ�õĿ�����
        CANT_BE_TARGETED_BY_OPPONENTS = 270,// ���ܳ�Ϊ���ֵ�Ŀ��
        NUM_TURNS_IN_PLAY = 271,    // �Ѿ��ڳ��ϵĻغ���
        NUM_TURNS_LEFT = 272,       // ʣ��غ���
        CURRENT_SPELLPOWER = 291,   // ��ǰ�����˺�ֵ
        ARMOR = 292,                // ����ֵ
        MORPH = 293,                // ����
        IS_MORPHED = 294,           // �Ƿ��ѱ���
        TEMP_RESOURCES = 295,       // ��ʱ��Դ
        OVERLOAD_OWED = 296,        // ����Ƿծ
        NUM_ATTACKS_THIS_TURN = 297,// ���غϹ�������
        NEXT_ALLY_BUFF = 302,       // ��һ���ѷ������ǿ
        MAGNET = 303,               // ����
        FIRST_CARD_PLAYED_THIS_TURN = 304,// ���غ��״�ʹ�õĿ���
        MULLIGAN_STATE = 305,       // ���ƽ׶�״̬
        TAUNT_READY = 306,          // �������
        STEALTH_READY = 307,        // Ǳ�о���
        CHARGE_READY = 308,         // ������
        CANT_BE_TARGETED_BY_SPELLS = 311,// ���ܳ�Ϊ����Ŀ��
        SHOULDEXITCOMBAT = 312,     // Ӧ�˳�ս��
        CREATOR = 313,              // ������
        CANT_BE_SILENCED = 314,     // ���ܱ���Ĭ
        PARENT_CARD = 316,          // ������
        NUM_MINIONS_PLAYED_THIS_TURN = 317,// ���غ���ʹ�õ������
        PREDAMAGE = 318,// Ԥ�˺����ڼ���ʵ���˺�ǰ��Ԥ���˺�ֵ��ʶ��
        COLLECTIBLE = 321,// ���ռ�����ʾ�ÿ����Ƿ���Ա�����ռ���
        TARGETING_ARROW_TEXT = 325,// ��׼��ͷ�ı�������������׼��ͷ���ı����ݡ�
        ENCHANTMENT_BIRTH_VISUAL = 330,// ��ħ�����Ӿ�Ч�����ڸ�ħ��Чʱ��ʾ���Ӿ�Ч����
        ENCHANTMENT_IDLE_VISUAL = 331,// ��ħ�����Ӿ�Ч�����ڸ�ħ��������״̬ʱ��ʾ���Ӿ�Ч����
        CANT_BE_TARGETED_BY_HERO_POWERS = 332,// ���ܱ�Ӣ�ۼ���ѡ�У��ÿ��Ʋ�����ΪӢ�ۼ��ܵ�Ŀ�ꡣ
        HEALTH_MINIMUM = 337,// �������ֵ����������ӵ�е��������ֵ��
        TAG_ONE_TURN_EFFECT = 338,// ���غ�Ч����ʶ�����ڱ��ֻ���ڵ��غ�����Ч��Ч����
        SILENCE = 339,// ��Ĭ�����ڱ�ʾ�����Ƿ��ڳ�Ĭ״̬��Ч������ȡ����
        COUNTER = 340,// ����������ʶ�������Ƿ��м�����������׷��Ч�������ȣ���
        ARTISTNAME = 342,// ���������ƣ����Ƶ������廭���ߵ����֡�
        ZONES_REVEALED = 348,// �����ѽ�ʾ����ʾ���ƵĿɼ��ԣ��Ƿ��ѱ��Է���ʾ��
        ADJACENT_BUFF = 350,// �������棺�ñ�ʶ�����ڱ�ʾ������ӵ�����Ч����
        FLAVORTEXT = 351,// Ȥζ�ı���������ʾ���Ƶı������»�Ȥζ������
        FORCED_PLAY = 352,// ǿ�Ƴ��ƣ���ʶ�ÿ�����ĳЩ����»ᱻǿ��ʹ�á�
        LOW_HEALTH_THRESHOLD = 353,// ������ֵ��ֵ�����ڴ����ڵ�����ֵ״̬�µ�Ч����
        SPELLPOWER_DOUBLE = 356,// ����ǿ�ȼӱ����ÿ��Ƶķ���ǿ��Ч���ӱ���
        HEALING_DOUBLE = 357,// ����Ч���ӱ����ÿ��Ƶ�����Ч���ӱ���
        NUM_OPTIONS_PLAYED_THIS_TURN = 358,// ���غ���ʹ��ѡ���������ڼ�¼��ǰ�غ�����ʹ�õĲ�ͬѡ���������
        TO_BE_DESTROYED = 360,// �������ݻ٣���Ǹÿ��ƽ���ĳЩЧ���±��ݻ١�
        AURA = 362,// �⻷���ñ�ʶ�����ڱ�ʾ���ƵĹ⻷Ч����Ӱ��������λ��
        POISONOUS = 363,// �綾����ʾ������ܹ������κ��ܵ����˺�����ӡ�
        HOW_TO_EARN = 364,// ��ȡ��ʽ��������λ�øÿ��ơ�
        HOW_TO_EARN_GOLDEN = 365,// ��ȡ��ɫ�汾��ʽ��������λ�øÿ��ƵĽ�ɫ�汾��
        HERO_POWER_DOUBLE = 366,// Ӣ�ۼ��ܼӱ����ÿ��Ƶ�Ӣ�ۼ���Ч���ӱ���
        AI_MUST_PLAY = 367,// AI������ƣ����AI��ĳЩ����±���ʹ�ô˿��ơ�
        NUM_MINIONS_PLAYER_KILLED_THIS_TURN = 368,// ���غ���������������������ڼ�¼����ڵ�ǰ�غ���������������
        NUM_MINIONS_KILLED_THIS_TURN = 369,// ���غ������������������ڼ�¼��ǰ�غ����ܹ���������������
        AFFECTED_BY_SPELL_POWER = 370,// �ܷ���ǿ��Ӱ�죺��ʶ�ÿ����Ƿ��ܷ���ǿ�ȼӳɵ�Ӱ�졣
        EXTRA_DEATHRATTLES = 371,// ��������ñ�ʶ����ʾ�ÿ��ƿ��Դ������������Ч����
        START_WITH_1_HEALTH = 372,// ��1������ֵ��ʼ����ʾ�ÿ�����1������ֵ��ʼ��Ϸ��
        IMMUNE_WHILE_ATTACKING = 373,// ����ʱ���ߣ��ÿ����ڹ���ʱ���������˺���
        MULTIPLY_HERO_DAMAGE = 374,// Ӣ���˺��������ÿ��ƻᱶ��Ӣ����ɵ��˺���
        MULTIPLY_BUFF_VALUE = 375,// ����Ч���������ñ�ʶ����ʾ�ÿ��ƻᱶ����õ�����Ч����
        CUSTOM_KEYWORD_EFFECT = 376,// �Զ���ؼ���Ч������ʾ�ÿ��ƾ����Զ���Ĺؼ���Ч����
        TOPDECK = 377,// ���ƣ��ñ�ʶ�����ڱ�ǳ�ȡ���鶥���Ŀ��ơ�
        CANT_BE_TARGETED_BY_BATTLECRIES = 379,// ���ܳ�Ϊս��Ŀ�꣺�ÿ��Ʋ��ܱ�ս��Ч��ѡ�С�
        HERO_POWER = 380,// Ӣ�ۼ��ܣ���ʶ��Ӣ�ۼ�����ص�Ч����
        DEATHRATTLE_RETURN_ZONE = 382,// ���ﷵ����������Ч�������󷵻ص������ʶ��
        STEADY_SHOT_CAN_TARGET = 383,// �ȹ������ѡĿ�꣺�ñ�ʶ����ʾ�ȹ�������ܵ�Ŀ���ѡ�ԡ�
        DISPLAYED_CREATOR = 385,// ��ʾ�����ߣ���ʾ�ÿ��ƵĴ�������Ϣ��
        POWERED_UP = 386,// ǿ������ʶ�ÿ��ƴ���ǿ��״̬��
        SPARE_PART = 388,// �����������ʶ�ÿ���Ϊ����������͡�
        FORGETFUL = 389,// �������ñ�ʶ����ʾ���ƻ��������Ч����
        CAN_SUMMON_MAXPLUSONE_MINION = 390,// ���ٻ����ֵ+1����ӣ��ñ�ʶ����ʾ���ٻ������������һ����ӡ�
        OBFUSCATED = 391,// ģ�����ñ�ʶ����ʾ����Ч����ģ���Ի򲻿ɼ��ԡ�
        BURNING = 392,// ȼ�գ���ʶ�ÿ��ƴ���ȼ��״̬�����ܵ������˺���
        OVERLOAD_LOCKED = 393,// �����������ñ�ʶ����ʾ�������ڹ���Ч����������
        NUM_TIMES_HERO_POWER_USED_THIS_GAME = 394,// ������Ϸ��ʹ��Ӣ�ۼ��ܵĴ�������¼��Ϸ������ʹ��Ӣ�ۼ��ܵ��ܴ�����
        CURRENT_HEROPOWER_DAMAGE_BONUS = 395,// ��ǰӢ�ۼ����˺��ӳɣ���ʾ��ǰӢ�ۼ��ܵ��˺��ӳ�ֵ��
        HEROPOWER_DAMAGE = 396,// Ӣ�ۼ����˺�����ʾӢ�ۼ��ܵĻ����˺�ֵ��
        LAST_CARD_PLAYED = 397,// ��һ��ʹ�õĿ��ƣ��������ϴ�ʹ�õĿ��ơ�
        NUM_FRIENDLY_MINIONS_THAT_DIED_THIS_TURN = 398,// ���غ��������ѷ������������¼��ǰ�غ����������ѷ����������
        NUM_CARDS_DRAWN_THIS_TURN = 399,// ���غϳ�ȡ�Ŀ�����������¼��ǰ�غ��ڳ�ȡ�Ŀ���������
        AI_ONE_SHOT_KILL = 400,// AIһ����ɱ����ʶAI�ܹ�ʹ�øÿ��ƽ���һ����ɱ��
        EVIL_GLOW = 401,// а��⻷���ñ�ʶ����ʾ���ƾ���а��⻷Ч����
        HIDE_STATS = 402,// ����״̬���ÿ��Ƶľ���״̬���繥����������ֵ���ᱻ���ء�
        INSPIRE = 403,// ��������ʶ�ÿ��ƾ��м���Ч����
        RECEIVES_DOUBLE_SPELLDAMAGE_BONUS = 404,// ����˫�������˺��ӳɣ��ÿ��ƻ����˫���ķ����˺��ӳɡ�
        HEROPOWER_ADDITIONAL_ACTIVATIONS = 405,// Ӣ�ۼ��ܶ��⼤��ÿ����ܹ���һ�غ��ڶ�μ���Ӣ�ۼ��ܡ�
        HEROPOWER_ACTIVATIONS_THIS_TURN = 406,// ���غϼ���Ӣ�ۼ��ܵĴ�������¼��ǰ�غ��ڼ���Ӣ�ۼ��ܵĴ�����
        REVEALED = 410,// �ѽ�ʾ����ʾ�����Ƿ��ѱ���ʾ�����֡�
        NUM_FRIENDLY_MINIONS_THAT_DIED_THIS_GAME = 412,// ������Ϸ�������ѷ������������¼������Ϸ���������ѷ����������
        CANNOT_ATTACK_HEROES = 413,// ���ܹ���Ӣ�ۣ��ÿ��Ʋ���ֱ�ӹ����Է�Ӣ�ۡ�
        LOCK_AND_LOAD = 414,// ��ս�������ñ�ʶ����ʾ���ƾ��б�ս������Ч����
        DISCOVER = 415,// ���֣���ʶ�ÿ��ƾ��С����֡�Ч����
        SHADOWFORM = 416,// ��Ӱ��̬����ʶ�ÿ��ƾ��а�Ӱ��̬Ч����
        NUM_FRIENDLY_MINIONS_THAT_ATTACKED_THIS_TURN = 417,// ���غϹ������ѷ������������¼��ǰ�غ���
        NUM_RESOURCES_SPENT_THIS_GAME = 418,
        CHOOSE_BOTH = 419,
        ELECTRIC_CHARGE_LEVEL = 420,
        HEAVILY_ARMORED = 421,
        DONT_SHOW_IMMUNE = 422,
        RITUAL = 424,
        PREHEALING = 425,
        APPEAR_FUNCTIONALLY_DEAD = 426,
        OVERLOAD_THIS_GAME = 427,
        SPELLS_COST_HEALTH = 431,
        HISTORY_PROXY_NO_BIG_CARD = 432,
        PROXY_CTHUN = 434,
        TRANSFORMED_FROM_CARD = 435,
        CTHUN = 436,
        CAST_RANDOM_SPELLS = 437,
        SHIFTING = 438,
        JADE_GOLEM = 441,
        EMBRACE_THE_SHADOW = 442,
        CHOOSE_ONE = 443,
        EXTRA_ATTACKS_THIS_TURN = 444,
        SEEN_CTHUN = 445,
        MINION_TYPE_REFERENCE = 447,
        UNTOUCHABLE = 448,
        RED_MANA_CRYSTALS = 449,
        SCORE_LABELID_1 = 450,
        SCORE_VALUE_1 = 451,
        SCORE_LABELID_2 = 452,
        SCORE_VALUE_2 = 453,
        SCORE_LABELID_3 = 454,
        SCORE_VALUE_3 = 455,
        CANT_BE_FATIGUED = 456,
        AUTOATTACK = 457,
        ARMS_DEALING = 458,
        PENDING_EVOLUTIONS = 461,
        QUEST = 462,
        TAG_LAST_KNOWN_COST_IN_HAND = 466,
        DEFINING_ENCHANTMENT = 469,
        FINISH_ATTACK_SPELL_ON_DAMAGE = 470,
        MODULAR_ENTITY_PART_1 = 471,
        MODULAR_ENTITY_PART_2 = 472,
        MODIFY_DEFINITION_ATTACK = 473,
        MODIFY_DEFINITION_HEALTH = 474,
        MODIFY_DEFINITION_COST = 475,
        MULTIPLE_CLASSES = 476,
        ALL_TARGETS_RANDOM = 477,
        MULTI_CLASS_GROUP = 480,
        CARD_COSTS_HEALTH = 481,
        GRIMY_GOONS = 482,
        JADE_LOTUS = 483,
        KABAL = 484,
        ADDITIONAL_PLAY_REQS_1 = 515,
        ADDITIONAL_PLAY_REQS_2 = 516,
        ELEMENTAL_POWERED_UP = 532,
        QUEST_PROGRESS = 534,
        QUEST_PROGRESS_TOTAL = 535,
        QUEST_CONTRIBUTOR = 541,
        ADAPT = 546,
        IS_CURRENT_TURN_AN_EXTRA_TURN = 547,
        EXTRA_TURNS_TAKEN_THIS_GAME = 548,
        SHIFTING_MINION = 549,
        SHIFTING_WEAPON = 550,
        DEATH_KNIGHT = 554,
        BOSS = 556,
        STAMPEDE = 564,
        IS_VAMPIRE = 680,
        CORRUPTED = 681,
        LIFESTEAL = 685,
        OVERRIDE_EMOTE_0 = 740,
        OVERRIDE_EMOTE_1 = 741,
        OVERRIDE_EMOTE_2 = 742,
        OVERRIDE_EMOTE_3 = 743,
        OVERRIDE_EMOTE_4 = 744,
        OVERRIDE_EMOTE_5 = 745,
        SCORE_FOOTERID = 751,
        HERO_POWER_DISABLED = 777,
        VALEERASHADOW = 779,
        OVERRIDECARDNAME = 781,
        OVERRIDECARDTEXTBUILDER = 782,
        HIDDEN_CHOICE = 813,
        ZOMBEAST = 823,
        HERO_EMOTE_SILENCED = 832,
        MODULAR = 849,
        GLORIOUSGLOOP = 1044,
        REBORN = 1085,
        HAS_BEEN_REBORN = 1336,
        POISONOUS_INSTANT = 1528,
        REPLACEMENT_ENTITY = 1632,
        SPELLS_CAST_TWICE = 1681,
        DONT_PICK_FROM_SUBSETS = 676,
        LUNAHIGHLIGHTHINT = 1054,
        EMPOWER = 1263,
        EMPOWER_PRIEST,
        EMPOWER_ROGUE,
        EMPOWER_SHAMAN,
        EMPOWER_WARLOCK,
        EMPOWER_WARRIOR,
        GOLDSPARKLES_HINT = 1984,
        CASTS_WHEN_DRAWN = 1077,
        DORMANT_VISUAL = 1090,
        DORMANT = 1518,
        DORMANT_AWAKEN_CONDITION_ENCHANT,
        SHRINE = 1057,
        FATIGUE_REFERENCE = 1290,
        WAND = 1015,
        TWINSPELL = 1193,
        TWINSPELL_COPY = 1186,
        TWINSPELLPENDING = 1269,
        CREATED_BY_TWINSPELL = 3432,
        CREATED_BY_MINIATURIZE,
        CREATED_BY_GIGANTIFY,
        EVILZUG = 994,
        RUSH = 791,
        ATTACKABLE_BY_RUSH = 930,
        ECHO = 846,
        NON_KEYWORD_ECHO = 1114,
        OVERKILL = 923,
        PROPHECY,
        ETHEREAL = 880,
        REVEAL_CHOICES = 792,
        REAL_TIME_TRANSFORM = 859,
        HEALTH_DISPLAY = 917,
        ENABLE_HEALTH_DISPLAY = 920,
        HEALTH_DISPLAY_COLOR = 1046,
        HEALTH_DISPLAY_NEGATIVE,
        VOODOO_LINK = 921,
        FAN_LINK = 3052,
        COLLECTIONMANAGER_FILTER_MANA_EVEN = 956,
        COLLECTIONMANAGER_FILTER_MANA_ODD,
        SUPPRESS_DEATH_SOUND = 959,
        ECHOING_OOZE_SPELL = 963,
        ENCHANTMENT_INVISIBLE = 976,
        WILD = 991,
        HALL_OF_FAME,
        FAST_BATTLECRY = 998,
        CARD_DOES_NOTHING = 1075,
        FORCE_NO_CUSTOM_SPELLS = 1529,
        FORCE_NO_CUSTOM_SUMMON_SPELLS = 1614,
        FORCE_NO_CUSTOM_LIFETIME_SPELLS = 1613,
        FORCE_NO_CUSTOM_KEYWORD_SPELLS = 1615,
        FORCE_GREEN_GLOW_ACTIVE = 1693,
        START_OF_COMBAT = 1531,
        PUZZLE = 979,
        PUZZLE_PROGRESS,
        PUZZLE_PROGRESS_TOTAL,
        PUZZLE_TYPE,
        PUZZLE_COMPLETED = 984,
        PUZZLE_NAME = 1026,
        PREVIOUS_PUZZLE_COMPLETED = 1042,
        PUZZLE_MODE = 1073,
        CONCEDE_BUTTON_ALTERNATIVE_TEXT = 985,
        HIDE_RESTART_BUTTON = 990,
        END_TURN_BUTTON_ALTERNATIVE_APPEARANCE = 1000,
        TURN_INDICATOR_ALTERNATIVE_APPEARANCE = 1027,
        DISABLE_TURN_INDICATORS = 1448,
        DECK_RULE_MOD_DECK_SIZE = 997,
        IGNORE_DECK_RULESET = 1896,
        HIDE_OUT_OF_CARDS_WARNING = 1050,
        SUPPRESS_JOBS_DONE_VO = 1055,
        BLOCK_ALL_INPUT = 1071,
        SUPPRESS_ALL_SUMMON_VO = 1458,
        SUPPRESS_SUMMON_VO_FOR_PLAYER = 1521,
        SUPPRES_ALL_SOUNDS_FOR_ENTITY = 3093,
        DONT_SUPPRESS_SUMMON_VO = 2440,
        DONT_SUPPRESS_KEYWORD_VO = 2636,
        PLAYER_BASE_SHRINE_DECK_ID = 1099,
        DISPLAY_CARD_ON_MOUSEOVER = 1078,
        DECK_POWER_UP = 1080,
        SIDEKICK,
        SIDEKICK_HERO_POWER,
        RUN_PROGRESS = 1113,
        ALTERNATE_MOUSE_OVER_CARD = 1132,
        ENCHANTMENT_BANNER_TEXT = 1135,
        MOUSE_OVER_CARD_APPEARANCE = 1142,
        IS_ADVENTURE_SCENARIO = 1172,
        COIN_MANA_GEM = 1199,
        COIN_MANA_GEM_FOR_CHOICE_CARDS = 1643,
        TECH_LEVEL_MANA_GEM = 1442,
        BACON_COIN_ON_ENEMY_MINIONS = 1467,
        ALWAYS_USE_FAST_ACTOR_TRIGGERS = 1473,
        HEROIC_HERO_POWER = 1282,
        UI_BUFF_ATK_UP = 1297,
        UI_BUFF_COST_DOWN = 1296,
        UI_BUFF_COST_UP = 1298,
        UI_BUFF_HEALTH_UP = 1294,
        UI_BUFF_SET_COST_ZERO,
        UI_BUFF_DURABILITY_UP = 1443,
        GALAKROND_IN_PLAY = 1194,
        OUTCAST = 1333,
        STUDY = 1414,
        SPELLBURST = 1427,
        NON_KEYWORD_SPELLBURST = 2672,
        CORRUPT = 1524,
        CORRUPTED_CARD = 1551,
        FRENZY = 1637,
        TRADEABLE = 1720,
        FORGE = 2785,
        FORGED = 3011,
        FORGES_INTO = 3074,
        BACON_DUO_PASSABLE = 3178,
        DECK_ACTION_COST = 1743,
        IS_USING_TRADE_OPTION = 2045,
        IS_USING_FORGE_OPTION = 2869,
        IS_USING_PASS_OPTION = 3185,
        TOOL = 1722,
        QUESTLINE = 1725,
        HONORABLE_KILL = 1920,
        COLOSSAL = 2247,
        COLOSSAL_LIMB,
        COLOSSAL_LIMB_ON_LEFT = 2469,
        DREDGE = 2332,
        INFUSE = 2456,
        INFUSED,
        CORPSE = 2559,
        MANATHIRST = 2498,
        MAGNETIC_TO_RACE = 2859,
        MAX_SIDEBOARD_CARDS = 2931,
        MIN_SIDEBOARD_CARDS = 3459,
        FINALE = 2820,
        OVERHEAL,
        BONUS_EFFECTS = 2934,
        SIDEBOARD_TYPE = 3427,
        RED_MANA_GEM = 449,
        BACON_IS_KEL_THUZAD = 1423,
        BACON_TRIPLE_UPGRADE_MINION_ID = 1429,
        BACON_TRIPLE_CANDIDATE = 1460,
        BACON_TRIPLED_BASE_MINION_ID = 1471,
        BACON_TRIPLED_BASE_MINION_ID2 = 3499,
        BACON_TRIPLED_BASE_MINION_ID3,
        BACON_PAIR_CANDIDATE = 3031,
        BACON_DUO_TRIPLE_CANDIDATE_TEAMMATE = 3145,
        BACON_DUO_PAIR_CANDIDATE_TEAMMATE,
        BATTLEGROUNDS_PREMIUM_EMOTES = 1463,
        PLAYER_ID_LOOKUP = 1740,
        BACON_BLOOD_GEM_TOOLTIP = 1966,
        BACON_REFRESH_TOOLTIP = 2104,
        AVENGE = 2129,
        BACON_SPELLCRAFT_ID = 2359,
        VENOMOUS = 2853,
        BACON_HERO_EARLY_ACCESS = 1554,
        BACON_STARSTOBOUNCEOFF = 2155,
        BACON_CHOSEN_BOARD_SKIN_ID = 2264,
        BACON_COMPANION_ID = 2130,
        BACON_BUDDY = 2154,
        BATTLEGROUNDS_FAVORITE_FINISHER = 2348,
        BACON_OMIT_WHEN_OUT_OF_ROTATION = 2387,
        BACON_FREEZE_TOOLTIP = 2455,
        BACON_STEALTH_TOOLTIP = 2704,
        BACON_QUEST_TOOLTIP,
        BACON_REBORN_TOOLTIP = 2870,
        BACON_PUTRICIDES_CREATION_TOOLTIP = 2875,
        BACON_MINION_TYPE_REWARD = 2571,
        BACON_CARD_DBID_REWARD = 2673,
        BACON_IS_HEROPOWER_QUESTREWARD = 2706,
        BACON_HERO_QUEST_REWARD_DATABASE_ID = 2713,
        BACON_HERO_HEROPOWER_QUEST_REWARD_DATABASE_ID,
        BACON_HERO_QUEST_REWARD_COMPLETED,
        BACON_HERO_HEROPOWER_QUEST_REWARD_COMPLETED,
        BACON_DOUBLE_QUEST_HERO_POWER = 2803,
        BACON_IS_BOB_QUEST = 2732,
        BACON_HERO_REWARD_CARD_DBID = 2748,
        BACON_HERO_HEROPOWER_REWARD_CARD_DBID,
        BACON_HERO_REWARD_MINION_TYPE,
        BACON_HERO_HEROPOWER_REWARD_MINION_TYPE,
        BACON_DIED_LAST_COMBAT = 2483,
        BACON_GLOBAL_ANOMALY_DBID = 2897,
        HAS_DRAG_TO_BUY = 2458,
        TRANSIENT_ENTITY = 1493,
        BACON_TRIGGER_UPBEAT = 3046,
        BACON_TRIGGER_XY,
        BACON_SELL_VALUE = 1587,
        BACON_CURRENT_COMBAT_PLAYER_ID = 2989,
        BACON_CONSUME_TOOLTIP = 3254,
        FX_DATANUM_1 = 1436,
        FX_DATANUM_2 = 3077,
        FX_DATANUM_3 = 3109,
        BACON_VERDANTSPHERES = 1598,
        METAMORPHOSIS = 1644,
        BACON_AVALANCHE = 1744,
        BACON_COMEONECOMEALL = 1789,
        BACON_DIED_LAST_COMBAT_HINT = 2780,
        ROOTED = 2179,
        VULNERABLE,
        IMMOLATING = 2505,
        SPELLCRAFT_HINT = 2557,
        COPIED_HINT = 2572,
        BLEEDING = 2575,
        IMMOLATESTAGE = 2600,
        SINFUL_BRAND = 2613,
        HAUNTED_SECRET = 2634,
        SECRET_LOCKED = 2676,
        LITERALLY_UNPLAYABLE = 1020,
        UNPLAYABLE_VISUALS = 2798,
        DEATH_SPELL_OVERRIDE = 2722,
        EXTRA_TURNS_SPELL_OVERRIDE = 3465,
        BUILDING_UP = 3016,
        TUTORIAL_TARGET_OPPONENT_ANIM = 3192,
        TUTORIAL_TARGET_MINION_ANIM,
        TUTORIAL_PLAY_MINION_ANIM = 3195,
        TUTORIAL_HERO_POWER_TARGET_MINION_ANIM,
        TUTORIAL_HERO_POWER_TARGET_OPPONENT_ANIM,
        ALONE_RANGER = 3258,
        SUPPRESS_HERO_STANDARD_SUMMON_FX = 3438,
        SHUDDERWOCKHIGHLIGHTHINT = 3463,
        OUROBOSDEATHRATTLE = 3716,
        FAKE_ZONE = 1702,
        FAKE_ZONE_POSITION,
        FAKE_CONTROLLER = 2032,
        CUTSCENE_CARD_TYPE = 3265,
        LETTUCE_CONTROLLER = 1653,
        LETTUCE_MERCENARY = 1665,
        LETTUCE_ABILITY_OWNER = 1654,
        LETTUCE_SELECTED_TARGET = 1657,
        LETTUCE_SELECTED_SUBCARD_INDEX = 1661,
        LETTUCE_ROLE = 1666,
        LETTUCE_IS_COMBAT_ACTION_TAKEN = 1668,
        LETTUCE_COOLDOWN_CONFIG,
        LETTUCE_CURRENT_COOLDOWN,
        LETTUCE_ABILITY_SUMMONED_MINION = 1676,
        LETTUCE_ABILITY_TILE_VISUAL_SELF_ONLY = 1697,
        LETTUCE_ABILITY_TILE_VISUAL_ALL_VISIBLE,
        LETTUCE_MAX_IN_PLAY_MERCENARIES = 1704,
        LETTUCE_MERCENARIES_TO_NOMINATE,
        LETTUCE_COOLDOWN_WHILE_BENCHED = 1708,
        LETTUCE_MERCENARY_RESERVE = 1731,
        LETTUCE_SKIP_MERCENARY_RESERVE,
        LETTUCE_DISABLE_AUTO_SELECT_NEXT_MERC = 1753,
        LETTUCE_ABILITY_USED_LAST_TURN = 1807,
        LETTUCE_MERCENARY_EXPERIENCE = 1852,
        LETTUCE_IS_EQUPIMENT = 1855,
        LETTUCE_EQUIPMENT_ID,
        LETTUCE_SELECTED_ABILITY_QUEUE_ORDER = 1991,
        LETTUCE_HAS_MANUALLY_SELECTED_ABILITY = 1967,
        LETTUCE_KEEP_LAST_STANDING_MINION_ACTOR = 1976,
        LETTUCE_USE_DETERMINISTIC_TEAM_ABILITY_QUEUING = 1990,
        LETTUCE_NODE_TYPE = 1808,
        LETTUCE_PASSIVE_ABILITY = 1671,
        LETTUCE_BOUNTY_BOSS = 2168,
        LETTUCE_IS_TREASURE_CARD = 2170,
        LETTUCE_CURRENT_BOUNTY_ID = 2120,
        LETTUCE_SHOW_OPPOSING_FAKE_HAND = 2224,
        LETTUCE_VERSUS_SPELL_STATE = 2228,
        LETTUCE_START_OF_GAME_ABILITY = 2241,
        LETTUCE_CURSED_ABILITY_VISUAL = 2381,
        LETTUCE_OVERTIME = 2123,
        LETTUCE_ABILITY_TILE_VISUAL_PUBLIC_SPEED = 2470,
        LETTUCE_FACTION = 2720,
        LETTUCE_COMBAT_FROM_HIGH_TO_LOW = 1712,
        LETTUCE_ABILITY_TIER = 2493,
        LETTUCE_EQUIPMENT_TIER,
        MERCENARIES_DISCOVER_SOURCE = 2752,
        SUMMONED_WHEN_DRAWN = 3128,
        QUICKDRAW = 2905,
        EXCAVATE = 3114,
        MINIATURIZE = 3318,
        MINI,
        BACON_PASS_TOOLTIP = 3321,
        ZILLIAX_CUSTOMIZABLE_COSMETICMODULE = 3376,
        ZILLIAX_CUSTOMIZABLE_FUNCTIONALMODULE,
        ZILLIAX_CUSTOMIZABLE_LINKED_COSMETICMOUDLE = 3450,
        ZILLIAX_CUSTOMIZABLE_LINKED_FUNCTIONALMOUDLE = 3470,
        ZILLIAX_CUSTOMIZABLE_SAVED_VERSION = 3477,
        GIGANTIFY = 3399,
        GIGANTIC,
        MAGE_TOURIST = 3606,
        DRUID_TOURIST = 3605,
        WARRIOR_TOURIST = 3604,
        HUNTER_TOURIST = 3603,
        PRIEST_TOURIST = 3602,
        DEMON_HUNTER_TOURIST = 3601,
        SHAMAN_TOURIST = 3600,
        DEATH_KNIGHT_TOURIST = 3599,
        WARLOCK_TOURIST = 3598,
        ROGUE_TOURIST = 3597,
        PALADIN_TOURIST = 3607,

        None,
        Mob,
        Spell,
        Weapon
    }

    public enum TAG_ZONE
    {
        INVALID,
        PLAY,
        DECK,
        HAND,
        GRAVEYARD,
        REMOVEDFROMGAME,
        SETASIDE,
        SECRET,
        LETTUCE_ABILITY,
    }

    public enum TAG_CLASS
    {
        INVALID = 0,
        DEATHKNIGHT = 1,
        DRUID = 2,
        HUNTER = 3,
        MAGE = 4,
        PALADIN = 5,
        PRIEST = 6,
        ROGUE = 7,
        SHAMAN = 8,
        WARLOCK = 9,
        WARRIOR = 10,
        DREAM = 11,
        NEUTRAL = 12,
        WHIZBANG = 13,
		DEMONHUNTER = 14,
    }

    public enum TAG_RACE
    {
        INVALID = 0,
        BLOODELF = 1,
        DRAENEI = 2,
        DWARF = 3,
        GNOME = 4,
        GOBLIN = 5,
        HUMAN = 6,
        NIGHTELF = 7,
        ORC = 8,
        TAUREN = 9,
        TROLL = 10,
        UNDEAD = 11,
        WORGEN = 12,
        GOBLIN2 = 13,
        MURLOC = 14,
        DEMON = 15,
        SCOURGE = 16,
        MECHANICAL = 17,
        ELEMENTAL = 18,
        OGRE = 19,
        PET = 20,
        TOTEM = 21,
        NERUBIAN = 22,
        PIRATE = 23,
        DRAGON = 24,
        BLANK,
        ALL,
        EGG = 38,
        QUILBOAR = 43,
        CENTAUR = 80,
        FURBOLG,
        HIGHELF = 83,
        TREANT,
        OWLKIN,
        HALFORC = 88,
        LOCK,
        NAGA = 92,
        OLDGOD,
        PANDAREN,
        GRONN,
        CELESTIAL,
        GNOLL,
        GOLEM,
        HARPY,
        VULPERA
    }
    
    public enum TAG_CARDTYPE
    {
        NONE = 0,
        GAME = 1,
        PLAYER = 2,
        HERO = 3,//Ӣ��
        MOB = 4,//���
        SPELL = 5,//����
        ENCHANTMENT = 6,//���������磺�����������꣬�����Ĵ��ۣ���Ȼ֮���ĸ���Ч����
        WEAPON = 7,//����
        ITEM = 8,
        TOKEN = 9,
        HEROPWR = 10,//Ӣ�ۼ���
        BLANK = 11,
        GAME_MODE_BUTTON = 12,
        MOVE_MINION_HOVER_TARGET = 22,
        LETTUCE_ABILITY,
        BATTLEGROUND_HERO_BUDDY,//ս����
        LOCATION = 39,//�ر�
        BATTLEGROUND_QUEST_REWARD,//ս�콱��
        BATTLEGROUND_ANOMALY = 43,//ս�����
        BATTLEGROUND_SPELL = 42,//ս�취��
        BATTLEGROUND_TRINKET = 44,//ս����Ʒ
    }

    public enum TAG_CARD_SET
    {
        INVALID = 0,
        TEST_TEMPORARY = 1,
        CORE = 2,
        EXPERT1 = 3,
        REWARD = 4,
        MISSIONS = 5,
        DEMO = 6,
        NONE = 7,
        CHEAT = 8,
        BLANK = 9,
        DEBUG_SP = 10,
        PROMO = 11,
        FP1 = 12,
        PE1 = 13,
        BRM = 14,
        TGT = 15,
        CREDITS = 16,
        HERO_SKINS = 17,
        TB = 18,
        SLUSH = 19,
        LOE = 20,
        OG = 21,
        OG_RESERVE = 22,
        KARA = 23,
        KARA_RESERVE = 24,
        GANGS = 25,
        GANGS_RESERVE = 26,
        UNGORO = 27,
        ICECROWN = 1001
    }

    public enum TAG_RARITY
    {
        INVALID = 0,
        COMMON = 1,
        FREE = 2,
        RARE = 3,
        EPIC = 4,
        LEGENDARY = 5,
    }

    public enum TAG_SPELL_SCHOOL
    {
        NONE = 0,
        ARCANE = 1,
        FIRE = 2,
        FROST = 3,
        NATURE = 4,
        HOLY = 5,
        SHADOW = 6,
        FEL = 7,
        PHYSICAL_COMBAT = 8,
        TAVERN = 9,
        SPELLCRAFT = 10
    }
}