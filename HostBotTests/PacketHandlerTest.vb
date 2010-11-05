﻿Imports Strilbrary.Collections
Imports Strilbrary.Threading
Imports Strilbrary.Values
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Collections.Generic

<TestClass()>
Public Class PacketHandlerTest
    Private Class TestPacketHandler
        Inherits Tinker.PacketHandler(Of Byte)
        Public Sub New()
            MyBase.New("Test", Nothing)
        End Sub
        Protected Overrides Function ExtractKey(ByVal header As IReadableList(Of Byte)) As Byte
            If header(0) = 255 Then Throw New InvalidOperationException("Mock Exception")
            Return header(0)
        End Function
        Public Overrides ReadOnly Property HeaderSize As Integer
            Get
                Return 1
            End Get
        End Property
    End Class

    <TestMethod()>
    Public Sub ValueTest()
        Dim flag = 0UI
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(data) TaskedAction(Sub() flag = data.SubView(0, 4).touint32))
        Dim result = p.HandlePacket(New Byte() {1, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskSucceeds(result)
        Assert.IsTrue(flag = &H78563412)
    End Sub

    <TestMethod()>
    Public Sub SelectTest()
        Dim flag1 = True
        Dim flag2 = False
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(data) TaskedAction(Sub() flag1 = False))
        p.IncludeHandler(key:=2,
                     handler:=Function(data) TaskedAction(Sub() flag2 = True))
        Dim result = p.HandlePacket(New Byte() {2, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskSucceeds(result)
        Assert.IsTrue(flag1)
        Assert.IsTrue(flag2)
    End Sub

    <TestMethod()>
    Public Sub DoubleHandleTest()
        Dim flag1 = False
        Dim flag2 = False
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub() flag1 = True))
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub() flag2 = True))
        Dim result = p.HandlePacket(New Byte() {1, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskSucceeds(result)
        Assert.IsTrue(flag1)
        Assert.IsTrue(flag2)
    End Sub

    <TestMethod()>
    Public Sub HandleFailTest()
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle)
                                  Throw New InvalidOperationException("Mock Exception")
                              End Function)
        Dim result = p.HandlePacket(New Byte() {1, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskFails(result)
    End Sub

    <TestMethod()>
    Public Sub HandleFutureFailTest()
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub() Throw New InvalidOperationException("Mock Exception")))
        Dim result = p.HandlePacket(New Byte() {1, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskFails(result)
    End Sub

    <TestMethod()>
    Public Sub ExtractKeyFailTest()
        Dim flag = True
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub() flag = False))
        Dim result = p.HandlePacket(New Byte() {255, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskFails(result)
        Assert.IsTrue(flag)
    End Sub

    <TestMethod()>
    Public Sub MissingHandlerTest()
        Dim p = New TestPacketHandler()
        Dim result = p.HandlePacket(New Byte() {1, 2, 3, 4}.AsReadableList)
        WaitUntilTaskFails(result)
    End Sub

    <TestMethod()>
    Public Sub DisposedHandlerTest()
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub()
                                                            End Sub)
                     ).Dispose()
        Dim result = p.HandlePacket(New Byte() {1, 2, 3, 4}.AsReadableList)
        WaitUntilTaskFails(result)
    End Sub

    <TestMethod()>
    Public Sub SelectNonDisposedHandlerTest()
        Dim flag1 = False
        Dim flag2 = True
        Dim p = New TestPacketHandler()
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub() flag1 = True))
        p.IncludeHandler(key:=1,
                     handler:=Function(pickle) TaskedAction(Sub() flag2 = False)
                     ).Dispose()
        Dim result = p.HandlePacket(New Byte() {1, &H12, &H34, &H56, &H78}.AsReadableList)
        WaitUntilTaskSucceeds(result)
        Assert.IsTrue(flag1)
        Assert.IsTrue(flag2)
    End Sub
End Class
