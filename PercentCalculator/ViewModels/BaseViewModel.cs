using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PercentCalculator.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler IsBusyChanged;

        protected virtual void OnIsBusyChanged()
        {
            IsBusyChanged?.Invoke(this, EventArgs.Empty);
        }

        readonly object _lockerIsLoading = new object();
        bool _isLoading = false;
        public bool IsLoading
        {
            get
            {
                lock (_lockerIsLoading)
                    return _isLoading;
            }
            set
            {
                lock (_lockerIsLoading)
                    if (_isLoading != value)
                    {
                        _isLoading = value;
                        OnPropertyChanged();
                    }
            }
        }

        readonly object _lockerIsBusy = new object();
        bool _isBusy = false;
        public bool IsBusy
        {
            get
            {
                lock (_lockerIsBusy)
                    return _isBusy;
            }
            set
            {
                lock (_lockerIsBusy)
                    if (_isBusy != value)
                    {
                        _isBusy = value;
                        OnPropertyChanged();
                        OnIsBusyChanged();
                    }
            }

        }

        public bool IsNotBusy => !_isBusy;

        public virtual void Initialize(object navigationData = null)
        {
        }

        public virtual Task InitializeAsync(object navigationData = null)
        {
            return Task.FromResult(false);
        }

        public Action CloseCallback;

        private static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("The expression is not a member access expression.", "propertyExpression");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("The member access expression does not access a property.", "propertyExpression");
            }

            var getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("The referenced property is a static property.", "propertyExpression");
            }

            return memberExpression.Member.Name;
        }
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }
        protected void SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyname = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyname);
        }
    }
}
