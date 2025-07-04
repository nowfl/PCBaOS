Public Class FoodExpert

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "Pancakes" Then
            Label3.Text = "100g plain flour" & vbNewLine & vbNewLine & "2 large eggs" & vbNewLine & vbNewLine & "300ml milk" & vbNewLine & vbNewLine & "1tbsp sunflower or vegetable oil, plus a little extra for frying" & vbNewLine & vbNewLine & "lemon wedges to serve (optional)" & vbNewLine & vbNewLine & "caster sugar to serve (optional)"
            Label4.Text = "STEP 1 Put 100g plain flour, 2 large eggs, 300ml milk, 1 tbsp sunflower or vegetable oil and a pinch of salt into a bowl or large jug, then whisk to a smooth batter." & vbNewLine & "STEP 2 Set aside for 30 mins to rest if you have time, or start cooking straight away." & vbNewLine & "STEP 3 Set a medium frying pan or crêpe pan over a medium heat and carefully wipe it with some oiled kitchen paper." & vbNewLine & "STEP 4 When hot, cook your pancakes for 1 min on each side until golden, keeping them warm in a low oven as you go." & vbNewLine & "STEP 5 Serve with lemon wedges and caster sugar, or your favourite filling. Once cold, you can layer the pancakes between baking parchment" & vbNewLine & "then wrap in cling film and freeze for up to 2 months."
        End If
        If ListBox1.SelectedItem = "Mac and Cheese" Then

        End If
        If ListBox1.SelectedItem = "Pizza" Then
            Label3.Text = "10g fresh yeast or 7g sachet dried" & vbNewLine & vbNewLine & "½ tsp sugar" & vbNewLine & vbNewLine & "375g Italian '00' flour , plus extra for dusting" & vbNewLine & vbNewLine & "1 tbsp olive oil , plus extra for greasing" & vbNewLine & vbNewLine & "3 x 125g balls mozzarella , torn" & vbNewLine & vbNewLine & "fresh basil , to serve" & vbNewLine & vbNewLine & "For the tomato sauce:" & vbNewLine & vbNewLine & "3 tbsp olive oil" & vbNewLine & vbNewLine & "1 onion , chopped" & vbNewLine & vbNewLine & "1 garlic clove , crushed" & vbNewLine & vbNewLine & "2 x 400g cans good-quality Italian chopped tomatoes"
            Label4.Text = "STEP 1 Mix together the yeast and sugar with 250ml warm water and leave to sit for 10 mins. Place half the flour in a table-top mixer with a dough hook," & vbNewLine & "pour in the yeast mixture and beat at medium speed for 10 mins (or mix in a bowl, then knead with oiled hands in the bowl for 5-10 mins)." & vbNewLine & "STEP 2 Leave somewhere warm for 10 more mins, then add the remaining flour and oil." & vbNewLine & "Beat or knead to a dough for a further 5 mins. Put in a well-oiled bowl, cover with a cloth and place somewhere warm to double in size – about 1½ hrs."
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        

    End Sub

    Private Sub CloseToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Exit the application"
    End Sub

    Private Sub CloseToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub
End Class