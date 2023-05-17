Public Module mbBienChung
    Public frm33d_DD_KG As New Form3Chan_3Mong_DD_KG
    Public frm33d_DD_CG As New Form3Chan_3Mong_DD_CG
    Public frm34d_DD_KG As New Form3Chan_4Mong_DD_KG
    Public frm34d_DD_CG As New Form3Chan_4Mong_DD_CG
    Public frm44d_DD_KG As New Form4Chan_4Mong_DD_KG
    Public frm44d_DD_CG As New Form4Chan_4Mong_DD_CG
    Public frm44d_TM_CG As New Form4Chan_4Mong_TM_CG
    Public frm44d_TM_KG As New Form4Chan_4Mong_TM_KG
    Public frm44d_L3d_K As New Form4Chan_4Mong_L3d_KG
    Public frmMD_TuDung As New FormMD_TuDung
    Public frmMB_TuDung As New FormMB_TuDung

    Public frmSetting As New FormSetting
    Public frmtestmd As New TestMatDung
    Public frmMain As FormMain
    Public frmMD_34d_L3_KG As New FormMD_3Chan_4Mong_L3_KG
    Public frmMD_34d_L3_CG As New FormMD_3Chan_4Mong_L3_CG
    Public frmMD_34d_l3_Trenmai_CG As New FormMD_3Chan_4Mong_L3_trenmaiCG
    Public frmMD_34d_L3_Trenmai_KG As New FormMD_3Chan_4Mong_L3_trenmaiKG
    Public textdauvao As String
    Public b_somong As Integer
    Public b_sochan As Integer
    Public b_sochancot As Integer
    Public b_trenmaiorduoidat As Integer
    Public b_bmong As Double
    Public b_hmong As Double
    Public b_b0mong As Double
    Public b_zmong As Double
    Public b_z0mong As Double
    Public b_h0mong As Double
    Public b_hchancot As Double
    Public b_bchancot As Double
    Public b_gocxoay As Double
    Public b_bgachongxoay As Double
    Public b_hgachongxoay As Double
    Public b_KTGaChongXoay As Double
    Public b_ScaleDim As Double
    Public b_ScaleText As Double
    Public b_d As Double    ' mo neo
    Public b_a As Double ' canh cot
    Public Tile As Double 'Ti le scale net dut mat bang
    Public b_agachongxoay As Double
    Public b_bmove As Double
    Public b_hmove As Double
    Public b_Mong1 As Double
    Public b_Mong2 As Double
    Public b_Mong3 As Double
    Public b_Mong4 As Double
    Public b_bMong1 As Double
    Public b_bMong2 As Double
    Public b_bMong3 As Double
    Public b_bMong4 As Double
    Public b_hMong1 As Double
    Public b_hMong2 As Double
    Public b_hMong3 As Double
    Public b_hMong4 As Double
    Public b_zMong1 As Double
    Public b_zMong2 As Double
    Public b_zMong3 As Double
    Public b_zMong4 As Double
    Public GocXoayMatBang As Double
    Public b_CaoDoMong As Double
    Public DuongDanThuVien As String = ""
    Public DuongDanData As String = ""
    Public MongNoiChung1 As String 'Móng nối chung cột cho mặt bằng 3 chân 4 móng
    Public MongNoiChung2 As String 'Móng nối chung cột cho mặt bằng 3 chân 4 móng
    Public IndexNoiDay1 As Integer = -1
    Public IndexNoiDay2 As Integer = -1
    Public frmTTC As New FormTTCcotDayCo
    Public frmTTC_TuDung As New FormTTCcotTuDung
    Public tableTTC As New DataTable
    Public listThongTinChung As ArrayList = New ArrayList
    Public ThongTinChung As New clsThongTinChung
    Public TiLeChu As Double
End Module

