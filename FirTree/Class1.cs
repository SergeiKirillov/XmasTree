using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirTree
{
    public class Zadachi : INotifyPropertyChanged
    {
        private string dtZadachi;
        private string strZadachi;
        private bool blStat;
        private int intCategoria;
        private int intRepeat; 

        public int Id { get; set; }

        public string dtTask
        {
            get { return dtZadachi; }
            set {
                dtZadachi = value;
                OnPropertyChanged("dtTask");
            }
        }

        public string strTask
        {
            get { return strZadachi; }
            set
            {
                strZadachi = value;
                OnPropertyChanged("strTask");
            }
        }

        public bool blStatus
        {
            get { return blStat; }
            set
            {
                blStat = value;
                OnPropertyChanged("blStatus");
            }
        }

        public int Categoria
        {
            get { return intCategoria; }
            set
            {
                intCategoria = value;
                OnPropertyChanged("Categoria");
            }
        }

        public int Repeat
        {
            get { return intRepeat; }
            set
            {
                intRepeat = value;
                OnPropertyChanged("Repeat");
            }
        }


        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
