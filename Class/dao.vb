Imports System.Data.SqlClient

Public Class dao
    Public SQLCNN As New SqlConnection
    Public SQLCNNFIXA As New SqlConnection
    Public SQLCNN2 As New SqlConnection
    Public SQLCNNROBO As New SqlConnection
    Public Sub conectar()

        'Conexão com o banco de dados da AlmaViva
        'SQLCNN.ConnectionString = "Data Source=172.16.252.181;Initial Catalog=DB_UNC_ALMAVIVA_TIM;User Id=focare;Password=focare$2022;MultipleActiveResultSets=True;Connection Timeout=10"

        'SQLCNN.ConnectionString = "Data Source=10.189.6.105;Initial Catalog=DB_UNC_FDO_MOVEL_OUT;User Id=focare;Password=focare$;MultipleActiveResultSets=True"
        SQLCNN.ConnectionString = "Data Source=LUCASCONRADO\SQLEXPRESS;Initial Catalog=DB_MAISCAPITAL;Integrated Security=True;MultipleActiveResultSets=True"

        Try
            If SQLCNN.State = ConnectionState.Closed Then

                'Conexão com o banco de dados da AlmaViva
                'SQLCNN.ConnectionString = "Data Source=172.16.252.181;Initial Catalog=DB_UNC_ALMAVIVA_TIM;User Id=focare;Password=focare$2022;MultipleActiveResultSets=True;Connection Timeout=10"

                SQLCNN.ConnectionString = "Data Source=LUCASCONRADO\SQLEXPRESS;Initial Catalog=DB_MAISCAPITAL;Integrated Security=True;MultipleActiveResultSets=True"

                'Conexão com o banco de dados local EDUARDO:
                'SQLCNN.ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Copia_TIM;Integrated Security=True;MultipleActiveResultSets=True"

                SQLCNN.Open()
            End If
        Catch
            'Mostra formulário de erro de conexão com o banco
            'cnconexaobanco.ShowDialog()
            Try
                SQLCNN.Open()
            Catch ex As Exception

            End Try
        Finally
        End Try
    End Sub

    Public Sub TesteConectar()

        'Conexão com o banco de dados da ALMAVIVA
        'SQLCNN.ConnectionString = "Data Source=172.16.252.181;Initial Catalog=DB_UNC_ALMAVIVA_TIM;User Id=focare;Password=focare$2022;MultipleActiveResultSets=True;Connection Timeout=10"

        'Conexão com o banco de dados local EDUARDO:
        'SQLCNN.ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Copia_TIM;Integrated Security=True;MultipleActiveResultSets=True"

        SQLCNN.ConnectionString = "Data Source=LUCASCONRADO\SQLEXPRESS;Initial Catalog=DB_MAISCAPITAL;Integrated Security=True;MultipleActiveResultSets=True"
        Try
            If SQLCNN.State = ConnectionState.Closed Then
                SQLCNN.Open()
            End If
        Catch
            Throw
        Finally
        End Try
    End Sub

    Public Sub desconectar()
        If SQLCNN.State <> ConnectionState.Closed Then
            SQLCNN.Close()
        End If
    End Sub
End Class
