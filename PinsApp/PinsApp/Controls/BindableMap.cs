using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Clustering;
namespace PinsApp.Controls
{
    public class BindableMap : ClusteredMap
    {
        public BindableMap()
        {
            PinsSource = new ObservableCollection<Pin>();
            PinsSource.CollectionChanged += PinsSourceOnCollectionChanged;
            UiSettings.MyLocationButtonEnabled = true;
        }   

        #region -- Public Properties --
        public ObservableCollection<Pin> PinsSource
        {
            get { return (ObservableCollection<Pin>)GetValue(PinsSourceProperty); }
            set { SetValue(PinsSourceProperty, value); }
        }
        
        public static readonly BindableProperty PinsSourceProperty = BindableProperty.Create(
            propertyName: "PinsSource",
            returnType: typeof(ObservableCollection<Pin>),
            declaringType: typeof(BindableMap),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            validateValue: null,
            propertyChanged: PinsSourcePropertyChanged);

        public ICommand command
        {
            get { return (ICommand)GetValue(commandProperty); }
            set { SetValue(commandProperty, value); }
        }

        public static readonly BindableProperty commandProperty = BindableProperty.Create(
            propertyName: "command",
            returnType: typeof(ICommand),
            declaringType: typeof(BindableMap),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            validateValue: null,
            propertyChanged: commandPropertyChanged);
        #endregion

        #region -- Private Helpers --
        private static void PinsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var thisInstance = bindable as BindableMap;
            var newPinsSource = newValue as ObservableCollection<Pin>;

            if (thisInstance == null || newPinsSource == null)
            {
                return;
            }

            UpdatePinsSource(thisInstance, newPinsSource);
        }

        private void PinsSourceOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdatePinsSource(this, sender as IEnumerable<Pin>);
                
        }

        private static void UpdatePinsSource(ClusteredMap bindableMap, IEnumerable<Pin> newSource)
        {
            bindableMap.Pins.Clear();
            foreach (var pin in newSource)
            {
                bindableMap.Pins.Add(pin);
            }
        }

        private static void commandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var thisInstance = bindable as BindableMap;
            var newCommandSource = newValue as ICommand;

            if (thisInstance == null || newCommandSource == null)
            {
                return;
            }

            UpdateCommandSource(thisInstance, newCommandSource);
        }

        private static void UpdateCommandSource(ClusteredMap bindableMap, ICommand newSource)
        {

        }
        #endregion
    }
}
