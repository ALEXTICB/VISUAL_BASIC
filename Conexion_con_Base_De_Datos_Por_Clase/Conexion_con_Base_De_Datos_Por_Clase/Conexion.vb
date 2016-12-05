Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion

    Public conexion As SqlConnection = New SqlConnection("Data Source=ALEX\ALEX;Initial Catalog=Conexion_Visual;Integrated Security=True")

    Private cmd As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand


    Public Sub conectar()

        Try
            conexion.Open()
            MessageBox.Show("Conectado")

        Catch ex As Exception
            MessageBox.Show("Error De Conección")

        Finally
            conexion.Close()

        End Try
    End Sub

    Public Sub consulta(ByVal sql As String, ByVal Tabla As String)

        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion)
        cmd = New SqlCommandBuilder(da)
        da.Fill(ds, Tabla)

    End Sub

    Function Insertar(ByVal sql)
        conexion.Open()
        comando = New SqlCommand(sql, conexion)

        Dim i As Integer = comando.ExecuteNonQuery()

        If (1 > 0) Then
            Return True

        Else
            Return False
        End If




    End Function
    Function Eliminar(ByVal sql)
        conexion.Open()
        comando = New SqlCommand(sql, conexion)

        Dim i As Integer = comando.ExecuteNonQuery()
        conexion.Close()

        If (1 > 0) Then
            Return True

        Else
            Return False
        End If
    End Function
    'Function Eliminar(ByVal tabla, ByVal condicion)
    ' conexion.Open()

    ' Dim elimina As String = "delete from" + tabla + "where" + condicion
    '    comando = New SqlCommand(elimina, conexion)
    ' Dim i As Integer = comando.ExecuteNonQuery()
    '     conexion.Close()

    '  If (i > 0) Then
    '      Return True
    '  Else
    '      Return False
    '  End If


    ' End Function

    Function actualizar(ByVal tabla, ByVal campos, ByVal condicion)
        conexion.Open()

        Dim actualiza As String = "update" & tabla & "set" & campos & "where" & condicion
        comando = New SqlCommand(actualiza, conexion)

        Dim i As Integer = comando.ExecuteNonQuery()
        conexion.Close()

        If (i > 0) Then
            Return True
        Else
            Return False

        End If



    End Function
End Class
