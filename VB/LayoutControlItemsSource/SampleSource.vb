Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel

Namespace LayoutControlItemsSource
    Public Class SampleSource
        Inherits BindableBase

        Private rnd As New Random()

        Private currentItem_Renamed As SampleItem

        Public Property Items() As ObservableCollection(Of SampleItem)

        Public Property CurrentItem() As SampleItem
            Get
                Return currentItem_Renamed
            End Get
            Set(ByVal value As SampleItem)
                currentItem_Renamed = value
                RaisePropertyChanged("CurrentItem")
            End Set
        End Property
        Public Sub New(ByVal count As Integer)
            Items = New ObservableCollection(Of SampleItem)()
            InitItems(count)
        End Sub
        Private Sub InitItems(ByVal count As Integer)
            Dim rnd As New Random()
            For i As Integer = 0 To count - 1
                Dim item As New SampleItem() With { _
                    .Name = "item" & i, _
                    .Value = rnd.Next(-50, 50) _
                }
                Items.Add(item)
            Next i
        End Sub
        Public Sub RemoveRandom()
            If Items.Count = 0 Then
                Return
            End If
            Items.RemoveAt(rnd.Next(0, Me.Items.Count))
        End Sub
        Public Sub RemoveAt(ByVal index As Integer)
            If Items.Count > index Then
                Items.RemoveAt(index)
            End If
        End Sub
        Public Sub Add()
            Dim i As Integer = (New Random(Date.Now.Millisecond)).Next(1, 100)
            Dim item As New SampleItem() With { _
                .Name = "item" & i, _
                .Value = i _
            }
            Items.Add(item)
        End Sub
    End Class

    Public Class SampleItem
        Inherits BindableBase


        Private name_Renamed As String
        Private amount As Integer

        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
                RaisePropertyChanged("Name")
            End Set
        End Property
        Public Property Value() As Integer
            Get
                Return amount
            End Get
            Set(ByVal value As Integer)
                amount = value
                RaisePropertyChanged("Value")
            End Set
        End Property
    End Class

    Public Class BindableBase
        Implements INotifyPropertyChanged

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Sub RaisePropertyChanged(ByVal fieldName As String)
            If PropertyChangedEvent Is Nothing Then
                Return
            End If
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(fieldName))
        End Sub
    End Class
End Namespace