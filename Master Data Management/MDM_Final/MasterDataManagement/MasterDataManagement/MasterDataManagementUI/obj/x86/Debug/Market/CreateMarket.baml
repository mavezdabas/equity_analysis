   M S B A M L   `   `   `  ����Q  MMasterDataManagementUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MasterDataManagement.UIEntitiesMasterDataManagement.UIEntities  5   	   H DMultiComboBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullF3clr-namespace:CustomControls;assembly=MultiComboBoxCustomControls 5   	   ?$clr-namespace:MasterDataManagementUIMasterDataManagementUI  5   	   0    *MasterDataManagementUI.Market.CreateMarket   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ?local-clr-namespace:MasterDataManagement.UIEntities     5   	   Csrc3clr-namespace:CustomControls;assembly=MultiComboBox     5   	   5vali$clr-namespace:MasterDataManagementUI     5   	     � Title$  Create Market��5   	   $	��400��6   $	��300��6,    � WindowStartupLocation$ CenterScreen=�68    � WindowStyle$ ThreeDBorderWindow=�6]    � 
ResizeMode$ NoResize=�6~    � 	Resources 5      .   (MasterDataManagement.UIEntities.MarketUI   c   
MarketName  CTextBlockTemplate �� 
TargetType � ColumnDefinitions �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value �� RelativeSource �� Path��%W  &	        &	      '�� Z      5	   
   $  ��6#   �� 5
   
   " ��65   .R�5      �  5      �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5      �� #��z��6   $��0��6=   $
��Left=�6M   $��Center=�6h   �� 5      $��*��6   $
��Left=�6%   
���  ��$��1��6Q   $��Center=�6a   $��64��6|   $��2��6�   5      5      �� 5   
   " ��6   .�5      �� 	 �@=�ErrorTemplate
 5      �� 5      .R�5      ]� .+�5      �� $��Right=�6(   
���  ��$��	ExtraBold"�5   9   $��20(�5   (   $��!��66   �� 5      
����  �$��2q�68   ._�5   "   �� 5      5      5       5"       5#      P� 5$       �@=�HasError . . �5%      �� 	 �@�ToolTip
 5&      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5(      5*      5,      .��5.      � -   5         �Name$ GridCreateMarket��5.        gridBackground#��[ 6%    � RowDefinitions 5/   
   �� 50      $	��.5* �6   �� 51      �� 52      �� 53      $��2* �6   �� 54      �� 55      �� 56      �� 57      $	��.3* �6   �� 58       5<   
   �� 5=      �� 5>      .+�5C   
   �� $��CREATE MARKET��6   $��Center=�6)   $��Center=�6F   $��2��6a   �� 5F      $��Market Name��6   $��1��6(   $
��Left=�65   $��Center=�6P   $��7q�6k   $��74��6v   #��[ 6�   �� 5G      $��Location��6   $��2��6$   $
��Left=�61   $��Center=�6L   $��7q�6g   #��[ 6r   �� 5H   
   $��Commodity Type��6   $��3��6)   $
��Left=�66   $��Center=�6Q   $��7q�6l   #��[ 6w   �� 5I   
   $��Currency��6   $��4��6#   $
��Left=�60   $��Center=�6K   $��7q�6f   #��[ 6q   �� 5J   
   $��
Start Date��6   $��5��6&   $
��Left=�63   $��Center=�6N   $��7q�6i   �� 5K   
   $��End Date��6   $��6��6$   $
��Left=�61   $��Center=�6L   $��7q�6g   �� 5M   
   -   5        $��txtMarketName��5M   :   $��1��6   $��1��6"   $��5q�6/   $��1��6O   .��6\   ��5N      �� 5O      $ 
MarketName�6    �� ValidationRules 5P      7   1MasterDataManagementUI.StringLengthValidationRule  5Q         MinimumLength$ 2��6:      MaximumLength$	 100��5R   ;      ErrorMessage$ Invalid Data��5S   ;   5U      .��5V      5W      �� 5Y   
   -   5        $��cmbLocation��5Y   ;   $��2��6   $��1��6    $��5q�60   $��2��6f   ��6N   �� 6u   �� 5^   
   $��3��6   $��0,1,0,0q�6    $��1��61   $��Select Commodities��6A   .��5_      � $��5q�6    5`      �� 5a      $	��44* �6'   �� 5b      $	��73* �6'    5d      �� 5e      $
��Auto �6$   �� 5f      $
��Auto �6$   �� 5g      $
��Auto �6$   �� 5h      $
��Auto �6$   �� 5i      $
��Auto �6$   �� 5j      $	��13* �6$   .+�5r      "  CustomControls.MultiComboBox  -   5        $��cmbCommodityType��5r   D   $��	0,10,-3,0q�6$   $��4��67    �� SelectionMode$ Multiple=�6\   $��Center=�5s   "      IsCreateNewEnabled .    DisplaySeparator$ , ��5u   "   $��2��5w   W   $��3��6k   ��5v   "   �� *CommodityTypeNames+$  CustomControls.BindableListBox   SelectedItems 5w   "   �� *SelectedCommodityTypeNames+5y      5z      5{      �� 5~   
   -   5        $��cmbCurrency��5~   ;   $��4��6   $��1��6    $��5q�60   $��4��6f   ��6N   �� 6u   �� 5   
   -   5         ��Name$
 Save��5   T   $
��SAVE��6   $��8��6    $��0��6-   $��5q�6=   $	��100��6H   $��7��6u    �� 	IsDefault . 6�   �� 5�   
   -   5        $ Cancel��5�   V   $��CANCEL��6   $��8��6"   $��1��6/   $��5q�6?   $	��100��6J   $��8��6{    �� IsCancel . 6�   �� 5�   
   $��*Mandatory Fields��6   $��7��6.   $��0��6;   $��8(�6K   
���  ��6k   (  "System.Windows.Controls.DatePicker  5�   
   -   5        $��dpStartDate��5�   e   $��1��6   $��5��6%   $��25��62   $
��Left=�6>   $��5q�6Y   $	��Top=�6x   $	��129��6�   $��5��6�   {�.  6�     5�   
   -	   5        $��	dpEndDate��5�   M   $��25��6   $
��Left=�6!   $��5,5,0,0q�6<   $	��Top=�6^   $	��129��6v   $��1��6�   $��6��6�   $��6��6�      SelectedDate 6�   �� *	EndDate+6�   5�      5�      