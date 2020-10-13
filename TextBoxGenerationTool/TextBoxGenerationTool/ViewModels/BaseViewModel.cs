using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextBoxGenerationTool.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected void Set<U>(ref U backingStore, U value, [CallerMemberName] string propertyName = null, Action onChanged = null, Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value)) return;

            onChanging?.Invoke(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangingEventHandler PropertyChanging;
        public void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanging == null) return;

            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
