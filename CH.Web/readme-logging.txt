
1.日志接口使用log4net+Common.Logging .
2 log4net 单独有配置文件在主目录下
3.Common.Logging 配置文件在Web.app主目录下（一定要放到主目录）
4.数据库存查询操作日志存放在 Linq2DBInfoAppender (使用log.Info())  见 logger Linq2db配置
5.数据库存查询操作错误日志存放在 Linq2DBErrorAppender (使用log.Error())  见 logger Linq2db配置
6.Web系统信息 SysInfoAppender  (使用log.Info())    见 logger Sys配置
7.Web系统错误信息 SysErrorAppender  (使用log.Error())  见 logger Sys配置
8 其它使用log.info.error === [见root配置]

使用地方 4 5 在linq2db 中的DataConnection 类中

6。7 现只使用一个error 在global.cs中