   M S B A M L   `   `   `  ����  SRP_SampleLager    SRP_SampleLager.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Icon$6  0/SRP_SampleLager;component/General/Warehouse.ico��5   	    � Title$ Sample Lager��5   	   $	��250��6   $	��300��6+    � 
ResizeMode$ CanMinimize=�67    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6    $��2��6-   $��Center=�6A   $6��0/SRP_SampleLager;component/General/Warehouse.ico��6^   $��10q�6�   $	��100��6�   �� 5   
   $��2��6   $��0��6!   $��	Username:��61      TextBlockStyle#���   6B   �� 5   
   $��2��6   $��1��6     InputElement#���  6I   ��6/   �� *
Username+6I   �� 5   
   $��3��6   $��	Password:��6!   #���   62   G� 5   
   -   5        $��
pbPassword��5   Z   $��3��6   $��1��6#   #���  63    J� InputBindings 5      �� 5      
 �� Key$ Enter��6    �� Command 6)   �� *LoginCommand+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� CommandParameter
 5      ��  �� ElementName$ 
pbPassword��5      �� 5!   
   $��4��6   $��2��6"     StackPanelStyle#���  66   .+�5"      �� $��Cancel��6     ButtonStyle#��[ 6&   ��6K   �� *CancelCommand+�� 5#      $��Login��6   #��[ 6%   ��6J   �� *LoginCommand+��5$      �� $ 
pbPassword��5%      5&      5'      