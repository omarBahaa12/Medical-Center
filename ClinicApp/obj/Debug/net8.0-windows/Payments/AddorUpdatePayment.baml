   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:UI.PaymentsUI.Payments  5   	   /clr-namespace:UI.AppointmentUI.Appointment  5   	   1clr-namespace:UI.PersonFolderUI.PersonFolder  6:   $    UI.Payments.AddorUpdatePayment   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:UI.Payments     5   	   4Appointmentclr-namespace:UI.Appointment     5   	   6PersonFolderclr-namespace:UI.PersonFolder     6:     � Title$  AddorUpdatePayment��5	   	   $	��800��5
   	   $	��970��5   	    � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       �� 5   
   " ��6   .�5      ��  � ��$ 
400,30,2,3q�6'   �� 5       � ��
 �����6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ Georgia)�6+   �� 5       � ��
 �   �6+   �� 5       � ��$ 60��6'   �� 5       � ��$	 180��6&   �� 5       � ��$ 3q�60   �� 5       � ��
 �����6,   5      5      .��5      � .+�5   
   �  � Orientation$ 
Horizontal=�6   .+�5      $   UI.PersonFolder.ucPersonSearch  -   5          Name$ ucPersonSearch1��5   *   $	��661��6C   .   (UI.Appointment.ucUpdateAppointmentStatus  5      -   5          Name$  ucUpdateAppointmentStatus1��5   4   $
��Left=�5   4   $��	10,8,10,0q�5   4   $	��568��5    4   $	��424��5!   4      UI.Payments.ucAddPayment  5"      -   5        	  Name$	 ucAddPayment1��5"   !   $	��507��5#   !   $	��417��5$   !   �� 5&      -   5        
 ��Name$
 Btn_Save��5(      $��
380,20,0,5q�5&      $
��Save��5'      5)      �� 5*      -   5        $
 
Btn_Cancel��5,      $��
100,20,0,5q�5*      $��Cancel��5+      5-      5/      50      51      