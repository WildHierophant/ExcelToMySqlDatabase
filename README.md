# ExcelToMySqlDatabase
导出Excel表格对应数据至MySql数据库的工具  

## 使用说明：
1.工具读取表格的表格需要修改Sheet1表格页面的名称，不能以Sheet或sheet开头，也不能为空，否则无法导出  
2.表格填写格式为，第一行不读，可作为备注行，第二行为表头，不能为空，第三行为单元格类型，不能为空，且单元格的类型必须与第三行开始往后的数据类型一致  
3.数据库格式为，数据库名必须为对应需读取的excel表格的第一工作表的表名的小写加上_table，如：需导出一张名为student的表，则数据库要命名为student_table  
4.数据库的字段格式为，第一列为key段，必须命名为id，第二列开始则读取excel表格的对应字段，对应数据库表头命名规则为，excel表名的小写加上excel表头的小写，如：需导出student表中的id与studentName两个字段，则对应的MySQL数据库中的表头应该增加studentid与studentstudentName两个字段  
5.工具会检测表格地址目录下，除子文件夹目录外的的所有文件xlsx与xls格式文件，并识别带填写的识别后缀的表格文件进行读取  

## 使用步骤：
1.填入需要转换的表格所在地址  
2.填入导出目录地址后  
3.点击导出Json按钮即可导出Json文件  

## 效果图
![image](https://github.com/WildHierophant/ExcelToMySqlDatabase/blob/master/202071-102243.jpg)
![image](https://github.com/WildHierophant/ExcelToMySqlDatabase/blob/master/202071-102501.jpg)

Excel导出为MySqlDatabase工具.rar，压缩包中为编译好的文件，ExcelToMySqlDatabase文件夹为原始工程文件  
