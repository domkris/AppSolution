   M S B A M L   `   `   `  ����B  >MainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MainApp.UserControlsMainApp.UserControls  5      4    .MainApp.UserControls.GenerateModelsUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MainApp.UserControls     5      
�������.��5	      �   � ColumnDefinitions  5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��5         generateModelsTitle#��[  5       $��Generate models��5!      �� 5"   
   $��0��6   $��0��5#      $��2��5$        generateModelsTitleStroke#��[ 5%      
���   �5&      �� 5'   
   $��0��6   $��1��5(      $	��Top=�5)      $��Select Server��5*      �� 5+   
   -   5         ��Name$ cbxServerList��5-      $��1��5+      $��1��5,      $	��Top=�5.      5/      �� 50   
   $��0��6   $��2��51      $	��Top=�52      $��Select Database��53      �� 54   
   -   5        $ cbxDatabaseList��56      $��1��54      $��2��55      $	��Top=�57      58      �� 59   
   $��2��6   $��2��5:      $��Bottom=�5;      $)��#Select objects for model generation��5<      $��0q�5=      &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dgTables��5A      $��1��5>      $��3��5?      $��3��5@      $��0q�5B         AutoGenerateColumns .    CanUserAddRows .  5M      �� 5N   
   $��1��6   $��6��5O      $��Bottom=�5P      $��View generation��5Q      $��0q�5R        5S   
   -   5        $ dgViews��5W      $��2��5S      $��7��5T      $��3��5U      $��0q�5V       .  .  5`      �� 5b   
   $��0��6   $��10��5c      $��Center=�5d      $!��Define namespace for models��5e      �� 5f   
   -   5         ��Name$ txtBoxModelNamespace��5f      $��1��5g      $��10��5h      $��Center=�5i      $��50,10,80,10q�5j      �� 5k   
   $��Select save folder��6   $��0��5l      $��11��5m      �� 5n   
   -   5        $ txtBoxSaveFolder��5n      $��1��5o      $��11��5p      $��Center=�5q      $��50,10,200,10q�5r      �� 5s   
   -   5         ��Name$ 
bttnBrowse��5s      $��1��5t      $��11��5u      $��Center=�5v      $��Right=�5w      $��80��5x      $��20��5y      $��10,10,100,10q�5z      .��5{      �� $��Browse��6   5|      �� 5}   
   -   5        $ bttnGenerate��5}      $��1��5~      $��12��5      $��80��5�      $��20��5�      $��Right=�5�      $��10,10,100,10q�5�      .��5�      �� $��Generate��6   5�      5�      5�      