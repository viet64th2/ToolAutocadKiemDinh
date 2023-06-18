Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO

Public Class mbVeMong
    Public Shared Function TachChuoi(txtDauVao As String, rowItem As Integer, txtViTri As Integer)
        Try
            Dim T0 As String() = txtDauVao.Split("@") '
            Dim T1 As String() = T0(rowItem).Split("_") 'mo_kt_
            Dim T2 As String() = T1(txtViTri).Split("_") 'chieurongxchieudaixchieucao    'chieudaixchieurongxchieucao(DP)
            Dim T3 As String() = T1(txtViTri).Split("x")
            Return T3
        Catch ex As System.Exception
            Return {"0", "0", "0"}
        End Try

    End Function



    Public Shared Sub Ve_Mong_0(b_bvemong0 As Double, b_hvemong0 As Double, xxoay As Double, yxoay As Double, Layer As String, Linetypescale As Double, TextHight As Double)
        Dim layermong0 As String = "10"
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do0ngoai(3) As Point2d 'mong 0 trong
        Mang_Toa_Do0ngoai(0) = New Point2d(-b_b0mong / 2 - b_b0mong / 3, b_h0mong / 2 + b_h0mong / 3)
        Mang_Toa_Do0ngoai(1) = New Point2d(b_b0mong / 2 + b_b0mong / 3, b_h0mong / 2 + b_h0mong / 3)
        Mang_Toa_Do0ngoai(2) = New Point2d(b_b0mong / 2 + b_b0mong / 3, -b_h0mong / 2 - b_h0mong / 3)
        Mang_Toa_Do0ngoai(3) = New Point2d(-b_b0mong / 2 - b_b0mong / 3, -b_h0mong / 2 - b_b0mong / 3)
        Dim id_mong0ngoai As ObjectId
        id_mong0ngoai = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0ngoai, True)
        Dim Mang_Toa_Do0trong(3) As Point2d 'mong 0 ngoai
        Mang_Toa_Do0trong(0) = New Point2d(-b_b0mong / 2 - b_b0mong / 3 - b_b0mong / 10, b_h0mong / 2 + b_h0mong / 3 + b_h0mong / 10)
        Mang_Toa_Do0trong(1) = New Point2d(b_b0mong / 2 + b_b0mong / 3 + b_b0mong / 10, b_h0mong / 2 + b_h0mong / 3 + b_h0mong / 10)
        Mang_Toa_Do0trong(2) = New Point2d(b_b0mong / 2 + b_b0mong / 3 + b_b0mong / 10, -b_h0mong / 2 - b_h0mong / 3 - b_h0mong / 10)
        Mang_Toa_Do0trong(3) = New Point2d(-b_b0mong / 2 - b_b0mong / 3 - b_b0mong / 10, -b_h0mong / 2 - b_b0mong / 3 - b_h0mong / 10)
        Dim id_mong0trong As ObjectId
        id_mong0trong = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0trong, True)
        Dim Mang_Toa_Do0(3) As Point2d
        Mang_Toa_Do0(0) = New Point2d(-b_b0mong / 2, b_h0mong / 2)
        Mang_Toa_Do0(1) = New Point2d(b_b0mong / 2, b_h0mong / 2)
        Mang_Toa_Do0(2) = New Point2d(b_b0mong / 2, -b_h0mong / 2)
        Mang_Toa_Do0(3) = New Point2d(-b_b0mong / 2, -b_h0mong / 2)
        Dim id_mong0 As ObjectId
        id_mong0 = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0, True)
        Dim GocXoay As Double = Lib_Drawing.mbTinhgoc1Update(xxoay, yxoay) '' Xoay mong 0
        If ((x1 = 0) Or (y1 = 0) Or (x2 = 0) Or (y2 = 0) Or (x3 = 0) Or (y3 = 0)) Then
            'GocXoay = 0
            Lib_Drawing.RotateEntity(id_mong0ngoai, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
            Lib_Drawing.RotateEntity(id_mong0trong, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
            Lib_Drawing.RotateEntity(id_mong0, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Else

            Lib_Drawing.RotateEntity(id_mong0ngoai, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
            Lib_Drawing.RotateEntity(id_mong0trong, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
            Lib_Drawing.RotateEntity(id_mong0, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        End If
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim Mong0ngoai, Mong0trong, Mong0 As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Mong0ngoai = acTrans.GetObject(id_mong0ngoai, OpenMode.ForWrite)
            Mong0trong = acTrans.GetObject(id_mong0trong, OpenMode.ForWrite)
            Mong0 = acTrans.GetObject(id_mong0, OpenMode.ForWrite)
            Mong0.Layer = layermong0
            Mong0ngoai.Layer = Layer
            Mong0ngoai.LinetypeScale = Linetypescale
            Mong0trong.Layer = Layer
            Mong0trong.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        For i = 0 To 3 Step 1
            Dim diemText As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (diemText.X > 0) And (diemText.Y > 0) Then
                '' Text 
                Dim TextMong0(2) As Point2d 'mong 0
                TextMong0(0) = New Point2d(diemText.X, diemText.Y)
                TextMong0(1) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + TextHight, b_h0mong / 2 + b_h0mong / 10 + TextHight)
                TextMong0(2) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 3 + TextHight * 9, b_h0mong / 2 + b_h0mong / 10 + TextHight)
                Dim id_TextMong0 As ObjectId
                id_TextMong0 = Lib_Drawing.CreateNewPolyline(TextMong0, False)
                Lib_Drawing.CreateNewMText(New Point3d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 3, b_h0mong / 2 + b_h0mong / 10 + TextHight + TextHight * 2.6, 0), "Móng M0", TextHight) ' nhân với 2.6 để chứ g trong "Móng 0" theo tỉ lệ sẽ ở trên đường kẻ
                'Cao độ mặt đất của móng
                Dim CaoDo As String

                If frmTTC.txtCaoDoMong.Text > 0 Then
                    CaoDo = "+" & Format(frmTTC.txtCaoDoMong.Text, "0.00")
                ElseIf frmTTC.txtCaoDoMong.Text = 0 Then
                    CaoDo = "%%p" & Format(frmTTC.txtCaoDoMong.Text, "0.00")
                Else
                    CaoDo = Format(frmTTC.txtCaoDoMong.Text, "0.00")
                End If
                Lib_Drawing.insertBlock(New Point3d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 12, b_h0mong / 2 + b_h0mong / 10 + TextHight - TextHight * 8, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)
            End If
        Next
        've 4 duong noi mong 
        Dim line1, line2, line3, line4 As Line
        Dim id_line1, id_line2, id_line3, id_line4 As ObjectId
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X <= 0) And (Diem1.Y >= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X <= 0) And (Diem2.Y >= 0) Then
                        id_line1 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X >= 0) And (Diem1.Y >= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X >= 0) And (Diem2.Y >= 0) Then
                        id_line2 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X >= 0) And (Diem1.Y <= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X >= 0) And (Diem2.Y <= 0) Then
                        id_line3 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X <= 0) And (Diem1.Y <= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X <= 0) And (Diem2.Y <= 0) Then
                        id_line4 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line1 = acTrans.GetObject(id_line1, OpenMode.ForWrite)
            line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
            line3 = acTrans.GetObject(id_line3, OpenMode.ForWrite)
            line4 = acTrans.GetObject(id_line4, OpenMode.ForWrite)
            line1.Layer = Layer
            line2.Layer = Layer
            line3.Layer = Layer
            line4.Layer = Layer
            line1.LinetypeScale = Linetypescale
            line2.LinetypeScale = Linetypescale
            line3.LinetypeScale = Linetypescale
            line4.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
    End Sub
    Public Shared Sub Ve_Mong_0_4Mong(b_bvemong0 As Double, b_hvemong0 As Double, xxoay As Double, yxoay As Double, Layer As String, Linetypescale As Double, TextHight As Double)
        Dim layermong0 As String = "10"
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do0ngoai(3) As Point2d 'mong 0 trong
        Mang_Toa_Do0ngoai(0) = New Point2d(-b_b0mong / 2 - b_b0mong / 3, b_h0mong / 2 + b_h0mong / 3)
        Mang_Toa_Do0ngoai(1) = New Point2d(b_b0mong / 2 + b_b0mong / 3, b_h0mong / 2 + b_h0mong / 3)
        Mang_Toa_Do0ngoai(2) = New Point2d(b_b0mong / 2 + b_b0mong / 3, -b_h0mong / 2 - b_h0mong / 3)
        Mang_Toa_Do0ngoai(3) = New Point2d(-b_b0mong / 2 - b_b0mong / 3, -b_h0mong / 2 - b_b0mong / 3)
        Dim id_mong0ngoai As ObjectId
        id_mong0ngoai = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0ngoai, True)
        Dim Mang_Toa_Do0trong(3) As Point2d 'mong 0 ngoai
        Mang_Toa_Do0trong(0) = New Point2d(-b_b0mong / 2 - b_b0mong / 3 - b_b0mong / 10, b_h0mong / 2 + b_h0mong / 3 + b_h0mong / 10)
        Mang_Toa_Do0trong(1) = New Point2d(b_b0mong / 2 + b_b0mong / 3 + b_b0mong / 10, b_h0mong / 2 + b_h0mong / 3 + b_h0mong / 10)
        Mang_Toa_Do0trong(2) = New Point2d(b_b0mong / 2 + b_b0mong / 3 + b_b0mong / 10, -b_h0mong / 2 - b_h0mong / 3 - b_h0mong / 10)
        Mang_Toa_Do0trong(3) = New Point2d(-b_b0mong / 2 - b_b0mong / 3 - b_b0mong / 10, -b_h0mong / 2 - b_b0mong / 3 - b_h0mong / 10)
        Dim id_mong0trong As ObjectId
        id_mong0trong = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0trong, True)
        Dim Mang_Toa_Do0(3) As Point2d
        Mang_Toa_Do0(0) = New Point2d(-b_b0mong / 2, b_h0mong / 2)
        Mang_Toa_Do0(1) = New Point2d(b_b0mong / 2, b_h0mong / 2)
        Mang_Toa_Do0(2) = New Point2d(b_b0mong / 2, -b_h0mong / 2)
        Mang_Toa_Do0(3) = New Point2d(-b_b0mong / 2, -b_h0mong / 2)
        Dim id_mong0 As ObjectId
        id_mong0 = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0, True)
        Dim Goc As Double = (GocXoayMatBang * (Math.PI)) / 180
        Dim GocXoay As Double
        If ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 And ThongTinChung.GaChongXoay <> "" Then
            Dim GocXoayCoGa As Double = Goc - Math.PI
            If MongNoiChung1 = "Móng 1, Móng 2" Then
                GocXoay = GocXoayCoGa - Math.PI
            ElseIf MongNoiChung1 = "Móng 2, Móng 3" Then
                GocXoay = GocXoayCoGa - Math.PI / 2 - Math.PI

            ElseIf MongNoiChung1 = "Móng 3, Móng 4" Then
                GocXoay = GocXoayCoGa
            ElseIf MongNoiChung1 = "Móng 4, Móng 1" Then
                GocXoay = GocXoayCoGa - Math.PI / 2
            Else
                GocXoay = GocXoayCoGa
            End If
        ElseIf ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 And ThongTinChung.GaChongXoay = "" Then
            Dim GocXoayCoGa As Double = Goc
            If MongNoiChung1 = "Móng 1, Móng 2" Then
                GocXoay = GocXoayCoGa - Math.PI
            ElseIf MongNoiChung1 = "Móng 2, Móng 3" Then
                GocXoay = GocXoayCoGa - Math.PI / 2 - Math.PI

            ElseIf MongNoiChung1 = "Móng 3, Móng 4" Then
                GocXoay = GocXoayCoGa
            ElseIf MongNoiChung1 = "Móng 4, Móng 1" Then
                GocXoay = GocXoayCoGa - Math.PI / 2
            Else
                GocXoay = GocXoayCoGa
            End If
        Else

            GocXoay = Goc
        End If
        Lib_Drawing.RotateEntity(id_mong0ngoai, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Lib_Drawing.RotateEntity(id_mong0trong, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Lib_Drawing.RotateEntity(id_mong0, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        'If ((x1 = 0) Or (y1 = 0) Or (x2 = 0) Or (y2 = 0) Or (x3 = 0) Or (y3 = 0)) Then
        '    'GocXoay = 0
        '    Lib_Drawing.RotateEntity(id_mong0ngoai, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        '    Lib_Drawing.RotateEntity(id_mong0trong, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        'Else

        '    Lib_Drawing.RotateEntity(id_mong0ngoai, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        '    Lib_Drawing.RotateEntity(id_mong0trong, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        'End If
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim Mong0ngoai, Mong0trong, Mong0 As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Mong0ngoai = acTrans.GetObject(id_mong0ngoai, OpenMode.ForWrite)
            Mong0trong = acTrans.GetObject(id_mong0trong, OpenMode.ForWrite)
            Mong0 = acTrans.GetObject(id_mong0, OpenMode.ForWrite)
            Mong0.Layer = layermong0
            Mong0ngoai.Layer = Layer
            Mong0ngoai.LinetypeScale = Linetypescale
            Mong0trong.Layer = Layer
            Mong0trong.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        For i = 0 To 3 Step 1
            Dim diemText As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (diemText.X > 0) And (diemText.Y > 0) Then
                '' Text 
                Dim TextMong0(2) As Point2d 'mong 0
                TextMong0(0) = New Point2d(diemText.X, diemText.Y)
                TextMong0(1) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + TextHight, b_h0mong / 2 + b_h0mong / 10 + TextHight)
                TextMong0(2) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 3 + TextHight * 9, b_h0mong / 2 + b_h0mong / 10 + TextHight)
                Dim id_TextMong0 As ObjectId
                id_TextMong0 = Lib_Drawing.CreateNewPolyline(TextMong0, False)
                Lib_Drawing.CreateNewMText(New Point3d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 3, b_h0mong / 2 + b_h0mong / 10 + TextHight + TextHight * 2.6, 0), "Móng M0", TextHight) ' nhân với 2.6 để chứ g trong "Móng 0" theo tỉ lệ sẽ ở trên đường kẻ
                'Cao độ mặt đất của móng
                Dim CaoDo As String

                If frmTTC.txtCaoDoMong.Text > 0 Then
                    CaoDo = "+" & Format(frmTTC.txtCaoDoMong.Text, "0.00")
                ElseIf frmTTC.txtCaoDoMong.Text = 0 Then
                    CaoDo = "%%p" & Format(frmTTC.txtCaoDoMong.Text, "0.00")
                Else
                    CaoDo = Format(frmTTC.txtCaoDoMong.Text, "0.00")
                End If
                Lib_Drawing.insertBlock(New Point3d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 12, b_h0mong / 2 + b_h0mong / 10 + TextHight - TextHight * 8, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)
            End If
        Next
        'Ve day noi 
        Dim line1, line2, line3, line4 As Line
        Dim id_line1, id_line2, id_line3, id_line4 As ObjectId
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X <= 0) And (Diem1.Y >= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X <= 0) And (Diem2.Y >= 0) Then
                        id_line1 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X >= 0) And (Diem1.Y >= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X >= 0) And (Diem2.Y >= 0) Then
                        id_line2 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X >= 0) And (Diem1.Y <= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X >= 0) And (Diem2.Y <= 0) Then
                        id_line3 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        For i = 0 To 3 Step 1
            Dim Diem1 As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (Diem1.X <= 0) And (Diem1.Y <= 0) Then
                For j = 0 To 3 Step 1
                    Dim Diem2 As Point2d = Mong0.GetPoint2dAt(j)
                    If (Diem2.X <= 0) And (Diem2.Y <= 0) Then
                        id_line4 = Lib_Drawing.CreateLine(New Point3d(Diem1.X, Diem1.Y, 0), New Point3d(Diem2.X, Diem2.Y, 0))
                    End If
                Next
            End If
        Next
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line1 = acTrans.GetObject(id_line1, OpenMode.ForWrite)
            line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
            line3 = acTrans.GetObject(id_line3, OpenMode.ForWrite)
            line4 = acTrans.GetObject(id_line4, OpenMode.ForWrite)
            line1.Layer = Layer
            line2.Layer = Layer
            line3.Layer = Layer
            line4.Layer = Layer
            line1.LinetypeScale = Linetypescale
            line2.LinetypeScale = Linetypescale
            line3.LinetypeScale = Linetypescale
            line4.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using

    End Sub
    Public Shared Sub Ve_Cot_Tam_Giac(CanhTamGiac As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, loaiday As Integer)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do5(2) As Point2d ' cot tam giac 
        Mang_Toa_Do5(0) = New Point2d(-(b_a * Math.Sqrt(3)) / 6, b_a / 2)
        Mang_Toa_Do5(1) = New Point2d((b_a * Math.Sqrt(3)) / 3, 0)
        Mang_Toa_Do5(2) = New Point2d(-(b_a * Math.Sqrt(3)) / 6, -b_a / 2)
        Dim id_cottamgiac As ObjectId
        id_cottamgiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
        Dim GocXoay As Double = (360 * Math.PI / 180) - Lib_Drawing.mbTinhgoc1(xxoay, yxoay) ''xoay cot tam giac
        Lib_Drawing.RotateEntity(id_cottamgiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim cottamgiac As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            cottamgiac = acTrans.GetObject(id_cottamgiac, OpenMode.ForWrite)
            cottamgiac.Layer = Layer
            cottamgiac.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        Dim diem1 As Point2d = cottamgiac.GetPoint2dAt(0)
        Dim id_c1 As ObjectId
        id_c1 = Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), b_a / 10)
        Dim id_coll1 As New ObjectIdCollection
        id_coll1.Add(id_c1)
        Lib_Drawing.CreateHatch_1MienBao(id_coll1, "SOLID", 0, 1)
        Dim diem2 As Point2d = cottamgiac.GetPoint2dAt(1)
        Dim id_c2 As ObjectId
        id_c2 = Lib_Drawing.CreateCircle(New Point3d(diem2.X, diem2.Y, 0), b_a / 10)
        Dim id_coll2 As New ObjectIdCollection
        id_coll2.Add(id_c2)
        Lib_Drawing.CreateHatch_1MienBao(id_coll2, "SOLID", 0, 1)
        Dim diem3 As Point2d = cottamgiac.GetPoint2dAt(2)
        Dim id_c3 As ObjectId
        id_c3 = Lib_Drawing.CreateCircle(New Point3d(diem3.X, diem3.Y, 0), b_a / 10)
        Dim id_coll3 As New ObjectIdCollection
        id_coll3.Add(id_c3)
        Lib_Drawing.CreateHatch_1MienBao(id_coll3, "SOLID", 0, 1)
        'Dim TextCot(2) As Point2d 'Cot tam giac
        'TextCot(0) = New Point2d(diem2.X, diem2.Y)
        'TextCot(1) = New Point2d(b_b0mong / 2 + b_b0mong / 10, -b_h0mong / 2 - b_h0mong / 10)
        'TextCot(2) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + b_b0mong, -b_h0mong / 2 - b_h0mong / 10)
        'Dim id_TextCot As ObjectId
        'id_TextCot = Lib_Drawing.CreateNewPolyline(TextCot, False)
        'Lib_Drawing.CreateNewMText(New Point3d(b_b0mong / 2 + b_b0mong / 10 + b_b0mong / 2, -b_h0mong / 2 - b_h0mong / 10 + TextHight + 50, 0), "Cột tam giác ", TextHight)
        '' ve day 
        Dim ID_Line1 As ObjectId ' day mong 1
        Dim line1 As Line
        Dim ID_Line2 As ObjectId ' day mong 2
        Dim line2 As Line
        Dim ID_Line3 As ObjectId ' day mong 3
        Dim line3 As Line
        Dim ID_Line4 As ObjectId ' day mong 4
        Dim line4 As Line
        If (loaiday = 3) Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(-x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, -y2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(-x3, -y3, 0), New Point3d(diem3.X, diem3.Y, 0))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                line1.Layer = LayerDay
                line2.Layer = LayerDay
                line3.Layer = LayerDay
                acTrans.Commit()
            End Using
        Else
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(-x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(-x3, -y3, 0), New Point3d(diem3.X, diem3.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, -y4, 0), New Point3d(diem2.X, diem2.Y, 0))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
                line1.Layer = LayerDay
                line2.Layer = LayerDay
                line3.Layer = LayerDay
                line4.Layer = LayerDay
                acTrans.Commit()
            End Using
        End If
        '' thay doi thuoc tinh day 

        ''dim
        Dim ID_DIMx1 As ObjectId 'x1
        Dim Dimx1 As RotatedDimension
        Dim ID_DIMy1 As ObjectId 'y1
        Dim Dimy1 As RotatedDimension
        Dim ID_DIMy2 As ObjectId 'y2
        Dim Dimy2 As RotatedDimension
        Dim ID_DIMx2 As ObjectId 'x2
        Dim Dimx2 As RotatedDimension
        Dim ID_DIMx3 As ObjectId 'x3
        Dim Dimx3 As RotatedDimension
        Dim ID_DIMy3 As ObjectId 'y3
        Dim Dimy3 As RotatedDimension
        Dim ID_DIMx4 As ObjectId 'x4
        Dim Dimx4 As RotatedDimension
        Dim ID_DIMy4 As ObjectId 'y4
        Dim Dimy4 As RotatedDimension
        If (loaiday = 3) Then
            ID_DIMx1 = Lib_Drawing.CreateRotatedDimension(New Point3d(-x1, Math.Max(y1, 0) + b_hmong, 0), New Point3d(0, Math.Max(y1, 0) + b_hmong, 0), New Point3d(-x1 / 2, Math.Max(0, y1) + b_hmong / 2 + b_hmong, 0), 0)
            ID_DIMy1 = Lib_Drawing.CreateRotatedDimension(New Point3d(-Math.Max(x3, x1) - b_bmong, 0, 0), New Point3d(-Math.Max(x3, x1) - b_bmong, y1, 0), New Point3d(-Math.Max(x3, x1) - b_bmong / 2 - b_bmong, 0 / 2, 0), 90)
            ID_DIMy2 = Lib_Drawing.CreateRotatedDimension(New Point3d(Math.Max(0, x2) + b_bmong, 0, 0), New Point3d(Math.Max(0, x2) + b_bmong, -y2, 0), New Point3d(Math.Max(x2, 0) + b_bmong / 2 + b_bmong, -0 / 2, 0), 90)
            ID_DIMx2 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, -Math.Max(y2, y3) - b_hmong, 0), New Point3d(x2, -Math.Max(y2, y3) - b_hmong, 0), New Point3d(0 / 2, -Math.Max(y3, y2) - b_hmong / 2 - b_hmong, 0), 0)
            ID_DIMx3 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, -Math.Max(y2, y3) - b_hmong, 0), New Point3d(-x3, -Math.Max(y2, y3) - b_hmong, 0), New Point3d(-x3 / 2, -Math.Max(y3, y2) - b_hmong / 2 - b_hmong, 0), 0)
            ID_DIMy3 = Lib_Drawing.CreateRotatedDimension(New Point3d(-Math.Max(x3, x1) - b_bmong, -y3, 0), New Point3d(-Math.Max(x3, x1) - b_bmong, 0, 0), New Point3d(-Math.Max(x3, x1) - b_bmong / 2 - b_bmong, -y3 / 2, 0), 90)

            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                Dimx1 = acTrans.GetObject(ID_DIMx1, OpenMode.ForWrite)
                Dimy1 = acTrans.GetObject(ID_DIMy1, OpenMode.ForWrite)
                Dimx2 = acTrans.GetObject(ID_DIMx2, OpenMode.ForWrite)
                Dimy2 = acTrans.GetObject(ID_DIMy2, OpenMode.ForWrite)
                Dimx3 = acTrans.GetObject(ID_DIMx3, OpenMode.ForWrite)
                Dimy3 = acTrans.GetObject(ID_DIMy3, OpenMode.ForWrite)
                Dimx1.Dimscale = Dimscale
                Dimy1.Dimscale = Dimscale
                Dimx2.Dimscale = Dimscale
                Dimy2.Dimscale = Dimscale
                Dimx3.Dimscale = Dimscale
                Dimy3.Dimscale = Dimscale
                acTrans.Commit()
            End Using
        Else
            ID_DIMx1 = Lib_Drawing.CreateRotatedDimension(New Point3d(-x1, Math.Max(y1, 0) + b_hmong, 0), New Point3d(0, Math.Max(y1, 0) + b_hmong, 0), New Point3d(-x1 / 2, Math.Max(0, y1) + b_hmong / 2 + b_hmong, 0), 0)
            ID_DIMy1 = Lib_Drawing.CreateRotatedDimension(New Point3d(-Math.Max(x3, x1) - b_bmong, 0, 0), New Point3d(-Math.Max(x3, x1) - b_bmong, y1, 0), New Point3d(-Math.Max(x3, x1) - b_bmong / 2 - b_bmong, y1 / 2, 0), 90)
            ID_DIMy2 = Lib_Drawing.CreateRotatedDimension(New Point3d(Math.Max(x4, x2) + b_bmong, 0, 0), New Point3d(Math.Max(x4, x2) + b_bmong, y2, 0), New Point3d(Math.Max(x2, x4) + b_bmong / 2 + b_bmong, y2 / 2, 0), 90)
            ID_DIMx2 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, Math.Max(y2, y1) + b_hmong, 0), New Point3d(x2, Math.Max(y2, y1) + b_hmong, 0), New Point3d(x2 / 2, Math.Max(y1, y2) + b_hmong / 2 + b_hmong, 0), 0)
            ID_DIMx3 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, -Math.Max(y4, y3) - b_hmong, 0), New Point3d(-x3, -Math.Max(y4, y3) - b_hmong, 0), New Point3d(-x3 / 2, -Math.Max(y4, y2) - b_hmong / 2 - b_hmong, 0), 0)
            ID_DIMy3 = Lib_Drawing.CreateRotatedDimension(New Point3d(-Math.Max(x3, x1) - b_bmong, -y3, 0), New Point3d(-Math.Max(x3, x1) - b_bmong, 0, 0), New Point3d(-Math.Max(x3, x1) - b_bmong / 2 - b_bmong, -y3 / 2, 0), 90)
            ID_DIMx4 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, -Math.Max(y4, y3) - b_hmong, 0), New Point3d(x4, -Math.Max(y4, y3) - b_hmong, 0), New Point3d(x4 / 2, -Math.Max(y4, y3) - b_hmong / 2 - b_hmong, 0), 0)
            ID_DIMy4 = Lib_Drawing.CreateRotatedDimension(New Point3d(Math.Max(x4, x1) + b_bmong, -y4, 0), New Point3d(Math.Max(x4, x1) + b_bmong, 0, 0), New Point3d(Math.Max(x4, x1) + b_bmong / 2 + b_bmong, -y4 / 2, 0), 90)
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                Dimx1 = acTrans.GetObject(ID_DIMx1, OpenMode.ForWrite)
                Dimy1 = acTrans.GetObject(ID_DIMy1, OpenMode.ForWrite)
                Dimx2 = acTrans.GetObject(ID_DIMx2, OpenMode.ForWrite)
                Dimy2 = acTrans.GetObject(ID_DIMy2, OpenMode.ForWrite)
                Dimx3 = acTrans.GetObject(ID_DIMx3, OpenMode.ForWrite)
                Dimy3 = acTrans.GetObject(ID_DIMy3, OpenMode.ForWrite)
                Dimx4 = acTrans.GetObject(ID_DIMx4, OpenMode.ForWrite)
                Dimy4 = acTrans.GetObject(ID_DIMy4, OpenMode.ForWrite)
                Dimx1.Dimscale = Dimscale
                Dimy1.Dimscale = Dimscale
                Dimx2.Dimscale = Dimscale
                Dimy2.Dimscale = Dimscale
                Dimx3.Dimscale = Dimscale
                Dimy3.Dimscale = Dimscale
                Dimx4.Dimscale = Dimscale
                Dimy4.Dimscale = Dimscale
                acTrans.Commit()
            End Using
        End If

    End Sub

    'Public Shared Sub Ve_Cot_Tu_Giac_Update(b_bchancot As Double, b_hchancot As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, GaChongXoay As Boolean)
    '    Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
    '    Dim acCurDb As Database = acDoc.Database
    '    Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
    '    Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
    '    Dim Mang_Toa_Do5(3) As Point2d ' cot tu giac
    '    Mang_Toa_Do5(0) = New Point2d(-b_bchancot / 2, b_hchancot / 2)
    '    Mang_Toa_Do5(1) = New Point2d(b_bchancot / 2, b_hchancot / 2)
    '    Mang_Toa_Do5(2) = New Point2d(b_bchancot / 2, -b_hchancot / 2)
    '    Mang_Toa_Do5(3) = New Point2d(-b_bchancot / 2, -b_hchancot / 2)
    '    Dim id_cottugiac As ObjectId
    '    id_cottugiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
    '    Dim GocXoay As Double = (GocXoayMatBang * (Math.PI)) / 180 ''xoay cot tu giac
    '    Lib_Drawing.RotateEntity(id_cottugiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
    '    acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
    '    Dim cottugiac As Polyline
    '    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
    '        cottugiac = acTrans.GetObject(id_cottugiac, OpenMode.ForWrite)
    '        cottugiac.Layer = Layer
    '        cottugiac.LinetypeScale = Linetypescale
    '        acTrans.Commit()
    '    End Using
    '    Dim diem1 As Point2d = cottugiac.GetPoint2dAt(0)
    '    Dim id_c1 As ObjectId
    '    id_c1 = Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), Math.Abs(b_bchancot / 10))
    '    Dim id_coll1 As New ObjectIdCollection
    '    id_coll1.Add(id_c1)
    '    Lib_Drawing.CreateHatch_1MienBao(id_coll1, "SOLID", 0, 1)
    '    Dim diem2 As Point2d = cottugiac.GetPoint2dAt(1)
    '    Dim id_c2 As ObjectId
    '    id_c2 = Lib_Drawing.CreateCircle(New Point3d(diem2.X, diem2.Y, 0), Math.Abs(b_bchancot / 10))
    '    Dim id_coll2 As New ObjectIdCollection
    '    id_coll2.Add(id_c2)
    '    Lib_Drawing.CreateHatch_1MienBao(id_coll2, "SOLID", 0, 1)
    '    Dim diem3 As Point2d = cottugiac.GetPoint2dAt(2)
    '    Dim id_c3 As ObjectId
    '    id_c3 = Lib_Drawing.CreateCircle(New Point3d(diem3.X, diem3.Y, 0), Math.Abs(b_bchancot / 10))
    '    Dim id_coll3 As New ObjectIdCollection
    '    id_coll3.Add(id_c3)
    '    Lib_Drawing.CreateHatch_1MienBao(id_coll3, "SOLID", 0, 1)
    '    Dim diem4 As Point2d = cottugiac.GetPoint2dAt(3)
    '    Dim id_c4 As ObjectId
    '    id_c4 = Lib_Drawing.CreateCircle(New Point3d(diem4.X, diem4.Y, 0), Math.Abs(b_bchancot / 10))
    '    Dim id_coll4 As New ObjectIdCollection
    '    id_coll4.Add(id_c4)
    '    Lib_Drawing.CreateHatch_1MienBao(id_coll4, "SOLID", 0, 1)
    '    'Dim TextCot(2) As Point2d 'Cot tu giac
    '    'TextCot(0) = New Point2d(diem2.X, diem2.Y)
    '    'TextCot(1) = New Point2d(b_b0mong / 2 + b_b0mong / 10, -b_h0mong / 2 - b_h0mong / 10)
    '    'TextCot(2) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + b_b0mong, -b_h0mong / 2 - b_h0mong / 10)
    '    'Dim id_TextCot As ObjectId
    '    'id_TextCot = Lib_Drawing.CreateNewPolyline(TextCot, False)
    '    'Lib_Drawing.CreateNewMText(New Point3d(b_b0mong / 2 + b_b0mong / 10 + b_b0mong / 2, -b_h0mong / 2 - b_h0mong / 10 + TextHight + 50, 0), "Cột Tứ Giác ", TextHight)
    '    '' ve day 
    '    Dim ID_Line1 As ObjectId ' day mong 1
    '    Dim line1 As Line
    '    Dim ID_Line11 As ObjectId ' day mong 1
    '    Dim line11 As Line
    '    Dim ID_Line2 As ObjectId ' day mong 2
    '    Dim line2 As Line
    '    Dim ID_Line22 As ObjectId ' day mong 2
    '    Dim line22 As Line
    '    Dim ID_Line3 As ObjectId ' day mong 3
    '    Dim line3 As Line
    '    Dim ID_Line33 As ObjectId ' day mong 3
    '    Dim line33 As Line
    '    Dim ID_Line4 As ObjectId ' day mong 4
    '    Dim line4 As Line
    '    Dim ID_Line44 As ObjectId ' day mong 4
    '    Dim line44 As Line
    '    If GaChongXoay = False Then
    '        If (x1 <= 0) And (y1 >= 0) And (x2 <= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
    '        ElseIf (x1 <= 0) And (y1 >= 0) And (x2 >= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 >= 0) And (x2 >= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 >= 0) And (x2 <= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 <= 0) And (x2 <= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 <= 0) And (x2 >= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
    '        ElseIf (x1 <= 0) And (y1 <= 0) And (x2 <= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '        ElseIf (x1 <= 0) And (y1 <= 0) And (x2 >= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
    '        Else
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '        End If
    '        '' thay doi thuoc tinh day 
    '        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
    '            line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
    '            line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
    '            line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
    '            line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
    '            line1.Layer = LayerDay
    '            line2.Layer = LayerDay
    '            line3.Layer = LayerDay
    '            line4.Layer = LayerDay
    '            line11 = acTrans.GetObject(ID_Line11, OpenMode.ForWrite)
    '            line22 = acTrans.GetObject(ID_Line22, OpenMode.ForWrite)
    '            line33 = acTrans.GetObject(ID_Line33, OpenMode.ForWrite)
    '            line44 = acTrans.GetObject(ID_Line44, OpenMode.ForWrite)
    '            line11.Layer = LayerDay
    '            line22.Layer = LayerDay
    '            line33.Layer = LayerDay
    '            line44.Layer = LayerDay
    '            acTrans.Commit()
    '        End Using
    '    Else
    '        If (x1 <= 0) And (y1 >= 0) And (x2 <= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
    '        ElseIf (x1 <= 0) And (y1 >= 0) And (x2 >= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 >= 0) And (x2 >= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 >= 0) And (x2 <= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 <= 0) And (x2 <= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
    '        ElseIf (x1 >= 0) And (y1 <= 0) And (x2 >= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
    '        ElseIf (x1 <= 0) And (y1 <= 0) And (x2 <= 0) And (y2 >= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '        ElseIf (x1 <= 0) And (y1 <= 0) And (x2 >= 0) And (y2 <= 0) Then
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
    '        Else
    '            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
    '            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
    '            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
    '            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
    '        End If
    '        ' thay doi thuoc tinh day 
    '        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
    '            line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
    '            line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
    '            line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
    '            line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
    '            line1.Layer = LayerDay
    '            line2.Layer = LayerDay
    '            line3.Layer = LayerDay
    '            line4.Layer = LayerDay
    '            acTrans.Commit()
    '        End Using
    '    End If
    '    'Dim
    '    mbVeMong.Dim4MongCotTamGiac(x1, y1, x2, y2, x3, y3, x4, y4, b_bmong, b_hmong, Dimscale)
    'End Sub
    Public Shared Sub Ve_Cot_Tu_Giac(b As Double, h As Double, d As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, GaChongXoay As Boolean)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database
        Dim Mang_Toa_Do5(3) As Point2d ' cot tu giac
        Mang_Toa_Do5(0) = New Point2d(b_bchancot / 2, b_hchancot / 2)
        Mang_Toa_Do5(1) = New Point2d(b_bchancot / 2, -b_hchancot / 2)
        Mang_Toa_Do5(2) = New Point2d(-b_bchancot / 2, -b_hchancot / 2)
        Mang_Toa_Do5(3) = New Point2d(-b_bchancot / 2, b_hchancot / 2)
        Dim id_cottugiac As ObjectId
        id_cottugiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
        ' thay doi thuoc tinh 
        Dim cottugiac As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            cottugiac = acTrans.GetObject(id_cottugiac, OpenMode.ForWrite)
            cottugiac.Layer = Layer
            cottugiac.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        Dim GocXoay As Double = (-GocXoayMatBang * (Math.PI)) / 180 ''xoay cot tu giac
        Lib_Drawing.RotateEntity(id_cottugiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Dim diem1 As Point2d = cottugiac.GetPoint2dAt(0)
        Dim diem2 As Point2d = cottugiac.GetPoint2dAt(1)
        Dim diem3 As Point2d = cottugiac.GetPoint2dAt(2)
        Dim diem4 As Point2d = cottugiac.GetPoint2dAt(3)

        Dim id_c1 As ObjectId
        id_c1 = Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), b_bchancot / 10)
        Dim id_coll1 As New ObjectIdCollection
        id_coll1.Add(id_c1)
        Lib_Drawing.CreateHatch_1MienBao(id_coll1, "SOLID", 0, 1)
        Dim id_c2 As ObjectId
        id_c2 = Lib_Drawing.CreateCircle(New Point3d(diem2.X, diem2.Y, 0), b_bchancot / 10)
        Dim id_coll2 As New ObjectIdCollection
        id_coll2.Add(id_c2)
        Lib_Drawing.CreateHatch_1MienBao(id_coll2, "SOLID", 0, 1)
        Dim id_c3 As ObjectId
        id_c3 = Lib_Drawing.CreateCircle(New Point3d(diem3.X, diem3.Y, 0), b_bchancot / 10)
        Dim id_coll3 As New ObjectIdCollection
        id_coll3.Add(id_c3)
        Lib_Drawing.CreateHatch_1MienBao(id_coll3, "SOLID", 0, 1)
        Dim id_c4 As ObjectId
        id_c4 = Lib_Drawing.CreateCircle(New Point3d(diem4.X, diem4.Y, 0), b_bchancot / 10)
        Dim id_coll4 As New ObjectIdCollection
        id_coll4.Add(id_c4)
        Lib_Drawing.CreateHatch_1MienBao(id_coll4, "SOLID", 0, 1)
        '' ve day 
        Dim ID_Line1 As ObjectId ' day mong 1
        Dim line1 As Line
        Dim ID_Line2 As ObjectId ' day mong 2
        Dim line2 As Line
        Dim ID_Line3 As ObjectId ' day mong 3
        Dim line3 As Line
        Dim ID_Line4 As ObjectId ' day mong 4
        Dim line4 As Line
        Dim ww = 0, hh = 0
        If (ThongTinChung.NoiDayCo = "TH1") Or (ThongTinChung.NoiDayCo = "TH3") Or (ThongTinChung.NoiDayCo = "TH4") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 + hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 + hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))

        ElseIf (ThongTinChung.NoiDayCo = "TH2") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 + hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 + hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))

        ElseIf (ThongTinChung.NoiDayCo = "TH5") Or (ThongTinChung.NoiDayCo = "TH6") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 + hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 + hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
        End If

        If (x1 <= 0) And (y1 >= 0) Then
            TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, Mang_Toa_Do5(3)), "", Mang_Toa_Do5(3))
            TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, Mang_Toa_Do5(0)), "", Mang_Toa_Do5(0))
            TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, Mang_Toa_Do5(1)), "", Mang_Toa_Do5(1))
            TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, Mang_Toa_Do5(2)), "", Mang_Toa_Do5(2))

        ElseIf (x1 <= 0) And (y1 <= 0) Then
            TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, Mang_Toa_Do5(3)), "", Mang_Toa_Do5(2))
            TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, Mang_Toa_Do5(0)), "", Mang_Toa_Do5(3))
            TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, Mang_Toa_Do5(1)), "", Mang_Toa_Do5(0))
            TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, Mang_Toa_Do5(2)), "", Mang_Toa_Do5(1))

        ElseIf (x1 >= 0) And (y1 >= 0) Then
            TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, Mang_Toa_Do5(3)), "", Mang_Toa_Do5(0))
            TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, Mang_Toa_Do5(0)), "", Mang_Toa_Do5(1))
            TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, Mang_Toa_Do5(1)), "", Mang_Toa_Do5(2))
            TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, Mang_Toa_Do5(2)), "", Mang_Toa_Do5(3))

        ElseIf (x1 >= 0) And (y1 <= 0) Then
            TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, Mang_Toa_Do5(3)), "", Mang_Toa_Do5(1))
            TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, Mang_Toa_Do5(0)), "", Mang_Toa_Do5(2))
            TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, Mang_Toa_Do5(1)), "", Mang_Toa_Do5(3))
            TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, Mang_Toa_Do5(2)), "", Mang_Toa_Do5(0))

        End If
        'If GaChongXoay = False Then
        'If (x1 <= 0) And (y1 >= 0) And (x2 <= 0) And (y2 <= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        'ElseIf (x1 <= 0) And (y1 >= 0) And (x2 >= 0) And (y2 >= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        'ElseIf (x1 >= 0) And (y1 >= 0) And (x2 >= 0) And (y2 <= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        'ElseIf (x1 >= 0) And (y1 >= 0) And (x2 <= 0) And (y2 >= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        'ElseIf (x1 >= 0) And (y1 <= 0) And (x2 <= 0) And (y2 <= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        'ElseIf (x1 >= 0) And (y1 <= 0) And (x2 >= 0) And (y2 >= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        'ElseIf (x1 <= 0) And (y1 <= 0) And (x2 <= 0) And (y2 > 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        'ElseIf (x1 <= 0) And (y1 <= 0) And (x2 >= 0) And (y2 <= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        'Else
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    TaoTextTrenMB(ID_Line1, TinhGocDuongThangMB(ID_Line1, New Point2d(diem2.X, diem2.Y)), "", New Point2d(diem2.X, diem2.Y))

        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    TaoTextTrenMB(ID_Line2, TinhGocDuongThangMB(ID_Line2, New Point2d(diem1.X, diem1.Y)), "", New Point2d(diem1.X, diem1.Y))

        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    TaoTextTrenMB(ID_Line3, TinhGocDuongThangMB(ID_Line3, New Point2d(diem4.X, diem4.Y)), "", New Point2d(diem4.X, diem4.Y))

        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    TaoTextTrenMB(ID_Line4, TinhGocDuongThangMB(ID_Line4, New Point2d(diem3.X, diem3.Y)), "", New Point2d(diem3.X, diem3.Y))

        'End If
        '' thay doi thuoc tinh day 
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
            line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
            line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
            line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
            line1.Layer = LayerDay
            line2.Layer = LayerDay
            line3.Layer = LayerDay
            line4.Layer = LayerDay
            'line11 = acTrans.GetObject(ID_Line11, OpenMode.ForWrite)
            'line22 = acTrans.GetObject(ID_Line22, OpenMode.ForWrite)
            'line33 = acTrans.GetObject(ID_Line33, OpenMode.ForWrite)
            'line44 = acTrans.GetObject(ID_Line44, OpenMode.ForWrite)
            'line11.Layer = LayerDay
            'line22.Layer = LayerDay
            'line33.Layer = LayerDay
            'line44.Layer = LayerDay
            acTrans.Commit()
        End Using
        'Else
        '    If (x1 <= 0) And (y1 <= 0) And (x2 <= 0) And (y2 >= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    ElseIf (x1 <= 0) And (y1 >= 0) And (x2 >= 0) And (y2 >= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ElseIf (x1 >= 0) And (y1 >= 0) And (x2 >= 0) And (y2 <= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    ElseIf (x1 >= 0) And (y1 >= 0) And (x2 <= 0) And (y2 >= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    ElseIf (x1 >= 0) And (y1 <= 0) And (x2 >= 0) And (y2 <= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    ElseIf (x1 >= 0) And (y1 <= 0) And (x2 >= 0) And (y2 >= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem4.X, diem4.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ElseIf (x1 <= 0) And (y1 <= 0) And (x2 <= 0) And (y2 >= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    ElseIf (x1 <= 0) And (y1 <= 0) And (x2 >= 0) And (y2 <= 0) Then
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    Else
        '        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    End If
        '    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
        '        line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
        '        line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
        '        line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
        '        line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
        '        line1.Layer = LayerDay
        '        line2.Layer = LayerDay
        '        line3.Layer = LayerDay
        '        line4.Layer = LayerDay
        '        acTrans.Commit()
        '    End Using
        'End If
        ''dim
        mbVeMong.Dim4MongCotTamGiac(x1, y1, x2, y2, x3, y3, x4, y4, Math.Max(b_bmong, b_hmong), Math.Max(b_bmong, b_hmong), Dimscale)

    End Sub
    Public Shared Sub Ga_Chong_Xoay_MB_Tu_Giac(b As Double, h As Double, d As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do5(3) As Point2d ' ga chong xoay

        Mang_Toa_Do5(0) = New Point2d(b_bchancot / 2, b_hchancot * 3)
        Mang_Toa_Do5(1) = New Point2d(b_bchancot / 2, -b_hchancot * 3)
        Mang_Toa_Do5(2) = New Point2d(-b_bchancot / 2, -b_hchancot * 3)
        Mang_Toa_Do5(3) = New Point2d(-b_bchancot / 2, b_hchancot * 3)
        Dim id_cottugiac As ObjectId
        id_cottugiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
        Dim GocXoay As Double = (-GocXoayMatBang * (Math.PI)) / 180

        Lib_Drawing.RotateEntity(id_cottugiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim cottugiac As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            cottugiac = acTrans.GetObject(id_cottugiac, OpenMode.ForWrite)
            cottugiac.Layer = Layer
            cottugiac.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        Dim diem1 As Point2d = cottugiac.GetPoint2dAt(0)
        Dim diem2 As Point2d = cottugiac.GetPoint2dAt(1)
        Dim diem3 As Point2d = cottugiac.GetPoint2dAt(2)
        Dim diem4 As Point2d = cottugiac.GetPoint2dAt(3)

        'Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), 200)

        '' ve day 
        Dim ID_Line1 As ObjectId ' day mong 1
        Dim line1 As Line
        Dim ID_Line2 As ObjectId ' day mong 2
        Dim line2 As Line
        Dim ID_Line3 As ObjectId ' day mong 3
        Dim line3 As Line
        Dim ID_Line4 As ObjectId ' day mong 4
        Dim line4 As Line
        Dim ww = 0, hh = 0
        If (ThongTinChung.NoiDayCo = "TH3") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
        ElseIf (ThongTinChung.NoiDayCo = "TH1") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 - hh / 2, 0), New Point3d(diem3.X, diem4.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
        ElseIf (ThongTinChung.NoiDayCo = "TH2") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
        ElseIf (ThongTinChung.NoiDayCo = "TH4") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 - hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
        ElseIf (ThongTinChung.NoiDayCo = "TH5") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 - hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
        ElseIf (ThongTinChung.NoiDayCo = "TH6") Then
            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - ww / 2, y1 - hh / 2, 0), New Point3d(diem2.X, diem2.Y, 0))
            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - ww / 2, y2 - hh / 2, 0), New Point3d(diem1.X, diem1.Y, 0))
            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + ww / 2, y3 - hh / 2, 0), New Point3d(diem4.X, diem4.Y, 0))
            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + ww / 2, y4 - hh / 2, 0), New Point3d(diem3.X, diem3.Y, 0))
        End If

        'If (x1 <= 0) And (y1 <= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        'ElseIf (x1 <= 0) And (y1 >= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 + d / 2, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 - d / 2, y3, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
        'ElseIf (x1 >= 0) And (y1 >= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
        'ElseIf (x1 >= 0) And (y1 <= 0) Then
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem4.X, diem4.Y, 0))
        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 + d / 2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 - d / 2, y4, 0), New Point3d(diem1.X, diem1.Y, 0))

        'Else
        '    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1 - d / 2, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
        '    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2 - d / 2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
        '    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3 + d / 2, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
        '    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4 + d / 2, y4, 0), New Point3d(diem4.X, diem4.Y, 0))
        'End If

        '' thay doi thuoc tinh day 
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
            line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
            line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
            line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
            line1.Layer = LayerDay
            line2.Layer = LayerDay
            line3.Layer = LayerDay
            line4.Layer = LayerDay
            acTrans.Commit()
        End Using
    End Sub
    Private Shared Function IsRectangleHorizontalOrVertical(ByVal point1 As Point2d, ByVal point2 As Point2d, ByVal point3 As Point2d, ByVal point4 As Point2d) As String
        Dim vector1 As Vector2d = point2 - point1
        Dim vector2 As Vector2d = point3 - point2
        Dim vector3 As Vector2d = point4 - point3

        ' Kiểm tra vector giữa các điểm
        Dim dotProduct1 As Double = vector1.DotProduct(vector2)
        Dim dotProduct2 As Double = vector2.DotProduct(vector3)

        ' Tính độ dài của các vector
        Dim length1 As Double = vector1.Length
        Dim length2 As Double = vector2.Length
        Dim length3 As Double = vector3.Length

        ' Kiểm tra vector có độ dài khác 0
        If length1 = 0 OrElse length2 = 0 OrElse length3 = 0 Then
            Return "Not a Rectangle"
        End If

        ' Tính góc giữa các vector (đơn vị radians)
        Dim angle1 As Double = vector1.GetAngleTo(vector2)
        Dim angle2 As Double = vector2.GetAngleTo(vector3)

        ' Kiểm tra xem góc giữa các vector có gần bằng 90 độ hay không
        Dim isRightAngle1 As Boolean = Math.Abs(angle1 - Math.PI / 2) < 0.01
        Dim isRightAngle2 As Boolean = Math.Abs(angle2 - Math.PI / 2) < 0.01

        If isRightAngle1 AndAlso isRightAngle2 Then
            ' Cả hai góc đều gần bằng 90 độ, hình chữ nhật đang quay ngang
            Return "Horizontal"
        ElseIf (Not isRightAngle1) AndAlso (Not isRightAngle2) Then
            ' Không có góc nào gần bằng 90 độ, hình chữ nhật đang quay dọc
            Return "Vertical"
        Else
            ' Trường hợp còn lại, không phải hình chữ nhật
            Return "Not a Rectangle"
        End If
    End Function
    Public Shared Sub Ve_Mong_0trenmai(b_bvemong0 As Double, b_hvemong0 As Double, xxoay As Double, yxoay As Double, Layer As String, Linetypescale As Double, TextHight As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do0ngoai(3) As Point2d 'mong 0 trong
        Mang_Toa_Do0ngoai(0) = New Point2d(-b_b0mong / 2, b_h0mong / 2)
        Mang_Toa_Do0ngoai(1) = New Point2d(b_b0mong / 2, b_h0mong / 2)
        Mang_Toa_Do0ngoai(2) = New Point2d(b_b0mong / 2, -b_h0mong / 2)
        Mang_Toa_Do0ngoai(3) = New Point2d(-b_b0mong / 2, -b_h0mong / 2)
        Dim id_mong0ngoai As ObjectId
        id_mong0ngoai = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0ngoai, True)
        Dim Mang_Toa_Do0trong(3) As Point2d 'mong 0 ngoai
        Mang_Toa_Do0trong(0) = New Point2d(-b_b0mong / 2 + b_b0mong / 10, b_h0mong / 2 - b_h0mong / 10)
        Mang_Toa_Do0trong(1) = New Point2d(b_b0mong / 2 - b_b0mong / 10, b_h0mong / 2 - b_h0mong / 10)
        Mang_Toa_Do0trong(2) = New Point2d(b_b0mong / 2 - b_b0mong / 10, -b_h0mong / 2 + b_h0mong / 10)
        Mang_Toa_Do0trong(3) = New Point2d(-b_b0mong / 2 + b_b0mong / 10, -b_h0mong / 2 + b_h0mong / 10)
        Dim id_mong0trong As ObjectId
        id_mong0trong = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do0trong, True)
        'Dim GocXoay As Double = (360 * Math.PI / 180) - Lib_Drawing.mbTinhgoc1(xxoay, yxoay) '' Xoay mong 0
        Dim GocXoay As Double = (-GocXoayMatBang * Math.PI) / 180
        Lib_Drawing.RotateEntity(id_mong0ngoai, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Lib_Drawing.RotateEntity(id_mong0trong, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim Mong0ngoai, Mong0trong As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Mong0ngoai = acTrans.GetObject(id_mong0ngoai, OpenMode.ForWrite)
            Mong0trong = acTrans.GetObject(id_mong0trong, OpenMode.ForWrite)
            Mong0ngoai.Layer = Layer
            Mong0ngoai.LinetypeScale = Linetypescale
            Mong0trong.Layer = Layer
            Mong0trong.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        For i = 0 To 3 Step 1
            Dim diemText As Point2d = Mong0ngoai.GetPoint2dAt(i)
            If (diemText.X > 0) And (diemText.Y > 0) Then
                '' Text 
                Dim TextMong0(2) As Point2d 'mong 0
                TextMong0(0) = New Point2d(diemText.X, diemText.Y)
                TextMong0(1) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + TextHight, b_h0mong / 2 + b_h0mong / 10 + TextHight)
                TextMong0(2) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 3 + TextHight * 9, b_h0mong / 2 + b_h0mong / 10 + TextHight)
                Dim id_TextMong0 As ObjectId
                id_TextMong0 = Lib_Drawing.CreateNewPolyline(TextMong0, False)
                Lib_Drawing.CreateNewMText(New Point3d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 3, b_h0mong / 2 + b_h0mong / 10 + TextHight + TextHight * 2.6, 0), "Móng 0", TextHight) ' nhân với 2.6 để chứ g trong "Móng 0" theo tỉ lệ sẽ ở trên đường kẻ
                'Cao độ mặt đất của móng
                Dim CaoDo As String

                If frmTTC.txtCaoDoMong.Text > 0 Then
                    CaoDo = "+" & Format(frmTTC.txtCaoDoMong.Text, "0.00")
                ElseIf frmTTC.txtCaoDoMong.Text = 0 Then
                    CaoDo = "%%p" & Format(frmTTC.txtCaoDoMong.Text, "0.00")
                Else
                    CaoDo = Format(frmTTC.txtCaoDoMong.Text, "0.00")
                End If
                Lib_Drawing.insertBlock(New Point3d(b_b0mong / 2 + b_b0mong / 10 + TextHight * 12, b_h0mong / 2 + b_h0mong / 10 + TextHight - TextHight * 8, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)

            End If
        Next
    End Sub
    Public Shared Sub VeMong(Toado_x As Double, Toado_y As Double, b_bvemong As Double, b_hvemong As Double, b_bmove As Double, b_hmove As Double, b_a As Double, Text As String, TextHight As Double, LinetypeScale As Double, Layer As String, vitridat As String, LoaiMong As Integer)
        Dim layermong As String = "10"

        'Dim score As Integer
        Dim vuongtrong As Polyline
        Dim vuongngoai As Polyline
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d

        Dim CaoDo As String
        If Text.Contains("1") Then
            b_CaoDoMong = Val(frmTTC.dgvToaDoMong.Rows(0).Cells(3).Value)
        ElseIf Text.Contains("2") Then
            b_CaoDoMong = Val(frmTTC.dgvToaDoMong.Rows(1).Cells(3).Value)
        ElseIf Text.Contains("3") Then
            b_CaoDoMong = Val(frmTTC.dgvToaDoMong.Rows(2).Cells(3).Value)
        ElseIf Text.Contains("4") Then
            b_CaoDoMong = Val(frmTTC.dgvToaDoMong.Rows(3).Cells(3).Value)
        ElseIf Text.Contains("0") Then
            b_CaoDoMong = Val(frmTTC.txtCaoDoMong.Text)
        End If
        If b_CaoDoMong > 0 Then
            CaoDo = "+" & Format(b_CaoDoMong, "00.00")
        ElseIf b_CaoDoMong = 0 Then
            CaoDo = "%%p" & Format(b_CaoDoMong, "00.00")
        Else
            CaoDo = Format(b_CaoDoMong, "00.00")
        End If
        'Lib_Drawing.insertBlock(New Point3d(2000, -hmongchinh, 0), "ct", Tile / 2, "+" & CaoDo)

#Region "Vẽ móng dưới đất"
        If (vitridat = "Dưới đất") Then
            Dim ofset As Double = 100
            If (LoaiMong = 1 - 1) Then
                Dim vuong2 As Polyline
                Dim vuong3 As Polyline
                Dim vuong4 As Polyline
                Dim TileHatch As Double = Math.Max(b_bvemong, b_hvemong) / 10
                Dim line As Line
                If ((Toado_x) <= 0 And (Toado_y) >= 0) Then ' vitri1
                    b_bmove = b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 6 - Math.Min(b_bvemong, b_hvemong) / 6
                    b_hmove = 0
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(1) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(2) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(1) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(2) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    mang_toa_do_1(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d 've 2 duong thang dut doan
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2)
                    Dim id_vuong2 As ObjectId
                    id_vuong2 = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Dim mang_toa_do_3(3) As Point2d 've hinh chu nhat lien doan 
                    mang_toa_do_3(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_3(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuong3 As ObjectId
                    id_vuong3 = Lib_Drawing.CreateNewPolyline(mang_toa_do_3, True)
                    Dim id_line As ObjectId
                    id_line = Lib_Drawing.CreateLine(New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2, 0), New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong2 = acTrans.GetObject(id_vuong2, OpenMode.ForWrite)
                        vuong2.Layer = Layer
                        vuong2.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong3 = acTrans.GetObject(id_vuong3, OpenMode.ForWrite)
                        vuong3.Layer = layermong
                        vuong3.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line = acTrans.GetObject(id_line, OpenMode.ForWrite)
                        line.Layer = Layer
                        line.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    'Dim xclone As Double = Math.Abs(Toado_x) - Math.Abs(-(b_a * Math.Sqrt(3)) / 6)
                    goctg = Lib_Drawing.mbTinhgoc2(Toado_x, Toado_y, 1)
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong3, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 1
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x - b_bvemong * 3 - TextHight, Toado_y + b_hvemong * 3 + TextHight)
                    TextMong1(2) = New Point2d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y + b_hvemong * 3 + TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Dim id_Text As ObjectId
                    'Tên móng
                    id_Text = Lib_Drawing.CreateNewMText(New Point3d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y + b_hvemong * 3 + TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)

                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) 've hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc           
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                ElseIf ((Toado_x) >= 0 And (Toado_y) >= 0) Then 'vitri2
                    b_bmove = b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 6 - Math.Min(b_bvemong, b_hvemong) / 6
                    b_hmove = 0
                    'b_bmove = b_bvemong / 2 - b_hvemong / 5
                    'b_hmove = 0
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(1) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(2) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(1) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(2) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    mang_toa_do_1(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d 've 2 duong thang dut doan
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2)
                    Dim id_vuong2 As ObjectId
                    id_vuong2 = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Dim mang_toa_do_3(3) As Point2d 've hinh chu nhat lien doan 
                    mang_toa_do_3(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_3(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuong3 As ObjectId
                    id_vuong3 = Lib_Drawing.CreateNewPolyline(mang_toa_do_3, True)
                    Dim id_line As ObjectId
                    id_line = Lib_Drawing.CreateLine(New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2, 0), New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong2 = acTrans.GetObject(id_vuong2, OpenMode.ForWrite)
                        vuong2.Layer = Layer
                        vuong2.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong3 = acTrans.GetObject(id_vuong3, OpenMode.ForWrite)
                        vuong3.Layer = layermong
                        vuong3.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line = acTrans.GetObject(id_line, OpenMode.ForWrite)
                        line.Layer = Layer
                        line.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    goctg = Lib_Drawing.mbTinhgoc(Toado_x, Toado_y, 2)
                    Dim gocxoay2 As Double = goctg
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(gocxoay2, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(gocxoay2, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong3, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 2
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x + b_bvemong * 3 + TextHight, Toado_y + b_hvemong * 3 + TextHight)
                    TextMong1(2) = New Point2d(Toado_x + b_bvemong * 3 + TextHight * 9 + TextHight * 3, Toado_y + b_hvemong * 3 + TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Lib_Drawing.CreateNewMText(New Point3d(Toado_x + b_bvemong * 3 + TextHight * 3, Toado_y + b_hvemong * 3 + TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)

                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) 've hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc                    
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                ElseIf ((Toado_x) <= 0 And (Toado_y) <= 0) Then 'vitri4
                    b_bmove = b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 6 - Math.Min(b_bvemong, b_hvemong) / 6
                    b_hmove = 0
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(1) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(2) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(1) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(2) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    mang_toa_do_1(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d 've 2 duong thang dut doan
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2)
                    Dim id_vuong2 As ObjectId
                    id_vuong2 = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Dim mang_toa_do_3(3) As Point2d 've hinh chu nhat lien doan 
                    mang_toa_do_3(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_3(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuong3 As ObjectId
                    id_vuong3 = Lib_Drawing.CreateNewPolyline(mang_toa_do_3, True)
                    Dim id_line As ObjectId
                    id_line = Lib_Drawing.CreateLine(New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2, 0), New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong2 = acTrans.GetObject(id_vuong2, OpenMode.ForWrite)
                        vuong2.Layer = Layer
                        vuong2.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong3 = acTrans.GetObject(id_vuong3, OpenMode.ForWrite)
                        vuong3.Layer = layermong
                        vuong3.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line = acTrans.GetObject(id_line, OpenMode.ForWrite)
                        line.Layer = Layer
                        line.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    Dim xclone As Double = Math.Abs(Toado_x) - Math.Abs(-(b_a * Math.Sqrt(3)) / 6)
                    goctg = Lib_Drawing.mbTinhgoc(xclone, Toado_y, 3)
                    Dim gocxoay2 As Double = goctg
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(gocxoay2, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(gocxoay2, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong3, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))

                    Lib_Drawing.RotateEntity(id_line, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 4
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x - b_bvemong * 3 - TextHight, Toado_y - b_hvemong * 3 - TextHight)
                    TextMong1(2) = New Point2d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y - b_hvemong * 3 - TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    'kaitomajickid
                    Lib_Drawing.CreateNewMText(New Point3d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y - b_hvemong * 3 - TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)

                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) 've hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc                  
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                ElseIf ((Toado_x) >= 0 And (Toado_y) <= 0) Then 'vitri3
                    b_bmove = b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 6 - Math.Min(b_bvemong, b_hvemong) / 6
                    b_hmove = 0
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(1) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(2) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(1) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2 + ofset)
                    mang_toa_do_1(2) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    mang_toa_do_1(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2 - ofset)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d 've 2 duong thang dut doan
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2)
                    Dim id_vuong2 As ObjectId
                    id_vuong2 = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Dim mang_toa_do_3(3) As Point2d 've hinh chu nhat lien doan                    
                    mang_toa_do_3(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_3(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_3(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuong3 As ObjectId
                    id_vuong3 = Lib_Drawing.CreateNewPolyline(mang_toa_do_3, True)
                    Dim id_line As ObjectId
                    id_line = Lib_Drawing.CreateLine(New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y - Math.Min(b_bvemong, b_hvemong) * 1.2, 0), New Point3d(Toado_x - Math.Min(b_bvemong, b_hvemong) / 3, Toado_y + Math.Min(b_bvemong, b_hvemong) * 1.2, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong2 = acTrans.GetObject(id_vuong2, OpenMode.ForWrite)
                        vuong2.Layer = Layer
                        vuong2.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong3 = acTrans.GetObject(id_vuong3, OpenMode.ForWrite)
                        vuong3.Layer = layermong
                        vuong3.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using

                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line = acTrans.GetObject(id_line, OpenMode.ForWrite)
                        line.Layer = Layer
                        line.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    goctg = Lib_Drawing.mbTinhgoc(Toado_x, Toado_y, 4)
                    Dim gocxoay2 As Double = goctg
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(gocxoay2, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(gocxoay2, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuong3, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 3
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x + b_bvemong * 3 + TextHight, Toado_y - b_hvemong * 3 - TextHight)
                    TextMong1(2) = New Point2d(Toado_x + b_bvemong * 3 + TextHight * 3 + TextHight * 9, Toado_y - b_hvemong * 3 - TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Lib_Drawing.CreateNewMText(New Point3d(Toado_x + b_bvemong * 3 + TextHight * 3, Toado_y - b_hvemong * 3 - TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) ' ve hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc                    
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                End If


            ElseIf (LoaiMong = 2 - 1) Then
                Dim line1, line11 As Line '2 duong giao nhau hinh tron
                Dim line2, line22 As Line
                Dim id_line1, id_line2, id_line11, id_line22 As ObjectId
                Dim vuong1 As Polyline 'VeMong
                Dim vuong4 As Polyline 'Be tong chong co moc
                Dim TileHatch As Double = Math.Max(b_bvemong, b_hvemong) / 10
                If ((Toado_x) <= 0 And (Toado_y) >= 0) Then ' vitri1
                    b_bmove = (b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    b_hmove = (b_hvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y + b_hvemong / 2 + ofset)
                    mang_toa_do(1) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y + b_hvemong / 2 + ofset)
                    mang_toa_do(2) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y + b_hvemong / 2 - b_hvemong * 3 - ofset)
                    mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y + b_hvemong / 2 - b_hvemong * 3 - ofset)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_1(1) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2)
                    mang_toa_do_1(2) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2 - b_hvemong * 3)
                    mang_toa_do_1(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2 - b_hvemong * 3)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuongmong As ObjectId
                    id_vuongmong = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong1 = acTrans.GetObject(id_vuongmong, OpenMode.ForWrite)
                        vuong1.Layer = layermong
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    If b_somong = 3 Then
                        'Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y, 0), New Point3d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2, 0))
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, True)
                    Else
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, False)
                    End If
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongmong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 1
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x - b_bvemong * 3 - TextHight, Toado_y + b_hvemong * 3 + TextHight)
                    TextMong1(2) = New Point2d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y + b_hvemong * 3 + TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Dim id_Text As ObjectId
                    id_Text = Lib_Drawing.CreateNewMText(New Point3d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y + b_hvemong * 3 + TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) ' ve hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    'Ve day net dung trong mong
                    id_line1 = Lib_Drawing.CreateLine(New Point3d(Toado_x + b_bvemong / 2, Toado_y, 0), New Point3d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y, 0))
                    id_line11 = Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y - b_hvemong / 2, 0), New Point3d(Toado_x, Toado_y + b_hvemong / 2 - b_hvemong * 3, 0))
                    id_line2 = Lib_Drawing.CreateLine(New Point3d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2, 0), New Point3d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2, 0))
                    id_line22 = Lib_Drawing.CreateLine(New Point3d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2, 0), New Point3d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2 - b_hvemong * 3, 0))
                    Lib_Drawing.RotateEntity(id_line1, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line11, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line22, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc           
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line1 = acTrans.GetObject(id_line1, OpenMode.ForWrite)
                        line11 = acTrans.GetObject(id_line11, OpenMode.ForWrite)
                        line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
                        line22 = acTrans.GetObject(id_line22, OpenMode.ForWrite)
                        line1.Layer = Layer
                        line11.Layer = Layer
                        line2.Layer = Layer
                        line22.Layer = Layer
                        line1.LinetypeScale = LinetypeScale
                        line11.LinetypeScale = LinetypeScale
                        line2.LinetypeScale = LinetypeScale
                        line22.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                ElseIf ((Toado_x) >= 0 And (Toado_y) >= 0) Then 'vitri2
                    b_bmove = (b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    b_hmove = (b_hvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x + b_bvemong / 2 + ofset, Toado_y + b_hvemong / 2 + ofset)
                    mang_toa_do(1) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3 - ofset, Toado_y + b_hvemong / 2 + ofset)
                    mang_toa_do(2) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3 - ofset, Toado_y + b_hvemong / 2 - b_hvemong * 3 - ofset)
                    mang_toa_do(3) = New Point2d(Toado_x + b_bvemong / 2 + ofset, Toado_y + b_hvemong / 2 - b_hvemong * 3 - ofset)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_1(1) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y + b_hvemong / 2)
                    mang_toa_do_1(2) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y + b_hvemong / 2 - b_hvemong * 3)
                    mang_toa_do_1(3) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2 - b_hvemong * 3)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuongmong As ObjectId
                    id_vuongmong = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong1 = acTrans.GetObject(id_vuongmong, OpenMode.ForWrite)
                        vuong1.Layer = layermong
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    If b_somong = 3 Then
                        'Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y, 0), New Point3d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2, 0))
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, True)
                    Else
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, False)
                    End If
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongmong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 1
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x + b_bvemong * 3 + TextHight, Toado_y + b_hvemong * 3 + TextHight)
                    TextMong1(2) = New Point2d(Toado_x + b_bvemong * 3 + TextHight * 9 + TextHight * 3, Toado_y + b_hvemong * 3 + TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Dim id_Text As ObjectId
                    id_Text = Lib_Drawing.CreateNewMText(New Point3d(Toado_x + b_bvemong * 3 + TextHight * 3, Toado_y + b_hvemong * 3 + TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) ' ve hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    'Ve day net dung trong mong
                    id_line1 = Lib_Drawing.CreateLine(New Point3d(Toado_x - b_bvemong / 2, Toado_y, 0), New Point3d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y, 0))
                    id_line11 = Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y - b_hvemong / 2, 0), New Point3d(Toado_x, Toado_y + b_hvemong / 2 - b_hvemong * 3, 0))
                    id_line2 = Lib_Drawing.CreateLine(New Point3d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2, 0), New Point3d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y - b_hvemong / 2, 0))
                    id_line22 = Lib_Drawing.CreateLine(New Point3d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2, 0), New Point3d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2 - b_hvemong * 3, 0))
                    Lib_Drawing.RotateEntity(id_line1, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line11, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line22, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line1 = acTrans.GetObject(id_line1, OpenMode.ForWrite)
                        line11 = acTrans.GetObject(id_line11, OpenMode.ForWrite)
                        line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
                        line22 = acTrans.GetObject(id_line22, OpenMode.ForWrite)
                        line1.Layer = Layer
                        line11.Layer = Layer
                        line2.Layer = Layer
                        line22.Layer = Layer
                        line1.LinetypeScale = LinetypeScale
                        line11.LinetypeScale = LinetypeScale
                        line2.LinetypeScale = LinetypeScale
                        line22.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc                    
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                ElseIf ((Toado_x) <= 0 And (Toado_y) <= 0) Then 'vitri4        
                    b_bmove = (b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    b_hmove = (b_hvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y - b_hvemong / 2 - ofset)
                    mang_toa_do(1) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y - b_hvemong / 2 - ofset)
                    mang_toa_do(2) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3 + ofset, Toado_y - b_hvemong / 2 + b_hvemong * 3 + ofset)
                    mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 - ofset, Toado_y - b_hvemong / 2 + b_hvemong * 3 + ofset)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_1(1) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2)
                    mang_toa_do_1(2) = New Point2d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y - b_hvemong / 2 + b_hvemong * 3)
                    mang_toa_do_1(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2 + b_hvemong * 3)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuongmong As ObjectId
                    id_vuongmong = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong1 = acTrans.GetObject(id_vuongmong, OpenMode.ForWrite)
                        vuong1.Layer = layermong
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    If b_somong = 3 Then
                        'Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y, 0), New Point3d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2, 0))
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, True)
                    Else
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, False)
                    End If
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongmong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 4
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x - b_bvemong * 3 - TextHight, Toado_y - b_hvemong * 3 - TextHight)
                    TextMong1(2) = New Point2d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y - b_hvemong * 3 - TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Dim id_Text As ObjectId
                    id_Text = Lib_Drawing.CreateNewMText(New Point3d(Toado_x - b_bvemong * 3 - TextHight * 9 - TextHight * 3, Toado_y - b_hvemong * 3 - TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)

                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) ' ve hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    'Ve day net dung trong mong
                    id_line1 = Lib_Drawing.CreateLine(New Point3d(Toado_x + b_bvemong / 2, Toado_y, 0), New Point3d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y, 0))
                    id_line11 = Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y + b_hvemong / 2, 0), New Point3d(Toado_x, Toado_y - b_hvemong / 2 + b_hvemong * 3, 0))
                    id_line2 = Lib_Drawing.CreateLine(New Point3d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2, 0), New Point3d(Toado_x - b_bvemong / 2 + b_bvemong * 3, Toado_y + b_hvemong / 2, 0))
                    id_line22 = Lib_Drawing.CreateLine(New Point3d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2, 0), New Point3d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2 + b_hvemong * 3, 0))
                    Lib_Drawing.RotateEntity(id_line1, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line11, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line22, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line1 = acTrans.GetObject(id_line1, OpenMode.ForWrite)
                        line11 = acTrans.GetObject(id_line11, OpenMode.ForWrite)
                        line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
                        line22 = acTrans.GetObject(id_line22, OpenMode.ForWrite)
                        line1.Layer = Layer
                        line11.Layer = Layer
                        line2.Layer = Layer
                        line22.Layer = Layer
                        line1.LinetypeScale = LinetypeScale
                        line11.LinetypeScale = LinetypeScale
                        line2.LinetypeScale = LinetypeScale
                        line22.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc                  
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                ElseIf ((Toado_x) >= 0 And (Toado_y) <= 0) Then 'vitri3
                    b_bmove = (b_bvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    b_hmove = (b_hvemong / 2 - Math.Min(b_bvemong, b_hvemong) / 10 - Math.Min(b_bvemong, b_hvemong) / 10)
                    Dim mang_toa_do(3) As Point2d
                    mang_toa_do(0) = New Point2d(Toado_x + b_bvemong / 2 + ofset, Toado_y - b_hvemong / 2 - ofset)
                    mang_toa_do(1) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3 - ofset, Toado_y - b_hvemong / 2 - ofset)
                    mang_toa_do(2) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3 - ofset, Toado_y - b_hvemong / 2 + b_hvemong * 3 + ofset)
                    mang_toa_do(3) = New Point2d(Toado_x + b_bvemong / 2 + ofset, Toado_y - b_hvemong / 2 + b_hvemong * 3 + ofset)
                    Dim id_vuongngoai As ObjectId
                    id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                    Dim mang_toa_do_1(3) As Point2d
                    mang_toa_do_1(0) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_1(1) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y - b_hvemong / 2)
                    mang_toa_do_1(2) = New Point2d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y - b_hvemong / 2 + b_hvemong * 3)
                    mang_toa_do_1(3) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2 + b_hvemong * 3)
                    Dim id_vuongtrong As ObjectId
                    id_vuongtrong = Lib_Drawing.CreateNewPolyline(mang_toa_do_1, True)
                    Dim mang_toa_do_2(3) As Point2d
                    mang_toa_do_2(0) = New Point2d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(1) = New Point2d(Toado_x + b_bvemong / 2, Toado_y + b_hvemong / 2)
                    mang_toa_do_2(2) = New Point2d(Toado_x + b_bvemong / 2, Toado_y - b_hvemong / 2)
                    mang_toa_do_2(3) = New Point2d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2)
                    Dim id_vuongmong As ObjectId
                    id_vuongmong = Lib_Drawing.CreateNewPolyline(mang_toa_do_2, True)
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongtrong = acTrans.GetObject(id_vuongtrong, OpenMode.ForWrite)
                        vuongtrong.Layer = Layer
                        vuongtrong.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                        vuongngoai.Layer = Layer
                        vuongngoai.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        vuong1 = acTrans.GetObject(id_vuongmong, OpenMode.ForWrite)
                        vuong1.Layer = layermong
                        acTrans.Commit()
                    End Using
                    Dim goctg As Double
                    If b_somong = 3 Then
                        'Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y, 0), New Point3d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2, 0))
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, True)
                    Else
                        goctg = Lib_Drawing.mbTinhgoc3(Toado_x, Toado_y, False)
                    End If
                    Lib_Drawing.RotateEntity(id_vuongngoai, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongtrong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_vuongmong, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Dim TextMong1(2) As Point2d 'mong vi tri so 1
                    TextMong1(0) = New Point2d(Toado_x, Toado_y)
                    TextMong1(1) = New Point2d(Toado_x + b_bvemong * 3 + TextHight, Toado_y - b_hvemong * 3 - TextHight)
                    TextMong1(2) = New Point2d(Toado_x + b_bvemong * 3 + TextHight * 9 + TextHight * 3, Toado_y - b_hvemong * 3 - TextHight)
                    Dim id_TextMong1 As ObjectId
                    id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                    Dim id_Text As ObjectId
                    id_Text = Lib_Drawing.CreateNewMText(New Point3d(Toado_x + b_bvemong * 3 + TextHight * 3, Toado_y - b_hvemong * 3 - TextHight + TextHight * 2.6, 0), Text, TextHight)
                    'Cao độ mặt đất của móng
                    taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
                    Dim id_c As ObjectId
                    id_c = Lib_Drawing.CreateCircle(New Point3d(Toado_x, Toado_y, 0), Math.Min(b_bvemong, b_hvemong) / 3) ' ve hinh tron
                    Dim id_coll As New ObjectIdCollection
                    id_coll.Add(id_c)
                    Lib_Drawing.CreateHatch_1MienBao(id_coll, "SOLID", 0, 1)
                    'Ve day net dung trong mong
                    id_line1 = Lib_Drawing.CreateLine(New Point3d(Toado_x - b_bvemong / 2, Toado_y, 0), New Point3d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y, 0))
                    id_line11 = Lib_Drawing.CreateLine(New Point3d(Toado_x, Toado_y + b_hvemong / 2, 0), New Point3d(Toado_x, Toado_y - b_hvemong / 2 + b_hvemong * 3, 0))
                    id_line2 = Lib_Drawing.CreateLine(New Point3d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2, 0), New Point3d(Toado_x + b_bvemong / 2 - b_bvemong * 3, Toado_y + b_hvemong / 2, 0))
                    id_line22 = Lib_Drawing.CreateLine(New Point3d(Toado_x - b_bvemong / 2, Toado_y + b_hvemong / 2, 0), New Point3d(Toado_x - b_bvemong / 2, Toado_y - b_hvemong / 2 + b_hvemong * 3, 0))
                    Lib_Drawing.RotateEntity(id_line1, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line11, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line2, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Lib_Drawing.RotateEntity(id_line22, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line1 = acTrans.GetObject(id_line1, OpenMode.ForWrite)
                        line11 = acTrans.GetObject(id_line11, OpenMode.ForWrite)
                        line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
                        line22 = acTrans.GetObject(id_line22, OpenMode.ForWrite)
                        line1.Layer = Layer
                        line11.Layer = Layer
                        line2.Layer = Layer
                        line22.Layer = Layer
                        line1.LinetypeScale = LinetypeScale
                        line11.LinetypeScale = LinetypeScale
                        line2.LinetypeScale = LinetypeScale
                        line22.LinetypeScale = LinetypeScale
                        acTrans.Commit()
                    End Using
                    If frmTTC.chkBeTongCoMoc.Checked = True Then
                        Dim mang_toa_do_4(3) As Point2d 've hinh chu nhat be tong chong co moc                    
                        mang_toa_do_4(0) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(1) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y + b_hvemong * 1.5)
                        mang_toa_do_4(2) = New Point2d(Toado_x + b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        mang_toa_do_4(3) = New Point2d(Toado_x - b_bvemong * 1.5, Toado_y - b_hvemong * 1.5)
                        Dim id_vuong4 As ObjectId
                        id_vuong4 = Lib_Drawing.CreateNewPolyline(mang_toa_do_4, True)
                        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                            vuong4 = acTrans.GetObject(id_vuong4, OpenMode.ForWrite)
                            vuong4.Layer = layermong
                            vuong4.LinetypeScale = LinetypeScale
                            acTrans.Commit()
                        End Using
                        Lib_Drawing.RotateEntity(id_vuong4, Matrix3d.Rotation(goctg, curUCS.Zaxis, New Point3d(Toado_x, Toado_y, 0)))
                        Dim id_coll2 As New ObjectIdCollection
                        id_coll2.Add(id_vuong4)
                        Lib_Drawing.CreateHatch_2MienBao(id_coll2, id_coll, "AR-CONC", 0, TileHatch)
                    End If
                End If

            Else
                '
            End If
#End Region
#Region "Vẽ móng trên mái"
        ElseIf (vitridat = "Trên mái") Then
            If ((Toado_x) <= 0 And (Toado_y) >= 0) Then ' vitri1
                b_bmove = 0
                b_hmove = 0
                Dim mang_toa_do(3) As Point2d
                mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(1) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(2) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                Dim id_vuongngoai As ObjectId
                id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                    vuongngoai.Layer = Layer
                    vuongngoai.LinetypeScale = LinetypeScale
                    acTrans.Commit()
                End Using
                Dim TextMong1(2) As Point2d 'mong vi tri so 1
                TextMong1(0) = New Point2d(Toado_x, Toado_y)
                TextMong1(1) = New Point2d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight)
                TextMong1(2) = New Point2d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight * 9 - TextHight * 3, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight)
                Dim id_TextMong1 As ObjectId
                id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                Dim id_Text As ObjectId
                id_Text = Lib_Drawing.CreateNewMText(New Point3d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight * 9 - TextHight * 3, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight + TextHight * 2.6, 0), Text, TextHight)
                'Cao độ mặt đất của móng
                'Lib_Drawing.insertBlock(New Point3d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight * 9 - TextHight, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight - TextHight * 8, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)
                taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
            ElseIf ((Toado_x) >= 0 And (Toado_y) >= 0) Then 'vitri2
                b_bmove = 0
                b_hmove = 0
                Dim mang_toa_do(3) As Point2d
                mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(1) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(2) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                Dim id_vuongngoai As ObjectId
                id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                    vuongngoai.Layer = Layer
                    vuongngoai.LinetypeScale = 5
                    acTrans.Commit()
                End Using
                Dim TextMong1(2) As Point2d 'mong vi tri so 2
                TextMong1(0) = New Point2d(Toado_x, Toado_y)
                TextMong1(1) = New Point2d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight)
                TextMong1(2) = New Point2d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight * 9 + TextHight * 3, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight)
                Dim id_TextMong1 As ObjectId
                id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                Lib_Drawing.CreateNewMText(New Point3d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight * 3, Toado_y + b_hvemong / 2 + b_hvemong / 10 + TextHight + TextHight * 2.6, 0), Text, TextHight)
                'Cao độ mặt đất của móng
                taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
            ElseIf ((Toado_x) <= 0 And (Toado_y) <= 0) Then 'vitri4
                b_bmove = 0
                b_hmove = 0
                Dim mang_toa_do(3) As Point2d
                mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(1) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(2) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                Dim id_vuongngoai As ObjectId
                id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                    vuongngoai.Layer = Layer
                    vuongngoai.LinetypeScale = 5
                    acTrans.Commit()
                End Using
                Dim TextMong1(2) As Point2d 'mong vi tri so 4
                TextMong1(0) = New Point2d(Toado_x, Toado_y)
                TextMong1(1) = New Point2d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight)
                TextMong1(2) = New Point2d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight * 9 - TextHight * 3, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight)
                Dim id_TextMong1 As ObjectId
                id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                Lib_Drawing.CreateNewMText(New Point3d(Toado_x - b_bvemong / 2 - b_bvemong / 10 - TextHight * 9 - TextHight * 3, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight + TextHight * 2.6, 0), Text, TextHight)
                taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)

            ElseIf ((Toado_x) >= 0 And (Toado_y) <= 0) Then 'vitri3
                b_bmove = 0
                b_hmove = 0
                Dim mang_toa_do(3) As Point2d
                mang_toa_do(0) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(1) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y + b_hvemong / 2 + b_hmove)
                mang_toa_do(2) = New Point2d(Toado_x + b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                mang_toa_do(3) = New Point2d(Toado_x - b_bvemong / 2 + b_bmove, Toado_y - b_hvemong / 2 + b_hmove)
                Dim id_vuongngoai As ObjectId
                id_vuongngoai = Lib_Drawing.CreateNewPolyline(mang_toa_do, True)
                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    vuongngoai = acTrans.GetObject(id_vuongngoai, OpenMode.ForWrite)
                    vuongngoai.Layer = Layer
                    vuongngoai.LinetypeScale = 5
                    acTrans.Commit()
                End Using
                Dim TextMong1(2) As Point2d 'mong vi tri so 3
                TextMong1(0) = New Point2d(Toado_x, Toado_y)
                TextMong1(1) = New Point2d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight)
                TextMong1(2) = New Point2d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight * 3 + TextHight * 9, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight)
                Dim id_TextMong1 As ObjectId
                id_TextMong1 = Lib_Drawing.CreateNewPolyline(TextMong1, False)
                Lib_Drawing.CreateNewMText(New Point3d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight * 3, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight + TextHight * 2.6, 0), Text, TextHight)
                'Cao độ mặt đất của móng
                taoblockcaotrinhmong(Toado_x, Toado_y, b_bvemong, TextHight, b_hvemong, CaoDo)
            End If
        Else
            '
        End If
#End Region
    End Sub
    Private Shared Sub taoblockcaotrinhmong(Toado_x As Double, Toado_y As Double, b_bvemong As Double, TextHight As Double, b_hvemong As Double, CaoDo As String)
        If Toado_x >= 0 And Toado_y >= 0 Then
            Lib_Drawing.insertBlock(New Point3d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight * 22, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)

        ElseIf Toado_x >= 0 And Toado_y <= 0 Then
            Lib_Drawing.insertBlock(New Point3d(Toado_x + b_bvemong / 2 + b_bvemong / 10 + TextHight * 22, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)

        ElseIf Toado_x <= 0 And Toado_y <= 0 Then
            Lib_Drawing.insertBlock(New Point3d(Toado_x + b_bvemong / 2 + b_bvemong / 10 - TextHight * 22, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)

        ElseIf Toado_x <= 0 And Toado_y >= 0 Then
            Lib_Drawing.insertBlock(New Point3d(Toado_x + b_bvemong / 2 + b_bvemong / 10 - TextHight * 22, Toado_y - b_hvemong / 2 - b_hvemong / 10 - TextHight, 0), "CaoTrinhMatBang", TiLeChu, CaoDo)

        End If
    End Sub
    Public Shared Sub Ga_Chong_Xoay_MB_TamGiac(CanhTamGiac As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, loaiday As Integer)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do5(2) As Point2d ' ga chong xoay tam giac  
        Mang_Toa_Do5(0) = New Point2d((b_a * Math.Sqrt(3)) / 3, b_a)
        Mang_Toa_Do5(1) = New Point2d((b_a * Math.Sqrt(3)) / 3, -b_a)
        Mang_Toa_Do5(2) = New Point2d(-(b_a * Math.Sqrt(3) * 2) / 3, 0)
        Dim id_cottamgiac As ObjectId
        id_cottamgiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
#Region "Nối dây cho gá chống xoay loại 4 móng"
        If (loaiday = 4) Then
            'Dim GocXoay As Double = (360 * Math.PI / 180) - Lib_Drawing.mbTinhgoc1(0, 0) 'xoay ga chong xoay cot tam giac
            Dim Goc As Double = (GocXoayMatBang * (Math.PI)) / 180
            Dim GocXoay As Double
            If ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 Then
                Dim GocXoayCoGa As Double = Goc
                If MongNoiChung1 = "Móng 1, Móng 2" Then
                    'GocXoay = GocXoayCoGa - Math.PI / 2
                    If x1 >= 0 And y1 >= 0 Then
                        GocXoay = 0
                    ElseIf x1 >= 0 And y1 <= 0 Then
                        GocXoay = -Math.PI / 2
                    ElseIf x1 <= 0 And y1 >= 0 Then
                        GocXoay = Math.PI / 2
                    Else
                        GocXoay = -Math.PI
                    End If
                ElseIf MongNoiChung1 = "Móng 2, Móng 3" Then
                    'GocXoay = GocXoayCoGa - Math.PI / 2
                    If x2 >= 0 And y2 >= 0 Then
                        GocXoay = 0
                    ElseIf x2 >= 0 And y2 <= 0 Then
                        GocXoay = -Math.PI / 2
                    ElseIf x2 <= 0 And y2 >= 0 Then
                        GocXoay = Math.PI / 2
                    Else
                        GocXoay = -Math.PI
                    End If
                ElseIf MongNoiChung1 = "Móng 3, Móng 4" Then
                    'GocXoay = GocXoayCoGa - Math.PI / 2
                    If x3 >= 0 And y3 >= 0 Then
                        GocXoay = 0
                    ElseIf x3 >= 0 And y3 <= 0 Then
                        GocXoay = -Math.PI / 2
                    ElseIf x3 <= 0 And y3 >= 0 Then
                        GocXoay = Math.PI / 2
                    Else
                        GocXoay = -Math.PI
                    End If
                ElseIf MongNoiChung1 = "Móng 4, Móng 1" Then
                    'GocXoay = GocXoayCoGa - Math.PI / 2
                    If x1 >= 0 And y1 >= 0 Then
                        GocXoay = Math.PI / 2
                    ElseIf x1 >= 0 And y1 <= 0 Then
                        GocXoay = 0
                    ElseIf x1 <= 0 And y1 >= 0 Then
                        GocXoay = -Math.PI
                    Else
                        GocXoay = -Math.PI / 2
                    End If
                Else
                    GocXoay = GocXoayCoGa
                End If
            Else
                GocXoay = Goc
            End If
            Lib_Drawing.RotateEntity(id_cottamgiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
            Dim cottamgiac As Polyline
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                cottamgiac = acTrans.GetObject(id_cottamgiac, OpenMode.ForWrite)
                cottamgiac.Layer = Layer
                cottamgiac.LinetypeScale = Linetypescale
                acTrans.Commit()
            End Using

            Dim diem1 As Point2d = cottamgiac.GetPoint2dAt(0)
            Dim diem2 As Point2d = cottamgiac.GetPoint2dAt(1)
            Dim diem3 As Point2d = cottamgiac.GetPoint2dAt(2)
            'Dim idcricle1 As ObjectId = Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), 50)
            'Dim idcricle2 As ObjectId = Lib_Drawing.CreateCircle(New Point3d(diem2.X, diem2.Y, 0), 100)
            Dim Xve1 As Double = Math.Round((diem1.X), 3)
            Dim Yve1 As Double = Math.Round((diem1.Y), 3)
            Dim Xve2 As Double = Math.Round((diem2.X), 3)
            Dim Yve2 As Double = Math.Round((diem2.Y), 3)
            Dim Xve3 As Double = Math.Round((diem3.X), 3)
            Dim Yve3 As Double = Math.Round((diem3.Y), 3)
            Dim ID_Line1 As ObjectId ' day mong 1
            Dim line1 As Line
            Dim ID_Line2 As ObjectId ' day mong 2
            Dim line2 As Line
            Dim ID_Line3 As ObjectId ' day mong 3
            Dim line3 As Line
            Dim ID_Line4 As ObjectId ' day mong 4
            Dim line4 As Line
            Dim ID_Line11 As ObjectId ' day mong 1
            Dim line11 As Line
            Dim ID_Line22 As ObjectId ' day mong 2
            Dim line22 As Line
            Dim ID_Line33 As ObjectId ' day mong 3
            Dim line33 As Line
            Dim ID_Line44 As ObjectId ' day mong 4
            Dim line44 As Line
            Dim listMongDaNoiDay As New List(Of String)
            If IndexNoiDay1 <> -1 Then
                If MongNoiChung1 = "Móng 1, Móng 2" Then
                    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                    listMongDaNoiDay.Add("Móng 1")
                    listMongDaNoiDay.Add("Móng 2")
                ElseIf MongNoiChung1 = "Móng 2, Móng 3" Then
                    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                    listMongDaNoiDay.Add("Móng 2")
                    listMongDaNoiDay.Add("Móng 3")
                ElseIf MongNoiChung1 = "Móng 3, Móng 4" Then
                    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                    listMongDaNoiDay.Add("Móng 3")
                    listMongDaNoiDay.Add("Móng 4")
                ElseIf MongNoiChung1 = "Móng 4, Móng 1" Then
                    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                    listMongDaNoiDay.Add("Móng 4")
                    listMongDaNoiDay.Add("Móng 1")
                Else
                End If
                If KiemTraNoiDayCoGa(listMongDaNoiDay, "Móng 1") = True Then
                Else
                    If x1 * diem1.X >= 0 Or y1 * diem1.Y >= 0 Then
                        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ElseIf x1 * diem2.X >= 0 Or y1 * diem2.Y >= 0 Then
                        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                    Else

                    End If
                End If


                If KiemTraNoiDayCoGa(listMongDaNoiDay, "Móng 2") = True Then

                Else
                    If x2 * diem1.X >= 0 Or y2 * diem1.Y >= 0 Then
                        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ElseIf x2 * diem2.X >= 0 Or y2 * diem2.Y >= 0 Then
                        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                    Else

                    End If
                End If


                If KiemTraNoiDayCoGa(listMongDaNoiDay, "Móng 3") = True Then
                Else
                    If x3 * diem1.X >= 0 Or y3 * diem1.Y >= 0 Then
                        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ElseIf x3 * diem2.X >= 0 Or y3 * diem2.Y >= 0 Then
                        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                    Else

                    End If
                End If

                If KiemTraNoiDayCoGa(listMongDaNoiDay, "Móng 4") = True Then
                Else
                    If x4 * diem1.X >= 0 Or y4 * diem1.Y >= 0 Then
                        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                    ElseIf x4 * diem2.X >= 0 Or y4 * diem2.Y >= 0 Then
                        ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                        ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                    Else

                    End If
                End If

            Else
                '
                If (Xve3 > 0) And (Yve3 > 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1) >= 0 And (y1 >= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Yve1 >= Yve2 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 > 0) And (Yve3 < 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1) >= 0 And (y1 >= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 < 0) And (Yve3 < 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 >= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If

                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 < 0) And (Yve3 > 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 = 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 = 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 >= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Yve2 > Yve1 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 > 0) And (Yve3 = 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 >= 0) Then
                        If Yve1 > Yve2 Then

                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Yve1 > Yve2 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 = 0) And (Yve3 > 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Xve1 < 0 And Xve2 > 0 Then

                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Xve1 < 0 And Xve2 > 0 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 >= 0) Then
                        If Xve1 < 0 And Xve2 > 0 Then

                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Xve1 < 0 And Xve2 > 0 Then

                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 = 0) And (Yve3 < 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Xve1 > 0 And Xve2 < 0 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            ElseIf (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Xve1 > 0 And Xve2 < 0 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 >= 0) Then
                        If Xve1 > 0 And Xve2 < 0 Then
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Xve1 > 0 And Xve2 < 0 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    End If
                ElseIf (Xve3 < 0) And (Yve3 = 0) Then
                    If (x1 <= 0) And (y1 <= 0) Then
                        If Yve1 < Yve2 Then
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 <= 0) And (y1 >= 0) Then
                        If Yve1 <= Yve2 Then
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1) >= 0 And (y1 >= 0) Then
                        If Yve1 <= Yve2 Then
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                            Else

                            End If
                        End If
                    ElseIf (x1 >= 0) And (y1 <= 0) Then
                        If Yve1 <= Yve2 Then
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else

                            End If
                        Else
                            If (x2 >= 0) And (y2 >= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                            ElseIf (x2 <= 0) And (y2 <= 0) Then
                                ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
                                ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
                                ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
                                ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
                            Else
                            End If
                        End If
                    End If
                End If
            End If

            'ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem3.X, diem3.Y, 0))
            'ID_Line11 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(diem1.X, diem1.Y, 0))
            'ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem3.X, diem3.Y, 0))
            'ID_Line22 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(diem2.X, diem2.Y, 0))
            'ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem2.X, diem2.Y, 0))
            'ID_Line33 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(diem1.X, diem1.Y, 0))
            'ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem1.X, diem1.Y, 0))
            'ID_Line44 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(diem2.X, diem2.Y, 0))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
                line1.Layer = LayerDay
                line2.Layer = LayerDay
                line3.Layer = LayerDay
                line4.Layer = LayerDay
                line11 = acTrans.GetObject(ID_Line11, OpenMode.ForWrite)
                line22 = acTrans.GetObject(ID_Line22, OpenMode.ForWrite)
                line33 = acTrans.GetObject(ID_Line33, OpenMode.ForWrite)
                line44 = acTrans.GetObject(ID_Line44, OpenMode.ForWrite)
                line11.Layer = LayerDay
                line22.Layer = LayerDay
                line33.Layer = LayerDay
                line44.Layer = LayerDay
                acTrans.Commit()
            End Using
#End Region
#Region "Nối dây cho gá chống xoay loại 3 móng"
        ElseIf (loaiday = 3) Then
            Dim GocXoay As Double = Lib_Drawing.mbTinhgoc1Update(xxoay, yxoay) 'xoay ga chong xoay cot tam giac
            Lib_Drawing.RotateEntity(id_cottamgiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
            Dim cottamgiac As Polyline
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                cottamgiac = acTrans.GetObject(id_cottamgiac, OpenMode.ForWrite)
                cottamgiac.Layer = Layer
                cottamgiac.LinetypeScale = Linetypescale
                acTrans.Commit()
            End Using
            Dim ID_Line1 As ObjectId ' day mong 1
            Dim line1 As Line
            Dim ID_Line2 As ObjectId ' day mong 2
            Dim line2 As Line
            Dim ID_Line3 As ObjectId ' day mong 3
            Dim line3 As Line
            For i = 0 To 2 Step 1
                Dim DiemNoiDayGa1 As Point2d = cottamgiac.GetPoint2dAt(i)
                If ((Math.Round((DiemNoiDayGa1.X), 2) * x1) < 0 And (Math.Round((DiemNoiDayGa1.Y), 2) * y1) < 0) Or ((Math.Round((DiemNoiDayGa1.X), 2) * x1) < 0 And (Math.Round((DiemNoiDayGa1.Y), 2) * y1) = 0) Or ((Math.Round((DiemNoiDayGa1.X), 2) * x1) = 0 And Math.Round((DiemNoiDayGa1.Y), 2) * y1 < 0) Then
                Else
                    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(DiemNoiDayGa1.X, DiemNoiDayGa1.Y, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                        line1.Layer = LayerDay
                        acTrans.Commit()
                    End Using
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDayGa2 As Point2d = cottamgiac.GetPoint2dAt(i)
                If ((Math.Round((DiemNoiDayGa2.X), 2) * x2) < 0 And (Math.Round((DiemNoiDayGa2.Y), 2) * y2) < 0) Or (Math.Round((DiemNoiDayGa2.X), 2) * x2) < 0 And (Math.Round((DiemNoiDayGa2.Y), 2) * y2 = 0) Or ((Math.Round((DiemNoiDayGa2.X), 2) * x2) = 0 And (Math.Round((DiemNoiDayGa2.Y), 2) * y2) < 0) Then

                Else
                    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(DiemNoiDayGa2.X, DiemNoiDayGa2.Y, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                        line2.Layer = LayerDay
                        acTrans.Commit()
                    End Using
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDayGa3 As Point2d = cottamgiac.GetPoint2dAt(i)
                If ((Math.Round((DiemNoiDayGa3.X), 2) * x3) < 0 And (Math.Round((DiemNoiDayGa3.Y), 2) * y3) < 0) Or ((Math.Round((DiemNoiDayGa3.X), 2) * x3) < 0 And (Math.Round((DiemNoiDayGa3.Y), 2) * y3) = 0) Or ((Math.Round((DiemNoiDayGa3.X), 2) * x3) = 0 And (Math.Round((DiemNoiDayGa3.Y), 2) * y3) < 0) Then

                Else
                    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(DiemNoiDayGa3.X, DiemNoiDayGa3.Y, 0))
                    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                        line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                        line3.Layer = LayerDay
                        acTrans.Commit()
                    End Using
                End If
            Next
        End If
#End Region
    End Sub
    Public Shared Sub Ve_Cot_Tam_Giac_update(CanhTamGiac As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, loaiday As Integer)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do5(2) As Point2d ' cot tam giac 
        Mang_Toa_Do5(0) = New Point2d(-(b_a * Math.Sqrt(3)) / 6, b_a / 2)
        Mang_Toa_Do5(1) = New Point2d((b_a * Math.Sqrt(3)) / 3, 0)
        Mang_Toa_Do5(2) = New Point2d(-(b_a * Math.Sqrt(3)) / 6, -b_a / 2)
        Dim id_cottamgiac As ObjectId
        id_cottamgiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
        Dim GocXoay As Double = Lib_Drawing.mbTinhgoc1Update(xxoay, yxoay) ''xoay cot tam giac
        Lib_Drawing.RotateEntity(id_cottamgiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim cottamgiac As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            cottamgiac = acTrans.GetObject(id_cottamgiac, OpenMode.ForWrite)
            cottamgiac.Layer = Layer
            cottamgiac.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        Dim diem1 As Point2d = cottamgiac.GetPoint2dAt(0)
        Dim id_c1 As ObjectId
        id_c1 = Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), b_a / 10)
        Dim id_coll1 As New ObjectIdCollection
        id_coll1.Add(id_c1)
        Lib_Drawing.CreateHatch_1MienBao(id_coll1, "SOLID", 0, 1)
        Dim diem2 As Point2d = cottamgiac.GetPoint2dAt(1)
        Dim id_c2 As ObjectId
        id_c2 = Lib_Drawing.CreateCircle(New Point3d(diem2.X, diem2.Y, 0), b_a / 10)
        Dim id_coll2 As New ObjectIdCollection
        id_coll2.Add(id_c2)
        Lib_Drawing.CreateHatch_1MienBao(id_coll2, "SOLID", 0, 1)
        Dim diem3 As Point2d = cottamgiac.GetPoint2dAt(2)
        Dim id_c3 As ObjectId
        id_c3 = Lib_Drawing.CreateCircle(New Point3d(diem3.X, diem3.Y, 0), b_a / 10)
        Dim id_coll3 As New ObjectIdCollection
        id_coll3.Add(id_c3)
        Lib_Drawing.CreateHatch_1MienBao(id_coll3, "SOLID", 0, 1)
        'Dim TextCot(2) As Point2d 'Cot tam giac
        'TextCot(0) = New Point2d(diem2.X, diem2.Y)
        'TextCot(1) = New Point2d(b_b0mong / 2 + b_b0mong / 10, -b_h0mong / 2 - b_h0mong / 10)
        'TextCot(2) = New Point2d(b_b0mong / 2 + b_b0mong / 10 + b_b0mong + b_b0mong / 4, -b_h0mong / 2 - b_h0mong / 10)
        'Dim id_TextCot As ObjectId
        'id_TextCot = Lib_Drawing.CreateNewPolyline(TextCot, False)
        'Lib_Drawing.CreateNewMText(New Point3d(b_b0mong / 2 + b_b0mong / 10, -b_h0mong / 2 - b_h0mong / 10 + TextHight + 50, 0), "Cột tam giác ", TextHight)
        '' ve day 
        Dim ID_Line1 As ObjectId ' day mong 1
        Dim line1 As Line
        Dim ID_Line2 As ObjectId ' day mong 2
        Dim line2 As Line
        Dim ID_Line3 As ObjectId ' day mong 3
        Dim line3 As Line
        Dim ID_Line4 As ObjectId ' day mong 4
        Dim line4 As Line
        If (loaiday = 3) Then
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x1) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y1) >= 0 Then
                    'ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(0, 0, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line1, DiemNoiDay)
                    TaoTextTrenMB(ID_Line1, goc, "", DiemNoiDay)
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x2) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y2) >= 0 Then
                    'ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(0, 0, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line2, DiemNoiDay)
                    TaoTextTrenMB(ID_Line2, goc, "", DiemNoiDay)
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x3) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y3) >= 0 Then
                    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(0, 0, 0))
                    'ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line3, DiemNoiDay)
                    TaoTextTrenMB(ID_Line3, goc, "", DiemNoiDay)
                End If
            Next
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                line1.Layer = LayerDay
                line2.Layer = LayerDay
                line3.Layer = LayerDay
                acTrans.Commit()
            End Using
        ElseIf (loaiday = 4) Then
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x1) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y1) >= 0 Then
                    'ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(0, 0, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line1, DiemNoiDay)
                    TaoTextTrenMB(ID_Line1, goc, "", DiemNoiDay)
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x2) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y2) >= 0 Then
                    'ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(0, 0, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line2, DiemNoiDay)
                    TaoTextTrenMB(ID_Line2, goc, "", DiemNoiDay)
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x3) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y3) >= 0 Then
                    'ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(0, 0, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line3, DiemNoiDay)
                    TaoTextTrenMB(ID_Line3, goc, "", DiemNoiDay)
                End If
            Next
            For i = 0 To 2 Step 1
                Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                If (Math.Round((DiemNoiDay.X), 2) * x4) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y4) >= 0 Then
                    'ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                    ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(0, 0, 0))
                    Dim goc As Double = TinhGocDuongThangMB(ID_Line4, DiemNoiDay)
                    TaoTextTrenMB(ID_Line4, goc, "", DiemNoiDay)
                End If
            Next
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
                line1.Layer = LayerDay
                line2.Layer = LayerDay
                line3.Layer = LayerDay
                line4.Layer = LayerDay
                acTrans.Commit()
            End Using
        End If
        '' thay doi thuoc tinh day 
        If (loaiday = 3) Then
            mbVeMong.Dim3MongCotTamGiac(x1, y1, x2, y2, x3, y3, b_bmong, Dimscale)
        ElseIf (loaiday = 4) Then
            mbVeMong.Dim4MongCotTamGiac(x1, y1, x2, y2, x3, y3, x4, y4, b_bmong, b_hmong, Dimscale)
        End If
    End Sub
    Public Shared Sub Ve_Cot_Tam_Giac_update_4Mong(CanhTamGiac As Double, xxoay As Double, yxoay As Double, Layer As String, LayerDay As String, Linetypescale As Double, Dimscale As Double, TextHight As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, loaiday As Integer)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim Mang_Toa_Do5(2) As Point2d ' cot tam giac 
        Mang_Toa_Do5(0) = New Point2d(-(b_a * Math.Sqrt(3)) / 6, b_a / 2)
        Mang_Toa_Do5(1) = New Point2d((b_a * Math.Sqrt(3)) / 3, 0)
        Mang_Toa_Do5(2) = New Point2d(-(b_a * Math.Sqrt(3)) / 6, -b_a / 2)
        Dim id_cottamgiac As ObjectId
        id_cottamgiac = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do5, True)
        Dim Goc As Double = (GocXoayMatBang * (Math.PI)) / 180
        Dim GocXoay As Double
        If ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 Then
            Dim GocXoayCoGa As Double = Goc
            If MongNoiChung1 = "Móng 1, Móng 2" Then
                'GocXoay = GocXoayCoGa - Math.PI / 2
                If x1 >= 0 And y1 >= 0 Then
                    GocXoay = 0
                ElseIf x1 >= 0 And y1 <= 0 Then
                    GocXoay = -Math.PI / 2
                ElseIf x1 <= 0 And y1 >= 0 Then
                    GocXoay = Math.PI / 2
                Else
                    GocXoay = -Math.PI
                End If
            ElseIf MongNoiChung1 = "Móng 2, Móng 3" Then
                'GocXoay = GocXoayCoGa - Math.PI / 2
                If x2 >= 0 And y2 >= 0 Then
                    GocXoay = 0
                ElseIf x2 >= 0 And y2 <= 0 Then
                    GocXoay = -Math.PI / 2
                ElseIf x2 <= 0 And y2 >= 0 Then
                    GocXoay = Math.PI / 2
                Else
                    GocXoay = -Math.PI
                End If
            ElseIf MongNoiChung1 = "Móng 3, Móng 4" Then
                'GocXoay = GocXoayCoGa - Math.PI / 2
                If x3 >= 0 And y3 >= 0 Then
                    GocXoay = 0
                ElseIf x3 >= 0 And y3 <= 0 Then
                    GocXoay = -Math.PI / 2
                ElseIf x3 <= 0 And y3 >= 0 Then
                    GocXoay = Math.PI / 2
                Else
                    GocXoay = -Math.PI
                End If
            ElseIf MongNoiChung1 = "Móng 4, Móng 1" Then
                'GocXoay = GocXoayCoGa - Math.PI / 2
                If x1 >= 0 And y1 >= 0 Then
                    GocXoay = Math.PI / 2
                ElseIf x1 >= 0 And y1 <= 0 Then
                    GocXoay = 0
                ElseIf x1 <= 0 And y1 >= 0 Then
                    GocXoay = -Math.PI
                Else
                    GocXoay = -Math.PI / 2
                End If
            Else
                GocXoay = GocXoayCoGa
            End If
        Else
            GocXoay = Goc
        End If
        Lib_Drawing.RotateEntity(id_cottamgiac, Matrix3d.Rotation(GocXoay, curUCS.Zaxis, New Point3d(0, 0, 0)))
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database ' thay doi thuoc tinh 
        Dim cottamgiac As Polyline
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            cottamgiac = acTrans.GetObject(id_cottamgiac, OpenMode.ForWrite)
            cottamgiac.Layer = Layer
            cottamgiac.LinetypeScale = Linetypescale
            acTrans.Commit()
        End Using
        Dim diem1 As Point2d = cottamgiac.GetPoint2dAt(0)
        Dim id_c1 As ObjectId
        id_c1 = Lib_Drawing.CreateCircle(New Point3d(diem1.X, diem1.Y, 0), b_a / 10)
        Dim id_coll1 As New ObjectIdCollection
        id_coll1.Add(id_c1)
        Lib_Drawing.CreateHatch_1MienBao(id_coll1, "SOLID", 0, 1)
        Dim diem2 As Point2d = cottamgiac.GetPoint2dAt(1)
        Dim id_c2 As ObjectId
        id_c2 = Lib_Drawing.CreateCircle(New Point3d(diem2.X, diem2.Y, 0), b_a / 10)
        Dim id_coll2 As New ObjectIdCollection
        id_coll2.Add(id_c2)
        Lib_Drawing.CreateHatch_1MienBao(id_coll2, "SOLID", 0, 1)
        Dim diem3 As Point2d = cottamgiac.GetPoint2dAt(2)
        Dim id_c3 As ObjectId
        id_c3 = Lib_Drawing.CreateCircle(New Point3d(diem3.X, diem3.Y, 0), b_a / 10)
        Dim id_coll3 As New ObjectIdCollection
        id_coll3.Add(id_c3)
        Lib_Drawing.CreateHatch_1MienBao(id_coll3, "SOLID", 0, 1)
        '' ve day 
        Dim ID_Line1 As ObjectId ' day mong 1
        Dim line1 As Line
        Dim ID_Line2 As ObjectId ' day mong 2
        Dim line2 As Line
        Dim ID_Line3 As ObjectId ' day mong 3
        Dim line3 As Line
        Dim ID_Line4 As ObjectId ' day mong 4
        Dim line4 As Line
        Try
            If (loaiday = 3) Then
                For i = 0 To 2 Step 1
                    Dim DiemNoiDay1 As Point2d = cottamgiac.GetPoint2dAt(i)
                    If (DiemNoiDay1.X * x1) >= 0 And (DiemNoiDay1.Y * y1) >= 0 Then
                        ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(DiemNoiDay1.X, DiemNoiDay1.Y, 0))
                        Dim goc1 As Double = TinhGocDuongThangMB(ID_Line1, DiemNoiDay1)
                        TaoTextTrenMB(ID_Line1, goc1, "", DiemNoiDay1)
                    End If
                Next
                For i = 0 To 2 Step 1
                    Dim DiemNoiDay2 As Point2d = cottamgiac.GetPoint2dAt(i)
                    If (DiemNoiDay2.X * x2) >= 0 And (DiemNoiDay2.Y * y2) >= 0 Then
                        ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(DiemNoiDay2.X, DiemNoiDay2.Y, 0))
                        Dim goc2 As Double = TinhGocDuongThangMB(ID_Line2, DiemNoiDay2)
                        TaoTextTrenMB(ID_Line2, goc2, "", DiemNoiDay2)
                    End If
                Next
                For i = 0 To 2 Step 1
                    Dim DiemNoiDay3 As Point2d = cottamgiac.GetPoint2dAt(i)
                    If (DiemNoiDay3.X * x3) >= 0 And (DiemNoiDay3.Y * y3) >= 0 Then
                        ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(DiemNoiDay3.X, DiemNoiDay3.Y, 0))
                        Dim goc3 As Double = TinhGocDuongThangMB(ID_Line3, DiemNoiDay3)
                        TaoTextTrenMB(ID_Line3, goc3, "", DiemNoiDay3)
                    End If
                Next
                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                    line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                    line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                    line1.Layer = LayerDay
                    line2.Layer = LayerDay
                    line3.Layer = LayerDay
                    acTrans.Commit()
                End Using
            ElseIf (loaiday = 4) Then
                Dim MongDaNoiDay As New List(Of String)
                If IndexNoiDay1 <> -1 Then
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x1) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y1) >= 0 Then
                            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                            Dim goc1 As Double = TinhGocDuongThangMB(ID_Line1, DiemNoiDay)
                            TaoTextTrenMB(ID_Line1, goc1, "", DiemNoiDay)
                        End If
                    Next
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x2) >= 0 And Math.Round((DiemNoiDay.Y * y2), 2) >= 0 Then
                            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(Math.Round((DiemNoiDay.X), 2), Math.Round((DiemNoiDay.Y), 2), 0))
                            Dim goc2 As Double = TinhGocDuongThangMB(ID_Line2, DiemNoiDay)
                            TaoTextTrenMB(ID_Line2, goc2, "", DiemNoiDay)
                        End If
                    Next
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x3) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y3) >= 0 Then
                            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                            Dim goc3 As Double = TinhGocDuongThangMB(ID_Line3, DiemNoiDay)
                            TaoTextTrenMB(ID_Line3, goc3, "", DiemNoiDay)
                        End If
                    Next
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x4) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y4) >= 0 Then
                            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                            Dim goc4 As Double = TinhGocDuongThangMB(ID_Line4, DiemNoiDay)
                            TaoTextTrenMB(ID_Line4, goc4, "", DiemNoiDay)
                        End If
                    Next

                Else
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x1) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y1) >= 0 Then
                            ID_Line1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                            Dim goc1 As Double = TinhGocDuongThangMB(ID_Line1, DiemNoiDay)
                            TaoTextTrenMB(ID_Line1, goc1, "", DiemNoiDay)
                        End If
                    Next
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x2) >= 0 And Math.Round((DiemNoiDay.Y * y2), 2) >= 0 Then
                            ID_Line2 = Lib_Drawing.CreateLine(New Point3d(x2, y2, 0), New Point3d(Math.Round((DiemNoiDay.X), 2), Math.Round((DiemNoiDay.Y), 2), 0))
                            Dim goc2 As Double = TinhGocDuongThangMB(ID_Line2, DiemNoiDay)
                            TaoTextTrenMB(ID_Line2, goc2, "", DiemNoiDay)
                        End If
                    Next
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x3) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y3) >= 0 Then
                            ID_Line3 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                            Dim goc3 As Double = TinhGocDuongThangMB(ID_Line3, DiemNoiDay)
                            TaoTextTrenMB(ID_Line3, goc3, "", DiemNoiDay)
                        End If
                    Next
                    For i = 0 To 2 Step 1
                        Dim DiemNoiDay As Point2d = cottamgiac.GetPoint2dAt(i)
                        If (Math.Round((DiemNoiDay.X), 2) * x4) >= 0 And (Math.Round((DiemNoiDay.Y), 2) * y4) >= 0 Then
                            ID_Line4 = Lib_Drawing.CreateLine(New Point3d(x4, y4, 0), New Point3d(DiemNoiDay.X, DiemNoiDay.Y, 0))
                            Dim goc4 As Double = TinhGocDuongThangMB(ID_Line4, DiemNoiDay)
                            TaoTextTrenMB(ID_Line4, goc4, "", DiemNoiDay)
                        End If
                    Next
                End If

                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    line1 = acTrans.GetObject(ID_Line1, OpenMode.ForWrite)
                    line2 = acTrans.GetObject(ID_Line2, OpenMode.ForWrite)
                    line3 = acTrans.GetObject(ID_Line3, OpenMode.ForWrite)
                    line4 = acTrans.GetObject(ID_Line4, OpenMode.ForWrite)
                    line1.Layer = LayerDay
                    line2.Layer = LayerDay
                    line3.Layer = LayerDay
                    line4.Layer = LayerDay
                    acTrans.Commit()
                End Using
            End If
        Catch ex As System.Exception
            MsgBox("Dây nối không hợp lý")
        End Try
        '' thay doi thuoc tinh day 
        If (loaiday = 3) Then
            mbVeMong.Dim3MongCotTamGiac(x1, y1, x2, y2, x3, y3, b_bmong, Dimscale)
        ElseIf (loaiday = 4) Then
            mbVeMong.Dim4MongCotTamGiac(x1, y1, x2, y2, x3, y3, x4, y4, b_bmong, b_hmong, Dimscale)
        End If
    End Sub
    Public Shared Function mbTile(x As Double, y As Double) As Double

        Dim tile As Double = (Math.Sqrt(x ^ 2 + y ^ 2) / 2) / 8
        Return tile
    End Function
    Public Shared Function mbTileMD(x As Double) As Double
        Dim tile As Double = x / 15
        Return tile
    End Function
    Public Shared Function mbTileMDCT(x As Double) As Double
        Dim tile As Double = x / 2.5
        Return tile
    End Function
    Public Shared Function mb_TinhH_MatDung(Tong As List(Of Double), so As Integer) As Double
        Dim TongChieucao As Double = 0
        Dim i As Integer = 0
        For i = 0 To so Step 1
            TongChieucao = TongChieucao + Tong(i)
        Next
        Return TongChieucao
    End Function
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
    Public Shared Sub DoiMauTheoBlock()
        Dim doc As Document = Application.DocumentManager.CurrentDocument
        Dim db As Database = doc.Database

        Using tr As Transaction = db.TransactionManager.StartTransaction()
            Dim bt As BlockTable
            bt = tr.GetObject(db.BlockTableId, OpenMode.ForWrite)

            Dim btr As BlockTableRecord
            btr = tr.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            For Each entId As ObjectId In btr
                Dim ent As Entity = tr.GetObject(entId, OpenMode.ForWrite)
                'ent.EntityColor.IsByBlock = True
            Next

            tr.Commit()
        End Using
    End Sub
    Public Shared Sub XoayMong(ByVal id As ObjectId, ByVal mat As Matrix3d)
        ' Get the current database and start a transaction
        Dim acCurDb As Autodesk.AutoCAD.DatabaseServices.Database
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Dim ent As Entity = acTrans.GetObject(id, OpenMode.ForWrite)
            ent.TransformBy(mat)
            'Matrix3d.
            acTrans.Commit()
        End Using

    End Sub
    Public Shared Function TinhGocMoc(x As Double, y As Double) As Double
        Dim tu As Double = x * y
        Dim mau As Double = y * Math.Sqrt(x ^ 2 + y ^ 2)
        Dim cos As Double = tu / mau
        Dim kq As Double
        If (x = 0) And (y = 0) Then
            kq = 0
        Else
            kq = Math.Acos(cos)
        End If
        Return kq

    End Function
    Public Shared Function TinhCanh(x1 As Double, y1 As Double, x2 As Double, y2 As Double) As ObjectId
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database
        Dim id_canh As ObjectId
        Dim id_CanhChuan As ObjectId
        Dim DoDaiCanh As Double
        Dim line As Line
        Dim TrungDiem As Point3d = New Point3d(((x1 + x2) / 2), ((y1 + y2) / 2), 0)
        id_canh = Lib_Drawing.CreateLine(New Point3d(0, 0, 0), TrungDiem)
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line = acTrans.GetObject(id_canh, OpenMode.ForWrite)
            acTrans.Commit()
        End Using
        DoDaiCanh = line.Length
        Return id_CanhChuan
    End Function
    Public Shared Sub Dim4MongCotTamGiac(x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, ByRef b_bmong As Double, ByRef b_hmong As Double, ByRef Dimscale As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim ID_DIM1 As ObjectId 'M1
        Dim Dim1 As RotatedDimension
        Dim ID_DIMP11 As ObjectId 'MP1
        Dim DimP11 As RotatedDimension
        Dim ID_DIMP12 As ObjectId 'MP2
        Dim DimP12 As RotatedDimension

        Dim ID_DIM2 As ObjectId 'M2
        Dim Dim2 As RotatedDimension
        Dim ID_DIMP21 As ObjectId 'MP1
        Dim DimP21 As RotatedDimension
        Dim ID_DIMP22 As ObjectId 'MP2
        Dim DimP22 As RotatedDimension

        Dim ID_DIM3 As ObjectId 'M3
        Dim Dim3 As RotatedDimension
        Dim ID_DIMP31 As ObjectId 'MP1
        Dim DimP31 As RotatedDimension
        Dim ID_DIMP32 As ObjectId 'MP2
        Dim DimP32 As RotatedDimension

        Dim ID_DIM4 As ObjectId 'M4
        Dim Dim4 As RotatedDimension
        Dim ID_DIMP41 As ObjectId 'MP1
        Dim DimP41 As RotatedDimension
        Dim ID_DIMP42 As ObjectId 'MP2
        Dim DimP42 As RotatedDimension

        Dim ofsetdoc As Double
        Dim ofsetngang As Double
        ofsetdoc = b_hmong / 2 + TiLeChu * 2 + TiLeChu / 2 ' chu mac dinh kho giay A4 = 2, khoang cach tu dong dim den chu = tilechu/2
        ofsetngang = b_bmong / 2 + TiLeChu * 2 + TiLeChu / 2

        ofsetdoc *= 2.5
        ofsetngang *= 2.5

        If (x1 <= 0) And (y1 <= 0) Then
            If (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, 0, 0), New Point3d(Math.Min(x1, x2) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, 0, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang / 2.5, y1, 0), 90)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(0, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang, y3, 0), 90)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, 0, 0), New Point3d(Math.Max(x3, x4) + ofsetngang / 2.5, y3, 0), 90)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, 0, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang / 2.5, y3, 0), 90)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(0, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc / 2.5, 0), 0)
                'end
            ElseIf (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x3, x2) + ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Max(x3, x2) + ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x3, x2) + ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                'end
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                'end
            End If
        ElseIf (x1 <= 0) And (y1 >= 0) Then
            If (x2 <= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, 0, 0), New Point3d(Math.Min(x1, x2) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, 0, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang / 2.5, y1, 0), 90)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(0, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang, y3, 0), 90)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, 0, 0), New Point3d(Math.Max(x3, x4) + ofsetngang / 2.5, y3, 0), 90)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, 0, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang / 2.5, y3, 0), 90)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(0, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc / 2.5, 0), 0)
                'end
            ElseIf (x2 >= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y4, y3) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x3, Math.Min(y4, y3) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y4, y3) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x1, x4) - ofsetngang, y4, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Min(x1, x4) - ofsetngang / 2.5, y4, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x1, x4) - ofsetngang / 2.5, y4, 0), 90)
                'end
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                'end
            End If
        ElseIf (x1) >= 0 And (y1 >= 0) Then
            If (x2 >= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, 0, 0), New Point3d(Math.Max(x1, x2) + ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, 0, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang / 2.5, y1, 0), 90)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(0, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang, y3, 0), 90)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, 0, 0), New Point3d(Math.Min(x3, x4) - ofsetngang / 2.5, y3, 0), 90)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, 0, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang / 2.5, y3, 0), 90)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(0, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc / 2.5, 0), 0)
                'end
            ElseIf (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Min(x2, x3) - ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang, y4, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, 0, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, 0, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                'end
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                'end
            End If
        ElseIf (x1 >= 0) And (y1 <= 0) Then
            If (x2 >= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x1, 0, 0), New Point3d(Math.Max(x1, x2) + ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, 0, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang / 2.5, y1, 0), 90)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(0, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang, y3, 0), 90)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, 0, 0), New Point3d(Math.Min(x3, x4) - ofsetngang / 2.5, y3, 0), 90)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, 0, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang / 2.5, y3, 0), 90)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(0, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc / 2.5, 0), 0)
                'end
            ElseIf (x2 <= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Min(x2, x3) - ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang, y4, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Max(x4, x1) + ofsetngang / 2.5, y4, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang / 2.5, y4, 0), 90)
                'end
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP11 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(0, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                ID_DIMP12 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                'Dim Phụ
                ID_DIMP21 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, 0, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                ID_DIMP22 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, 0, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang / 2.5, y2, 0), 90)
                'end
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                'Dim Phụ
                ID_DIMP31 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(0, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                ID_DIMP32 = Lib_Drawing.CreateRotatedDimension(New Point3d(0, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc / 2.5, 0), 0)
                'end
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
                'Dim Phụ
                ID_DIMP41 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, 0, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                ID_DIMP42 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, 0, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang / 2.5, y1, 0), 90)
                'end
            End If
        End If
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Dim1 = acTrans.GetObject(ID_DIM1, OpenMode.ForWrite)
            DimP11 = acTrans.GetObject(ID_DIMP11, OpenMode.ForWrite)
            DimP12 = acTrans.GetObject(ID_DIMP12, OpenMode.ForWrite)
            DimP21 = acTrans.GetObject(ID_DIMP21, OpenMode.ForWrite)
            DimP22 = acTrans.GetObject(ID_DIMP22, OpenMode.ForWrite)
            Dim2 = acTrans.GetObject(ID_DIM2, OpenMode.ForWrite)
            Dim3 = acTrans.GetObject(ID_DIM3, OpenMode.ForWrite)
            DimP31 = acTrans.GetObject(ID_DIMP31, OpenMode.ForWrite)
            DimP32 = acTrans.GetObject(ID_DIMP32, OpenMode.ForWrite)
            Dim4 = acTrans.GetObject(ID_DIM4, OpenMode.ForWrite)
            DimP41 = acTrans.GetObject(ID_DIMP41, OpenMode.ForWrite)
            DimP42 = acTrans.GetObject(ID_DIMP42, OpenMode.ForWrite)

            Dim1.Dimscale = Dimscale
            DimP11.Dimscale = Dimscale
            DimP12.Dimscale = Dimscale
            Dim2.Dimscale = Dimscale
            DimP21.Dimscale = Dimscale
            DimP22.Dimscale = Dimscale
            Dim3.Dimscale = Dimscale
            DimP31.Dimscale = Dimscale
            DimP32.Dimscale = Dimscale
            Dim4.Dimscale = Dimscale
            DimP41.Dimscale = Dimscale
            DimP42.Dimscale = Dimscale
            Dim4.Dimscale = Dimscale
            acTrans.Commit()
        End Using
    End Sub
    Public Shared Sub Dim3MongCotTamGiac(x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, ByRef Khoangofset As Double, ByRef Dimscale As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim ID_DIM1 As ObjectId 'M1
        Dim Dim1 As AlignedDimension
        Dim ID_DIMP11 As ObjectId 'M1
        Dim DimP11 As AlignedDimension
        Dim ID_DIMP12 As ObjectId 'M1
        Dim DimP12 As AlignedDimension

        Dim ID_DIM2 As ObjectId 'M2
        Dim Dim2 As AlignedDimension
        Dim ID_DIMP21 As ObjectId 'M1
        Dim DimP21 As AlignedDimension
        Dim ID_DIMP22 As ObjectId 'M1
        Dim DimP22 As AlignedDimension

        Dim ID_DIM3 As ObjectId 'M3
        Dim Dim3 As AlignedDimension
        Dim ID_DIMP31 As ObjectId 'M1
        Dim DimP31 As AlignedDimension
        Dim ID_DIMP32 As ObjectId 'M1
        Dim DimP32 As AlignedDimension

        Dim ofset As Double
        ofset = b_bmong + TiLeChu * 2.5 + TiLeChu / 2 ' chu mac dinh kho giay A4 = 2, khoang cach tu dong dim den chu = tilechu/2
        Dim diemdim1 As Point3d = Lib_Drawing.TimDiem(x1, y1, x2, y2, ofset * 2)
        Dim diemdimp1 As Point3d = Lib_Drawing.TimDiem(x1, y1, x2, y2, ofset)
        Dim diemdim2 As Point3d = Lib_Drawing.TimDiem(x2, y2, x3, y3, ofset * 2)
        Dim diemdimp2 As Point3d = Lib_Drawing.TimDiem(x2, y2, x3, y3, ofset)
        Dim diemdim3 As Point3d = Lib_Drawing.TimDiem(x3, y3, x1, y1, ofset * 2)
        Dim diemdimp3 As Point3d = Lib_Drawing.TimDiem(x3, y3, x1, y1, ofset)
        ID_DIM1 = Lib_Drawing.CreateAlignedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), diemdim1, 0)
        'Dim Phụ
        ID_DIMP11 = Lib_Drawing.CreateAlignedDimension(New Point3d(x1, y1, 0), New Point3d((x1 + x2) / 2, (y1 + y2) / 2, 0), diemdimp1, 0)
        ID_DIMP12 = Lib_Drawing.CreateAlignedDimension(New Point3d((x1 + x2) / 2, (y1 + y2) / 2, 0), New Point3d(x2, y2, 0), diemdimp1, 0)
        'end
        ID_DIM2 = Lib_Drawing.CreateAlignedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), diemdim2, 0)
        'Dim Phụ
        ID_DIMP21 = Lib_Drawing.CreateAlignedDimension(New Point3d(x2, y2, 0), New Point3d((x2 + x3) / 2, (y2 + y3) / 2, 0), diemdimp2, 0)
        ID_DIMP22 = Lib_Drawing.CreateAlignedDimension(New Point3d((x2 + x3) / 2, (y2 + y3) / 2, 0), New Point3d(x3, y3, 0), diemdimp2, 0)
        'end
        ID_DIM3 = Lib_Drawing.CreateAlignedDimension(New Point3d(x3, y3, 0), New Point3d(x1, y1, 0), diemdim3, 0)
        'Dim Phụ
        ID_DIMP31 = Lib_Drawing.CreateAlignedDimension(New Point3d(x3, y3, 0), New Point3d((x1 + x3) / 2, (y1 + y3) / 2, 0), diemdimp3, 0)
        ID_DIMP32 = Lib_Drawing.CreateAlignedDimension(New Point3d((x1 + x3) / 2, (y1 + y3) / 2, 0), New Point3d(x1, y1, 0), diemdimp3, 0)
        'end
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Dim1 = acTrans.GetObject(ID_DIM1, OpenMode.ForWrite)
            DimP11 = acTrans.GetObject(ID_DIMP11, OpenMode.ForWrite)
            DimP12 = acTrans.GetObject(ID_DIMP12, OpenMode.ForWrite)
            DimP21 = acTrans.GetObject(ID_DIMP21, OpenMode.ForWrite)
            DimP22 = acTrans.GetObject(ID_DIMP22, OpenMode.ForWrite)
            Dim2 = acTrans.GetObject(ID_DIM2, OpenMode.ForWrite)
            Dim3 = acTrans.GetObject(ID_DIM3, OpenMode.ForWrite)
            DimP31 = acTrans.GetObject(ID_DIMP31, OpenMode.ForWrite)
            DimP32 = acTrans.GetObject(ID_DIMP32, OpenMode.ForWrite)


            Dim1.Dimscale = Dimscale
            DimP11.Dimscale = Dimscale
            DimP12.Dimscale = Dimscale
            Dim2.Dimscale = Dimscale
            DimP21.Dimscale = Dimscale
            DimP22.Dimscale = Dimscale
            Dim3.Dimscale = Dimscale
            DimP31.Dimscale = Dimscale
            DimP32.Dimscale = Dimscale

            acTrans.Commit()

        End Using
    End Sub
    Public Shared Sub Dim4MongCotTuGiac(x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, ByRef b_bmong As Double, ByRef b_hmong As Double, ByRef Dimscale As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim ID_DIM1 As ObjectId 'M1
        Dim Dim1 As RotatedDimension
        Dim ID_DIM2 As ObjectId 'M2
        Dim Dim2 As RotatedDimension
        Dim ID_DIM3 As ObjectId 'M3
        Dim Dim3 As RotatedDimension
        Dim ID_DIM4 As ObjectId 'M4
        Dim Dim4 As RotatedDimension
        Dim ofsetdoc As Double
        Dim ofsetngang As Double
        ofsetdoc = b_hmong / 2 + TiLeChu * 2 + TiLeChu / 2 ' chu mac dinh kho giay A4 = 2, khoang cach tu dong dim den chu = tilechu/2
        ofsetngang = b_bmong / 2 + TiLeChu * 2 + TiLeChu / 2
        If (x1 <= 0) And (y1 <= 0) Then
            If (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc, 0), 0)
            ElseIf (x2 >= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x3, x2) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        ElseIf (x1 <= 0) And (y1 >= 0) Then
            If (x2 <= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc, 0), 0)
            ElseIf (x2 >= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y4, y3) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x1, x4) - ofsetngang, y4, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        ElseIf (x1) >= 0 And (y1 >= 0) Then
            If (x2 >= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc, 0), 0)

            ElseIf (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang, y4, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        ElseIf (x1 >= 0) And (y1 <= 0) Then
            If (x2 >= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc, 0), 0)
            ElseIf (x2 <= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang, y4, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        End If
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Dim1 = acTrans.GetObject(ID_DIM1, OpenMode.ForWrite)
            Dim2 = acTrans.GetObject(ID_DIM2, OpenMode.ForWrite)
            Dim3 = acTrans.GetObject(ID_DIM3, OpenMode.ForWrite)
            Dim4 = acTrans.GetObject(ID_DIM4, OpenMode.ForWrite)
            Dim1.Dimscale = Dimscale
            Dim2.Dimscale = Dimscale
            Dim3.Dimscale = Dimscale
            Dim4.Dimscale = Dimscale
            acTrans.Commit()
        End Using
    End Sub
    Public Shared Sub Dim4MongCotTuGiacTrenMai(x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, ByRef b_bmong As Double, ByRef b_hmong As Double, ByRef Dimscale As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim ID_DIM1 As ObjectId 'M1
        Dim Dim1 As RotatedDimension
        Dim ID_DIM2 As ObjectId 'M2
        Dim Dim2 As RotatedDimension
        Dim ID_DIM3 As ObjectId 'M3
        Dim Dim3 As RotatedDimension
        Dim ID_DIM4 As ObjectId 'M4
        Dim Dim4 As RotatedDimension
        Dim ofsetdoc As Double
        Dim ofsetngang As Double
        ofsetdoc = b_hmong / 2 + TiLeChu * 2 + TiLeChu / 2 ' chu mac dinh kho giay A4 = 2, khoang cach tu dong dim den chu = tilechu/2
        ofsetngang = b_bmong / 2 + TiLeChu * 2 + TiLeChu / 2
        If (x1 <= 0) And (y1 <= 0) Then
            If (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc, 0), 0)
            ElseIf (x2 >= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x3, x2) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        ElseIf (x1 <= 0) And (y1 >= 0) Then
            If (x2 <= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Min(x1, x2) - ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Max(x3, x4) + ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc, 0), 0)
            ElseIf (x2 >= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y4, y3) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x1, x4) - ofsetngang, y4, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        ElseIf (x1) >= 0 And (y1 >= 0) Then
            If (x2 >= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Min(y2, y3) - ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Max(y1, y4) + ofsetdoc, 0), 0)
            ElseIf (x2 <= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang, y4, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If
        ElseIf (x1 >= 0) And (y1 <= 0) Then
            If (x2 >= 0) And (y2 >= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(Math.Max(x1, x2) + ofsetngang, y1, 0), 90)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(x2, Math.Max(y2, y3) + ofsetdoc, 0), 0)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(Math.Min(x3, x4) - ofsetngang, y3, 0), 90)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(x4, Math.Min(y1, y4) - ofsetdoc, 0), 0)
            ElseIf (x2 <= 0) And (y2 <= 0) Then
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Min(y1, y2) - ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Min(x2, x3) - ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x3, Math.Max(y3, y4) + ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Max(x4, x1) + ofsetngang, y4, 0), 90)
            Else
                ID_DIM1 = Lib_Drawing.CreateRotatedDimension(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0), New Point3d(x1, Math.Max(y1, y2) + ofsetdoc, 0), 0)
                ID_DIM2 = Lib_Drawing.CreateRotatedDimension(New Point3d(x2, y2, 0), New Point3d(x3, y3, 0), New Point3d(Math.Max(x2, x3) + ofsetngang, y2, 0), 90)
                ID_DIM3 = Lib_Drawing.CreateRotatedDimension(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0), New Point3d(x4, Math.Min(y3, y4) - ofsetdoc, 0), 0)
                ID_DIM4 = Lib_Drawing.CreateRotatedDimension(New Point3d(x4, y4, 0), New Point3d(x1, y1, 0), New Point3d(Math.Min(x4, x1) - ofsetngang, y1, 0), 90)
            End If

        End If
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Dim1 = acTrans.GetObject(ID_DIM1, OpenMode.ForWrite)
            Dim2 = acTrans.GetObject(ID_DIM2, OpenMode.ForWrite)
            Dim3 = acTrans.GetObject(ID_DIM3, OpenMode.ForWrite)
            Dim4 = acTrans.GetObject(ID_DIM4, OpenMode.ForWrite)
            Dim1.Dimscale = Dimscale
            Dim2.Dimscale = Dimscale
            Dim3.Dimscale = Dimscale
            Dim4.Dimscale = Dimscale
            acTrans.Commit()
        End Using
    End Sub
    Public Shared Sub Erase_E(entId As ObjectId)
        Dim doc As Document = Application.DocumentManager.CurrentDocument
        Dim db As Database = doc.Database

        Using tr As Transaction = db.TransactionManager.StartTransaction()
            Dim bt As BlockTable
            bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead)

            Dim btr As BlockTableRecord
            btr = tr.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            Dim ent As Entity = tr.GetObject(entId, OpenMode.ForWrite)
            ent.Erase(True)

            tr.Commit()
        End Using
    End Sub
    Public Shared Function TinhGocDuongThangMB(id As ObjectId, DiemNoiDay As Point2d)
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
        If (Diem1.X <= 0 And DiemNoiDay.X >= 0) Then
            tu = Math.Abs(DiemNoiDay.X) - Math.Abs(Diem1.X)
        ElseIf (Diem1.X <= 0 And DiemNoiDay.X <= 0) Then
            tu = Math.Abs(DiemNoiDay.X) - Math.Abs(Diem1.X)
        ElseIf (Diem1.X >= 0 And DiemNoiDay.X >= 0) Then
            tu = Math.Abs(Diem1.X) - Math.Abs(DiemNoiDay.X)
        ElseIf (Diem1.X >= 0 And DiemNoiDay.X <= 0) Then
            tu = Math.Abs(Diem1.X) - Math.Abs(DiemNoiDay.X)
        End If
        'mau = line.Length
        mau = Math.Sqrt((Diem1.X - DiemNoiDay.X) * (Diem1.X - DiemNoiDay.X) + (Diem1.Y - DiemNoiDay.Y) * (Diem1.Y - DiemNoiDay.Y))
        cos = tu / mau
        goc = Math.Acos(cos)
        Dim gocd = goc * 180 / Math.PI
        Return goc
    End Function
    Public Shared Sub TaoTextTrenMB(id As ObjectId, GocXoay As Double, NoiDung As String, DiemNoiDay As Point2d)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim diem1 As New Point3d
        Dim diem2 As New Point2d

        Dim line As New Line
        Dim lineclon As New Line
        Dim id_lineclon As ObjectId
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line = acTrans.GetObject(id, OpenMode.ForWrite)
            diem1 = line.StartPoint
            diem2 = DiemNoiDay
            NoiDung = "L=" & Convert.ToString(Math.Round(Val(line.Length / 1000), 1)) & "m"
            acTrans.Commit()
        End Using

        Dim DiemDat, DiemText As Point3d
        If DiemNoiDay.X <= 0 And DiemNoiDay.Y >= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 - 0, (diem1.Y + diem2.Y) / 2 - 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X - TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(-((Math.PI) / 2 - GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            Dim goc = (Math.PI - GocXoay) * 180 / Math.PI
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, -Math.PI + GocXoay)

        ElseIf DiemNoiDay.X <= 0 And DiemNoiDay.Y <= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 - 0, (diem1.Y + diem2.Y) / 2 - 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X - TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(((Math.PI) / 2 - GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            'MsgBox(GocXoay * (180 / Math.PI))
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, Math.PI - GocXoay)
        ElseIf DiemNoiDay.X >= 0 And DiemNoiDay.Y >= 0 Then
            DiemDat = New Point3d((diem1.X + diem2.X) / 2 + 0, (diem1.Y + diem2.Y) / 2 + 0, 0)
            id_lineclon = Lib_Drawing.CreateLine(DiemDat, New Point3d(DiemDat.X + TiLeChu * 3, DiemDat.Y, 0))
            Lib_Drawing.RotateEntity(id_lineclon, Matrix3d.Rotation(((Math.PI) / 2 + GocXoay), curUCS.Zaxis, DiemDat))
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                lineclon = acTrans.GetObject(id_lineclon, OpenMode.ForWrite)
                DiemText = lineclon.EndPoint
                lineclon.Erase()
                acTrans.Commit()
            End Using
            Lib_Drawing.CreateNewMText1(DiemText, NoiDung, TiLeChu, +GocXoay)
        ElseIf DiemNoiDay.X >= 0 And DiemNoiDay.Y <= 0 Then
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
    Public Shared Function KiemTraNoiDayCoGa(ListMong As List(Of String), TenMong As String)
        Dim kt As Boolean
        For i = 0 To ListMong.Count - 1
            If ListMong(i) = TenMong Then
                kt = True
                Exit For
            Else
                kt = False
            End If
        Next
        Return kt
    End Function
End Class
