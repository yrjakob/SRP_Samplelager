   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       SRP_SampleLager   SRP_SampleLager.LogView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  LogView��5      .   (System.Windows.Interactivity.Interaction   Triggers 5	      /   )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��4��6      BorderStyle#���   6%   ._�5   
   �� $��4��6   $	��Log��6(     Headline#���  63   5      �� 5    
   $��1��6   $��	Username:��6!     TextBlockStyle#���  62   �� 5!   
   $��1��6   $��1��6      InputElement#���  6S    �� SelectedValue 60   �� *
Username+��5"      �� *UsernameList+ 5#        5$      $ SelectionChanged��6!   . 5%         6,   �� *SelectUserCommand+5&      5(      �� 5*   
   $��1��6   $��2��6!   $��Aktion:��61   #���  6@   �� 5+   
   $��1��6   $��3��6    #���  6Q    60   �� *Action+��5,      �� *
ActionList+ 5-        5.      $ SelectionChanged��6!   . 5/         6,   �� *SelectActionCommand+50      52      �� 54   
   $��2��6   $��Zeitraum von:��6!   #���  66   (  "System.Windows.Controls.DatePicker  55   
   $��2��6   $��1��6"   #���  6O      SelectedDate 62   �� *Von+ 56        57      $ SelectedDateChanged��6!   . 58         6,   �� *SelectVonCommand+59      5;      �� 5=   
   $��2��6   $��2��6!   $
��bis:��61   #���  6=     5>   
   $��2��6   $��3��6"   #���  6O    62   �� *Bis+ 5?        5@      $ SelectedDateChanged��6!   . 5A         6,   �� *SelectBisCommand+5B      5D      �� 5F   
   -   5        $��lvLog��5F   \   $��3��6   $��4��6      ListViewStyle#���  64   ��5G      �� *	LogList+	 �� View	 5H      �� 5I      .P�5J      �� $��Username��6%   
 �� DisplayMemberBinding
 67   �� *
Username+�� 5K      $��Aktion��6%   
 65   �� *Action+�� 5L      $��Datum��6%   
 64   �� *Datum+ �� StringFormat$ 
dd.MM.yyyy��5M      5O      5P      5Q      