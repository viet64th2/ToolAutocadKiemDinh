Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Public Class clsMatDung

    Public Shared Sub EraseAll()
        Dim doc As Document = Application.DocumentManager.CurrentDocument
        Dim db As Database = doc.Database

        Using tr As Transaction = db.TransactionManager.StartTransaction()
            Dim bt As BlockTable
            bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead)

            Dim btr As BlockTableRecord
            btr = tr.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            For Each entId As ObjectId In btr
                Dim ent As Entity = tr.GetObject(entId, OpenMode.ForWrite)
                ent.Erase(True)
            Next
            tr.Commit()
        End Using
    End Sub
    Public Shared Sub MatX_Z_CoGa(ChieuCaoDot As String,
                                   BeRongCot As String,
                                   vaom1 As Double,
                                   vaom2 As Double,
                                   listchieucaoday As List(Of Double),
                                   LoaiDot As List(Of String),
                                   CaoMong1 As Double,
                                   CaoMong2 As Double,
                                   Rongmong1 As Double,
                                   Rongmong2 As Double,
                                   CaoMong0 As Double,
                                   Rongmong0 As Double,
                                   loaimong As String,
                                   zM1 As Double,
                                   zM2 As Double,
                                   Vitri As String, listViTriGaChongXay As List(Of Integer), SoTangDay As Integer)
#Region "Khai báo"
        Dim ChieuCao As Double
        Dim RongCot As Double
        ChieuCao = Convert.ToDouble(ChieuCaoDot)
        RongCot = Convert.ToDouble(BeRongCot)
        Dim xM1 As Double = vaom1
        Dim xM2 As Double = vaom2
        Dim RongGa As Double = 3 * RongCot

        Dim SoModule As Integer
        Dim ChieuCaoModule As Double
        ChieuCao = ChieuCao * 1000
        ChieuCaoModule = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(0).Cells(2).Value) * 1000



        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
#End Region
#Region "Vẽ thân cột"
        Dim H As New List(Of Double)
        Dim Soroucout As Integer = frmTTC.BangChieuCaoDot.RowCount - 1
        Dim SoDot As Integer = frmTTC.BangChieuCaoDot.RowCount

        Dim CaoDoChanDot As New List(Of Double)
        CaoDoChanDot.Add(0)
        Dim TongCao As Double
        TongCao = 0
        For i = 0 To frmTTC.BangChieuCaoDot.Rows.Count - 1
            H.Add(Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        Next

        For i = 1 To SoDot
            CaoDoChanDot.Add(CaoDoChanDot(i - 1) + H(i - 1))
        Next

        For i = 0 To SoDot - 1
            Dim modul = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(2).Value) * 1000
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            VeThanCot(H(i), LoaiDot(i), CaoDoChanDot(i), RongCot, modul, ChieuCao)
            TongCao = TongCao + H(i)
        Next
        Lib_Drawing.CreateLine(New Point3d(-RongCot / 2, TongCao, 0), New Point3d(-RongCot / 2, ChieuCaoModule * 4 + TongCao, 0))
#End Region
#Region " Vẽ Loại Móng"
        VeMong(CaoMong1, CaoMong2, Rongmong1, Rongmong2, loaimong, xM1, zM1, xM2, zM2, CaoMong0, Rongmong0, tr)
#End Region
#Region "Tạo Dim"
        Dim ToaDoXDimTong As Double = -xM1 - TiLeChu * 20
        Dim ToaDoXDim As Double = ToaDoXDimTong + TiLeChu * 3
        Dim ToaDoXText As Double = ToaDoXDim + TiLeChu * 2
        '' Dim
        For i As Integer = 0 To SoDot - 1
            Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDim, CaoDoChanDot(i), 0), New Point3d(ToaDoXDim, CaoDoChanDot(i + 1), 0), New Point3d(ToaDoXDim - TiLeChu * 3, (CaoDoChanDot(i) + CaoDoChanDot(i + 1)) / 2 + 0, 0), 90, TiLeChu / 2)
        Next
        Dim z As Double
        If zM1 < zM2 Then
            z = zM1
        Else
            z = zM2
        End If
        Lib_Drawing.CreateRotatedDimension1(New Point3d(-xM1, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(-xM1 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(xM2, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(xM2 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDimTong, 0, 0), New Point3d(ToaDoXDimTong, TongCao, 0), New Point3d(ToaDoXDimTong - TiLeChu * 7, ChieuCao / 2, 0), 90, TiLeChu / 2)
#End Region
#Region "Tạo text Đốt"
        '' Text
        For i As Integer = 0 To SoDot - 1
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            Lib_Drawing.CreateNewMText(New Point3d(ToaDoXText, CaoDoChanDot(i + 1) - caodot / 2, 0), "Đốt " & i + 1, TiLeChu)
        Next
#End Region
#Region " Vẽ Dây co"
        ''Vẽ Day co
        For i = 0 To SoTangDay - 1
            VeDaycoTrai(listchieucaoday(i), Convert.ToDouble(RongCot), -xM1, zM1)
            VeDaycoPhai(listchieucaoday(i), Convert.ToDouble(-RongCot), xM1, zM2)
        Next
        'For i As Integer = 0 To listchieucaoday.Count - 1
        '    Lib_Drawing.CreateNewMText(New Point3d((xM1 + RongCot) / 2, (listchieucaoday(i) * 1000) / 2 + 0, 0), "T" & i + 1, TiLeChu)
        'Next
#End Region

    End Sub
    Public Shared Sub MatY_Z_CoGa(ChieuCaoDot As String,
                                   BeRongCot As String,
                                   vaom1 As Double,
                                   vaom2 As Double,
                                   listchieucaoday As List(Of Double),
                                   LoaiDot As List(Of String),
                                   CaoMong2 As Double,
                                   CaoMong3 As Double,
                                   Rongmong2 As Double,
                                   Rongmong3 As Double,
                                   CaoMong0 As Double,
                                   Rongmong0 As Double,
                                   loaimong As String,
                                   zM1 As Double,
                                   zM2 As Double,
                                   Vitri As String, listViTriGaChongXay As List(Of Integer), SoTangDay As Integer)
        'Dim ViTriCoGa As Integer = 2
        'Dim SoTangDay As Integer = 3
#Region "Khai báo"
        Dim ChieuCao As Double
        Dim RongCot As Double
        ChieuCao = Convert.ToDouble(ChieuCaoDot)
        RongCot = Convert.ToDouble(BeRongCot)
        Dim xM1 As Double = vaom1
        Dim xM2 As Double = vaom2
        Dim RongGa As Double = 3 * RongCot

        Dim SoModule As Integer
        Dim ChieuCaoModule As Double
        ChieuCao = ChieuCao * 1000

        ChieuCaoModule = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(0).Cells(2).Value) * 1000

        SoModule = ChieuCao / ChieuCaoModule

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
#End Region
#Region "Vẽ thân cột"
        Dim H As New List(Of Double)
        Dim Soroucout As Integer = frmTTC.BangChieuCaoDot.RowCount - 1
        Dim SoDot As Integer = frmTTC.BangChieuCaoDot.RowCount

        Dim CaoDoChanDot As New List(Of Double)
        CaoDoChanDot.Add(0)
        Dim TongCao As Double
        TongCao = 0
        For i = 0 To frmTTC.BangChieuCaoDot.Rows.Count - 1
            H.Add(Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        Next

        For i = 1 To SoDot
            CaoDoChanDot.Add(CaoDoChanDot(i - 1) + H(i - 1))
        Next

        For i = 0 To SoDot - 1
            Dim modul = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(2).Value) * 1000
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            VeThanCot(H(i), LoaiDot(i), CaoDoChanDot(i), RongCot, modul, ChieuCao)
            TongCao = TongCao + H(i)
        Next
        Lib_Drawing.CreateLine(New Point3d(-RongCot / 2, TongCao, 0), New Point3d(-RongCot / 2, ChieuCaoModule * 4 + TongCao, 0))
#End Region
#Region " Vẽ Loại Gá CX"
        For i = 0 To SoTangDay - 1
            For j = 0 To listViTriGaChongXay.Count - 1
                If i = listViTriGaChongXay(j) Then
                    'Ve ga chong xoay
                    Dim Toa_do_Gia(3) As Point2d
                    Toa_do_Gia(0) = New Point2d(RongGa, listchieucaoday(i) * 1000)
                    Toa_do_Gia(1) = New Point2d(RongCot / 2, listchieucaoday(i) * 1000 - ChieuCaoModule)
                    Toa_do_Gia(2) = New Point2d(-RongCot / 2, listchieucaoday(i) * 1000 - ChieuCaoModule)
                    Toa_do_Gia(3) = New Point2d(-RongGa, listchieucaoday(i) * 1000)
                    Lib_Drawing.CreateNewPolyline(Toa_do_Gia, True)
                End If
            Next
        Next
#End Region
#Region " Vẽ Loại Móng"
        VeMong(CaoMong2, CaoMong3, Rongmong2, Rongmong3, loaimong, xM1, zM1, xM2, zM2, CaoMong0, Rongmong0, tr)
#End Region
#Region "Tạo Dim"
        Dim ToaDoXDimTong As Double = -xM1 - TiLeChu * 20
        Dim ToaDoXDim As Double = ToaDoXDimTong + TiLeChu * 3
        Dim ToaDoXText As Double = ToaDoXDim + TiLeChu * 2
        '' Dim
        For i As Integer = 0 To SoDot - 1
            Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDim, CaoDoChanDot(i), 0), New Point3d(ToaDoXDim, CaoDoChanDot(i + 1), 0), New Point3d(ToaDoXDim - TiLeChu * 3, (CaoDoChanDot(i) + CaoDoChanDot(i + 1)) / 2 + 0, 0), 90, TiLeChu / 2)
        Next
        Dim z As Double
        If zM1 < zM2 Then
            z = zM1
        Else
            z = zM2
        End If
        Lib_Drawing.CreateRotatedDimension1(New Point3d(-xM1, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(-xM1 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(xM2, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(xM2 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDimTong, 0, 0), New Point3d(ToaDoXDimTong, TongCao, 0), New Point3d(ToaDoXDimTong - TiLeChu * 7, ChieuCao / 2, 0), 90, TiLeChu / 2)
#End Region
#Region "Tạo text Đốt"
        '' Text
        For i As Integer = 0 To SoDot - 1
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            Lib_Drawing.CreateNewMText(New Point3d(ToaDoXText, CaoDoChanDot(i + 1) - caodot / 2, 0), "Đốt " & i + 1, TiLeChu)
        Next
#End Region
#Region " Vẽ Dây co"
        For j = 0 To listViTriGaChongXay.Count - 1
            VeDaycoTrai(listchieucaoday(listViTriGaChongXay(j)), Convert.ToDouble(-RongGa * 2), -xM1, zM1)
            VeDaycoPhai(listchieucaoday(listViTriGaChongXay(j)), Convert.ToDouble(RongGa * 2), xM1, zM2)
        Next
        ''Vẽ Day co
        For i = 0 To SoTangDay - 1
            If KiemTra(i, listViTriGaChongXay) Then
            Else
                VeDaycoTrai(listchieucaoday(i), Convert.ToDouble(-RongCot), -xM1, zM1)
                VeDaycoPhai(listchieucaoday(i), Convert.ToDouble(RongCot), xM1, zM2)
            End If

        Next

#End Region

    End Sub
    Public Shared Sub MatX_Z_KoGa(ChieuCaoDot As String,
                                   BeRongCot As String,
                                   vaom1 As Double,
                                   vaom2 As Double,
                                   listchieucaoday As List(Of Double),
                                   LoaiDot As List(Of String),
                                   CaoMong1 As Double,
                                   CaoMong2 As Double,
                                   Rongmong1 As Double,
                                   Rongmong2 As Double,
                                   CaoMong0 As Double,
                                   Rongmong0 As Double,
                                   loaimong As String,
                                   zM1 As Double,
                                   zM2 As Double,
                                   Vitri As String, listViTriGaChongXay As List(Of Integer), SoTangDay As Integer)
#Region "Khai báo"

        Dim ChieuCao As Double
        Dim RongCot As Double
        ChieuCao = Convert.ToDouble(ChieuCaoDot)
        RongCot = Convert.ToDouble(BeRongCot)
        Dim xM1 As Double = vaom1
        Dim xM2 As Double = vaom2
        Dim RongGa As Double = 3 * RongCot
        Dim SoModule As Integer
        Dim ChieuCaoModule As Double
        ChieuCaoModule = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(0).Cells(2).Value) * 1000
        SoModule = ChieuCao / ChieuCaoModule
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
#End Region
#Region "Vẽ thân cột"
        Dim H As New List(Of Double)
        Dim Soroucout As Integer = frmTTC.BangChieuCaoDot.RowCount - 1
        Dim SoDot As Integer = frmTTC.BangChieuCaoDot.RowCount

        Dim CaoDoChanDot As New List(Of Double)
        CaoDoChanDot.Add(0)
        Dim TongCao As Double
        TongCao = 0
        For i = 0 To frmTTC.BangChieuCaoDot.Rows.Count - 1
            H.Add(Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        Next

        For i = 1 To SoDot
            CaoDoChanDot.Add(CaoDoChanDot(i - 1) + H(i - 1))
        Next

        For i = 0 To SoDot - 1
            Dim modul = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(2).Value) * 1000
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            VeThanCot(H(i), LoaiDot(i), CaoDoChanDot(i), RongCot, modul, ChieuCao)
            TongCao = TongCao + H(i)
        Next
        Lib_Drawing.CreateLine(New Point3d(-RongCot / 2, TongCao, 0), New Point3d(-RongCot / 2, ChieuCaoModule * 4 + TongCao, 0))
#End Region
        '#Region "Vẽ thân cột"
        '        Dim H As New List(Of Double)
        '        Dim Soroucout As Integer = frmTTC.BangChieuCaoDot.RowCount - 1
        '        Dim SoDot As Integer = frmTTC.BangChieuCaoDot.RowCount

        '        Dim CaoDoChanDot As New List(Of Double)
        '        CaoDoChanDot.Add(0)
        '        Dim TongCao As Double
        '        TongCao = 0
        '        For i = Soroucout To 0 Step -1
        '            H.Add(Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        '        Next

        '        For i = 1 To SoDot
        '            CaoDoChanDot(i) = CaoDoChanDot(i - 1) + H(i - 1)

        '        Next

        '        For i = 0 To SoDot - 1
        '            VeThanCot(H(i), LoaiDot(i), CaoDoChanDot(i), RongCot, ChieuCaoModule, ChieuCao)
        '            TongCao = TongCao + H(i)
        '        Next
        '        Lib_Drawing.CreateLine(New Point3d(-RongCot / 2, TongCao, 0), New Point3d(-RongCot / 2, ChieuCaoModule * 4 + TongCao, 0))
        '#End Region
#Region " Vẽ Loại Móng"
        VeMong(CaoMong1, CaoMong2, Rongmong1, Rongmong2, loaimong, xM1, zM1, xM2, zM2, CaoMong0, Rongmong0, tr)
#End Region
#Region "Tạo Dim"
        Dim ToaDoXDimTong As Double = -xM1 - TiLeChu * 20
        Dim ToaDoXDim As Double = ToaDoXDimTong + TiLeChu * 3
        Dim ToaDoXText As Double = ToaDoXDim + TiLeChu * 2
        '' Dim
        For i As Integer = 0 To SoDot - 1
            Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDim, CaoDoChanDot(i), 0), New Point3d(ToaDoXDim, CaoDoChanDot(i + 1), 0), New Point3d(ToaDoXDim - TiLeChu * 3, (CaoDoChanDot(i) + CaoDoChanDot(i + 1)) / 2 + 0, 0), 90, TiLeChu / 2)
        Next
        Dim z As Double
        If zM1 < zM2 Then
            z = zM1
        Else
            z = zM2
        End If
        Lib_Drawing.CreateRotatedDimension1(New Point3d(-xM1, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(-xM1 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(xM2, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(xM2 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDimTong, 0, 0), New Point3d(ToaDoXDimTong, TongCao, 0), New Point3d(ToaDoXDimTong - TiLeChu * 7, ChieuCao / 2, 0), 90, TiLeChu / 2)
#End Region
#Region "Tạo text Đốt"
        '' Text
        For i As Integer = 0 To SoDot - 1
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            Lib_Drawing.CreateNewMText(New Point3d(ToaDoXText, CaoDoChanDot(i + 1) - caodot / 2, 0), "Đốt " & i + 1, TiLeChu)
        Next
#End Region
#Region " Vẽ Dây co"
        ''Vẽ Day co
        For i = 0 To SoTangDay - 1
            VeDaycoTrai(listchieucaoday(i), Convert.ToDouble(RongCot), -xM1, zM1)
            VeDaycoPhai(listchieucaoday(i), Convert.ToDouble(-RongCot), xM1, zM2)
        Next

#End Region

    End Sub
    Public Shared Sub MatY_Z_KoGa(ChieuCaoDot As String,
                                   BeRongCot As String,
                                   vaom1 As Double,
                                   vaom2 As Double,
                                   listchieucaoday As List(Of Double),
                                   LoaiDot As List(Of String),
                                   CaoMong2 As Double,
                                   CaoMong3 As Double,
                                   Rongmong2 As Double,
                                   Rongmong3 As Double,
                                   CaoMong0 As Double,
                                   Rongmong0 As Double,
                                   loaimong As String,
                                   zM1 As Double,
                                   zM2 As Double,
                                   Vitri As String, listViTriGaChongXay As List(Of Integer), SoTangDay As Integer)
#Region "Khai báo"
        Dim ChieuCao As Double
        Dim RongCot As Double
        ChieuCao = Convert.ToDouble(ChieuCaoDot)
        RongCot = Convert.ToDouble(BeRongCot)
        Dim xM1 As Double = vaom1
        Dim xM2 As Double = vaom2
        Dim RongGa As Double = 3 * RongCot

        Dim SoModule As Integer
        Dim ChieuCaoModule As Double
        ChieuCao = ChieuCao * 1000
        ChieuCaoModule = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(0).Cells(2).Value) * 1000

        SoModule = ChieuCao / ChieuCaoModule

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
#End Region
#Region "Vẽ thân cột"
        Dim H As New List(Of Double)
        Dim Soroucout As Integer = frmTTC.BangChieuCaoDot.RowCount - 1
        Dim SoDot As Integer = frmTTC.BangChieuCaoDot.RowCount

        Dim CaoDoChanDot As New List(Of Double)
        CaoDoChanDot.Add(0)
        Dim TongCao As Double
        TongCao = 0
        For i = 0 To frmTTC.BangChieuCaoDot.Rows.Count - 1
            H.Add(Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        Next

        For i = 1 To SoDot
            CaoDoChanDot.Add(CaoDoChanDot(i - 1) + H(i - 1))
        Next

        For i = 0 To SoDot - 1
            Dim modul = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(2).Value) * 1000
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            VeThanCot(H(i), LoaiDot(i), CaoDoChanDot(i), RongCot, modul, ChieuCao)
            TongCao = TongCao + H(i)
        Next
        Lib_Drawing.CreateLine(New Point3d(-RongCot / 2, TongCao, 0), New Point3d(-RongCot / 2, ChieuCaoModule * 4 + TongCao, 0))
#End Region
#Region " Vẽ Loại Móng"
        VeMong(CaoMong2, CaoMong3, Rongmong2, Rongmong3, loaimong, xM1, zM1, xM2, zM2, CaoMong0, Rongmong0, tr)
#End Region
#Region "Tạo Dim"
        Dim ToaDoXDimTong As Double = -xM1 - TiLeChu * 20
        Dim ToaDoXDim As Double = ToaDoXDimTong + TiLeChu * 3
        Dim ToaDoXText As Double = ToaDoXDim + TiLeChu * 2
        '' Dim
        For i As Integer = 0 To SoDot - 1
            Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDim, CaoDoChanDot(i), 0), New Point3d(ToaDoXDim, CaoDoChanDot(i + 1), 0), New Point3d(ToaDoXDim - TiLeChu * 3, (CaoDoChanDot(i) + CaoDoChanDot(i + 1)) / 2 + 0, 0), 90, TiLeChu / 2)
        Next
        Dim z As Double
        If zM1 < zM2 Then
            z = zM1
        Else
            z = zM2
        End If
        Lib_Drawing.CreateRotatedDimension1(New Point3d(-xM1, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(-xM1 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(xM2, z - Rongmong0 * 4 + 0, 0), New Point3d(0, z - Rongmong0 * 4, 0), New Point3d(xM2 / 2, z - Rongmong0 * 4 - TiLeChu * 3 + 0, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDimTong, 0, 0), New Point3d(ToaDoXDimTong, TongCao, 0), New Point3d(ToaDoXDimTong - TiLeChu * 7, ChieuCao / 2, 0), 90, TiLeChu / 2)
#End Region
#Region "Tạo text Đốt"
        '' Text
        For i As Integer = 0 To SoDot - 1
            Dim caodot = Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000
            Lib_Drawing.CreateNewMText(New Point3d(ToaDoXText, CaoDoChanDot(i + 1) - caodot / 2, 0), "Đốt " & i + 1, TiLeChu)
        Next
#End Region
#Region " Vẽ Dây co"
        For j = 0 To listViTriGaChongXay.Count - 1
            VeDaycoTrai(listchieucaoday(listViTriGaChongXay(j)), Convert.ToDouble(-RongGa * 2), -xM1, zM1)
            VeDaycoPhai(listchieucaoday(listViTriGaChongXay(j)), Convert.ToDouble(RongGa * 2), xM1, zM1)
        Next
        ''Vẽ Day co
        For i = 0 To SoTangDay - 1
            If KiemTra(i, listViTriGaChongXay) Then
            Else
                VeDaycoTrai(listchieucaoday(i), Convert.ToDouble(-RongCot), -xM1, zM1)
                VeDaycoPhai(listchieucaoday(i), Convert.ToDouble(RongCot), xM1, zM2)
            End If
        Next

#End Region

    End Sub
    Public Shared Function KiemTra(int As Integer, list As List(Of Integer))
        Dim BienKiemtra As Boolean = False
        For i = 0 To list.Count - 1
            If int = list(i) Then
                BienKiemtra = True
                Exit For
            End If
        Next
        Return BienKiemtra
    End Function
    Public Shared Sub VeMong(CaoMong1 As Double, CaoMong2 As Double, RongMong1 As Double, RongMong2 As Double, loaimong As String, xM1 As Double, zM1 As Double, xM2 As Double, zM2 As Double, CaoMong0 As Double, Rongmong0 As Double, tr As Transaction)
        'Dim a As Double = CaoMong / 5
        'Dim b As Double = RongMong / 5
        Dim xloplot As Double = 100
        Dim zloplot As Double = 100
        If loaimong = "L2" Then
            Dim id_mong1 As ObjectId 'Vẽ móng 1
            Dim id_mong12 As ObjectId 'Vẽ chi tiết móng 1
            Dim id_mong13 As ObjectId 'Vẽ lớp lót bê tông móng 1
            Dim id_mong2 As ObjectId 'Vẽ móng 2
            Dim id_mong22 As ObjectId 'Vẽ chi tiết móng 2
            Dim id_mong23 As ObjectId 'Vẽ lớp lót bê tông móng 2
            'móng 1
            Dim Toa_Do_M1(5) As Point2d ' Vẽ móng
            Toa_Do_M1(0) = New Point2d(-xM1 - RongMong1 / 2, zM1)
            Toa_Do_M1(1) = New Point2d(-xM1 + RongMong1 / 2, zM1)
            Toa_Do_M1(2) = New Point2d(-xM1 + RongMong1 / 2, -RongMong1 * 3)
            Toa_Do_M1(3) = New Point2d(-xM1 - RongMong1 / 2 + RongMong1 * 3, -RongMong1 * 3)
            Toa_Do_M1(4) = New Point2d(-xM1 - RongMong1 / 2 + RongMong1 * 3, -RongMong1 * 4)
            Toa_Do_M1(5) = New Point2d(-xM1 - RongMong1 / 2, -RongMong1 * 4)
            id_mong1 = Lib_Drawing.CreateNewPolyline(Toa_Do_M1, True)
            Dim Toa_Do_M12(4) As Point2d 'Vẽ chi tiết móng
            Toa_Do_M12(0) = New Point2d(-xM1 - RongMong1 / 2, -RongMong1 * 3)
            Toa_Do_M12(1) = New Point2d(-xM1, -RongMong1 * 3)
            Toa_Do_M12(2) = New Point2d(-xM1, zM1 - CaoMong1)
            Toa_Do_M12(3) = New Point2d(-xM1 - RongMong1 / 2 + RongMong1 * 3, zM1 - CaoMong1)
            Toa_Do_M12(4) = New Point2d(-xM1 - RongMong1 / 2 + RongMong1 * 3, -RongMong1 * 3)
            id_mong12 = Lib_Drawing.CreateNewPolyline(Toa_Do_M12, False)
            Dim Toa_Do_M13(3) As Point2d ' Vẽ lớp lót bê tông
            Toa_Do_M13(0) = New Point2d(-xM1 - RongMong1 / 2 - 100, -RongMong1 * 4)
            Toa_Do_M13(1) = New Point2d(-xM1 - RongMong1 / 2 + RongMong1 * 3 + 100, -RongMong1 * 4)
            Toa_Do_M13(2) = New Point2d(-xM1 - RongMong1 / 2 + RongMong1 * 3 + 100, -RongMong1 * 4 - 100)
            Toa_Do_M13(3) = New Point2d(-xM1 - RongMong1 / 2 - 100, -RongMong1 * 4 - 100)
            id_mong13 = Lib_Drawing.CreateNewPolyline(Toa_Do_M13, True)
            'móng 2
            Dim Toa_Do_M2(5) As Point2d 'Vẽ móng
            Toa_Do_M2(0) = New Point2d(xM2 + RongMong2 / 2, zM2)
            Toa_Do_M2(1) = New Point2d(xM2 - RongMong2 / 2, zM2)
            Toa_Do_M2(2) = New Point2d(xM2 - RongMong2 / 2, -RongMong2 * 3)
            Toa_Do_M2(3) = New Point2d(xM2 + RongMong2 / 2 - RongMong2 * 3, -RongMong2 * 3)
            Toa_Do_M2(4) = New Point2d(xM2 + RongMong2 / 2 - RongMong2 * 3, -RongMong2 * 4)
            Toa_Do_M2(5) = New Point2d(xM2 + RongMong2 / 2, -RongMong2 * 4)
            id_mong2 = Lib_Drawing.CreateNewPolyline(Toa_Do_M2, True)
            Dim Toa_Do_M22(4) As Point2d 'Vẽ chi tiết móng
            Toa_Do_M22(0) = New Point2d(xM2 + RongMong2 / 2, -RongMong2 * 3)
            Toa_Do_M22(1) = New Point2d(xM2, -RongMong2 * 3)
            Toa_Do_M22(2) = New Point2d(xM2, zM2 - CaoMong2)
            Toa_Do_M22(3) = New Point2d(xM2 + RongMong2 / 2 - RongMong2 * 3, zM2 - CaoMong2)
            Toa_Do_M22(4) = New Point2d(xM2 + RongMong2 / 2 - RongMong2 * 3, -RongMong2 * 3)
            id_mong22 = Lib_Drawing.CreateNewPolyline(Toa_Do_M22, False)
            Dim Toa_Do_M23(3) As Point2d ' Vẽ lớp lót bê tông
            Toa_Do_M23(0) = New Point2d(xM2 + RongMong2 / 2 + 100, -RongMong2 * 4)
            Toa_Do_M23(1) = New Point2d(xM2 + RongMong2 / 2 - RongMong2 * 3 - 100, -RongMong2 * 4)
            Toa_Do_M23(2) = New Point2d(xM2 + RongMong2 / 2 - RongMong2 * 3 - 100, -RongMong2 * 4 - 100)
            Toa_Do_M23(3) = New Point2d(xM2 + RongMong2 / 2 + 100, -RongMong2 * 4 - 100)
            id_mong23 = Lib_Drawing.CreateNewPolyline(Toa_Do_M23, True)
            clsMatDung.VeDatMongCoL2(New Point3d(-xM1, zM1, 0), CaoMong1, RongMong1)
            clsMatDung.VeDatMongCoL2(New Point3d(xM2, zM2, 0), CaoMong2, RongMong2)
            'VeCaoDo(listCaoDo, 2, 3, z1, z3, rongMB / 2, rongMB / 2, b_hmong, b_hmong, 0, TiLeChu * 2)
        ElseIf loaimong = "L1" Then
            Dim id_mong1 As ObjectId 'Vẽ móng 1
            Dim id_mong12 As ObjectId ' Vẽ chi tiết trong móng 1
            Dim id_mong13 As ObjectId ' Vẽ lớp lót bê tông móng 1
            Dim id_mong2 As ObjectId 'Vẽ móng 2
            Dim id_mong22 As ObjectId 'Vẽ chi tiết trong móng 2
            Dim id_mong23 As ObjectId ' Vẽ Lớp lót bê tông móng 2
            'móng 1
            Dim Toa_Do_M1(4) As Point2d ' Vẽ móng      
            Toa_Do_M1(0) = New Point2d(-xM1 - RongMong1 / 2, zM1)
            Toa_Do_M1(1) = New Point2d(-xM1 + RongMong1 / 2, zM1)
            Toa_Do_M1(2) = New Point2d(-xM1 + RongMong1 / 2, -RongMong1 * 4)
            Toa_Do_M1(3) = New Point2d(-xM1 + RongMong1 / 2 - RongMong1 * 3, -RongMong1 * 4)
            Toa_Do_M1(4) = New Point2d(-xM1 + RongMong1 / 2 - RongMong1 * 3, -RongMong1 * 3.5)
            id_mong1 = Lib_Drawing.CreateNewPolyline(Toa_Do_M1, True)
            Dim Toa_Do_M12(3) As Point2d ' Vẽ  chi tiết trong móng
            Toa_Do_M12(0) = New Point2d(-xM1 + RongMong1 / 2 - RongMong1 * 3, -RongMong1 * 3.5)
            Toa_Do_M12(1) = New Point2d(-xM1, -RongMong1 * 3.5)
            Toa_Do_M12(2) = New Point2d(-xM1, -RongMong1 / 2)
            Toa_Do_M12(3) = New Point2d(-xM1 + RongMong1 / 2, -RongMong1 / 2)
            id_mong12 = Lib_Drawing.CreateNewPolyline(Toa_Do_M12, False)
            Dim Toa_Do_M13(3) As Point2d ' Vẽ  lớp lót bê tông
            Toa_Do_M13(0) = New Point2d(-xM1 + RongMong1 / 2 - RongMong1 * 3 - 100, -RongMong1 * 4)
            Toa_Do_M13(1) = New Point2d(-xM1 + RongMong1 / 2 + 100, -RongMong1 * 4)
            Toa_Do_M13(2) = New Point2d(-xM1 + RongMong1 / 2 + 100, -RongMong1 * 4 - 100)
            Toa_Do_M13(3) = New Point2d(-xM1 + RongMong1 / 2 - RongMong1 * 3 - 100, -RongMong1 * 4 - 100)
            id_mong13 = Lib_Drawing.CreateNewPolyline(Toa_Do_M13, True)
            'móng 2
            Dim Toa_Do_M2(4) As Point2d
            Toa_Do_M2(0) = New Point2d(xM2 + RongMong2 / 2, zM2)
            Toa_Do_M2(1) = New Point2d(xM2 - RongMong2 / 2, zM2)
            Toa_Do_M2(2) = New Point2d(xM2 - RongMong2 / 2, -RongMong2 * 4)
            Toa_Do_M2(3) = New Point2d(xM2 - RongMong2 / 2 + RongMong2 * 3, -RongMong2 * 4)
            Toa_Do_M2(4) = New Point2d(xM2 - RongMong2 / 2 + RongMong2 * 3, -RongMong2 * 3.5)
            id_mong2 = Lib_Drawing.CreateNewPolyline(Toa_Do_M2, True)
            Dim Toa_Do_M22(3) As Point2d ' Vẽ  chi tiết trong móng
            Toa_Do_M22(0) = New Point2d(xM2 - RongMong2 / 2 + RongMong2 * 3, -RongMong2 * 3.5)
            Toa_Do_M22(1) = New Point2d(xM2, -RongMong2 * 3.5)
            Toa_Do_M22(2) = New Point2d(xM2, -RongMong2 / 2)
            Toa_Do_M22(3) = New Point2d(xM2 - RongMong2 / 2, -RongMong2 / 2)
            id_mong22 = Lib_Drawing.CreateNewPolyline(Toa_Do_M22, False)
            Dim Toa_Do_M23(3) As Point2d ' Vẽ  lóp lót bê tông
            Toa_Do_M23(0) = New Point2d(xM2 - RongMong2 / 2 + RongMong2 * 3 + 100, -RongMong2 * 4)
            Toa_Do_M23(1) = New Point2d(xM2 - RongMong2 / 2 - 100, -RongMong2 * 4)
            Toa_Do_M23(2) = New Point2d(xM2 - RongMong2 / 2 - 100, -RongMong2 * 4 - 100)
            Toa_Do_M23(3) = New Point2d(xM2 - RongMong2 / 2 + RongMong2 * 3 + 100, -RongMong2 * 4 - 100)
            id_mong23 = Lib_Drawing.CreateNewPolyline(Toa_Do_M23, True)
            'Vẽ mặt đất cho móng co
            clsMatDung.VeDatMongCoL1(New Point3d(-xM1, zM1, 0), CaoMong1, RongMong1)
            clsMatDung.VeDatMongCoL1(New Point3d(xM2, zM2, 0), CaoMong2, RongMong2)
        ElseIf loaimong = "L3" Then
            Dim id_mong1 As ObjectId
            Dim id_mong2 As ObjectId
            'móng 1
            Dim Toa_Do_M1(3) As Point2d
            Toa_Do_M1(0) = New Point2d(-xM1 + RongMong1 / 2, -CaoMong1 + zM1)
            Toa_Do_M1(1) = New Point2d(-xM1 + RongMong1 / 2, zM1)
            Toa_Do_M1(2) = New Point2d(-xM1 - RongMong1 / 2, zM1)
            Toa_Do_M1(3) = New Point2d(-xM1 - RongMong1 / 2, -CaoMong1 + zM1)
            id_mong1 = Lib_Drawing.CreateNewPolyline(Toa_Do_M1, True)
            'móng 2
            Dim Toa_Do_M2(3) As Point2d
            Toa_Do_M2(0) = New Point2d(xM2 + RongMong2 / 2, -CaoMong2 + zM2)
            Toa_Do_M2(1) = New Point2d(xM2 + RongMong2 / 2, zM2)
            Toa_Do_M2(2) = New Point2d(xM2 - RongMong2 / 2, zM2)
            Toa_Do_M2(3) = New Point2d(xM2 - RongMong2 / 2, -CaoMong2 + zM2)
            id_mong2 = Lib_Drawing.CreateNewPolyline(Toa_Do_M2, True)
        End If
        VeCaoDoMong(zM2, zM2, xM2)
        VeCaoDoMong(zM1, zM1, -xM1)
#Region "Vẽ Móng M0"
        'Móng 0
        Dim c As Double = CaoMong0
        Dim d As Double = Rongmong0
        If ThongTinChung.ViTriDat = "Dưới đất" Then
            Dim Toa_Do_M0(7) As Point2d
            Toa_Do_M0(0) = New Point2d(-d / 2, 0)
            Toa_Do_M0(1) = New Point2d(d / 2, 0)
            Toa_Do_M0(2) = New Point2d(d / 2, -d * 1.5)
            Toa_Do_M0(3) = New Point2d(d / 2 + d, -d * 1.5 - (Math.Tan(Math.PI / 6) * d))
            Toa_Do_M0(4) = New Point2d(d / 2 + d, -d * 1.5 - (Math.Tan(Math.PI / 6) * d) - d / 2)
            Toa_Do_M0(5) = New Point2d(-d / 2 - d, -d * 1.5 - (Math.Tan(Math.PI / 6) * d) - d / 2)
            Toa_Do_M0(6) = New Point2d(-d / 2 - d, -d * 1.5 - (Math.Tan(Math.PI / 6) * d))
            Toa_Do_M0(7) = New Point2d(-d / 2, -d * 1.5)
            Dim id_mongchinh As ObjectId
            id_mongchinh = Lib_Drawing.CreateNewPolyline(Toa_Do_M0, True)
            Dim Toa_Do_Lot(3) As Point2d
            Toa_Do_Lot(0) = New Point2d(-d / 2 - d - 100, -d * 1.5 - (Math.Tan(Math.PI / 6) * d) - d / 2)
            Toa_Do_Lot(1) = New Point2d(d / 2 + d + 100, -d * 1.5 - (Math.Tan(Math.PI / 6) * d) - d / 2)
            Toa_Do_Lot(2) = New Point2d(d / 2 + d + 100, -d * 1.5 - (Math.Tan(Math.PI / 6) * d) - d / 2 - 100)
            Toa_Do_Lot(3) = New Point2d(-d / 2 - d - 100, -d * 1.5 - (Math.Tan(Math.PI / 6) * d) - d / 2 - 100)
            Dim id_loplot As ObjectId
            id_loplot = Lib_Drawing.CreateNewPolyline(Toa_Do_Lot, True)
            Dim mongchinh As Polyline
            Dim loplotbetong As Polyline
            'Mặt đất
            clsMatDung.VeDatMong0(New Point3d(0, 0, 0), d, c)
            'Lib_Drawing.CreateLine(New Point3d(-xM1 - 10000, -c, 0), New Point3d(xM2 + 10000, -c, 0))
            'Layer
            Using tr
                mongchinh = tr.GetObject(id_mongchinh, OpenMode.ForWrite)
                mongchinh.Layer = "8"
                loplotbetong = tr.GetObject(id_loplot, OpenMode.ForWrite)
                loplotbetong.Layer = "8"
                tr.Commit()
            End Using
        Else
            Dim Toa_Do_M0(3) As Point2d
            Toa_Do_M0(0) = New Point2d(-d / 2, 0 + c)
            Toa_Do_M0(1) = New Point2d(d / 2, 0 + c)
            Toa_Do_M0(2) = New Point2d(d / 2, -d + c)
            Toa_Do_M0(3) = New Point2d(-d / 2, -d + c)
            Dim id_mongchinh As ObjectId
            id_mongchinh = Lib_Drawing.CreateNewPolyline(Toa_Do_M0, True)
            Dim mongchinh As Polyline
            'Mặt đất
            'Lib_Drawing.CreateLine(New Point3d(-xM1 - 10000, -c, 0), New Point3d(xM2 + 10000, -c, 0))
            'Layer
            Using tr
                mongchinh = tr.GetObject(id_mongchinh, OpenMode.ForWrite)
                mongchinh.Layer = "8"
                tr.Commit()
            End Using
        End If
#End Region
    End Sub
    Private Shared Sub VeThanCot(ChieuCaoDot As Double, LoaiDot As String, CaoDoChanDot As Double, RongCot As Double, ChieuCaoModule As Double, ChieuCao As Double)
        Dim SoModule As Integer
        SoModule = ChieuCaoDot / ChieuCaoModule
        If LoaiDot = "DLM" Then
            Ve_DLM(SoModule, RongCot, ChieuCaoModule, CaoDoChanDot)
        End If
        If LoaiDot = "DHM" Then
            Ve_DMH(SoModule, RongCot, ChieuCaoModule, CaoDoChanDot)
        End If
        If LoaiDot = "DMH" Then
            Ve_DMH(SoModule, RongCot, ChieuCaoModule, CaoDoChanDot)
        End If
        If LoaiDot = "DM" Then
            Ve_DM(SoModule, RongCot, ChieuCaoModule, ChieuCao, CaoDoChanDot)
        End If
        If LoaiDot = "DM_LEFT" Then
            Ve_DM_LEFT(SoModule, RongCot, ChieuCaoModule, ChieuCao, CaoDoChanDot)
        End If
        If LoaiDot = "DRM" Then
            Ve_DRM(SoModule, RongCot, ChieuCaoModule, CaoDoChanDot)
        End If


    End Sub
    Private Shared Sub VeDaycoTrai(CaoDoDay As Double, RongCot As Double, XM As Double, ZM As Double)
        Dim id_day As ObjectId
        id_day = Lib_Drawing.CreateLine(New Point3d(XM, ZM, 0), New Point3d(RongCot / 2, CaoDoDay * 1000, 0))
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Dim goc As Double = clsMatDung.TinhGocDuongThang(id_day)
        ' MsgBox((goc * 180) / Math.PI)
        clsMatDung.TaoTextTrenDayCo(id_day, goc, "kaitomajickid", CaoDoDay)
        Dim dayco As Line
        Using tr
            dayco = tr.GetObject(id_day, OpenMode.ForWrite)
            dayco.Layer = "2"
            tr.Commit()
        End Using
    End Sub
    Private Shared Sub VeDaycoPhai(CaoDoDay As Double, RongCot As Double, XM As Double, ZM As Double)
        Dim id_day As ObjectId
        id_day = Lib_Drawing.CreateLine(New Point3d(XM, ZM, 0), New Point3d(RongCot / 2, CaoDoDay * 1000, 0))
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim goc As Double = clsMatDung.TinhGocDuongThang(id_day)
        clsMatDung.TaoTextTrenDayCo(id_day, goc, "kaitomajickid", CaoDoDay)
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Dim dayco As Line
        Using tr
            dayco = tr.GetObject(id_day, OpenMode.ForWrite)
            dayco.Layer = "2"
            tr.Commit()
        End Using
    End Sub
    Public Shared Sub VeCaoDoMong(b_CaoDoMong As Double, z1 As Double, xmong1 As Double)
        'CaoDomong
        '''''''''
        Dim CaoDoMong_M0 As Double = Convert.ToDouble(frmTTC.txtCaoDoMong.Text) * 1000
        If z1 <> 0 Then
            If b_CaoDoMong = 0 Then
                Lib_Drawing.insertBlock(New Point3d(xmong1 + 1000, z1, 0), "ct", TiLeChu, "%%p0.00")
            Else
                Dim Caodomong1 As String
                Caodomong1 = Format((b_CaoDoMong + CaoDoMong_M0) / 1000, "0.00")
                'MsgBox(Caodomong1)
                If z1 > 0 Then
                    Lib_Drawing.insertBlock(New Point3d(xmong1 + 1000, z1, 0), "ct", TiLeChu, "+" & Caodomong1)

                Else
                    Lib_Drawing.insertBlock(New Point3d(xmong1 + 1000, z1, 0), "ct", TiLeChu, Caodomong1)

                End If
            End If
        End If
        ''''''''''''''
    End Sub
    Public Shared Sub VeCaoDoDot(XM1 As Double, tile As Double)
        Dim H As New List(Of Double)
        Dim CaoDoChanDot As New List(Of Double)

        Dim ToaDoXDimTong As Double = -XM1 - TiLeChu * 20
        Dim ToaDoXDim As Double = ToaDoXDimTong + TiLeChu * 3
        Dim SoDot As Integer = frmTTC.BangChieuCaoDot.RowCount
        CaoDoChanDot.Add(0)

        For i = 0 To frmTTC.BangChieuCaoDot.Rows.Count - 1
            H.Add(Convert.ToDouble(frmTTC.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        Next

        For i = 1 To SoDot
            CaoDoChanDot.Add(CaoDoChanDot(i - 1) + H(i - 1))
        Next

        For i As Integer = 0 To SoDot - 1
            Dim CaoDo As String
            CaoDo = Format(CaoDoChanDot(i + 1) / 1000, "00.00")
            Lib_Drawing.insertBlock(New Point3d(ToaDoXDim, CaoDoChanDot(i + 1), 0), "ct", tile / 2, "+" & CaoDo)
        Next

        Dim ChieuCaoCot = Format((ThongTinChung.ChieuCao * 1000 + b_CaoDoMong) / 1000, "00.00")
        Lib_Drawing.insertBlock(New Point3d(ToaDoXDim, ChieuCaoCot * 1000, 0), "ct", tile / 2, "+" & ChieuCaoCot)


    End Sub
    Public Shared Sub VeCaoDo(listCaoDo As IList(Of Double), MongSo1 As Double, MongSo2 As Double, z1 As Double, z2 As Double, xmong1 As Double, xmong2 As Double, hmong1 As Double, hmong2 As Double, hmongchinh As Double, tile As Double)

        Dim b_CaoDoMong1, b_CaoDoMong2 As Double
        b_CaoDoMong1 = Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(MongSo1 - 1).Cells(3).Value) * 1000
        b_CaoDoMong2 = Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(MongSo2 - 1).Cells(3).Value) * 1000
        b_CaoDoMong = Convert.ToDouble(frmTTC.txtCaoDoMong.Text) * 1000
        For i As Integer = 0 To frmTTC.dgvCaoDoDayCo.RowCount - 1
            Dim CaoDo As String
            CaoDo = Format((listCaoDo(i) * 1000 + b_CaoDoMong) / 1000, "00.00")
            Lib_Drawing.insertBlock(New Point3d(2000, listCaoDo(i) * 1000, 0), "ct", tile / 2, "+" & CaoDo)
        Next
        Dim ChieuCaoCot = Format((ThongTinChung.ChieuCao * 1000 + b_CaoDoMong) / 1000, "00.00")
        Lib_Drawing.insertBlock(New Point3d(2000, ChieuCaoCot * 1000, 0), "ct", tile / 2, "+" & ChieuCaoCot)

        If b_CaoDoMong = 0 Then
            Lib_Drawing.insertBlock(New Point3d(2000, -hmongchinh, 0), "ct", tile / 2, "%%p0.00")
        Else
            Dim CaoDo As String
            CaoDo = Format(b_CaoDoMong / 1000, "00.00")
            Lib_Drawing.insertBlock(New Point3d(2000, -hmongchinh, 0), "ct", tile / 2, "+" & CaoDo)
        End If
        ''CaoDomong
        ''''''''''
        'If z1 <> 0 Then
        '    If b_CaoDoMong1 = 0 Then
        '        Lib_Drawing.insertBlock(New Point3d(-xmong1, z1 - hmong1, 0), "ct", tile / 2, "%%p0.000")
        '    Else
        '        Dim Caodomong1 As String
        '        Caodomong1 = Format(b_CaoDoMong + b_CaoDoMong1, "##,#")
        '        Lib_Drawing.insertBlock(New Point3d(-xmong1, z1 - hmong1, 0), "ct", tile / 2, "+" & Caodomong1)
        '    End If

        '    If b_CaoDoMong = 0 Then
        '        Lib_Drawing.insertBlock(New Point3d(xmong2, z2 - hmong2, 0), "ct", tile / 2, "%%p0.000")
        '    Else
        '        Dim Caodomong2 As String
        '        Caodomong2 = Format(b_CaoDoMong + b_CaoDoMong2, "##,#")
        '        Lib_Drawing.insertBlock(New Point3d(xmong2, z2 - hmong2, 0), "ct", tile / 2, "+" & Caodomong2)
        '    End If
        'End If
        '''''''''''''''
    End Sub
    Public Shared Sub Ve_DMH(SoModule As Double, RongCot As Double, ChieuCaoModule As Double, CaoDoChanDot As Double)
        For i As Integer = 0 To SoModule - 1
            Dim Toa_Do_Cot(3) As Point2d
            Toa_Do_Cot(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Toa_Do_Cot(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Toa_Do_Cot(2) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Toa_Do_Cot(3) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Lib_Drawing.CreateNewPolyline1(Toa_Do_Cot, False)
            If i Mod 2 = 0 Then
                Dim Toa_do_cheo1(1) As Point2d
                Toa_do_cheo1(0) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
                Toa_do_cheo1(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
                Lib_Drawing.CreateNewPolyline1(Toa_do_cheo1, False)
            Else
                Dim Toa_do_cheo2(1) As Point2d
                Toa_do_cheo2(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
                Toa_do_cheo2(1) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
                Lib_Drawing.CreateNewPolyline1(Toa_do_cheo2, False)
            End If
        Next
    End Sub
    Public Shared Sub Ve_DRM(SoModule As Double, RongCot As Double, ChieuCaoModule As Double, CaoDoChanDot As Double)
        For i As Integer = 0 To SoModule - 1
            Dim Toa_Do_Cot(3) As Point2d
            Toa_Do_Cot(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Toa_Do_Cot(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Toa_Do_Cot(2) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Toa_Do_Cot(3) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Lib_Drawing.CreateNewPolyline1(Toa_Do_Cot, True)
            Dim Toa_do_cheo1(1) As Point2d
            Toa_do_cheo1(0) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Toa_do_cheo1(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Lib_Drawing.CreateNewPolyline1(Toa_do_cheo1, False)
        Next
    End Sub
    Public Shared Sub Ve_DLM(SoModule As Double, RongCot As Double, ChieuCaoModule As Double, CaoDoChanDot As Double)

        For i As Integer = 0 To SoModule - 1
            Dim Toa_Do_Cot(3) As Point2d
            Toa_Do_Cot(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Toa_Do_Cot(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Toa_Do_Cot(2) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Toa_Do_Cot(3) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Lib_Drawing.CreateNewPolyline1(Toa_Do_Cot, True)
            Dim Toa_do_cheo2(1) As Point2d
            Toa_do_cheo2(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
            Toa_do_cheo2(1) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
            Lib_Drawing.CreateNewPolyline1(Toa_do_cheo2, False)
        Next
    End Sub
    Public Shared Sub Ve_DM_LEFT(SoModule As Double, RongCot As Double, ChieuCaoModule As Double, ChieuCao As Double, CaoDoChanDot As Double)
        Dim Toa_do_trai(1) As Point2d
        Toa_do_trai(0) = New Point2d(-RongCot / 2, 0)
        Toa_do_trai(1) = New Point2d(-RongCot / 2, ChieuCao + 0)
        Lib_Drawing.CreateNewPolyline1(Toa_do_trai, False)

        Dim Toa_do_phai(1) As Point2d
        Toa_do_phai(0) = New Point2d(RongCot / 2, 0)
        Toa_do_phai(1) = New Point2d(RongCot / 2, ChieuCao + 0)
        Lib_Drawing.CreateNewPolyline1(Toa_do_phai, False)

        Dim Toa_do_tren(1) As Point2d
        Toa_do_tren(0) = New Point2d(-RongCot / 2, ChieuCao + 0)
        Toa_do_tren(1) = New Point2d(RongCot / 2, ChieuCao + 0)
        Lib_Drawing.CreateNewPolyline1(Toa_do_tren, False)
        For i As Integer = 0 To SoModule - 1
            If i Mod 2 = 0 Then
                Dim Toa_do_cheo1(1) As Point2d
                Toa_do_cheo1(0) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
                Toa_do_cheo1(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
                Lib_Drawing.CreateNewPolyline1(Toa_do_cheo1, False)
            Else
                Dim Toa_do_cheo2(1) As Point2d
                Toa_do_cheo2(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
                Toa_do_cheo2(1) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
                Lib_Drawing.CreateNewPolyline1(Toa_do_cheo2, False)
            End If
        Next
    End Sub
    Public Shared Sub Ve_DM(SoModule As Double, RongCot As Double, ChieuCaoModule As Double, ChieuCao As Double, CaoDoChanDot As Double)
        Dim Toa_do_trai(1) As Point2d
        Toa_do_trai(0) = New Point2d(-RongCot / 2, 0)
        Toa_do_trai(1) = New Point2d(-RongCot / 2, ChieuCao + 0)
        Lib_Drawing.CreateNewPolyline1(Toa_do_trai, False)

        Dim Toa_do_phai(1) As Point2d
        Toa_do_phai(0) = New Point2d(RongCot / 2, 0)
        Toa_do_phai(1) = New Point2d(RongCot / 2, ChieuCao + 0)
        Lib_Drawing.CreateNewPolyline1(Toa_do_phai, False)

        Dim Toa_do_tren(1) As Point2d
        Toa_do_tren(0) = New Point2d(-RongCot / 2, ChieuCao + 0)
        Toa_do_tren(1) = New Point2d(RongCot / 2, ChieuCao + 0)
        Lib_Drawing.CreateNewPolyline1(Toa_do_tren, False)
        For i As Integer = 0 To SoModule - 1
            If i Mod 2 = 0 Then
                Dim Toa_do_cheo2(1) As Point2d
                Toa_do_cheo2(0) = New Point2d(-RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
                Toa_do_cheo2(1) = New Point2d(RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
                Lib_Drawing.CreateNewPolyline1(Toa_do_cheo2, False)
            Else
                Dim Toa_do_cheo1(1) As Point2d
                Toa_do_cheo1(0) = New Point2d(RongCot / 2, ChieuCaoModule * i + CaoDoChanDot)
                Toa_do_cheo1(1) = New Point2d(-RongCot / 2, ChieuCaoModule * (i + 1) + CaoDoChanDot)
                Lib_Drawing.CreateNewPolyline1(Toa_do_cheo1, False)
            End If
        Next
    End Sub
    Public Shared Function TinhGocDuongThang(id As ObjectId)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database
        Dim goc As Double
        Dim line As New Line
        Dim Diem1 As New Point3d
        Dim Diem2 As New Point3d
        Dim tu, mau, cos As Double
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line = acTrans.GetObject(id, OpenMode.ForWrite)
            Diem1 = line.StartPoint
            Diem2 = line.EndPoint
            acTrans.Commit()
        End Using
        If (Diem1.X <= 0 And Diem2.X >= 0) Then
            tu = Math.Abs(Diem1.X) + Math.Abs(Diem2.X)
        ElseIf (Diem1.X <= 0 And Diem2.X <= 0) Then
            tu = Math.Abs(Diem1.X) - Math.Abs(Diem2.X)
        ElseIf (Diem1.X >= 0 And Diem2.X >= 0) Then
            tu = Math.Abs(Diem1.X) - Math.Abs(Diem2.X)
        ElseIf (Diem1.X >= 0 And Diem2.X <= 0) Then
            tu = Math.Abs(Diem1.X) + Math.Abs(Diem2.X)
        End If
        mau = line.Length
        cos = tu / mau
        goc = Math.Acos(cos)
        Return goc
    End Function
    Public Shared Sub TaoTextTrenDayCo(id As ObjectId, GocXoay As Double, NoiDung As String, CaoDayCo As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim diem1, diem2 As New Point3d
        Dim line As New Line
        Dim lineclon As New Line
        Dim id_lineclon As ObjectId
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line = acTrans.GetObject(id, OpenMode.ForWrite)
            diem1 = line.StartPoint
            diem2 = line.EndPoint
            Dim khoangcachmong = Math.Sqrt((x1 * x1) + (y1 * y1))
            Dim chieucaocot = CaoDayCo * 1000
            Dim chieudaiday = Math.Round(Math.Sqrt((chieucaocot * chieucaocot) + (khoangcachmong * khoangcachmong)), 2)
            NoiDung = "L=" & Convert.ToString(Math.Round(Val(chieudaiday / 1000), 2)) & "(m)"
            acTrans.Commit()
        End Using

        Dim DiemDat, DiemText As Point3d
        If diem1.X <= 0 And diem2.X >= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 - 0, (diem1.Y + diem2.Y) / 2 - 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X - TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(-((Math.PI) / 2 - GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, GocXoay)

        ElseIf diem1.X <= 0 And diem2.X <= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 - 0, (diem1.Y + diem2.Y) / 2 - 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X - TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(-((Math.PI) / 2 - GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, GocXoay)
        ElseIf diem1.X >= 0 And diem2.X >= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 + 0, (diem1.Y + diem2.Y) / 2 + 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X + TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(((Math.PI) / 2 - GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, -GocXoay)
        ElseIf diem1.X >= 0 And diem2.X <= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 + 0, (diem1.Y + diem2.Y) / 2 + 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X + TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(((Math.PI) / 2 - GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, -GocXoay)
        End If
    End Sub
    Public Shared Sub VeDatMongCoL1(Toado As Point3d, CaoMong As Double, RongMong As Double)
        If Toado.X <= 0 Then
            If Toado.Y <= 0 Then
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - CaoMong, 0))
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - CaoMong, 0))
            Else
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - CaoMong, 0))
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - CaoMong, 0))
            End If

        Else
            If Toado.Y <= 0 Then
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - CaoMong, 0))
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - CaoMong, 0))
            Else
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - CaoMong, 0))
                Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - CaoMong, 0))
            End If
        End If

    End Sub
    Public Shared Sub VeDatMongCoL2(Toado As Point3d, CaoMong As Double, RongMong As Double)
        If Toado.X <= 0 Then
            Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - CaoMong, 0))
            Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - CaoMong, 0))
        Else
            Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - CaoMong, 0))
            Lib_Drawing.CreateLine(New Point3d(Toado.X, Toado.Y - CaoMong, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - CaoMong, 0))
        End If

    End Sub
    Public Shared Sub VeDatMong0(Toado As Point3d, RongMong As Double, c As Double)
        Lib_Drawing.CreateLine(New Point3d(Toado.X + RongMong / 2, Toado.Y - c, 0), New Point3d(Toado.X + RongMong * 5, Toado.Y - c, 0))
        Lib_Drawing.CreateLine(New Point3d(Toado.X - RongMong / 2, Toado.Y - c, 0), New Point3d(Toado.X - RongMong * 5, Toado.Y - c, 0))
    End Sub
End Class
