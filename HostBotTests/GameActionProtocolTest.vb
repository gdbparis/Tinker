﻿Imports Strilbrary.Values
Imports Strilbrary.Collections
Imports Strilbrary.Time
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Collections.Generic
Imports Tinker.Pickling
Imports Tinker.WC3
Imports Tinker.WC3.Protocol
Imports TinkerTests.PicklingTest

<TestClass()>
Public Class GameActionProtocolTest
    <TestMethod()>
    Public Sub AssignGroupHotkeyTest()
        JarTest(GameActions.AssignGroupHotkey,
                data:={1,
                       1, 0,
                       1, 0, 0, 0, 2, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"group index", 1},
                        {"targets", New List(Of GameObjectId)({New GameObjectId(1, 2)})}
                    })
    End Sub
    <TestMethod()>
    Public Sub CancelHeroReviveTest()
        JarTest(GameActions.CancelHeroRevive,
                data:={2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"target", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub ChangeAllyOptionsTest()
        JarTest(GameActions.ChangeAllyOptions,
                data:={1,
                       1 << 5, 1 << (10 - 8), 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player slot id", 1},
                        {"flags", AllianceTypes.AlliedVictory Or AllianceTypes.SharedVision}
                    })
    End Sub
    <TestMethod()>
    Public Sub ChangeSelectionTest()
        JarTest(GameActions.ChangeSelection,
                data:={2,
                       1, 0,
                       1, 0, 0, 0, 2, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"operation", SelectionOperation.Remove},
                        {"targets", New List(Of GameObjectId)({New GameObjectId(1, 2)})}
                    })
    End Sub
    <TestMethod()>
    Public Sub CheatDisableTechRequirementsTest()
        JarTest(GameActions.CheatDisableTechRequirements,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatDisableVictoryConditionsTest()
        JarTest(GameActions.CheatDisableVictoryConditions,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatEnableResearchTest()
        JarTest(GameActions.CheatEnableResearch,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatFastCooldownTest()
        JarTest(GameActions.CheatFastCooldown,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatFastDeathDecayTest()
        JarTest(GameActions.CheatFastDeathDecay,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatGodModeTest()
        JarTest(GameActions.CheatGodMode,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatGoldTest()
        JarTest(GameActions.CheatGold,
                data:={0,
                       100, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 0},
                        {"amount", 100}
                    })
    End Sub
    <TestMethod()>
    Public Sub CheatGoldAndLumberTest()
        JarTest(GameActions.CheatGoldAndLumber,
                data:={0,
                       100, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 0},
                        {"amount", 100}
                    })
    End Sub
    <TestMethod()>
    Public Sub CheatInstantDefeatTest()
        JarTest(GameActions.CheatInstantDefeat,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatInstantVictoryTest()
        JarTest(GameActions.CheatInstantVictory,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatLumberTest()
        JarTest(GameActions.CheatLumber,
                data:={0,
                       100, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 0},
                        {"amount", 100}
                    })
    End Sub
    <TestMethod()>
    Public Sub CheatNoDefeatTest()
        JarTest(GameActions.CheatNoDefeat,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatNoFoodLimitTest()
        JarTest(GameActions.CheatNoFoodLimit,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatRemoveFogOfWarTest()
        JarTest(GameActions.CheatRemoveFogOfWar,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatResearchUpgradesTest()
        JarTest(GameActions.CheatResearchUpgrades,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatSetTimeOfDayTest()
        JarTest(GameActions.CheatSetTimeOfDay,
                data:=BitConverter.GetBytes(CSng(12.0)),
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"time", CSng(12.0)}
                    })
    End Sub
    <TestMethod()>
    Public Sub CheatSpeedConstructionTest()
        JarTest(GameActions.CheatSpeedConstruction,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub CheatUnlimitedManaTest()
        JarTest(GameActions.CheatUnlimitedMana,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub DecreaseGameSpeedTest()
        JarTest(GameActions.DecreaseGameSpeed,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub DequeueBuildingOrderTest()
        JarTest(GameActions.DequeueBuildingOrder,
                data:={1,
                       &HFE, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"slot number", 1},
                        {"type", &HFE}
                    })
    End Sub
    <TestMethod()>
    Public Sub DropOrGiveItemTest()
        JarTest(GameActions.DropOrGiveItem,
                data:=New Byte() _
                      {1, 0,
                       3, 0, &HD, 0,
                       2, 0, 0, 0, 3, 0, 0, 0}.Concat(
                       BitConverter.GetBytes(CSng(5.0))).Concat(
                       BitConverter.GetBytes(CSng(6.0))).Concat({
                       3, 0, 0, 0, 2, 0, 0, 0,
                       5, 0, 0, 0, 8, 0, 0, 0}).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"flags", OrderTypes.Queue},
                        {"order", OrderId.Smart},
                        {"unknown", New GameObjectId(2, 3)},
                        {"x", CSng(5.0)},
                        {"y", CSng(6.0)},
                        {"receiver", New GameObjectId(3, 2)},
                        {"item", New GameObjectId(5, 8)}
                    })
    End Sub
    <TestMethod()>
    Public Sub EnterChooseBuildingSubmenuTest()
        JarTest(GameActions.EnterChooseBuildingSubmenu,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub EnterChooseHeroSkillSubmenuTest()
        JarTest(GameActions.EnterChooseHeroSkillSubmenu,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub FogObjectOrderTest()
        JarTest(GameActions.FogObjectOrder,
                data:=New Byte() _
                      {1, 0,
                       3, 0, &HD, 0,
                       2, 0, 0, 0, 3, 0, 0, 0}.Concat(
                       BitConverter.GetBytes(CSng(5.0))).Concat(
                       BitConverter.GetBytes(CSng(6.0))).Concat({
                       &HED, &HFE, 0, 0,
                       1, 2, 3, 4, 5, 6, 7, 8, 9}).Concat(
                       BitConverter.GetBytes(CSng(7.0))).Concat(
                       BitConverter.GetBytes(CSng(8.0))).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"flags", OrderTypes.Queue},
                        {"order", OrderId.Smart},
                        {"unknown", New GameObjectId(2, 3)},
                        {"fog target x", CSng(5.0)},
                        {"fog target y", CSng(6.0)},
                        {"fog target type", &HFEED},
                        {"unknown2", New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9}.AsReadableList},
                        {"actual target x", CSng(7.0)},
                        {"actual target y", CSng(8.0)}
                    })
    End Sub
    <TestMethod()>
    Public Sub GameCacheSyncBooleanTest()
        JarTest(GameActions.GameCacheSyncBoolean,
                data:={116, 101, 115, 116, 0,
                       101, 115, 116, 0,
                       116, 101, 115, 0,
                       1, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"filename", "test"},
                        {"mission key", "est"},
                        {"key", "tes"},
                        {"value", 1}
                    })
    End Sub
    <TestMethod()>
    Public Sub GameCacheSyncIntegerTest()
        JarTest(GameActions.GameCacheSyncInteger,
                data:={116, 101, 115, 116, 0,
                       101, 115, 116, 0,
                       116, 101, 115, 0,
                       1, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"filename", "test"},
                        {"mission key", "est"},
                        {"key", "tes"},
                        {"value", 1}
                    })
    End Sub
    <TestMethod()>
    Public Sub GameCacheSyncRealTest()
        JarTest(GameActions.GameCacheSyncReal,
                data:=New Byte() _
                      {116, 101, 115, 116, 0,
                       101, 115, 116, 0,
                       116, 101, 115, 0}.Concat(
                       BitConverter.GetBytes(CSng(1))).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"filename", "test"},
                        {"mission key", "est"},
                        {"key", "tes"},
                        {"value", CSng(1)}
                    })
    End Sub
    <TestMethod()>
    Public Sub GameCacheSyncStringTest()
        JarTest(GameActions.GameCacheSyncString,
                data:={116, 101, 115, 116, 0,
                       101, 115, 116, 0,
                       116, 101, 115, 0,
                       101, 115, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"filename", "test"},
                        {"mission key", "est"},
                        {"key", "tes"},
                        {"value", "es"}
                    })
    End Sub
    <TestMethod()>
    Public Sub GameCacheSyncUnitTest()
        Dim raw = Enumerable.Repeat(CByte(0), 86).ToArray
        JarTest(GameActions.GameCacheSyncUnit,
                data:=New Byte() _
                      {116, 101, 115, 116, 0,
                       101, 115, 116, 0,
                       116, 101, 115, 0,
                       &HFE, 0, 0, 0}.Concat(raw).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"filename", "test"},
                        {"mission key", "est"},
                        {"key", "tes"},
                        {"unit type", &HFE},
                        {"unknown data", raw.AsReadableList}
                    })
    End Sub
    <TestMethod()>
    Public Sub IncreaseGameSpeedTest()
        JarTest(GameActions.IncreaseGameSpeed,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub MinimapPingTest()
        JarTest(GameActions.MinimapPing,
                data:=BitConverter.GetBytes(CSng(5)).Concat(
                      BitConverter.GetBytes(CSng(6))).Concat(
                      {1, 2, 3, 4}).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"x", CSng(5.0)},
                        {"y", CSng(6.0)},
                        {"unknown", New Byte() {1, 2, 3, 4}.AsReadableList}
                    })
    End Sub
    <TestMethod()>
    Public Sub ObjectOrderTest()
        JarTest(GameActions.ObjectOrder,
                data:=New Byte() _
                      {1, 0,
                       3, 0, &HD, 0,
                       2, 0, 0, 0, 3, 0, 0, 0}.Concat(
                       BitConverter.GetBytes(CSng(5.0))).Concat(
                       BitConverter.GetBytes(CSng(6.0))).Concat({
                       3, 0, 0, 0, 2, 0, 0, 0}).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"flags", OrderTypes.Queue},
                        {"order", OrderId.Smart},
                        {"unknown", New GameObjectId(2, 3)},
                        {"x", CSng(5.0)},
                        {"y", CSng(6.0)},
                        {"target", New GameObjectId(3, 2)}
                    })
    End Sub
    <TestMethod()>
    Public Sub PauseGameTest()
        JarTest(GameActions.PauseGame,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub PointOrderTest()
        JarTest(GameActions.PointOrder,
                data:=New Byte() _
                      {1, 0,
                       3, 0, &HD, 0,
                       2, 0, 0, 0, 3, 0, 0, 0}.Concat(
                       BitConverter.GetBytes(CSng(5.0))).Concat(
                       BitConverter.GetBytes(CSng(6.0))).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"flags", OrderTypes.Queue},
                        {"order", OrderId.Smart},
                        {"unknown", New GameObjectId(2, 3)},
                        {"target x", CSng(5.0)},
                        {"target y", CSng(6.0)}
                    })
    End Sub
    <TestMethod()>
    Public Sub PressedEscapeTest()
        JarTest(GameActions.PressedEscape,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub PreSubGroupSelectionTest()
        JarTest(GameActions.PreSubGroupSelection,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub ResumeGameTest()
        JarTest(GameActions.ResumeGame,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub SaveGameFinishedTest()
        JarTest(GameActions.SaveGameFinished,
                data:={1, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 1}
                    })
    End Sub
    <TestMethod()>
    Public Sub SaveGameStartedTest()
        JarTest(GameActions.SaveGameStarted,
                data:={116, 101, 115, 116, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"filename", "test"}
                    })
    End Sub
    <TestMethod()>
    Public Sub SelectGroundItemTest()
        JarTest(GameActions.SelectGroundItem,
                data:={1,
                       2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 1},
                        {"target", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub SelectGroupHotkeyTest()
        JarTest(GameActions.SelectGroupHotkey,
                data:={1, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"group index", 1},
                        {"unknown", 0}
                    })
    End Sub
    <TestMethod()>
    Public Sub SelectSubGroupTest()
        JarTest(GameActions.SelectSubGroup,
                data:={&HEF, &HBE, &HED, &HFE,
                       2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unit type", &HFEEDBEEFUI},
                        {"target", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub SelfOrderTest()
        JarTest(GameActions.SelfOrder,
                data:={1, 0,
                       3, 0, &HD, 0,
                       2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"flags", OrderTypes.Queue},
                        {"order", OrderId.Smart},
                        {"unknown", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub SetGameSpeedTest()
        JarTest(GameActions.SetGameSpeed,
                data:={2},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"speed", GameSpeedSetting.Fast}
                    })
    End Sub
    <TestMethod()>
    Public Sub TransferResourcesTest()
        JarTest(GameActions.TransferResources,
                data:={1,
                       100, 0, 0, 0,
                       200, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player slot id", 1},
                        {"gold", 100},
                        {"lumber", 200}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerArrowKeyEventTest()
        JarTest(GameActions.TriggerArrowKeyEvent,
                data:={4},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"event type", ArrowKeyEvent.PressedDownArrow}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerChatEventTest()
        JarTest(GameActions.TriggerChatEvent,
                data:={2, 0, 0, 0, 3, 0, 0, 0,
                       116, 101, 115, 116, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"trigger event", New GameObjectId(2, 3)},
                        {"text", "test"}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerDialogButtonClickedTest()
        JarTest(GameActions.TriggerDialogButtonClicked,
                data:={2, 0, 0, 0, 3, 0, 0, 0,
                       4, 0, 0, 0, 5, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"dialog", New GameObjectId(2, 3)},
                        {"button", New GameObjectId(4, 5)}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerDialogButtonClicked2Test()
        JarTest(GameActions.TriggerDialogButtonClicked2,
                data:={2, 0, 0, 0, 3, 0, 0, 0,
                       4, 0, 0, 0, 5, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"button", New GameObjectId(2, 3)},
                        {"dialog", New GameObjectId(4, 5)}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerMouseClickedTrackableTest()
        JarTest(GameActions.TriggerMouseClickedTrackable,
                data:={2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"trackable", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerMouseTouchedTrackableTest()
        JarTest(GameActions.TriggerMouseTouchedTrackable,
                data:={2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"trackable", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerSelectionEventTest()
        JarTest(GameActions.TriggerSelectionEvent,
                data:={1,
                       2, 0, 0, 0, 3, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"operation", SelectionOperation.Add},
                        {"target", New GameObjectId(2, 3)}
                    })
    End Sub
    <TestMethod()>
    Public Sub TriggerWaitFinishedTest()
        JarTest(GameActions.TriggerWaitFinished,
                data:={2, 0, 0, 0, 3, 0, 0, 0,
                       1, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"trigger thread", New GameObjectId(2, 3)},
                        {"thread wait count", 1}
                    })
    End Sub
End Class
