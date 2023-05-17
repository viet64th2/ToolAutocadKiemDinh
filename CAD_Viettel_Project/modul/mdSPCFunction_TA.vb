Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO


' Add ribbon 
Imports Autodesk.Windows
Imports System.Windows.Input
Imports System.Windows.Media.Imaging
Imports System.Windows

Public Class mdSPCFunction_TA
    Public Function getText(path As String)
        Dim list As ArrayList = New ArrayList
        If (System.IO.File.Exists(path)) Then
            Dim text As String = ReadText(path)
            Dim li() As String = text.Split("@")
            List.AddRange(li)
        End If
        Return List
    End Function
    Public Function LayThongTinChung(arl As ArrayList)
        Dim li As List(Of String) = New List(Of String)
        For i = 1 To arl.Count - 1
            Dim itemDam As String = arl.Item(i)
            Dim b As String() = itemDam.Split("_")
            li.Add(b(1))
        Next
        If li(2) = "Dây co" Then
            ThongTinChung.DiaDiem = li(0)
            ThongTinChung.MaTram = li(1)
            ThongTinChung.LoaiCot = li(2)
            ThongTinChung.ChieuCao = li(3)
            ThongTinChung.TietDienCot = li(4)
            ThongTinChung.ViTriDat = li(5)
            ThongTinChung.BeTongMong = li(6)
            ThongTinChung.SoMong = li(7)
            ThongTinChung.SoChanCot = li(8)
            ThongTinChung.ChieuCaoDot = li(9)
            ThongTinChung.SoTangDay = li(10)
            ThongTinChung.SoDot = li(11)
            ThongTinChung.GaChongXoay = li(12)
        Else
            ThongTinChung.DiaDiem = li(0)
            ThongTinChung.MaTram = li(1)
            ThongTinChung.LoaiCot = li(2)
            ThongTinChung.ChieuCao = li(3)
            ThongTinChung.KichThuocChanCot = li(5)
            ThongTinChung.ViTriDat = li(6)
            ThongTinChung.BeTongMong = li(7)
            ThongTinChung.SoDot = li(8)
            ThongTinChung.SoMong = "4"
            ThongTinChung.SoChanCot = "4"
        End If
        Return li
    End Function
    Public Function TinhKhoangCach(X1 As Double, Y1 As Double, X2 As Double, Y2 As Double) As Double
        Return Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1))
    End Function
    Public Sub InsertData(Table As DataGridView, arl As ArrayList)
        Table.Rows.Clear()
        For i = 1 To arl.Count - 1
            Dim itemDam As String = arl.Item(i)
            Dim b As String() = itemDam.Split("_")
            Table.Rows.Add(b)
        Next
    End Sub
    Public Function ReadText(path As String)
        Dim text As String = ""
        If System.IO.File.Exists(path) = True Then
            Dim f As System.IO.StreamReader
            f = My.Computer.FileSystem.OpenTextFileReader(path)
            text = f.ReadToEnd()
            f.Close()
        End If
        Return text
    End Function
    Public Sub WirteText(text As String, path As String)
        System.IO.File.WriteAllText(path, text)
        If System.IO.File.Exists(path) = True Then
            'MsgBox("Đã lưu dữ liệu!")
        End If
    End Sub
    Public Sub SaveFile(table As DataGridView, name As String)
        Dim textData As String = "@"
        For i = 0 To table.RowCount - 1
            'textData = textData + "@"
            For j = 0 To table.ColumnCount - 1
                Try
                    If (IsNothing(table.Rows(i).Cells(j).Value)) Then
                        table.Rows(i).Cells(j).Value = ""
                    End If
                    Dim data As String = table.Rows(i).Cells(j).Value.ToString
                    If j = table.ColumnCount - 1 Then
                        If i = table.RowCount - 1 Then
                            textData = textData + data
                        Else
                            textData = textData + data + "@"
                        End If
                    Else
                        textData = textData + data + "_"
                    End If
                Catch ex As System.Exception
                    If j = table.ColumnCount - 1 Then
                        textData = textData + ""
                    Else
                        textData = textData + "" + "_"
                    End If
                End Try
            Next
        Next

        WirteText(textData, DuongDanData + "\" + name + ".txt")
    End Sub
End Class
