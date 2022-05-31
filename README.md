# Setup

## Visual Studio 2022

* 選擇 .NET桌面開發和ASP.NET與網頁程式開發

* 在個別元件裡勾選安裝 .NET 5.0

## MySql installer

1. MySql Server 8.0.29

* 名稱任意英文即可

* 密碼請設為 root (大小寫需相符)

* 其餘預設值即可

2. MySQl Workbench 8.0.29
* 建議安裝以管理資料庫並可進行drop table

## NuGet套件

1. 方案總管: 在專案名稱(OnlineShop)滑鼠右鍵，找到 "管理NuGet套件"

2. 安裝下列功能:

* Microsoft.EntityFrameworkCore 5.0.17
  
* Microsoft.EntityFrameworkCore.Design 5.0.17
  
* Microsoft.EntityFrameworkCore.SqlServer 5.0.17
  
* Microsoft.EntityFrameworkCore.Tools 5.0.17
  
* MySql.Data 8.0.29
  
* MySql.EntityFrameworkCore 5.0.13
  
* Pomelo.EntityFrameworkCore.MySql 5.0.4
  
* System.Data.SqlClient 4.8.3

3. 工具裡找到 "NuGet套件管理員" 中找到 "套件管理器主控台"
4. 刪除所有在"Migrations"資料夾內的所有檔案 (如果有的話，通常裡面只有.cs檔案，不要刪到資料夾)
5. 若沒有Migrations資料夾請自行創建
6. 輸入下列指令，不得出現任何錯誤

* add-migration DB

* update-database
* 
* 若有錯誤出現，請drop OnlineShop裡的所有table和刪除所有在"Migrations"資料夾內的所有檔案後重試
