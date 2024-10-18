using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace LandetxearenErreserba
{
    public partial class MainPage : ContentPage
    {
        public List<string> Images { get; set; }
        public ObservableCollection<DateEvent> Events { get; set; }
        public DateTime SelectedDate { get; set; } // Nueva propiedad para SelectedDate

        public MainPage()
        {
            InitializeComponent();
            Events = new ObservableCollection<DateEvent>();

            // Vincular la colección al CollectionView
            eventsCollectionView.ItemsSource = Events;

            // Establecer MinimumDate al día de hoy
            datePicker.MinimumDate = DateTime.Today;

            // Establecer la fecha inicial como hoy
            SelectedDate = DateTime.Today; // Inicializar la propiedad
            datePicker.Date = SelectedDate; // Sincronizar con DatePicker

            Images = new List<string>
            {
                "bat.jpg",
                "bi.jpg",
                "hiru.jpg",
                "lau.jpg",
            };

            BindingContext = this;
        }

        // Este es el método para manejar el evento DateChanged
        private void OnDateChanged(object sender, DateChangedEventArgs e)
        {
            // Actualizar la propiedad SelectedDate
            SelectedDate = e.NewDate;

            // Limpiar la colección antes de agregar nuevas fechas
            Events.Clear();

            // Agregar las fechas desde SelectedDate hasta 7 días después
            for (int i = 0; i <= 7; i++)
            {
                DateTime dateToAdd = SelectedDate.AddDays(i);
                Events.Add(new DateEvent { Name = dateToAdd.ToString("dd/MM/yyyy") });
            }
        }

        private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            decimal total = 0;

            // Sumar precios según las opciones seleccionadas
            if (checkBox1.IsChecked)
                total += 25;

            if (checkBox2.IsChecked)
                total += 150;

            if (checkBox3.IsChecked)
                total += 40;

            // Actualizar el valor del segundo Entry
            entry2.Text = total.ToString();
            decimal estanciaPrecio = 300; // Precio fijo
            decimal gehigarriakPrecio = total; // Precio de los extras

            // Calcular el total y actualizar el tercer Entry
            decimal totalGuztira = estanciaPrecio + gehigarriakPrecio;
            totalEntry.Text = totalGuztira.ToString();
        }
    }

    public class DateEvent
    {
        public string Name { get; set; }
    }
}
