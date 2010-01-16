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
Public Class WC3ProtocolTest
    <TestMethod()>
    Public Sub ClientConfirmHostLeavingTest()
        JarTest(Packets.ClientConfirmHostLeaving,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub ClientMapInfoTest()
        JarTest(Packets.ClientMapInfo,
                data:={1, 0, 0, 0,
                       3,
                       128, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 1},
                        {"dl state", DownloadState.Downloading},
                        {"total downloaded", 128}
                    })
    End Sub
    <TestMethod()>
    Public Sub GameActionTest()
        JarTest(Packets.GameAction,
                appendSafe:=False,
                data:={32, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"crc32", 32},
                        {"actions", New List(Of GameAction)()}
                    })
    End Sub
    <TestMethod()>
    Public Sub GreetTest()
        JarTest(Packets.Greet,
                data:={0, 0,
                       2,
                       2, 0, &H17, &HE1, 127, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"slot data", New Byte() {}.AsReadableList},
                        {"player index", 2},
                        {"external address", New Net.IPEndPoint(Net.IPAddress.Loopback, 6113)}
                    })
    End Sub
    <TestMethod()>
    Public Sub HostConfirmHostLeavingTest()
        JarTest(Packets.HostConfirmHostLeaving,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub HostMapInfoTest()
        Dim sha1 = (From i In Enumerable.Range(0, 20)
                    Select CByte(i)).ToArray.AsReadableList
        JarTest(Packets.HostMapInfo,
                data:=New Byte() _
                      {0, 0, 0, 0,
                       116, 101, 115, 116, 0,
                       15, 0, 0, 0,
                       32, 0, 0, 0,
                       13, 0, 0, 0}.Concat(
                       sha1).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 0},
                        {"path", "test"},
                        {"size", 15},
                        {"crc32", 32},
                        {"xoro checksum", 13},
                        {"sha1 checksum", sha1}
                    })
    End Sub
    <TestMethod()>
    Public Sub KnockTest()
        JarTest(Packets.Knock,
                data:={42, 0, 0, 0,
                       99, 0, 0, 0,
                       0,
                       &HE0, &H17,
                       16, 0, 0, 0,
                       116, 101, 115, 116, 0,
                       1, 0,
                       2, 0, &H17, &HE1, 127, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"game id", 42},
                        {"entry key", 99},
                        {"unknown value", 0},
                        {"listen port", 6112},
                        {"peer key", 16},
                        {"name", "test"},
                        {"unknown data", New Byte() {0}.AsReadableList},
                        {"internal address", New Net.IPEndPoint(Net.IPAddress.Loopback, 6113)}
                    })
    End Sub
    <TestMethod()>
    Public Sub LanCreateGameTest()
        JarTest(Packets.LanCreateGame,
                data:={Asc("3"), Asc("r"), Asc("a"), Asc("w"),
                       20, 0, 0, 0,
                       42, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"product id", "war3"},
                        {"major version", 20},
                        {"game id", 42}
                    })
    End Sub
    <TestMethod()>
    Public Sub LanDescribeGameTest()
        JarTest(Packets.LanDescribeGame,
                data:=New Byte() _
                      {Asc("3"), Asc("r"), Asc("a"), Asc("w"),
                       20, 0, 0, 0,
                       42, 0, 0, 0,
                       16, 0, 0, 0,
                       116, 101, 115, 116, 0,
                       0}.Concat(
                       New GameStatsJar("test").Pack(BnetProtocolTest.TestStats).Data).Concat({
                       12, 0, 0, 0,
                       8, 0, 0, 0,
                       2, 0, 0, 0,
                       12, 0, 0, 0,
                       25, 0, 0, 0,
                       &HE0, &H17}).ToArray,
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"product id", "war3"},
                        {"major version", 20},
                        {"game id", 42},
                        {"entry key", 16},
                        {"name", "test"},
                        {"password", ""},
                        {"statstring", BnetProtocolTest.TestStats},
                        {"num slots", 12},
                        {"game type", GameTypes.AuthenticatedMakerBlizzard},
                        {"num players + 1", 2},
                        {"free slots + 1", 12},
                        {"age", 25},
                        {"listen port", 6112}
                    })
    End Sub
    <TestMethod()>
    Public Sub LanDestroyGameTest()
        JarTest(Packets.LanDestroyGame,
                data:={20, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"game id", 20}
                    })
    End Sub
    <TestMethod()>
    Public Sub LanRefreshGameTest()
        JarTest(Packets.LanRefreshGame,
                data:={42, 0, 0, 0,
                       2, 0, 0, 0,
                       1, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"game id", 42},
                        {"num players", 2},
                        {"free slots", 1}
                    })
    End Sub
    <TestMethod()>
    Public Sub LanRequestGameTest()
        JarTest(Packets.LanRequestGame,
                data:={Asc("3"), Asc("r"), Asc("a"), Asc("w"),
                       20, 0, 0, 0,
                       0, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"product id", "war3"},
                        {"major version", 20},
                        {"unknown1", 0}
                    })
    End Sub
    <TestMethod()>
    Public Sub LeavingTest()
        JarTest(Packets.Leaving,
                data:={7, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"leave type", PlayerLeaveType.Lose}
                    })
    End Sub
    <TestMethod()>
    Public Sub LobbyStateTest()
        Dim slots = New List(Of Slot)()
        JarTest(Packets.LobbyState,
                data:={7, 0,
                       0,
                       13, 0, 0, 0,
                       1,
                       12},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"state size", 7},
                        {"slots", New List(Of Dictionary(Of InvariantString, Object))()},
                        {"time", 13},
                        {"layout style", 1},
                        {"num player slots", 12}
                    })
    End Sub
    <TestMethod()>
    Public Sub MapFileDataTest()
        JarTest(Packets.MapFileData,
                appendSafe:=False,
                requireAllData:=False,
                data:={2,
                       3,
                       0, 0, 0, 0,
                       128, 0, 0, 0,
                       32, 0, 0, 0,
                       1, 2, 3, 4},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player index", 2},
                        {"sending player index", 3},
                        {"unknown", 0},
                        {"file position", 128},
                        {"crc32", 32},
                        {"file data", New Byte() {1, 2, 3, 4}.AsReadableList}
                    })
    End Sub
    <TestMethod()>
    Public Sub MapFileDataProblemTest()
        JarTest(Packets.MapFileDataProblem,
                data:={2,
                       3,
                       0, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"sender index", 2},
                        {"receiver index", 3},
                        {"unknown", 0}
                    })
    End Sub
    <TestMethod()>
    Public Sub MapFileDataReceivedTest()
        JarTest(Packets.MapFileDataReceived,
                data:={2,
                       3,
                       0, 0, 0, 0,
                       128, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"sender index", 2},
                        {"receiver index", 3},
                        {"unknown", 0},
                        {"total downloaded", 128}
                    })
    End Sub
    <TestMethod()>
    Public Sub NewHostTest()
        JarTest(Packets.NewHost,
                data:={1},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player index", 1}
                    })
    End Sub
    <TestMethod()>
    Public Sub NonGameActionTest()
        JarTest(Packets.NonGameAction,
                data:={3, 1, 2, 3,
                       4,
                       32,
                       1, 0, 0, 0,
                       116, 101, 115, 116, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player indexes", New Byte() {1, 2, 3}.AsReadableList},
                        {"sending player", 4},
                        {"command type", NonGameAction.GameChat},
                        {"receiver type", ChatReceiverType.Allies},
                        {"message", "test"}
                    })
        JarTest(Packets.NonGameAction,
                data:={3, 1, 2, 3,
                       4,
                       16,
                       116, 101, 115, 116, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player indexes", New Byte() {1, 2, 3}.AsReadableList},
                        {"sending player", 4},
                        {"command type", NonGameAction.LobbyChat},
                        {"message", "test"}
                    })
        JarTest(Packets.NonGameAction,
                data:={3, 1, 2, 3,
                       4,
                       17,
                       1},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player indexes", New Byte() {1, 2, 3}.AsReadableList},
                        {"sending player", 4},
                        {"command type", NonGameAction.SetTeam},
                        {"new value", 1}
                    })
        JarTest(Packets.NonGameAction,
                data:={3, 1, 2, 3,
                       4,
                       20,
                       100},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player indexes", New Byte() {1, 2, 3}.AsReadableList},
                        {"sending player", 4},
                        {"command type", NonGameAction.SetHandicap},
                        {"new value", 100}
                    })
        JarTest(Packets.NonGameAction,
                data:={3, 1, 2, 3,
                       4,
                       18,
                       1},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player indexes", New Byte() {1, 2, 3}.AsReadableList},
                        {"sending player", 4},
                        {"command type", NonGameAction.SetColor},
                        {"new value", Slot.PlayerColor.Blue}
                    })
        JarTest(Packets.NonGameAction,
                data:={3, 1, 2, 3,
                       4,
                       19,
                       2},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiving player indexes", New Byte() {1, 2, 3}.AsReadableList},
                        {"sending player", 4},
                        {"command type", NonGameAction.SetRace},
                        {"new value", Slot.Races.Orc}
                    })
    End Sub
    <TestMethod()>
    Public Sub OtherPlayerJoinedTestTest()
        JarTest(Packets.OtherPlayerJoined,
                data:={27, 0, 0, 0,
                       1,
                       116, 101, 115, 116, 0,
                       1, 42,
                       2, 0, &H17, &HE0, 127, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                       2, 0, &H17, &HE1, 127, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"peer key", 27},
                        {"index", 1},
                        {"name", "test"},
                        {"unknown data", New Byte() {42}.AsReadableList},
                        {"external address", New Net.IPEndPoint(Net.IPAddress.Loopback, 6112)},
                        {"internal address", New Net.IPEndPoint(Net.IPAddress.Loopback, 6113)}
                    })
    End Sub
    <TestMethod()>
    Public Sub OtherPlayerLeftTest()
        JarTest(Packets.OtherPlayerLeft,
                data:={1,
                       7, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player index", 1},
                        {"leave type", PlayerLeaveType.Lose}
                    })
    End Sub
    <TestMethod()>
    Public Sub OtherPlayerReadyTest()
        JarTest(Packets.OtherPlayerReady,
                data:={3},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player index", 3}
                    })
    End Sub
    <TestMethod()>
    Public Sub PeerConnectionInfoTest()
        JarTest(Packets.PeerConnectionInfo,
                data:={7, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player bitflags", 7}
                    })
    End Sub
    <TestMethod()>
    Public Sub PeerKnockTest()
        JarTest(Packets.PeerKnock,
                data:={42, 0, 0, 0,
                       0, 0, 0, 0,
                       1,
                       0,
                       7, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"receiver peer key", 42},
                        {"unknown1", 0},
                        {"sender player id", 1},
                        {"unknown3", 0},
                        {"sender peer connection flags", 7}
                    })
    End Sub
    <TestMethod()>
    Public Sub PeerPingTest()
        JarTest(Packets.PeerPing,
                data:={&HEF, &HBE, &HAD, &HDE,
                       7, 0, 0, 0,
                       1, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"salt", &HDEADBEEFUI},
                        {"sender peer connection flags", 7},
                        {"unknown2", 1}
                    })
    End Sub
    <TestMethod()>
    Public Sub PeerPongTest()
        JarTest(Packets.PeerPong,
                data:={&HEF, &HBE, &HAD, &HDE},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"salt", &HDEADBEEFUI}
                    })
    End Sub
    <TestMethod()>
    Public Sub PingTest()
        JarTest(Packets.Ping,
                data:={&HEF, &HBE, &HAD, &HDE},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"salt", &HDEADBEEFUI}
                    })
    End Sub
    <TestMethod()>
    Public Sub PongTest()
        JarTest(Packets.Pong,
                data:={&HEF, &HBE, &HAD, &HDE},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"salt", &HDEADBEEFUI}
                    })
    End Sub
    <TestMethod()>
    Public Sub ReadyTest()
        JarTest(Packets.Ready,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub RejectEntryTest()
        JarTest(Packets.RejectEntry,
                data:={27, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"reason", RejectReason.IncorrectPassword}
                    })
    End Sub
    <TestMethod()>
    Public Sub RemovePlayerFromLagScreenTest()
        JarTest(Packets.RemovePlayerFromLagScreen,
                data:={4,
                       23, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"player index", 4},
                        {"marginal milliseconds used", 23}
                    })
    End Sub
    <TestMethod()>
    Public Sub RequestDropLaggersTest()
        JarTest(Packets.RequestDropLaggers,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub SetDownloadSourceTest()
        JarTest(Packets.SetDownloadSource,
                data:={0, 0, 0, 0,
                       2},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown", 0},
                        {"sending player index", 2}
                    })
    End Sub
    <TestMethod()>
    Public Sub SetUploadTargetTest()
        JarTest(Packets.SetUploadTarget,
                data:={0, 0, 0, 0,
                       3,
                       128, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"unknown1", 0},
                        {"receiving player index", 3},
                        {"starting file pos", 128}
                    })
    End Sub
    <TestMethod()>
    Public Sub ShowLagScreenTest()
        Dim lagger = New Dictionary(Of InvariantString, Object) From {
                             {"player index", 2},
                             {"initial milliseconds used", 25}
                         }
        JarTest(Packets.ShowLagScreen,
                data:={2,
                       2, 25, 0, 0, 0,
                       2, 25, 0, 0, 0},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"laggers", {lagger, lagger}}
                    })
    End Sub
    <TestMethod()>
    Public Sub StartCountdownTest()
        JarTest(Packets.StartCountdown,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub StartLoadingTest()
        JarTest(Packets.StartLoading,
                data:={},
                value:=New Dictionary(Of InvariantString, Object) From {})
    End Sub
    <TestMethod()>
    Public Sub TickTest()
        JarTest(Packets.Tick,
                requireAllData:=False,
                appendSafe:=False,
                data:={250, 0,
                       1, 2, 3, 4},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"time span", 250},
                        {"subpacket", New Byte() {1, 2, 3, 4}.AsReadableList}
                    })
    End Sub
    <TestMethod()>
    Public Sub TockTest()
        JarTest(Packets.Tock,
                data:={1, 2, 3, 4, 5},
                value:=New Dictionary(Of InvariantString, Object) From {
                        {"game state checksum", New Byte() {1, 2, 3, 4, 5}.AsReadableList}
                    })
    End Sub
End Class
