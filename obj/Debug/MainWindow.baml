   M S B A M L   `   `   `  ????\  XEpic Tetris (Super Mario Maker 2), Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Epic_Tetris_Super_Mario_Maker_2Epic_Tetris_Super_Mario_Maker_2  5   	   0    *Epic_Tetris_Super_Mario_Maker_2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Epic_Tetris_Super_Mario_Maker_2     5   	   -   5          ? Title$  Epic Tetris??5   	   $	??600??6   $	??800??6*   $	??600??5	   	   $	??600??6   
???????$??Segoe UI)?5   	   $??28(?6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   ??5   
   ?? 5       ?? ImageSource$' !Assets\SMB3\Ground\Background.png??6   .+?5   
   (? $??1??6   $??1??5      $??0,0,0,20q?5      .??5      ?? -   5         ??Name$ 
GameCanvas??5      ???#93BBEC$	??250??5      $	??510??5       }?. 5"      5#      ?? 5$   
   -   5         ??Name$ 	ScoreText??5$      $??0??5%      $??1??5&      $??Score: ??5'      $
??0,10q?5(       ?? TextAlignment$ Center=?5)      ?? 5*   
   $??1??6   $??0??5+      $??Center=?5,      $??Right=?5-      .+?5.      ?? $
??Hold??6   $ Center=?5/      ?? 50      -   5         ??Name$ 	HoldImage??50      $??20q?51      $	??125??52      53      ?? 54   
   $??1??6   $??2??55      $??Center=?56      $
??Left=?57      .+?58      ?? $
??Next??6   $ Center=?59      ?? 5:      -   5        $ 	NextImage??5:      $??20q?5;      $	??125??5<      5=      ? 5>   
   -   5         ?Name$ GameOverMenu??5>      ???	#CC000000$??2??5@      $??3??5A      $y?Hidden=?5B      .+?5C      ?? $??Center=?6   $??Center=?5D      .+?5E      ?? $??	Game Over??6   $??48(?5F      $ Center=?5G      ?? 5H      -   5        $ FinalScoreText??5H      $??Score: ??5I      $??36(?5J      $ Center=?5K      ?? 5L      -   5        $??
Play Again??5L      
???????$??0,20,0,0q?5N      $??5q?5O      5P      ?? 5Q      -	   5        $
??Quit??5Q      
????p??$??0,20,0,0q?5S      $??5q?5T      5U      5V      5W      5X      5Y      