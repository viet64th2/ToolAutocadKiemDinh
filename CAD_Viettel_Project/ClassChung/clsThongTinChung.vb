Imports System.IO
Public Class clsThongTinChung
    Private m_DiaDiem As String
    Private m_MaTram As String
    Private m_LoaiCot As String
    Private m_ChieuCao As Single
    Private m_TietDienCot As String
    Private m_ViTriDat As String
    Private m_BeTongMong As String
    Private m_SoMong As Integer
    Private m_SoChanCot As Integer
    Private m_ChieuCaoDot As Single
    Private m_SoTangDay As Integer
    Private m_SoDot As Integer
    Private m_GaChongXoay As String
    Private m_LoaiGaChongXoay As String
    Private m_KichThuocChanCot As String
    Private m_LoaiMong1 As String
    Private m_LoaiMong2 As String
    Private m_LoaiMong3 As String
    Private m_LoaiMong4 As String
    Private m_MongNoiChung As String



#Region "Property"
    Public Property KichThuocChanCot As String
        Set(value As String)
            m_KichThuocChanCot = value
        End Set
        Get
            Return m_KichThuocChanCot
        End Get
    End Property
    Public Property MaTram As String
        Set(value As String)
            m_MaTram = value
        End Set
        Get
            Return m_MaTram
        End Get
    End Property
    Public Property LoaiMong1 As String
        Set(value As String)
            m_LoaiMong1 = value
        End Set
        Get
            Return m_LoaiMong1
        End Get
    End Property
    Public Property LoaiMong2 As String
        Set(value As String)
            m_LoaiMong2 = value
        End Set
        Get
            Return m_LoaiMong2
        End Get
    End Property
    Public Property LoaiMong3 As String
        Set(value As String)
            m_LoaiMong3 = value
        End Set
        Get
            Return m_LoaiMong3
        End Get
    End Property
    Public Property LoaiMong4 As String
        Set(value As String)
            m_LoaiMong4 = value
        End Set
        Get
            Return m_LoaiMong4
        End Get
    End Property
    Public Property LoaiGaChongXoay As String
        Set(value As String)
            m_LoaiGaChongXoay = value
        End Set
        Get
            Return m_LoaiGaChongXoay
        End Get
    End Property
    Public Property DiaDiem As String
        Set(value As String)
            m_DiaDiem = value
        End Set
        Get
            Return m_DiaDiem
        End Get
    End Property
    Public Property LoaiCot As String
        Set(value As String)
            m_LoaiCot = value
        End Set
        Get
            Return m_LoaiCot
        End Get
    End Property
    Public Property ChieuCao As Single
        Set(value As Single)
            m_ChieuCao = value
        End Set
        Get
            Return m_ChieuCao
        End Get
    End Property
    Public Property ChieuCaoDot As Single
        Set(value As Single)
            m_ChieuCaoDot = value
        End Set
        Get
            Return m_ChieuCaoDot
        End Get
    End Property
    Public Property ViTriDat As String
        Set(value As String)
            m_ViTriDat = value
        End Set
        Get
            Return m_ViTriDat
        End Get
    End Property
    Public Property GaChongXoay As String
        Set(value As String)
            m_GaChongXoay = value
        End Set
        Get
            Return m_GaChongXoay
        End Get
    End Property
    Public Property TietDienCot As String
        Set(value As String)
            m_TietDienCot = value
        End Set
        Get
            Return m_TietDienCot
        End Get
    End Property
    Public Property BeTongMong As String
        Set(value As String)
            m_BeTongMong = value
        End Set
        Get
            Return m_BeTongMong
        End Get
    End Property
    Public Property SoDot As Integer
        Set(value As Integer)
            m_SoDot = value
        End Set
        Get
            Return m_SoDot
        End Get
    End Property
    Public Property SoMong As Integer
        Set(value As Integer)
            m_SoMong = value
        End Set
        Get
            Return m_SoMong
        End Get
    End Property
    Public Property SoChanCot As Integer
        Set(value As Integer)
            m_SoChanCot = value
        End Set
        Get
            Return m_SoChanCot
        End Get
    End Property
    Public Property SoTangDay As Integer
        Set(value As Integer)
            m_SoTangDay = value
        End Set
        Get
            Return m_SoTangDay
        End Get
    End Property

    Public Property MongNoiChung As String
        Get
            Return m_MongNoiChung
        End Get
        Set(value As String)
            m_MongNoiChung = value
        End Set
    End Property
#End Region

End Class
