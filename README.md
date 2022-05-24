# Setup

## Visual Studio 2022

* 選擇 .NET桌面開發

* 在個別元件裡勾選安裝 .NET 5.0

## MySql installer

1. MySql Server 8.0.29

* 名稱請設為 localhost (大小寫需相符)

* 密碼請設為 root (大小寫需相符)

* 其餘預設值即可

2. MySQl Workbench 8.0.29
* 選擇性安裝

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
4. 輸入下列指令，不得出現任何錯誤

* add-migration DB

* update-database
* 
* 若有錯誤出現，請drop OnlineShop裡的所有table後重試
