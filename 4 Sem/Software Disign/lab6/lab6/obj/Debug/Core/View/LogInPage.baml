   M S B A M L   `   `   `  ����?  ;lab6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:lab6.Core.Viewlab6.Core.View  5   	       lab6.Core.View.LogInPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:lab6.Core.View     5   	     N� Title$  Cinema System��5   	   $	��600��6   $��1000         ��6,    N� 
Background �#c0ebe2 N� 
FontFamily$ Bebas Neue Pro)�5
   	    � 	Resources 5         WaterMarkStyleTextBox �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 ��Name

 � Tag �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	        �� 5   
   " ��6.   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�6P   �� 5      $ PART_ContentHost��6+   $��5,0,0,0q�6E   $��Center=�6V   �� 5      $	 WaterMarkLabel��65   $��5,0,0,0q�6$   #��z
 6M   $��Center=�6m   $y�	Collapsed=�5   $   
�������$��Arial)�6M   5       5      ]� 5       5   "   �� 5   &    � ��$  ��6@   ./�5   "   �� $ WaterMarkLabel��6?    � y�$ Visible=�6[   5      P� 5       � {� .  . �5   "   ��  � ��
 �iii�6?   5      5!      5#      5$      5%      .��5'      � .+�5(   
   �� 
���   �
�������$��1q�6=   $��393,133,359,206q�6R    J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$ 20Q�6#      ShadowDepth$ 0Q�63   5,      �� 5-   
   -   5         ��Name$ LoginTextBox��5-      $
 login��6(   $
��Left=�64   $��18(�6O   $��25��6]    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��174��6�   $��428,202,0,0q�6�   �� 5.   
   -   5         ��Name$ LogInButton��5.   >   ���#4c4a4b
�������$��
Войти��6S   $
��Left=�6c   $��18(�6~   $��429,301,0,0q�6�   $	��Top=�6�   $	��174��6�    J� RenderTransformOrigin$ 0.128,2.906&�6�   $��27��6�   z�5/      V� 50      .~�51      �� �� 52      �� 53       �� Angle$ -0.181Q�6&   T� 54      55      57      G� 58   
   -   5         G�Name$ PasswordTextBox��58       G� PasswordChar$ *��60   $��18(�6A   $
��Left=�6O   $��26��6j   $��428,248,0,0q�6v   $	��Top=�6�   $	��174��6�   �� 59   
   $��ВХОД��6   $
��Left=�6   $��25(�6:   $��492,140,0,0q�6H   $	��Top=�6]   $ 5.857,-1.887&�6u   $��43��6�   �� 5:   
   -   5        $ RegisterButton��5:   >   ���#4c4a4b
�������$��Регистрация��6V   $
��Left=�6l   $��18(�6�   $	��Top=�6�   $	��175��6�   $ 0.128,2.906&�6�   $��28��6�   $��429,340,0,0q�6�   z�5;      V� 5<      .~�5=      �� �� 5>      �� 5?      $ -0.181Q�6&   T� 5@      5A      5C      �� 5D   
   $��
Логин��6   $
��Left=�6    $��0,5,0,0q�6;   $��428,183,0,0q�6M   $	��Top=�6b   $��23��6z   $	��174��6�   �� 5E   
   $��Пароль��6   $
��Left=�6!   $��0,6,0,0q�6<   $��428,227,0,0q�6N   $	��Top=�6c   $��23��6{   $	��174��6�   5G      5H      