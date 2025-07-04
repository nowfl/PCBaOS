Imports System.Reflection

Public Class teess

    Private Sub teess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim assemblyFile As String = "C:\Users\User\Documents\Visual Studio 2010\Projects\TestApplication\TestApplication\bin\Debug\TestApplication.dll"
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(assemblyFile)
        Dim type As Type = assembly.GetType("ClassLibrary1.Class1")
        Dim instance As Object = Activator.CreateInstance(type)
        Dim newForm As Form = CType(instance, Form)
        newForm.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim assemblyFile As String = "C:\Users\User\Documents\Visual Studio 2010\Projects\TestApplication\TestApplication\bin\Debug\TestApplication.dll"
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(assemblyFile)
        Dim type As Type = assembly.GetType("ClassLibrary1.Form1")
        If GetType(Form).IsAssignableFrom(type) Then
            Dim newForm As Form = CType(Activator.CreateInstance(type), Form)
            newForm.Show()
        Else
            MessageBox.Show("The specified type cannot be cast to Form.")
        End If
    End Sub
End Class