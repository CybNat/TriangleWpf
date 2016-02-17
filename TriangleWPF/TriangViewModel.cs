using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using TriangleWPF.Annotations;

namespace TriangleWPF
{
    public class TriangViewModel : INotifyPropertyChanged
    {
        private TriangModel trMode = new TriangModel();
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public double A
        {
            get { return trMode.A; }
            set
            {
                if (value.Equals(trMode.A)) return;
                trMode.A = value;
                OnPropertyChanged("A");
                OnPropertyChanged("Sq");
            }
        }

        public double B
        {
            get { return trMode.B; }
            set
            {
                if (value.Equals(trMode.B)) return;
                trMode.B = value;
                OnPropertyChanged("B");
                OnPropertyChanged("Sq");

            }
        }

        public double C
        {
            get { return trMode.C; }
            set
            {
                if (value.Equals(trMode.C)) return;
                trMode.C = value;
                OnPropertyChanged("C");
                OnPropertyChanged("Sq");

            }
        }


        public string Sq
        {
            get
            {
                try
                {
                    return String.Format("Площадь прямоугольного треугольника равна {0}",trMode.GetSquare().ToString());
                    //return trMode.GetSquare().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
        }
    }

    public class TriangModel
    {
        public double A;
        public double B;
        public double C;

        public double GetSquare()
        {
            double gipot = C;
            double kat1 = A;
            double kat2 = B;
            if (A > B && A > C)
            {
                gipot = A;
                kat1 = B;
                kat2 = C;
            }
            else
            {
                if (B > A && B > C)
                {
                    gipot = B;
                    kat1 = A;
                    kat2 = C;
                }
            }

            var trueSqvGip = gipot * gipot;
            var sqvGip = kat1 * kat1 + kat2 * kat2;
            if (Math.Abs(trueSqvGip - sqvGip) > Double.Epsilon)
            {
                throw new ArgumentException("Прямоугольного треугольника с данными сторонами не существует");
            }

            double s = kat1 * kat2 * 0.5;
            return s;
        }
    }
}
