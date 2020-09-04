Imports Bibliotheque
Public Class Tapie
    Dim placutage As Boolean 'si c'est un déplacement ou un parachutage
    Dim I, cb, cx, cy, x, y As Integer 'coordonnées des cases du plateau, cx,cy coordonnées du départ, x, y coordonnées d'arrivé, i, numéro de banque'
    Dim im As PictureBox
    Dim img As DragDropEffects
    Public Jeu As Plateau
    Dim Banque1(6) As PictureBox 'banque j1
    Dim Banque2(6) As PictureBox 'banque j2





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click   'Bouton abandon
        Me.Close()
    End Sub

    Private Sub Tapie_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'initialisation du jeu
        Dim J1 As String, J2 As String
        J1 = InputBox("Entrer nom du joueur 1", "") 'recuperation nom des deux joeurs
        J2 = InputBox("Entrer nom du joueur 2", "")
        If (J1 = "" Or J1.Length > 15 Or J1 = J2) Then 'si pas de nom donnés, ou supérieur 15 caractères, surnom affectueux, pour éviter qu'ils soient perdus
            J1 = "Dickhead"
        End If
        If (J2 = "" Or J2.Length > 15) Then
            J2 = "Dickheadbis"
        End If
        Jeu = New Plateau(J1, J2) 'création du plateau de jeu
        Label1.Text = Jeu.joueur1.Nomjoueur
        Label2.Text = Jeu.joueur2.Nomjoueur
        PictureBox1.AllowDrop = True 'initialisation allowdrop
        PictureBox2.AllowDrop = True
        PictureBox3.AllowDrop = True
        PictureBox4.AllowDrop = True
        PictureBox5.AllowDrop = True
        PictureBox6.AllowDrop = True
        PictureBox7.AllowDrop = True
        PictureBox8.AllowDrop = True
        PictureBox9.AllowDrop = True
        PictureBox10.AllowDrop = True
        PictureBox11.AllowDrop = True
        PictureBox12.AllowDrop = True

        Banque1(0) = PictureBox21 'initialisation de la banque
        Banque1(1) = PictureBox22
        Banque1(2) = PictureBox23
        Banque1(3) = PictureBox24
        Banque1(4) = PictureBox25
        Banque1(5) = PictureBox26
        Banque2(0) = PictureBox14
        Banque2(1) = PictureBox15
        Banque2(2) = PictureBox16
        Banque2(3) = PictureBox17
        Banque2(4) = PictureBox18
        Banque2(5) = PictureBox19
        label5change()
        If (Jeu.tour = 1) Then 'msgbox pour aider à voir qui commence
            MsgBox("C'est au tour de " + Jeu.joueur1.Nomjoueur)
        Else
            MsgBox("C'est au tour de " + Jeu.joueur2.Nomjoueur)
        End If

    End Sub
    Private Sub label5change() 'mise à jour label 5 informant déplacement
        If (Jeu.tour = 1) Then
            Label5.Text = ("C'est au tour de " + Jeu.joueur1.Nomjoueur)
        Else
            Label5.Text = ("C'est au tour de " + Jeu.joueur2.Nomjoueur)
        End If
    End Sub


    'objectif pas encore réussi : Annulé le drag&drop n'efface pas la case

    ''Drag & drop :
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        cx = 3 'mis à jour coord départ
        cy = 2
        placutage = True 'c'est un déplacement
        PictureBox_MouseMove(sender, e) 'on passe au commun idem pour les autres
    End Sub
    Private Sub PicturBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        cx = 3
        cy = 1
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox3_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseMove
        cx = 3
        cy = 0
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub

    Private Sub PicturBox4_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseMove
        cx = 2
        cy = 2
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox5_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox5.MouseMove
        cx = 2
        cy = 1
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox6.MouseMove
        cx = 2
        cy = 0
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub

    Private Sub PicturBox7_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox7.MouseMove
        cx = 1
        cy = 2
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox8_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox8.MouseMove
        cx = 1
        cy = 1
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox9_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox9.MouseMove
        cx = 1
        cy = 0
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox10_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox10.MouseMove
        cx = 0
        cy = 2
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox11_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox11.MouseMove
        cx = 0
        cy = 1
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox12_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox12.MouseMove
        cx = 0
        cy = 0
        placutage = True
        PictureBox_MouseMove(sender, e)
    End Sub
    Private Sub PicturBox14_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox14.MouseMove
        If (Jeu.tour = 2) Then 'si c'est la bonne banque
            cb = 0 ' MAJ numéro de banque
            placutage = False ' C'est un parachutage
            PictureBox_MouseMove(sender, e) 'tronc commun, idem pour les autres
        End If
    End Sub
    Private Sub PicturBox15_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox15.MouseMove
        If (Jeu.tour = 2) Then
            cb = 1
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox16_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox16.MouseMove
        If (Jeu.tour = 2) Then
            cb = 2
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox17_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox17.MouseMove
        If (Jeu.tour = 2) Then
            cb = 3
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox18_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox18.MouseMove
        If (Jeu.tour = 2) Then
            cb = 4
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox19_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox19.MouseMove
        If (Jeu.tour = 2) Then
            cb = 5
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox21_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox21.MouseMove
        If (Jeu.tour = 1) Then
            cb = 0
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox22_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox22.MouseMove
        If (Jeu.tour = 1) Then
            cb = 1
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox23_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox23.MouseMove
        If (Jeu.tour = 1) Then
            cb = 2
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox24_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox24.MouseMove
        If (Jeu.tour = 1) Then
            cb = 3
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox25_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox25.MouseMove
        If (Jeu.tour = 1) Then
            cb = 4
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub
    Private Sub PicturBox26_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox26.MouseMove
        If (Jeu.tour = 1) Then
            cb = 5
            placutage = False
            PictureBox_MouseMove(sender, e)
        End If
    End Sub

    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) 'drag


        If e.Button = MouseButtons.Left Then
            im = CType(sender, PictureBox)
            If (im.Image IsNot Nothing) Then
                img = im.DoDragDrop(im.Image, DragDropEffects.Move)

                If (im.Image IsNot Nothing) Then
                    If img = DoDragDrop(im.Image, DragDropEffects.Move) Then

                    End If

                End If
            End If
        End If
    End Sub

    Private Sub PictureBox2_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox2.DragEnter, PictureBox1.DragEnter, PictureBox3.DragEnter, PictureBox4.DragEnter, PictureBox5.DragEnter, PictureBox6.DragEnter, PictureBox7.DragEnter, PictureBox8.DragEnter, PictureBox9.DragEnter, PictureBox10.DragEnter, PictureBox11.DragEnter, PictureBox12.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then 'drag enter
            e.Effect = DragDropEffects.Move

        Else

            e.Effect = DragDropEffects.None

        End If
    End Sub
    Private Sub PicturBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        If (placutage = True) Then 'si c'est un déplacement
            I = Jeu.validdeplace(cx, cy, 3, 2) 'fonction validdeplace
            x = 3 'mis à jour coordonnées arrivé
            y = 2
        ElseIf (placutage = False) Then 'si c'est un parachutage
            I = Jeu.parachutage(cb, 3, 2) 'fonction de parachutage
        End If
        PictureBoxChange(sender, e) ' tronc commmun, idem pour les autres

    End Sub
    Private Sub PicturBox2_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox2.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 3, 1)
            x = 3
            y = 1
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 3, 1)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox3_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox3.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 3, 0)
            x = 3
            y = 0
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 3, 0)
        End If
        PictureBoxChange(sender, e)

    End Sub

    Private Sub PicturBox4_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox4.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 2, 2)
            x = 2
            y = 2
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 2, 2)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox5_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox5.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 2, 1)
            x = 2
            y = 1
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 2, 1)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox6_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox6.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 2, 0)
            x = 2
            y = 0
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 2, 0)
        End If
        PictureBoxChange(sender, e)

    End Sub

    Private Sub PicturBox7_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox7.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 1, 2)
            x = 1
            y = 2
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 1, 2)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox8_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox8.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 1, 1)
            x = 1
            y = 1
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 1, 1)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox9_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox9.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 1, 0)
            x = 1
            y = 0
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 1, 0)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox10_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox10.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 0, 2)
            x = 0
            y = 2
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 0, 2)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox11_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox11.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 0, 1)
            x = 0
            y = 1
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 0, 1)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PicturBox12_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox12.DragDrop
        If (placutage = True) Then
            I = Jeu.validdeplace(cx, cy, 0, 0)
            x = 0
            y = 0
        ElseIf (placutage = False) Then
            I = Jeu.parachutage(cb, 0, 0)
        End If
        PictureBoxChange(sender, e)

    End Sub
    Private Sub PictureBoxChange(sender As Object, e As DragEventArgs)
        If (I = 0) Then ' si échec, pas de drop
            Label6.Text = "Echec du déplacement" 'label informatif affiche échec
        Else 'si on a réussi le déplacement

            im.Image = Nothing 'permet de vider l'emplacement de l'imgage de base si le déplacement est validé 
            If (CType(sender, PictureBox).Image IsNot Nothing) Then 'si case d'arrivé n'est pas vide ..
                inbanque(sender) '..on l'a met dans la banque
            End If
            CType(sender, PictureBox).Image = e.Data.GetData(DataFormats.Bitmap) 'l'image de la case d'arrivé devient l'image de la case de départ
            If (Jeu.plateaudejeu(x, y).Guerrier = True And placutage = True) Then 'si on a fait un déplacement et que l'on a transformé le kodama en guerrier
                If (Jeu.tour = 1) Then ' mis à jour de l'image en kodama samurai, en fonction du joueur
                    CType(sender, PictureBox).Image = CType(My.Resources.Kodama_samouraiInverse, Image)
                ElseIf (Jeu.tour = 2) Then
                    CType(sender, PictureBox).Image = CType(My.Resources.Kodama_samourai, Image)
                End If
            End If
            Label6.Text = "Succès du déplacement" 'label informatif du succès
            label5change() 'changement de à qui le tour

            If (I = 2) Then 'si c'est la fin du jeu et que l'un à gagné
                If (Jeu.tour = 2) Then 'tour inversé car changement de tour à la fin
                    MsgBox(Jeu.joueur1.Nomjoueur + " a gagné, Fin du jeu")
                ElseIf (Jeu.tour = 1) Then
                    MsgBox(Jeu.joueur2.Nomjoueur + " a gagné, Fin du jeu")
                End If
                Close()
            ElseIf (I = 3) Then ' si égalité car irrésolution
                MsgBox("Fin du jeu égalité, personne n'a gagné")
                Close()
            End If
        End If

    End Sub
    Private Sub inbanque(sender As Object)
        Dim test As Boolean = False 'envoit dans banque
        Dim i As Integer = 0

        If (Jeu.tour = 2) Then 'si c'est le joueur 1 (rappel, tour inversé
            While (test = False) 'trouve un espace libre dans la banque, met le pion adverse retourné dans sa banque
                If ((Banque1(i).Image Is Nothing)) Then
                    test = True
                    Banque1(i).Image = CType(sender, PictureBox).Image
                    Banque1(i).Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                    If (Jeu.joueur1.banque(i).numb = 2) Then 'si on a un kodama, on s'assure qu'il ne soit plus samurai
                        Banque1(i).Image = CType(My.Resources.kodama, Image)
                    End If
                Else
                    i = i + 1
                End If
            End While
        ElseIf (Jeu.tour = 1) Then
            While (test = False)
                If ((Banque2(i).Image Is Nothing)) Then
                    test = True
                    Banque2(i).Image = CType(sender, PictureBox).Image
                    Banque2(i).Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                    If (Jeu.joueur2.banque(i).numb = 2) Then
                        Banque2(i).Image = CType(My.Resources.kodamaInverse, Image)
                    End If
                Else
                    i = i + 1
                End If
            End While

        End If
    End Sub
End Class
