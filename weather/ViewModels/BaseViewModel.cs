using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace weather
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private bool isBusy;
		public const string IsBusyPropertyName = "IsBusy";
		public bool IsBusy 
		{
			get { return isBusy; }
			set { SetProperty (ref isBusy, value, IsBusyPropertyName);}
		}

		protected void SetProperty<T>(
			ref T backingStore, T value,
			string propertyName,
			Action onChanged = null) 
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value)) 
				return;

			backingStore = value;

			if (onChanged != null) 
				onChanged();

			Notify(propertyName);
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		protected void Notify(string propertyName) 
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));

		}

	}
}

