   M S B A M L   `   `   `  ����J  FICS-Project.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ICS_Project.App.ViewsICS_Project.App.Views  5      G(clr-namespace:ICS_Project.App.ViewModelsICS_Project.App.ViewModels  5      (    "ICS_Project.App.Views.TeamEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ICS_Project.App.Views     5      ?
viewModels(clr-namespace:ICS_Project.App.ViewModels     5        � DataContext  5	      �� *TeamEditViewModel+   ViewModelLocator �� Source# [  .��5      � 
�������.+�5   
   �� .+�5      �� $��18(�6   $��Arial)�6"   $��	80,25,0,0q�65   .��6H   Team edition6V   �� 5      $��	80,0,0,25q�6   	 �� X1$ 0��6&   	 �� X2$	 800��6-   	 �� Y1$ 0��66   	 �� Y2$ 0��6=   
���   �$��2��6S   $��23��6g   6u   �� 5      $��
100,0,0,10q�6    �� Orientation$ 
Horizontal=�6-   .+�5      �� $��
10,0,104,0q�6   .��6,   Team title:69   �� 5      $	��130��6   ��6&   �� *
Team.Title+6D   5      �� 5      $��
100,0,0,10q�6   $ 
Horizontal=�6-   .+�5      �� $��	10,0,30,0q�6   .��6+   Description of the team:6E   �� 5      $	��130��6   ��6&   �� *Team.Description+6J   5      �� 5      $��
100,0,0,10q�6   $ 
Horizontal=�6-   .+�5      �� $��	10,0,78,0q�6   .��6+   Team category:6;   �� 5      $	��130��6   ��6&   �� *Team.Category+6G   5      �� 5       $��100,20,0,10q�6   $ 
Horizontal=�6.   .+�5!      �� $��	195,0,0,0q�69   $��97��6L   ��6   �� *SaveCommand+.��6X   Save6^   5"      5%      5&      5'      