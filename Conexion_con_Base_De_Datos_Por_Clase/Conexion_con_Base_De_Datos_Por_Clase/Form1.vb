Public Class Form1

    Dim conexion As Conexion = New Conexion()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.conectar()
        mostrar_datos()





    End Sub
    Public Sub mostrar_datos()
        conexion.consulta("select *from Alumno", "Alumno")
        DataGridView1.DataSource = conexion.ds.Tables("Alumno")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim agregar As String = "insert into Alumno values ('" + ID.Text + "', '" + Nombre.Text + "' , '" + Apellidos.Text + "')"

        If (conexion.Insertar(agregar)) Then

            MessageBox.Show("Datos Ingresados")
            mostrar_datos()

        Else
            MessageBox.Show("Error Al Agregar")

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' If (conexion.Eliminar("Alumno", "id =" + ID.Text)) Then
        'MessageBox.Show("Datos Eliminados correctamente")
        ' mostrar_datos()
        ' Else
        ' MessageBox.Show("Error Al Eliminar")
        ' End If
        Dim delete As String = "delete from Alumno where id= '" + ID.Text + ""

        If (conexion.Eliminar(delete)) Then

            MessageBox.Show("Datos Eliminados")
            mostrar_datos()

        Else
            MessageBox.Show("Error Al eliminar")

        End If



    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        ID.Text = dgv.Cells(0).Value.ToString()
        Nombre.Text = dgv.Cells(1).Value.ToString()
        Apellidos.Text = dgv.Cells(2).Value.ToString()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim actualizar As String = "id ='" & ID.Text & "',Nombre=" & Nombre.Text & "',Apellido'" & Apellidos.Text & "'"

        If (conexion.actualizar("Alumno", actualizar, "id " + ID.Text)) Then

            MessageBox.Show("Datos Actualizados")
        Else
            MessageBox.Show("Error Al Actualizar")

        End If
    End Sub
End Class
