Imports Bibliotheque

Public Class Form1
    '  Private Sub btnOK_Click(sender As Object, e As EventArgs) Tapie.Show() REM lblMessage.Text = hw.Bonjour() End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Tapie.Show()
        REM lblMessage.Text = hw.Bonjour()
    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object,
   ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            VisitLink()
        Catch ex As Exception
            ' The error message
            MessageBox.Show("Unable to open link that was clicked.")
        End Try
    End Sub

    Sub VisitLink()
        ' Change the color of the link text by setting LinkVisited 
        ' to True.
        LinkLabel1.LinkVisited = True
        ' Call the Process.Start method to open the default browser 
        ' with a URL:
        System.Diagnostics.Process.Start("https://ent.iut-amiens.fr/pluginfile.php/14316/mod_resource/content/1/yokainomori-rulesF.pdf")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If LinkLabel1.Visible = True Then
            LinkLabel1.Visible = False
        Else
            LinkLabel1.Visible = True

        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Close()
    End Sub
End Class
