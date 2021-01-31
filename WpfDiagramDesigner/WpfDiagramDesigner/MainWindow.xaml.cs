using MetaDslx.GraphViz;
using MetaDslx.Languages.Uml.Model;
using MetaDslx.Languages.Uml.Serialization;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Windows;

using System.Windows.Media;
using WpfDiagramDesigner.Model;

namespace WpfDiagramDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogicalViewModelLoader classLoader = new LogicalViewModelLoader();
        private UseCaseModelLoader useCaseLoader = new UseCaseModelLoader();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DiagramView_DrawNode(object sender, DrawNodeEventArgs args)
        {
            var dc = args.DrawingContext;
            var node = args.NodeLayout;
            var myPen = new Pen
            {
                Thickness = 0.05,
                Brush = Brushes.Black
            };
            myPen.Freeze();
            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new Point(node.Position.X - node.Size.X / 2, node.Position.Y - node.Size.Y / 2), new Size(node.Size.X, node.Size.Y));
            dc.DrawRectangle(Brushes.LightGray, node.IsSubGraph ? myPen : null, rect);
        }

        private void Open_UML_file(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".uml";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                Button1.Label = "Opened";
                classLoader.LoadLayout(dlg.FileName);
                useCaseLoader.LoadLayout(dlg.FileName);
                DiagramView.GraphLayout = classLoader.Layout;
            }
        }

        private void LoadClass_Click(object sender, RoutedEventArgs e)
        {
            if(Button1.Label != "Opened") { }
            else
            {
                DiagramView.GraphLayout = classLoader.Layout;
            }
        }

        private void LoadUseCase_Click(object sender, RoutedEventArgs e)
        {
            if (Button1.Label != "Opened") { }
            else
            {
                
                DiagramView.GraphLayout = useCaseLoader.Layout;

            }

        }
    }
}
