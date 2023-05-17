Imports System
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports Autodesk.AutoCAD.ApplicationServices.DocumentExtension
Imports Autodesk.AutoCAD.ApplicationServices.Document
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports Autodesk.AutoCAD.Colors
Public Module Toa_Do

    Public x1 As Double
    Public y1 As Double
    Public z1 As Double

    Public x2 As Double
    Public x3 As Double
    Public x4 As Double

    Public y2 As Double
    Public y3 As Double
    Public y4 As Double

    Public z2 As Double
    Public z3 As Double
    Public z4 As Double

End Module
Module Extensions
    <Extension()>
    Function GetFormat(ByVal filename As String) As ImageFormat
        Dim imf = ImageFormat.Png

        If filename.Contains(".") Then
            Dim ext As String = filename.Substring(filename.LastIndexOf(".") + 1)
            If ext.Length > 3 Then ext = ext.Substring(0, 3)

            Select Case ext.ToLower()
                Case "bmp"
                    imf = ImageFormat.Bmp
                Case "gif"
                    imf = ImageFormat.Gif
                Case "jpg"
                    imf = ImageFormat.Jpeg
                Case "tif"
                    imf = ImageFormat.Tiff
                Case "wmf"
                    imf = ImageFormat.Wmf
                Case Else
                    imf = ImageFormat.Png
            End Select
        End If
        Return imf
    End Function
End Module
