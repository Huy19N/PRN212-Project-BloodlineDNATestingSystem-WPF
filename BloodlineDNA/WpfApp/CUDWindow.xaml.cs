﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CUDWindow.xaml
    /// </summary>
    public partial class CUDWindow : Window
    {
        public CUDWindow(UserControl content)
        {
            InitializeComponent();
            MainContent.Content = content;
        }
    }
}
