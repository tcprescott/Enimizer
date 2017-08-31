﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemizerLibrary
{
    public static class SpriteConstants
    {
        /*
         * $06B44C
         * Byte formatted thus: i s phhhhh
         * s - 'Statis'. If set, indicates that the sprite should not be considered as "alive" in routines that try to check that property. 
         * Functionally, the sprites might not actually be considered to be in statis though. 
         * Example: Bubbles (aka Fire Faeries) are not considered alive for the purposes of puzzles, 
         * because it's not expected that you always have the resources to kill them. Thus, they always have this bit set.
         */
        public static readonly byte StatisMask = 0x40; // 0100 0000

        public static readonly byte
            RavenSprite = 0x00,
            VultureSprite = 0x01,
            FlyingStalfosHeadSprite = 0x02,
            EmptySprite = 0x03,
            PullSwitch_GoodSprite = 0x04,
            PullSwitch_Unused1Sprite = 0x05,
            PullSwitch_BadSprite = 0x06,
            PullSwitch_Unused2Sprite = 0x07,
            Octorok_OneWaySprite = 0x08,
            MoldormSprite = 0x09,
            Octorok_FourWaySprite = 0x0A,
            ChickenSprite = 0x0B,
            Octorok_MaybeSprite = 0x0C,
            BuzzblobSprite = 0x0D,
            SnapdragonSprite = 0x0E,
            OctoballoonSprite = 0x0F,
            OctoballoonHatchlingsSprite = 0x10,
            HinoxSprite = 0x11,
            MoblinSprite = 0x12,
            MiniHelmasaurSprite = 0x13,
            GargoylesDomainGateSprite = 0x14,
            AntifairySprite = 0x15,
            SahasrahlaAginahSprite = 0x16,
            BushHoarderSprite = 0x17,
            MiniMoldormSprite = 0x18,
            PoeSprite = 0x19,
            DwarvesSprite = 0x1A,
            ArrowInWall_MaybeSprite = 0x1B,
            StatueSprite = 0x1C,
            WeathervaneSprite = 0x1D,
            CrystalSwitchSprite = 0x1E,
            BugCatchingKidSprite = 0x1F,
            SluggulaSprite = 0x20,
            PushSwitchSprite = 0x21,
            RopaSprite = 0x22,
            RedBariSprite = 0x23,
            BlueBariSprite = 0x24,
            TalkingTreeSprite = 0x25,
            HardhatBeetleSprite = 0x26,
            DeadrockSprite = 0x27,
            StorytellersSprite = 0x28,
            BlindHideoutAttendantSprite = 0x29,
            SweepingLadySprite = 0x2A,
            MultipurposeSpriteSprite = 0x2B,
            LumberjacksSprite = 0x2C,
            TelepathicStones_NoIdeaWhatThisActuallyIsLikelyUnusedSprite = 0x2D,
            FluteBoysNotesSprite = 0x2E,
            RaceHPNPCsSprite = 0x2F,
            Person_MaybeSprite = 0x30,
            FortuneTellerSprite = 0x31,
            AngryBrothersSprite = 0x32,
            PullForRupeesSpriteSprite = 0x33,
            ScaredGirl2Sprite = 0x34,
            InnkeeperSprite = 0x35,
            WitchSprite = 0x36,
            WaterfallSprite = 0x37,
            ArrowTargetSprite = 0x38,
            AverageMiddleAgedManSprite = 0x39,
            HalfMagicBatSprite = 0x3A,
            DashItemSprite = 0x3B,
            VillageKidSprite = 0x3C,
            Signs_ChickenLadyAlsoShowedUp_ScaredLadiesOutsideHousesSprite = 0x3D,
            RockHoarderSprite = 0x3E,
            TutorialSoldierSprite = 0x3F,
            LightningLockSprite = 0x40,
            BlueSwordSoldier_DetectPlayerSprite = 0x41,
            GreenSwordSoldierSprite = 0x42,
            RedSpearSoldierSprite = 0x43,
            AssaultSwordSoldierSprite = 0x44,
            GreenSpearSoldierSprite = 0x45,
            BlueArcherSprite = 0x46,
            GreenArcherSprite = 0x47,
            RedJavelinSoldierSprite = 0x48,
            RedJavelinSoldier2Sprite = 0x49,
            RedBombSoldiersSprite = 0x4A,
            GreenSoldierRecruits_HMKnightSprite = 0x4B,
            GeldmanSprite = 0x4C,
            RabbitSprite = 0x4D,
            PopoSprite = 0x4E,
            Popo2Sprite = 0x4F,
            CannonBallsSprite = 0x50,
            ArmosSprite = 0x51,
            GiantZoraSprite = 0x52,
            ArmosKnightsSprite = 0x53,
            LanmolasSprite = 0x54,
            FireballZoraSprite = 0x55,
            WalkingZoraSprite = 0x56,
            DesertPalaceBarriersSprite = 0x57,
            CrabSprite = 0x58,
            BirdSprite = 0x59,
            SquirrelSprite = 0x5A,
            Spark_LeftToRightSprite = 0x5B,
            Spark_RightToLeftSprite = 0x5C,
            Roller_VerticalMovingSprite = 0x5D,
            Roller_VerticalMoving2Sprite = 0x5E,
            RollerSprite = 0x5F,
            Roller_HorizontalMovingSprite = 0x60,
            BeamosSprite = 0x61,
            MasterSwordSprite = 0x62,
            Devalant_NonShooterSprite = 0x63,
            Devalant_ShooterSprite = 0x64,
            ShootingGalleryProprietorSprite = 0x65,
            MovingCannonBallShooters_RightSprite = 0x66,
            MovingCannonBallShooters_LeftSprite = 0x67,
            MovingCannonBallShooters_DownSprite = 0x68,
            MovingCannonBallShooters_UpSprite = 0x69,
            BallNChainTrooperSprite = 0x6A,
            CannonSoldierSprite = 0x6B,
            MirrorPortalSprite = 0x6C,
            RatSprite = 0x6D,
            RopeSprite = 0x6E,
            KeeseSprite = 0x6F,
            HelmasaurKingFireballSprite = 0x70,
            LeeverSprite = 0x71,
            ActivatoForThePonds_WhereYouThrowInItemsSprite = 0x72,
            UnclePriestSprite = 0x73,
            RunningManSprite = 0x74,
            BottleSalesmanSprite = 0x75,
            PrincessZeldaSprite = 0x76,
            Antifairy_AlternateSprite = 0x77,
            VillageElderSprite = 0x78,
            BeeSprite = 0x79,
            AgahnimSprite = 0x7A,
            AgahnimEnergyBallSprite = 0x7B,
            HyuSprite = 0x7C,
            BigSpikeTrapSprite = 0x7D,
            GuruguruBar_ClockwiseSprite = 0x7E,
            GuruguruBar_CounterClockwiseSprite = 0x7F,
            WinderSprite = 0x80,
            WaterTektiteSprite = 0x81,
            AntifairyCircleSprite = 0x82,
            GreenEyegoreSprite = 0x83,
            RedEyegoreSprite = 0x84,
            YellowStalfosSprite = 0x85,
            KodongosSprite = 0x86,
            FlamesSprite = 0x87,
            MothulaSprite = 0x88,
            MothulasBeamSprite = 0x89,
            SpikeTrapSprite = 0x8A,
            GibdoSprite = 0x8B,
            ArrghusSprite = 0x8C,
            ArrghusSpawnSprite = 0x8D,
            TerrorpinSprite = 0x8E,
            SlimeSprite = 0x8F,
            WallmasterSprite = 0x90,
            StalfosKnightSprite = 0x91,
            HelmasaurKingSprite = 0x92,
            BumperSprite = 0x93,
            SwimmersSprite = 0x94,
            EyeLaser_RightSprite = 0x95,
            EyeLaser_LeftSprite = 0x96,
            EyeLaser_DownSprite = 0x97,
            EyeLaser_UpSprite = 0x98,
            PengatorSprite = 0x99,
            KyameronSprite = 0x9A,
            WizzrobeSprite = 0x9B,
            TadpolesSprite = 0x9C,
            Tadpoles2Sprite = 0x9D,
            Ostrich_HauntedGroveSprite = 0x9E,
            FluteSprite = 0x9F,
            Birds_HauntedGroveSprite = 0xA0,
            FreezorSprite = 0xA1,
            KholdstareSprite = 0xA2,
            KholdstaresShellSprite = 0xA3,
            FallingIceSprite = 0xA4,
            ZazakFireballSprite = 0xA5,
            RedZazakSprite = 0xA6,
            StalfosSprite = 0xA7,
            BomberFlyingCreaturesFromDarkworldSprite = 0xA8,
            BomberFlyingCreaturesFromDarkworld2Sprite = 0xA9,
            PikitSprite = 0xAA,
            MaidenSprite = 0xAB,
            AppleSprite = 0xAC,
            LostOldManSprite = 0xAD,
            DownPipeSprite = 0xAE,
            UpPipeSprite = 0xAF,
            RightPipeSprite = 0xB0,
            LeftPipeSprite = 0xB1,
            GoodBee_AgainMaybeSprite = 0xB2,
            HylianInscriptionSprite = 0xB3,
            ThiefsChestSprite = 0xB4,
            BombSalesmanSprite = 0xB5,
            KikiSprite = 0xB6,
            MaidenInBlindDungeonSprite = 0xB7,
            MonologueTestingSpriteSprite = 0xB8,
            FeudingFriendsOnDeathMountainSprite = 0xB9,
            WhirlpoolSprite = 0xBA,
            SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite = 0xBB,
            DrunkInTheInnSprite = 0xBC,
            Vitreous_LargeEyeballSprite = 0xBD,
            Vitreous_SmallEyeballSprite = 0xBE,
            VitreousLightningSprite = 0xBF,
            CatFish_QuakeMedallionSprite = 0xC0,
            AgahnimTeleportingZeldaToDarkworldSprite = 0xC1,
            BouldersSprite = 0xC2,
            GiboSprite = 0xC3,
            ThiefSprite = 0xC4,
            MedusaSprite = 0xC5,
            FourWayFireballSpittersSprite = 0xC6,
            HokkuBokkuSprite = 0xC7,
            BigFairyWhoHealsYouSprite = 0xC8,
            TektiteSprite = 0xC9,
            ChainChompSprite = 0xCA,
            TrinexxSprite = 0xCB,
            AnotherPartOfTrinexxSprite = 0xCC,
            YetAnotherPartOfTrinexxSprite = 0xCD,
            BlindTheThiefSprite = 0xCE,
            SwamolaSprite = 0xCF,
            LynelSprite = 0xD0,
            BunnyBeamSprite = 0xD1,
            FloppingFishSprite = 0xD2,
            StalSprite = 0xD3,
            LandmineSprite = 0xD4,
            DiggingGameProprietorSprite = 0xD5,
            GanonSprite = 0xD6,
            CopyOfGanon_ExceptInvincibleSprite = 0xD7,
            HeartSprite = 0xD8,
            GreenRupeeSprite = 0xD9,
            BlueRupeeSprite = 0xDA,
            RedRupeeSprite = 0xDB,
            BombRefill1Sprite = 0xDC,
            BombRefill4Sprite = 0xDD,
            BombRefill8Sprite = 0xDE,
            SmallMagicRefillSprite = 0xDF,
            FullMagicRefillSprite = 0xE0,
            ArrowRefill5Sprite = 0xE1,
            ArrowRefill10Sprite = 0xE2,
            FairySprite = 0xE3,
            KeySprite = 0xE4,
            BigKeySprite = 0xE5,
            ShieldSprite = 0xE6,
            MushroomSprite = 0xE7,
            FakeMasterSwordSprite = 0xE8,
            MagicShopDude_HisItemsIncludingTheMagicPowderSprite = 0xE9,
            HeartContainerSprite = 0xEA,
            HeartPieceSprite = 0xEB,
            BushesSprite = 0xEC,
            CaneOfSomariaPlatformSprite = 0xED,
            MantleSprite = 0xEE,
            CaneOfSomariaPlatform_Unused1Sprite = 0xEF,
            CaneOfSomariaPlatform_Unused2Sprite = 0xF0,
            CaneOfSomariaPlatform_Unused3Sprite = 0xF1,
            MedallionTabletSprite = 0xF2;

        //all the absorbable sprites fairy, bombs, rupees, arrows, ect, that can be used in any rooms without any specific set selected
        public static readonly byte[] absorbable_sprites =
        {
            SpriteConstants.HeartSprite,
            SpriteConstants.GreenRupeeSprite,
            SpriteConstants.BlueRupeeSprite,
            SpriteConstants.RedRupeeSprite,
            SpriteConstants.BombRefill1Sprite,
            SpriteConstants.BombRefill4Sprite,
            SpriteConstants.BombRefill8Sprite,
            SpriteConstants.SmallMagicRefillSprite,
            SpriteConstants.FullMagicRefillSprite,
            SpriteConstants.ArrowRefill5Sprite,
            SpriteConstants.ArrowRefill10Sprite,
            SpriteConstants.FairySprite,
            SpriteConstants.KeySprite // TODO: do we want this in the pool?
        };


        //For Keys
        public static readonly byte[] NonKillable =
        {
            SpriteConstants.ActivatoForThePonds_WhereYouThrowInItemsSprite,
            SpriteConstants.AngryBrothersSprite,
            SpriteConstants.Antifairy_AlternateSprite,
            SpriteConstants.AntifairyCircleSprite,
            SpriteConstants.AntifairySprite,
            SpriteConstants.AppleSprite,
            SpriteConstants.ArrowRefill10Sprite,
            SpriteConstants.ArrowRefill5Sprite,
            SpriteConstants.ArrowTargetSprite,
            SpriteConstants.BeamosSprite,
            SpriteConstants.BigKeySprite,
            SpriteConstants.BigSpikeTrapSprite,
            SpriteConstants.Birds_HauntedGroveSprite,
            SpriteConstants.BlindHideoutAttendantSprite,
            SpriteConstants.BlueRupeeSprite,
            SpriteConstants.BomberFlyingCreaturesFromDarkworld2Sprite,
            SpriteConstants.BomberFlyingCreaturesFromDarkworldSprite,
            SpriteConstants.BombRefill1Sprite,
            SpriteConstants.BombRefill4Sprite,
            SpriteConstants.BombRefill8Sprite,
            SpriteConstants.BouldersSprite,
            SpriteConstants.BumperSprite,
            SpriteConstants.BunnyBeamSprite,
            SpriteConstants.ChainChompSprite,
            SpriteConstants.ChickenSprite,
            SpriteConstants.CrystalSwitchSprite,
            SpriteConstants.DeadrockSprite,
            SpriteConstants.DesertPalaceBarriersSprite,
            SpriteConstants.DownPipeSprite,
            SpriteConstants.DwarvesSprite,
            SpriteConstants.EmptySprite,
            SpriteConstants.EyeLaser_DownSprite,
            SpriteConstants.EyeLaser_LeftSprite,
            SpriteConstants.EyeLaser_RightSprite,
            SpriteConstants.EyeLaser_UpSprite,
            SpriteConstants.FairySprite,
            SpriteConstants.FallingIceSprite,
            SpriteConstants.FluteSprite,
            SpriteConstants.FlyingStalfosHeadSprite,
            SpriteConstants.FortuneTellerSprite,
            SpriteConstants.FourWayFireballSpittersSprite,
            SpriteConstants.FreezorSprite,
            SpriteConstants.FullMagicRefillSprite,
            SpriteConstants.GargoylesDomainGateSprite,
            SpriteConstants.GoodBee_AgainMaybeSprite,
            SpriteConstants.GreenRupeeSprite,
            SpriteConstants.GuruguruBar_ClockwiseSprite,
            SpriteConstants.GuruguruBar_CounterClockwiseSprite,
            SpriteConstants.HardhatBeetleSprite,
            SpriteConstants.HeartSprite,
            SpriteConstants.HyuSprite,
            SpriteConstants.InnkeeperSprite,
            SpriteConstants.KeeseSprite,
            SpriteConstants.KeySprite,
            SpriteConstants.KyameronSprite,
            SpriteConstants.LeftPipeSprite,
            SpriteConstants.LightningLockSprite,
            SpriteConstants.LostOldManSprite,
            SpriteConstants.LynelSprite,
            SpriteConstants.MaidenInBlindDungeonSprite,
            SpriteConstants.MedusaSprite,
            SpriteConstants.MonologueTestingSpriteSprite,
            SpriteConstants.MovingCannonBallShooters_DownSprite,
            SpriteConstants.MovingCannonBallShooters_LeftSprite,
            SpriteConstants.MovingCannonBallShooters_RightSprite,
            SpriteConstants.MovingCannonBallShooters_UpSprite,
            SpriteConstants.MushroomSprite,
            SpriteConstants.Ostrich_HauntedGroveSprite,
            SpriteConstants.PikitSprite,
            SpriteConstants.PoeSprite,
            SpriteConstants.PullSwitch_BadSprite,
            SpriteConstants.PullSwitch_GoodSprite,
            SpriteConstants.PullSwitch_Unused1Sprite,
            SpriteConstants.PullSwitch_Unused2Sprite,
            SpriteConstants.PushSwitchSprite,
            SpriteConstants.RabbitSprite,
            SpriteConstants.RaceHPNPCsSprite,
            SpriteConstants.RavenSprite,
            SpriteConstants.RedBariSprite,
            SpriteConstants.RedEyegoreSprite,
            SpriteConstants.RedRupeeSprite,
            SpriteConstants.RightPipeSprite,
            SpriteConstants.Roller_HorizontalMovingSprite,
            SpriteConstants.Roller_VerticalMoving2Sprite,
            SpriteConstants.Roller_VerticalMovingSprite,
            SpriteConstants.RollerSprite,
            SpriteConstants.SahasrahlaAginahSprite,
            SpriteConstants.ShieldSprite,
            SpriteConstants.SmallMagicRefillSprite,
            SpriteConstants.Spark_LeftToRightSprite,
            SpriteConstants.Spark_RightToLeftSprite,
            SpriteConstants.SpikeTrapSprite,
            SpriteConstants.StalfosKnightSprite,
            SpriteConstants.StatueSprite,
            SpriteConstants.StorytellersSprite,
            SpriteConstants.SweepingLadySprite,
            SpriteConstants.SwimmersSprite,
            SpriteConstants.TerrorpinSprite,
            SpriteConstants.TutorialSoldierSprite,
            SpriteConstants.UpPipeSprite,
            SpriteConstants.VillageKidSprite,
            SpriteConstants.VultureSprite,
            SpriteConstants.WallmasterSprite,
            SpriteConstants.WaterfallSprite,
            SpriteConstants.WaterTektiteSprite,
            SpriteConstants.WinderSprite,
            SpriteConstants.WitchSprite,
            SpriteConstants.YellowStalfosSprite
        };

        /*
         * $06B44C
         * Byte formatted thus: i s phhhhh
         * s - 'Statis'. If set, indicates that the sprite should not be considered as "alive" in routines that try to check that property. 
         * Functionally, the sprites might not actually be considered to be in statis though. 
         * Example: Bubbles (aka Fire Faeries) are not considered alive for the purposes of puzzles, 
         * because it's not expected that you always have the resources to kill them. Thus, they always have this bit set.
         */
        public static readonly byte[] statis_sprites =
        {
            SpriteConstants.ChainChompSprite,
            SpriteConstants.DeadrockSprite,
            SpriteConstants.Roller_VerticalMovingSprite,
            SpriteConstants.Roller_VerticalMoving2Sprite,
            SpriteConstants.RollerSprite,
            SpriteConstants.Roller_HorizontalMovingSprite,
            SpriteConstants.GuruguruBar_ClockwiseSprite,
            SpriteConstants.GuruguruBar_CounterClockwiseSprite
        };

        //Non Killable in shutter doors Rooms
        public static readonly byte[] NonKillable_shutter =
        {
            SpriteConstants.ActivatoForThePonds_WhereYouThrowInItemsSprite,
            SpriteConstants.AngryBrothersSprite,
            SpriteConstants.Antifairy_AlternateSprite,
            SpriteConstants.AntifairyCircleSprite,
            SpriteConstants.ArrowTargetSprite,
            SpriteConstants.Birds_HauntedGroveSprite,
            SpriteConstants.BlindHideoutAttendantSprite,
            SpriteConstants.BouldersSprite,
            SpriteConstants.BumperSprite,
            SpriteConstants.ChickenSprite,
            SpriteConstants.CrystalSwitchSprite,
            SpriteConstants.DeadrockSprite,
            SpriteConstants.DesertPalaceBarriersSprite,
            SpriteConstants.DownPipeSprite,
            SpriteConstants.DwarvesSprite,
            SpriteConstants.EmptySprite,
            SpriteConstants.EyeLaser_DownSprite,
            SpriteConstants.EyeLaser_LeftSprite,
            SpriteConstants.EyeLaser_RightSprite,
            SpriteConstants.EyeLaser_UpSprite,
            SpriteConstants.FluteSprite,
            SpriteConstants.FlyingStalfosHeadSprite,
            SpriteConstants.FortuneTellerSprite,
            SpriteConstants.FourWayFireballSpittersSprite,
            SpriteConstants.FreezorSprite,
            SpriteConstants.GargoylesDomainGateSprite,
            SpriteConstants.GoodBee_AgainMaybeSprite,
            SpriteConstants.HardhatBeetleSprite,
            SpriteConstants.InnkeeperSprite,
            SpriteConstants.KeeseSprite,
            SpriteConstants.KyameronSprite,
            SpriteConstants.LeftPipeSprite,
            SpriteConstants.LightningLockSprite,
            SpriteConstants.LostOldManSprite,
            SpriteConstants.LynelSprite,
            SpriteConstants.MaidenInBlindDungeonSprite,
            SpriteConstants.MedusaSprite,
            SpriteConstants.MonologueTestingSpriteSprite,
            SpriteConstants.MovingCannonBallShooters_DownSprite,
            SpriteConstants.MovingCannonBallShooters_LeftSprite,
            SpriteConstants.MovingCannonBallShooters_RightSprite,
            SpriteConstants.MovingCannonBallShooters_UpSprite,
            SpriteConstants.Ostrich_HauntedGroveSprite,
            SpriteConstants.PoeSprite,
            SpriteConstants.PullSwitch_BadSprite,
            SpriteConstants.PullSwitch_GoodSprite,
            SpriteConstants.PullSwitch_Unused1Sprite,
            SpriteConstants.PullSwitch_Unused2Sprite,
            SpriteConstants.PushSwitchSprite,
            SpriteConstants.RabbitSprite,
            SpriteConstants.RaceHPNPCsSprite,
            SpriteConstants.RavenSprite,
            SpriteConstants.RedEyegoreSprite,
            SpriteConstants.RightPipeSprite,
            SpriteConstants.SahasrahlaAginahSprite,
            SpriteConstants.SpikeTrapSprite,
            SpriteConstants.StalfosKnightSprite,
            SpriteConstants.StatueSprite,
            SpriteConstants.StorytellersSprite,
            SpriteConstants.SweepingLadySprite,
            SpriteConstants.SwimmersSprite,
            SpriteConstants.TerrorpinSprite,
            SpriteConstants.TutorialSoldierSprite,
            SpriteConstants.UpPipeSprite,
            SpriteConstants.VillageKidSprite,
            SpriteConstants.VultureSprite,
            SpriteConstants.WallmasterSprite,
            SpriteConstants.WaterfallSprite,
            SpriteConstants.WaterTektiteSprite,
            SpriteConstants.WinderSprite,
            SpriteConstants.WitchSprite,
            SpriteConstants.YellowStalfosSprite
        };


        public static readonly byte[] bowSprites = { SpriteConstants.GreenEyegoreSprite, SpriteConstants.RedEyegoreSprite };
        public static readonly byte[] hammerSprites = { SpriteConstants.TerrorpinSprite };

        public static readonly int[] key_sprite = { 0x04DA20, 0x04DA5C, 0x04DB7F, 0x04DD73, 0x04DDC3, 0x04DE07, 0x04E203, 0x04E20B, 0x04E326, 0x04E4F7, 0x04E70C, 0x04E7C8, 0x04E7FA, 0x04E200, 0x04E687, 0x04E991, 0x04E994, 0x04E997, 0x04E99A, 0x04E99D, 0x04E9A0, 0x04E9A3, 0x04E9A6, 0x04E9A9, 0x04E9AC, 0x04E9AF, 0x04E790, 0x04E78D, 0x04E78A };

        //all the sprites "gfx" sheet 
        public static readonly byte[] sprite_subset_0 = { 22, 31, 47, 14 }; //70-72 part of guards we already have 4 guard set don't need more
        public static readonly byte[] sprite_subset_1 = { 44, 30, 32 };//73-13
        public static readonly byte[] sprite_subset_2 = { 12, 18, 23, 24, 28, 46, 34, 35, 39, 40, 38, 41, 36, 37, 42 };//19 trainee guard
        public static readonly byte[] sprite_subset_3 = { 17, 16, 27, 20, 82, 83 };

    }
}