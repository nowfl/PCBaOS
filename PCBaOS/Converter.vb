Public Class Converter
    Private Sub Converter_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Populate ComboBox1 with converting types
        ComboBox1.Items.Add("Length")
        ComboBox1.Items.Add("Weight")
        ComboBox1.Items.Add("Currency")
        ComboBox1.Items.Add("Temperature")
        ComboBox1.Items.Add("Volume")
        ComboBox1.Items.Add("Area")
        ComboBox1.SelectedItem = "Length"
        ComboBox2.SelectedItem = "km"
        ComboBox3.SelectedItem = "km"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Populate ComboBox2 and ComboBox3 with input and output units based on the selected converting type
        If ComboBox1.SelectedItem = "Length" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("km")
            ComboBox2.Items.Add("m")
            ComboBox2.Items.Add("cm")
            ComboBox2.SelectedItem = "km"

            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("km")
            ComboBox3.Items.Add("m")
            ComboBox3.Items.Add("cm")
            ComboBox3.SelectedItem = "km"
        ElseIf ComboBox1.SelectedItem = "Weight" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("kg")
            ComboBox2.Items.Add("g")
            ComboBox2.SelectedItem = "kg"

            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("kg")
            ComboBox3.Items.Add("g")
            ComboBox3.SelectedItem = "kg"
        ElseIf ComboBox1.SelectedItem = "Currency" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("USD")
            ComboBox2.Items.Add("EUR")
            ComboBox2.Items.Add("GBP")
            ComboBox2.SelectedItem = "USD"

            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("USD")
            ComboBox3.Items.Add("EUR")
            ComboBox3.Items.Add("GBP")
            ComboBox3.SelectedItem = "USD"
        ElseIf ComboBox1.SelectedItem = "Temperature" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Celsius")
            ComboBox2.Items.Add("Fahrenheit")
            ComboBox2.Items.Add("Kelvin")
            ComboBox2.SelectedItem = "Celsius"

            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Celsius")
            ComboBox3.Items.Add("Fahrenheit")
            ComboBox3.Items.Add("Kelvin")
            ComboBox3.SelectedItem = "Celsius"
        ElseIf ComboBox1.SelectedItem = "Volume" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Liters")
            ComboBox2.Items.Add("Milliliters")
            ComboBox2.Items.Add("Cubic Meters")
            ComboBox2.Items.Add("Cubic Feet")
            ComboBox2.SelectedItem = "Liters"

            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Liters")
            ComboBox3.Items.Add("Milliliters")
            ComboBox3.Items.Add("Cubic Meters")
            ComboBox3.Items.Add("Cubic Feet")
            ComboBox3.SelectedItem = "Liters"
        ElseIf ComboBox1.SelectedItem = "Area" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Square meter")
            ComboBox2.Items.Add("Square kilometer")
            ComboBox2.Items.Add("Square mile")
            ComboBox2.SelectedItem = "Square meter"

            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("Square meter")
            ComboBox3.Items.Add("Square kilometer")
            ComboBox3.Items.Add("Square mile")
            ComboBox3.SelectedItem = "Square meter"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        'Update TextBox2 based on the selected converting type and units
        Dim inputValue As Double = Val(TextBox1.Text)
        Dim inputUnit As String = ComboBox2.SelectedItem
        Dim outputUnit As String = ComboBox3.SelectedItem
        Dim outputValue As Double

        If ComboBox1.SelectedItem = "Length" Then
            Select Case inputUnit
                Case "km"
                    Select Case outputUnit
                        Case "km"
                            outputValue = inputValue
                        Case "m"
                            outputValue = inputValue * 1000
                        Case "cm"
                            outputValue = inputValue * 100000
                    End Select
                Case "m"
                    Select Case outputUnit
                        Case "km"
                            outputValue = inputValue / 1000
                        Case "m"
                            outputValue = inputValue
                        Case "cm"
                            outputValue = inputValue * 100
                    End Select
                Case "cm"
                    Select Case outputUnit
                        Case "km"
                            outputValue = inputValue / 100000
                        Case "m"
                            outputValue = inputValue / 100
                        Case "cm"
                            outputValue = inputValue
                    End Select
            End Select
        ElseIf ComboBox1.SelectedItem = "Weight" Then
            Select Case inputUnit
                Case "kg"
                    Select Case outputUnit
                        Case "kg"
                            outputValue = inputValue
                        Case "g"
                            outputValue = inputValue * 1000
                    End Select
                Case "g"
                    Select Case outputUnit
                        Case "kg"
                            outputValue = inputValue / 1000
                        Case "g"
                            outputValue = inputValue
                    End Select
            End Select
        ElseIf ComboBox1.SelectedItem = "Currency" Then
            Select Case inputUnit
                Case "USD"
                    Select Case outputUnit
                        Case "USD"
                            outputValue = inputValue
                        Case "EUR"
                            outputValue = inputValue * 0.83
                        Case "GBP"
                            outputValue = inputValue * 0.72
                    End Select
                Case "EUR"
                    Select Case outputUnit
                        Case "USD"
                            outputValue = inputValue * 1.21
                        Case "EUR"
                            outputValue = inputValue
                        Case "GBP"
                            outputValue = inputValue * 0.87
                    End Select
                Case "GBP"
                    Select Case outputUnit
                        Case "USD"
                            outputValue = inputValue * 1.39
                        Case "EUR"
                            outputValue = inputValue * 1.15
                        Case "GBP"
                            outputValue = inputValue
                    End Select
            End Select
        ElseIf ComboBox1.SelectedItem = "Temperature" Then
            Select Case inputUnit
                Case "Celsius"
                    Select Case outputUnit
                        Case "Celsius"
                            outputValue = inputValue
                        Case "Fahrenheit"
                            outputValue = (inputValue * 1.8) + 32
                        Case "Kelvin"
                            outputValue = inputValue + 273.15
                    End Select
                Case "Fahrenheit"
                    Select Case outputUnit
                        Case "Celsius"
                            outputValue = (inputValue - 32) / 1.8
                        Case "Fahrenheit"
                            outputValue = inputValue
                        Case "Kelvin"
                            outputValue = (inputValue + 459.67) * 5 / 9
                    End Select
                Case "Kelvin"
                    Select Case outputUnit
                        Case "Celsius"
                            outputValue = inputValue - 273.15
                        Case "Fahrenheit"
                            outputValue = (inputValue * 1.8) - 459.67
                        Case "Kelvin"
                            outputValue = inputValue
                    End Select
            End Select
        ElseIf ComboBox1.SelectedItem = "Volume" Then
            Select Case inputUnit
                Case "Liters"
                    Select Case outputUnit
                        Case "Liters"
                            outputValue = inputValue
                        Case "Milliliters"
                            outputValue = inputValue * 1000
                        Case "Cubic Meters"
                            outputValue = inputValue / 1000
                        Case "Cubic Feet"
                            outputValue = inputValue * 0.0353
                    End Select
                Case "Milliliters"
                    Select Case outputUnit
                        Case "Liters"
                            outputValue = inputValue / 1000
                        Case "Milliliters"
                            outputValue = inputValue
                        Case "Cubic Meters"
                            outputValue = inputValue / 1000000
                        Case "Cubic Feet"
                            outputValue = inputValue * 0.0000353
                    End Select
                Case "Cubic Meters"
                    Select Case outputUnit
                        Case "Liters"
                            outputValue = inputValue * 1000
                        Case "Milliliters"
                            outputValue = inputValue * 1000000
                        Case "Cubic Meters"
                            outputValue = inputValue
                        Case "Cubic Feet"
                            outputValue = inputValue * 35.3147
                    End Select
                Case "Cubic Feet"
                    Select Case outputUnit
                        Case "Liters"
                            outputValue = inputValue / 0.0353
                        Case "Milliliters"
                            outputValue = inputValue / 0.0000353
                        Case "Cubic Meters"
                            outputValue = inputValue / 35.3147
                        Case "Cubic Feet"
                            outputValue = inputValue
                    End Select
            End Select
        ElseIf ComboBox1.SelectedItem = "Area" Then
            Select Case inputUnit
                Case "Square meter"
                    Select Case outputUnit
                        Case "Square meter"
                            outputValue = inputValue
                        Case "Square kilometer"
                            outputValue = inputValue / 1000000
                        Case "Square mile"
                            outputValue = inputValue / 2589988.11
                    End Select
                Case "Square kilometer"
                    Select Case outputUnit
                        Case "Square meter"
                            outputValue = inputValue * 1000000
                        Case "Square kilometer"
                            outputValue = inputValue
                        Case "Square mile"
                            outputValue = inputValue / 2.58998811
                    End Select
                Case "Square mile"
                    Select Case outputUnit
                        Case "Square meter"
                            outputValue = inputValue * 2589988.11
                        Case "Square kilometer"
                            outputValue = inputValue * 2.58998811
                        Case "Square mile"
                            outputValue = inputValue
                    End Select
            End Select
        End If

        TextBox2.Text = outputValue.ToString()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'Update TextBox2 every second
        TextBox1_TextChanged(sender, e)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox1_TextChanged(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox1_TextChanged(sender, e)
    End Sub

    Private Sub AboutCurrencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutCurrencyToolStripMenuItem.Click
        MsgBox("Exchange rates used in the application are based on the exchange rates" & vbNewLine & "as of September, 2021", MsgBoxStyle.OkOnly, "Exchange Rates")
    End Sub
End Class