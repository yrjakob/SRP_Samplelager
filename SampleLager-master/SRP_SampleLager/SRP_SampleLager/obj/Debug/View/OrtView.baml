   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    SRP_SampleLager   SRP_SampleLager.OrtView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  Sample Lager��5   	   $	��135��6   $	��300��6+   .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6      Headline#���   6B   ��6(   �� *
Headline+6B   �� 5   
   $��1��6   $
��Ort:��6!     TextBlockStyle#���  6-   �� 5   
   $��1��6   $��1��6     InputElement#���  6i   ��6/   �� *Ort+ �� UpdateSourceTrigger$ PropertyChanged=�6i   �� 5   
   $��2��6   $��2��6"     StackPanelStyle#���  66   .+�5      �� $��	Abbrechen��6     ButtonStyle#��[ 6)   ��6N   �� *AbortCommand+�� 5      $��	Speichern��6   #��[ 6)   ��6N   �� *SaveCommand+5      5      5       