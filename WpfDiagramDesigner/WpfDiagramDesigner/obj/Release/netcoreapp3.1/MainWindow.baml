   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  M IWpfDiagramDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfDiagramDesignerWpfDiagramDesigner #   WpfDiagramDesigner.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9system&clr-namespace:System;assembly=mscorlib     2local clr-namespace:WpfDiagramDesigner       � Title$  
MainWindow��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* �.+�+  %System.Windows.Controls.Ribbon.Ribbon  -     Name$ Ribbon��   Title$ Ribbon Title��$��	0,-22,0,0q�$��0��   HelpPaneContent 1  +System.Windows.Controls.Ribbon.RibbonButton  -     Name$
 Help��   QuickAccessToolBar =  7System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar  .@�  -   $ 
QATButton1��  -   $ 
QATButton2��   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  .@�>  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -     Name$ 	MenuItem1��$��Hello _Ribbon��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  -   	  Name$	 HomeTab��$
��Home��.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -   
  Name$
 Group1��$��Group1��.@�  -   $ Button1��   Label$
 Open��   SmallImageSource$i cG:\BME-VIK\7.felev\Onlab\WpfDiagramDesigner\WpfDiagramDesigner\Images\ic_folder_open_black_24dp.png��  -	   $	 	FormatTab��$��Format��$  WpfDiagramDesigner.DiagramView  -
     Name$ DiagramView��$	  WpfDiagramDesigner.DiagramView 	  DrawNode$ DiagramView_DrawNode��$��1��   NodeTemplate ��  �� DataType" ��.R�� .+��� $��50��$��50��
����ح��� $��Center=�$��Center=����� �� " ��.R�� .+��� 
�������� $	��Top=�$��Center=�����    EdgeTemplate %
  WpfDiagramDesigner.EdgeTemplate
   
  EdgeType" ��
 
  Pen >�  >� Brush
 �  �� >� 	Thickness$	 5.0Q�
  " �� >� 
 � � �$	 5.0Q�