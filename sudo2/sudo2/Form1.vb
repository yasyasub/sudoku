Imports System.IO
Public Class frmSudo

    'объявляем переменные
    'Массивы
    Public lblN() As Label  'массив ярлыков чисел на поле
    Public lblKlav(10) As Label  'массив ярлыков чисел от 1 до 9 + del

    Dim full As Byte        'full - размер массива, full = razmer * razmer - 1
    Dim r As New Random     'случайное число

    'элементы для ярлыка
    'размер шрифта
    Dim bolwoiWrift = 14
    'размер элем
    Public Wir As Byte = 50
    Public Dlin As Byte = 50

    Dim rasst As Byte = 3 'промежуток между соседними
    Dim startPosL As Byte = 40 'начальное положение 1 ярлыка по X
    Dim startPosH As Byte = 40 'начальное положение 1 ярлыка по Y
    Dim intervalH,
        intervalW

    'новый расклад берем из файла
    '!!!Изменения- "sudo" заменяем файл на массив из модуля
    'Dim origMasFile = "sudo"
    ' Dim massOrig As String() = IO.File.ReadAllLines(origMasFile, System.Text.Encoding.Default)

    'цвета поля
    Dim fonColor = Color.White
    Dim fonColor2 = Color.Gray

    'цвета шрифтов
    Dim wriftOtv = Color.Blue
    Dim wriftOrig = Color.Black

    '!!!Изменения
    Dim wriftOtvDa = Color.Green
    Dim wriftOtvNet = Color.Red

    '
    Dim mass4is(81)
    Dim chislo As Byte
    Dim isto4nik
    Dim rezerv As String

    Dim tmpNumbZ = ""

    '---------------------------------------------
    '--- SUB ------------
    '---старт - строим таблицу
    Sub start(razmer As Integer)
        intervalW = rasst + Wir 'сдвиг соседнего ярлыка по по Х
        intervalH = rasst + Dlin 'сдвиг соседнего ярлыка по по У

        ' razmer = Val(frmTablNastr.num.Value)      'razmer - размерность квадрата из нумерации num
        full = razmer * razmer - 1   'full - размер массива

        'меняем размер массива
        ReDim lblN(full)


        'располагаем наши ярлыки на форме и задаем им числа
        For i = 0 To full             'от 0 до последнего элемента
            lblN(i) = New Label       'каждый элемент массива - новый ярлык

            'размеры у всех одинаковые)
            lblN(i).Height = Dlin
            lblN(i).Width = Wir

            Select Case i
                Case 0 To (razmer - 1) '1 строка ярлыков
                    lblN(i).Left = startPosL + i * intervalW
                    lblN(i).Top = startPosH


                Case (razmer) To (razmer * 2 - 1) '2 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer) * intervalW
                    lblN(i).Top = startPosH + intervalH


                Case (razmer * 2) To (razmer * 3 - 1) '3 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 2) * intervalW
                    lblN(i).Top = startPosH + intervalH * 2


                Case (razmer * 3) To (razmer * 4 - 1) '4 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 3) * intervalW
                    lblN(i).Top = startPosH + intervalH * 3


                Case (razmer * 4) To (razmer * 5 - 1) '5 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 4) * intervalW
                    lblN(i).Top = startPosH + intervalH * 4

                Case (razmer * 5) To (razmer * 6 - 1) '6 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 5) * intervalW
                    lblN(i).Top = startPosH + intervalH * 5

                Case (razmer * 6) To (razmer * 7 - 1) '7 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 6) * intervalW
                    lblN(i).Top = startPosH + intervalH * 6

                Case (razmer * 7) To (razmer * 8 - 1) '8 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 7) * intervalW
                    lblN(i).Top = startPosH + intervalH * 7

                Case (razmer * 8) To (razmer * 9 - 1) '9 строка ярлыков
                    lblN(i).Left = startPosL + (i - razmer * 8) * intervalW
                    lblN(i).Top = startPosH + intervalH * 8
            End Select

            '-------------
            lblN(i).Text = Str(massOrig(i)) '+ Str(i)
            '--------

            lblN(i).TextAlign = ContentAlignment.MiddleCenter    'выравниваем текст по центру
            lblN(i).Font = New System.Drawing.Font("Arial", bolwoiWrift)  'задаем шрифт

            lblN(i).ForeColor = Color.Black

            lblN(i).BackColor = Color.Silver                     'задаем фон


            'кликаем - получаем индекс элемента
            AddHandler lblN(i).Click, AddressOf lblNClick
            Me.Controls.AddRange(Me.lblN)
            'ЭНД --- кликаем - получаем индекс
            'обработка этого события дальше


            lblN(i).Visible = True                               'делаем видимыми
            Me.Controls.Add(lblN(i))                             'добавляем на форму
        Next


    End Sub

    'клавиатура - кнопки
    Sub klavka()

        'располагаем наши ярлыки на форме и задаем им числа
        For i = 0 To 9             'от 0 до последнего элемента
            lblKlav(i) = New Label       'каждый элемент массива - новый ярлык

            Dim interval = 45
            Dim startPosLKl = 10
            Dim startPosHKl = 10

            'размеры у всех одинаковые)
            lblKlav(i).Height = 40
            lblKlav(i).Width = 40

            Select Case i
                Case 0 To 2 '1 строка ярлыков
                    lblKlav(i).Left = startPosLKl + i * interval
                    lblKlav(i).Top = startPosHKl

                Case 3 To 5 '2 строка ярлыков
                    lblKlav(i).Left = startPosLKl + (i - 3) * interval
                    lblKlav(i).Top = startPosHKl + interval

                Case 6 To 8 '3 строка ярлыков
                    lblKlav(i).Left = startPosLKl + (i - 6) * interval
                    lblKlav(i).Top = startPosHKl + interval * 2

                Case 9
                    lblKlav(i).Width = 40 * 3 + 10
                    lblKlav(i).Left = startPosLKl
                    lblKlav(i).Top = startPosHKl + interval * 3


            End Select

            '-------------
            lblKlav(i).Text = i + 1
            If i = 9 Then
                lblKlav(i).Text = "Del"
            End If

            '--------

            lblKlav(i).TextAlign = ContentAlignment.MiddleCenter    'выравниваем текст по центру
            lblKlav(i).Font = New System.Drawing.Font("Arial", bolwoiWrift)  'задаем шрифт

            lblKlav(i).ForeColor = Color.Black

            lblKlav(i).BackColor = Color.White
            '(Color.FromArgb(255 * Rnd(), 255 * Rnd(), 255 * Rnd()))                    'задаем фон
            'Else
            'lblKlav(i).BackColor = Color.Silver                     'задаем фон
            'End If

            'кликаем - получаем индекс элемента
            AddHandler lblKlav(i).Click, AddressOf lblKlavClick
            'Me.Controls.AddRange(Me.lblN)
            Me.grKlava.Controls.AddRange(Me.lblKlav)
            'ЭНД --- кликаем - получаем индекс
            'обработка этого события дальше


            lblKlav(i).Visible = True                               'делаем видимыми
            Me.grKlava.Controls.Add(lblKlav(i))                             'добавляем на грбокс
        Next

    End Sub

    '---кликаем - получаем индекс - числа на поле
    Private Sub lblNClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        'Dim isto4nik, nexts

        'Если надо узнать именно индекс в массиве, 
        'то ищем объект sender
        i = Array.IndexOf(lblN, sender)
        'isto4nik = lblN(i).Text
        isto4nik = i

        grKlava.Visible = False

        '!!!Изменения
        'если НЕ черная цифра (пусто или синий или красный)
        If lblN(i).Text = "" Or lblN(i).ForeColor = wriftOtv Or lblN(i).ForeColor = wriftOtvNet Then

            'MsgBox(massOrig(i))
            '!!!
            tmpNumbZ = massOrig(i)

            If grKlava.Visible = True Then
                grKlava.Visible = False
            Else
                grKlava.Visible = True
            End If

            'положение клавы
            If i < 40 Then
                grKlava.Top = lblN(i).Top + 50 'grKlava.Height
                grKlava.Left = lblN(i).Left
            Else
                grKlava.Top = lblN(i).Top - grKlava.Height
                grKlava.Left = lblN(i).Left
            End If
        Else

        End If

    End Sub

    '---кликаем - получаем индекс - клавиатура
    Private Sub lblKlavClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        'Если надо узнать именно индекс в массиве, 
        'то ищем объект sender
        i = Array.IndexOf(lblKlav, sender)

        If i <> 9 Then
            lblN(isto4nik).Text = lblKlav(i).Text
            'вставить число - проверка

            '!!!Изменения
            If chPodskazki.Checked Then
                If tmpNumbZ = lblKlav(i).Text Then
                    lblN(isto4nik).ForeColor = wriftOtvDa
                Else
                    lblN(isto4nik).ForeColor = wriftOtvNet

                End If
            Else
                lblN(isto4nik).ForeColor = wriftOtv
            End If

        Else
            lblN(isto4nik).Text = ""
        End If

        'MsgBox(isto4nik)

        grKlava.Visible = False
    End Sub

    '--пермешивание комбинаций
    'строки
    Sub mixStroki(c1 As Integer, c2 As Integer)
        'Dim c1 = 9 * r.Next(0, 9) ' 9 * 3 '4
        'Dim c2 = 9 * r.Next(0, 9) ' 9 * 5 '6

        Dim msX_(10)
        Dim msY_(10)

        '4->x '6->Y 'Y->4 'x->6

        '4=>X
        For i = c1 To c1 + 8
            msX_(i - c1) = massOrig(i)
        Next

        '6=>Y
        For i = c2 To c2 + 8
            msY_(i - c2) = massOrig(i)
        Next

        'Y->4
        For i = c1 To c1 + 8
            massOrig(i) = msY_(i - c1)
        Next

        'x=>6
        For i = c2 To c2 + 8
            massOrig(i) = msX_(i - c2)
        Next


        For i = 0 To 80
            lblN(i).Text = massOrig(i)
        Next

    End Sub

    'строки ПЛЮС
    Sub mixStrokiPlus()
        Dim c01, c02 As Integer
        Dim xzw

        xzw = Int(Rnd() * 100)

        If xzw < 30 Then
            c01 = r.Next(0, 3)
            c02 = r.Next(0, 3)
        End If

        If xzw > 30 And xzw < 60 Then
            c01 = r.Next(3, 6)
            c02 = r.Next(3, 6)
        End If

        If xzw > 60 Then
            c01 = r.Next(6, 9)
            c02 = r.Next(6, 9)
        End If

        mixStroki(9 * c01, 9 * c02)
    End Sub

    'столбцы
    Sub mixStolb(c1 As Integer, c2 As Integer)
        Randomize()
        'r.Next(min2, max2)
        Dim x(10)
        Dim y(10)
        'Dim c1 = r.Next(0, 9) '4
        'Dim c2 = r.Next(0, 9) '6

        For i = 0 To 8
            x(i) = lblN(c1 + 9 * i).Text
            y(i) = lblN(c2 + 9 * i).Text
        Next

        For i = 0 To 8
            lblN(c2 + 9 * i).Text = x(i)
            lblN(c1 + 9 * i).Text = y(i)
        Next

    End Sub

    'столбцы ПЛЮС
    Sub mixStolbPlus()
        Dim c01, c02 As Integer
        Dim xzw '= 65

        xzw = Int(Rnd() * 100)

        If xzw < 30 Then
            c01 = r.Next(0, 3)
            c02 = r.Next(0, 3)
        End If

        If xzw > 30 And xzw < 60 Then
            c01 = r.Next(3, 6)
            c02 = r.Next(3, 6)
        End If

        If xzw > 60 Then
            c01 = r.Next(6, 9)
            c02 = r.Next(6, 9)
        End If
        mixStolb(c01, c02)
    End Sub
    '--

    'расцветка
    Sub colorTabl()
        For i = 0 To 80
            lblN(i).BackColor = fonColor
            lblN(i).ForeColor = wriftOrig
        Next

        For i = 3 To 5
            For j = 0 To 2
                lblN(i + 9 * j).BackColor = fonColor2
            Next
        Next

        For i = 27 To 29
            For j = 0 To 2
                lblN(i + 9 * j).BackColor = fonColor2
            Next
        Next

        For i = 33 To 35
            For j = 0 To 2
                lblN(i + 9 * j).BackColor = fonColor2
            Next
        Next

        For i = 57 To 59
            For j = 0 To 2
                lblN(i + 9 * j).BackColor = fonColor2
            Next
        Next

    End Sub

    'создание массива с индексами
    Sub mass4isCreat()
        For i = 0 To 80
            mass4is(i) = i
        Next
    End Sub

    'перемешивание массива 
    Public Sub mixx(mas As Array)
        Dim element1, element2, x, y
        Randomize()
        For i = 0 To 10000
            x = Int(Rnd() * mas.Length)  'Определили случайный элемент массива с номером х
            y = Int(Rnd() * mas.Length)  'Определили случайный элемент массива с номером y
            element1 = mas(x)           'Запомнили значение случайного х-элемента массива
            element2 = mas(y)           'Запомнили значение случайного y-элемента массива
            mas(y) = element1           'Присвоили случайному x элементу значение y элемента
            mas(x) = element2           'Присвоили случайному y элементу значение x элемента
        Next
    End Sub


    'удаление некоторых значений
    Sub del4is(kolvoYd_ As Integer)
        mass4isCreat()
        mixx(mass4is)

        For i = 0 To kolvoYd_
            lblN(mass4is(i)).Text = ""
        Next
    End Sub

    'удаление случайных элементов ПО УР СЛОЖН
    Sub delElemz()
        Dim delElem = 0

        If RadioButton1.Checked = True Then
            delElem = r.Next(25, 30)
        End If
        If RadioButton2.Checked = True Then
            delElem = r.Next(30, 35)
        End If
        If RadioButton3.Checked = True Then
            delElem = r.Next(35, 45)
        End If
        If RadioButton4.Checked = True Then
            delElem = r.Next(45, 55)
        End If
        If RadioButton5.Checked = True Then
            delElem = r.Next(55, 65)
        End If

        del4is(delElem)
    End Sub

    'сейф файл
    Sub saveFile()
        ' Указываем начальную папку
        SFD1.InitialDirectory = Application.StartupPath '+ "\bin"
        ' Указываем заголовок
        SFD1.Title = "Сохранить игру"
        ' При помощи фильтра можно отбросить ненужные типы файлов
        SFD1.Filter = "Save|*.ssv|Все|*.*"
        ' Если есть список выбора типов, то можно указать какой тип будет выбран при загрузке диалога
        SFD1.FilterIndex = 1

        If SFD1.ShowDialog = DialogResult.OK Then
            ' rezerv - переменная со значениями
            IO.File.WriteAllText(SFD1.FileName, rezerv, System.Text.Encoding.Default)
        End If

    End Sub

    'откр файл
    Sub openFile()
        ' Указываем начальную папку
        OFD1.InitialDirectory = Application.StartupPath '+ "\bin"
        ' Указываем заголовок
        OFD1.Title = "Открыть сохранение"
        ' При помощи фильтра можно отбросить ненужные типы файлов
        OFD1.Filter = "Save|*.ssv|Все|*.*"
        ' Если есть список выбора типов, то можно указать какой тип будет выбран при загрузке диалога
        OFD1.FilterIndex = 1

        If OFD1.ShowDialog = DialogResult.OK Then
            Dim masSav() = IO.File.ReadAllLines(OFD1.FileName, System.Text.Encoding.Default)
            For i = 0 To 80
                If masSav(i) > 0 Then
                    If masSav(i) > 10 Then
                        lblN(i).Text = Val(masSav(i)) Mod 10
                        lblN(i).ForeColor = wriftOtv
                    Else
                        lblN(i).Text = masSav(i)
                    End If
                Else
                    lblN(i).Text = ""
                End If
            Next
        End If
    End Sub

    Private Sub frmSudo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'frmMain.Show()
    End Sub

    '---элементы
    'загрузка
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        start(9)
        klavka()
        colorTabl()
        For j = 0 To 100
            mixStrokiPlus()
            mixStolbPlus()
        Next

        delElemz()
    End Sub

    '!!!
    Sub newGamez()
        GroupBox1.Visible = False
        Me.Cursor = Cursors.WaitCursor
        colorTabl()
        For j = 0 To 100
            mixStrokiPlus()
            mixStolbPlus()
        Next

        rezerv = ""
        For i = 0 To 80
            rezerv += massOrig(i) + vbCrLf
        Next

        'IO.File.WriteAllText(origMasFile, rezerv, System.Text.Encoding.Default)

        delElemz()
        Me.Cursor = Cursors.Default
    End Sub

    'Новая игра
    Private Sub НоваяИграToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НоваяИграToolStripMenuItem.Click
        newGamez()
    End Sub

    'load
    Private Sub ЗагрузитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗагрузитьToolStripMenuItem.Click
        openFile()
    End Sub

    '!!!!
    'сейф
    Private Sub СохранитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СохранитьToolStripMenuItem.Click
        rezerv = ""
        For i = 0 To 80

            If lblN(i).Text = "" Then
                rezerv += "0" + vbCrLf
            Else
                If lblN(i).ForeColor = wriftOrig Or lblN(i).ForeColor = wriftOtvDa Then
                    rezerv += lblN(i).Text + vbCrLf
                Else
                    rezerv += "1" + lblN(i).Text + vbCrLf
                End If

            End If
        Next

        saveFile()
    End Sub

    'Настройки
    Private Sub НастройкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НастройкиToolStripMenuItem.Click
        ' в центре экрана
        GroupBox1.Top = (Me.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.Width / 2) - (GroupBox1.Width / 2)

        GroupBox1.Visible = True

    End Sub

    'сохр настр и начать новую игру
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        newGamez()


    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        GroupBox1.Visible = False
    End Sub

    'ВЫХОД
    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        'frmMain.Show()
    End Sub

    'ответ
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        For i = 0 To 80
            lblN(i).Text = massOrig(i)
        Next
        'mixStolb(0, 2)

    End Sub

    Private Sub GrKlava_Enter(sender As Object, e As EventArgs) Handles grKlava.Enter

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub SFD1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SFD1.FileOk

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged

    End Sub

    Private Sub XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XToolStripMenuItem.Click
        For i = 0 To 80
            lblN(i).Text = i
        Next
    End Sub



End Class

