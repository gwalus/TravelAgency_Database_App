using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        private ICollection tableName;
        public ICollection TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                if (tableName == value)
                {
                    return;
                }
                tableName = value;
                OnPropertyChanged(nameof(TableName));
            }
        }
        
        private ICollection tableContent;       
        public ICollection TableContent
        {
            get
            {
                return tableContent;
            }
            set
            {
                if (tableContent == value)
                {
                    return;
                }
                tableContent = value;
                OnPropertyChanged(nameof(TableContent));
            }
        }

        private string buttonContent;
        public string ButtonContent
        {
            get
            {
                return buttonContent;
            }
            set
            {
                if (buttonContent == value)
                {
                    return;
                }
                buttonContent = value;
                OnPropertyChanged(nameof(ButtonContent));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string memberName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
